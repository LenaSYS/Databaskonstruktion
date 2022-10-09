
using dbsk3_2018.Models;
using Microsoft.AspNetCore.Mvc;

namespace dbsk3_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MyModel anInstanceOfMyModel = new MyModel("Hello World", 3);
            ViewBag.HelloText = anInstanceOfMyModel.Text;
            ViewBag.ANumber = anInstanceOfMyModel.Number;
            ViewBag.FunnyString = anInstanceOfMyModel.TextMultipliedWithNumber();
            return View();
        }
    }
}
