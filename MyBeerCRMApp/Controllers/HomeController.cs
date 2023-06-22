using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBeerCRMApp.Areas.Identity.Data;
using MyBeerCRMApp.Models;
using System.Diagnostics;

namespace MyBeerCRMApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<MyBeerCRMAppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<MyBeerCRMAppUser> userManager) //Чуть-чуть отредактировали передаваемые параметры, чтобы посмотреть юзер айди  
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}