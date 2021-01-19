namespace Logger
{
    using System;
    using System.IO;

    public class FileLogger : BaseLogger
    {
        public FileLogger(string? filePath)
        {
            this.FilePath = filePath ?? throw new ArgumentNullException($"FilePath was null in the {nameof(FileLogger)}");
        }

        public string FilePath { get; private set; }

        public override void Log(LogLevel logLevel, string message)
        {
            File.AppendAllText(this.FilePath, $"{DateTime.Now} {this.Name} {logLevel} : {message} \n");
        }
    }
}