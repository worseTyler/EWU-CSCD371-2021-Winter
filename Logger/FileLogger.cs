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
            System.Collections.Generic.IEnumerable<string> testString = $"{DateTime.Now:G} {logLevel}: {message}{Environment.NewLine}";
            File.AppendAllLines(FilePath, testString);
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(FileLogger));
        }
    }
}
