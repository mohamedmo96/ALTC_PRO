using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class LoginController : Controller
    {
        private readonly IComplainService _LoginService;

        public LoginController(IComplainService loginService)
        {
            _LoginService = loginService;
        }

        // Display the create complaint form
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Login obj)
        {
            if (ModelState.IsValid)
            {
                _LoginService.Add(obj);
                //return RedirectToAction("Index"); // Redirect to the list of complaints after creating one
            }

            return View(obj);
        }

        //// GET: List all complaints
        //public IActionResult Index()
        //{
        //    var complaints = _LoginService.GetAllComplaints();
        //    return View(complaints);
        //}

        //// GET: View details of a specific complaint
        //public IActionResult Details(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest();
        //    }

        //    var complaint = _LoginService.GetComplaintById(id);

        //    if (complaint == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(complaint);
        //}
    }

}
