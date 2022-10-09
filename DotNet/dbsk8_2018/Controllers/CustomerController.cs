using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbsk8_2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dbsk8_2018.Controllers
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
            return View(new dbsk8_2018.Models.CustomerModel(_configuration).GetAllCustomers());
        }
    }
}
