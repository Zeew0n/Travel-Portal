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

using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using Libero.FusionCharts;
using System;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;
using TravelPortalEntity;

//using AirLines.RoleManagement;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    //Jeewan le comment gareko[CheckSessionFilter(Order = 1)]
    public class DashboardController : Controller//ZeroController
    {


        //

        // GET: /Dashboard/
        DashboardProvider _prov = new DashboardProvider();
        // AgentMarkupProvider _markuprepo = new AgentMarkupProvider()

        //   [AutoRefresh(ControllerName = "Dashboard", ActionName = "Index", DurationInSeconds = 60)]
        [HttpGet]
        public ActionResult Index(int? pageNo, int? flag)
        {
            DashboardModel model = new DashboardModel();
            if (Session["DBFromDate"] == null)
            {
                model.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                Session["DBFromDate"] = model.FromDate;
            }
            else
                model.FromDate = (DateTime)Session["DBFromDate"];
            if (Session["DBToDate"] == null)
            {
                model.ToDate = DateTime.Now;
                Session["DBToDate"] = model.ToDate;
            }
            else
                model.ToDate = (DateTime)Session["DBToDate"];

            //GetUserChart();
            TicketStatus();
            SalesReport();
            SegmentSales();
            TTLChart();
            CappingChart();
            return View(model);

        }

        [HttpPost]
        public ActionResult Index(int? pageNo, int? flag, DashboardModel model)
        {
            Session["DBFromDate"] = model.FromDate;
            Session["DBToDate"] = model.ToDate;

            // GetUserChart();
            TicketStatus();
            SalesReport();
            SegmentSales();
            TTLChart();
            CappingChart();
            return View(model);
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
        EntityModel ent = new EntityModel();
        private void TicketStatus()
        {
            DateTime fromdate = (DateTime)Session["DBFromDate"];
            DateTime toDate = (DateTime)Session["DBToDate"];
            var da = ent.Air_DB_GetTicketStatus(fromdate, toDate, null);

            Libero.FusionCharts.Pie3DChart pie = new Pie3DChart();

            // Set properties
            pie.Background.BgColor = "ffffff";
            pie.ChartTitles.Caption = "Ticket Status";
            pie.ChartTitles.SubCaption = fromdate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]) + " - " + toDate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]);
            pie.PiePropertySet.PieSliceDepth = 15;
            //pie.PieVisibility.Animation = false;

            // Set a template
            pie.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            pie.GenericVisibility.ShowNames = true;


            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Count");

            foreach (var item in da)
            {
                dt.Rows.Add(new object[] { item.ticketStatusName, item.Count });
            }
            pie.DataSource = dt;
            pie.DataTextField = "Name";
            pie.DataValueField = "Count";
            pie.DataBind();
            ViewData["TicketStatusChart"] = pie;
        }

        private void TTLChart()
        {
            var da = ent.Air_DB_GetTTL(null);
            Libero.FusionCharts.Pie3DChart pie = new Pie3DChart();

            // Set properties
            pie.Background.BgColor = "ffffff";
            pie.ChartTitles.Caption = "TTL Status";
            pie.PiePropertySet.PieSliceDepth = 15;
            //pie.PieVisibility.Animation = false;
            pie.NumberFormat.DecimalPrecision = 0;
            // Set a template
            pie.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            pie.GenericVisibility.ShowNames = true;


            DataTable dt = new DataTable();
            dt.Columns.Add("RemainDays");
            dt.Columns.Add("Count");


            foreach (var item in da)
            {
                dt.Rows.Add(new object[] { item.RemainDays + " Days", item.Count, });
            }
            pie.DataSource = dt;
            pie.DataTextField = "RemainDays";
            pie.DataValueField = "Count";
            pie.DataBind();


            ViewData["TTLChart"] = pie;
        }
        private void SalesReport()
        {
            var obj = (TravelSession)Session["TravelPortalSessionInfo"];

            DateTime fromdate = (DateTime)Session["DBFromDate"];
            DateTime toDate = (DateTime)Session["DBToDate"];
            var da = ent.Air_DB_GetSales(fromdate, toDate, null);

            Libero.FusionCharts.LineChart chart = new LineChart();

            // Set properties
            chart.Background.BgColor = "ffffff";
            chart.Background.BgAlpha = 50;
            chart.ChartTitles.Caption = "Sales Status";
            chart.ChartTitles.SubCaption = fromdate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]) + " - " + toDate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]);

            // Set a template
            chart.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            //chart.PiePropertySet.PieSliceDepth = 15;
            chart.LinePropertySet.LineColor = "Blue";

            // chart.GenericVisibility.ShowNames = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("AirlineCode");
            dt.Columns.Add("Amount");

            foreach (var item in da)
            {
                dt.Rows.Add(new object[] { item.AirlineCode, item.Amount });
            }
            chart.DataSource = dt;
            chart.DataTextField = "AirlineCode";
            chart.DataValueField = "Amount";

            ViewData["SalesChart"] = chart;
        }
        private void SegmentSales()
        {
            DateTime fromdate = (DateTime)Session["DBFromDate"];
            DateTime toDate = (DateTime)Session["DBToDate"];

            var obj = (TravelSession)Session["TravelPortalSessionInfo"];

            var segmentsalesObj = ent.Air_DB_GetSegmentSales(fromdate, toDate, null);
            Libero.FusionCharts.Column2DChart bar = new Column2DChart();

            bar.Background.BgColor = "ffffff";
            bar.ChartTitles.Caption = "Segment Count";
            bar.ChartTitles.SubCaption = fromdate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]) + " - " + toDate.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]);

            bar.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            //bar.Animation.Animation = false;
            bar.BarsVisibility.RotateNames = true;

            DataTable dtSegmentSales = new DataTable();
            dtSegmentSales.Columns.Add("Segment");
            dtSegmentSales.Columns.Add("Count");

            foreach (var item in segmentsalesObj)
            {
                dtSegmentSales.Rows.Add(new object[] { item.Segment, item.Count });
            }

            bar.DataSource = dtSegmentSales;
            bar.DataTextField = "Segment";
            bar.DataValueField = "Count";
            ViewData["SegmentChart"] = bar;
        }
        private void CappingChart()
        {
            var da = ent.Air_Dash_GetCappingInfo();
            Libero.FusionCharts.Column2DChart chart = new Column2DChart();

            chart.Background.BgColor = "ffffff";
            chart.ChartTitles.Caption = "Capping Status";
            chart.NumberFormat.DecimalPrecision = 0;
            chart.Template = new Libero.FusionCharts.Template.OfficeDarkTemplate();
            chart.BarsVisibility.RotateNames = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("AirlineCode");
            dt.Columns.Add("TotalNumberOfCAP");

            foreach (var item in da)
            {
                dt.Rows.Add(new object[] { item.AirlineCode, item.TotalNumberOfCAP, });
            }
            chart.DataSource = dt;
            chart.DataTextField = "AirlineCode";
            chart.DataValueField = "TotalNumberOfCAP";
            ViewData["CappingChart"] = chart;

        }
    }
}
