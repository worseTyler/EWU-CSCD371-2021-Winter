namespace CanHazFunny
{
    using System;

    public class OutputJokeService : IOutputJoke
    {
        void IOutputJoke.OutputJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
