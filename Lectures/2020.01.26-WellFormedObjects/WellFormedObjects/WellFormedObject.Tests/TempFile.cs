using System;
using System.IO;

namespace WellFormedObject.Tests
{
    public sealed class TempFile : IDisposable
    {
        private bool _DisposedValue;

        public string FilePath { get; }

        public TempFile()
        {
            FilePath = Path.GetTempFileName();
        }

        private void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    File.Delete(FilePath);
                }
                
                _DisposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
