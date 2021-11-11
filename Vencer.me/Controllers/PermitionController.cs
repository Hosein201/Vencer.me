using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    [AuthorizeCookie]
    public class PermitionController : Controller
    {
        public IActionResult ManegmentUsers() => View();
    }
}
