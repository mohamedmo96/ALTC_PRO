﻿using ALTC_Website.Services;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ALTC_Website.Controllers
{
    
    public class RequestController : Controller

    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IRequestService requestService;
        public RequestController(IRequestService _requestService,IWebHostEnvironment _webHostEnvironment)
        {
            hostEnvironment = _webHostEnvironment;
            requestService = _requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(string dir, string lang)
        {
            ViewData["lang"] = lang;
            ViewData["dir"] = dir;

            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(RequestVM requestVM, string lang , string dir) 
        {
            //ViewData["lang"]=lang;
         //var  lang = ViewBag.lang;
           //ViewData["dir"]=dir;
           //var dir=ViewBag.dir;
            if(!ModelState.IsValid)
            {
               // return RedirectToAction("Index", "contact");

                 return PartialView(requestVM);
            }
            Request request = new Request() 
            {
                Name = requestVM.Name,
                Details = requestVM.Details,
                Email = requestVM.Email,
                Phone = requestVM.Phone,
            };
            if(requestVM.File != null)
            {
               string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
               string fileName= Abstract.File.Upload(uploadPath, requestVM.File);

               request.FileName= fileName;
            }
            
            requestService.Create(request);
            return RedirectToAction("Index", "contact", new {dir=dir,lang=lang});
            //return RedirectToAction("Index", "contact", new {dir=dir,lang=lang});
           
        }

        public IActionResult ValidFileExtension(IFormFile file)
        {
            string[] extensions = { "png", "jpg" };
            string extension = Path.GetExtension(file.FileName);
            if (extensions.Contains(extension.ToLower()))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
