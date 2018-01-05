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
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;
using System.Web.Routing;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;

namespace ATLTravelPortal.CustomAttribute
{
    public class PermissionDetailsAttribute : FilterAttribute, IActionFilter
    {

        //this property gets the permissiondetail required to access the particular action as controller attribute
        public String Add { get; set; }
        public String Edit { get; set; }
        public String View { get; set; }
        public String Delete { get; set; }
        public string Details { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }


        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="filterContext"></param>

        private PermissionDetailsAttribute _authorizationattribute;
        private static string _ControllerName { get; set; }
        private static string _ActionName { get; set; }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="filterContext"></param>
        /// 
        UserRolePrevilageProvider _role = new UserRolePrevilageProvider();        /// TODO :Connecting more precise way with database

        /// Begin of Metho for ActionExecution /////////

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            _ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString();
            _ActionName = filterContext.ActionDescriptor.ActionName.ToString();

            ///// Get All listed attribute from controller
            if (_authorizationattribute == null)
            {
                _authorizationattribute = (PermissionDetailsAttribute)filterContext.ActionDescriptor.
                                                            ControllerDescriptor.
                                                            GetCustomAttributes(
                                                                typeof(PermissionDetailsAttribute), false).
                                                            Single();
            }
            /////////  First Check user authentication //////////////////////
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var username = HttpContext.Current.User.Identity.Name;
                if (username != "admin")
                {
                    
                   string _AreaName = filterContext.RouteData.DataTokens["area"].ToString();
                  
                    var obj = (TravelSession)HttpContext.Current.Session["TravelPortalSessionInfo"];

                    int Productid = _role.CheckUserProductId(_AreaName, obj.ProductId); //checking dynamically 
                    List<RolePrivilageModel> userPermissionDetails = _role.GetRolePrivilageBaseonUser(obj.AppUserId, Productid).Where(uu => uu.ControllerName == _ControllerName && uu.isExist == true).ToList();
                    bool isValid = false;

                    foreach (var item in userPermissionDetails)
                    {
                        if (item.ActionTypeName == "View" && _ActionName == _authorizationattribute.View ||
                            item.ActionTypeName == "Add" && _ActionName == _authorizationattribute.Add ||
                           item.ActionTypeName == "Edit" && _ActionName == _authorizationattribute.Edit ||
                           item.ActionTypeName == "Delete" && _ActionName == _authorizationattribute.Delete ||
                           item.ActionTypeName == "Details" && _ActionName == _authorizationattribute.Details ||
                            item.ActionTypeName == "Custom1" && _ActionName == _authorizationattribute.Custom1 ||
                            item.ActionTypeName=="Custom2" && _ActionName==_authorizationattribute.Custom2
                            )
                            isValid = true;
                    }

                    var isAjaxCall = filterContext.HttpContext.Request.IsAjaxRequest();
                    var res = filterContext.HttpContext.Response;
                    if (isValid == false)
                    {
                        if (isAjaxCall)
                        {
                            res.StatusCode = 403; //401:Unauthorized, 403:Forbidden
                            res.End();
                        }
                        System.Web.Routing.RouteValueDictionary rd = new System.Web.Routing.RouteValueDictionary(new { Controller = "Errors", Action = "AccessDenied", area = (string)null });
                        filterContext.Result = new RedirectToRouteResult(rd);
                    }
                }

            }
            else
            {
                System.Web.Routing.RouteValueDictionary rd = new System.Web.Routing.RouteValueDictionary(new { Controller = "account", Action = "logon", area = (string)null });
                filterContext.Result = new RedirectToRouteResult(rd);
            }
        }

    }
}