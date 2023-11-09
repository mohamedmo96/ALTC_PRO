using ALTC_Website.Services;
using ALTC_Website.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;
using System.ComponentModel.DataAnnotations;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            // List<RequestVM> requestsVM = requests.Select(r => new RequestVM{Name=r.Name,Email=r.Email,Phone=r.Phone,Details=r.Details,File=null}).ToList();

            return View(requests);
        }
        public IActionResult Download(string name)
        {
            string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
            string filePath = Path.Combine(uploadPath, "5a028364-59d9-499b-a3d2-a8731a46213a_Mohamed_Ali Nagy_Resume_13-08-2023-00-11-22.pdf");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            //var fileName = Path.GetFileName(filepath);
            return File(fileBytes, "application/octet-stream", "5a028364-59d9-499b-a3d2-a8731a46213a_Mohamed_Ali Nagy_Resume_13-08-2023-00-11-22.pdf");

            //return RedirectToAction(nameof(Index));

        }
    }
}