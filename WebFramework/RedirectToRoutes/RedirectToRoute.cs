using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace WebFramework.RedirectToRoutes
{
    public static class RedirectToRoute
    {
        public static void Redirect(ActionExecutingContext context, string controller, string action)
        {
            context.Result = new RedirectToRouteResult(
                          new RouteValueDictionary
                     {
                        { "controller", controller },
                        { "action", action }
                     });
        }
    }
}
