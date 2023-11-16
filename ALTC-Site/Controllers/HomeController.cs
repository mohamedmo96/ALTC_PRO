using ALTC_Site.Services;
using ALTC_Website.Models;
using ALTC_Website.Services;
using ALTC_WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ALTC_WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartment department;
        private readonly IServiceService serviceService;

        public HomeController(IDepartment department, IServiceService serviceService)
        {
            this.department = department;
            this.serviceService = serviceService;
        }

        public IActionResult Index(string dir, string lang)
        {
            // Store in ViewData to pass to View
            ViewData["Dir"] = dir;
            ViewData["Lang"] = lang;

            // Get data based on the selected language
            var model = department.GetBylang(lang);
            ViewBag.data = serviceService.GetBylang(lang);

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
