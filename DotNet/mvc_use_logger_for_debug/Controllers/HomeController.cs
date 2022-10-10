using Microsoft.AspNetCore.Mvc;

namespace mvc_use_logger_for_debug.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SomeText = "Some text passed from the controller using the ViewBag Object";
            return View();
        }
    }
}
