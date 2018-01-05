#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
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
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Order = 2)]
    public class DefaultMarkupSettingController : Controller
    {
        //
        // GET: /DefaultMarkupSetting/
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();


        [HttpGet]
        public ActionResult Index()
        {

            var data = ent.DefaultMarkupLevels.FirstOrDefault();
            if (data != null)
            {
                var model = new DefaultMarkupSettingModel
                {
                    MaximumMarkupValue = data.MaxMarkupFare,
                    MiniumMarkupValue = data.MinMarkupFare,
                    DefaultMarkupValue = data.DefaultMarkupFare
                };
                return View(model);
            }
            return View();


        }

        

        public class res
        {
            public string responseStatus { get; set; }
            public string responseMsg { get; set; }

        }

    }
}
