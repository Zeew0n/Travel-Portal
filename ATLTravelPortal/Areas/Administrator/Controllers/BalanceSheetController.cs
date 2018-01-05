using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class BalanceSheetController : Controller
    {
        //
        // GET: /BalanceSheetReport/

        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        BalanceSheetProvider ser = new BalanceSheetProvider();


        public ActionResult Index(int? productId, DateTime? FromDate, DateTime? ToDate)
        {

            if (Request.IsAjaxRequest())
            {
                var viewModel = new ProfitLossReportModel
                {
                    BalanceSheetList = ser.GetBalanceSheetReportList(productId, FromDate, ToDate)
                };
                return PartialView("ListPartial", viewModel);
            }

            var productList = ent.Core_Products.ToList();
            ViewData["ProductList"] = new SelectList(productList, "ProductId", "ProductName", 0);

            return View();
        }



        [HttpPost]
        public ActionResult Index(ProfitLossReportModel model)
        {
            if (Request.IsAjaxRequest())
            {

                DateTime? FDate;
                if (model.FromDate == DateTime.MinValue)
                    FDate = null;
                else
                    FDate = model.FromDate;

                DateTime? TDate;
                if (model.ToDate == DateTime.MinValue)
                    TDate = null;
                else
                    TDate = model.ToDate;
                var productList = ent.Core_Products.ToList();

                ViewData["ProductList"] = new SelectList(productList, "ProductId", "ProductName", 0);
                int? id = model.ProductId;


                var viewModel = new ProfitLossReportModel
                {
                    BalanceSheetList = ser.GetBalanceSheetReportList(id, FDate, TDate)

                };
                return PartialView("ListPartial", viewModel);

            }

            return View();
        }




    }
}
