using Microsoft.AspNetCore.Mvc;

namespace MAXCINA.Areas.Admin.Controllers
{
    [Area(SD.Area_Admin)]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var movies=_context.Movies;
            return View(movies.ToList());
        }
    }
}
