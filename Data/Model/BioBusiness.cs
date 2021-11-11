using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Repository;

namespace Data.Model
{
    public class BioBusiness : IEntityDb
    {
        public BioBusiness()
        {
            Id = Guid.NewGuid();
            RegisterDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "PathLogoMax")]
        public string PathLogoMax { get; set; }

        public string PathLogoMini { get; set; }

        //[Required(ErrorMessage = "PathLicense")]
        public string PathLicense { get; set; }

        //[Required(ErrorMessage = "PathVideo")]
        public string PathVideo { get; set; }

        [Required(ErrorMessage = "لطفا نام کسب کار خود را وارد کنید ")]
        [MaxLength(20, ErrorMessage = "نام کسب کار نمی نواند بیست کاراکتر باشد")]
        [Display(Name = "نام کسب کار")]
        public string NameBusiness { get; set; }

        [Display(Name = "مدیر")]
        [Required(ErrorMessage = "لطفا نام مدیر خود را وارد کنید")]
        [MaxLength(20, ErrorMessage = " نام مدیر نمی نواند بیست کاراکتر باشد")]
        public string BusinessManeger { get; set; }

        [Display(Name = "نوع کسب کار")]
        [MaxLength(20, ErrorMessage = "نام نوع کسب  کار نمی نواند بیست کاراکتر باشد")]
        public string TypeBusiness { get; set; }

        [Display(Name = "توضیحات ")]
        [MaxLength(1500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است")]
        public string Description { get; set; }

        [Display(Name = "ساعت کاری")]
        // [Required(ErrorMessage = "لطفا ساعت کاری خود را مشخص کنید")]
        public string Clock { get; set; }

        public string GalleryImg { get; set; }
        public string Mobile { get; set; }
        public string HomeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }

        public string Address { get; set; }
        public string WhatsApp { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Aparat { get; set; }

        [ForeignKey(nameof(BusinessFullId))]
        public Guid BusinessFullId { get; set; }
        public BusinessFull BusinessFull { get; set; }
    }
}


       

