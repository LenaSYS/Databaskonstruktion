using Microsoft.AspNetCore.Mvc;
using mvc_secure_sessions.Models;
using System.Diagnostics;

namespace mvc_secure_sessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            ViewBag.SessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

            _logger.LogInformation("Username:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeyUsername));
            _logger.LogInformation("SessionId:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeySessionId));

            return View();
        }

        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, username);
            HttpContext.Session.SetString(SessionVariables.SessionKeySessionId, Guid.NewGuid().ToString());

            _logger.LogInformation("Username:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeyUsername));
            _logger.LogInformation("SessionId:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeySessionId));

            return RedirectToAction("MyPage");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            _logger.LogInformation("Username:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeyUsername));
            _logger.LogInformation("SessionId:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeySessionId));

            return RedirectToAction("Index");
        }

        public IActionResult MyPage()
        {
            ViewBag.Username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            ViewBag.SessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

            _logger.LogInformation("Username:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeyUsername));
            _logger.LogInformation("SessionId:{session}", HttpContext.Session.GetString(SessionVariables.SessionKeySessionId));

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}