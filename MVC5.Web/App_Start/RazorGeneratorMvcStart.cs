using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(MVC5.Web.RazorGeneratorMvcStart), "Start")]

namespace MVC5.Web {
    public static class RazorGeneratorMvcStart {
        public static void Start() {
            var engine = new PrecompiledMvcEngine(typeof(RazorGeneratorMvcStart).Assembly) {
                UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(engine);
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }
    }
}
