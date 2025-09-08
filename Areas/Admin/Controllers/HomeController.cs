using Microsoft.AspNetCore.Mvc;

namespace MAXCINA.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area(SD.Area_Admin)]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotfoundPage()
        {
            return View();
        }
    }
}
