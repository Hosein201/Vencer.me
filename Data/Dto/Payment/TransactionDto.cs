using Nest;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto.Payment
{
    public class TransactionDto
    {
        public TransactionDto()
        {
            this.IsSite = true;
        }
        [Required(ErrorMessage = "لطفا توضیحات خود را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا مبلع مورد نظر خود را برای افزایش اعتبار وارد کنید")]
        [Display(Name = "مبلغ"), Number]
        public long Amount { get; set; }
        public Guid UserId { get; set; }
        public bool IsSite { get; set; }
    }

    public class DiscountDto
    {
        public DiscountDto()
        {
            this.IsSite = true;
        }

        [Required(ErrorMessage = "لطفا توضیحات خود را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا مبلع مورد نظر خود را برای افزایش اعتبار وارد کنید")]
        [Display(Name = "مبلغ"),  Number]
        public long Amount { get; set; }
        public bool IsSite { get; set; }
        public Guid UserId { get; set; }
    }
}
