using Common.CommonModel;
using Common.Utilities;
using Microsoft.AspNetCore.Http;
using ServicePovider;
using System;

namespace Services
{
    public static class CookieCustom
    {
        public static string Get(IHttpContextAccessor httpContextAccesso, string key)
        {
            return httpContextAccesso.HttpContext.Request.Cookies[key];
        }
        public static void SetCookie(IResponseCookies ResponseCookies,
            AccessToken accessToken)
        {
            CookieOptions _options = new CookieOptions();
            if (accessToken.expires_in.ToString().HasValue())
                _options.Expires = DateTime.Now.AddMinutes(accessToken.expires_in);
            else
                _options.Expires = DateTime.Now.AddMilliseconds(10);

            ResponseCookies.Append(accessToken.token_type, accessToken.access_token, _options);
        }
        public static void SetCookieGeneral(IResponseCookies ResponseCookies,
            ModelCookieCustome model)
        {
            CookieOptions _options = new CookieOptions();
            if (model.Expire.ToString().HasValue())
                _options.Expires = DateTime.Now.AddMinutes(model.Expire);
            else
                _options.Expires = DateTime.Now.AddMilliseconds(10);

            ResponseCookies.Append(model.TypeCookie, model.Data, _options);
        }

        public static void RemoveCookie(IHttpContextAccessor httpContextAccesso, string key)
        {
            httpContextAccesso.HttpContext.Response.Cookies.Delete(key);
        }

    }
}
