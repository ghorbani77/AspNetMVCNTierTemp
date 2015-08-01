using System;
using System.Collections.Generic;
using System.Timers;
using System.Web;
using MVC5.Common.Helpers.Extentions;
using MVC5.Common.Helpers.Http;

namespace MVC5.Common.HttpModules
{
    /// <summary>
    /// ماژولی برای جلوگیری از حملات 
    /// Dos
    /// </summary>
    public class DosAttackModule : IHttpModule
    {

        #region  Fields
        private const int BannedRequests = 10;
        private const int ReductionInterval = 1000; // 1 second
        private const int ReleaseInterval = 12 * 60 * 60 * 1000; // 12 hour

        public static Dictionary<string, short> IpAdresses { get; private set; }
        public static Stack<string> Banned { get; private set; }
        public static Timer Timer { get; private set; }
        public static Timer BannedTimer { get; private set; }

        #endregion

        #region Constructor
        static DosAttackModule()
        {
            IpAdresses = new Dictionary<string, short>();
            Banned = new Stack<string>();
            Timer = CreateTimer();
            BannedTimer = CreateBanningTimer();
        }
        #endregion

        #region IHttpModule Members
        void IHttpModule.Dispose()
        {
            // Nothing to dispose; 
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        private static void Context_BeginRequest(object sender, EventArgs e)
        {
            //اگر عمل 
            //Forwarding 
            //صورت نگیرد در این صورت آدرس اصلی در متغییر زیر است
            var ip = HttpContext.Current.Request.GetIp();

            if (Banned.Contains(ip))
            {
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.Response.End();
            }

            CheckIpAddress(ip);
        }

        #endregion

        #region CheckIpAddress
        /// <summary>
        /// چک میکنیم که آیا آی پی مورد نظر در لیست 
        /// آی پی های است یا خیر ، اگر از حد تعیین شده زیاد بود درخواست هایش لذا بلاک شود
        /// </summary>
        /// <param name="ip">آی پی شخص</param>
        private static void CheckIpAddress(string ip)
        {
            if (!IpAdresses.ContainsKey(ip))
            {
                IpAdresses[ip] = 1;
            }
            else if (IpAdresses[ip] == BannedRequests)
            {
                Banned.Push(ip);
                IpAdresses.Remove(ip);
            }
            else
            {
                IpAdresses[ip]++;
            }
        }
        #endregion

        #region Timers

        /// <summary>
        ///در این متد یک تایمر برای برای حذف آی پی  از لیست آی پی ها
        /// </summary>
        private static Timer CreateTimer()
        {
            var timer = GetTimer(ReductionInterval);
            timer.Elapsed += TimerElapsed;
            return timer;
        }

        /// <summary>
        ///ساخت تایمر برای حذف آی پی  بلاک شده از لیست آی پی های بلاک شده 
        /// </summary>
        /// <returns></returns>
        private static Timer CreateBanningTimer()
        {
            var timer = GetTimer(ReleaseInterval);
            timer.Elapsed += delegate { Banned.Pop(); };
            return timer;
        }

        /// <summary>
        /// Creates a simple timer instance and starts it.
        /// </summary>
        /// <param name="interval">The interval in milliseconds.</param>
        private static Timer GetTimer(int interval)
        {
            var timer = new Timer { Interval = interval };
            timer.Start();

            return timer;
        }

        /// <summary>
        /// کم کردن تعداد درخواست هر آی پی در هر ثانیه
        /// </summary>
        private static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var key in IpAdresses.Keys)
            {
                IpAdresses[key]--;
                if (IpAdresses[key] == 0)
                    IpAdresses.Remove(key);
            }
        }

        #endregion

    }
}
