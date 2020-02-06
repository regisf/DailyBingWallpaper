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
using System.IO;

namespace DailyBingWallpaper 
{
    internal class Storage
    {
        const string DirectoryName = "DailyBingWallpaper ";

        private void CreateDirectoryIfNotExists(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        internal string GetApplicationFolderPath()
        {
            var userAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dirPath = Path.Combine(userAppData, DirectoryName);

            CreateDirectoryIfNotExists(dirPath);

            return dirPath;
        }

        internal string ConfigurationFilePath(string filename)
        {
            var dirPath = GetApplicationFolderPath();
            var filePath = Path.Combine(dirPath, filename);

            return filePath;
        }

        internal string CreateImagePath(string name)
        {
            var savePath = ConfigurationMgt.GetInstance().Configuration.SavePath;
            var imagePath = Path.Combine(savePath, name);

            return imagePath;
        }


    }
}