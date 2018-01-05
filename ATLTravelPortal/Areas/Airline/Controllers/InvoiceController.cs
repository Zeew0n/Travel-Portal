using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class InvoiceController : ATLTravelPortal.Areas.Airline.Controllers.PartialViewRendererController
    {       
        InvoiceDetailProvider provider = new InvoiceDetailProvider();
        public ActionResult Index(int id)
        {
            var newmodel = provider.GetInvoiceDetailMain(id);
            return View(newmodel);
        }

        [HttpPost]
        public ActionResult Index(int id, InvoiceViewModel model)
        {

            var newmodel = provider.GetInvoiceDetailMain(id);
            newmodel.Email = model.Email;

            if (!ModelState.IsValid) return View("Index", newmodel);

            // string body = RenderPartialViewToString("Index", newmodel);
            string HTMLbody = RenderPartialViewToString("Index", newmodel);
            string body = provider.RemoveSendEmailFields(HTMLbody);

            try
            {

                provider.SendEmail(newmodel.Email, body, "Invoice");

                ViewData["isEmailSent"] = "Your email is right on the way, you'll get email in a minute.";
            }
            catch (Exception ex)
            {
                ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                ViewData["isEmailSent"] = "Unable to send email";
            }
            return View(newmodel);
        }


    }
}
