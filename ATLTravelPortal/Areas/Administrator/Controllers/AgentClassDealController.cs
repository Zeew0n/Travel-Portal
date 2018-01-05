using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [ATLTravelPortal.SecurityAttributes.CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class AgentClassDealController : Controller
    {
        AgentClassDealProvider ser = new AgentClassDealProvider();       

        public ActionResult Index()
        {
            AgentClassDealModel model = new AgentClassDealModel();
            model.AgentClassList = ser.GetAllAgentClassList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Index(int? agentClassId, int? masterDealId, int? hotelMasterDealId)
        {
            bool result = false;
            JsonResult jsonResultData = new JsonResult();
            try
            {
                TravelSession obj = null;
                if (Session["TravelPortalSessionInfo"] != null)
                    obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = ser.SaveAgentClassDeal(agentClassId, masterDealId, hotelMasterDealId, obj.AppUserId);
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
