using MVC5.ServiceLayer.Contracts;
using MVC5.ServiceLayer.EFServiecs;
using StructureMap.Configuration.DSL;
namespace MVC5.IocConfig
{
    public class ServiceLayerRegistery : Registry
    {
        public ServiceLayerRegistery()
        {
            For<IGroupService>().Use<GroupService>();
        }
    }
}
