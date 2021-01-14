using System;

namespace Logger
{
    public class LogFactory
    {
        private static string? FilePath;
        public static FileLogger CreateLogger()
        {
            FileLogger? fileLogger;
            if (false)
            {
                fileLogger = new FileLogger();
            }
            else
            {
                fileLogger = null;
            }

            return fileLogger;
        }

        public static void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
