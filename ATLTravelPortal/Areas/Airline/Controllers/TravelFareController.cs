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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details", Delete = "Delete", Order = 2)]
    public class TravelFareController : Controller
    {

        TravelFareProvider _tfareprovider = new TravelFareProvider();
        EntityModel ent = new EntityModel();
        GeneralProvider _provider = new GeneralProvider();
        CustomValidationClass valsvc;
        public TravelFareController()
        {
            valsvc = new CustomValidationClass(this.ModelState);
        }

        //
        // GET: /TravelFare/Create
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create()
        {
            SetValueForDropdownlist();
            DefaultPaperFareRules defaultPaperFairRule = new DefaultPaperFareRules();
            defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();

            PaperFareRules rule = new PaperFareRules();
            TravelFareModel model = new TravelFareModel();

            model.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
            model.ChildFareType = defaultPaperFairRule.ChildFareType;
            model.ChildFareOn = defaultPaperFairRule.ChildFareOn;
            model.ChildFare = defaultPaperFairRule.ChildFare;
            model.InfantFare = defaultPaperFairRule.InfantFare;
            model.InfantFareOn = defaultPaperFairRule.InfantFareOn;
            model.InfantFareType = defaultPaperFairRule.InfantFareType;
            TempData["Error"] = " ";
            return View(model);
        }



        [HttpPost, ValidateInput(false)]
        public ActionResult Create(TravelFareModel model, FormCollection collection)
        {
            DefaultPaperFareRules defaultPaperFairRule = new DefaultPaperFareRules();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
            SetValueForDropdownlist();
            bool checkPaperFare = true;

          

            if (model.DepartureCityId == model.DestinationCityId)
            {
                ModelState.AddModelError("City", "Please Review the Cities");
                TempData["City"] = "please Review the cities";
            }
            if (model.ExpireOn == null)
            {
                checkPaperFare = _tfareprovider.IfPaperFareExist(model.AirlineId, model.FlightClassId, model.EffectiveFrom, model.DepartureCityId, model.DepartureCityId);
            }
            else
            {
                checkPaperFare = _tfareprovider.CheckPaperFareExist(model.AirlineId, model.FlightClassId, model.EffectiveFrom, Convert.ToDateTime(model.ExpireOn), model.DepartureCityId, model.DestinationCityId);
            }

            bool checkClassName = _tfareprovider.CheckClassNameExist(model.AirlineId, model.FlightClassId, model.DepartureCityId, model.DestinationCityId);

            if (checkPaperFare == false )
            {
                TempData["Error"] = "Fare  already exists";
                ModelState.AddModelError("Fare", "Unable to Save the values");
            }
            else if (checkClassName == true)
            {
                SetValueForDropdownlist();
                PaperFareRules _obj = new PaperFareRules();
                _obj.AirlineId = model.AirlineId;
                _obj.FlightSeasonId = model.FlightSeasonId;
                _obj.DepartureCityId = model.DepartureCityId;
                _obj.DestinationCityId = model.DestinationCityId;
                _obj.FlightClassId = model.FlightClassId;
                //_obj.OneWayFareBasis = "sda";//
                _obj.OneWayFareBasis = model.OneWayFareBasis;
                _obj.OneWayFare = model.OneWayFare;
                _obj.RoundWayGoing = model.GoingFare;
                //_obj.RoundWayFareBasis = "sad"; //model.RoundWayFareBasis;
                _obj.RoundWayFareBasis = model.RoundWayFareBasis;
                _obj.RoundWayFare = model.TotalRoundTripFare;
                _obj.RoundWayReturn = model.RoundWayFare;
                _obj.EffectiveFrom = model.EffectiveFrom;
                _obj.ExpireOn = model.ExpireOn;
                _obj.FlightTypeId = model.FlightTypeId;
                _obj.ChildFare = model.ChildFare;
                _obj.ChildFareUSD = model.ChildFareUSD;
                _obj.ChildFareType = model.ChildFareType;
                _obj.ChildFareOn = model.ChildFareOn;
                _obj.InfantFare = model.InfantFare;
                _obj.InfantFareUSD = model.InfantFareUSD;
                _obj.InfantFareType = model.InfantFareType;
                _obj.InfantFareOn = model.InfantFareOn;
                _obj.RefundFee = model.RefundFee;
                _obj.RefundFeeUSD = model.RefundFeeDollar;
                _obj.ReissueFee = model.ReissueFee;
                _obj.ReissueFeeUSD = model.ReissueFeeDollar;
                _obj.TourCode = model.TourCode;
                _obj.FC = model.FuelCharge;
                _obj.ValidUntilNextNotic = model.ValidTillFurtherNotice;
                _obj.RoundWayGoingUSD = model.RoundWayGoingUSD;
                _obj.OneWayFareUSD = model.OneWayFareUSD;
                _obj.RoundWayReturnUSD = model.RoundWayReturnUSD;
                _obj.RoundWayFareUSD = model.RoundWayFareUSD;
                _obj.TermsAndConditions = collection["Information"];
                _tfareprovider.SavePaperFareRule(_obj);
                return RedirectToAction("Index");

            }

            //else
            //{

            //    if (ModelState.IsValid)
            //    {

            //        SetValueForDropdownlist();
            //        PaperFareRules _obj = new PaperFareRules();
            //        _obj.AirlineId = model.AirlineId;
            //        _obj.FlightSeasonId = model.FlightSeasonId;
            //        _obj.DepartureCityId = model.DepartureCityId;
            //        _obj.DestinationCityId = model.DestinationCityId;
            //        _obj.FlightClassId = model.FlightClassId;
            //        //_obj.OneWayFareBasis = "sda";//
            //        _obj.OneWayFareBasis = model.OneWayFareBasis;
            //        _obj.OneWayFare = model.OneWayFare;
            //        _obj.RoundWayGoing = model.GoingFare;
            //        //_obj.RoundWayFareBasis = "sad"; //model.RoundWayFareBasis;
            //        _obj.RoundWayFareBasis = model.RoundWayFareBasis;
            //        _obj.RoundWayFare = model.TotalRoundTripFare;
            //        _obj.RoundWayReturn = model.RoundWayFare;
            //        _obj.EffectiveFrom = model.EffectiveFrom;
            //        _obj.ExpireOn = model.ExpireOn;
            //        _obj.FlightTypeId = model.FlightTypeId;
            //        _obj.ChildFare = model.ChildFare;
            //        _obj.ChildFareUSD = model.ChildFareUSD;
            //        _obj.ChildFareType = model.ChildFareType;
            //        _obj.ChildFareOn = model.ChildFareOn;
            //        _obj.InfantFare = model.InfantFare;
            //        _obj.InfantFareUSD = model.InfantFareUSD;
            //        _obj.InfantFareType = model.InfantFareType;
            //        _obj.InfantFareOn = model.InfantFareOn;
            //        _obj.RefundFee = model.RefundFee;
            //        _obj.RefundFeeUSD = model.RefundFeeDollar;
            //        _obj.ReissueFee = model.ReissueFee;
            //        _obj.ReissueFeeUSD = model.ReissueFeeDollar;
            //        _obj.TourCode = model.TourCode;
            //        _obj.FC = model.FuelCharge;
            //        _obj.ValidUntilNextNotic = model.ValidTillFurtherNotice;
            //        _obj.RoundWayGoingUSD = model.RoundWayGoingUSD;
            //        _obj.OneWayFareUSD = model.OneWayFareUSD;
            //        _obj.RoundWayReturnUSD = model.RoundWayReturnUSD;
            //        _obj.RoundWayFareUSD = model.RoundWayFareUSD;
            //        _obj.TermsAndConditions = collection["Information"];
            //        _tfareprovider.SavePaperFareRule(_obj);
            //        return RedirectToAction("Index");
            //    }

                else
                {
                    TempData["classname"] = "Class Name  already exists";

                    defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();
                    model.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
                  
                    return View(model);
                }

           // }
            defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();
            model.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
            return View(model);
        }

        public ActionResult Index(int? AirlineType)
        {
            //return View(_tfareprovider.ListAllPaperFlightFareRule());



            ViewData["AirlineType"] = new SelectList(ent.AirlineTypes.OrderBy(x => x.TypeName), "AirineTypeId ", "TypeName ");
            if (Request.IsAjaxRequest())
            {

                if (AirlineType == 1)
                {
                    var international = new TravelFareModel
                    {
                        airlineTravelportalList = _tfareprovider.GetInternationalTravelFare().OrderBy(x => x.AirlineNmae)
                    };
                    return PartialView("ListPartial", international);
                }
                else
                {
                    var domestic = new TravelFareModel
                    {
                        airlineTravelportalList = _tfareprovider.GetDomesticTravelFare().OrderBy(x => x.AirlineNmae)
                    };
                    return PartialView("ListPartial", domestic);
                }
            }
            var viewModel = new TravelFareModel
            {
                airlineTravelportalList = _tfareprovider.GetDomesticTravelFare().OrderBy(x => x.AirlineNmae)
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc, int? AirlineType)
        {

            if (Request.IsAjaxRequest())
            {
                string airlineCityname = fc["SearchAirline"];
                if (airlineCityname != null && airlineCityname != "")
                {

                    var result = new TravelFareModel
                    {
                        airlineTravelportalList = _tfareprovider.GetTravelFareByName(airlineCityname)
                    };
                    return PartialView("ListPartial", result);
                }
                else
                {
                    if (AirlineType == 1)
                    {
                        var international = new TravelFareModel
                        {
                            airlineTravelportalList = _tfareprovider.GetInternationalTravelFare()
                        };
                        return PartialView("ListPartial", international);
                    }
                    else
                    {
                        var domestic = new TravelFareModel
                        {
                            airlineTravelportalList = _tfareprovider.GetDomesticTravelFare()
                        };
                        return PartialView("ListPartial", domestic);
                    }
                }
            }
            return View();
        }


        //
        // GET: /TravelFare/Edit/5

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            SetValueForDropdownlist();

            PaperFareRules item = new PaperFareRules();
            DefaultPaperFareRules defaultPaperFairRule = new DefaultPaperFareRules();
            item = _tfareprovider.GetPaperFlightFareRuleById(id);
            defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();
            TravelFareModel model = new TravelFareModel();
            model.PaperFareId = item.PaperFareId;
            model.AirlineId = item.AirlineId;
            model.FlightSeasonId = item.FlightSeasonId;
            model.DepartureCityId = item.DepartureCityId;
            model.DestinationCityId = item.DestinationCityId;
            model.FlightClassId = item.FlightClassId;
            model.OneWayFareBasis = item.OneWayFareBasis;
            model.OneWayFare = item.OneWayFare;
            model.GoingFare = item.RoundWayGoing;
            model.RoundWayFare = item.RoundWayReturn;
            model.FuelCharge = item.FC;
            model.RoundWayFareBasis = item.RoundWayFareBasis;
            model.TotalRoundTripFare = item.RoundWayFare;
            model.EffectiveFrom = item.EffectiveFrom;
            model.ExpireOn = item.ExpireOn;
            model.FlightTypeId = item.FlightTypeId;
            model.ChildFare = item.ChildFare;
            model.ChildFareUSD = item.ChildFareUSD;
            model.ChildFareType = item.ChildFareType;
            model.ChildFareOn = item.ChildFareOn;
            model.InfantFare = item.InfantFare;
            model.InfantFareUSD = item.InfantFareUSD;
            model.InfantFareType = item.InfantFareType;
            model.InfantFareOn = item.InfantFareOn;
            model.RefundFee = item.RefundFee;
            model.RefundFeeDollar = item.RefundFeeUSD;
            model.ReissueFee = item.ReissueFee;
            model.ReissueFeeDollar = item.ReissueFeeUSD;
            model.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
            model.RoundWayGoingUSD = item.RoundWayGoingUSD;
            model.OneWayFareUSD = item.OneWayFareUSD;
            model.RoundWayReturnUSD = item.RoundWayReturnUSD;
            model.RoundWayFareUSD = item.RoundWayFareUSD;
            model.ValidTillFurtherNotice = Convert.ToBoolean(item.ValidUntilNextNotic);
            model.TourCode = item.TourCode;


            return View(model);
        }

        //
        // POST: /TravelFare/Edit/5

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, TravelFareModel obj, FormCollection collection)
        {
            DefaultPaperFareRules defaultPaperFairRule = new DefaultPaperFareRules();
            if (obj.DepartureCityId == obj.DestinationCityId)
            {
                ModelState.AddModelError("City", "Please Review the Cities");
                TempData["City"] = "please Review the cities";
            }
            //Checking If that Id contains all the values 
            bool CheckId = _tfareprovider.CheckValuesForAParticularID(obj.AirlineId, obj.DepartureCityId, obj.DestinationCityId, obj.FlightClassId, id);
            bool checkPaperFare = true;
            if (CheckId == false)
            {

                if (obj.ExpireOn == null)
                {
                    checkPaperFare = _tfareprovider.IfPaperFareExist(obj.AirlineId, obj.FlightClassId, obj.EffectiveFrom, obj.DepartureCityId, obj.DepartureCityId);
                }
                else
                {
                    checkPaperFare = _tfareprovider.CheckPaperFareExist(obj.AirlineId, obj.FlightClassId, obj.EffectiveFrom, Convert.ToDateTime(obj.ExpireOn), obj.DepartureCityId, obj.DestinationCityId);
                }
            }

            bool checkClassName = _tfareprovider.CheckClassNameExist(obj.AirlineId, obj.FlightClassId, obj.DepartureCityId, obj.DestinationCityId);

            if (checkPaperFare == false)
            {
                TempData["Error"] = "Fare  already exists";
                ModelState.AddModelError("Fare", "Unable to Save the values");
            }
            else if (checkClassName == true)
            {
                PaperFareRules _obj = new PaperFareRules();

                _obj.PaperFareId = id;
                _obj.AirlineId = obj.AirlineId;
                _obj.FlightSeasonId = obj.FlightSeasonId;
                _obj.DepartureCityId = obj.DepartureCityId;
                _obj.DestinationCityId = obj.DestinationCityId;
                _obj.FlightClassId = obj.FlightClassId;
                _obj.OneWayFareBasis = obj.OneWayFareBasis;
                _obj.OneWayFare = obj.OneWayFare;
                _obj.RoundWayGoing = obj.GoingFare;
                _obj.RoundWayReturn = obj.RoundWayFare;
                _obj.RoundWayFare = obj.TotalRoundTripFare;
                _obj.RoundWayFareBasis = obj.RoundWayFareBasis;
                _obj.FC = obj.FuelCharge;

                _obj.EffectiveFrom = obj.EffectiveFrom;
                _obj.ExpireOn = obj.ExpireOn;
                _obj.FlightTypeId = obj.FlightTypeId;
                _obj.ChildFare = obj.ChildFare;
                _obj.ChildFareUSD = obj.ChildFareUSD;
                _obj.ChildFareType = obj.ChildFareType;
                _obj.ChildFareOn = obj.ChildFareOn;
                _obj.InfantFare = obj.InfantFare;
                _obj.InfantFareUSD = obj.InfantFareUSD;
                _obj.InfantFareType = obj.InfantFareType;
                _obj.InfantFareOn = obj.InfantFareOn;
                _obj.RefundFee = obj.RefundFee;
                _obj.RefundFeeUSD = obj.RefundFeeDollar;
                _obj.ReissueFee = obj.ReissueFee;
                _obj.ReissueFeeUSD = obj.ReissueFeeDollar;
                _obj.TourCode = obj.TourCode;
                _obj.TermsAndConditions = collection["Information"];
                _obj.ValidUntilNextNotic = obj.ValidTillFurtherNotice;
                _obj.RoundWayGoingUSD = obj.RoundWayGoingUSD;
                _obj.OneWayFareUSD = obj.OneWayFareUSD;
                _obj.RoundWayReturnUSD = obj.RoundWayReturnUSD;
                _obj.RoundWayFareUSD = obj.RoundWayFareUSD;
                _tfareprovider.EditPaperFlightFareRule(_obj);
                return RedirectToAction("Index");
            }
            //if (ModelState.IsValid)
            //{
            //    PaperFareRules _obj = new PaperFareRules();

            //    _obj.PaperFareId = id;
            //    _obj.AirlineId = obj.AirlineId;
            //    _obj.FlightSeasonId = obj.FlightSeasonId;
            //    _obj.DepartureCityId = obj.DepartureCityId;
            //    _obj.DestinationCityId = obj.DestinationCityId;
            //    _obj.FlightClassId = obj.FlightClassId;
            //    _obj.OneWayFareBasis = obj.OneWayFareBasis;
            //    _obj.OneWayFare = obj.OneWayFare;
            //    _obj.RoundWayGoing = obj.GoingFare;
            //    _obj.RoundWayReturn = obj.RoundWayFare;
            //    _obj.RoundWayFare = obj.TotalRoundTripFare;
            //    _obj.RoundWayFareBasis = obj.RoundWayFareBasis;
            //    _obj.FC = obj.FuelCharge;

            //    _obj.EffectiveFrom = obj.EffectiveFrom;
            //    _obj.ExpireOn = obj.ExpireOn;
            //    _obj.FlightTypeId = obj.FlightTypeId;
            //    _obj.ChildFare = obj.ChildFare;
            //    _obj.ChildFareUSD = obj.ChildFareUSD;
            //    _obj.ChildFareType = obj.ChildFareType;
            //    _obj.ChildFareOn = obj.ChildFareOn;
            //    _obj.InfantFare = obj.InfantFare;
            //    _obj.InfantFareUSD = obj.InfantFareUSD;
            //    _obj.InfantFareType = obj.InfantFareType;
            //    _obj.InfantFareOn = obj.InfantFareOn;
            //    _obj.RefundFee = obj.RefundFee;
            //    _obj.RefundFeeUSD = obj.RefundFeeDollar;
            //    _obj.ReissueFee = obj.ReissueFee;
            //    _obj.ReissueFeeUSD = obj.ReissueFeeDollar;
            //    _obj.TourCode = obj.TourCode;
            //    _obj.TermsAndConditions = collection["Information"];
            //    _obj.ValidUntilNextNotic = obj.ValidTillFurtherNotice;
            //    _obj.RoundWayGoingUSD = obj.RoundWayGoingUSD;
            //    _obj.OneWayFareUSD = obj.OneWayFareUSD;
            //    _obj.RoundWayReturnUSD = obj.RoundWayReturnUSD;
            //    _obj.RoundWayFareUSD = obj.RoundWayFareUSD;
            //    _tfareprovider.EditPaperFlightFareRule(_obj);
            //    return RedirectToAction("Index");
            //}
            else
            {
                TempData["classname"] = "Class Name  already exists";

                SetValueForDropdownlist();
                defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();
                obj.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
                return View(obj);

            }
            defaultPaperFairRule = _tfareprovider.GetDefaultPaperFairRule();
            obj.TermsAndConditions = defaultPaperFairRule.TermsAndConditions;
            return View(obj);
        }

        public ActionResult Details(int id)
        {

            PaperFareRules item = new PaperFareRules();
            item = _tfareprovider.GetPaperFlightFareRuleById(id);

            TravelFareModel model = new TravelFareModel();
            model.PaperFareId = item.PaperFareId;
            model.AirlineNmae = item.Airlines.AirlineName;
            model.FlightSeasonName = item.FlightSeasons.FlightSeasonName;
            model.DepartureCityName = _provider.GetCityName(item.DepartureCityId);
            model.DestinationCityName = _provider.GetCityName(item.DestinationCityId);
            //model.DepartureCityName = item.AirlineCities.CityName;
            //model.DepartureCityName = item.AirlineCities.CityName;
            //  model.FlightClassName = item.FlightClasses.ClassName;
            model.OneWayFareBasis = item.OneWayFareBasis;
            model.OneWayFare = item.OneWayFare;
            model.RoundWayFareBasis = item.RoundWayFareBasis;
            model.GoingFare = item.RoundWayGoing;
            model.RoundWayFare = item.RoundWayReturn;
            model.EffectiveFrom = item.EffectiveFrom;
            model.ExpireOn = item.ExpireOn;
            model.FlightTypes = item.FlightTypes.FlightTypeName;
            model.ChildFare = item.ChildFare;
            model.ChildFareType = item.ChildFareType;
            model.ChildFareOn = item.ChildFareOn;
            model.InfantFare = item.InfantFare;
            model.InfantFareType = item.InfantFareType;
            model.InfantFareOn = item.InfantFareOn;
            model.RefundFee = item.RefundFee;
            model.ReissueFee = item.ReissueFee;
            model.TermsAndConditions = item.TermsAndConditions;
            model.TourCode = item.TourCode;
            model.FuelCharge = item.FC;
            model.TotalRoundTripFare = item.RoundWayFare;
            model.RoundWayGoingUSD = item.RoundWayGoingUSD;
            model.OneWayFareUSD = item.OneWayFareUSD;
            model.RoundWayReturnUSD = item.RoundWayReturnUSD;
            model.RoundWayFareUSD = item.RoundWayFareUSD;
            model.ValidTillFurtherNotice = Convert.ToBoolean(item.ValidUntilNextNotic);

            return View(model);
        }

        //
        // POST: /TravelFare/Delete/5


        public ActionResult Delete(int id, FormCollection collection)
        {
            _tfareprovider.DeleteFare(id);
            return RedirectToAction("Index");
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }




        /////JsonResult Function To AjaxRequestController//////////////////
        //public JsonResult GetFlightClassCodeByAirline(int id)
        //{

        //    var result = new JsonResult();
        //    var lists = new SelectList(_tfareprovider.GetFlightClassCodeByAirlineID(id), "DomesticFlightClassId", "FlightClassCode");
        //    result.Data = lists;
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;

        //}

        //public JsonResult GetAirlines(int AirlineTypeId)
        //{
        //    var model = _provider.GetAirlinesList(AirlineTypeId).ToList();
        //    JsonResult result = new JsonResult();
        //    result.Data = new SelectList(model, "AirlineId", "AirlineName");
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}
        //public JsonResult GetCities(int AirlineTypeId)
        //{
        //    var model = _provider.CityListAsperFlightType(AirlineTypeId).ToList();
        //    JsonResult result = new JsonResult();
        //    result.Data = new SelectList(model, "CityID", "CityName");
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}



        #region Custom region
        public void SetValueForDropdownlist()
        {
            var flightclasslist = ent.Air_DomesticFlightClasses.ToList();
            Air_DomesticFlightClasses flightclassSelect = new Air_DomesticFlightClasses() { DomesticFlightClassId = -1, FlightClassCode = "--Select--" };
            flightclasslist.Insert(0, flightclassSelect);

            var currencylist = ent.Currencies.ToList();
            Currencies currencySelect = new Currencies() { CurrencyId = -1, CurrencyName = "--Select--" };
            currencylist.Insert(0, currencySelect);

            //var flighttypelist = ent.FlightTypes.ToList();
            //FlightTypes flighttypeSelect = new FlightTypes() { FlightTypeId = -1, FlightTypeName ="--Select--" };
            //flighttypelist.Insert(0, flighttypeSelect);

            var flightsessionlist = ent.FlightSeasons.ToList();
            FlightSeasons flightsessionSelect = new FlightSeasons { FlightSeasonId = -1, FlightSeasonName = "--Select--" };
            flightsessionlist.Insert(0, flightsessionSelect);

            //var airlinelist = ent.Airlines.ToList();
            //Airlines airlineSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            //airlinelist.Insert(0, airlineSelect);


            //var departurecitylist = ent.AirlineCities.ToList();
            //AirlineCities departurecitylistSelect = new AirlineCities() { CityID = -1, CityName = "--Select--" };
            //departurecitylist.Insert(0, departurecitylistSelect);

            //var destinationcitylist = ent.AirlineCities.ToList();
            //AirlineCities destinartioncitySelect = new AirlineCities() { CityID = -1, CityName = "--Select--" };
            //destinationcitylist.Insert(0, destinartioncitySelect);


            //ViewData["FlightClasses"] = flightclasslist;//new SelectList(_tfareprovider.GetAllFlightClass(), "FlightClassId", "FlightClassCode");
            //ViewData["CurrencyType"] = currencylist;//new SelectList(_tfareprovider.GetAllCurrencyType(), "CurrencyId", "CurrencyCode");
            //ViewData["FlightTypes"] = flighttypelist;//new SelectList(_tfareprovider.GetAllFlightType(), "FlightTypeId", "FlightTypeName");
            //ViewData["FlightSeasons"] = flightsessionlist;//new SelectList(_tfareprovider.GetAllFlightSeason(), "FlightSeasonId", "FlightSeasonName");
            //ViewData["Airline"] = airlinelist;//new SelectList(_tfareprovider.GetAllAirline(), "AirlineId", "AirlineName");
            //ViewData["DepartureCity"] = departurecitylist;//new SelectList(_tfareprovider.GetAllAirlineCity(), "CityID", "CityName");
            //ViewData["DestinationCity"] = departurecitylist; //new SelectList(_tfareprovider.GetAllAirlineCity(), "CityID", "CityName");

            ViewData["FlightClasses"] = new SelectList(_tfareprovider.GetAllFlightClass(), "FlightClassId", "FlightClassCode");
            ViewData["CurrencyType"] = new SelectList(_tfareprovider.GetAllCurrencyType(), "CurrencyId", "CurrencyCode");
            ViewData["FlightTypes"] = new SelectList(_tfareprovider.GetDomesticFlightType(), "FlightTypeId", "FlightTypeName", 0);
            ViewData["FlightSeasons"] = new SelectList(_tfareprovider.GetAllFlightSeason(), "FlightSeasonId", "FlightSeasonName");
            ViewData["Airline"] = new SelectList(_tfareprovider.GetAllDomesticAirlines(), "AirlineId", "AirlineName", 0);
            ViewData["DepartureCity"] = new SelectList(_tfareprovider.GetDomesticCities(), "CityID", "CityName", 0);
            // ViewData["DestinationCity"] = new SelectList(_tfareprovider.GetAllAirlineCity(), "CityID", "CityName");

            ViewData["ChildFairTypes"] = new SelectList(ATLTravelPortal.Helpers.ChildFairTypes.GetChildFairType(), "ChildFairTypeID", "ChildFairType", "P");
            ViewData["ChildFairOns"] = new SelectList(ATLTravelPortal.Helpers.ChildFairOns.GetChildFairOn(), "ChildFairOnId", "ChildFairOnss", "M");


        }
        #  endregion

        //public IEnumerable<TravelFareModel> GerListAirLineTravelFare()
        //{
        //    var tempData = ent.PaperFareRules.ToList();
        //    var reviewModel = new List<TravelFareModel>();

        //    foreach (var item in tempData)
        //    {
        //        var viewModel = new TravelFareModel
        //        {
        //            PaperFareId = item.PaperFareId,
        //            AirlineId	 = item.AirlineId,
        //            AirlineNmae = item.Airlines.AirlineName,
        //            FlightSeasonId	= item.FlightSeasonId,
        //            DepartureCityId	= item.DepartureCityId,
        //            DestinationCityName = _provider.GetCityName(item.DestinationCityId),
        //            DestinationCityId	= item.DepartureCityId,
        //            DepartureCityName = _provider.GetCityName(item.DepartureCityId),
        //            FlightClassId	= item.DestinationCityId,
        //            OneWayFareBasis	= item.OneWayFareBasis,
        //            OneWayFare	= item.OneWayFare,
        //            RoundWayFareBasis	= item.RoundWayFareBasis,
        //            RoundWayFare	= item.RoundWayFare,
        //            EffectiveFrom	= item.EffectiveFrom,
        //            ExpireOn	= item.ExpireOn,
        //            FlightTypeId	= item.FlightTypeId,
        //            ChildFare	= item.ChildFare,
        //            ChildFareType	= item.ChildFareType,
        //            ChildFareOn	= item.ChildFareOn,
        //            InfantFare	= item.InfantFare,
        //            InfantFareType	= item.InfantFareType,
        //            InfantFareOn	= item.InfantFareOn,
        //            RefundFee	= item.RefundFee,
        //            ReissueFee	= item.ReissueFee,
        //            CurrencyId	= item.CurrencyId,
        //            TermsAndConditions	= item.TermsAndConditions,
        //            TourCode	= item.TourCode,
        //            FlightClassName = item.FlightClasses.ClassName

        //        };
        //        reviewModel.Add(viewModel);
        //    }
        //    return reviewModel.AsEnumerable();
        //}

    }
}
