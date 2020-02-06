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
using System.IO;

namespace DailyBingWallpaper 
{
    internal class Logger : Storage
    {
        private const string LogFileName = "daily-bing-wallpaper.log";
        private string LogFormat = "[{0}] - {1:dd/MM/yyyy : HH:mm:ss.ffff} - {2}";
        private const string DebugFormat = " DEBUG ";
        private const string InfoFormat = "  INFO ";
        private const string WarningFormat = "WARNING";
        private const string CriticalFormat = "CRITICAL";

        static Logger _logger = null;

        public enum LogLevel
        {
            NotSet,
            Debug,
            Info,
            Warning,
            Critical
        }

        public Logger()
        {
            var logFilePath = GetLoggerSavePath();
            LogStream = File.CreateText(logFilePath);
        }

        private StreamWriter LogStream { get; set; }

        private string GetLoggerSavePath()
        {
            var dirPath = GetApplicationFolderPath();
            return Path.Combine(dirPath, LogFileName);
        }

        static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public static void Log(string message, params object[] args)
        {
            Info(message, args);
        }

        private static void Log(string message, LogLevel level = LogLevel.Info, params object[] args)
        {
            var levelStr = "";
            switch (level)
            {
#if DEBUG
                case LogLevel.Debug:
                    levelStr = DebugFormat;
                    break;
#endif

                case LogLevel.Info:
                    levelStr = InfoFormat;
                    break;

                case LogLevel.Warning:
                    levelStr = WarningFormat;
                    break;

                case LogLevel.Critical:
                    levelStr = CriticalFormat;
                    break;

                default:
                    break;
            }

            Logger.GetLogger().WriteFormat(String.Format(message, args), levelStr);

        }

        private void WriteFormat(string message, string level)
        {
#if DEBUG
            Console.WriteLine(LogFormat, level, DateTime.UtcNow, message);
#endif
            LogStream.WriteLine(String.Format(LogFormat, level, DateTime.UtcNow, message).ToCharArray());
            LogStream.Flush();
        }

        public static void Debug(string message, params object[] args)
        {
            Log(message, LogLevel.Debug, args);
        }

        public static void Info(string message, params object[] args)
        {
            Log(message, LogLevel.Info, args);
        }

        public static void Critical(string message, params object[] args)
        {
            Log(message, LogLevel.Critical, args);
        }

        public static void Warning(string message, params object[] args)
        {
            Log(message, LogLevel.Debug, args);
        }
    }
}
