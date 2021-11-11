using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto.Customer
{
    public class EditProfileDto
    {

        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام ونام خانوادگی")]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل"), EmailAddress(ErrorMessage = "لطفا ایمیل خود را به درستی وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفاکشور خود راانتخاب کنید")]
        [Display(Name = "کشور")]
        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "لطفا استان خود را انتخاب کنید")]
        [Display(Name = "استان")]
        public Guid ProvinceId { get; set; }

        [Required(ErrorMessage = "لطفا شهر خود را انتخاب کنید")]
        [Display(Name = "شهر")]
        public Guid CityId { get; set; }

        //[Required(ErrorMessage = "لطفا شغل خود را انتخاب کنید")]
        //[Display(Name = "شغل")]
        //public Guid JobId { get; set; }

        [Required(ErrorMessage = "لطفا آدرس تکمیلی خود را وارد کنید")]
        [Display(Name = "آدرس تکمیلی")]
        public string Address { get; set; }
        public string UserName { get; set; }

    }
  
}
