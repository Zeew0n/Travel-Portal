using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using System.Data.SqlClient;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Repository
{
    public class GeneralRepository
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public IEnumerable<Core_GetAvailableBalanceBranch_Result> GetAvailableBalanceForBranchOffice(int brancofficeid)
        {
            return ent.Core_GetAvailableBalanceBranch(brancofficeid);
        }

        public IEnumerable<Core_GetAvailableBalanceDistrubutor_Result> GetAvailableBalanceForDistributor(int distributorid)
        {
            return ent.Core_GetAvailableBalanceDistrubutor(distributorid);
        }



        public aspnet_Users GetUserinfo(Guid ID)
        {
            return ent.aspnet_Users.SingleOrDefault(u => u.UserId == ID);
        }
        public aspnet_UsersAgentRelation GetRelationInfo(Guid userid)
        {
            return ent.aspnet_UsersAgentRelation.SingleOrDefault(u => u.UserId == userid);
        }
        public Agents GetAgentInfo(int ID)
        {
            return ent.Agents.SingleOrDefault(u => u.AgentId == ID);
        }
        public UsersDetails GetUserDetails(Guid ID)
        {
            return ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
        }

        public static int LoggedUserId()
        {
            TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
            return session.AppUserId;
        }
        public static int LoggedAgentId()
        {
            TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
            return session.LoginTypeId;
        }

        public List<int> GetUserProductId(int userid)
        {
            List<int> ids = new List<int>();
            var userproductidlist = ent.Core_UserProducts.Where(xx => xx.UserId == userid).ToList();
            if (userproductidlist != null || userproductidlist.Count() != 0)
            {
                foreach (var item in userproductidlist)
                {
                    ids.Add(item.ProductId);
                }
                return ids;
            }
            else
                return null;
        }

        public bool ValidateUser(string userName, string password)
        {

            System.Data.Objects.ObjectParameter Parm_result = new System.Data.Objects.ObjectParameter("Result", false);
            ent.CORE_CheckLoginForUser(userName, 1, "admin", Parm_result);
            if ((Boolean)Parm_result.Value == false)
                return false;


            if (Membership.ValidateUser(userName, password) == true)
                return true;
            else return false;
        }
        //check user
        public bool ValidateUnameAndPassword(string userName, string password, out Guid userId)
        {

            aspnet_Users au = CheckUser(userName, password);
            userId = new Guid();
            if (au == null)
                return false;
            else
            {
                userId = au.UserId;
                return true;
            }

        }
        //check user
        public aspnet_Users CheckUser(string userName, string password)
        {
            aspnet_Users au = ent.aspnet_Users.Include("aspnet_Membership").Where(uu => uu.UserName == userName && uu.aspnet_Applications.ApplicationName == Membership.ApplicationName).FirstOrDefault();

            if (au != null)
                return au;
            else
                return null;
        }
        public void Save_LoginHistory(LoginHistories lgh)
        {
            ent.AddToLoginHistories(lgh);
            ent.SaveChanges();
        }
        //Hem 
        public static DateTime CurrentDate()
        {
            DateTime CurrentDate = DateTime.Now.Date;
            return CurrentDate;
        }
        public static DateTime CurrentDateTime()
        {
            DateTime CurrentDate = DateTime.UtcNow;
            return CurrentDate;
        }
        public enum AppStatusName
        {
            Deleted,
        }
        public static IEnumerable<SelectListItem> GeneralStatus()
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "0" });
            ddlList.Add(new SelectListItem { Text = "Active", Value = "2" });
            ddlList.Add(new SelectListItem { Text = "Blocked", Value = "3" });
            return ddlList;
        }

        public static int LogedUserId()
        {
            TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
            return session.AppUserId;
        }
        public void ExportData(IEnumerable<dynamic> List, FormCollection fc, string FileName)
        {
            ATL.Core.Exporter.ExportData exp = new ATL.Core.Exporter.ExportData();
            exp.FileName = FileName;

            if (fc["ExportTypeExcel.x"] != null)
            {
                exp.Export(List, 1);
            }
            else if (fc["ExportTypeCSV.x"] != null)
            {
                exp.Export(List, 4);
            }
            else if (fc["ExportTypeWord.x"] != null)
            {
                exp.Export(List, 3);
            }
            else if (fc["ExportTypePdf.x"] != null)
            {
                exp.Export(List, 2);
            }


        }
        public DateTime LocalDateTime(DateTime UtcDateTime)
        {
            TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(session.TimeZoneId);
            DateTime loclTime = TimeZoneInfo.ConvertTimeFromUtc(UtcDateTime, tzi);
            return loclTime;
        }
        public DateTime UtcDateTime(DateTime UserDateTime)
        {
            TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelSessionInfo"];
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(session.TimeZoneId);
            DateTime loclTime = TimeZoneInfo.ConvertTimeToUtc(UserDateTime, tzi);
            return loclTime;
        }
        public static string getEncryptionKey = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"];
        public static ActionResponse CatchException(Exception ex = null)
        {
            ActionResponse _res = new ActionResponse();
            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Source != null)
                    {
                        if (ex.InnerException.Source == ".Net SqlClient Data Provider")
                        {

                            SqlException sql = (SqlException)ex.InnerException;
                            _res.ErrNumber = sql.Number;
                            _res.ActionMessage = SqlErrorMessage(sql);
                            _res.ErrType = "2";
                            _res.ResponseStatus = true;
                        }
                        else
                        {
                            _res.ErrNumber = 50000;
                            _res.ActionMessage = Resources.SQLErrorMessage.Error;
                            _res.ErrType = "3";
                            _res.ResponseStatus = true;
                        }
                    }
                    else
                    {
                        _res.ErrNumber = 50000;
                        _res.ActionMessage = Resources.SQLErrorMessage.Error;
                        _res.ErrType = "3";
                        _res.ResponseStatus = true;
                    }

                }
                else
                {
                    _res.ErrNumber = 50000;
                    _res.ActionMessage = Resources.SQLErrorMessage.Error;
                    _res.ErrType = "3";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ErrNumber = 1005;
                _res.ActionMessage = Resources.Message.UnCompleteForm;
                _res.ErrType = "3";
                _res.ResponseStatus = true;
            }
            return _res;
        }

        public static string SqlErrorMessage(SqlException ex)
        {
            if (ex.Number == 50000)
                return ex.Message;
            else if (ex.Number == 241)
                return Resources.SQLErrorMessage.Error241;
            else if (ex.Number == 242)
                return Resources.SQLErrorMessage.Error242;
            else if (ex.Number == 245)
                return Resources.SQLErrorMessage.Error245;
            else if (ex.Number == 2627)
                return Resources.SQLErrorMessage.Error2627;
            else if (ex.Number == 8152)
                return Resources.SQLErrorMessage.Error8152;
            else if (ex.Number == 547)
                return Resources.SQLErrorMessage.Error547;
            else
                return Resources.SQLErrorMessage.Error;
        }
        public static ActionResponse ActionMessage
        {
            get { return (ActionResponse)HttpContext.Current.Session["ActionMessage"]; }
            set { HttpContext.Current.Session["ActionMessage"] = value; }
        }
        public static string getIPAddress
        {
            get
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
        }
        
    }

}