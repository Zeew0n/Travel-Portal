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
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create",  Delete = "Delete", Order = 2)]
    public class DomesticFlightClassController : Controller
    {
       
        DomesticflighClassProvider _domesticProvider = new DomesticflighClassProvider();
        //
        // GET: /DomesticFlightClass/

        public ActionResult Index()
        {
            AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
            {
                AirlineFlighClass = _domesticProvider.GetAllFlightClassesList().ToList().AsQueryable(),

            };
            return View(viewmodel);
        }


        //
        // GET: /DomesticFlightClass/Create

        public ActionResult Create()
        {
            AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
            {
                DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
               
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("Create", viewmodel);
            else
                return View(viewmodel);

        }

        

        [HttpPost]
        public ActionResult Create(AirlineFlighClassViewModel model)
        {
            bool check = _domesticProvider.CheckFlightCode(model.AirlineId,model.FlightClassCode);
            if (check == false)
            {
                try
                {

                    _domesticProvider.AddFlightClass(model);
                    /////// Return to View After Success
                    AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
                    {
                        DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
                    };
                    TempData["Message"] = "Successfully added";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = "Code Already exists";
            return RedirectToAction("Index");
        }

        //
        // GET: /DomesticFlightClass/EditFlightClass/5

        public ActionResult Edit(int id)
        {
            var datamodel = _domesticProvider.GeFlightClassesInfo(id);
            var viewmodel = new AirlineFlighClassViewModel()
            {

                FlightClassId = id,
                FlightClassCode = datamodel.FlightClassCode,
                AirlineId=datamodel.AirlineId,
                HFAirlineId=datamodel.AirlineId,
                DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
                ClassType = datamodel.FlightClassType,
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("_Edit", viewmodel);
            else
                return View(viewmodel);
        }

        //
        // POST: /DomesticFlightClass/Edit/5

        [HttpPost]
        public ActionResult Edit(AirlineFlighClassViewModel model)
        {

           // int airlineId = _domesticProvider.GetAirlineId(model.FlightClassId);
            model.AirlineId = model.HFAirlineId;
           // model.FlightClassId = id;
            bool check = true;
           
            check = _domesticProvider.CheckFlightCode(model.AirlineId, model.FlightClassCode);
         
             
          
                try
                {
                    // TODO: Add update logic here
                    _domesticProvider.UpdatFlightClasses(model);
                  //  TempData["Message"] = "Successfully updated";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

         
            //TempData["Message"] = "Code Already exists";
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ViewDomesticFlightClass(AirlineFlighClassViewModel model)
        {
            if (model.AirlineId != 0)
            {

                AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
                {
                    AirlineId = model.AirlineId,
                    DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
                    AirlineFlighClass = _domesticProvider.GetFlightClassDomesticAirline(),
                    ActiveFlightClassForAirline = _domesticProvider.GetAllActiveFlightClassForAirline(model.AirlineId).ToList()
                };
                return View("DomesticFlightClass", viewmodel);
            }
            else
            {
                AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
                {

                    DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
                };
                return View("DomesticFlightClass", viewmodel);
            }
        }

        public ActionResult Delete(int id)
        {
            _domesticProvider.DeleteFareClass(id);
            return RedirectToAction("Index");
        }
        public ActionResult DomesticFlightClass(int id)
        {
            if (id != 0)
            {

                AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
                {
                    AirlineId = id,
                    DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
                    AirlineFlighClass = _domesticProvider.GetFlightClassDomesticAirline(),
                    ActiveFlightClassForAirline = _domesticProvider.GetAllActiveFlightClassForAirline(id).ToList()
                };

                return View(viewmodel);
            }
            else
            {
                AirlineFlighClassViewModel viewmodel = new AirlineFlighClassViewModel()
             {

                 DomesticAirlineList = _domesticProvider.GetDomesticAirlineList(),
             };
                return View(viewmodel);
            }

        }

        //
        // POST: /DomesticFlightClass/Delete/5

        [HttpPost]
        public ActionResult DomesticFlightClass(AirlineFlighClassViewModel model, int[] ChkFlightClassId)
        {
            try
            {
                _domesticProvider.DeleteAirlineFlightClasses(model.AirlineId);
                List<int> ChkFlightClassIdS = new List<int>();
                foreach (int Classid in ChkFlightClassId)
                {
                    model.FlightClassId = Classid;
                    _domesticProvider.AddDomesticAirlineFlightClass(model);
                }
                // TODO: Add delete logic here
                int id = model.AirlineId;
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("DomesticFlightClass", new { id = model.AirlineId });
            }
            catch
            {
                return View();
            }
        }
    }
}
