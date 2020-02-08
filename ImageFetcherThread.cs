/*
 * Daily Bing Wallpaper
 * Copyright (C) 2020 Regis FLORET
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Threading;
using static DailyBingWallpaper.ConfigurationDO;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// Thead to load the image either from hard drive or from the internet
    /// 
    /// </summary>
    internal class ImageFetcherThread
    {
        private Thread LoaderThread { get; set; }

        private System.Timers.Timer WakeupTimer { get; set; }
        public event HasImageHandler HasImage;

        private void Run()
        {
            Logger.Log("The fetcher thread starts");

            var config = ConfigurationMgt.GetInstance().Configuration;
            switch (config.WhenToFetch)
            {
                case FetchType.OnceOnStart:
                    LoadNow();
                    break;

                case FetchType.Manually:
                    return;


                case FetchType.WithServerTimestamp:
                    LoadWithServerTimestap();
                    break;
            }
        }

        private void LoadWithServerTimestap()
        {
            Logger.Log("Loading with timestamp");
            bool loaded = false;

            var storage = new ResultStorage();
            if (!storage.Exists)
            {
                Logger.Warning("There is no storage. Is it the  first time?. Load image now.");
                
                LoadNow();
                loaded = true;
            } 

            var bingImage = storage.Load().First;
            var endDate = ToDate(bingImage.EndDate.ToString());
            var timeDiff = DateTime.Now - endDate;

            if (timeDiff.Days <= 0)
            {
                Logger.Info("The end date is in the future ({0}). Nothing to do.", bingImage.EndDate);
            }

            else
            {
                Logger.Info("Ooops! We are late. Reload the image.");

                if (!loaded)
                {
                    LoadNow();
                }
            }

            SetupNextLoad(timeDiff.TotalMilliseconds);
            
            var imageStorage = new ImageStorage(bingImage);
            imageStorage.RemovePreviousImage();
        }

        private void SetupNextLoad(double remaining)
        {
            Logger.Log("Start the timer for the next call");
            var remainingMilliSeconds = Math.Floor(remaining);

            SetupWakeTimer(remainingMilliSeconds);
        }

        private void SetupWakeTimer(double remainingMilliSeconds)
        {
            Logger.Log("Create the timer. Reload in {0} ms", remainingMilliSeconds);

            WakeupTimer = new System.Timers.Timer(remainingMilliSeconds);
            WakeupTimer.Enabled = true;
            WakeupTimer.AutoReset = false;
            WakeupTimer.Elapsed += (s, a) => LoadWithServerTimestap();
            WakeupTimer.Start();
        }

        private DateTime ToDate(string date)
        {
            Logger.Log("Convert the date from string to .Net datetime");
            return DateTime.ParseExact(date,
                                       "yyyyMMdd",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }

        internal void LoadNow()
        {
            Logger.Log("Load the image now and ");
            var loader = new BingLoader(); 
            loader.HasResult += OnHaveResult;
            loader.HasImage += OnHaveImage;
            loader.Load();
        }

        private void OnHaveImage(object source, HasImageEventArgs e)
        {
            Logger.Log("Got an image. Save it and set it as a wallpaper");
            
            var storage = new ImageStorage(e.Image, e.Name);
            storage.Save();
            SystemCallsMgt.SetImageAsWallpaper(storage.Path);

            // Emit event
            HasImage(this, e);
        }

        private void OnHaveResult(object source, HasImageResultEventArgs e)
        {
            Logger.Log("Got a Bing server response. Save the result json as a file");
            
            var storage = new ResultStorage(e.Result);
            storage.Save();
        }

        /// <summary>
        /// Stop the internal thread
        /// </summary>
        internal void Stop()
        {
            Logger.Log("Stop the fetcher thread");
            
            LoaderThread.Abort();
        }

        /// <summary>
        /// Start the internal thread
        /// </summary>
        /// <see cref="ImageFetcherThread.Run"/>
        internal void Start()
        {
            Logger.Log("Start the fetcher thread");
            
            LoaderThread = new Thread(new ThreadStart(Run));
            LoaderThread.Start();
        }
    }
}
