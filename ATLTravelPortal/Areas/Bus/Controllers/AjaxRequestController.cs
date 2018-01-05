using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Repository;
using System.Web.Script.Serialization;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Bus.Controllers
{
    public class AjaxRequestController : Controller
    {
        public JsonResult GetCategoryByMasterId(int? id)
        {
            BusScheduleRepository busschedulerepository = new BusScheduleRepository();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(busschedulerepository.GetAllCategoryByMasterId(id ?? 0), "BusCategoryId", "BusCategoryName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        [HttpPost]
        public JsonResult BusStationList(string searchText, int maxResult)
        {
            BusScheduleRepository busschedulerepository = new BusScheduleRepository();
            var result = new JsonResult();

            var p = busschedulerepository.GetAllBusCities(searchText, maxResult).Select(n => new { Id = n.BusCityId, Name = n.BusCityName, Code = n.BusCityCode });

            var data = p;
            result.Data = data;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult AjaxDistributorDealDetail(int id, string source)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetBusDistributorDealDetail(id);
            viewModel.BusOperatorList = mDealProvider.GetAllBusOperatorList();
            viewModel.BusCategoryList = mDealProvider.GetAllBusCategoryList(id);

            viewModel.DealMasterList = mDealProvider.GetAllDistributorDealMasterList(4, obj.LoginTypeId);
            viewModel.CurrencyList = mDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxBranchDealDetail(int id, string source)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetBusBranchDealDetail(id);
            viewModel.BusOperatorList = mDealProvider.GetAllBusOperatorList();
            viewModel.BusCategoryList = mDealProvider.GetAllBusCategoryList(id);

            viewModel.DealMasterList = mDealProvider.GetAllBranchDealMasterList(4, obj.LoginTypeId);
            viewModel.CurrencyList = mDealProvider.GetCurrencyList();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDistributorDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetBusDistributorDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DistributorDealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxBranchDealCancel(int id)
        {
            BranchDealViewModel viewModel = new BranchDealViewModel();
            BranchDealProvider mDealProvider = new BranchDealProvider();
            viewModel = mDealProvider.GetBusBranchDealDetail(id);
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_BranchDealDetail", viewModel);
            else
                return View(viewModel);
        }
        ///////////////////////////Deal Setup Action Starts Here/////////////////////////////
        public ActionResult AjaxDealDetail(int id, string source)
        {
            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider masDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();
            BranchDealProvider mbDealProvider = new BranchDealProvider();

            DealViewModel viewModel = new DealViewModel();

            viewModel = masDealProvider.GetBusDealDetail(id);

            viewModel.DealMasterList = masDealProvider.GetAllDealMasterList(4);
            viewModel.DealAppliedOnList = masDealProvider.GetAllDealAppliedOnList();
            viewModel.DealCalculateOnList = masDealProvider.GetAllDealCalculateOnList();

            viewModel.BusOperatorList = mbDealProvider.GetAllBusOperatorList();
            viewModel.BusCategoryList = mbDealProvider.GetAllBusCategoryList(viewModel.BusOperatorId ?? 0);

            viewModel.CurrencyList = masDealProvider.GetCurrencyList().Where(x => x.Value == "1");
            viewModel.DealIdentifierList = masDealProvider.GetBusDealIdentifiers(masDealProvider.GetDealMasterById(viewModel.DealMasterId).DealTypeId);


            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealEdit", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult AjaxDealCancel(int id)
        {
            ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider masDealProvider = new ATLTravelPortal.Areas.Airline.Repository.MasterDealProvider();
            DealViewModel viewModel = new DealViewModel();
            viewModel = masDealProvider.GetBusDealDetail(id);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public JsonResult GetCategoryByOperatorId(int? id)
        {
            BranchDealProvider branchdealprovider = new BranchDealProvider();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(branchdealprovider.GetAllBusCategoryList(id ?? 0), "Value", "Text");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        
    }
}
