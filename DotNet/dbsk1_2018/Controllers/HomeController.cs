using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dbsk1_2018.Models;

namespace dbsk1_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string text = "Hello World";
            int number = 2;
            ViewBag.HelloText = text;
            ViewBag.ANumber = number;
            return View();
        }
    }
}
