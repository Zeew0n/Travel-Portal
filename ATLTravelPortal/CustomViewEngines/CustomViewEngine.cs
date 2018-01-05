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
using System.Data.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATLTravelPortal.CustomViewEngines
{
    public class CustomViewEngine : WebFormViewEngine
    {
        public CustomViewEngine()
            : base()
        {
            ViewLocationFormats = new[] { 
                "~/{0}.aspx",
                "~/{0}.ascx",
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx",
            };

            MasterLocationFormats = new[] {
                "~/{0}.master",
                "~/Shared/{0}.master",
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master",
            };

            PartialViewLocationFormats = ViewLocationFormats;
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {

            ViewEngineResult moduleResult = null;

            if (controllerContext.RouteData.Values.ContainsKey("module"))
            {
                string modulePartialName = FormatViewName(controllerContext, partialViewName);
                moduleResult = base.FindPartialView(controllerContext, modulePartialName, useCache);
                if (moduleResult != null && moduleResult.View != null)
                {
                    return moduleResult;
                }
                string sharedModulePartialName = FormatSharedViewName(controllerContext, partialViewName);
                moduleResult = base.FindPartialView(controllerContext, sharedModulePartialName, useCache);
                if (moduleResult != null && moduleResult.View != null)
                {
                    return moduleResult;
                }
            }

            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            ViewEngineResult moduleResult = null;

            if (controllerContext.RouteData.Values.ContainsKey("module"))
            {
                string moduleViewName = FormatViewName(controllerContext, viewName);
                moduleResult = base.FindView(controllerContext, moduleViewName, masterName, useCache);
                if (moduleResult != null && moduleResult.View != null)
                {
                    return moduleResult;
                }
                string sharedModuleViewName = FormatSharedViewName(controllerContext, viewName);
                moduleResult = base.FindView(controllerContext, sharedModuleViewName, masterName, useCache);
                if (moduleResult != null && moduleResult.View != null)
                {
                    return moduleResult;
                }
            }

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        private static string FormatViewName(ControllerContext controllerContext, string viewName)
        {
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");

            string module = controllerContext.RouteData.Values["module"].ToString();
            return "Modules/" + module + "/Views/" + controllerName + "/" + viewName;
        }

        private static string FormatSharedViewName(ControllerContext controllerContext, string viewName)
        {
            string module = controllerContext.RouteData.Values["module"].ToString();
            return "Modules/" + module + "/Views/Shared/" + viewName;
        }
    }
}
//////////By madan //////////http://stackoverflow.com/questions/2140208/how-to-set-a-default-route-to-an-area-in-mvc