using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MAXCINA.Areas.Admin.Controllers
{
    [Area(SD.Area_Admin)]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var movies = _context.Movies;//.OrderBy(m=>m.MovieStatus);
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
        public IActionResult Create(Movies movie, IFormFile ImgUrl)
        {
            if (ImgUrl is null)
            {
                return BadRequest();
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\customer\\movies", fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                ImgUrl.CopyTo(stream);
            }
            movie.ImgUrl = fileName;
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
        public IActionResult Edit(Movies movie, IFormFile? ImgUrl)
        {
            var MovieInDb = _context.Movies.AsNoTracking().FirstOrDefault(e=>e.MoviesId==movie.MoviesId);

            if (MovieInDb is null)
                return NotFound();

            if (ImgUrl is not null)
            {
                // Save img in wwwroot
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                // djsl-kds232-91321d-sadas-dasd213213.png
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\customer\\movies", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    ImgUrl.CopyTo(stream);
                }

                // Remove old Img from wwwroot
                var oldFileName = MovieInDb.ImgUrl;
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\customer\\movies", oldFileName);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                // Save img in DB
                movie.ImgUrl = fileName;
            }
            else
            {
                movie.ImgUrl = MovieInDb.ImgUrl;
            }
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
