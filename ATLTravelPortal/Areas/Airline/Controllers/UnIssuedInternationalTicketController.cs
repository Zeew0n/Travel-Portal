using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Details = "Details", Add = "Issue", Delete = "Cancel", Order = 2)]
    public class UnIssuedInternationalTicketController : Controller
    {
        UnIssuedInternationalTicketProvider pro = new UnIssuedInternationalTicketProvider();
        PNRsModel _modPNR = new PNRsModel();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();
        FareModel _modFare = new FareModel();
        PNRDetailProvider _provider = new PNRDetailProvider();
        [HttpGet]
        public ActionResult Index()
        {
           IEnumerable<UnIssuedInternationalTicketModel> model = pro.GetList();
           return View(model);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Details(int id, string submitButton,UnIssuedInternationalTicketModel model)
        {
            if (submitButton == "Issue PNR")
            {
                if(Issue(id))
                    return RedirectToAction("Index");
            }
            if (submitButton == "Cancel PNR")
            {
                if(Cancel(id, model))
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Details");
        }

        public bool Issue(int id)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                pro.IssueTicket(id,ts.AppUserId);
               
            }
            catch (GDS.GDSException ex)
            {

                System.Text.StringBuilder errorBuilder = new System.Text.StringBuilder();
                foreach (GDS.GdsErrorData errors in ex.GDSErrors)
                {

                    errorBuilder.Append(errors.ErrorMessage);
                    errorBuilder.Append(errors.ErrText);
                }
                TempData["InfoMessage"] = errorBuilder;

                Exception newExp = new Exception(errorBuilder.ToString());
                Utility.ErrorLogging.LogException(newExp);
                return false;

            }
            catch (Exception ex)
            {
                TempData["InfoMessage"] = ex.Message;
                Utility.ErrorLogging.LogException(ex);
                return false;
            }
            return true;
        }

        public bool Cancel(int id,UnIssuedInternationalTicketModel model)
        {
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            try
            {
                model.UserID = ts.AppUserId;
                pro.CancelTicket(id, model);
            }
            catch (GDS.GDSException ex)
            {

                System.Text.StringBuilder errorBuilder = new System.Text.StringBuilder();
                foreach (GDS.GdsErrorData errors in ex.GDSErrors)
                {

                    errorBuilder.Append(errors.ErrorMessage);
                    errorBuilder.Append(errors.ErrText);
                }
                TempData["InfoMessage"] = errorBuilder;
                Exception newExp = new Exception(errorBuilder.ToString());
                Utility.ErrorLogging.LogException(newExp);
                return false;

            }
            catch (Exception ex)
            {

                TempData["InfoMessage"] = ex.Message;
                Utility.ErrorLogging.LogException(ex);
                return false;
            }
            return true;
        }



    }
}
