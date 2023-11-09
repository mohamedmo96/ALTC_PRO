using ALTC_Site.Services;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Site.Controllers
{
    public class DepartmantController : Controller
    {
        private readonly IDepartment requestService;

        public DepartmantController(IDepartment _requestService)
        {
            requestService = _requestService;
        }
        public IActionResult GetAll()
        {
            var model = requestService.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department requst)
        {
            if (!ModelState.IsValid)
            {
                return View(requst);
            }
            requestService.Create(requst);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            requestService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
  
   
}
