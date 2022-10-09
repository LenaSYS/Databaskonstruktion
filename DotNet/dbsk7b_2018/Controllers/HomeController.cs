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
            ViewBag.CustomerTable = _customersModel.GetAllCustomers();
            return View();
        }

        public IActionResult InsertCustomer(string custno, string ssn,string name)
        {
            _customersModel.InsertCustomer(custno,ssn,name);
            return RedirectToAction("Index");
        }

    }
}
