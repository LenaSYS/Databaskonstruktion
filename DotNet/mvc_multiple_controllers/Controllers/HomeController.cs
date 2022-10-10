using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc_multiple_controllers.Models;

namespace mvc_multiple_controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private CustomerModel _customersModel;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _customersModel = new CustomerModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.SomeText = "Some text passed from the controller using the ViewBag";
            return View();
        }
    }
}
