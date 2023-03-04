using MvcDadJokes.Data;
using MvcDadJokes.Models;

namespace MvcDadJokes.Services
{
    public class JokeRepo : IJokeRepo
    {
        private readonly AppDbContext context;

        public JokeRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void AddJoke(JokesModel joke)
        {
            context.Jokes.Add(joke);
            context.SaveChanges();
        }

        public List<JokesModel> GetJokes()
        {
            return context.Jokes.ToList();
        }
    }
}
