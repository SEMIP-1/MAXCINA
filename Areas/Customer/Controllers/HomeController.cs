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
        //---------------------------------------------------------------
        #region Movies
        public IActionResult Movies(FilterVM filterVM, int page = 2)
        {
            var movies = _context.Movies.Include(m => m.Category).Include(m=>m.Cinema).AsQueryable();
            if (!string.IsNullOrEmpty(filterVM.Name))
            {
                movies = movies.Where(m => m.Name.Contains(filterVM.Name));
                ViewBag.Name = filterVM.Name;
            }
            if (filterVM.MinPrice.HasValue)
            {
                movies = movies.Where(m => m.Price >= filterVM.MinPrice.Value);
                ViewBag.MinPrice = filterVM.MinPrice;
            }
            if (filterVM.MaxPrice.HasValue)
            {
                movies = movies.Where(m => m.Price <= filterVM.MaxPrice.Value);
                ViewBag.MaxPrice = filterVM.MaxPrice;
            }
            if (filterVM.categoryId.HasValue && filterVM.categoryId.Value != 0)
            {
                movies = movies.Where(m => m.CategoryId == filterVM.categoryId);
                ViewBag.CategoryId = filterVM.categoryId;
            }
            if (filterVM.cinemaId.HasValue && filterVM.cinemaId.Value != 0)
            {
                movies = movies.Where(m => m.CinemaId == filterVM.cinemaId);
                ViewBag.CinemaId = filterVM.cinemaId;
            }
            if (filterVM.isTranding)
            {
                movies = movies.OrderBy(m=>m.Traffic);
                ViewBag.isTranding = filterVM.isTranding;
            }
            var categories = _context.Categories;
            var cinemas = _context.Cinemas;
            var TotalNumberOfPages =Math.Ceiling( movies.Count()/8.0);
            var CurrentPage = page; 
            ViewBag.TotalNumberOfPages = TotalNumberOfPages;
            ViewBag.CurrentPage = CurrentPage;

            movies = movies.Skip((page - 1) * 8).Take(8);

            return View(new MoviesFilterVM 
            { 
                movies = movies.ToList(),
                categories = categories.ToList(),
                cinemas = cinemas.ToList()
            } );
        }
        //---------------------------------------------------------------
        public IActionResult MovieDetails(int id)
        {
            var _movies = _context.Movies.Include(m => m.Category).Include(m => m.Cinema).FirstOrDefault(m => m.MoviesId == id);
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
        #endregion
        //---------------------------------------------------------------
        #region Cinema
        public IActionResult Cinema()
        {
            var _Cinmas = _context.Cinemas.Include(c => c.Movies);
            return View(_Cinmas.ToList());
        }
        //---------------------------------------------------------------
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
        #endregion
        //---------------------------------------------------------------
        #region Actors
        public IActionResult Actors()
        {
            var actors = _context.Actors;
            return View(actors.ToList());
        }
        //---------------------------------------------------------------
        public IActionResult ActorDetails(int id)
        {
            var _actor = _context.Actors.Include(c => c.Movies).FirstOrDefault(m=>m.ActorsId==id);
            if (_actor is null)
            {
                return RedirectToAction(nameof(NotfoundPage));
            }
            var _movies = _context.Movies.Include(m => m.Category);
            var _actorsMovies = _context.ActorMovies.Where(m => m.ActorsId == id);
            return View(new ActorMoviesVM()
            {
                actors = _actor ,
                movies = _movies.ToList(),
                actorMovies = _actorsMovies.ToList()
            });
        }
        #endregion
    }
}
