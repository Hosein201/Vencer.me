using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{

    public class BusinessController : Controller
    {
        [AuthorizeCookie]
        public IActionResult CreateBusiness()
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult BusinessList()
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult BusinessLists()
        {
            return View();
        }

        [Route("{NameBusiness}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Business()
        {
             var urlView= HttpContext.Request.Path.ToString().Split("/");
             ViewBag.url = urlView[1];
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [AuthorizeCookie]
        [Route("EditBusiness/{EditBusiness}")]
        public IActionResult EditBusiness()
        {
            var urlView = HttpContext.Request.Path.ToString().Split("/");
            ViewBag.urlEdit = urlView[2];
            return View();
        }
    }
}