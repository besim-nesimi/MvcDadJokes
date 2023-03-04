using MvcDadJokes.Models;

namespace MvcDadJokes.Services
{
    public interface IJokeRepo
    {
        void AddJoke(JokesModel joke);

        List<JokesModel> GetJokes();
    }
}
