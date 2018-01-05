using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Details = "Detail", Order = 2)]
    public class DashboardContentController : Controller
    {
        DashboardContentProvider ser = new DashboardContentProvider();
        public ActionResult Index()
        {
            DashboardContentsModel model = new DashboardContentsModel();
            try
            {
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                model.ListDashboardContents = ser.GetDashBoardContentsList();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [ValidateInput(false)]
        public ActionResult Create()
        {
            DashboardContentsModel model = new DashboardContentsModel();
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DashboardContentsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;
            try
            {
                int Id = ser.CreateDashBoardContents(model);
                model = ser.GetDashboardContentsDetail(Id);
                if (model.IsPublished == true)
                {
                    model.IsPublished = false;
                    ser.UpdateIsPublished(Id, model);
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            DashboardContentsModel model = new DashboardContentsModel();
            model.DasbBoardContentId = Id;
            model = ser.GetDashboardContentsDetail(Id);
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, DashboardContentsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.DasbBoardContentId = Id;
            model.UpdatedBy = obj.AppUserId;
            try
            {
                if (model.IsPublished == true)
                {
                    model.IsPublished = false;
                    ser.UpdateIsPublished(Id, model);
                    model.IsPublished = true;
                    ser.EditDashBoardContents(model);
                }
                else
                {
                    ser.EditDashBoardContents(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            DashboardContentsModel model = new DashboardContentsModel();
            model.DasbBoardContentId = Id;
            model = ser.GetCMSContent(Id);
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                ser.Delete(Id);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
