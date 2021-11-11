using System.ComponentModel.DataAnnotations;

namespace Data.Dto.Business
{
    public class EditDetailDto
    {
        [Required(ErrorMessage = "لطفا نام کسب کار خود را وارد کنید ")]
        [MaxLength(20, ErrorMessage = "نام کسب کار نمی نواند بیست کاراکتر باشد")]
        [Display(Name = "نام کسب کار")]
        public string NameBusiness { get; set; }

        [Display(Name = "نوع کسب کار")]
        [MaxLength(20, ErrorMessage = "نام نوع کسب  کار نمی نواند بیست کاراکتر باشد")]
        public string TypeBusiness { get; set; }

        [Display(Name = "مدیر")]
        [Required(ErrorMessage = "لطفا نام مدیر خود را وارد کنید")]
        [MaxLength(20, ErrorMessage = " نام مدیر نمی نواند بیست کاراکتر باشد")]
        public string BusinessManeger { get; set; }

        [Display(Name = "توضیحات ")]
        [MaxLength(1500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است")]
        public string Description { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [MaxLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [MinLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [Display(Name = "موبایل"), Phone]
        public string Mobile { get; set; }


        [Display(Name = "تلفن ")]
        public string HomeNumber { get; set; } // لیست شماره محل کار

        [Display(Name = "فکس")]
        public string FaxNumber { get; set; } // لیست شماره فکس 

        [Display(Name = "ایمیل"), EmailAddress(ErrorMessage = "لطفا ایمیل خود را به درستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "واتساپ")]
        public string WhatsApp { get; set; }
        [Display(Name = "یوتیوب")]
        public string Youtube { get; set; }
        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }
        [Display(Name = "آپارات")]
        public string Aparat { get; set; }

    }

    public class EditGalleryDto
    {
        public string ImgGallery { get; set; }
        public string PathVideo { get; set; }
    }

    public class EditWorkHoursDto
    {
        public string Clock { get; set; }
    }

    public class EditLogoBusinessDto
    {
        public string PathLogoMini { get; set; }
        public string PathLicense { get; set; }
        public string PathLogoMax { get; set; }
    }
}
