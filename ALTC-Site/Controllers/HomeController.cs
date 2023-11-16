using ALTC_Site.Services;
using ALTC_Website.Models;
using ALTC_Website.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ALTC_WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartment department;

        public HomeController(IDepartment department)
        {
            this.department = department;
        }

        public IActionResult Index()
        {
            string lang = "en"; // قم بتحديد اللغة المطلوبة

            var model = department.GetBylang(lang);
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
