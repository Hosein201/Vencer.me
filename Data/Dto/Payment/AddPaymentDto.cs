using Nest;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto.Payment
{
    public class AddPaymentDto
    {
        public AddPaymentDto()
        {
            this.IsSite = true;
            this.Increase = true;
            this.IsComplete = false;
            this.TransactionBetweenUser = false;
        }

        [Required(ErrorMessage = "لطفا توضیحات خود را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا موبایل خود را وارد کنید")]
        [MaxLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [MinLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [Display(Name = "موبایل"), Phone]
        public string Mobile { get; set; }
        public string Authority { get; set; }

        [Required(ErrorMessage = "لطفا مبلع مورد نظر خود را برای افزایش اعتبار وارد کنید")]
        [Display(Name = "مبلغ"), Number]
        public long Amount { get; set; }
        public bool IsSite { get; set; }
        public bool Discount { get; set; }
        public bool Increase { get; set; }
        public bool IsComplete { get; set; }
        public bool TransactionBetweenUser { get; set; }

    }

    public class VerifyToPayDto
    {
        public long Amount { get; set; }
        public string Authority { get; set; }


    }

    public class CreatePaymentDto
    {
        public long Amount { get; set; }
        public string Authority { get; set; }
        public string Refid { get; set; }
    }
    public class CreateUserAndSetBusinessAndSetPaymentDto
    {
        public CreateUserAndSetBusinessAndSetPaymentDto()
        {
            this.IsSite = true;
        }

        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری"),]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید ")]
        [Display(Name = "رمز عبور"), RegularExpression(@"^[A-Za-z]+\d+.*$", ErrorMessage = "رمز عبور حتما با یک کاراکتر انگلیسی شروع شود")]
        public string password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور را وارد کنید")]
        [Display(Name = "تکرار رمز عبور"), Compare("password", ErrorMessage = "تکرار رمز عبور را به درستی وارد کنید")]
        public string passwordConfirmed { get; set; }
        public string Authority { get; set; }
        public long Amount { get; set; }
        public bool IsSite { get; set; }
        [Required(ErrorMessage = "لطفالینک مورد نظر خود را برای کسب کار خود وارد کنید")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "کاراکترهای وارد شده نمی تواند عدد یا حرف خاص و فارسی باشد")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکترهای وارد شده نمیتواند بیش از 50 کاراکترباشد")]
        [Display(Name = "آدرس کسب کار")]
        public string BusinessUrl { get; set; }

        [Required(ErrorMessage = "لطفا نام کسب کار خود را وارد کنید ")]
        [MaxLength(20, ErrorMessage = "نام کسب کار نمی نواند بیست کاراکتر باشد")]
        [Display(Name = "نام کسب کار")]
        public string NameBusiness { get; set; }


        [Display(Name = "نوع کسب کار")]
        [Required(ErrorMessage = "لطفا نوع کسب  کار خود را وارد کنید")]
        [MaxLength(20, ErrorMessage = "نام نوع کسب  کار نمی نواند بیست کاراکتر باشد")]
        public string TypeBusines { get; set; }


        [Display(Name = "مدیر")]
        [Required(ErrorMessage = "لطفا نام مدیر خود را وارد کنید")]
        [MaxLength(20, ErrorMessage = " نام مدیر نمی نواند بیست کاراکتر باشد")]
        public string BusinessManeger { get; set; }


        [Display(Name = "توضیحات ")]
        [Required(ErrorMessage = "لطفا توضیحاتی در مورد کسب کار خود  بنویسید ")]
        [MaxLength(1500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است")]
        public string Description { get; set; }


        [Display(Name = "ساعت کاری")]
        public string Clock { get; set; }


        [Display(Name = "مسیر ویدیو معرفی")]
        public string PathVideo { get; set; }
        public string PathLogoMini { get; set; }
        public string PathLicense { get; set; }
        public string PathLogoMax { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا ادرسی برای کسب کار خود را تعیین کنید")]
        public string Address { get; set; }

        [Required(ErrorMessage = "لطفا موبایل خود را وارد کنید")]
        [MaxLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [MinLength(11, ErrorMessage = "لطفا موبایل خود را به درستی وارد کنید")]
        [Display(Name = "موبایل"), Phone]
        public string Mobile { get; set; }


        [Display(Name = "تلفن ")]
        [Required(ErrorMessage = "لطفا شماره  نلفن محل  کسب کار خود را وارد کنید")]
        public string HomeNumber { get; set; } // لیست شماره محل کار

        [Display(Name = "فکس")]
        [Required(ErrorMessage = "لطفا شماره فکس خود را وارد کنید")]
        public string FaxNumber { get; set; } // لیست شماره فکس 

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل"), EmailAddress(ErrorMessage = "لطفا ایمیل خود را به درستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "واتساپ")]
        public string WhatsApp { get; set; }
        [Display(Name = "تلگرام")]
        public string Telegram { get; set; }
        [Display(Name = "لینکدین")]
        public string Linkedin { get; set; }
        [Display(Name = "یوتیوب")]
        public string Youtube { get; set; }
        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }
        [Display(Name = "فیسبوک")]
        public string FaceBook { get; set; }
        [Display(Name = "آپارات")]
        public string Aparat { get; set; }
        [Display(Name = "سایت شخصی")]
        public string SitePersonal { get; set; }
    }
}
