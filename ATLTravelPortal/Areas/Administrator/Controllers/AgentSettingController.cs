using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "UpdataAgentSetting", Order = 2)]
    public class AgentSettingController : Controller
    {
        AgentSettingProvider provider = new AgentSettingProvider();

        [HttpGet]
        public ActionResult Index(int id)
        {
            AgentSettingModel model = new AgentSettingModel();


            model.MasterDealIdOfAirlines = provider.GetMasterDeal(id, 1) != null ? provider.GetMasterDeal(id, 1).MasterDealId : 0;
            model.MasterDealIdOfHotel = provider.GetMasterDeal(id, 2) != null ? provider.GetMasterDeal(id, 2).MasterDealId : 0;
            model.MasterDealIdOfBus = provider.GetMasterDeal(id, 4) != null ? provider.GetMasterDeal(id, 4).MasterDealId : 0;
            model.MasterDealIdOfMobile = provider.GetMasterDeal(id, 3) != null ? provider.GetMasterDeal(id, 3).MasterDealId : 0;

            model.MasterDealNameListOfAirlines = provider.GetAgentDealListOfAirlines();
            model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
            model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
            model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

            model.agentsettinglist = provider.GetAllAdminSettingList();
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
                TempData["InfoMessage"] = "Agent Setting Successfully updated";
            }
            catch(Exception ex)
            {
                TempData["InfoMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        public void UpdataAgentSetting(int id, AgentSettingModel settingmodel,List<AgentServiceProviderNames> model, TravelSession obj)
        {
            provider.UpdateAgentwithAgentClass(settingmodel.AgentClassId, obj.AppUserId, id);
            if (settingmodel.MasterDealIdOfAirlines != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 1);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 1, id);
                }
                else
                {
                    provider.SaveAgentDeal(settingmodel, id, 1, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 1);
            }

            if (settingmodel.MasterDealIdOfHotel != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 2);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 2, id);
                }
                else
                {

                    provider.SaveAgentDeal(settingmodel, id, 2, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 2);
            }

            if (settingmodel.MasterDealIdOfBus != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 4);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 4, id);
                }
                else
                {

                    provider.SaveAgentDeal(settingmodel, id, 4, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 4);
            }

            if (settingmodel.MasterDealIdOfMobile != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 3);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 3, id);
                }
                else
                {

                    provider.SaveAgentDeal(settingmodel, id, 3, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 4);
            }

            /////////////////Begin Updating Agent Setting Lists /////////////////////////////////////////////
            provider.DeleteAgentSetting(id); //// First delete all agent setting///
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
