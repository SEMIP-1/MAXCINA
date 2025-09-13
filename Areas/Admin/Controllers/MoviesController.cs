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
        //---------------------------------------------------------------
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories;
            var cinemas = _context.Cinemas;
            return View(new MoviesCreateVM()
            {
                Category = categories.ToList(),
                Cinema = cinemas.ToList()
            });
        }
        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        //---------------------------------------------------------------
        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movies = _context.Movies.FirstOrDefault(m=>m.MoviesId==id);
            if (movies is null)
            {
                return NotFound();
                //RedirectToAction(SD.NotFoundPage,controllerName: SD.HomeController);
            }
            var categories = _context.Categories;
            var cinemas = _context.Cinemas;
            return View(new MoviesEditVM() 
            {
                Movie = movies,
                Category = categories.ToList(),
                Cinema = cinemas.ToList()
            });
        }
        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        //---------------------------------------------------------------
        #region Delete
        public IActionResult Delete(int id)
        {
            var movies = _context.Movies.FirstOrDefault(m => m.MoviesId == id);
            if (movies is null)
            {
                return NotFound();
                //RedirectToAction(SD.NotFoundPage,controllerName: SD.HomeController);
            }
            _context.Movies.Remove(movies);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
