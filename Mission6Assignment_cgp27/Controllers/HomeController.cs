using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext movieContext { get; set; }

        public HomeController(MovieContext x)
        {
            movieContext = x;
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

            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie model)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                movieContext.Add(model);
                movieContext.SaveChanges();

                return View("ConfirmationPage");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult MovieCollection()
        {
            var movies = movieContext.Movies
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int MovieId)
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            var movie = movieContext.Movies.Single(x => x.MovieId == MovieId);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(movie);
                movieContext.SaveChanges();

                return RedirectToAction("MovieCollection");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View("AddMovie", movie);
            }

        }
        [HttpGet]
        public IActionResult DeleteMovie(int MovieId)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == MovieId);
            return View(movie);
        }
        
        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            movieContext.Movies.Remove(movie);
            movieContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
    }
}
