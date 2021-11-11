using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.RedirectToRoutes;
using WebFramework.UserManagerExtension;

namespace WebFramework
{
    public static class FilterApiActionaUserActive
    {
        public static void FilterLogin(ActionExecutingContext context)
        {
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();

            var userName = context.HttpContext.Request.Form.FirstOrDefault(w=> w.Key== "UserName").Value;

            if (!string.IsNullOrEmpty(userName))
            {
                var isActive = userManager.CheckActiveUser(userName);
                var result = isActive.GetAwaiter().GetResult();
                if (!result)
                    RedirectToRoute.Redirect(context, "Home", "ConntAccess");
            }
        }
    }
}
