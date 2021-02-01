namespace GenericCollectionClass.SetWriterSpace
{
    using System;
    using System.IO;

    public class SetWriter : IDisposable
    {
        private bool disposedValue;

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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.StreamWriter.Close();
                    this.StreamWriter.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
