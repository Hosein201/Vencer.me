using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
 
    public class ShopController : Controller
    {
        [AuthorizeCookie]
        public IActionResult Products() 
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult ProductDetail() 
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult CreateProducts()
        {
            return View();
        }

        [AuthorizeCookie]
        public IActionResult ShopUserForAdmin() // For admin  لیست فروشگاه ها و تعداد محصولات
        {
            return View();
        }

        public IActionResult Shops() // For users  لیست فروشگاه ها و تعداد محصولات
        {
            return View();
        }
    }
}
