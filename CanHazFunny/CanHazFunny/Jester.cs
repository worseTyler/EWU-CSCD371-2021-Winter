namespace CanHazFunny
{
    using System;

    public class Jester
    {
        public Jester(IJokeService jokeService, IOutputJoke outputJoke)
        {
            this.IJokeService = jokeService ?? throw new ArgumentNullException(nameof(this.IJokeService));
            this.IOutputJoke = outputJoke ?? throw new ArgumentNullException(nameof(this.IOutputJoke));
        }

        private IJokeService IJokeService { get; }

        private IOutputJoke IOutputJoke { get; }

        public void TellJoke()
        {
            string joke;
            do
            {
                joke = this.IJokeService.GetJoke();
            }
            while (joke.Contains("Chuck") || joke.Contains("Norris"));

            this.IOutputJoke.OutputJoke(joke);
        }
    }
}