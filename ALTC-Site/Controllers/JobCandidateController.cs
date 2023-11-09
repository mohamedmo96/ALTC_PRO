using ALTC_Website.Services;
using ALTC_Website.ViewModels;
using ALTC_WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Hosting;
using Amazon.Runtime.Internal;

namespace ALTC_Website.Controllers
{
    public class JobCandidateController : Controller
    {
        private readonly IJobcandidateService jobcandidateService;
        private readonly IWebHostEnvironment hostEnvironment;

        public JobCandidateController(IJobcandidateService jobcandidateService, IWebHostEnvironment _webHostEnvironment)
        {
            hostEnvironment = _webHostEnvironment;
            this.jobcandidateService = jobcandidateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var model = jobcandidateService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobRequsetVM requestVM)
        {
          
            JobCandidate request = new JobCandidate()
            {
                Name = requestVM.Name,
                Email = requestVM.Email,
                Phone = requestVM.Phone,
                Message = requestVM.Message,
                JobTitile=requestVM.JobTitile,
                
            };
            if (requestVM.File != null)
            {

                string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
                string fileName = Abstract.File.Upload(uploadPath, requestVM.File);
              
                request.FileName = fileName;
            }
            jobcandidateService.Create(request);

            return RedirectToAction("index");


        }
    }
}
