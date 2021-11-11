using Microsoft.AspNetCore.Mvc.Filters;
using WebFramework.RedirectToRoutes;
namespace WebFramework
{
    public class FilterApiAction : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = (string)context.RouteData.Values["controller"];
            string action = (string)context.RouteData.Values["action"];

            if (!string.IsNullOrEmpty(action))
            {
                if (action == "Login" && controller== "ApiAccount")
                {
                    FilterApiActionaUserActive.FilterLogin(context);
                }
                FilterApiActionPermission.FilterPermission(context, action);
            }
            else
            {
                RedirectToRoute.Redirect(context, "Home", "ConntAccess");
            }
        }
    }
}
