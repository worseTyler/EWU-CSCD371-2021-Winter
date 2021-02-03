using System;

namespace Generics
{
    public class Threeple<TFirst, TSecond, TThird>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description
        {
            get
            {
                return $"First: {First.ToString()}\nSecond: {Second.ToString()}\nThird: {Third.ToString()}";
            }
        }

        public Threeple(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public static (T1, T2, T3) Deconstruct<T1, T2, T3>(Threeple<T1, T2, T3> threeple)
        {
            return (threeple.First, threeple.Second, threeple.Third);
        }
    }

    public class ThreepleDescription<TFirst, TSecond, TThird> where TFirst : IDescription
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description
        {
            get
            {
                return $"First: {First.Description}\nSecond: {Second.ToString()}\nThird: {Third.ToString()}";
            }
        }

        public ThreepleDescription(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
    }

    public interface Serializer<T>
    {
        public void Serialize(T thing);

       
    }
    public interface Deserializer<out T>
    {
        public T Deserialize(int id);
    }
}
