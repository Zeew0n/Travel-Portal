using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers.Pagination;
using System.Text;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Detail", Delete = "Delete", Custom1 = "Comment", Order = 2)]

    public class AgentCallLogController : Controller
    {
        //
        // GET: /Administrator/AgentCallLog/

        AgentCallLogProvider ser = new AgentCallLogProvider();
        public ActionResult Index(int? page, DateTime? FromDate, DateTime? ToDate)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            AgentCallLogModel model = new AgentCallLogModel();

            if (FromDate == null && ToDate == null)
            {
                model.FromDate = GeneralRepository.CurrentDateTime().Date;
                model.ToDate = GeneralRepository.CurrentDateTime().Date.AddHours(23).AddMinutes(59);
            }
            else
            {
                model.FromDate = FromDate;
                model.ToDate = ToDate;
            }


            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;

            model.AgentCallLogList = ser.ListPhoneCallLogs(model.FromDate, model.ToDate);
            model.AgentFollowUpCallLogList = ser.ListFollowUpPhoneCallLogs().ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentCallLogModel model, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 100;

            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");
           

            if (model.FromDate != null)
                model.FromDate = model.FromDate.Value.Date;

            if (model.ToDate != null)
                model.ToDate = model.ToDate.Value.Date.AddHours(23).AddMinutes(59);

            model.AgentCallLogList = ser.ListPhoneCallLogs(model.FromDate, model.ToDate);
            model.AgentFollowUpCallLogList = ser.ListFollowUpPhoneCallLogs().ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }

        public ActionResult Create()
        {
            AgentCallLogModel model = new AgentCallLogModel();
            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AgentCallLogModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.LoggedBy = obj.AppUserId;
            string[] callduration = new string[2];
            callduration = model.Duration.Split(':');
            model.CallDuration = 0;
            //if (!string.IsNullOrEmpty(callduration[0]))
            //{
            //    model.CallDuration += Convert.ToDouble(callduration[0]) * 60;
            //}
            if (!string.IsNullOrEmpty(callduration[0]))
            {
                model.CallDuration += Convert.ToDouble(callduration[0]);
            }
            if (!string.IsNullOrEmpty(callduration[1]))
            {
                model.CallDuration += Convert.ToDouble(callduration[1]) / 60;
            }
            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");
            try
            {
                ser.CreatePhoneCallLogs(model);
            }
            catch
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            AgentCallLogModel model = new AgentCallLogModel();
            List<Core_PhoneCallLogComments> commentmodel = ser.GeCommentByID(Id);


            model = ser.DetailPhoneCallLogs(Id);
            double callduration = 0;
            callduration = model.CallDuration;
            string callDt = ProcessCallDuration(callduration);

            model.Duration = callDt;

            model.PhoneCallLogId = Id;

            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");


            try
            {
                foreach (var item in commentmodel)
                {
                    model.commentid = (int)item.PhoneCallLogCommentId;
                }
            }
            catch
            {
            }
            model.CommentList = ser.GetGroupBookingCommtList(Id);

            return View(model);
        }

        private string ProcessCallDuration(double duration)
        {
            TimeSpan ts = new TimeSpan((long)(duration * 60 * Math.Pow(10, 7)));
            return ( ts.Minutes.ToString().PadLeft(2, '0') + ":" + ts.Seconds.ToString().PadLeft(2, '0'));
        }

        [HttpPost]
        public ActionResult Edit(int Id, AgentCallLogModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");

            model.PhoneCallLogId = Id;

            model.LoggedBy = obj.AppUserId;

            int agentid = ser.GetAgentId(model.AgentName);
            model.AgentId = agentid;

            string[] callduration = new string[2];
            callduration = model.Duration.Split(':');
            model.CallDuration = 0;
            //if (!string.IsNullOrEmpty(callduration[0]))
            //{
            //    model.CallDuration += Convert.ToDouble(callduration[0]) * 60;
            //}
            if (!string.IsNullOrEmpty(callduration[0]))
            {
                model.CallDuration += Convert.ToDouble(callduration[0]);
            }
            if (!string.IsNullOrEmpty(callduration[1]))
            {
                model.CallDuration += Convert.ToDouble(callduration[1]) / 60;
            }

            try
            {

                ser.EditPhoneCallLogs(model);


            }
            catch
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ser.DeletePhoneCallLogs(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            AgentCallLogModel model = new AgentCallLogModel();


            model = ser.DetailPhoneCallLogs(id);
            double callduration = 0;
            callduration = model.CallDuration;
            string callDt = ProcessCallDuration(callduration);

            model.Duration = callDt;

            model.PhoneCallLogId = id;

            model.For_ProductList = new SelectList(ser.GetProductType(), "ProductId", "ProductName");
            model.On_ServiceProviderList = new SelectList(ser.GetServiceProviderType(), "ServiceProviderId", "ServiceProviderName");


            return View(model);
        }

        [HttpPost]
        public ActionResult Comment(int id, AgentCallLogModel model)
        {

            TravelSession ts = (ATLTravelPortal.Helpers.TravelSession)Session["TravelPortalSessionInfo"];

            model.PhoneCallLogId = id;
            model.CreatedBy = ts.AppUserId;

            ser.CommentsAdd(model);

            return RedirectToAction("Edit", new { @id = id });
        }
    }
}
