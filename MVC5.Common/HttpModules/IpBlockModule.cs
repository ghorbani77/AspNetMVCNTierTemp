using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Caching;
using MVC5.Common.Helpers.Http;

namespace MVC5.Common.HttpModules
{
    public class IpBlockModule : IHttpModule
       {
           private readonly EventHandler _onBeginRequest;
   
           public IpBlockModule()
           {
               _onBeginRequest = HandleBeginRequest;
           }
   
           void IHttpModule.Dispose()
           {
           }
   
           void IHttpModule.Init(HttpApplication context)
           {
               context.BeginRequest += _onBeginRequest;
           }
   
           const string Blockedipskey = "blockedips";
           const string Blockedipsfile = "SiteConfig/blockedips.config";
   
           public static StringDictionary GetBlockedIPs(HttpContext context)
           {
               var ips = (StringDictionary)context.Cache[Blockedipskey ];
               if (ips != null) return ips;
               ips = GetBlockedIPs(GetBlockedIPsFilePathFromCurrentContext(context));
               context.Cache.Insert(Blockedipskey , ips, new CacheDependency(GetBlockedIPsFilePathFromCurrentContext(context)));
               return ips;
           }
   
           private static string _blockedIpFileName;
           private static readonly object BlockedIpFileNameObject = new object();
           public static string GetBlockedIPsFilePathFromCurrentContext(HttpContext context)
           {
               if (_blockedIpFileName != null)
                   return _blockedIpFileName;
               lock(BlockedIpFileNameObject)
               {
                   if (_blockedIpFileName == null)
                   {
                       _blockedIpFileName = context.Server.MapPath(Blockedipsfile);
                   }
               }
               return _blockedIpFileName;
           }
   
           public static StringDictionary GetBlockedIPs(string configPath)
           {
               var retval = new StringDictionary();
               using (var sr = new StreamReader(configPath)) 
               {
                   String line;
                   while ((line = sr.ReadLine()) != null) 
                   {
                       line = line.Trim();
                       if (line.Length != 0)
                       {
                           retval.Add(line, null);
                       }
                   }
               }
               return retval;
           }
   
           private static void HandleBeginRequest( object sender, EventArgs evargs )
           {
               var app = sender as HttpApplication;

               if (app == null) return;
               var ipAddr = app.Context.Request.GetIp();
               if (string.IsNullOrEmpty(ipAddr))
               {
                   return;
               }
   
               var badIPs = GetBlockedIPs(app.Context);
               if (badIPs == null || !badIPs.ContainsKey(ipAddr)) return;
               app.Context.Response.StatusCode = 404;
               app.Context.Response.SuppressContent = true;
               app.Context.Response.End();
           }
       }
}
