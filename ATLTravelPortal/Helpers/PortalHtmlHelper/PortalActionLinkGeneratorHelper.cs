using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Web.Mvc.Ajax;

namespace ATLTravelPortal.Helpers.PortalHtmlHelper
{
    public static class PortalActionLinkGeneratorHelper
    {
        public static MvcHtmlString GenerateAlphabeticalActionLink(this AjaxHelper helper,string actionName, string controllerName,string AreaName, AjaxOptions ajaxOptions)
        {
            var sb = new StringBuilder();
            for (int i = 65; i <= 90; i++)
            {
                string charlink=Convert.ToChar(i).ToString();
                sb.Append("<span class=\"pageActiveLink\">");
                sb.Append(helper.ActionLink(charlink, "Index", new { controller = controllerName, Area = AreaName, @id = charlink },ajaxOptions));
                sb.Append("</span>");
            }
            return MvcHtmlString.Create(sb.ToString()); 
        }
    }
}