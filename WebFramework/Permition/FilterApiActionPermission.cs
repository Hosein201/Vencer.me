using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebFramework.Permition;
using WebFramework.RedirectToRoutes;

namespace WebFramework
{
    public static class FilterApiActionPermission
    {
        public static void FilterPermission(ActionExecutingContext context , string action)
        {
            if (context.Controller.GetType().IsSubclassOf(typeof(ControllerBase)))
            {
                var customAttributesLength = context.Controller.GetType().GetMethod(action).GetCustomAttributes(typeof(PermissionAttribute), true).Length;

                if (customAttributesLength > 0)
                {
                    var permissionAttribute = (PermissionAttribute)Attribute.GetCustomAttributes(context.Controller.GetType().GetMethod(action), typeof(PermissionAttribute)).FirstOrDefault();
                    if (!permissionAttribute.Active)
                    {
                        RedirectToRoute.Redirect(context, "Home", "ConntAccess");
                        return;
                    }
                    if (permissionAttribute.Permission.ToDisplay() != VencerPermission.AllUser.ToDisplay())
                        if (!context.HttpContext.User.IsInRole(permissionAttribute.Permission.ToDisplay()))
                        {
                            RedirectToRoute.Redirect(context, "Home", "ConntAccess");
                            return;
                        }
                }
                else if (customAttributesLength < 0)
                {
                    RedirectToRoute.Redirect(context, "Home", "ConntAccess");
                    return;
                }
            }
        }
    }
}
