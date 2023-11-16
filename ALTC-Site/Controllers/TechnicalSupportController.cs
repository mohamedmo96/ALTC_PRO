using ALTC_Website.Services;
using ALTC_WebSite.Models;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ALTC_Website.Controllers
{
    public class TechnicalSupportController : Controller
    {
        private readonly ITechnicalSupportService requestService;

        public TechnicalSupportController(ITechnicalSupportService _requestService)
        {
            requestService = _requestService;
        }

        public IActionResult Index(string dir, string lang)
        {
            ViewData["Dir"] = dir;
            ViewData["Lang"] = lang;
            return View();
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
        public IActionResult Create(TechnicalSupport requst, string dir, string lang)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Contact", "Index", requst);
            }
            requestService.Create(requst);

            return RedirectToAction( "Index" , "TechnicalSupport", new {  dir=dir,  lang=lang });
        }
    }
}

