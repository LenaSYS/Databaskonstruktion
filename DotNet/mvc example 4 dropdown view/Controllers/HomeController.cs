using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc_code_generated_listbox.Models;

namespace mvc_code_generated_listbox.Controllers
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
