using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dto.User
{
    public class UsersDto
    {
        public Guid UserId { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }

    public class UserRegsiterInPanelDto
    {
        public UserRegsiterInPanelDto()
        {
            IsSite = true;
        }
        [Display(Name = "نام و ناو خانوادگی")]
        public string  FullName { get; set; }
        [Required(ErrorMessage ="لطفا نام کاربری خود را وارد کنید")]
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }

        [Display(Name="ایمیل"),EmailAddress]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage="لطفا موبایل خود را وارد کنید")]
        [Display(Name="موبایل"),Phone]
        public string Mobile { get; set; }

        [Required(ErrorMessage ="لطفا رمز عبور خود را وارد کنید")]
        [Display(Name="رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا نام کسب وکار خود را وارد کنید")]
        [Display(Name ="نام کسب وکار")]
        public string NameBusiness { get; set; } 
        
        [Required(ErrorMessage = "لطفا ادرس کسب وکار خود را وارد کنید")]
        [Display(Name ="آدرس کسب وکار")]
        public string BusinessUrl { get; set; }

        [Required(ErrorMessage ="لطفا نام مدیر کسب  و کار خود را وارد کنید")]
        [Display(Name="مدیر کسب کار")]
        public string BusinessManeger { get; set; }

        [Display(Name="مبلغ")]
        public string Amount { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات خود را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string DcrAmount { get; set; }
        public bool IsSite { get; set; }

    }
    public class UserRegsiterDto
    {
        public UserRegsiterDto()
        {
            IsSite = true;
        }
        [Display(Name = "نام و ناو خانوادگی")]
        public string  FullName { get; set; }
        [Required(ErrorMessage ="لطفا نام کاربری خود را وارد کنید")]
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }

        [Display(Name="ایمیل"),EmailAddress]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage="لطفا موبایل خود را وارد کنید")]
        [Display(Name="موبایل"),Phone]
        public string Mobile { get; set; }

        [Required(ErrorMessage ="لطفا رمز عبور خود را وارد کنید")]
        [Display(Name="رمز عبور")]
        public string Password { get; set; }

        public bool IsSite { get; set; }

    }

    public class UserLogin
    {
        public UserLogin()
        {
            IsSite = true;
        }

        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        public bool IsSite { get; set; }

    }
    public class DataDashboard
    {
        public string RegisterDate { get; set; }
        public int CountBusinessFull { get; set; }
        public string MuchPayment { get; set; }
    }
}

