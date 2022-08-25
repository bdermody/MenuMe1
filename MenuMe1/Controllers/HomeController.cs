using MenuMe1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MenuMe1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
           
            return View();
            //"Areas/Identity/Pages/Account/Login.cshtml"
        }

        public IActionResult ForgotPassword()
        {

            return View("Areas/Identity/Pages/Account/ForgotPassword.cshtml");
           
        }

        public IActionResult Register()
        {

            return View("Areas/Identity/Pages/Account/Register.cshtml");
            
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}