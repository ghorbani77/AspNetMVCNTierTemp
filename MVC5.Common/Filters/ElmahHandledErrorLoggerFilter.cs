//using Elmah;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MVC5.Web.Filters
//{
//    public class ElmahHandledErrorLoggerFilter:IExceptionFilter
//    {
//        public void OnException(ExceptionContext filterContext)
//        {
//            if (filterContext.ExceptionHandled)
//                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
//        }
//    }
//}