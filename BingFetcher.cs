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

using System.Net.Http;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// 
    /// </summary>
    internal class BingFetcher
    {
        const string BingUrl = "https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt={0}";

        /// <summary>
        /// Create the
        /// </summary>
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Get information from the bing server
        /// </summary>
        /// <returns>A Bing Result</returns>
        public BingResult Fetch()
        {
            var bingUrl = string.Format(BingUrl, ConfigurationMgt.GetInstance().Configuration.CultureName);
            var response = client.GetAsync(bingUrl).Result;
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;
            var converted = BingResult.FromString(result);

            return converted;
        }
    }
}
