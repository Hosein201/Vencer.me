using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    [AuthorizeCookie]
    public class TicketingController : Controller
    {
        public IActionResult Exchange()
        {
            return View();
        } 
        public IActionResult SupportExchangesUser()
        {
            return View();
        }  public IActionResult SupportExchanges()
        {
            return View();
        }
    }
}
