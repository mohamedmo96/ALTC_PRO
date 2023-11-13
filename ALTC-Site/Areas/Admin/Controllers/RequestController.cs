using ALTC_Website.Services;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;
using System.ComponentModel.DataAnnotations;

namespace ALTC_Website.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IRequestService requestService;
        public RequestController(IRequestService _requestService, IWebHostEnvironment _hostEnvironment)
        {
            requestService = _requestService;
            hostEnvironment = _hostEnvironment;
        }

        public IActionResult Index()
        {
            var requests = requestService.GetAll();
            return View(requests);
        }
		public IActionResult GetDetails(string id)
		{
			if (id == null)
			{
				return View(nameof(Index));
			}
			Request request = requestService.GetById(id);
			return View(request);
		}
		public IActionResult Download(string fileName)
        {
            string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
            string filePath = Path.Combine(uploadPath, fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);

        }
    }
}