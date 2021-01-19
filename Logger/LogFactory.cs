namespace Logger
{
    using System;
    using System.IO;

    public static class LogFactory
    {
        private static string? FilePath { get; set; }

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

#pragma warning disable CS8603 // Want to be able to return null
            return fileLogger;
#pragma warning restore CS8603 // Want to be able to return null
        }

        public static void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
