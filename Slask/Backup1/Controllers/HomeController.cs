using System.Web.Mvc;

namespace dbsk1.Controllers
{
    public class HomeController : Controller
    {

        //
        // GET: /Home/

        public string Index()
        {
            string text = "Hello World";
            int number = 1;
  
            return "<h2>" + text + "</h2>" + "A number:" + number;
        }

    }
}



