using System;
using WellFormedObjects.Barn;

namespace WellFormedObjects
{
    public class Pony
    {
        public int NumLegs { get; init; }
        public string Name { get; init; }

        public Pony(Farmer farmer = null)
        {
            Farmer myFarmer = farmer ?? Farmer.Dale;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj is not Pony pony)
            {
                return false;
            }
            return pony.NumLegs == NumLegs &&
                   pony.Name == Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NumLegs.GetHashCode(), Name?.GetHashCode() ?? 0);
        }

        public static bool operator ==(Pony first, Pony second)
        {
            if (first is null && second is null) return true;
            if (first is null ^ second is null) return false;
            return first.Equals(second);
        }

        public static bool operator !=(Pony first, Pony second)
            => !(first == second);

        public static Pony operator +(Pony pony, string otherName)
        {
            return new Pony
            {
                NumLegs = pony.NumLegs,
                Name = $"{pony.Name} {otherName}"
            };
        }

        public static explicit operator int(Pony pony)
        {
            return pony?.NumLegs ?? -1;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Stuff";
        }
    }
}
