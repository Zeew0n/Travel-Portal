using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Text;
namespace ATLTravelPortal.Helpers
{
    public static class MenuItemHelper
    {

        public static string MenuItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {

            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            var sb = new StringBuilder();

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                sb.Append("<li class=\"active\">");
            else
                sb.Append("<li>");

            sb.Append(helper.ActionLink(linkText, actionName, controllerName));
            sb.Append("</li>");
            return sb.ToString();

        }



    }
}