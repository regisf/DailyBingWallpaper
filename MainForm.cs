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
    public partial class MainForm : Form
    {
        internal ImageFetcherThread ImageFetcher { get; private set; }

        private delegate void SafeCallDelegate(object source, HasImageEventArgs e);

        public MainForm()
        {
            Logger.Log("MainForm construction");

            InitializeComponent();

            ShowPreferencesDialogIfRequired();

            ConnectEvents();
            StartFetcherThread();

            Load += OnMainFormLoad;
            Activated += (sender, args) =>
           {
               var resultStorage = new ResultStorage();
               var bingResult = resultStorage.Load();
               var imgStorage = new ImageStorage(bingResult.First) ;
               pictureBox.Image = imgStorage.Image;
           };
        }

        /// <summary>
        /// Start the application as Hidden form.
        /// </summary>
        /// <param name="sender">The main window form</param>
        /// <param name="e">The associated event object</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => { Hide(); }));
        }

        /// <summary>
        /// Connect all events that couldn't be connected with the form builder
        /// </summary>
        private void ConnectEvents()
        {
            Logger.Log("Connect all events to the form");

            Application.ApplicationExit += EndFetcherThread;
            quitToolStripMenuItem.Click += (sender, args) => Application.Exit();
        }

        /// <summary>
        /// Create and start the fetcher object. as a separated thread
        /// to avoid program blocking. 
        /// </summary>
        /// <see cref="ImageFetcherThread"/>
        private void StartFetcherThread()
        {
            Logger.Log("Start fetcher thread");

            ImageFetcher = new ImageFetcherThread();
            ImageFetcher.Start();

            ImageFetcher.HasImage += OnHasImage;
        }

        /// <summary>
        /// Stop and close the image fetcher thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <see cref="ImageFetcherThread"/>
        private void EndFetcherThread(object sender, EventArgs e)
        {
            Logger.Log("End the fetcher thread");

            ImageFetcher.Stop();
        }

        private void OnDisplayAboutDialog(object sender, EventArgs e)
        {
            Logger.Log("Display about dialog");

            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }

        /// <summary>
        /// Display the preferences dialog on first launch. 
        /// First we ask for default preferences and if the user
        /// wants to set its own preferences, display the preference dialog
        /// </summary>
        /// <see cref="MainFrom.ShowPreferences"/>
        private void ShowPreferencesDialogIfRequired()
        {
            Logger.Log("Show preferences dialog");

            if (LoadConfiguration().IsFirstTime)
            {

                var result = MessageBox.Show(
                "It seems it the first time you start Bing Wallpaper. " +
                "Do you which to create new preferences? ",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ShowPreferences();
                }

                ConfigurationMgt.GetInstance().SetFirstTime(false);
            }
        }

        private ConfigurationDO LoadConfiguration()
        {
            Logger.Log("Load the configuration");

            ConfigurationDO config;
            var configMgt = ConfigurationMgt.GetInstance();
            
            try
            {
                config = configMgt.Configuration;
            }

            catch (InvalidOperationException)
            {
                Logger.Warning("The configuration doesn't exist or it is corrupted.");

                var dialogResult = MessageBox.Show(
                    "It seems the configuration file is damaged. " +
                    "A new configuration file will be created.",
                    "Reload with default?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                config = configMgt.RecreateConfiguration();
                configMgt.SetFirstTime(false);
            }

            return config;

        }

        /// <summary>
        /// Respond to a
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnHasImage(object source, HasImageEventArgs e)
        {
            Logger.Log("Having an image. Set the Image object for the form");

            var image = e.Image;
            pictureBox.Image = image;
        }

        private void OnShowPreferencesDialog(object sender, EventArgs e)
        {
            Logger.Log("Display the preferences dialog (proxy method)");
            ShowPreferences();
        }

        /// <summary>
        /// Display the preferences dialog. 
        /// If the user clicked on the OK button, save the preferences
        /// </summary>
        /// <see cref="Preferences"/>
        /// <see cref="ConfigurationDO"/>
        /// <see cref="ConfigurationMgt"
        private void ShowPreferences()
        {
            Logger.Log("Display the preferences dialog");

            using (var preferenceDlg = new Preferences())
            {
                if (preferenceDlg.ShowDialog() == DialogResult.OK)
                {
                    if (!preferenceDlg.IsApplied)
                    {
                        Logger.Info("Save the preferences");
                        var configuration = preferenceDlg.GetConfiguration();
                        ConfigurationMgt.GetInstance().Update(configuration);
                    }
                }
                else
                {
                    Logger.Info("Canceling the preferences dialog");
                }
            }
        }

        /// <summary>
        /// Responds to a Resize event. Hide the from if  it is minimized
        /// </summary>
        /// <see cref="MainForm.HideForm"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormHasBeenResized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideForm();
            }
        }

        /// <summary>
        /// When the notify icon is double clicked. Display the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIconHasBeenDoubleClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void UpdateNow(object sender, EventArgs e)
        {
            ImageFetcher.LoadNow();
        }

        /// <summary>
        /// Display informations about the daily image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowInformation(object sender, EventArgs e)
        {
            InformationDialog dialog = new InformationDialog();
            dialog.Show();
            
        }

        /// <summary>
        /// Response to a Close Button clicked
        /// </summary>
        /// <param name="sender">Event sender (aka this)</param>
        /// <param name="e">Event args</param>
        private void CloseButton_clicked(object sender, EventArgs e)
        {
            HideForm();
        }

        /// <summary>
        /// Hide the form and set the Notify icon visible.
        /// </summary>
        private void HideForm()
        {
            Hide();
            notifyIcon.Visible = true;
        }
    }
}
