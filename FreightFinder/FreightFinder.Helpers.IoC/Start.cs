using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightFinder.Core.IDAL;
using FreightFinder.Core.IoC;
using FreightFinder.Core.IServices;
using FreightFinder.DAL;
using FreightFinder.DAL.Repository;
using FreightFinder.Service;
using Ninject.Extensions.Conventions.Syntax;

namespace FreightFinder.Helpers.IoC
{
    public class Start 
    {

        public static ContainerBuilder Run(ContainerBuilder builder)
        {
             builder = Load(builder);

            return builder;
        }

        private static ContainerBuilder Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<object>>().As<IRepository<object>>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            return builder;
        }
    }
}
