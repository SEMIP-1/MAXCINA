using Microsoft.AspNetCore.Mvc;

namespace MAXCINA.Areas.Admin.Controllers
{
    [Area(SD.Area_Admin)]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var movies=_context.Movies.OrderBy(m=>m.MovieStatus);
            return View(movies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
