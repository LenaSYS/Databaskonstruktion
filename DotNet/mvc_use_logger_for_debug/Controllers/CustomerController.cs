using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mvc_use_logger_for_debug.Models;

namespace mvc_use_logger_for_debug.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public CustomerController(ILogger<CustomerController> logger, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
            _configuration = configuration;

            _logger.LogInformation("====> CustomerController Started at {dateTime}", DateTime.UtcNow);
        }
        public IActionResult Index()
        {
            _logger.LogInformation("====> CustomerController:Index accessed {dateTime}", DateTime.UtcNow);

            return View(new CustomerModel(_loggerFactory.CreateLogger<CustomerModel>(), _configuration).GetAllCustomers());
        }
    }
}
