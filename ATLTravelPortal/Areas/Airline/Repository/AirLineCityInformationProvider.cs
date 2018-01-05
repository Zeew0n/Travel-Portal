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
using System.Data.Common;
using System.Data.Objects;
using ATLTravelPortal;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirLineCityInformationProvider
    {
        EntityModel ent = new EntityModel();

        #region AirlineCities

        public void AddAirLineCityInfo(AirLineCityModel model)
        {
            EntityModel ent = new EntityModel();
            AirlineCities datamodel = new AirlineCities
            {
                CityName=model.CityName,
                CityCode=model.CityCode,
                AirlineCityTypeId = model.AirlineCityTypId,
                CountryId = model.CountryId
            };
            ent.AddToAirlineCities(datamodel);
            ent.SaveChanges();
        }
        public IQueryable<AirlineCities> GetAirLineCity()
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.AsQueryable();
        }
        
        public IQueryable<AirlineCities> GetAllAirlineCityByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.AirlineCities.Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<AirlineCities> pagingdata = ent.AirlineCities.OrderBy(t => t.CityID).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        public IQueryable<AirlineCities> GetAllInternationalAirlineCityByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.AirlineCities.Where(x=>x.AirlineCityTypeId ==1).Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<AirlineCities> pagingdata = ent.AirlineCities.Where(x=>x.AirlineCityTypeId ==1).OrderBy(t => t.CityID).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        public IQueryable<AirlineCities> GetAllDomesticAirlineCityByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.AirlineCities.Where(x=>x.AirlineCityTypeId ==2).Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<AirlineCities> pagingdata = ent.AirlineCities.Where(x=>x.AirlineCityTypeId ==2).OrderBy(t => t.CityCode).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        public IQueryable<AirlineCities> GetAllSearchAirlineCityNameList(string AirlineCityNameCode, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.AirlineCities.Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<AirlineCities> pagingdata = ent.AirlineCities.Where(x => (x.CityName.ToLower().Contains(AirlineCityNameCode.ToLower()) || x.CityCode.ToLower().Contains(AirlineCityNameCode.ToLower()))).Take(pageSize).AsQueryable();
            return pagingdata;
        }

        public AirlineCities GetAirLineCityinfoByid(int CityID)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.Where(x => x.CityID == CityID).FirstOrDefault();
        }
        public Bus_Cities GetBusCityByid(int CityID)
        {
            EntityModel ent = new EntityModel();
            return ent.Bus_Cities.Where(x=>x.BusCityId==CityID).FirstOrDefault();
        }

        public void DeleteAirlineCity(int AirlineCityId)
        {
            AirlineCities obj = ent.AirlineCities.Where(x => x.CityID == AirlineCityId).FirstOrDefault();
            ent.DeleteObject(obj);
            ent.SaveChanges();
        }

        public bool CheckCityName(string CityName)
        {
            var result = ent.AirlineCities.Where(x => x.CityName.ToUpper() == CityName.ToUpper()).FirstOrDefault();
            if (result == null)
            { return true; }
            else
                return false;
        
        }

        public void EditAirLineCityInfo(AirLineCityModel model)
        {
            EntityModel ent = new EntityModel();
            var obj = ent.AirlineCities.Where(x => x.CityID == model.CityID).FirstOrDefault();
            if (obj != null)
            {
                obj.CityID = model.CityID;
                obj.CityCode = model.CityCode;
                obj.CityName = model.CityName;
                obj.AirlineCityTypeId = model.AirlineCityTypId;
                obj.CountryId = model.CountryId;
                ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                ent.SaveChanges();
            }
        }

        public IEnumerable<AirlineCities> GetAllCityNameList(string cityNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();


            return ent.AirlineCities.Where(x => (x.CityName.ToLower().Contains(cityNameCode.ToLower()) || x.CityCode.ToLower().Contains(cityNameCode.ToLower()))).Select(x =>
                                new AirlineCities{ CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                ).Take(maxResult).ToList();
            
        }

        public IEnumerable<AirlineCities> GetDepartureCity()
        {
            return ent.AirlineCities.ToList();
        }
        public IEnumerable<SelectListItem> GetAirlineCityTypeList()
        {
            List<AirlineCityTypes> all = GetAll().ToList();
            var AirlineCityTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineCityTypeName,
                    Value = item.AirlineCityTypeId.ToString()
                };
                AirlineCityTypeList.Add(teml);
            }
            return AirlineCityTypeList.AsEnumerable();
        }
        public IQueryable<AirlineCityTypes> GetAll()
        {
            return ent.AirlineCityTypes.OrderByDescending(xx => xx.AirlineCityTypeId).AsQueryable();
        }
        public List<AirlineCities> GetDestinationCity()
        {
            return ent.AirlineCities.ToList();
        }

        public AirlineCities GetCityInfo(int ID)
        {
            return ent.AirlineCities.SingleOrDefault(u => u.CityID == ID);
        }

        public IEnumerable<AirlineCities> GetAllAirlineCityList(string AirlineCityNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.Where(x => (x.CityName.ToLower().Contains(AirlineCityNameCode.ToLower()) || x.CityCode.ToLower().Contains(AirlineCityNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new AirlineCities { CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                );
        }




        public List<Countries> GetCountriesList()
        {
            return ent.Countries.ToList();
        }

        public IEnumerable<SelectListItem> GetAllCountriesList()
        {
            List<Countries> all = GetCountriesList().ToList();
            var GetAllCountriesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CountryName,
                    Value = item.CountryId.ToString()
                };
                GetAllCountriesList.Add(teml);

            }
            var country = GetAllCountriesList.OrderBy(x => x.Value == "1");

            return country.ToList();
        }
        public IEnumerable<Bus_Cities> GetAllBusCityNameList(string cityNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();

            //return ent.Bus_Cities.Where(x=>x.BusCityName.ToLower().Contains(cityNameCode.ToLower().Select());

            return ent.Bus_Cities.Where(x => (x.BusCityName.ToLower().Contains(cityNameCode.ToLower()) || x.BusCityCode.ToLower().Contains(cityNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Bus_Cities { BusCityName = x.BusCityName, BusCityId = x.BusCityId, BusCityCode = x.BusCityCode });


        }


        #endregion



    }
}