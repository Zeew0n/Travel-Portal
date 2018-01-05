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
    [PermissionDetails(View = "Index", Order = 2)]


    public class UnIssuedDomesticTicketController : Controller
    {
        //
        // GET: /UnIssuedDomesticTicket/

        GeneralProvider defaultProvider = new GeneralProvider();

        UnIssuedDomesticTicketProvider ser = new UnIssuedDomesticTicketProvider();

        public ActionResult Index(int? pageNo, int? flag)
        {
            UnIssuedDomesticTicketModel model = new UnIssuedDomesticTicketModel();
            model.UsIssuedDomesticTicketList = ser.ListUnIssuedDomesticTicket();


            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;

            model.UsIssuedDomesticTicketList = ser.GetUnIssuedDomesticTicketByPagination(model, pageNo.Value, out  currentPageNo, out numberOfPage, flag);
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;

            return View(model);
        }

        public ActionResult Issue(long Id)
        {
            UnIssuedDomesticTicketModel model = new UnIssuedDomesticTicketModel();
           
            ViewData["AgentList"] = new SelectList(defaultProvider.GetAgentList(), "AgentId", "AgentName");
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            
            try
            {
                ser.Issue(Id, ts.AppUserId);
                model.UsIssuedDomesticTicketList = ser.ListUnIssuedDomesticTicket();

                return View("Index", model);
            }
            catch
            {
                model.UsIssuedDomesticTicketList = ser.ListUnIssuedDomesticTicket();

                TempData["Error"] = "PNR cannot be created";

                return View("Index", model);

            }
        }



    }
}
