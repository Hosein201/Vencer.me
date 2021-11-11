using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Regsiter()
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}