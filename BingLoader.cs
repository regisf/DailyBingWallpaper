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

namespace DailyBingWallpaper 
{
    internal class BingLoader : ILoader
    {
        public BingResult Result { get; set; }

        public Image Image { get; set; }

        public event HasImageHandler HasImage;
        public event HasImageResultHandler HasResult;

        public void Load()
        {
            BingFetcher fetcher = new BingFetcher();
            Result = fetcher.Fetch();
            HasResult(this, new HasImageResultEventArgs(Result));

            ImageLoader imageLoader = new ImageLoader(Result.First.Url);
            Image = imageLoader.LoadImage();
            HasImage(this, new HasImageEventArgs(Image, Result.First.Name));
        }
    }
}
