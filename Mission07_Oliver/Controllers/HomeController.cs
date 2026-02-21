using Microsoft.AspNetCore.Mvc;
using Mission07_Oliver.Models;
using System.Diagnostics;

namespace Mission07_Oliver.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("Movie", new Movie());
        }

        [HttpPost]
        public IActionResult Movie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(movie);
            }
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .OrderBy(s => s.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(s => s.MovieId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("Movie", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(s => s.MovieId == id);
            return View(movieToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
