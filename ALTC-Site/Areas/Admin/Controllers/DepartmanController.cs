using ALTC_Site.Services;
using ALTC_Site.ViewModels;
using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmanController : Controller
    {
        private readonly IDepartment department;
        private readonly IWebHostEnvironment hostEnvironment;


        public DepartmanController(IDepartment department, IWebHostEnvironment _webHostEnvironment)
        {
            this.department = department;
            hostEnvironment = _webHostEnvironment;

        }
        public IActionResult GetAll()
        {
            var model = department.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeptVM requestVM)
        {

            Department request = new Department()
            {
                Name = requestVM.Name,
                Describtion = requestVM.Describtion,
                lang=requestVM.lang

            };
            if (requestVM.File != null)
            {

                string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string fileName = ALTC_Website.Abstract.File.Upload(uploadPath, requestVM.File);

                request.FileName = fileName;
            }
            department.Create(request);

            return RedirectToAction("index");


        }
                [HttpGet]
        public IActionResult Edit(string id)
        {
            // Retrieve the StaticData object by id
            var staticData = department.GetById(id);

            // Check if the object is found
            if (staticData == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Pass the StaticData object to the view for editing
            return View(staticData);
        }
        [HttpPost]
        public IActionResult Edit(string id, Department request)
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
            department.Update(request);

            return RedirectToAction("GetAll");
        }

    }
}
