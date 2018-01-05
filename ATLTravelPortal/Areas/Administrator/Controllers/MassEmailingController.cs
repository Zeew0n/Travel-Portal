using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Models.Enums;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class MassEmailingController : Controller
    {
        MassEmailingProvider massEmailingProvider = new MassEmailingProvider();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return View(massEmailingProvider.GetMassEmailingModel(null));
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message.ToString();
                return View(massEmailingProvider.GetMassEmailingModel(null));
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(MassEmailingModel model)
        {
            try
            {
               
                //if (ModelState.IsValid)
                //{
                    if (model.MessageType == MessageType.Email)
                    {
                        int result = massEmailingProvider.SendMassEmails(model);
                        TempData["SuccessMessage"] = result.ToString() + " Email(s) Sent Successfully.";
                    }
                    else if (model.MessageType == MessageType.SMS)
                    {
                        int result = massEmailingProvider.SendMassSMSs(model);

                        TempData["SuccessMessage"] = result.ToString() + " SMS(s) Sent Successfully.";
                    }
                  //  return View(massEmailingProvider.GetMassEmailingModel(model));
                    return RedirectToAction("Index");
                //}
                //else
                //    return View(massEmailingProvider.GetMassEmailingModel(model));

            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message.ToString();
                return View(massEmailingProvider.GetMassEmailingModel(model));
            }
        }
    }
}
