using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Error/

        public ActionResult PageNotFound(string aspxerrorpath)
        {
            return View();
        }

        public ActionResult Error()
        {
            if (Request.IsAjaxRequest())
                return PartialView("VUC_Error");

            return View();
        }
        public ActionResult AccessDenied()
        {
            return View();
        }

       
    }
}
