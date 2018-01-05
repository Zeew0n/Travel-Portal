using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class AgencyPNRTransferController : Controller
    {

        PNRInfoProvider _provider = new PNRInfoProvider();
        GeneralProvider defaultProvider = new GeneralProvider();
        //
        // GET: /Airline/AgencyPNRTransfer/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(int AgentId, int ToAgentId, string PnrNo, string BookingStatus, string Remark)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string jsonresponse = _provider.TransferPNRToAgency(AgentId, ToAgentId, PnrNo, BookingStatus, Remark, obj.AppUserId);
           return Json(jsonresponse);
        }

        //
        // GET: /Airline/AgencyPNRTransfer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Airline/AgencyPNRTransfer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Airline/AgencyPNRTransfer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Airline/AgencyPNRTransfer/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Airline/AgencyPNRTransfer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Airline/AgencyPNRTransfer/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Airline/AgencyPNRTransfer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
