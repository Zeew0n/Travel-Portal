using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Details = "Preview", Order = 2)]
    public class ContentsController : Controller
    {
        //
        // GET: /Administrator/Contents/
        ContentsProvider ser = new ContentsProvider();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            ContentsModel model = new ContentsModel();
            model.ListContents = ser.GetContentsList().ToPagedList(currentPageIndex,defaultPageSize);
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult Create()
        {
            ContentsModel model = new ContentsModel();
            model.DomainName = UrlHelperExtensions.AbsolutePath(HttpContext.Request.Url.OriginalString); 
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ContentsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;
            model.DomainName = UrlHelperExtensions.AbsolutePath(HttpContext.Request.Url.OriginalString); 

            try
            {
                ser.CreateContents(model);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ContentsModel model = new ContentsModel();

            model.ContentId = Id;
            model = ser.GetContentsDetail(Id);

            return View(model);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, ContentsModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.ContentId = Id;
            model.UpdatedBy = obj.AppUserId;

                try
                {
                    ser.EditContents(model);

                }
                catch
                {
                    return View(model);
                }
             
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Preview(int Id)
        {
            ContentsModel model = new ContentsModel();

            model.ContentId = Id;
            model = ser.GetPreview(Id);

            return View(model);
        }
         
        public ActionResult Delete(int Id)
        {
            try
            {
                ser.Delete(Id);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }



    }
}
