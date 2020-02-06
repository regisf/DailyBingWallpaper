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

using System.IO;

namespace DailyBingWallpaper 
{
    internal class ResultStorage : Storage
    {
        const string DailyJsonFile = "daily_bing_image.json";

        internal ResultStorage(BingResult result = null)
        {
            Result = result;
        }

        internal BingResult Result { get; set; }
        
        public bool Exists
        {
            get
            {
                return File.Exists(ConfigurationFilePath(DailyJsonFile));
            }
        }


        internal void Save()
        {
            var filePath = ConfigurationFilePath(DailyJsonFile);

            using (StreamWriter writer = File.CreateText(filePath))
            {
                if (Result != null)
                {
                    writer.Write(Result.ToString());
                }
            }
        }

        internal BingResult Load()
        {
            var filePath = ConfigurationFilePath(DailyJsonFile);
            using (StreamReader reader = File.OpenText(filePath))
            {
                var content = reader.ReadToEnd();
                return BingResult.FromString(content);
            }
        }

        internal bool HasResult()
        {
            var filePath = ConfigurationFilePath(DailyJsonFile);
            return File.Exists(filePath);
        }
    }
}
