using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollectionClass.SetWriterSpace
{
    class SetWriter
    {
        public SetWriter(string filePath)
        {
            this.StreamWriter = new StreamWriter(filePath ?? throw new ArgumentNullException(nameof(SetWriter)));
        }
        private StreamWriter StreamWriter { get; }

        public void WriteToStream(string message)
        {
            this.StreamWriter.Write(message);
        }
    }
}