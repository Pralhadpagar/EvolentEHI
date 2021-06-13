using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using EvolentEHI.IBL;
using Autofac.Integration.WebApi;
namespace EvolentEHI.WebApi.App_Start
{
    public  class ContainerConfig
    {
        /// <summary>
        /// config container
        /// </summary>
        /// <returns></returns>
        public static void Configure()
        {
            var builderobj = new ContainerBuilder();
            // builderobj.RegisterApiControllers(Assembly )
            var config = GlobalConfiguration.Configuration;            
            builderobj.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builderobj.RegisterType<ContactRepo>().As<IContactRepo>();
            var container = builderobj.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);           

        }

    }
}