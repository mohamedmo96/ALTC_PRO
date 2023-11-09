using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaticDataController : Controller
    {
        private readonly IStaticData staticDataa;


        public StaticDataController(IStaticData staticData)
        {
            staticDataa = staticData;
        }
        public IActionResult GetAll()
        {
            var model = staticDataa.GetAll();
            return View(model);
        }
        public IActionResult Delete(string id)
        {
             staticDataa.Delete(id);
           return RedirectToAction("GetAll");  
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StaticData requst)
        {
            if (!ModelState.IsValid)
            {
                return View(requst);
            }

            staticDataa.Create(requst);

            return RedirectToAction("GetAll");
        }
    }
}
