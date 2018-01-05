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
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class DomesticflighClassProvider
    {
        EntityModel ent = new EntityModel();


        /// <summary>
        /// /////////   Flight type list 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetFlightTypeList()
        {
            //List<FlightTypes> all = GetAllFlightTypes().ToList();
            List<FlightTypes> all = GetAllFlightTypes().Where(x=>x.FlightTypeId==2).ToList();
            var GetFlightTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.FlightTypeName,
                    Value = item.FlightTypeId.ToString()
                };
                GetFlightTypeList.Add(teml);
            }
            return GetFlightTypeList.AsEnumerable();
        }
      
        public IQueryable<FlightTypes> GetAllFlightTypes()
        {
            return ent.FlightTypes.OrderByDescending(xx => xx.FlightTypeId).AsQueryable();
        }

        ///////// Domestic airline list ///////////////

        public IEnumerable<SelectListItem> GetDomesticAirlineList()
        {
            List<Airlines> all = GetAllDomesticAirlineList().OrderBy(x=>x.AirlineCode).ToList();
            var DomesticAirlineList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineName,
                    Value = item.AirlineId.ToString()
                };
                DomesticAirlineList.Add(teml);
            }
            return DomesticAirlineList.AsEnumerable();
        }
        public IQueryable<Airlines> GetAllDomesticAirlineList()
        {
            return ent.Airlines.OrderByDescending(xx => xx.AirlineId).Where( aa=>aa.AirlineTypeId==2) .AsQueryable();
        }
        /////////////////// Flight Class For Domestic Airline ///////////////////////////////
        public IQueryable<AirlineFlighClassViewModel> GetAllFlightClassesList()
        {
            var cc = (from aa in ent.Air_DomesticFlightClasses.OrderBy(ff => ff.AirlineId)
                      select new AirlineFlighClassViewModel
                      {
                          AirlineId = aa.AirlineId,
                          AirlineName=aa.Airlines.AirlineName,
                          FlightClassCode = aa.FlightClassCode,
                          ClassType = aa.FlightClassType,
                         FlightClassId=aa.DomesticFlightClassId,
                      }).ToList();
            return cc.AsQueryable();
        }

        public void AddFlightClass(AirlineFlighClassViewModel model)
        {
            Air_DomesticFlightClasses datamodel = new Air_DomesticFlightClasses
            {
                AirlineId=model.AirlineId,
                FlightClassCode = model.FlightClassCode,
                 FlightClassType=model.ClassType 
            };
            ent.AddToAir_DomesticFlightClasses(datamodel);
            ent.SaveChanges();
        }
        /////////// only Flight Class For domestic ///////////////

        public void AddDomesticAirlineFlightClass(AirlineFlighClassViewModel model)
        {
            AirlineFlightClasses datamodel = new AirlineFlightClasses
            {
                AirlineId = model.AirlineId,
                FlightClassId = model.FlightClassId,
               
            };
            ent.AddToAirlineFlightClasses(datamodel);
            ent.SaveChanges();
        }

        public void DeleteFareClass(int FareClassId)
        {
           // FlightClasses obj = ent.FlightClasses.Where(x => x.FlightClassId == FareClassId).FirstOrDefault();

            Air_DomesticFlightClasses obj = ent.Air_DomesticFlightClasses.Where(x => x.DomesticFlightClassId == FareClassId).FirstOrDefault();
            ent.DeleteObject(obj);
            ent.SaveChanges();
        }
        public IQueryable<AirlineFlighClassViewModel> GetFlightClassDomesticAirline()
        {
         
            var fc = (from aa in ent.FlightClasses.Where(aa => aa.FlightTypeId == 2).AsQueryable()
                      select new AirlineFlighClassViewModel
                      {
                          FlightClassId = aa.FlightClassId,
                          FlightClassCode = aa.FlightClassCode,
                        //  ClassName = aa.ClassName,
                      }).ToList();
            return fc.AsQueryable();
        }
        ///////////////// Get Active Class for by Airline ///////////////////
        public List<AirlineFlighClassViewModel> GetAllActiveFlightClassForAirline(int Airlineid)
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.FlightClasses
                      join bb in ent.AirlineFlightClasses
                      on aa.FlightClassId equals bb.FlightClassId
                      where bb.AirlineId == Airlineid
                      select new AirlineFlighClassViewModel
                      {
                         // ClassName = aa.ClassName,
                          FlightClassCode=aa.FlightClassCode,
                          FlightClassId = aa.FlightClassId,
                      }).ToList();
            return cc;
        }

        ///////////////////// Get Active Class for by FlightClassId ///////////////////
        public List<AirlineFlighClassViewModel> GetAllActiveAirlineNameByClassId(int FlightClassId)
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.FlightClasses
                      join bb in ent.AirlineFlightClasses
                      on aa.FlightClassId equals bb.FlightClassId
                      where bb.FlightClassId == FlightClassId
                      select new AirlineFlighClassViewModel
                      {
                        //  ClassName = aa.ClassName,
                          FlightClassCode = aa.FlightClassCode,
                          FlightClassId = aa.FlightClassId,
                          AirlineId=bb.AirlineId,
                          AirlineName=bb.Airlines.AirlineName
                      }).ToList();
            return cc;
        }

        public void UpdatFlightClasses(AirlineFlighClassViewModel modeltosave)
        {
            Air_DomesticFlightClasses comm = ent.Air_DomesticFlightClasses.Where(u => u.DomesticFlightClassId == modeltosave.FlightClassId).FirstOrDefault();
            comm.DomesticFlightClassId = modeltosave.FlightClassId;
            comm.FlightClassCode = modeltosave.FlightClassCode;
            comm.FlightClassType = modeltosave.ClassType;
            ent.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            ent.SaveChanges();
            /////
        }
        public Air_DomesticFlightClasses GeFlightClassesInfo(int FlightClassId)
        {
            return ent.Air_DomesticFlightClasses.SingleOrDefault(u => u.DomesticFlightClassId == FlightClassId);
        }

        
        public int GetAirlineId(int FlightClassId)
        {
            //Air_DomesticFlightClasses result = ent.Air_DomesticFlightClasses.Where(x => x.FlightClassCode == FlightClassId).SingleOrDefault();
            //return result.AirlineId;

            var result = ent.Air_DomesticFlightClasses.Where(x => x.DomesticFlightClassId == FlightClassId).SingleOrDefault();
            return result.AirlineId;
        }


        public void DeleteAirlineFlightClasses(int AirlineId)
        {
            try
            {
                ent.DeleteAirlineFlightClasses(AirlineId);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckFlightCode(int AirlineId, string FlightCode)
        {
            var result = ent.Air_DomesticFlightClasses.Where(x => (x.AirlineId == AirlineId && x.FlightClassCode==FlightCode)).ToList();
            if (result.Count()==0)
            {
                return false;
            }
            return true;
        }

       

    }
}