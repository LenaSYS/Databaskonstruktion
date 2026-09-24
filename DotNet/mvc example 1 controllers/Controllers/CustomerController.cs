using mvc_multiple_controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace mvc_multiple_controllers.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.SomeText = "Some other text passed from the controller using the ViewBag";
            return View();
        }
    }
}
