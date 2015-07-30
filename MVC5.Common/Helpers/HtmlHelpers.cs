using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC5.Common.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString NoAutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.TextBoxFor(expression, new { @class = "form-control", autocomplete = "off" });
        }
        public static MvcHtmlString NoAutoCompleteTextBoxForLtr<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.TextBoxFor(expression, new { @class = "form-control", autocomplete = "off",dir="ltr" });
        }
        public static MvcHtmlString FormControlTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.TextBoxFor(expression, new { @class = "form-control"});
        }
        public static MvcHtmlString FormControlPasswordFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.PasswordFor(expression, new { @class = "form-control" });
        }
      
    }
}
