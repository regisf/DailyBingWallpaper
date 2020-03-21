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
    /// <summary>
    /// Handle the image on hard drive
    /// </summary>
    internal class ImageStorage : Storage
    {
        /// <summary>
        /// The image in memory
        /// </summary>
        internal System.Drawing.Image Image { get; set; }

        /// <summary>
        /// Name of the image as given by bing servers
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// The image path. Where the image is stored
        /// </summary>
        internal string Path { get; private set; }

        /// <summary>
        /// Create a new Image storage from the given argument
        /// </summary>
        /// <param name="image">The image stored in memroy</param>
        /// <param name="name">The image name as given by the Bing servers request</param>
        internal ImageStorage(System.Drawing.Image image, string name)
        {
            Image = image;
            Name = name;
            Path = CreateImagePath(Name);
        }

        /// <summary>
        /// Try to get the image from the HD using the Result Storage
        /// </summary>
        internal ImageStorage(BingImage bingImage)
        {
            Name = bingImage.Name;
            Path = CreateImagePath(Name);
            Image = Load();
        }

        /// <summary>
        /// Save the image in memory to the hard drive
        /// </summary>
        internal void Save()
        {
            Image.Save(Path);
        }

        /// <summary>
        /// Load image from the storage
        /// </summary>
        /// <returns>The image in memory</returns>
        private System.Drawing.Image Load()
        {
            return System.Drawing.Image.FromFile(Path);
        }

        /// <summary>
        /// Remove all previous image regardering the user preferences
        /// </summary>
        internal void RemovePreviousImage()
        {
            Logger.Log("Try to remove all previous wallpaper");

            if (!ConfigurationMgt.GetInstance().Configuration.DeleteImage)
            {
                Logger.Log("The configuration disallow to remove images");
                return;
            }

            var filePathes = GetFilePathes();
            var currentImagePath = GetCurrentImagePath();

            Logger.Log("There is {0} files to remove", filePathes.Length - 1);
            foreach (var path in filePathes)
            {
                if (path == currentImagePath)
                {
                    continue;
                }

                Logger.Log("Deleting {0}", path);
                try
                {
                    File.Delete(path);
                } 
                
                catch(Exception err)
                {
                    Logger.Error("Unable to delete the file {0} because of {1}", path, err.ToString());
                }
            }

            Logger.Log("All images deleted");
        }

        /// <summary>
        /// Returns all files inside the image files directory
        /// </summary>
        /// <returns>The file pathes from image files directory</returns>
        /// <see cref="ConfigurationDO.SavePath"/>
        private string[] GetFilePathes()
        {
            var savepath = ConfigurationMgt.GetInstance().Configuration.SavePath;
            return Directory.GetFiles(savepath, "*.jpg", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Construct the current image path
        /// </summary>
        /// <returns>The current image path</returns>
        private string GetCurrentImagePath()
        {
            var imageName = new ResultStorage().Load().First.Name;
            return CreateImagePath(imageName);
        }
    }
}
