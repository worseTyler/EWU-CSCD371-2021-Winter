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
            FileStream fileStream = new FileStream(FilePath, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("this is a test");
            fileStream.Close();
            return;
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(FileLogger));
        }
    }
}
