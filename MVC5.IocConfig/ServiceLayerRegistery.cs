
using System.Runtime.Serialization;
using System.Web.Mvc;
using MVC5.Common.Controller;
using MVC5.ServiceLayer.Mailers;
using StructureMap.Configuration.DSL;
using System.Runtime.Serialization.Formatters.Binary;

namespace MVC5.IocConfig
{
    public class ServiceLayerRegistery : Registry
    {
        public ServiceLayerRegistery()
        {
          
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.AssemblyContainingType<UserMailer>();
            });
        }
    }
}
