using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
     [CheckSessionFilter(Order=1)]
     [PermissionDetails(View = "Index", Order = 2)]
   

    public class PNRDetailController : Controller
    {
        PNRDetailProvider _provider = new PNRDetailProvider();
        PNRsModel _modPNR = new PNRsModel();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();



        //
        // GET: /PNRDetail/
        /// <summary>
        /// 
        /// id is the PNR Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public ActionResult Index(int id)
        {
            return View();
        }
        /// <summary>
        /// 
        /// id is the PNR Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PNR(int id)
        {
            _modPNR = _provider.GetPNRDetail(id);
            return PartialView("VUC_PNR", _modPNR);
        }
        /// <summary>
        /// 
        /// id is the PNR Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PNRSegment(int id)
        {
            _modPNRSeg.PNRSegmentsList = _provider.GetPNRSegmentList(id);
            return PartialView("VUC_PNRSegment", _modPNRSeg);
        }
        /// <summary>
        /// 
        /// id is the PNR Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult PNRPassenger(int id)
        {
            _modPassenger.PassengersList = _provider.GetPassengersList(id);
            return PartialView("VUC_PNRPassenger", _modPassenger);
        }
    }
}
