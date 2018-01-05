using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Models;
using ATLTravelPortal.Repository;
using System.IO;
using Resources;
using System.Web.UI;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Controllers
{
    public class PageController : Controller
    {
        GeneralRepository _generalRepo = new GeneralRepository();
        //
        // GET: /Page/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AvailableBalanceHeader()
        {
            try
            {
                var obj = SessionStore.GetTravelSession(); ;
                if (obj != null)
                {
                    var AvailableBalanceResult = _generalRepo.GetAvailableBalanceForBranchOffice(obj.LoginTypeId).ToList();
                    var Balanceviewmodel = new PageViewModel.AvailableBalanceViewModel();
                    /// For NPR balance
                    ///  //Currency
                    Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
                    Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
                    Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;

                    /// For USD balance
                    Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
                    Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
                    Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

                    /// For INR balance
                    //Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
                    //Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
                    //Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


                    if (Balanceviewmodel.CurrentBalanceNPR == null)
                        Balanceviewmodel.CurrentBalanceNPR = 0;


                    double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
                    if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                        Balanceviewmodel.isLowBalanceNPR = true;
                    else
                        Balanceviewmodel.isLowBalanceNPR = false;

                    double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
                    if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                        Balanceviewmodel.isLowBalanceUSD = true;
                    else
                        Balanceviewmodel.isLowBalanceUSD = false;

                    //double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
                    //if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                    //    Balanceviewmodel.isLowBalanceINR = true;
                    //else
                    //    Balanceviewmodel.isLowBalanceINR = false;


                    return PartialView("AvailableBalanceHeader", Balanceviewmodel);
                }
                else
                    return PartialView("AvailableBalanceHeader");
            }
            catch
            {
                return RedirectToAction("LogOn", "Account");
            }

        }





        [ChildActionOnly]
        public ActionResult AvailableBalanceHeaderDistributor()
        {
            try
            {
                var obj = SessionStore.GetTravelSession(); ;
                if (obj != null)
                {
                    var AvailableBalanceResult = _generalRepo.GetAvailableBalanceForDistributor(obj.LoginTypeId).ToList();
                    var Balanceviewmodel = new PageViewModel.AvailableBalanceViewModel();
                    /// For NPR balance
                    ///  //Currency
                    Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
                    Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
                    Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;

                    /// For USD balance
                    Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
                    Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
                    Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

                    /// For INR balance
                    //Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
                    //Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
                    //Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


                    if (Balanceviewmodel.CurrentBalanceNPR == null)
                        Balanceviewmodel.CurrentBalanceNPR = 0;


                    double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
                    if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                        Balanceviewmodel.isLowBalanceNPR = true;
                    else
                        Balanceviewmodel.isLowBalanceNPR = false;

                    double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
                    if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                        Balanceviewmodel.isLowBalanceUSD = true;
                    else
                        Balanceviewmodel.isLowBalanceUSD = false;

                    //double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
                    //if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                    //    Balanceviewmodel.isLowBalanceINR = true;
                    //else
                    //    Balanceviewmodel.isLowBalanceINR = false;


                    return PartialView("AvailableBalanceHeaderDistributor", Balanceviewmodel);
                }
                else
                    return PartialView("AvailableBalanceHeaderDistributor");
            }
            catch
            {
                return RedirectToAction("LogOn", "Account");
            }

        }





   
       


     

    }

}
