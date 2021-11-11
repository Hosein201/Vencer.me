using Data.Dto.User;
using Data.Model;
using System;

namespace WebFramework.CustomMapper
{
    public static class Req2User
    {
        public static User ReqDto2User(UserRegsiterDto regsiterDto)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = regsiterDto.Email,
                UserName = regsiterDto.UserName,
                PhoneNumber = regsiterDto.Mobile,
                LastLoginDate = DateTime.Now,
                FullName = regsiterDto.FullName,
            };
            return user;
        }
        public static User ReqDto2User(UserRegsiterInPanelDto regsiterDto)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = regsiterDto.Email,
                UserName = regsiterDto.UserName,
                PhoneNumber = regsiterDto.Mobile,
                LastLoginDate = DateTime.Now,
                FullName = regsiterDto.FullName,
            };
            return user;
        }

    }
}
