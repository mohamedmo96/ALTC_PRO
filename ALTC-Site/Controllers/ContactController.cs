using Microsoft.AspNetCore.Mvc;

namespace ALTC_Website.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
