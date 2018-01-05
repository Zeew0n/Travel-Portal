using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class VoidCancellationRequestRuleController : Controller
    {
        VoidCancellationRequestRuleRepository VoidCancellationRequestRuleRepository = new VoidCancellationRequestRuleRepository();

        EntityModel entity = new EntityModel();
        public ActionResult Index()
        {
            VoidCancellationRequestRuleModel model = new VoidCancellationRequestRuleModel();

            model.VoidCancellationRequestList = VoidCancellationRequestRuleRepository.GetVoidCancellationRequestList();
            return View(model);

        }

        public ActionResult Create()
        {
            VoidCancellationRequestRuleModel model = new VoidCancellationRequestRuleModel();
            model.ProductOption = VoidCancellationRequestRuleRepository.GetProducts();
            model.RuleOnOption = VoidCancellationRequestRuleRepository.GetRuleOn();
            return View(model);

        }

        [HttpPost]
        public ActionResult Create(VoidCancellationRequestRuleModel model)
        {

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = ts.AppUserId;
            model.CreatedDate = DateTime.Now;

            //var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
            if (VoidCancellationRequestRuleRepository.Check(model.ProductId))
            {

                VoidCancellationRequestRuleRepository.SaveToVoidCancellationRequest(model);

            }
            else
            {
                TempData["ActionResponse"] = "This record already exists.";
                model.ProductOption = VoidCancellationRequestRuleRepository.GetProducts();
                model.RuleOnOption = VoidCancellationRequestRuleRepository.GetRuleOn();
                return View(model);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {

            VoidCancellationRequestRuleModel model = new VoidCancellationRequestRuleModel();

            model = VoidCancellationRequestRuleRepository.GetEdit(id);
            model.ProductOption = VoidCancellationRequestRuleRepository.GetProducts();
            model.RuleOnOption = VoidCancellationRequestRuleRepository.GetRuleOn();
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(VoidCancellationRequestRuleModel model)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = ts.AppUserId;
            model.CreatedDate = DateTime.Now;
            if (VoidCancellationRequestRuleRepository.CheckforEdit(model))
            {
                VoidCancellationRequestRuleRepository.SaveEdit(model);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ActionResponse"] = "You can't edit this record as it is already exists.";
                model.ProductOption = VoidCancellationRequestRuleRepository.GetProducts();
                model.RuleOnOption = VoidCancellationRequestRuleRepository.GetRuleOn();
                return View(model);
            }
        }



        public ActionResult Delete(int id)
        {
            if (VoidCancellationRequestRuleRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ActionResponse"] = "Sorry, some error occurred while deleting.";
                return RedirectToAction("Index");
            }
        }
    }
}
