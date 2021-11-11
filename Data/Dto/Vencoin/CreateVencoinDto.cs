using System.ComponentModel.DataAnnotations;

namespace Data.Dto.Vencoin
{
    public class CreateVencoinDto
    {
        public string TypeSaleOrBuy { get; set; }
        [Display(Name = "مبلغ"), Required(ErrorMessage = "لطفا مبلغ دلخواه خود  را  وارد کنید")]
        public string Price { get; set; }
        [Display(Name = "حجم یا تعداد"), Required(ErrorMessage = "لطفا تعداد یا حجم دلخواه خود  را  وارد کنید")]
        public string Total { get; set; }
        [Display(Name = "شرایط خرید")]
        public string Condition { get; set; }
    }
}
