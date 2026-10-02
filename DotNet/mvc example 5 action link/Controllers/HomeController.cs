using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mvc_code_generated_action_links.Models;

namespace mvc_code_generated_action_links.Controllers
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
