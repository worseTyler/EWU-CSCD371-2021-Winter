using System;

namespace CanHazFunny
{
    public class Jester : IJokeService, IOutputJoke
    {
        private IJokeService IJokeService { get; }
        //private IOutputJoke IOutputJoke { get; }

        public Jester(IJokeService jokeService /*IOutputJoke outputJoke*/)
        {
            IJokeService = jokeService ?? throw new ArgumentNullException((nameof(IJokeService)));
            //IOutputJoke = outputJoke ?? throw new ArgumentNullException((nameof(IOutputJoke)));
        }
        public string GetJoke()
        {
            throw new NotImplementedException();
        }

        public void OutputJoke(string joke)
        {
            Console.WriteLine(joke);
        }

        public void TellJoke()
        {
            string joke;
            do
            {
                joke = IJokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));
            
            OutputJoke(joke);
        }
    }
}