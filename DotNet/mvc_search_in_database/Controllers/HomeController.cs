using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc_search_in_database.Models;

namespace mvc_search_in_database.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private CustomersModel _customersModel;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _customersModel = new CustomersModel(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchCustomers(string name)
        {
            ViewBag.SearchResults = _customersModel.SearchCustomers(name);
            return View();
        }
    }
}
