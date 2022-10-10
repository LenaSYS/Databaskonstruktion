using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc_connect_model_to_mysql.Models;

namespace mvc_connect_model_to_mysql.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            CustomersModel customersModel = new CustomersModel(_configuration);
            ViewBag.CustomerTable = customersModel.GetAllCustomers();
            return View();
        }
    }
}