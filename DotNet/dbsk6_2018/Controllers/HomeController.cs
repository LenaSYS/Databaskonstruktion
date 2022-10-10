using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk6_2018.Models;
using Microsoft.Extensions.Configuration;

namespace dbsk6_2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private InvoiceModel _invoiceModel;
        private CustomerModel _customerModel;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _customerModel = new CustomerModel(_configuration);
            _invoiceModel = new InvoiceModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.AllCustomersTable = _customerModel.GetAllCustomers();
            return View();
        }

        public IActionResult SearchInvoiceRows(string custno)
        {
            ViewBag.SearchResults = _invoiceModel.SearchInvoiceRows(custno);
            return View();
        }
    }
}
