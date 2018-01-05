using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class PromotionalFareSetupController : Controller
    {
        public ActionResult Index()
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            return View(promotionalFareSetupProvider.GetPromotionalFareListModel());
        }

        [HttpGet]
        public ActionResult Create()
        {

            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            PromotionalFareModel model = new PromotionalFareModel();
            try
            {
                model = promotionalFareSetupProvider.GetPromotionalFareSetupCreateModel();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(PromotionalFareModel model)
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            PromotionalFareModel viewModel = new PromotionalFareModel();
            GeneralProvider generalProvider = new GeneralProvider();
            try
            {
                foreach (var item in model.PromotionalFareSector.PromotionalFareSegment)
                {
                    item.FromCityList = generalProvider.GetAirlineCityList(); ;
                    item.ToCityList = generalProvider.GetAirlineCityList(); ;
                }
                viewModel = promotionalFareSetupProvider.GetPromotionalFareSetupCreateModel();
                viewModel.PromotionalFareSector.Taxes = model.PromotionalFareSector.Taxes;
                viewModel.PromotionalFareSector.PromotionalFareSegment = model.PromotionalFareSector.PromotionalFareSegment;

                promotionalFareSetupProvider.SavePromotionalFare(model);
                TempData["SuccessMessage"] = "Saved Successfully.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            try
            {
                return View(promotionalFareSetupProvider.GetPromotionalFareSetupEditModel(id));
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(promotionalFareSetupProvider.GetPromotionalFareSetupEditModel(id));
            }
        }

        [HttpPost]
        public ActionResult Edit(PromotionalFareModel model)
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            PromotionalFareModel viewModel = new PromotionalFareModel();
            try
            {  
                promotionalFareSetupProvider.EditPromotionalFare(model);
                viewModel = promotionalFareSetupProvider.GetPromotionalFareSetupEditModel(model.PromotionalFareSector.PromotionalFareId);

               // viewModel.PromotionalFareSector.Taxes = model.PromotionalFareSector.Taxes;
               // viewModel.PromotionalFareSector.PromotionalFareSegment = model.PromotionalFareSector.PromotionalFareSegment;             


                TempData["SuccessMessage"] = "Edited Successfully.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            try
            {
                return View(promotionalFareSetupProvider.GetPromotionalFareSetupEditModel(id));
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(promotionalFareSetupProvider.GetPromotionalFareSetupEditModel(id));
            }
        }
        public ActionResult Delete(Int64 id)
        {
            PromotionalFareSetupProvider promotionalFareSetupProvider = new PromotionalFareSetupProvider();
            try
            {
                promotionalFareSetupProvider.Delete(id);
                TempData["SuccessMessage"] = "Deleted Successfully.";
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
