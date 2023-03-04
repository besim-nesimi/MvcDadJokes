using Microsoft.AspNetCore.Mvc;
using MvcDadJokes.Api;
using MvcDadJokes.Models;
using System.Diagnostics;

namespace MvcDadJokes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}