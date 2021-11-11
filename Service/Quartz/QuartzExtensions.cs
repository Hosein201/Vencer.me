using Microsoft.Extensions.DependencyInjection;
using Quartz;
using ServicePoviders;
using System;

namespace Services
{
    public static class QuartzExtensions
    {
        public static void AddQuartz(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.SchedulerId = "JobTransactionDailyId";
                q.SchedulerName = "JobTransactionDaily";
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                var jobKeyVencoin = new JobKey("TransactionVencoin", "TransactionVencoinGroup");
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    options.AllowDefaultConstructor = true;
                });

                q.AddJob<JobsVencoin>(j =>
                    j.StoreDurably()
                        .WithIdentity(jobKeyVencoin)
                        .WithDescription("DescriptionJobTransactionDaily").Build()
                );

                q.AddTrigger(t =>
                    t.WithIdentity("TriggerJobTransactionDaily")
                        .ForJob(jobKeyVencoin)
                        .StartAt(DateTimeOffset.Now.AddMinutes(1))
                        .WithDescription("DescriptionTriggerJobTransactionDaily")
                );
            });

            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });

        }
    }
}