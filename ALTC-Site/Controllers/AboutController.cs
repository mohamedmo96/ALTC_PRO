using ALTC_Website.Services;
using Microsoft.AspNetCore.Mvc;

namespace ALTC_Site.Controllers
{
    public class AboutController : Controller
    {
        private readonly IStaticData staticDataa;


        public AboutController(IStaticData staticData)
        {
            staticDataa = staticData;
        }
        public IActionResult GetAll()
        {
            var model = staticDataa.GetAll();
            return View(model);
        }
        public IActionResult Index()
        {
            var model = staticDataa.GetAll();
            return View(model);
        }
    }
}
