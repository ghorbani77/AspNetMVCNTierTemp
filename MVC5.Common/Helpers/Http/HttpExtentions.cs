using System.Web;
using MVC5.Common.Helpers.Extentions;

namespace MVC5.Common.Helpers.Http
{
    public static class HttpExtentions
    {
        public static string PhysicalToVirtualPathConverter(this HttpServerUtilityBase utility, string path, HttpRequestBase context)
        {
            return path.Replace(context.ServerVariables["APPL_PHYSICAL_PATH"], "/").Replace(@"\", "/");
        }

        public static string GetIp(this HttpRequest request)
        {
            var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //اگر عمل 
            //Forwarding 
            //صورت نگیرد در این صورت آدرس اصلی در متغییر زیر است
            if (!ip.IsNotEmpty()) ip = request.UserHostAddress;
            return ip;
        }
    }
}