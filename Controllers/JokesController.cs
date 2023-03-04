using Microsoft.AspNetCore.Mvc;
using MvcDadJokes.Api;
using MvcDadJokes.Data;
using MvcDadJokes.Models;
using MvcDadJokes.Services;

namespace MvcDadJokes.Controllers
{
    public class JokesController : Controller
    {
        private readonly IJokeRepo jokeRepo;

        public JokesController(IJokeRepo jokeRepo)
        {
            this.jokeRepo = jokeRepo;
        }
        public async Task<IActionResult> Index()
        {
            // Hämta ett dad-joke
            JokesModel joke = await new ApiCaller().JokesCall();

            // Spara dad-joket i en databas
            jokeRepo.AddJoke(joke);

            // Skicka anv till view
            return View(joke);
        }

        //public async Task<IActionResult>AllJokes()
        //{
        //    ApiModel jokes = await new ApiCaller().ManyJokes();
        //    return View(jokes);
        //}

        public async Task<IActionResult>AllJokes()
        {
            // Hämta alla skämt från dad-jokes från databasen
            List<JokesModel> jokes = jokeRepo.GetJokes();
            
            // Visa alla jokes
            return View(jokes);
        }
    }
}
