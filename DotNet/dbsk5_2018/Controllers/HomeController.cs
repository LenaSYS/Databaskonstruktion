using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk5_2018.Models;
using Microsoft.Extensions.Configuration;

namespace dbsk5_2018.Controllers
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
            ViewBag.AllCustomersTable = _customersModel.GetAllCustomers();
            return View();
        }

        public IActionResult DeleteCustomer(string custno)
        {
            _customersModel.DeleteCustomer(custno);
            return RedirectToAction("Index");
        }

    }
}
