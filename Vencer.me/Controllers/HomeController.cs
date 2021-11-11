using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{

    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public HomeController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [AuthorizeCookie]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View();
        }


        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult ConntAccess()
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult Logout()
        {
            foreach (var cookie in HttpContext.Request.Cookies.Keys)
                Response.Cookies.Delete(cookie);
            _signInManager.Context.User = null;
            return RedirectToAction("Login", "Account");
        }
    }
}
