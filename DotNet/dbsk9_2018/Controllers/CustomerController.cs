using System;
using System.Diagnostics;
using dbsk9_2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbsk9_2018.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        private CustomerModel _customersModel;

        public CustomerController(ILogger<CustomerController> logger, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
            _configuration = configuration;

            _logger.LogInformation("====> Application Started at {dateTime}", DateTime.UtcNow);
        }
        public IActionResult Index()
        {
            _logger.LogInformation("====> Index accessed {dateTime}", DateTime.UtcNow);

            ILogger<CustomerModel> customersModelLogger = _loggerFactory.CreateLogger<CustomerModel>();

            return View(new dbsk9_2018.Models.CustomerModel(customersModelLogger,_configuration).GetAllCustomers());
        }
    }
}
