using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter]
    public class BranchClassDealController : Controller
    {
        AgentClassDealProvider ser = new AgentClassDealProvider();
        public ActionResult Index()
        {
            AgentClassDealModel model = new AgentClassDealModel();
            model.AgentClassList = ser.GetAllBranchClassList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Index(int? branchClassId, int? masterDealId, int? hotelMasterDealId, int? busMasterDealId, int? mobileMasterDealId)
        {
            bool result = false;
            JsonResult jsonResultData = new JsonResult();
            try
            {
                TravelSession obj = null;
                if (Session["TravelPortalSessionInfo"] != null)
                    obj = (TravelSession)Session["TravelPortalSessionInfo"];

                result = ser.SaveBranchClassDeal(branchClassId, masterDealId, hotelMasterDealId, busMasterDealId,mobileMasterDealId, obj.AppUserId);
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
