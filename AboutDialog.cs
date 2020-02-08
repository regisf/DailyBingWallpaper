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

using System.Reflection;
using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// Display an about box dialog
    /// </summary>
    public partial class AboutDialog : Form
    {
        /// <summary>
        /// Ctor. Set up the version from the Assembly
        /// </summary>
        public AboutDialog()
        {
            InitializeComponent();
            versionLabel.Text = string.Format(versionLabel.Text, Assembly.GetEntryAssembly().GetName().Version);
        }

        /// <summary>
        /// Display the license box (GPL3)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void licenseButton_Click(object sender, System.EventArgs e)
        {
            LicenseDialog dialog = new LicenseDialog();
            dialog.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/regisf/DailyBingWallpaper");
        }
    }
}
