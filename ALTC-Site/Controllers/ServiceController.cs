using ALTC_Website.Services;
using ALTC_WebSite.Models;
using ALTC_WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // Display the create Servicet form
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service obj)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Add(obj);
                //return RedirectToAction("Index"); // Redirect to the list of Servicets after creating one
            }

            return View(obj);
        }

        public IActionResult Index()
        {
            var services = _serviceService.GetAllServices();
            return View(services);
        }

        //// POST: Edit a service
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(string id, Service updatedService)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _serviceService.UpdateService(id, updatedService);
        //        return RedirectToAction("Index"); // Redirect to the list of services after editing one
        //    }

        //    return View(updatedService);
        //}

        // GET: Edit a service
        [HttpGet]
        public IActionResult Edit(string id)
        {
            // Retrieve the service to edit by its ID and return the edit view
            var serviceToEdit = _serviceService.GetServiceById(id);
            if (serviceToEdit == null)
            {
                // Handle the case where the service with the specified ID is not found
                return NotFound();
            }

            return View(serviceToEdit);
        }

        // POST: Edit a service
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Service updatedService)
        {
            if (ModelState.IsValid)
            {
                _serviceService.UpdateService(id, updatedService); // Pass the id and updatedService
                return RedirectToAction("Index"); // Redirect to the list of services after editing one
            }

            return View(updatedService);
        }



        // GET: Delete a service
        [HttpGet]
        public IActionResult Delete(string id)
        {
            _serviceService.DeleteService(id);
            return RedirectToAction("Index"); // Redirect to the list of services after deleting one
        }


    }

}
                                                                                                                                                                                                                                                                                                                                                               