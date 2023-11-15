﻿using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index(string dir, string lang)
        {
            // Store in ViewData to pass to View
            ViewData["Dir"] = dir;
            ViewData["Lang"] = lang;

            // Check lang to select corresponding data
            if (lang == "en")
            {
                // Select en data
            }
            else
            {
                // select ar data
            }

            return View();
        }
    }
}
