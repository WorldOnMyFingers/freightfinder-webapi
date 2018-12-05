using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FreightFinder.Core.Domain;
using FreightFinder.Core.Mapping;
using FreightFinder.Helpers.IoC;
using FreightFinder.Service;

namespace WebApiFreightFinder
{
    public class Bootstrapper
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder = Start.Run(builder);
            SetAutofacContainer(builder);

        }

        private static void SetAutofacContainer(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(typeof(CompanyService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(VehicleServices).Assembly)
               .Where(t => t.Name.EndsWith("Services"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserServices).Assembly)
               .Where(t => t.Name.EndsWith("Services"))
               .AsImplementedInterfaces().InstancePerRequest();
            AutoMapperConfiguration.Setup();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}