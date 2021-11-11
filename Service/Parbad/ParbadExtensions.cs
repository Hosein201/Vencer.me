using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Parbad.Builder;
using Parbad.Gateway.ZarinPal;
using Parbad.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Parbad
{
    public static class ParbadExtensions
    {
        public static void AddServiceParbad
            (this IServiceCollection services, ParbadConfiguration parbad)
        {

        
            services.AddParbad().ConfigureGateways(gateways =>
            {
                gateways
                     .AddMellat()
                     .WithAccounts(source =>
                     {
                         source.AddInMemory(account =>
                         {
                             account.TerminalId = parbad.Mellat.TerminalId;
                             account.UserName = parbad.Mellat.UserName;
                             account.UserPassword = parbad.Mellat.UserPassword;
                         });
                     });
                gateways
                    .AddZarinPal()
                     .WithAccounts(source =>
                     {
                         source.AddInMemory(account =>
                         {
                             account.MerchantId = parbad.ZarinPal.MerchantId;
                             account.IsSandbox = parbad.ZarinPal.IsSandbox;
                         });
                     });
            }).Build();

            
        }
    }
}
