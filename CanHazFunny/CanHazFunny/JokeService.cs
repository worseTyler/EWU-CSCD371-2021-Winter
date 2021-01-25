namespace CanHazFunny
{
    using System.Net.Http;

    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new ();

        public string GetJoke()
        {
            string joke = this.HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
    }
}
