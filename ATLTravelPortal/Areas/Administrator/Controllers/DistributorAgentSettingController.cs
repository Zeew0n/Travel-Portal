using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    // [PermissionDetails(View = "Index", Edit = "UpdataAgentSetting", Order = 2)]
    public class DistributorAgentSettingController : Controller
    {
        AgentSettingProvider provider = new AgentSettingProvider();

        [HttpGet]
        public ActionResult Index(int id)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            AgentSettingModel model = new AgentSettingModel();

            model.MasterDealIdOfAirlines = Convert.ToInt32(provider.GetDistributorsAgentMasterDeal(id, 1) != null ? provider.GetDistributorsAgentMasterDeal(id, 1).DistributorDealMasterId : 0);
            model.MasterDealIdOfHotel = Convert.ToInt32(provider.GetDistributorsAgentMasterDeal(id, 2) != null ? provider.GetDistributorsAgentMasterDeal(id, 2).DistributorDealMasterId : 0);
            model.MasterDealIdOfBus = Convert.ToInt32(provider.GetDistributorsAgentMasterDeal(id, 4) != null ? provider.GetDistributorsAgentMasterDeal(id, 4).DistributorDealMasterId : 0);
            model.MasterDealIdOfMobile = Convert.ToInt32(provider.GetDistributorsAgentMasterDeal(id, 3) != null ? provider.GetDistributorsAgentMasterDeal(id, 3).DistributorDealMasterId : 0);

            model.MasterDealNameListOfAirlines = provider.GetAllDistributorAgentDealListOfAirlines(obj.LoginTypeId);
            model.MasterDealNameListOfHotels = provider.GetAllDistributorAgentDealListOfHotels(obj.LoginTypeId);
            model.MasterDealNameListOfBus = provider.GetAllDistributorAgentDealListOfBus(obj.LoginTypeId);
            model.MasterDealNameListOfMobile = provider.GetAllDistributorAgentDealListOfMobile(obj.LoginTypeId);

            model.agentsettinglist = provider.GetAllSettingList();
            model.ServiceProviders = provider.GetAllActiveServiceProviders(id).ToList();
            model.Activeagentsettinglist = provider.GetAllActiveSettingForAgent(id);
            ViewData["agentClass"] = new SelectList(provider.GetAgentClass(), "AgentClassId", "AgentClassName");
            model.AgentClassId = provider.GetAgentClass(id);
            model.AgentName = provider.GetAgentName(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int id, AgentSettingModel settingmodel)
        {
            try
            {
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                UpdataAgentSetting(id, settingmodel, settingmodel.ServiceProviders, obj);
                TempData["InfoMessage"] = "Agent Setting Updated Successfully ";
            }
            catch (Exception ex)
            {
                TempData["InfoMessage"] = ex.Message;
            }
            return RedirectToAction("Index", "DistributorAgentManagement");
        }

        [NonAction]
        public void UpdataAgentSetting(int id, AgentSettingModel settingmodel, List<AgentServiceProviderNames> model, TravelSession obj)
        {
            provider.UpdateAgentwithAgentClass(settingmodel.AgentClassId, obj.AppUserId, id);
            if (settingmodel.MasterDealIdOfAirlines != 0)
            {
                bool result = provider.CheckIFDealExistForBranchsDistributor(id, 1);
                if (result == true)
                {
                    provider.UpdateBranchDistributorDeal(settingmodel, 1, id);
                }
                else
                {
                    provider.SaveBranchDistributorAgentDeal(settingmodel, id, 1, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAir_DistributorAgentDealAssociations(id, 1);
            }

            if (settingmodel.MasterDealIdOfHotel != 0)
            {
                bool result = provider.CheckIFDealExistForBranchsDistributor(id, 2);
                if (result == true)
                {
                    provider.UpdateBranchDistributorDeal(settingmodel, 2, id);
                }
                else
                {

                    provider.SaveBranchDistributorAgentDeal(settingmodel, id, 2, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAir_DistributorAgentDealAssociations(id, 2);
            }

            if (settingmodel.MasterDealIdOfBus != 0)
            {
                bool result = provider.CheckIFDealExistForBranchsDistributor(id, 4);
                if (result == true)
                {
                    provider.UpdateBranchDistributorDeal(settingmodel, 4, id);
                }
                else
                {

                    provider.SaveBranchDistributorAgentDeal(settingmodel, id, 4, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAir_DistributorAgentDealAssociations(id, 4);
            }


            if (settingmodel.MasterDealIdOfMobile != 0)
            {
                bool result = provider.CheckIFDealExistForBranchsDistributor(id, 3);
                if (result == true)
                {
                    provider.UpdateBranchDistributorDeal(settingmodel, 3, id);
                }
                else
                {

                    provider.SaveBranchDistributorAgentDeal(settingmodel, id, 3, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAir_DistributorAgentDealAssociations(id, 3);
            }


            /////////////////Begin Updating Agent Setting Lists /////////////////////////////////////////////
            provider.DeleteDistributorAgentSetting(id); //// First delete all agent setting///
            if (settingmodel.ChkSettingId != null)    //////////  Checking if product is other than Ticketing
            {
                List<int> AgentSettingIds = new List<int>();
                foreach (int sid in settingmodel.ChkSettingId)
                {
                    AgentSettingIds.Add(sid);
                }

                provider.SaveAgentSetting(AgentSettingIds, id);
            }
            //// Get Selected Account Setting Of Agent
            if (model.Count != 0)
            {
                model = model.Where(xx => xx.ServiceProviderId != 0).ToList();
                provider.DeleteServiceProviderAccountSetting(id);
                provider.SaveServiceProviderAccountSetting(model, obj.AppUserId, id);
            }
        }

    }
}
