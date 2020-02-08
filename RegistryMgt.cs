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

using Microsoft.Win32;
using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    /// <summary>
    /// Manage Windows Registry interaction
    /// </summary>
    internal class RegistryMgt
    {
        const string CurrentUserRegistryKeyValue = @"Software\Microsoft\Windows\CurrentVersion\Run";
        const string RegistryKeyValue = @"HKEY_CURRENT_USER\" + CurrentUserRegistryKeyValue;
        const string ApplicationKeyValue = "Daily Bing Wallpaper";

        /// <summary>
        /// Set the application to start with Windows boot. This will manipulate the register database.
        /// </summary>
        /// <param name="startWithWindows">Shall the application starts with windows flag (true if starts false elsewhere)</param>
        internal static void SetApplicationRunAtWindowsStartup(bool startWithWindows)
        {
            if (!startWithWindows)
            {
                RemoveKey();
            }

            else
            {
                InstallKey();
            }
        }

        /// <summary>
        /// Ensure the key "Daily Bing Wallpaper" exists or not
        /// </summary>
        /// <returns>True if the key exists. False elsewhere</returns>
        internal static bool KeyExists()
        {
            return GetRunRegistry() != null;
        }

        /// <summary>
        /// Get the value of the application registry entry
        /// </summary>
        /// <returns>The value of the regitry entry or null</returns>
        static string GetRunRegistry()
        {
            return (string)Registry.GetValue(RegistryKeyValue, ApplicationKeyValue, null);
        }

        /// <summary>
        /// Delete the entry from registry
        /// </summary>
        static void RemoveKey()
        {
            Registry.CurrentUser.OpenSubKey(CurrentUserRegistryKeyValue, true)?.DeleteValue(ApplicationKeyValue);
        }

        /// <summary>
        /// Install the entry into the registry
        /// </summary>
        static void InstallKey()
        {
            Registry.SetValue(RegistryKeyValue, ApplicationKeyValue, Application.ExecutablePath);
        }
    }
}
