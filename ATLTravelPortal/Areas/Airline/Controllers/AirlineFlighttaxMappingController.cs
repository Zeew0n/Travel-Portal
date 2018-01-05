using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirLines.Provider.Admin;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.CustomAttribute;

namespace AirLines.Controllers.Admin
{
    [CheckSessionFilter(Order=1)]
    [PermissionDetails(View = "Index", Add = "Create", Order = 2)]
    public class AirlineFlighttaxMappingController : Controller
    {
        EntityModel ent = new EntityModel();
        AirlineFlightTaxMappingProvider ser = new AirlineFlightTaxMappingProvider();

        //
        // GET: /AirlineFlighttaxMapping/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(AirLineFlightTaxMappingModel model)
        {
            var viewModel = new AirLineFlightTaxMappingModel
            {
                airLineFlightTaxMappingList = GetAirLineFlightMappingByAirlineId(model.AirLineId)
            };
            return View(viewModel);
        }
        
        public ActionResult AjaxList(int id)
        {
            var viewModel = new AirLineFlightTaxMappingModel
            {
                airLineFlightTaxMappingList = GetAirLineFlightMappingByAirlineId(id)
            };
            return PartialView("VUC_AirLineFlightTaxMappingList",viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AirLineFlightTaxMappingModel model = new AirLineFlightTaxMappingModel();
            var listOfAirlines = ent.Airlines.ToList();
            Airlines infoSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            listOfAirlines.Insert(0, infoSelect);

            var flightmappingList = ent.AirlineFlightTaxes.ToList();
            AirlineFlightTaxes flighttaxSelect = new AirlineFlightTaxes() { FlightTaxId = -1, FlightTaxName = "--Select--" };
            flightmappingList.Insert(0, flighttaxSelect);
            ViewData["CommissionValueType"] = new SelectList(ATLTravelPortal.Helpers.ChildFairTypes.GetChildFairType(), "ChildFairTypeID", "ChildFairType", "");

            ViewData["airLineList"] = listOfAirlines;
            ViewData["FlightTaxList"] = flightmappingList;
            //model = LoadListData(model);
            return View();
            
        }


        [HttpPost]
        public ActionResult Create(AirLineFlightTaxMappingModel model)
        {
            var airlineList = ent.Airlines.ToList();
            Airlines airlineSelect = new Airlines() { AirlineId = 0, AirlineName = "--Select--" };
            airlineList.Insert(0, airlineSelect);

            var flightmappingList = ent.AirlineFlightTaxes.ToList();
            AirlineFlightTaxes flighttaxSelect = new AirlineFlightTaxes() { FlightTaxId = -1, FlightTaxName = "--Select--" };
            flightmappingList.Insert(0, flighttaxSelect);

            ViewData["airLineList"] = airlineList;
            ViewData["FlightTaxList"] = flightmappingList;
            ViewData["CommissionValueType"] = new SelectList(ATLTravelPortal.Helpers.ChildFairTypes.GetChildFairType(), "ChildFairTypeID", "ChildFairType", "");

            var airlines = ent.Airlines.Where(x => x.AirlineId == model.AirLineId).FirstOrDefault();
            if (airlines != null && ent.AirlineFlightTaxesMappings.Where(x => (x.FlightTaxId == model.FlightTaxId
                    && x.AirlineId == model.AirLineId))
                    .FirstOrDefault() != null)
            {
                ModelState.AddModelError("AirlineId", "AirLine or Flight tax already exists");
            }
            


            AirlineFlightTaxesMappings obj = new AirlineFlightTaxesMappings();

            if (ModelState.IsValid)
            {

                
                //else if (model.AirLineId == -1)
                //{
                //    ModelState.AddModelError("", "Please select AirlineName!!");
                //}
                //else if (model.FlightTaxId == -1)
                //{
                //    ModelState.AddModelError("", "Please select FlighttaxName!!");
                //}
                //else if (model.ddlcommission == "1")
                //{
                //    ModelState.AddModelError("", "Please select CommissionType!!");
                //}
                //else
                //{
                obj.AirlineId = model.AirLineId;
                obj.FlightTaxId = model.FlightTaxId;
                obj.CommissionValue = model.CommissionValue;
                obj.CommissionType = model.ddlcommission;
                ser.AddAirLineFlightTaxMapping(obj);
                //}

                //model = LoadListData(model);
                return View("Create", model);
            }
            else
            {
                ViewData["airLineList"] = ent.Airlines.ToList();
                ViewData["FlightTaxList"] = ent.AirlineFlightTaxes.ToList();
                ViewData["CommissionValueType"] = new SelectList(ATLTravelPortal.Helpers.ChildFairTypes.GetChildFairType(), "ChildFairTypeID", "ChildFairType", "");
                return View();
            }
        }

        //private AirLineFlightTaxMappingModel LoadListData(AirLineFlightTaxMappingModel model)
        //{

        //    model.commissionList.Add(new SelectListItem { Text = "--Select--", Value = "1", });
        //    model.commissionList.Add(new SelectListItem { Text = "PERCENTAGE", Value = "PERCENTAGE", });
        //    model.commissionList.Add(new SelectListItem { Text = "SLAB", Value = "SLAB", });
        //    model.airLineFlightTaxMappingList = GetAirLineFlightMappingByAirlineId(model.AirLineId);
        //    return model;
        //}

        private IEnumerable<AirLineFlightTaxMappingModel> GetAirLineFlightMappingByAirlineId(int AirlIneId)
        {
            var tempModel = ent.GetAirlineFlightTaxesMapping(AirlIneId);
            var reviewModel = new List<AirLineFlightTaxMappingModel>();

            foreach (var item in tempModel)
            {
                var viewModal = new AirLineFlightTaxMappingModel
                {
                    AirLineId = item.AirlineId,
                    AirlineName = item.AirlineName,
                    FlightTaxId = item.FlightTaxId,
                    FlightTaxName = item.FlightTaxName,
                    CommissionValue = item.CommissionValue,
                    CommissionType = item.CommissionType
                };
                reviewModel.Add(viewModal);
            }
            return reviewModel.AsEnumerable();
        }
    }
}
