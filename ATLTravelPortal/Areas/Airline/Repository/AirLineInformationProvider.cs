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

namespace
ATLTravelPortal.Areas.Airline.Repository
{
    public class AirLineInformationProvider : EntityModel
    {
        EntityModel ent = new EntityModel();

        #region AirLine Information

        /// <summary>
        /// ////////////////////For AccountTypes with Settlement//////////////////////////////////////
        /// </summary>
        /// <param name="obj"></param>
        /// 

        public IEnumerable<SelectListItem> GetAllAccTypesList()
        {
            List<GL_AccTypes> all = GetAccTypesList().ToList();
            var GetAllAccTypesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AccTypeName,
                    Value = item.AccTypeId.ToString()
                };
                GetAllAccTypesList.Add(teml);
            }
            return GetAllAccTypesList.AsEnumerable();
        }
        //to get only BSP and Consolidator//
        public List<GL_AccTypes> GetAccTypesList()
        {
            return ent.GL_AccTypes.Where(tt => (tt.AccTypeId == 3) || (tt.AccTypeId == 4)).ToList();
        }


        public List<AirLinesModel> GetAllLedgerNameofBSPorConsolidatorBasedonAccTypes(int AccTypeId)
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.GL_Ledgers
                      where aa.AccTypeId == AccTypeId
                      select new AirLinesModel
                      {
                          LedgerId = (int)aa.LedgerId,
                          LedgerName = aa.LedgerName
                      }).ToList();
            return cc;
        }

        public List<GL_Ledgers> GetLedgername()
        {
            return ent.GL_Ledgers.ToList();
        }
        public IEnumerable<SelectListItem> GetAllGetLedgername()
        {
            var GetAllGetLedgername = new List<SelectListItem>();
                //var tem = new SelectListItem
                //{
                //    Text ="",
                //    Value = ""
                //};
                //GetAllGetLedgername.Add(tem);
            
            return GetAllGetLedgername.AsEnumerable();


            //List<GL_Ledgers> all = GetLedgername().ToList();
            //var GetAllGetLedgername = new List<SelectListItem>();
            //foreach (var item in all)
            //{
            //    var tem = new SelectListItem
            //    {
            //        Text = item.LedgerName,
            //        Value = item.LedgerId.ToString()
            //    };
            //    GetAllGetLedgername.Add(tem);
            //}
            //return GetAllGetLedgername.AsEnumerable();
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Int64 AddLedger(GL_Ledgers obj)
        {

            ent.AddToGL_Ledgers(obj);
            ent.SaveChanges();
            return obj.LedgerId;
        }

        public int GetLedgerMasterDetail(int id)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.Id == id).FirstOrDefault();
            AirLinesModel model = new AirLinesModel();
            if (result != null)
            {
                model.LedgerId = (int)result.LedgerId;
                model.LedId = (int)result.Id;
                model.LedgerName = result.LedgerName;

                return model.LedId;
            }
            else
            {
                return model.LedId;
            }

        }


        public long AddLedgerMaster(GL_Ledgers obj)
        {

            ent.AddToGL_Ledgers(obj);
            ent.SaveChanges();

            //to return the primary key
           return obj.LedgerId;
        }
     


        public int AddAirLine(Airlines obj)
        {
            ent.AddToAirlines(obj);
            ent.SaveChanges();
            //to return the primary id//
            return obj.AirlineId;
        }

        //public override int SaveChanges(System.Data.Objects.SaveOptions options)
        //{
        //    return base.SaveChanges(options);
        //}




        public List<Airlines> GetAllAirLinesByAscendingOrder()
        {

            return ent.Airlines.OrderBy(aa => aa.AirlineName).ToList();

        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllActiveAirLinesList()
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == true);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode
                    
                };
                model.Add(obj);
            }
            return model.AsQueryable();

        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllActiveAirLinesList(int TypeId)
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == true && x.AirlineTypeId == TypeId).OrderBy(x => x.AirlineName);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode
                   
                };
                model.Add(obj);
            }
            return model.AsQueryable();

        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllActiveInternationalAirlineList()
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == true && x.AirlineTypeId == 1).OrderBy(x => x.AirlineName);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                   // CountryName = item.Countries.CountryName== null?null    :item.Countries.CountryName,
                   CountryName = item.CountryId == null? "" : item.Countries.CountryName
                    
                    
                };
                model.Add(obj);
            }
            return model.AsQueryable();
        }

        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllInactiveAirLinesList()
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == false).OrderBy(x => x.AirlineName).OrderBy(x => x.AirlineName);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode
                    
                };
                model.Add(obj);
            }
            return model.AsQueryable();

        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllInActiveInternationalAirlineList()
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == false && x.AirlineTypeId == 1).OrderBy(x => x.AirlineName);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    CountryName = item.Countries.CountryName
                };
                model.Add(obj);
            }
            return model.AsQueryable();
        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllInActiveAirlineList(int TypeId)
        {
            var result = ent.Airlines.OrderBy(x => x.AirlineName).Where(x => x.isActive == false && x.AirlineTypeId == TypeId).OrderBy(x => x.AirlineName);
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    CountryName = item.Countries.CountryName
                };
                model.Add(obj);
            }
            return model.AsQueryable();
        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllAirLines()
        {

            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.AsQueryable().OrderBy(x => x.AirlineName);
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    AirLineId = item.AirlineId,
                    Photo = item.Photo

                };
                obj.Add(model);
            }
            return obj.AsQueryable();

        }
        public IQueryable<Airlines> GetAllAirlineByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.Airlines.Count();
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
            IQueryable<Airlines> pagingdata = ent.Airlines.OrderBy(t => t.AirlineId).Where(x => x.isActive == true).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }
        //public IQueryable<Airlines> GetAllInActiveAirlineByByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        //{
        //    int pageSize = (int)PageSize.JePageSize;
        //    int rowCount = ent.Airlines.Where(x => x.isActive == false).Count();
        //    numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
        //    if (flag != null)//Checking for next/Previous
        //    {
        //        if (flag == 1)
        //            if (pageNo != 1) //represents previous
        //                pageNo -= 1;
        //        if (flag == 2)
        //            if (pageNo != numberOfPages)//represents next
        //                pageNo += 1;

        //    }
        //    currentPageNo = pageNo;
        //    int rowsToSkip = (pageSize * currentPageNo) - pageSize;
        //    IQueryable<Airlines> pagingdata = ent.Airlines.OrderBy(t => t.AirlineId).Where(x => x.isActive == false).Skip(rowsToSkip).Take(pageSize).AsQueryable();
        //    return pagingdata;
        //}
        //public IQueryable<Airlines> GetAllInActiveAirline()
        //{
        //    IQueryable<Airlines> result = ent.Airlines.OrderBy(t => t.AirlineId).Where(x => x.isActive == false).AsQueryable();
        //    return result;
        //}

        //public IQueryable<AirLines.Models.AirLine.AirLines> GetAllAirlineByByPagings(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        //{
        //    int pageSize = (int)PageSize.JePageSize;
        //    int rowCount = ent.Airlines.Count();
        //    numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
        //    if (flag != null)//Checking for next/Previous
        //    {
        //        if (flag == 1)
        //            if (pageNo != 1) //represents previous
        //                pageNo -= 1;
        //        if (flag == 2)
        //            if (pageNo != numberOfPages)//represents next
        //                pageNo += 1;

        //    }
        //    currentPageNo = pageNo;
        //    int rowsToSkip = (pageSize * currentPageNo) - pageSize;
        //    List<AirLines.Models.AirLine.AirLines> obj = new List<AirLines.Models.AirLine.AirLines>();
        //    var result = ent.Airlines.OrderBy(t => t.AirlineId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
        //    foreach (var item in result)
        //    {
        //        AirLines.Models.AirLine.AirLines model = new AirLines.Models.AirLine.AirLines()
        //        {
        //            txtAirLineName = item.AirlineName,
        //            AirLineCode = item.AirlineCode,
        //            Photo = item.Photo,
        //            AirLineId = item.AirlineId
        //        };
        //        obj.Add(model);
        //    }
        //    //IQueryable<Airlines> pagingdata = ent.Airlines.OrderBy(t => t.AirlineId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
        //    return obj.AsQueryable();
        //}

        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllAirline()
        {
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.OrderBy(t => t.AirlineId).AsQueryable();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    AirLineId = item.AirlineId
                };
                obj.Add(model);
            }
            return obj.AsQueryable();
        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllActiveDomesticAirline()
        {
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.Where(x => x.AirlineTypeId == 2 && x.isActive == true).OrderBy(x => x.AirlineCode).AsQueryable();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    AirLineId = item.AirlineId
                };
                obj.Add(model);
            }
            return obj.AsQueryable();
        }
        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllInActiveDomesticAirline()
        {
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.Where(x => x.AirlineTypeId == 2 && x.isActive == false).OrderBy(x => x.AirlineId).AsQueryable();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    AirLineId = item.AirlineId
                };
                obj.Add(model);
            }
            return obj.AsQueryable();
        }

        //public IQueryable<Airlines> GetAllSearchAirlineNameList(string AirlineNameCode, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        //{
        //    int pageSize = (int)PageSize.JePageSize;
        //    int rowCount = ent.Airlines.Count();
        //    numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
        //    if (flag != null)//Checking for next/Previous
        //    {
        //        if (flag == 1)
        //            if (pageNo != 1) //represents previous
        //                pageNo -= 1;
        //        if (flag == 2)
        //            if (pageNo != numberOfPages)//represents next
        //                pageNo += 1;

        //    }
        //    currentPageNo = pageNo;
        //    int rowsToSkip = (pageSize * currentPageNo) - pageSize;
        //    IQueryable<Airlines> pagingdata = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(pageSize).AsQueryable();
        //    return pagingdata;
        //}

        //public IQueryable<Airlines> GetAllSearchAirlineNameList(string AirlineNameCode)
        //{
        //    IQueryable<Airlines> result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).AsQueryable();
        //    return result;
        //}

        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllSearchAirlineNameList(string AirlineNameCode)
        {
            var result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower())));
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> model = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines obj = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode
                };
                model.Add(obj);
            }
            return model.AsQueryable();
        }
        //public IQueryable<Airlines> GetAllInActivehAirlineNameList(string AirlineNameCode, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        //{
        //    int pageSize = (int)PageSize.JePageSize;
        //    int rowCount = ent.Airlines.Count();
        //    numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
        //    if (flag != null)//Checking for next/Previous
        //    {
        //        if (flag == 1)
        //            if (pageNo != 1) //represents previous
        //                pageNo -= 1;
        //        if (flag == 2)
        //            if (pageNo != numberOfPages)//represents next
        //                pageNo += 1;

        //    }
        //    currentPageNo = pageNo;
        //    int rowsToSkip = (pageSize * currentPageNo) - pageSize;
        //    //IQueryable<Airlines> pagingdata = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower())|| x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(pageSize).AsQueryable();
        //    IQueryable<Airlines> pagingdata = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()) || x.isActive == false)).Take(pageSize).AsQueryable();
        //    return pagingdata;
        //}

        public IQueryable<Airlines> GetAllInActivehAirlineNameList(string AirlineNameCode)
        {
            IQueryable<Airlines> result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()) || x.isActive == false)).AsQueryable();
            return result;
        }

        public IQueryable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllSearchAirlineNameLists(string AirlineNameCode, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = ent.Airlines.Count();
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
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(pageSize).AsQueryable();
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    txtAirLineName = item.AirlineName,
                    AirLineCode = item.AirlineCode,
                    Photo = item.Photo,
                    AirLineId = item.AirlineId
                };
                obj.Add(model);
            }
            // IQueryable<Airlines> pagingdata = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(pageSize).AsQueryable();
            return obj.AsQueryable();
        }



        public Airlines GetAirLineInfoById(int AirlineId)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
        }

        public GL_Ledgers GetLedgerInfoById(int LedgerId)
        {
            EntityModel ent = new EntityModel();
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.Id == LedgerId && x.AccTypeId==1).FirstOrDefault();

           
            if (result != null)
            {
                return result;
            }
            // return result;
            else
            {
                return result;
            }
        }

        public GL_Ledgers GetLedgerInfoByLedgerId(int LedgerId)
        {
            EntityModel ent = new EntityModel();
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.LedgerId == LedgerId).FirstOrDefault();


            if (result != null)
            {
                return result;
            }
            // return result;
            else
            {
                return result;
            }
        }

        public int GetLedgerInformationById(int id)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.Id == id).FirstOrDefault();
            AirLinesModel model = new AirLinesModel();
            if (result != null)
            {
                model.LedgerId = (int)result.LedgerId;
                model.AccTypes = result.AccTypeId;
                model.LedId = (int) result.Id;
                return model.LedgerId;
            }
           else

                return model.LedgerId;
        }

        

        //public AirLineModel GetAirLineInfoById(int AirlineId)
        //{

        //    Airlines result = ent.Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
        //    AirLineModel model = new AirLineModel();
        //    model.AirlineCode = result.AirlineCode;
        //    model.AirlineName = result.AirlineName;
        //    model.Photo = result.Photo;
        //    model.chkSettlement = Convert.ToBoolean(result.SettlmentLedgerId);
        //    model.AccTypes = (int)result.SettlmentLedgerId;
        //    model.BSPorConsolidatorId = (int)result.SettlmentLedgerId;
        //    model.AirlineTypId = result.AirlineTypeId;

        //    return model;


        //}


        public ATLTravelPortal.Areas.Airline.Models.AirLines GetAirLineInfoByIds(int AirlineId)
        {
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            //obj = ent.Airlines.Where(x => x.AirlineId == AirlineId).ToList();
            var result = ent.Airlines.Where(x => x.AirlineId == AirlineId);
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines()
                {
                    AirLineCode = item.AirlineCode,
                    AirLineId = item.AirlineId,
                    txtAirLineName = item.AirlineName,
                    Photo = item.Photo
                };
                obj.Add(model);
            }
            return obj.FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetAirlineTypeList()
        {
            List<AirlineTypes> all = GetAllAirlineTypes().ToList();
            var AirlineCityTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.TypeName,
                    Value = item.AirineTypeId.ToString()
                };
                AirlineCityTypeList.Add(teml);
            }
            return AirlineCityTypeList.AsEnumerable();
        }
        public IQueryable<AirlineTypes> GetAllAirlineTypes()
        {
            return ent.AirlineTypes.OrderByDescending(xx => xx.AirineTypeId).AsQueryable();
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
         var country =   GetAllCountriesList.OrderBy(x => x.Value == "1" );
            
         return country.ToList();
        }





        public void EditAirLineInfo(Airlines obj)
        {
            if (obj.SettlmentLedgerId == 0)
                obj.SettlmentLedgerId = null;
            EntityModel ent = new EntityModel();
            var result = ent.Airlines.Where(x => x.AirlineId == obj.AirlineId).FirstOrDefault();
            if (result != null)
            {
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
        }

        //for delete
        public void DeleteLedgerMaster(int ID)
        {
            GL_Ledgers result = ent.GL_Ledgers.Where(x => x.Id == ID).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
        }

        public void EditLedgerInfo(GL_Ledgers obj)
        {

            EntityModel ent = new EntityModel();
            var result = ent.GL_Ledgers.Where(x => x.Id == obj.Id).FirstOrDefault();

            if (result != null)
            {
                obj.LedgerId = result.LedgerId;
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();

            }
        }

        /// <summary>
        /// Change the Status of Airline to Active 
        /// </summary>
        /// <param name="AirlineId"></param>
        public void ChangeStatusToActive(int AirlineId, Airlines model)
        {
            var result = ent.Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
            result.isActive = true;
            if (result != null)
            {
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }
        /// <summary>
        /// Change the Status of Airline to InActive
        /// </summary>
        /// <param name="AirlineId"></param>
        /// <param name="model"></param>
        public void ChangeStatusToInActive(int AirlineId, Airlines model)
        {
            var result = ent.Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();

            result.isActive = false;
            if (result != null)
            {
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }
        public void EditAirLineInfo(ATLTravelPortal.Areas.Airline.Models.AirLines obj)
        {
            var result = ent.Airlines.Where(x => x.AirlineId == obj.AirLineId).FirstOrDefault();
            if (result != null)
            {
                result.AirlineName = obj.txtAirLineName;
                result.Photo = obj.Photo;
                result.AirlineCode = obj.AirLineCode;
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }

        }
        public bool isLedgerExists(int AirlineId )
        {
            var aa = Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
            if (aa.SettlmentLedgerId == null)
                return false;
            else
            {
                if (ent.GL_Ledgers.Where(x => x.Id == AirlineId && x.AccTypeId == 1).ToList().Count == 0)
                    return false;
                else
                    return true;
            }
        }

        public int getLedgerId(int AirlineId)
        {
            return (int) GL_Ledgers.Where(x => x.Id == AirlineId && x.AccTypeId==1).Select(x => x.LedgerId).FirstOrDefault();
            
        }


        public IEnumerable<Airlines> GetAllAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => x.AirlineTypeId == 1).Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        public IEnumerable<Airlines> GetAllDomesticAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => x.AirlineTypeId == 2).Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        public void DeleteAirline(int AirlineId)
        {
            Airlines obj = ent.Airlines.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
            ent.DeleteObject(obj);
            ent.SaveChanges();
        }
        public bool CheckAirlineName(string AirlineName)
        {

            var result = ent.Airlines.Where(x => x.AirlineName.ToUpper() == AirlineName.ToUpper()).FirstOrDefault();


            if (result == null)
            {
                return true;
            }
            return false;
        }
        public IEnumerable<ATLTravelPortal.Areas.Airline.Models.AirLines> GetAllAirlineNameLists(string AirlineNameCode, int maxResult)
        {
            List<ATLTravelPortal.Areas.Airline.Models.AirLines> obj = new List<ATLTravelPortal.Areas.Airline.Models.AirLines>();
            var result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().
                Select(x => new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode });
            foreach (var item in result)
            {
                ATLTravelPortal.Areas.Airline.Models.AirLines model = new ATLTravelPortal.Areas.Airline.Models.AirLines
                {
                    txtAirLineName = item.AirlineName,
                    AirLineId = item.AirlineId,
                    AirLineCode = item.AirlineCode
                };
                obj.Add(model);
            }
            return obj.AsEnumerable();
        }
        #endregion

    }


}