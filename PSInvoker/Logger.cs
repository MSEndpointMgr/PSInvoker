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
            string logPath = Environment.ExpandEnvironmentVariables("%TEMP%\\PSInvoker.log");

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
