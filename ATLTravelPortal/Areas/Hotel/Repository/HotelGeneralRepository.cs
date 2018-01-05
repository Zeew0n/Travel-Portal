using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    [CheckSessionFilter(Order = 1)]
    public class HotelGeneralRepository
    {
        public static string sendQuotation(string Email,string Subject,string Body,string Message,bool IsPreview)
        {
           
            int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
            int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var OutPutHTML= new System.Data.Objects.ObjectParameter("OutputHTML",typeof(string));
            _ent.Core_SendEmailQuatation(LoggedAgentId, Email, Subject, Message, "HTL", Body, IsPreview, LoggedUserId, OutPutHTML);
            return OutPutHTML.Value.ToString();
        }
        public static void sendEmial(string RecipientsEmail, string CCEmail, string BCCEmail, string Subject, string Body,string BodyFormat,string EmailImportent)
        {
            int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
            int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var OutPutHTML = new System.Data.Objects.ObjectParameter("OutputHTML", typeof(string));
            _ent.CORE_SendEmails(RecipientsEmail, CCEmail, BCCEmail, Subject, Body, BodyFormat, EmailImportent);
        }
        public static void sendBookingRequest(string Subject, string Body)
        {
            int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
            int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            string emailAdd = _ent.Agents.Where(x => x.AgentId == LoggedAgentId).FirstOrDefault().Email;
            _ent.Core_SendEmailForBookingRequest(emailAdd, Subject, Body, "HTL");
        }
        public static string getQutationTemplate()
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var msg = _ent.Core_EmailTemplates.Where(x => x.TamplateFor == "HTL").FirstOrDefault();
            if (msg != null)
                return msg.HTMLContains;
            else
            return "";
        }
        public static void SetRequestPageRow()
        {
            try
            {
                if (HttpContext.Current.Request.QueryString["pageRow"] != null)
                {
                    int pageRow = Convert.ToInt32(HttpContext.Current.Request.QueryString["pageRow"]);
                    DefaultPageSize = pageRow <= 0 ? DefaultPageSize : pageRow;
                }
            }
            catch
            {
                //do nothing
            }
        }
        public static bool ValidateEmail(string email)
        {
            string _emailPatt = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
             @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
             @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_emailPatt, System.Text.RegularExpressions.RegexOptions.Singleline);
            var x = (regexp.IsMatch(email));
            return x;
        }
        public static string getIPAddress()
        {
            string szRemoteAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string szXForwardedFor = HttpContext.Current.Request.ServerVariables["X_FORWARDED_FOR"];
            string szIP = "";

            if (szXForwardedFor == null)
            {
                szIP = szRemoteAddr.Trim();
            }
            else
            {
                szIP = szXForwardedFor;
                if (szIP.IndexOf(",") > 0)
                {
                    string[] arIPs = szIP.Split(',');

                    //foreach (string item in arIPs)
                    //{
                    //    if (!isPrivateIP(item))
                    //    {
                    //        return item;
                    //    }
                    //}
                    szIP = arIPs[0].Trim();
                }
            }
            return szIP;
        }
       
        public static int DefaultPageSize = 15;
    }
}