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
    public class BranchDistributorAgentSettingController : Controller
    {
        //
        // GET: /Administrator/BranchDistributorAgentSetting/

        AgentSettingProvider provider = new AgentSettingProvider();

        [HttpGet]
        public ActionResult Index(int id, int? BOId)
        {
            AgentSettingModel model = new AgentSettingModel();

            model.MasterDealIdOfAirlines = provider.GetMasterDeal(id, 1) != null ? provider.GetMasterDeal(id, 1).MasterDealId : 0;
            model.MasterDealIdOfHotel = provider.GetMasterDeal(id, 2) != null ? provider.GetMasterDeal(id, 2).MasterDealId : 0;
            model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
            model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
            model.agentsettinglist = provider.GetAllSettingList();
            model.ServiceProviders = provider.GetAllActiveServiceProviders(id).ToList();
            model.Activeagentsettinglist = provider.GetAllActiveSettingForAgent(id);
            ViewData["agentClass"] = new SelectList(provider.GetAgentClass(), "AgentClassId", "AgentClassName");
            model.AgentClassId = provider.GetAgentClass(id);
            model.AgentName = provider.GetAgentName(id);
            model.branchofficeid = BOId;
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
            return RedirectToAction("AgentList", "BranchOfficeManagement", new { id = settingmodel.branchofficeid });
        }

        [NonAction]
        public void UpdataAgentSetting(int id, AgentSettingModel settingmodel, List<AgentServiceProviderNames> model, TravelSession obj)
        {
            provider.UpdateAgentwithAgentClass(settingmodel.AgentClassId, obj.AppUserId, id);
            if (settingmodel.MasterDealIdOfAirlines != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 1);
                if (result == true)
                {
                    provider.UpdateBranchDistributorAgentSettingDeal(settingmodel, 1, id);
                }
                else
                {
                    provider.SaveBranchDistributorAgentSettingDeal(settingmodel, id, 1, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDistributorAgentSettingDeal(id, 1);
            }

            if (settingmodel.MasterDealIdOfHotel != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 2);
                if (result == true)
                {
                    provider.UpdateBranchDistributorAgentSettingDeal(settingmodel, 2, id);
                }
                else
                {

                    provider.SaveBranchDistributorAgentSettingDeal(settingmodel, id, 2, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDistributorAgentSettingDeal(id, 2);
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
