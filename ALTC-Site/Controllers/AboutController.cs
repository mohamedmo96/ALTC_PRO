using ALTC_Site.Services;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Site.Controllers
{
    public class AboutController : Controller
    {
        private readonly IStaticData department;

        public AboutController(IStaticData department)
        {
            this.department = department;
        }
        public IActionResult Index(string dir, string lang)
        {
            // Store in ViewData to pass to View
            ViewData["Dir"] = dir;
            ViewData["Lang"] = lang;

            // Get data based on the selected language
            var model = department.GetBylang(lang);

            return View(model);
        }
    }
}
