using ALTC_Website.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ComplainController : Controller
    {
        private readonly IComplainService _complainService;

        public ComplainController(IComplainService complainService)
        {
            _complainService = complainService;
        }
        public IActionResult Index()
        {
            var model = _complainService.GetAllComplaints();
            return View(model);
        }
    }
}
