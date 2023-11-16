using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_WebSite.Models;
using ALTC_WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IServiceService department;
        private readonly IWebHostEnvironment hostEnvironment;


        public ServicesController(IServiceService department, IWebHostEnvironment _webHostEnvironment)
        {
            this.department = department;
            hostEnvironment = _webHostEnvironment;

        }
        public IActionResult GetAll()
        {
            var model = department.GetAllServices();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServVM requestVM)
        {

            Service request = new Service()
            {
                Name = requestVM.Name,
                Details = requestVM.Details,
                lang = requestVM.lang

            };
            if (requestVM.File != null)
            {

                string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string fileName = ALTC_Website.Abstract.File.Upload(uploadPath, requestVM.File);

                request.FileName = fileName;
            }
            department.Add(request);

            return RedirectToAction("index");


        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            // Retrieve the StaticData object by id
            var staticData = department.GetServiceById(id);

            // Check if the object is found
            if (staticData == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Pass the StaticData object to the view for editing
            return View(staticData);
        }
        [HttpPost]
        public IActionResult Edit(string id, Service request)
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
            department.UpdateService(id ,request);

            return RedirectToAction("GetAll");
        }

    }
}
