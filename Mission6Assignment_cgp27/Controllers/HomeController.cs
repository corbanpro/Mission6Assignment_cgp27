using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6Assignment_cgp27.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment_cgp27.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext movie { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext x)
        {
            _logger = logger;
            movie = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie model)
        {
            movie.Add(model);
            movie.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
