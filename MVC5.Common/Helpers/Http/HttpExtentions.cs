using System.Web;

namespace MVC5.Common.Helpers.Http
{
    public static class HttpExtentions
    {
        public static string PhysicalToVirtualPathConverter(this HttpServerUtilityBase utility, string path, HttpRequestBase context)
        {
            return path.Replace(context.ServerVariables["APPL_PHYSICAL_PATH"], "/").Replace(@"\", "/");
        }
    }
}