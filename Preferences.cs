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
using System.Globalization;
using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();

            SetupGUI();
        }

        private void SetupGUI()
        { 
            var config = ConfigurationMgt.GetInstance().Configuration;

            pathTextBox.Text = config.SavePath;
            launchOnWindowsStarts.Checked = config.StartsWithWindows && RegistryMgt.KeyExists();
            deleteImageCheckBox.Checked = config.DeleteImage;

            switch (config.WhenToFetch)
            {
                case ConfigurationDO.FetchType.Manually:
                    fetchManuallyRadioButton.Checked = true;
                    break;

                case ConfigurationDO.FetchType.OnceOnStart:
                    fetchOnProgramStartsRadioButton.Checked = true;
                    break;

                case ConfigurationDO.FetchType.WithServerTimestamp:
                    fetchUsingServerTimeRadioButton.Checked = true;
                    break;
            }

            SetCulturesLanguages(config.CultureName);
        }

        /// <summary>
        /// Set up the language combo box.
        /// </summary>
        private void SetCulturesLanguages(string configCultureName)
        {
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures & ~CultureTypes.NeutralCultures);

            int index = 0;

            for (int i = 0; i < cultureInfos.Length; i++)
            {
                var culture = cultureInfos[i];

                languageSelect.Items.Add(String.Format("{0} - {1}", culture.DisplayName, culture.Name));

                if (culture.Name == configCultureName)
                {
                    index = i;
                }
            }

            languageSelect.SelectedIndex = index;
        }

        private void SearchPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }

            pathTextBox.Text = dlg.SelectedPath;
        }

        internal bool IsApplied { get; private set; }

        private void SavePreferences()
        {
            var configMgt = ConfigurationMgt.GetInstance();
            var config = configMgt.Configuration;

            config.SavePath = pathTextBox.Text;
            config.StartsWithWindows = launchOnWindowsStarts.Checked;
            config.DeleteImage = deleteImageCheckBox.Checked;
            config.AllowMetricsSend = allowMetricsSendCheckBox.Checked;

            SetConfigFetchFromGUI(ref config);

            RegistryMgt.SetApplicationRunAtWindowsStartup(config.StartsWithWindows);

            configMgt.Save();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            IsApplied = true;
            SavePreferences();
        }

        internal ConfigurationDO GetConfiguration()
        {
            ConfigurationDO config = new ConfigurationDO();
            config.DeleteImage = deleteImageCheckBox.Checked;
            config.IsFirstTime = false;
            config.SavePath = pathTextBox.Text;
            config.StartsWithWindows = launchOnWindowsStarts.Checked;
            SetConfigFetchFromGUI(ref config);

            return config;
        }

        private void SetConfigFetchFromGUI(ref ConfigurationDO config)
        {
            if (fetchManuallyRadioButton.Checked)
            {
                config.WhenToFetch = ConfigurationDO.FetchType.Manually;
            }

            else if (fetchOnProgramStartsRadioButton.Checked)
            {
                config.WhenToFetch = ConfigurationDO.FetchType.OnceOnStart;
            }

            else if (fetchUsingServerTimeRadioButton.Checked)
            {
                config.WhenToFetch = ConfigurationDO.FetchType.WithServerTimestamp;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset the application preferences?",
                "Reset preferences",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ConfigurationMgt.GetInstance().Reset();
                SetupGUI();
            }
        }
    }
}
