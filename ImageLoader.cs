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

using System.Drawing;
using System.IO;
using System.Net;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// 
    /// </summary>
    class ImageLoader
    {
        /// <summary>
        /// The Bing search engine base url
        /// </summary>
        public static string BingBaseUrl = "https://bing.com";

        /// <summary>
        /// Create an URL from the given URL
        /// </summary>
        /// <param name="url"></param>
        public ImageLoader(string url)
        {
            Url = BingBaseUrl + url;
        }

        /// <summary>
        /// Property for the URL which is normally an URI
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Load the image from the Internet.
        /// </summary>
        /// <returns></returns>
        public Image LoadImage()
        {
            WebClient webClient = new WebClient();
            var data = webClient.DownloadData(Url);
            MemoryStream stream = new MemoryStream(data);

            return Image.FromStream(stream);
        }
    }
}
