using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto.User
{
    public class ProfileDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
        public Guid JobId { get; set; }
        public string Address { get; set; }
        public string PathImgUser { get; set; }
    }
}
