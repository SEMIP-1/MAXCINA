using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAXCINA.Areas.Admin.Controllers
{
    [Area(SD.Area_Admin)]
    public class CinemaController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var cinema = _context.Cinemas.OrderBy(m => m.Id);
            return View(cinema.ToList());
        }
        //----------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
