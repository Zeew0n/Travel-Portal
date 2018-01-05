using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    
    public class PNRManagementController : Controller
    {
        PNRManagementRepository pnrmanagerepo = new PNRManagementRepository();
        //
        // GET: /Airline/PNRManagement/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(PNRManagementModel model)
        {
            PNRManagementModel viewmodel=new PNRManagementModel();
            viewmodel.PNRsModel = pnrmanagerepo.GetPNRDetail(model.GDSPNR);
            viewmodel.PNRSegmentsList = pnrmanagerepo.GetPNRSegmentList(viewmodel.PNRsModel.PNRId);
            viewmodel.PassengerList = pnrmanagerepo.GetPassengersList(viewmodel.PNRsModel.PNRId);
            viewmodel.TicketStatusList = pnrmanagerepo.GetAllTicketStatusList();
            return PartialView("VUC_PNREditPartial", viewmodel);
        }

    }
}
