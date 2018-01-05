using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class IssueDomesticTicketsController : Controller
    {
        IssueDomesticTicketsProvider issueDomesticTicketsProvider = new IssueDomesticTicketsProvider();

        [HttpGet]
        public ActionResult Index(Int64? id, bool doOnlyUploadETicket)
        {
            IssueDomesticTicketsModel viewModel = new IssueDomesticTicketsModel();
            try
            {
                if (id != null)
                    viewModel = issueDomesticTicketsProvider.GetIssueDomesticTickets(id,doOnlyUploadETicket);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IssueDomesticTicketsModel model)
        {
            IssueDomesticTicketsModel viewModel = new IssueDomesticTicketsModel();
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = false;                  
                    isUpdated = issueDomesticTicketsProvider.Update(model);
                    if (model != null)
                        viewModel = issueDomesticTicketsProvider.GetIssueDomesticTickets(model.MPNRId,model.DoOnlyUploadETicket);

                    if (isUpdated)
                        return RedirectToAction("Index", new { Controller = "UnIssuedDomesticTicket" });
                    TempData["SuccessMessage"] = "Record Updated Successfully!";
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(viewModel);
            }
            return View(viewModel);
        }

        public ActionResult Delete(Int64? id, Int64? pid, string mode)
        {
            try
            {
                issueDomesticTicketsProvider.DeletePassenger(pid, mode);
                if (mode == "remove")
                    TempData["SuccessMessage"] = "Passenger Removed Successfully!";
                else if (mode == "include")
                    TempData["SuccessMessage"] = "Passenger Included Successfully!";

                return RedirectToAction("Index", new { id = id, doOnlyUploadETicket = false });
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index", new { id = id, doOnlyUploadETicket=false });
        }

        public ActionResult CancelPNR(Int64? id)
        {
            try
            {
                issueDomesticTicketsProvider.CancelPNR(id);

                return RedirectToAction("Index", new { Controller = "UnIssuedDomesticTicket" });
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }
            return RedirectToAction("Index", new { id = id, doOnlyUploadETicket = false });
          
        }
    }
}
