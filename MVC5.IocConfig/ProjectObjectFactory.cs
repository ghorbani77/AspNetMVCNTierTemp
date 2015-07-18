using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.DataLayer.Context;
using StructureMap;
using StructureMap.Web;

namespace MVC5.IocConfig
{
    public class ProjectObjectFactory
    {
        #region Fields
        private static readonly Lazy<Container> ContainerBuilder =
          new Lazy<Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion

        #region Container
        public static IContainer Container
        {
            get { return ContainerBuilder.Value; }
        }
        #endregion

        #region DefaultContainer
        private static Container DefaultContainer()
        {
            var container = new Container(ioc =>
             {
                 ioc.For<IUnitOfWork>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<ApplicationDbContext>();

                 ioc.For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
                 ioc.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                 ioc.For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
                 ioc.For<HttpRequestBase>().Use(ctx => ctx.GetInstance<HttpContextBase>().Request);
                 ioc.For<ISessionProvider>().Use<SessionProvider>();
                 ioc.For<IFormatter>().Use(a=>new BinaryFormatter());
                 ioc.For<ITempDataProvider>().Use<CustomTempDataProvider>();

                 ioc.AddRegistry<AspNetIdentityRegistery>();
                 ioc.AddRegistry<AutoMapperRegistery>();
                 ioc.AddRegistry<ServiceLayerRegistery>();

                 ioc.Scan(scanner => scanner.WithDefaultConventions());
             });

            return container;
        }
        #endregion


    }
}
