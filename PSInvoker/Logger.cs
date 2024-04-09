using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace PSInvoker
{
    public static class Logger
    {
        public static void WriteLogFile(string message)
        {
            string logPathConfig = ConfigurationManager.AppSettings["LogPath"];
            string logPath = Environment.ExpandEnvironmentVariables(logPathConfig);

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
