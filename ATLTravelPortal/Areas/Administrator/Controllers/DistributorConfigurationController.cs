using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using System.Transactions;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    public class DistributorConfigurationController : Controller
    {
        DistributorConfigurationProvider distributorConfigurationProvider = new DistributorConfigurationProvider();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 3;
            DistributorConfigurationModel model = new DistributorConfigurationModel();
           
            
            model.DistributorConfigurationList = distributorConfigurationProvider.GetDistributorConfigurationContentsList().ToPagedList(currentPageIndex, defaultPageSize);
            
            return View(model);
        }

        public ActionResult Create()
        {
            DistributorConfigurationModel model = new DistributorConfigurationModel();
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DistributorConfigurationModel model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                    if (model.IsPublished)

                        distributorConfigurationProvider.UpdateIsPublished(model.DistributorID);
                    distributorConfigurationProvider.SaveCreateDistributorConfigurationContents(model);
                    ts.Complete();
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
            DistributorConfigurationModel model = new DistributorConfigurationModel();
            model = distributorConfigurationProvider.GetDistributorConfigurationEdit(Id);
            return View(model);

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(DistributorConfigurationModel model)
        {
            try
            {
                 var x = SessionStore.GetTravelSession();
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (model.IsPublished)

                       
                        distributorConfigurationProvider.UpdateIsPublished(x.LoginTypeId);
                         distributorConfigurationProvider.SaveEditDistributorConfigurationContents(model);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                distributorConfigurationProvider.Delete(Id);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index");
        }


        public FileContentResult GetImage(int id)
        {
            EntityModel entity = new EntityModel();

            LayoutSetting ToEdit = (from p in entity.LayoutSetting
                                    where p.LayoutSettingId == id
                                    select p).First();

            return File(ToEdit.Logo, ToEdit.ImageType);
        }

    }
}
