 using System.ComponentModel.DataAnnotations;

namespace Data.Dto.User
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید ")]
        [Display(Name = "رمز عبور فعلی"), RegularExpression(@"^[A-Za-z]+\d+.*$", ErrorMessage = "رمز عبور حتما با یک کاراکتر انگلیسی شروع شود")]
        public string Oldpassword { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبورجدید خود را وارد کنید ")]
        [Display(Name = "رمز عبور جدید"), RegularExpression(@"^[A-Za-z]+\d+.*$", ErrorMessage = "رمز عبور حتما با یک کاراکتر انگلیسی شروع شود")]
        public string Newpassword { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور را وارد کنید")]
        [Display(Name = "تکرار رمز عبور جدید"), Compare( nameof(Newpassword), ErrorMessage = "تکرار رمز عبور را به درستی وارد کنید")]
        public string passwordConfirmed { get; set; }
    }
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری"),]
        public string UserName { get; set; }


        [Required(ErrorMessage = "لطفا موبایل خود را وارد کنید")]
        [Display(Name = "موبایل"), Phone]
        public string Mobile { get; set; }

    }
}
