using ALTC_Website.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
     public class JobController : Controller
    {
        private readonly IJobcandidateService jobcandidateService;

        public JobController(IJobcandidateService jobcandidateService)
        {
            this.jobcandidateService = jobcandidateService;
        }

        public IActionResult Index()
        {
            var model = jobcandidateService.GetAll();
            return View(model);
        }
        public IActionResult test()
        {
            
            return View();
        }
        public IActionResult GetAll()
        {
            var model = jobcandidateService.GetAll();
            return View(model);
        }
    }
}
