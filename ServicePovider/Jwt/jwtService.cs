using Common.Interface;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ServicePovider
{
    public class JwtService : IJwtService, IScopedDependency
    {

        private readonly SignInManager<User> signInManager;

        public JwtService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(User user, string roleName)
        {
            var securityKey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");
            var encryptkey = Encoding.UTF8.GetBytes("16CharEncryptKey");
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey)
                , SecurityAlgorithms.HmacSha256Signature);

            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptkey),
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var Claims = await getClaims(user, roleName);
            var descriptor = new SecurityTokenDescriptor()
            {
                Audience = "Vencer",
                Issuer = "Vencer",
                Expires = DateTime.Now.AddMinutes(60),
                NotBefore = DateTime.Now.AddMinutes(0),
                Subject = new ClaimsIdentity(Claims),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> getClaims(User user, string roleName)
        {
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var listClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(securityStampClaimType, user.SecurityStamp.ToString()),
                new Claim(ClaimTypes.Role,roleName),
                new Claim(ClaimTypes.Surname,user.FullName is null ? "پروفایل کاربری" : user.FullName),
                new Claim(type:"PathImgUser", value: user.PathImgUser is null ? "placeholderImage.jpg" : user.PathImgUser)
            };
            var result = await signInManager.ClaimsFactory.CreateAsync(user);
            var Claim = result.Claims;
            return listClaim;
        }
    }
}
