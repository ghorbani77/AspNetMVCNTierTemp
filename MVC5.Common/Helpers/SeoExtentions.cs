using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MVC5.Common.Helpers
{
    public static class SeoExtentions
    {
        #region Fields
        private const string SeparatorTitle = " - ";
        private const int MaxLenghtTitle = 60;
        private const int MaxLenghtSlug = 45;
        private const int MaxLenghtDescription = 170;
        #endregion

        #region MetaTag
        private const string FaviconPath = "~/cdn/ui/favicon.ico";
        public static string GenerateMetaTag(string title, string description, bool allowIndexPage, bool allowFollowLinks, string author = "", string lastmodified = "", string expires = "never", string language = "fa", CacheControlType cacheControlType = CacheControlType.Private)
        {
            title = title.Substring(0, title.Length <= MaxLenghtTitle ? title.Length : MaxLenghtTitle).Trim();
            description = description.Substring(0, description.Length <= MaxLenghtDescription ? description.Length : MaxLenghtDescription).Trim();

            var meta = "";
            meta += string.Format("<title>{0}</title>\n", title);
            meta += string.Format("<link rel=\"shortcut icon\" href=\"{0}\"/>\n", FaviconPath);
            meta += string.Format("<meta http-equiv=\"content-language\" content=\"{0}\"/>\n", language);
            meta += string.Format("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"/>\n");
            meta += string.Format("<meta charset=\"utf-8\"/>\n");
            meta += string.Format("<meta name=\"description\" content=\"{0}\"/>\n", description);
            meta += string.Format("<meta http-equiv=\"Cache-control\" content=\"{0}\"/>\n", EnumHelper.GetEnumDescription(typeof(CacheControlType), cacheControlType.ToString()));
            meta += string.Format("<meta name=\"robots\" content=\"{0}, {1}\" />\n", allowIndexPage ? "index" : "noindex", allowFollowLinks ? "follow" : "nofollow");
            meta += string.Format("<meta name=\"expires\" content=\"{0}\"/>\n", expires);

            if (!string.IsNullOrEmpty(lastmodified))
                meta += string.Format("<meta name=\"last-modified\" content=\"{0}\"/>\n", lastmodified);

            if (!string.IsNullOrEmpty(author))
                meta += string.Format("<meta name=\"author\" content=\"{0}\"/>\n", author);

            //------------------------------------Google & Bing Doesn't Use Meta Keywords ...
            //meta += string.Format("<meta name=\"keywords\" content=\"{0}\"/>\n", keywords);

            return meta;
        }
        #endregion

        #region Slug
        public static string GenerateSlug(this string title)
        {
            var slug = RemoveAccent(title).ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9-\u0600-\u06FF]", "-");
            slug = Regex.Replace(slug, @"\s+", "-").Trim();
            slug = Regex.Replace(slug, @"-+", "-");
            slug = slug.Substring(0, slug.Length <= MaxLenghtSlug ? slug.Length : MaxLenghtSlug).Trim();

            return slug;
        }
#endregion

        #region Title
         public static string ResolveTitleForUrl(this HtmlHelper htmlHelper, string title)
        {
            return string.IsNullOrEmpty(title)
                ? string.Empty
                : Regex.Replace(Regex.Replace(title, "[^\\w]", "-"), "[-]{2,}", "-");
        }

        public static string ResolveTitleForUrl(string title)
        {
            return string.IsNullOrEmpty(title)
                ? string.Empty
                : Regex.Replace(Regex.Replace(title, "[^\\w]", "-"), "[-]{2,}", "-");
        }
        private static string RemoveAccent(this string text)
        {
            var bytes = Encoding.GetEncoding("UTF-8").GetBytes(text);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string RemoveHtmlTags(this string text)
        {
            return string.IsNullOrEmpty(text) ? string.Empty : Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }

        public static string GeneratePageTitle(params string[] crumbs)
        {
            var title = "";

            for (var i = 0; i < crumbs.Length; i++)
            {
                title += string.Format
                            (
                                "{0}{1}",
                                crumbs[i],
                                (i < crumbs.Length - 1) ? SeparatorTitle : string.Empty
                            );
            }

            title = title.Substring(0, title.Length <= MaxLenghtTitle ? title.Length : MaxLenghtTitle).Trim();

            return title;
        }

        public static string GeneratePageDescription(string description)
        {
            return
                description.Substring(0,
                    description.Length <= MaxLenghtDescription ? description.Length : MaxLenghtDescription).Trim();
        }
        #endregion

        #region Enum
        public enum CacheControlType
        {
            [Description("public")]
            Public,
            [Description("private")]
            Private,
            [Description("no-cache")]
            Nocache,
            [Description("no-store")]
            Nostore
        }
        #endregion

    }
}