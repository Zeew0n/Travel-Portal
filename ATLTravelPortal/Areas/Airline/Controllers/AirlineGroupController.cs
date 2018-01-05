#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: SessionExpire.cs
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
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{

    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details",  Order = 2)]
    public class AirlineGroupController : Controller
    {
        AirlineGroupRepository _airgrouprepo = new AirlineGroupRepository();
        public string SavedGroupAirline { get; set; }
        public IAirlineCachingRepository cacheRepository { get; set; }

		public AirlineGroupController()
			: this(new AirlineCachingRepository())
		{
		}

        public AirlineGroupController(IAirlineCachingRepository cacherepository)
		{
			this.cacheRepository = cacherepository;
		}
        //
        // GET: /AirlineGroup/

        public ActionResult Index()
        {
            var model = _airgrouprepo.GetAllAirlineGroupList().ToList();
            return View(model);
        }

        //
        // GET: /AirlineGroup/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AirlineGroup/Create

        public ActionResult Create()
        {
            AirlineGroupViewModel model = new AirlineGroupViewModel 
            { 
                AvailableAirline = cacheRepository.GetCacheAirlines().ToList(),
                RequestedAirline = new List<Airlines>() 
            };
            return View(model);
          
        } 

        //
        // POST: /AirlineGroup/Create

        [HttpPost]
        public ActionResult Create(AirlineGroupViewModel model, string add, string remove, string send)
        {
            //Need to clear model state or it will interfere with the updated model
            ModelState.Clear();
            RestoreSavedState(model);
            if (!string.IsNullOrEmpty(add))
                AddAirlines(model);
            else if (!string.IsNullOrEmpty(remove))
                RemoveAirlines(model);
            else if (!string.IsNullOrEmpty(send))
            {
                Validate(model);
                if (ModelState.IsValid)
                {
                    ///// Collecting all airline id 
                    string[] SavedGroupAirline = GetStringArray(model.SavedRequested);
                    ///// Collecting last saved id 
                    _airgrouprepo.SaveAirlineGroup(model);
                    int Groupid = _airgrouprepo.GetLastId().ToList().Last().AirlineGroupId;
                    //////// Saving all list of Acces airline id
                   int[] AllSavedId = SavedGroupAirline.Select(x => int.Parse(x)).ToArray();
                   _airgrouprepo.CollectMappingInfo(AllSavedId, Groupid);
                    return RedirectToAction("Index");
                }
                //Todo: Repository.ClearCache();...
            }
            SaveState(model);
            return View(model);
        }
        
        //
        // GET: /AirlineGroup/Edit/5
 
        public ActionResult Edit(int id)
        {
            AirlineGroupViewModel model = new AirlineGroupViewModel 
            { 
                AvailableAirline = cacheRepository.GetCacheAirlines().ToList(),
                RequestedAirline = _airgrouprepo.GetAllAddedAirlineGroupListForEdit(id),
                GroupName =_airgrouprepo.GetAirlineGroupName(id)
            };
            
            
            return View(model);
        }

        //
        // POST: /AirlineGroup/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, AirlineGroupViewModel model, string add, string remove, string send)
        {
            try
            {
                // TODO: Add update logic here
                ModelState.Clear();
                RestoreSavedState(model);
                if (!string.IsNullOrEmpty(add))
                    AddAirlines(model);
                else if (!string.IsNullOrEmpty(remove))
                    RemoveAirlines(model);
                else if (!string.IsNullOrEmpty(send))
                {
                    Validate(model);
                    if (ModelState.IsValid)
                    {
                        ///// Collecting all airline id 
                        string[] SavedGroupAirline = GetStringArray(model.SavedRequested);
                        ///// Collecting last saved id 
                       // _airgrouprepo.SaveAirlineGroup(model);
                        int Groupid = _airgrouprepo.GetLastId().ToList().Last().AirlineGroupId;
                        //////// Saving all list of Acces airline id
                        int[] AllSavedId = SavedGroupAirline.Select(x => int.Parse(x)).ToArray();
                       // _airgrouprepo.CollectMappingInfo(AllSavedId, Groupid);
                        return RedirectToAction("Index");
                    }
                    //Todo: Repository.ClearCache();...
                }
                SaveState(model);
               
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        #region SupportFuncs for Airline group
        private void Validate(AirlineGroupViewModel model)
        {
            //if (model.RequestedTotal > 400m)
            //    ModelState.AddModelError("", "Total must be 400 or less");
            if (string.IsNullOrEmpty(model.GroupName))
                ModelState.AddModelError("GroupName", "Please Enter Group Name");
            if (string.IsNullOrEmpty(model.SavedRequested))
                ModelState.AddModelError("", "You haven't selected any presents!");
        }

        void SaveState(AirlineGroupViewModel model)
        {
            //create comma delimited list of product ids
            model.SavedRequested = string.Join(",", model.RequestedAirline.Select(p => p.AirlineId.ToString()).ToArray());
            
            model.AvailableAirline = cacheRepository.GetCacheAirlines().Except(model.RequestedAirline).ToList();
        }
        
        void RemoveAirlines(AirlineGroupViewModel model)
        {
            if (model.RequestedSelected != null)
            {
                model.RequestedAirline.RemoveAll(p => model.RequestedSelected.Contains(p.AirlineId));
                model.RequestedSelected = null;
            }
        }

        void AddAirlines(AirlineGroupViewModel model)
        {
            if (model.AvailableSelected != null)
            {
                var airline = cacheRepository.GetCacheAirlines().Where(p => model.AvailableSelected.Contains(p.AirlineId));
                model.RequestedAirline.AddRange(airline);
                model.AvailableSelected = null;
            }
        }

        void RestoreSavedState(AirlineGroupViewModel model)
        {
            model.RequestedAirline = new List<Airlines>();
            //get the previously stored items
            if (!string.IsNullOrEmpty(model.SavedRequested))
            {
                string[] Airlineids = model.SavedRequested.Split(',');
                var airlines = cacheRepository.GetCacheAirlines().Where(p => Airlineids.Contains(p.AirlineId.ToString()));
                model.RequestedAirline.AddRange(airlines);
            }
        }
        // get array of action names
        private string[] GetStringArray(string value)
        {
            // check the id for the  airline selection
            if (string.IsNullOrEmpty(value))
            {
                value = "";
            }
            string[] stringArray = value.Split(',');
            for (int k = 0; k < stringArray.Length; k++)
            {
                stringArray[k] = stringArray[k].ToLower().Trim();
            }
            return stringArray;
        }
        #endregion 
       
    }
}
