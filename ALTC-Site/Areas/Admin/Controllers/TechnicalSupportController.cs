using ALTC_Website.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TechnicalSupportController : Controller
    {
        private readonly ITechnicalSupportService requestService;

        public TechnicalSupportController(ITechnicalSupportService _requestService)
        {
            requestService = _requestService;
        }
        public IActionResult Index()
        {
            var model = requestService.GetAll();
            return View(model);
        }
    }
}
