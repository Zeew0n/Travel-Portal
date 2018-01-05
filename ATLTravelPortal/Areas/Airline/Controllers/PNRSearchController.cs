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

namespace ATLTravelPortal.Areas.Airline.Controllers
{

     [CheckSessionFilter]
    public class PNRSearchController : Controller
    {
         AgentManagement _spAgentList = new AgentManagement();
         PNRSearchModel model = new PNRSearchModel();
        //
        // GET: /PNRSearch/
        [HttpGet]
        public ActionResult ActionBookedSearch()
        {
            model.AgentList = _spAgentList.getAllAgentList();

            return View("~/Views/TicketManagement/VUC_PNRSearch.ascx",model);
        }
        [ChildActionOnly]
        public ActionResult ActionBookedSearch(PNRSearchModel model)
        {
            model.AgentList = _spAgentList.getAllAgentList();
            return View("~/Views/TicketManagement/VUC_PNRSearch.ascx", model);
        }
         

        [HttpGet]
        public ActionResult ActionConfirmSearch()
        {
            model.AgentList = _spAgentList.getAllAgentList();
            return View("~/Views/TicketManagement/VUC_PNRSearch.ascx",model);
        }
        [ChildActionOnly]
        public ActionResult ActionConfirmSearch(PNRSearchModel model)
        {
            model.AgentList = _spAgentList.getAllAgentList();
            return View("~/Views/TicketManagement/VUC_PNRSearch.ascx", model);
        }

        
         [HttpGet]
        public ActionResult ActionBookingSearchByAgent()
        {
            model.AgentList = _spAgentList.getAllAgentList();

            return View("~/Views/TicketManagement/VUC_PNRSearchByAgent.ascx", model);
        }
        [ChildActionOnly]
              public ActionResult ActionBookingSearchByAgent(PNRSearchModel model)
        {
            return View("~/Views/TicketManagement/VUC_PNRSearchByAgent.ascx", model);
        }



        [HttpGet]
        public ActionResult ActionConfirmSearchByAgent()
        {
            model.AgentList = _spAgentList.getAllAgentList();
            return View("~/Views/TicketManagement/VUC_PNRSearchByAgent.ascx", model);
        }
        [ChildActionOnly]
        public ActionResult ActionConfirmSearchByAgent(PNRSearchModel model)
        {
            return View("~/Views/TicketManagement/VUC_PNRSearchByAgent.ascx", model);
        }


    }
}
