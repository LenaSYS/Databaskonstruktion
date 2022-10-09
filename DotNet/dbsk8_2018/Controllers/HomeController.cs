using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk8_2018.Models;
using Microsoft.Extensions.Configuration;

namespace dbsk8_2018.Controllers
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
