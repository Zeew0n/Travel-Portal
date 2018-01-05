using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using EncryptionMVC.Security.Encryption.QueryString;
using System.Configuration;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class SignUpAgentsController : PartialViewRendererController
    {
        //
        // GET: /Administrator/SignUpAgents/
        AgencyProvider ser = new AgencyProvider();
        AgentManagementRepository _rep = new AgentManagementRepository();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        private string mKey = "!#$a54?3!#$a54?3";

        public ActionResult Index(int? page)
        {
            AgencyModel model = new AgencyModel();
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            model.AgencyList = ser.ListSignUpAgents().ToPagedList(currentPageIndex, defaultPageSize); ;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AgencyModel model)
        {
            try
            {
                int currentPageIndex = 1;
                int defaultPageSize = 30;
                model.AgencyList = ser.GetSignUpAgentSearchResult(model.AgencyName.Trim()).ToPagedList(currentPageIndex, defaultPageSize);

                return View(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id, FormCollection fc, List<AgentBankModel> AgentBankModel)
        {
            AgencyModel model = new AgencyModel();
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model = ser.SignUpAgentsDetail(id);
            model.CreatedBy = ts.AppUserId;
            model.CreatedbyUser = ts.AppUserId;
            try
            {
               int[] ChkProductId = new int[1] { 1 };
               int agentID = ser.Create(model, AgentBankModel, ChkProductId, fc);
               ser.UpdateSignUpAgent(id, agentID);
               ser.Approve(id);

               SecureQueryString qs = new SecureQueryString(mKey);
               model.domainname= UrlHelperExtensions.AbsolutePath(HttpContext.Request.Url.OriginalString);
               model.UrlLinktoSendLocal = UrlHelperExtensions.AbsolutePath(HttpContext.Request.Url.OriginalString);//ConfigurationManager.AppSettings["LoginPageUrlLocal"];
               model.UrlLinktoSendLive = "https://agent.arihantholidays.com/"; //ConfigurationManager.AppSettings["LoginPageUrlLive"];
               string htmlContent = RenderPartialViewToString("EMailTemplate", model);
               var result = ser.SendEmail(htmlContent, id, "Agency Confirmation Mail");
               return RedirectToAction("Index", "AgentManagement");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Detail", new { id = id });
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        ser.SignUpAgentDelete(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message;
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult Detail(int id)
        {
            AgencyModel model = new AgencyModel();
            model = ser.SignUpAgentsDetail(id);
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            try
            {

                ser.DeleteSignUpAgents(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Cannot delete this record";
                return RedirectToAction("Index");
            }
        }


    }
}
