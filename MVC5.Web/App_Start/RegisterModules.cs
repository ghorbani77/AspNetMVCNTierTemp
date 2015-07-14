
using System.Web;
using MVC5.Web;

[assembly :PreApplicationStartMethod(typeof(RegisterModules),"Start")]
namespace MVC5.Web
{
    public class RegisterModules
    {
        public static void Start()
        {
        //    DynamicModuleUtility.RegisterModule(typeof(DosAttackModule));
        //    DynamicModuleUtility.RegisterModule(typeof(AntiXssModule));
        //    DynamicModuleUtility.RegisterModule(typeof(Common.HttpCompress.HttpModule));
        }
    }
}