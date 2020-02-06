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
using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// Display current image information.
    /// </summary>
    public partial class InformationDialog : Form
    {

        /// <summary>
        /// Constructor. Setup labels with information.
        /// </summary>
        public InformationDialog()
        {
            InitializeComponent();

            var resultStorage = new ResultStorage();
            Image = resultStorage.Load().First;

            titleLabel.Text = Image.Title;
            copyrightLabel.Text = Image.Copyright;
        }

        /// <summary>
        /// Get or set the BingImage as found from the bing result JSON
        /// </summary>
        /// <see cref="BingImage"/>
        BingImage Image { get; set; }

        /// <summary>
        /// Close the dialog. Responds to a click on OkButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Link is clicked. Go to the web size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Image.CopyrightLink);
        }
    }
}
