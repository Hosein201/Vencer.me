using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    [AuthorizeCookie]
    public class VencoinController : Controller
    {
        public IActionResult ReportVencoin()
        {
            return View();
        }

        public IActionResult BuyOrSalesVencoin()
        {
            return View();
        }

        public IActionResult DetailVencoinUsers()
        {
            return View();
        }
    }
}
