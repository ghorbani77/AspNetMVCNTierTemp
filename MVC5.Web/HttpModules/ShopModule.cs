using System;
using System.Web;

namespace MVC5.Web.HttpModules
{
    public class ShopModule : IHttpModule
    {
    
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
           context.BeginRequest+=OnBeginRequest;
        }

        #endregion

        private static void OnBeginRequest(Object source, EventArgs e)
        {
            
        }
     
    }
}
