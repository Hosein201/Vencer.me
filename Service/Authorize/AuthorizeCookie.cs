using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebFramework.RedirectToRoutes;

namespace Services
{
    public class AuthorizeCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var token = context.HttpContext.Request.Cookies["Bearer"];
            var secretkey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");
            var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey");
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true,
                ValidAudience = "Vencer",

                ValidateIssuer = true,
                ValidIssuer = "Vencer",

            };
            var handler = new JwtSecurityTokenHandler();
            var user = (ClaimsPrincipal)null;
            try
            {
                user = handler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            }
            catch (Exception) { RedirectToRoute.Redirect(context, "Account", "Login"); return; }
            if (user != null)
            {
                var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();
                var validatedUser = signInManager.ValidateSecurityStampAsync(user);
                if (validatedUser == null) { RedirectToRoute.Redirect(context, "Account", "Login"); return; }
                signInManager.Context.User = user;
                base.OnActionExecuting(context);
            }
            else if (user == null) { RedirectToRoute.Redirect(context, "Account", "Login"); return; }
        }
    }
}
