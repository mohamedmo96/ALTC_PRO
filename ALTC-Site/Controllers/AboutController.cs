using Microsoft.AspNetCore.Mvc;

namespace ALTC_Site.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
