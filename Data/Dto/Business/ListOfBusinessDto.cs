using System;

namespace Data.Dto.Business
{
    public class ListBusinessDto
    {
        public Guid IdBusinessFull { get; set; }
        public string BusinessUrl { get; set; }
        public string Description { get; set; }
        public string NameBusiness { get; set; }
        public string BusinessManeger { get; set; }
        public string PathLogoMini { get; set; }
        public bool IsActive { get; set; }
    }
}
