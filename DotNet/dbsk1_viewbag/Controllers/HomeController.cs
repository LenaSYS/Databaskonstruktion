using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dbsk1_viewbag.Models;

namespace dbsk1_viewbag.Controllers
{
    public class HomeController : Controller
    {
        private string greger = "Snus";

        public IActionResult Index()
        {
            string text = "Hello World";
            int number = 2;
            ViewBag.HelloText = text;
            ViewBag.ANumber = number;
            return View();
        }
        public IActionResult ShowCustomers()
        {
            return View();
        }
    }
}
