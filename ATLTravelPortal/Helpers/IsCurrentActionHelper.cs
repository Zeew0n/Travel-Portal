using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Runtime.CompilerServices;
using System.Web.Routing;


namespace ATLTravelPortal.Helpers
{
    public static class IsCurrentActionHelper
    {

        public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        //public static MvcForm FormHelper(this HtmlHelper helper)
        //{
        //    string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
        //    string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

        //    TagBuilder builder = new TagBuilder("form");
        //   // builder.MergeAttributes<string, object>(htmlAttributes);
        //    builder.MergeAttribute("action", currentControllerName);
        //    builder.MergeAttribute("method", HtmlHelper.GetFormMethodString(FormMethod.Post), true);
        //    helper.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.StartTag));

        //    return new MvcForm(helper.ViewContext);
        //}


        public static string BeginListItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            string result;
            TagBuilder builder = GetListItem(helper, linkText, actionName, controllerName);
            result = builder.ToString(TagRenderMode.StartTag);
            result += builder.InnerHtml;

            return result;
        }


        static TagBuilder GetListItem(HtmlHelper helper, string linkText, string actionName, string controllerName)
        {

            var linkHtml = HtmlHelper.GenerateLink(helper.ViewContext.RequestContext, helper.RouteCollection, linkText, null, actionName, controllerName, null, null);

            var builder = new TagBuilder("li");

            var isCurrent = IsCurrentAction(helper, actionName, controllerName);

            if (isCurrent)
            {
                builder.MergeAttribute("class", "current");
            }
            else
            {
                builder.MergeAttribute("class", "notCurrent");
            }

            builder.InnerHtml = linkHtml;
            return builder;
        }
    }
}