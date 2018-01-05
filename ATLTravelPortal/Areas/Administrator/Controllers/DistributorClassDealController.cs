using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    //[ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Index", Order = 2)]
    public class DistributorClassDealController : Controller
    {
        AgentClassDealProvider ser = new AgentClassDealProvider();

        public ActionResult Index()
        {
            AgentClassDealModel model = new AgentClassDealModel();
            TravelSession obj = null;
            if (Session["TravelPortalSessionInfo"] != null)
                obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.AgentClassList = ser.GetAllDistributorAgentClassList(obj.LoginTypeId);
            return View(model);
        }

        [HttpPost]
        public JsonResult Index(int? agentClassId, int? masterDealId, int? hotelMasterDealId, int? busMasterDealId, int? mobileMasterDealId)
        {
            bool result = false;
            JsonResult jsonResultData = new JsonResult();
            try
            {
                TravelSession obj = null;
                if (Session["TravelPortalSessionInfo"] != null)
                    obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = ser.SaveAgentDistributorClassDeal(agentClassId, masterDealId, hotelMasterDealId, busMasterDealId,mobileMasterDealId, obj.AppUserId, obj.LoginTypeId);
                jsonResultData.Data = result;
            }
            catch (Exception ex)
            {
                result = false;
                jsonResultData.Data = result;
            }
            return jsonResultData;
        }
    }
}
