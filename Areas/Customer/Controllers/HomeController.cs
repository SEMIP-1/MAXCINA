using MAXCINA.Models;
using MAXCINA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MAXCINA.Areas.Customer.Controllers
{
    [Area(SD.Area_Customer)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotfoundPage()
        {
            return View();
        }
        public IActionResult Movies()
        {
            var movies = _context.Movies.Include(m => m.Category);
            return View(movies.ToList());
        }
        public IActionResult MovieDetails(int id)
        {
            var _movies = _context.Movies.Include(m => m.Category).Include(m => m.Cinema).FirstOrDefault(m=>m.MoviesId==id);
            if (_movies is null)
            {
                return RedirectToAction(nameof(NotfoundPage));
            }
            var _similarMovies = _context.Movies.Include(m => m.Category).Where(m => m.CategoryId == _movies.CategoryId && m.MoviesId != id).Skip(0).Take(4);

            return View(new MovieDetailsVM() 
            {
                Movie = _movies,
                SimilarMovies = _similarMovies.ToList()
            });
        }
        public IActionResult Cinema()
        {
            var _Cinmas= _context.Cinemas.Include(c=>c.Movies);
            return View(_Cinmas.ToList());
        }
        public IActionResult CinemaDetails(int id)
        {
            var _Cinmas = _context.Cinemas.Include(c => c.Movies).FirstOrDefault(m => m.Id == id);
            if (_Cinmas is null)
            {
                return RedirectToAction(nameof(NotfoundPage));
            }
            var _similarMovies = _context.Movies.Include(m => m.Category).Where(m => m.CinemaId == _Cinmas.Id);

            return View(new CinemaDetailsVM() 
            {
                cinema = _Cinmas,
                AvillableMovies = _similarMovies.ToList()
            });
        }
    }
}
