using Microsoft.Extensions.DependencyInjection;

namespace Services.SignalR
{
    public static class SignalRExtensions
    {
        public static void AddCustomeSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
        }
    }
}
