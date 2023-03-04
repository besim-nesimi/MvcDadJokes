using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MvcDadJokes.Models;

namespace MvcDadJokes.Api
{
    public class ApiCaller
    {
        public async Task<JokesModel> JokesCall()
        {
            JokesModel? result = await ApiInitializer.httpClient.GetFromJsonAsync<JokesModel>("https://icanhazdadjoke.com/");

            return result;
        }

        public async Task<ApiModel> ManyJokes()
        {
            ApiModel? jokes = await ApiInitializer.httpClient.GetFromJsonAsync<ApiModel>("https://icanhazdadjoke.com/search");

            return jokes;
        }
    }
}
