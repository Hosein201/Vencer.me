using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    [AuthorizeCookie]
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult RegsiterInPanel()
        {
            return View();
        } 
        public IActionResult EditProfile()
        {
            return View();
        }
    }
}