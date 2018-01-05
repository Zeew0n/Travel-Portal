using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Repository;
using TravelPortalEntity;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Detail", Delete = "Delete", Custom1 = "Comment", Order = 2)]

    public class AgentTeleLogsController : Controller
    {
        //
        // GET: /Administrator/AgentTeleLogs/
        AgentTeleLogsProvider ser = new AgentTeleLogsProvider();
        public ActionResult Index(DateTime? FromDate, DateTime? ToDate,int?page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            AgentTeleLogsModel model = new AgentTeleLogsModel();

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


            model.AgentTeleLogsList = ser.ListAgentTeleLogs(model.FromDate, model.ToDate);
            model.AgentTeleLogsFollowupList = ser.ListFollowupAgentTeleLogs().ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgentTeleLogsModel model,int?page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 100;
            if (model.FromDate != null)
                model.FromDate = model.FromDate.Value.Date;

            if (model.ToDate != null)
                model.ToDate = model.ToDate.Value.Date.AddHours(23).AddMinutes(59);

            model.AgentTeleLogsList = ser.ListAgentTeleLogs(model.FromDate, model.ToDate);
            model.AgentTeleLogsFollowupList = ser.ListFollowupAgentTeleLogs().ToPagedList(currentPageIndex, defaultPageSize);

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AgentTeleLogsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;
            try
            {
                ser.CreateAgentTeleLogs(model);
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
            AgentTeleLogsModel model = new AgentTeleLogsModel();
            List<Core_AgentTeleLogComments> commentmodel = ser.GeCommentByID(Id);
            model.AgentTeleLogId = Id;
            model = ser.DetailAgentTeleLogs(Id);
          
            try
            {
                foreach (var item in commentmodel)
                {
                    model.commentid = (int)item.AgentTeleLogCommentId;
                }
            }
            catch
            {
            }
            model.CommentList = ser.GetAgentTeleLogsList(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, AgentTeleLogsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.AgentTeleLogId = Id;

            model.CreatedBy = obj.AppUserId;

            int agentid = ser.GetAgentId(model.AgentName);
            model.AgentId = agentid;
            try
            {
                ser.EditAgentTeleLogs(model);
            }
            catch
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                ser.DeleteAgentTeleLogs(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Detail(int id)
        {
            AgentTeleLogsModel model = new AgentTeleLogsModel();
            model = ser.DetailAgentTeleLogs(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Comment(int id, AgentTeleLogsModel model)
        {

            TravelSession ts = (ATLTravelPortal.Helpers.TravelSession)Session["TravelPortalSessionInfo"];

            model.AgentTeleLogId = id;
            model.CreatedBy = ts.AppUserId;
            try
            {
                ser.CommentsAdd(model);
            }
            catch
            {
            }

            return RedirectToAction("Edit", new { @id = id });
        }



    }
}
