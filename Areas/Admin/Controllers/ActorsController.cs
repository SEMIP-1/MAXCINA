using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAXCINA.Areas.Admin.Controllers
{
    [Area(SD.Area_Admin)]
    public class ActorsController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var actors = _context.Actors.OrderBy(m => m.ActorsId);
            return View(actors.ToList());
        }
        //---------------------------------------------------------------
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actors actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        //---------------------------------------------------------------
        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var actors = _context.Actors.FirstOrDefault(m => m.ActorsId == id);
            if (actors is null)
            {
                return NotFound();
                //RedirectToAction(SD.NotFoundPage,controllerName: SD.HomeController);
            }
            return View(actors);
        }
        [HttpPost]
        public IActionResult Edit(Actors actors)
        {
            _context.Actors.Update(actors);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        //---------------------------------------------------------------
        #region Delete
        public IActionResult Delete(int id)
        {
            var actors = _context.Actors.FirstOrDefault(m => m.ActorsId == id);
            if (actors is null)
            {
                return NotFound();
                //RedirectToAction(SD.NotFoundPage,controllerName: SD.HomeController);
            }
            _context.Actors.Remove(actors);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
