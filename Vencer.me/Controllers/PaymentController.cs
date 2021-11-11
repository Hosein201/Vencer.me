using Microsoft.AspNetCore.Mvc;
using Services;

namespace Vencer.me.Controllers
{
    [AuthorizeCookie]
    public class PaymentController : Controller
    {
        public IActionResult AddPayment() // افزایش اعتبار
        {
            return View();
        }
        public IActionResult ReportPayments() // گزارش تراکنش ها کاربر
        {
            return View();
        }
        public IActionResult ReportPaymentsUsers()// گزارش تراکنش ها کاربران
        {
            return View();
        }
        public IActionResult ReportPaymentByMoblie() // گزارش تراکنش با توجه به موبایل 
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult VerifyToPay()
        {
            return View();
        }
        public IActionResult DiscountPayment()
        {
            return View();
        }   
        public IActionResult TransactionPayment()
        {
            return View();
        }
    }
}
