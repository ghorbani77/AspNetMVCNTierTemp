
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC5.Common.Helpers;

namespace MVC5.Common.MVC
{
    public static class AspNetMvcHelpers
    {
        #region GetSummaryFromHtml
        /// <summary>
        /// get summary of Html with max size
        /// </summary>
        /// <param name="html"></param>
        /// <param name="text"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string GetSummaryFromHtml(this HtmlHelper html, string text, int max)
        {
            var summaryHtml = string.Empty;
            var words = text.CleanTags().Split(new[] { ' ' });

            for (var i = 0; i < max; i++)
            {
                summaryHtml += words[i];
            }

            return summaryHtml;
        }

        #endregion

        #region Persia.Net 
        //public static MvcHtmlString FarsiDate(this HtmlHelper html, DateTime dateTime)
        //{
        //    var tag = new TagBuilder("span");
        //    tag.MergeAttribute("dir", "ltr");
        //    tag.AddCssClass("farsi-date");
        //    tag.SetInnerText(Calendar.ConvertToPersian(dateTime).ToString("W"));
        //    return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        //}

        //public static MvcHtmlString FarsiDateAndTime(this HtmlHelper html, DateTime dateTime)
        //{
        //    return MvcHtmlString.Create(FarsiTime(html, dateTime).ToHtmlString() + "  ,  " + FarsiDate(html, dateTime).ToHtmlString());
        //}
        //public static MvcHtmlString FarsiTime(this HtmlHelper html, DateTime dateTime)
        //{
        //    var tag = new TagBuilder("span");
        //    tag.MergeAttribute("dir", "ltr");
        //    tag.AddCssClass("farsi-time");
        //    tag.SetInnerText(Calendar.ConvertToPersian(dateTime).ToString("R"));
        //    return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        //}
        //public static MvcHtmlString FarsiRemaining(this HtmlHelper html, DateTime dateTime)
        //{
        //    var tag = new TagBuilder("span");
        //    tag.MergeAttribute("dir", "rtl");
        //    tag.AddCssClass("farsi-remaining");
        //    tag.SetInnerText(Calendar.ConvertToPersian(dateTime).ToRelativeDateString("TY"));
        //    return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        //}

        #endregion

        #region GetListOfErrors
        public static List<string> GetListOfErrors(this ModelStateDictionary modelState)
        {
            var list = modelState.ToList();
            var listErrors = new List<string>();
            foreach (var keyValuePair in list)
            {
                listErrors.AddRange(keyValuePair.Value.Errors.Select(error => error.ErrorMessage));
            }
            return listErrors;
        }
        #endregion
      
    }
}
