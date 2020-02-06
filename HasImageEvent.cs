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

namespace DailyBingWallpaper 
{
    delegate void HasImageHandler(object source, HasImageEventArgs e);
    delegate void HasImageResultHandler(object source, HasImageResultEventArgs e);

    internal class HasImageEventArgs : EventArgs
    {
        public HasImageEventArgs(System.Drawing.Image image, string name)
        {
            Image = image;
            Name = name;
        }

        public System.Drawing.Image Image { get; private set; }

        public string Name { get; private set; }
    }

    internal class HasImageResultEventArgs : EventArgs
    {

        public HasImageResultEventArgs(BingResult result)
        {
            Result = result;
        }

        public BingResult Result { get; private set; }
    }
}
