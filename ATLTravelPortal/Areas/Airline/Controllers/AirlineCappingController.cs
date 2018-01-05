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
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Order = 2)]
    public class AirlineCappingController : Controller
    {
        GeneralProvider defaultProvider = new GeneralProvider();
        AirlineCappingProvider airlineCappingProvider = new AirlineCappingProvider();
        EntityModel ent = new EntityModel();

        public ActionResult Create()
        {
            var gdsList = ent.ServiceProviders.OrderBy(x=>x.ServiceProviderName).ToList();
            ServiceProviders gdsSelect = new  ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);

            var airLineList = ent.Airlines.ToList();
            Airlines airlineSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            airLineList.Insert(0, airlineSelect);

            var bankList = ent.Banks.ToList();
            Banks bankSelect = new Banks() { BankId = -1, BankName = "--Select--" };
            bankList.Insert(0, bankSelect);

            var paymentList = ent.PaymentModes.ToList();
            PaymentModes paymentSelect = new PaymentModes() { PaymentModeId = -1, ModeName = "--Select--" };
            paymentList.Insert(0, paymentSelect);

            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
            ViewData["AirlineList"] = airLineList;//defaultProvider.GetAirlineList();
            ViewData["BankList"] = bankList;//defaultProvider.GetBankList();
            ViewData["PaymentModeList"] = paymentList;//defaultProvider.GetPaymentModeList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(AirlineCappingModel model)
        {
            var gdsList = ent.ServiceProviders.ToList();
            ServiceProviders gdsSelect = new ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);

            var airLineList = ent.Airlines.ToList();
            Airlines airlineSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            airLineList.Insert(0, airlineSelect);

            var bankList = ent.Banks.ToList();
            Banks bankSelect = new Banks() { BankId = -1, BankName = "--Select--" };
            bankList.Insert(0, bankSelect);

            var paymentList = ent.PaymentModes.ToList();
            PaymentModes paymentSelect = new PaymentModes() { PaymentModeId = -1, ModeName = "--Select--" };
            paymentList.Insert(0, paymentSelect);

            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
            ViewData["AirlineList"] = airLineList;//defaultProvider.GetAirlineList();
            ViewData["BankList"] = bankList;//defaultProvider.GetBankList();
            ViewData["PaymentModeList"] = paymentList;//defaultProvider.GetPaymentModeList();

            if (ModelState.IsValid)
            {
                airlineCappingProvider.Create(model);
                //ViewData["GDSList"] = defaultProvider.GetGDSInformationList();
                //ViewData["AirlineList"] = defaultProvider.GetAirlineList();
                //ViewData["BankList"] = defaultProvider.GetBankList();
                //ViewData["PaymentModeList"] = defaultProvider.GetPaymentModeList();
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            var gdsList = ent.ServiceProviders.OrderBy(x => x.ServiceProviderName).ToList();
            ServiceProviders gdsSelect = new ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);
            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
            // ViewData["AirlineList"] = defaultProvider.GetAirlineList();
            return View();

        }

        [HttpPost]
        public ActionResult Index(AirlineCappingModel objmodel)
        {
            var gdsList = ent.ServiceProviders.ToList();
            ServiceProviders gdsSelect = new ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);


            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
           // ViewData["AirlineList"] = defaultProvider.GetAirlineList();

            var model = new AirlineCappingModel
            {
                airlineCappingList = airlineCappingProvider.List(objmodel.ServiceProviderId)
            };

            return View(model);
        }

        public ActionResult Edit(Int64 id)
        {
            var gdsList = ent.ServiceProviders.ToList();
            ServiceProviders gdsSelect = new ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);

            var airLineList = ent.Airlines.ToList();
            Airlines airlineSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            airLineList.Insert(0, airlineSelect);

            var bankList = ent.Banks.ToList();
            Banks bankSelect = new Banks() { BankId = -1, BankName = "--Select--" };
            bankList.Insert(0, bankSelect);

            var paymentList = ent.PaymentModes.ToList();
            PaymentModes paymentSelect = new PaymentModes() { PaymentModeId = -1, ModeName = "--Select--" };
            paymentList.Insert(0, paymentSelect);

            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
            ViewData["AirlineList"] = airLineList;//defaultProvider.GetAirlineList();
            ViewData["BankList"] = bankList;//defaultProvider.GetBankList();
            ViewData["PaymentModeList"] = paymentList;//defaultProvider.GetPaymentModeList();

            //ViewData["GDSList"] = defaultProvider.GetGDSInformationList();
            //ViewData["AirlineList"] = defaultProvider.GetAirlineList();
            //ViewData["BankList"] = defaultProvider.GetBankList();
            //ViewData["PaymentModeList"] = defaultProvider.GetPaymentModeList();

            var model = airlineCappingProvider.GetCappingDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AirlineCappingModel model,Int64 id)
        {
            model.cappingId = id;

            var gdsList = ent.ServiceProviders.ToList();
            ServiceProviders gdsSelect = new ServiceProviders() { ServiceProviderId = -1, ServiceProviderName = "--Select--" };
            gdsList.Insert(0, gdsSelect);

            var airLineList = ent.Airlines.ToList();
            Airlines airlineSelect = new Airlines() { AirlineId = -1, AirlineName = "--Select--" };
            airLineList.Insert(0, airlineSelect);

            var bankList = ent.Banks.ToList();
            Banks bankSelect = new Banks() { BankId = -1, BankName = "--Select--" };
            bankList.Insert(0, bankSelect);

            var paymentList = ent.PaymentModes.ToList();
            PaymentModes paymentSelect = new PaymentModes() { PaymentModeId = -1, ModeName = "--Select--" };
            paymentList.Insert(0, paymentSelect);

            ViewData["GDSList"] = gdsList;//defaultProvider.GetGDSInformationList();
            ViewData["AirlineList"] = airLineList;//defaultProvider.GetAirlineList();
            ViewData["BankList"] = bankList;//defaultProvider.GetBankList();
            ViewData["PaymentModeList"] = paymentList;//defaultProvider.GetPaymentModeList();

            //ViewData["GDSList"] = defaultProvider.GetGDSInformationList();
            //ViewData["AirlineList"] = defaultProvider.GetAirlineList();
            //ViewData["BankList"] = defaultProvider.GetBankList();
            //ViewData["PaymentModeList"] = defaultProvider.GetPaymentModeList();

            if (ModelState.IsValid)
            {
                airlineCappingProvider.Edit(model);
                return View(model);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            airlineCappingProvider.Delete(Id);
            return RedirectToAction("Index");


            //AirlineCappingModel model = new AirlineCappingModel();
            //int serviceproviderid = airlineCappingProvider.GetServiceProviderId(Id);
            //model.ServiceProviderId = serviceproviderid;
            //airlineCappingProvider.Delete(Id);
            //return RedirectToAction("Index", model.ServiceProviderId);
        }


        [HttpPost]
        public JsonResult FindAirline(string searchText, int maxResult)
        {
            var result = airlineCappingProvider.GetAirline(searchText, maxResult);
            return Json(result);
        }
        

    }
}
