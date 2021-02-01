namespace GenericCollectionClass
{
    using System.Collections.Generic;
    using System.Linq;

    public class NumSet
    {
        public NumSet(params int[] input)
        {
            this.Collection = new List<int>(input);
        }

        private List<int> Collection { get; }

        public static implicit operator int[](NumSet numSet)
        {
            return numSet.Collection.ToArray();
        }

        public static bool operator ==(NumSet? leftHand, NumSet? rightHand)
        {
            if (leftHand is null)
            {
                return rightHand is null;
            }

            return leftHand.Equals(rightHand);
        }

        public static bool operator !=(NumSet leftHand, NumSet rightHand)
        => !(leftHand == rightHand);

        public override string ToString()
        {
            return string.Join(", ", this.Collection.ToArray());
        }

        public override int GetHashCode()
        {
            List<int> sorted = this.Collection.ToList();

            sorted.Sort();
            string hashCode = string.Empty;
            foreach (int num in sorted)
            {
                hashCode += num.GetHashCode();
            }

            return int.Parse(hashCode);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not NumSet numSet)
            {
                return false;
            }

            return obj.GetHashCode() == this.GetHashCode();
        }

        public int[] GetArray()
        {
            return this.Collection.ToArray();
        }
    }
}