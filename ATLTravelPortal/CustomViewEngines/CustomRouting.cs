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
    public static class CustomRouting
    {
        public static void MapModules(this RouteCollection routes, string url, string rootNamespace, string[] modules)
        {
            Array.ForEach(modules, module =>
            {
                Route route = new Route("{module}/" + url, new MvcRouteHandler());
                route.Constraints = new RouteValueDictionary(new { module });
                string areaNamespace = rootNamespace + ".Modules." + module + ".Controllers";
                route.DataTokens = new RouteValueDictionary(new { namespaces = new string[] { areaNamespace } });
                route.Defaults = new RouteValueDictionary(new { action = "Index", controller = "Home", id = "" });
                routes.Add(route);
            });
        }

        public static void MapRootModule(this RouteCollection routes, string url, string rootNamespace, object defaults)
        {
            Route route = new Route(url, new MvcRouteHandler());
            route.DataTokens = new RouteValueDictionary(new { namespaces = new string[] { rootNamespace + ".Controllers" } });
            route.Defaults = new RouteValueDictionary(new { module = "root", action = "Index", controller = "Home", id = "" });
            routes.Add(route);
        }
    }
}