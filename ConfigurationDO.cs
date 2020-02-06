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
using System.Globalization;
using System.IO;

namespace DailyBingWallpaper 
{
    [Serializable()]
    public class ConfigurationDO
    {
        public enum FetchType
        {
            Manually,
            OnceOnStart,
            WithServerTimestamp
        }

        public string SavePath { get; set; }

        public bool StartsWithWindows { get; set; }

        public bool IsFirstTime { get; set; }

        public FetchType WhenToFetch { get; set; }

        public bool DeleteImage { get; set; }

        public string CultureName { get; set; }

        public bool AllowMetricsSend { get; set; }

        internal void SetDefault()
        {
            var picturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            SavePath = Path.Combine(picturePath, "Bing Wallpapers");
            StartsWithWindows = false;
            IsFirstTime = true;
            WhenToFetch = FetchType.WithServerTimestamp;
            DeleteImage = true;
            CultureName = CultureInfo.CurrentCulture.Name;
            AllowMetricsSend = false;
        }

        internal void Update(ConfigurationDO configuration)
        {
            IsFirstTime = configuration.IsFirstTime;
            SavePath = configuration.SavePath;
            StartsWithWindows = configuration.StartsWithWindows;
            WhenToFetch = configuration.WhenToFetch;
            DeleteImage = configuration.DeleteImage;
            CultureName = configuration.CultureName;
            AllowMetricsSend = configuration.AllowMetricsSend;
        }
    }
}