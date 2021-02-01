using System;
using System.IO;

namespace GenericCollectionClass.SetWriterSpace
{
    public class SetWriter : IDisposable
    {
        private bool DisposedValue;

        public SetWriter(string filePath)
        {
            this.StreamWriter = new StreamWriter(filePath
                ?? throw new ArgumentNullException($"{nameof(SetWriter)} cannot be instantiated because of a null filePath"));
        }
        private StreamWriter StreamWriter { get; }

        public void WriteToStream(NumSet set)
        {
            this.StreamWriter.Write(set.ToString());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.DisposedValue)
            {
                if (disposing)
                {
                    StreamWriter.Close();
                    StreamWriter.Dispose();
                }
                this.DisposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
