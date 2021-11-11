using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dto.SupportExchanges
{
    public class SupportExchangesDto
    {
    }

    public class CreateSupportExchangesDto
    {
        [Display(Name = "وضعیت")]
        public int State { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "مبلغ مورد نظر برای  واریز را وارد کنید"), MinLength(0 ,ErrorMessage = "مبلغ وارد شده معتبر نمی باشد")]
        public string AmountOfExchange { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "توضیحات مورد نظر را وارد کنید")]
        public string Description { get; set; }
        public string FilePath { get; set; }
        [Required(ErrorMessage = "شماره کارت مورد نظر را وارد کنید")]
        [Display(Name = "شماره کارت")]
        public string AccountNumberOfBank { get; set; }
    }
}
