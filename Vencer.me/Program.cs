using Common.Utilities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Vencer.me
{
    public class Program
    {
        public static ILogger logger;
        public static void Main(string[] args)
        {

            logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(LogEventLevel.Verbose,
                   "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
                    new Uri("http://localhost:9200/"))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                    IndexFormat = "vencer-{0:yyyy.MM.dd}",
                    //FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                    EmitEventFailureHandling.WriteToFailureSink |
                                    EmitEventFailureHandling.RaiseCallback,
                    MinimumLogEventLevel = LogEventLevel.Verbose,
                    RegisterTemplateFailure = RegisterTemplateRecovery.IndexAnyway,
                    DeadLetterIndexName = "vencer-{0:yyyy.MM.dd}"
                })
                //.WriteTo.File($"./failures.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Appliction is started okey ");
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (AppException ex)
            {
                Log.Verbose(ex.StackTrace);
                throw new AppException(ApiResultStatusCode.ServerError, ex.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
             .UseIISIntegration()
                 .UseStartup<Startup>()
                    .UseSerilog(logger);

    }
}
