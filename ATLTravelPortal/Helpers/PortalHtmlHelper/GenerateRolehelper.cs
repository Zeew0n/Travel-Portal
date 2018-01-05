using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace ATLTravelPortal.Helpers.PortalHtmlHelper
{
    public static class GenerateRolehelper
    {
        public static MvcHtmlString GenerateUserRoleList(this HtmlHelper helper, Guid UserId)
        {
            ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository pro = new ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository();
            ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser m = new ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser();
            m.GetUserRolesList.AddRange(pro.ListGetUserRoles(UserId));
            var sb = new StringBuilder();
            sb.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            foreach (var roles in m.GetUserRolesList)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + roles.RolesName + "</td>");
                sb.Append("<td>" + roles.RolesOn + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}