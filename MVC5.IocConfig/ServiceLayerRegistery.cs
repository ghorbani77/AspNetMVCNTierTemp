using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.EFServiecs;
using MVC5.ServiceLayer.Mailers;
using StructureMap.Configuration.DSL;
namespace MVC5.IocConfig
{
    public class ServiceLayerRegistery : Registry
    {
        public ServiceLayerRegistery()
        {
            For<IUserMailer>().Use<UserMailer>();
        }
    }
}
