using MvcDadJokes.Data;
using MvcDadJokes.Models;

namespace MvcDadJokes.Services
{
    public class JokeRepoDeluxe : IJokeRepo
    {
        private readonly AppDbContext context;

        public JokeRepoDeluxe(AppDbContext context)
        {
            this.context = context;
        }
        public void AddJoke(JokesModel joke)
        {
            joke.Joke += "!!!";

            context.Jokes.Add(joke);
            context.SaveChanges();

        }

        public List<JokesModel> GetJokes()
        {
            return context.Jokes.ToList();
        }
    }
}
