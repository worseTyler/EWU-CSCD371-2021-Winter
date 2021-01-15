using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; private set; } // Get rid of private set??
        public override void Log(LogLevel logLevel, string message)
        {
            File.AppendAllText(FilePath, $"{DateTime.Now} {Name} {logLevel} : {message} \n");
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException($"FilePath was null in the {nameof(FileLogger)}");
        }
    }
}