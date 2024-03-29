﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using WebFramework;

namespace Services.Middlewares
{
    public static class UseEndpoints
    {
        public static void CustomUseEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<UpdateDataGrid>("/updateDataGrid");

            });
        }
    }
}
