using System;
using System.IO;
using System.Configuration;

namespace Assignment_1
{
    public static class Logger
    {
        public static void WriteLog(string message, string level = "Info", string loggerpath = "logpath")
        {
            string logPath = ConfigurationManager.AppSettings[loggerpath];
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                if (message != "")
                {
                    writer.WriteLine($"{DateTime.Now} : [{level}] : {message}");
                }
                else
                {
                    writer.WriteLine("\n");
                }
            }
        }
    }
}
