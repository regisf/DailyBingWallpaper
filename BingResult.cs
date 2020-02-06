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

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DailyBingWallpaper 
{
    [DataContract]
    internal class BingImage
    {
        [DataMember(Name = "enddate")]
        public long EndDate { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "copyright")]
        public string Copyright;

        [DataMember(Name = "copyrightlink")]
        public string CopyrightLink;

        [DataMember(Name = "title")]
        public string Title;

        /// <summary>
        /// Get the name of the image. 
        /// The name is inside the Url field as a parameter (id)
        /// </summary>
        public string Name
        {
            get
            {
                var parameters = Url.Split('?')[1];
                string[] splitted = parameters.Split('&');
                Dictionary<string, string> paramDictionnary = new Dictionary<string, string>();
                foreach (var parameter in splitted)
                {
                    var keyVal = parameter.Split('=');
                    paramDictionnary.Add(keyVal[0], keyVal[1]);
                }

                return paramDictionnary["id"];
            }
        }
    }

    [DataContract]
    internal class BingResult
    {
        private string content;

        [DataMember(Name = "images")]
        public List<BingImage> Images { get; set; }

        /// <summary>
        /// Convert the request result as a wallpaper object
        /// </summary>
        /// <param name="content">The HTTP body as string</param>
        /// <returns>The wallpaper object from the content</returns>
        public static BingResult FromString(string content)
        {
            var bingResult = new BingResult();

            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var serializer = new DataContractJsonSerializer(bingResult.GetType());

            bingResult = serializer.ReadObject(memoryStream) as BingResult;
            bingResult.content = content;
            memoryStream.Close();

            return bingResult;

        }

        /// <summary>
        /// Usually there's only one element into the list send by the server.
        /// </summary>
        public BingImage First
        {
            get
            {
                return Images[0];
            }
        }

        /// <summary>
        /// Return the value of the JSON
        /// </summary>
        /// <returns>The JSON file as a string</returns>
        override public string ToString()
        {
            return content;
        }
    }
}
