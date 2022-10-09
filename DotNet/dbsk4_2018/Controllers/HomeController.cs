using Microsoft.AspNetCore.Mvc;
using dbsk4_2018.Models;
using Microsoft.Extensions.Configuration;

namespace dbsk4_2018.Controllers
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