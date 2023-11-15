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
        [HttpGet]
        public IActionResult Edit(string id)
        {
            // Retrieve the StaticData object by id
            var staticData = staticDataa.GetById(id);

            // Check if the object is found
            if (staticData == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Pass the StaticData object to the view for editing
            return View(staticData);
        }
        [HttpPost]
        public IActionResult Edit(string id, StaticData request)
        {
            // Check if the provided id is different from the model id
            if (id != request.id)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            if (!ModelState.IsValid)
            {
                return View(request); // Return the view with validation errors
            }

            // Update the StaticData object
            staticDataa.Update(request);

            return RedirectToAction("GetAll");
        }
    }
}
