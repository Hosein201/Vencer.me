using Common;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class AddContext
    {
        public static void AddContextVerncer(this IServiceCollection services,
             ConnectionStrings connectionStrings)
        {
            services.AddDbContext<VencerDbContext>(options =>
            {
               options.UseSqlServer(connectionStrings.SqlServer);

                //options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=VencerDb;Trusted_Connection=True;");
                 //options.UseSqlServer(@"Server=185.187.51.202;Database=VencerDb;User Id=sa; Password=ven@cer123;Persist Security Info=True");
                //.ConfigureWarnings(warning => warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
            });
        }
    }
}
