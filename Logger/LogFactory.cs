using System;
using System.IO;
namespace Logger
{
    public class LogFactory
    {
        private static string? FilePath;
        public static FileLogger CreateLogger(string className)
        {
            FileLogger? fileLogger;

            if (File.Exists(FilePath))
            {
                fileLogger = new FileLogger(FilePath)
                { Name = className };
            }
            else
            {
                fileLogger = null;
            }

            return fileLogger;
        }

        public static bool ConfigureFileLogger(string filePath)
        {
            if (File.Exists(filePath))
            {
                FilePath = filePath;
                return true;
            } 
            else
            {
                return false;
            }
            
        }
    }
}
