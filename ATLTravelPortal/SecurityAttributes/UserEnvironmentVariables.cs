#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AgentManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EnCryptDecrypt;
using TravelPortalEntity;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;


namespace ATLTravelPortal.SecurityAttributes
{
    public class UserEnvironmentVariables
    {

        GeneralRepository generalProvider = new GeneralRepository();
        public void SetLogOn(Guid userId, bool rememberMe)
        {
            if (rememberMe == true)
            {
                //set cookie
                HttpContext.Current.Response.Cookies["BackOfficeCookies"].Value = CryptorEngine.Encrypt(userId.ToString(), true);
                HttpContext.Current.Response.Cookies["BackOfficeCookies"].Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                HttpContext.Current.Session["TravelPortalSession"] = CryptorEngine.Encrypt(userId.ToString(), true);
            }
            SerEnvVariables();
        }

        public void SerEnvVariables()
        {
            if (HttpContext.Current.Session["TravelPortalSession"] != null)
            {
                if (HttpContext.Current.Session["TravelPortalSessionInfo"] == null)
                {
                    string userId = HttpContext.Current.Session["TravelPortalSession"].ToString();
                    DecryptUserId(userId);
                }
            }
            else if (HttpContext.Current.Request.Cookies["BackOfficeCookies"] != null)
            {
                if (HttpContext.Current.Session["TravelPortalSessionInfo"] == null)
                {
                    string userId = HttpContext.Current.Request.Cookies["BackOfficeCookies"].Value.ToString();
                    DecryptUserId(userId);
                }
            }


        }

        public void DecryptUserId(string userId)
        {
            userId = CryptorEngine.Decrypt(userId.ToString(), true);
            Guid gid = new Guid(userId);
            SetSessionsObject(gid);
        }
        // ***********************************************************************************
        ////// Setting of session For Specific user login
        // ***********************************************************************************
        public void SetSessionsObject(Guid userId)
        {
            Agents ainfo = null;
            TravelSession obj = new TravelSession();
            aspnet_Users tu = GetUserInfo(userId);
            try
            {
                ainfo = GetAgentInfo(tu.UserId);
            }
            catch (Exception)
            {
            }

            UsersDetails udinfo = GetUserDetailsInfo(userId);
            if (udinfo.UserTypeId == 5)
            {
                BranchOfficeManagementProvider branchOfficeManagementProvider = new BranchOfficeManagementProvider();
                View_BranchDetails branchOffices = branchOfficeManagementProvider.GetBranchOfficeByUserId(userId);

                obj.LoginTypeName = branchOffices.BranchOfficeName;
                obj.AgentCode = branchOffices.BranchOfficeName;
                obj.LoginTypeId = branchOffices.BranchOfficeId;
            }
            else if (udinfo.UserTypeId == 6)
            {
                DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
                View_DistributorDetails distributors = distributorManagementProvider.GetDistributorByUserId(userId);

                obj.LoginTypeName = distributors.DistributorName;
                obj.AgentCode = distributors.DistributorName;
                obj.LoginTypeId = distributors.DistributorId;
            }
            else if (udinfo.UserTypeId == 7)
            {
                obj.Id = userId;
                obj.LoginName = tu.UserName;
                obj.AppUserId = udinfo.AppUserId;
                obj.UserTypeId = udinfo.UserTypeId;
                obj.ProductId = GetUserProductId(obj.AppUserId);
            }

            obj.Id = userId;         
            obj.LoginName = tu.UserName;
            obj.AppUserId = udinfo.AppUserId;
            obj.UserTypeId = udinfo.UserTypeId;
            obj.ProductId = GetUserProductId(obj.AppUserId);
    
            HttpContext.Current.Session["TravelPortalSessionInfo"] = obj;
        }
        #region
        // ***********************************************************************************
        //Database Connection Region for retrieving various Info to store in session /////
        // ***********************************************************************************

        public aspnet_Users GetUserInfo(Guid userId)
        {
            aspnet_Users tu = generalProvider.GetUserinfo(userId);
            return tu;
        }
        public Agents GetAgentInfo(Guid userId)
        {
            Agents tu = new Agents();
            aspnet_UsersAgentRelation uar = generalProvider.GetRelationInfo(userId);
            if (uar != null)
                tu = generalProvider.GetAgentInfo(uar.AgentId);
            return tu;
        }

        ///   TODO :Retrieve Product Id To Store in Session ///////
        ///   Table Name :  CORE_UserProducts  /////////////////

        public UsersDetails GetUserDetailsInfo(Guid userId)
        {
            return generalProvider.GetUserDetails(userId);
        }

        public List<int> GetUserProductId(int userid)
        {
            List<int> ids=new List<int>();
            ids = generalProvider.GetUserProductId(userid);
            return ids;
        }

        #endregion
        // ***********************************************************************************

        public void SetLogOut()
        {
            if (HttpContext.Current.Session["TravelPortalSession"] != null)
            {
                HttpContext.Current.Session["TravelPortalSession"] = HttpContext.Current.Session["TravelPortalSession"] = null;
                HttpContext.Current.Session.Abandon();
            }
            if (HttpContext.Current.Request.Cookies["BackOfficeCookies"] != null)
            {
                HttpContext.Current.Response.Cookies["BackOfficeCookies"].Expires = DateTime.Now.AddYears(-1);
            }
            UnsetUserEnvironmentValues();
        }

        public void UnsetUserEnvironmentValues()
        {
            if (HttpContext.Current.Session["TravelPortalSessionInfo"] != null)
            {
                HttpContext.Current.Session["TravelPortalSessionInfo"] = null;
            }
        }

        // *************************************************************************
        ///    To check if the user is logged on or not  /////////////////////////
        // *************************************************************************

        public bool isUserLoggedOn()
        {
            bool flag = false;
            if (HttpContext.Current.Session["TravelPortalSession"] != null)
            {
                if (HttpContext.Current.Session["TravelPortalSessionInfo"] == null)
                {
                    string userId = CryptorEngine.Decrypt(HttpContext.Current.Session["TravelPortalSession"].ToString(), true);
                    Guid gid = new Guid(userId);
                    SetSessionsObject(gid);
                }
                return true; ;
            }

            else if (HttpContext.Current.Request.Cookies["BackOfficeCookies"] != null)
            {
                if (HttpContext.Current.Session["TravelPortalSessionInfo"] == null)
                {
                    string userId = CryptorEngine.Decrypt(HttpContext.Current.Request.Cookies["BackOfficeCookies"].Value.ToString(), true);
                    Guid gid = new Guid(userId);
                    SetSessionsObject(gid);
                }
                return true;
            }

            else
                return flag;
        }
        // ***********************************************************************************
    }
}