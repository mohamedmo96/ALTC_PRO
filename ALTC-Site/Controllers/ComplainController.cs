using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class ComplainController : Controller
    {
        private readonly IComplainService _complainService;

        public ComplainController(IComplainService complainService)
        {
            _complainService = complainService;
        }

        // Display the create complaint form
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complain obj)
        {
            if (ModelState.IsValid)
            {
                _complainService.Add(obj);
                //return RedirectToAction("Index"); // Redirect to the list of complaints after creating one
            }

            return View(obj);
        }

        // GET: List all complaints
        public IActionResult Index()
        {
            var complaints = _complainService.GetAllComplaints();
            return View(complaints);
        }

        // GET: View details of a specific complaint
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var complaint = _complainService.GetComplaintById(id);

            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }
    }

}
