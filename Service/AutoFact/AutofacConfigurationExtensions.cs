using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Interface;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using ServicePovider;
using System;
using Quartz;
using WebFramework;

namespace Services
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServiceWithAutofac(this ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
           // containerBuilder.Register(c => c.Resolve<ISchedulerFactory>().GetScheduler());
            System.Reflection.Assembly dataAssembly = typeof(UserRepository).Assembly; //rep
            System.Reflection.Assembly serviceAssembly = typeof(CookieCustom).Assembly; // service
            System.Reflection.Assembly webFrameworkAssembly = typeof(FileManeger).Assembly; //  webFramework
            System.Reflection.Assembly servicePoviderAssembly = typeof(ServiceAccount).Assembly; //  ServicePovider
                                                                                                 // System.Reflection.Assembly webFrameworkAssemblyPaymentPay = typeof(PaymentPay).Assembly; //  webFramework

            containerBuilder.RegisterAssemblyTypes(dataAssembly, serviceAssembly, webFrameworkAssembly, servicePoviderAssembly).AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            containerBuilder.RegisterAssemblyTypes(dataAssembly, serviceAssembly, webFrameworkAssembly, servicePoviderAssembly).AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces().InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(dataAssembly, serviceAssembly, webFrameworkAssembly, servicePoviderAssembly).AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces().SingleInstance();
            // containerBuilder.RegisterType<ServiceReference1.PaymentGatewayClient>().As<ServiceReference1.PaymentGatewayClient>().AsImplementedInterfaces().InstancePerLifetimeScope();

        }
        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.AddServiceWithAutofac();

            IContainer container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
