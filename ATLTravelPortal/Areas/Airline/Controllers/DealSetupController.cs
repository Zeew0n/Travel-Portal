using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;
using System.Text.RegularExpressions;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Delete = "Delete", Edit = "Edit", Order = 2)]
    public class DealSetupController : Controller
    {
        MasterDealProvider mDealProvider = new MasterDealProvider();
        AirLineInformationProvider airlineInfoProvider = new AirLineInformationProvider();

        public ActionResult Index(int? id, string FilterDealIdentifierId, int? FilterAirlineId, int? FilterCurrencyId, string Source)
        {
            var dealtype = mDealProvider.GetDealMasterById(id ?? 0);
            DealViewModel viewmodel = new DealViewModel();

            viewmodel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
            viewmodel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewmodel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();

            if (Source == "5")
            {
                viewmodel.Source = 5;               
                viewmodel.CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Text == "INR");              
                IEnumerable<SelectListItem> dealIdentifierList = mDealProvider.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
                if (dealIdentifierList.Count() > 0)
                {                    
                    dealIdentifierList = dealIdentifierList.Where(z => z.Value == "5");
                }
                viewmodel.DealIdentifierList = dealIdentifierList;
                FilterDealIdentifierId = "A-TBOAIR-DEAL";
                viewmodel.DealList = mDealProvider.GetAllDeals(id, FilterDealIdentifierId, FilterAirlineId, FilterCurrencyId);
            }
            else
            {               
                viewmodel.CurrencyList = mDealProvider.GetCurrencyList();            
                viewmodel.DealIdentifierList = mDealProvider.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0);
                viewmodel.DealList = mDealProvider.GetAllDeals(id, FilterDealIdentifierId, FilterAirlineId, FilterCurrencyId);
            }

            //DealViewModel viewmodel = new DealViewModel()
            //{
            //    AirlineNameList = mDealProvider.GetAllAirlineNameList(),
            //    CurrencyList = mDealProvider.GetCurrencyList(),
            //    DealMasterList = mDealProvider.GetAllDealMasterList(1),
            //    DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
            //    DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
            //    DealIdentifierList = mDealProvider.GetDealIdentifiers(dealtype != null ? dealtype.DealTypeId : 0),
            //    DealList = mDealProvider.GetAllDeals(id, FilterDealIdentifierId, FilterAirlineId, FilterCurrencyId),
            //};

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetailList", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(DealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.Now;
            model.isVerified = false;
            model.isDelete = false;

            mDealProvider.Update_Tkt_Deals(model);

            DealViewModel viewmodel = new DealViewModel()
                        {
                            AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                            CurrencyList = mDealProvider.GetCurrencyList(),
                            DealMasterList = mDealProvider.GetAllDealMasterList(1),
                            DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
                            DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
                            DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId),
                            DealList = mDealProvider.GetAllDeals(model.DealMasterId, null, null, null)
                        };

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("DisplayDealTemplate", viewmodel);
            else
                return View(viewmodel);
        }

        public ActionResult Create(int id, int? FilterDealIdentifierId, string FilterDealIdentifierText, int? FilterAirlineId, int? FilterCurrencyId, string source1)
        {
            var airlineInfo = airlineInfoProvider.GetAirLineInfoById(FilterAirlineId ?? 0);

            DealViewModel viewmodel = new DealViewModel();
            viewmodel.Source = Convert.ToInt32(source1);

            viewmodel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewmodel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
            viewmodel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewmodel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();
            viewmodel.DealMasterId = id;
            viewmodel.DealMaserText = mDealProvider.GetDealMasterById(id).DealName;
            viewmodel.DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0;
            viewmodel.DealIdentifierText = FilterDealIdentifierText;
            viewmodel.CurrencyId = FilterCurrencyId != null ? FilterCurrencyId.Value : 0;
            viewmodel.AirlineId = FilterAirlineId;
            viewmodel.AirlineName = airlineInfo != null ? airlineInfo.AirlineName : "";
            if (source1 == "5")
            {               
                viewmodel.CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Text == "INR");            

                IEnumerable<SelectListItem> dealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(id).DealTypeId);
                if (dealIdentifierList.Count() > 0)
                {
                   
                    dealIdentifierList = dealIdentifierList.Where(z => z.Value == "5");
                }
                viewmodel.DealIdentifierList = dealIdentifierList;
            }
            else
            {               
                viewmodel.CurrencyList = mDealProvider.GetCurrencyList();            
                viewmodel.DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(id).DealTypeId);               
            }

            //DealViewModel viewmodel = new DealViewModel()
            //{
            //    AirlineNameList = mDealProvider.GetAllAirlineNameList(),
            //    CurrencyList = mDealProvider.GetCurrencyList(),
            //    DealMasterList = mDealProvider.GetAllDealMasterList(1),
            //    DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
            //    DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
            //    DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(id).DealTypeId),
            //    DealMasterId = id,
            //    DealMaserText = mDealProvider.GetDealMasterById(id).DealName,
            //    DealIdentifierId = FilterDealIdentifierId != null ? FilterDealIdentifierId.Value : 0,
            //    DealIdentifierText = FilterDealIdentifierText,
            //    CurrencyId = FilterCurrencyId != null ? FilterCurrencyId.Value : 0,
            //    AirlineId = FilterAirlineId,
            //    AirlineName = airlineInfo != null ? airlineInfo.AirlineName : ""
            //};


            if (Request != null && Request.IsAjaxRequest())
                return PartialView("CreateDeal", viewmodel);
            else
                return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(DealViewModel model)
        {
            
            DealViewModel viewmodel = new DealViewModel()
            {
                AirlineNameList = mDealProvider.GetAllAirlineNameList(),
                CurrencyList = mDealProvider.GetCurrencyList(),
                DealMasterList = mDealProvider.GetAllDealMasterList(1),
                DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList(),
                DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList(),
                DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId),
                DealMaserText = mDealProvider.GetDealMasterById(model.DealMasterId).DealName
            };

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.MakerId = obj.AppUserId;
            model.MakerDate = DateTime.UtcNow;
            model.isVerified = true;
            model.VerifiedBy = obj.AppUserId;
            model.VerifiedDate = DateTime.UtcNow;
            model.isDelete = false;

            int dealId = mDealProvider.Save_Tkt_Deals(model);

            DealViewModel viewModel = new DealViewModel();

            viewModel = mDealProvider.GetDealDetail(dealId);

            viewModel.AirlineNameList = mDealProvider.GetAllAirlineNameList();
            viewModel.CurrencyList = mDealProvider.GetCurrencyList();
            viewModel.DealMasterList = mDealProvider.GetAllDealMasterList(1);
            viewModel.DealAppliedOnList = mDealProvider.GetAllDealAppliedOnList();
            viewModel.DealCalculateOnList = mDealProvider.GetAllDealCalculateOnList();
            viewModel.DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId);

            if (model.Source == 5)
            {
                viewModel.CurrencyList = mDealProvider.GetCurrencyList().Where(x => x.Text == "INR");

                IEnumerable<SelectListItem> dealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId);
                if (dealIdentifierList.Count() > 0)
                {

                    dealIdentifierList = dealIdentifierList.Where(z => z.Value == "5");
                }
                viewModel.DealIdentifierList = dealIdentifierList;
            }
            else
            {
                viewModel.CurrencyList = mDealProvider.GetCurrencyList();
                viewModel.DealIdentifierList = mDealProvider.GetDealIdentifiers(mDealProvider.GetDealMasterById(model.DealMasterId).DealTypeId);
            }

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Edit(DealViewModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.UpdatedBy = obj.AppUserId;
            model.UpdatedDate = DateTime.UtcNow;

            mDealProvider.Update_Tkt_Deals(model);

            DealViewModel viewModel = new DealViewModel();
            viewModel = mDealProvider.GetDealDetail(model.DealId);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("VUC_DealDetail", viewModel);
            else
                return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            JsonResult returnJsonData = new JsonResult();
            try
            {
                bool result = false;
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                result = mDealProvider.Delete_Tkt_Deals(id, obj.AppUserId);
                returnJsonData.Data = result;
            }
            catch (Exception ex)
            {
                returnJsonData.Data = "Sorry, unable to delete deal!";
            }
            return returnJsonData;
        }

        private void ValidateMasterDealviewModel(MasterDealviewModel dealmaster)
        {
            bool dealmasterIsNull = dealmaster == null ? true : false;
            const string decimalRegex = @"^\d+(\.\d\d)?$";
            Regex rgx = new Regex(decimalRegex);
            // Validation logic
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.DealName)))
                ModelState.AddModelError("DealName", "DealName  is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty((dealmaster.DealTypeId).ToString())) || (dealmaster.DealTypeId == 0))
                ModelState.AddModelError("DealTypeId", "DealType Name is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.EffectiveFrom.ToString())))
                ModelState.AddModelError("EffectiveFrom", "EffectiveFrom Date is required.");
            if ((dealmasterIsNull) || (string.IsNullOrEmpty(dealmaster.ExpireOn.ToString())))
                ModelState.AddModelError("ExpireOn", "ExpireOn Date is required.");
        }
    }
}
