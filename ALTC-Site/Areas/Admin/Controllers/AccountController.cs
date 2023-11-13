using ALTC_Site.Models;
using ALTC_Site.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ALTC_Site.ViewModels;

namespace ALTC_Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            if(accountService.IsAuthenticated(user.Email,user.Password))
            {
                Account accountModel = accountService.Get(user.Email, user.Password);
                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, accountModel.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, accountModel.Name));
                claims.AddClaim(new Claim(ClaimTypes.Role, accountModel.Role));
                ClaimsPrincipal principle = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");

            }
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "MasterAdmin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "MasterAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            accountService.Add(account);
           // return View(account);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "MasterAdmin")]

        public IActionResult Delete(string id)
        {
            Account account = accountService.GetById(id);
            if (account != null)
            {
                accountService.Delete(id);
            }
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "MasterAdmin")]

        public IActionResult Index()
        {
          var accounts= accountService.GetAll();
            return View(accounts);
        }
    }
}
