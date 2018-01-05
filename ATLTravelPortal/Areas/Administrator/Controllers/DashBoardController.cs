#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using ATLTravelPortal.Areas.Administrator.Repository;
using Libero.FusionCharts;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    //[CheckSessionFilter]
    //--JEEWAN comment gareko--[PermissionDetails(View = "Dashboard", Details = "SearchUser")]
    public class DashboardController : Controller//ZeroController
    {


        //

        // GET: /Dashboard/
        DashboardProvider _prov = new DashboardProvider();


        //--JEEWAN comment gareko--[Authorize]

        public ActionResult Index()
        {

            GetUserChart();
            return View();
        }

        private void GetUserChart()
        {
            var model = _prov.GetDashboardData();

            Libero.FusionCharts.Column2DChart bar = new Column2DChart();

            bar.Background.BgColor = "ffffff";
            bar.ChartTitles.Caption = "User/Agent";

            bar.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            //bar.Animation.Animation = false;
            DataTable dtUserchart = new DataTable();

            dtUserchart.Columns.Add("Date");
            dtUserchart.Columns.Add("Value");

            foreach (var item in model)
            {
                dtUserchart.Rows.Add(new object[] { "Agent", item.TotalAgent });
                dtUserchart.Rows.Add(new object[] { "User", item.TotalUser });
                dtUserchart.Rows.Add(new object[] { "Online", Membership.GetNumberOfUsersOnline() });
                dtUserchart.Rows.Add(new object[] { "Locked", item.LockedUser });
                dtUserchart.Rows.Add(new object[] { "Pending", item.UnapprovedUser });
            }

            bar.DataSource = dtUserchart;
            bar.DataTextField = "Date";
            bar.DataValueField = "Value";
            ViewData["UserChart"] = bar;
        }
    }
}
