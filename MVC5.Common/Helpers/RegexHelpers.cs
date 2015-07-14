using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC5.Common.Helpers
{
   public   static class RegexHelpers
    {
        private static readonly Regex HtmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        /// <summary>
        /// حذف تمامی تگ‌های موجود
        /// </summary>
        /// <param name="html">ورودی اچ تی ام ال</param>
        /// <returns></returns>
        public static string CleanTags(this string html)
        {
            return HtmlRegex.Replace(html, string.Empty);
        }

        private static readonly Regex ContentRegex = new Regex(@"<\/?script[^>]*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// تنها حذف یک تگ ویژه
        /// </summary>
        /// <param name="html">ورودی اچ تی ام ال</param>
        /// <returns></returns>
        public static string CleanScriptTags(this string html)
        {
            return ContentRegex.Replace(html, string.Empty);
        }

        private static readonly Regex SafeStrRegex = new Regex(@"<script[^>]*?>[\s\S]*?<\/script>",
           RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// حذف یک تگ ویژه به همراه محتویات آن
        /// </summary>
        /// <param name="html">ورودی اچ تی ام ال</param>
        /// <returns></returns>
        public static string CleanScriptsTagsAndContents(this string html)
        {
            return SafeStrRegex.Replace(html, "");
        }
    }
}
