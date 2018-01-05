using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using System.Collections;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    
    public class TicketCappingController : Controller
    {
        public ActionResult Index()
        {
            TicketCappingProvider pro = new TicketCappingProvider();

            IEnumerable<TicketCappingModel> model = pro.GetList();
            return View(model);
        }

    }
}
