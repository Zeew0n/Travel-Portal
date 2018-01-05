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
    public class ConfigureAccountController : Controller
    {
        //
        // GET: /ConfigureAccount/
        GeneralProvider provider = new GeneralProvider();
        ConfigureAccountProvider ser = new ConfigureAccountProvider();
        public ActionResult Index(int? productId)
        {
            ConfigureAccountModel model = new ConfigureAccountModel();
            model.KeyValue = new Dictionary<string, int>();
            SetDropDownValue(productId);
            if (Request.IsAjaxRequest())
            {
                if (productId == null)
                {
                    productId = 0;
                }
                model.ConfigureAccountList = ser.GetConfigureAccountList(productId.Value);

                return PartialView("ListPartial", model);
            }

            model.ConfigureAccountList = ser.GetConfigureAccountList(0);


            return View();
        }
        [HttpPost]
        public ActionResult Index(ConfigureAccountModel obj, string KeyValue, int[] AccountValue)
        {
            //SetDropDownValue(obj.ProductId);
            ConfigureAccountModel model = new ConfigureAccountModel();

            string[] str = KeyValue.Split(',');
           
            for (int i = 1; i < str.Length; i++)
            {

                if (str[i] == "")
                {
                    continue;
                }
                int LedgerId = int.Parse(str[i]);

                ser.SaveConfigureAccount(AccountValue.ElementAt(i-1), obj.ProductId, LedgerId);


            }

            return RedirectToAction("Index");
        }
        public void SetDropDownValue(int? ProductId)
        {
            ViewData["Products"] = new SelectList(provider.GetProductsList(), "ProductId", "ProductName");
            if (ProductId != null)
                ViewData["Ledger"] = new SelectList(ser.GetLedgerList(ProductId.Value), "LedgerId", "LedgerName", "---Select----");
        }
    }
}
