using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenericCollectionClass
{
    public class NumSet
    {
        private List<int> Collection { get; }
        
        public NumSet(params int[] input)
        {
            Collection = new List<int>(input);
        }

        public override string ToString()
        {
            return string.Join(", ", Collection.ToArray());
        }

        public override int GetHashCode()
        {
            List<int> sorted = Collection.ToList();

            sorted.Sort();
            string hashCode = string.Empty;
            foreach(int num in sorted)
            {
                hashCode += num.GetHashCode();
            }
            
            return int.Parse(hashCode);
        }
        public override bool Equals(object? obj)
        {
            if(obj is not NumSet numSet)
            {
                return false;
            }
            return obj.GetHashCode() == this.GetHashCode();
        }

        public static bool operator ==(NumSet? leftHand, NumSet? rightHand)
        {
            if(leftHand is null)
            {
                return rightHand is null;
            }
            return leftHand.Equals(rightHand);
        }
        public static bool operator !=(NumSet leftHand, NumSet rightHand) 
                => !(leftHand == rightHand);

        public int[] GetArray()
        {
            return this.Collection.ToArray();
        }
    }

    public class SetWriter : IDisposable
    {
        private bool DisposedValue;

        public SetWriter(string filePath)
        {
            this.StreamWriter = new StreamWriter(filePath 
                ?? throw new ArgumentNullException($"{nameof(SetWriter)} cannot be instantiated because of a null filePath"));
        }
        private StreamWriter StreamWriter { get; }

        public void WriteToStream(string message)
        {
            this.StreamWriter.Write(message);
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