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
using System.Web.Mvc;


namespace ATLTravelPortal.SecurityAttributes
{
    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext cc = HttpContext.Current;
            // ControllerBase bb = filterContext.Controller;
            UserEnvironmentVariables us = new UserEnvironmentVariables();

            if (!us.isUserLoggedOn())
            {
                string val = cc.Request.Url.PathAndQuery;
                string urlHelper = new UrlHelper(filterContext.RequestContext).RouteUrl(new { controller = "Account", action = "LogOn", ReturnUrl = val ,area="" });
                if ((filterContext.HttpContext.Request.IsAjaxRequest()) || (cc.Response.StatusCode == 302) || (cc.Request.Headers["X-Requested-With"] == "XMLHttpRequest"))
                {
                    cc.Response.Clear();
                    cc.Response.StatusCode = Convert.ToInt32(401); //401:Unauthorized
                    cc.Response.End();
                }
                else
                {
                    cc.Response.Redirect(urlHelper);
                }
              
            }
            else
            {
            
                // Do nothing
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}