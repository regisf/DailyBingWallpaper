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

using System.IO;
using System.Xml.Serialization;

namespace DailyBingWallpaper 
{
    internal class ConfigurationMgt : Storage
    {
        private static string ConfigurationFileName = "configuration.xml";

        public ConfigurationMgt()
        {
            // At least it must exists
            Configuration = new ConfigurationDO();
        }

        static ConfigurationMgt _configMgt = null;

        internal static ConfigurationMgt GetInstance()
        {
            if (_configMgt == null)
            {
                _configMgt = new ConfigurationMgt();
                _configMgt.Load();
            }

            return _configMgt;
        }

        internal ConfigurationDO RecreateConfiguration()
        {
            if (File.Exists(ConfigurationFilePath(ConfigurationFileName)))
            {
                File.Delete(ConfigurationFilePath(ConfigurationFileName));
            }

            CreateDefaultFile();

            return Configuration;
        }

        internal ConfigurationDO Configuration { get; set; }

        /// <summary>
        /// Try to load the configuration file. If this file is missing,
        /// we create the object with default values and then, we save
        /// the new configuration file.
        /// </summary>
        /// <returns>The configuration object</returns>
        internal ConfigurationDO Load()
        {
            try
            {
                using (StreamReader reader = File.OpenText(ConfigurationFilePath(ConfigurationFileName)))
                {
                    var type = Configuration.GetType();
                    XmlSerializer serializer = new XmlSerializer(type);
                    Configuration = (ConfigurationDO)serializer.Deserialize(reader);
                }
            }

            catch (FileNotFoundException)
            {
                CreateDefaultFile();
            }

            return Configuration;
        }

        private void CreateDefaultFile()
        {
            Configuration.SetDefault();
            Save();
        }

        internal void Save()
        {
            using (StreamWriter writer = File.CreateText(ConfigurationFilePath(ConfigurationFileName)))
            {
                var type = Configuration.GetType();
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(writer, Configuration);
            }
        }

        internal void Update(ConfigurationDO configuration)
        {
            Configuration.Update(configuration);
            Save();
        }

        /// <summary>
        /// Reset the application preferences by creating a default configuration file
        /// This method exists to give a meaning to the code.
        /// </summary>
        internal void Reset()
        {
            CreateDefaultFile();
        }

        internal void SetFirstTime(bool firstTime)
        {
            Configuration.IsFirstTime = firstTime;
            Save();

        }
    }
}
