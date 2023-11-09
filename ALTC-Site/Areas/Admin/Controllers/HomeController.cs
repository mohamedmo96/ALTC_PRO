using ALTC_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ALTC_WebSite.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class HomeController : Controller
    {

 
        public IActionResult Index()
        {
            return View();
        }
       


    }
}
