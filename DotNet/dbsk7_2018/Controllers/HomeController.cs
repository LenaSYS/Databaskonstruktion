using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dbsk7_2018.Models;
using Microsoft.Extensions.Configuration;

namespace dbsk7_2018.Controllers
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
