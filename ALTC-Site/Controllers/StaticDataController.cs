using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class StaticDataController : Controller
    {
        private readonly IStaticData staticDataa;


        public StaticDataController(IStaticData staticData)
        {
            staticDataa = staticData;
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var model = staticDataa.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(StaticData staticData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.msg = "No";
                return View(staticData);
            }

            staticDataa.Create(staticData);
            return View(staticData);


        }
    }
}
