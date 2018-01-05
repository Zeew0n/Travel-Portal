using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Bus.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class MasterDealProvider
    {
        EntityModel ent = new EntityModel();
       // AirLineCityInformationProvider cityProvider = new AirLineCityInformationProvider();
        /// <summary>
        ///   Deal type list 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllDealTypeList(int productId)
        {
            List<Tkt_DealType> all = GetAllDealType(productId).ToList();
            var GetAllDealTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealTypeName,
                    Value = item.DealTypeId.ToString()
                };
                GetAllDealTypeList.Add(teml);
            }
            return GetAllDealTypeList.AsEnumerable();
        }
        public IQueryable<Tkt_DealType> GetAllDealType(int productId)
        {
            var result = new List<Tkt_DealType>();
            bool IsDefault = CheckIfContainDefaultTypeDeal(productId);
            bool IsMaster = CheckIfContainMasterTypeDeal(productId);
            bool IsSuper = CheckIfContainSuperTypeDeal(productId);
            bool isB2C = CheckIfContainB2CTypeDeal(productId);
           

            var resultSuperDeal = new Tkt_DealType();
            var resultDefaultDeal = new Tkt_DealType();
            var resultMasterDeal = new Tkt_DealType();
            var resultAgentDeal = new Tkt_DealType();
            var resultB2CDeal = new Tkt_DealType();

            if (!IsMaster)
            {
                resultMasterDeal = ent.Tkt_DealType.Where(x => x.DealTypeId == 1).FirstOrDefault();
                if (resultMasterDeal != null)
                    result.Add(resultMasterDeal);
            }

            if (!IsDefault)
            {
                resultDefaultDeal = ent.Tkt_DealType.Where(x => x.DealTypeId == 3).FirstOrDefault();
                if (resultDefaultDeal != null)
                    result.Add(resultDefaultDeal);
            }

            if (!IsSuper)
            {
                resultSuperDeal = ent.Tkt_DealType.Where(x => x.DealTypeId == 4).FirstOrDefault();
                if (resultSuperDeal != null)
                    result.Add(resultSuperDeal);
            }

            if (!isB2C)
            {
                resultB2CDeal = ent.Tkt_DealType.Where(x => x.DealTypeId == 5).FirstOrDefault();
                if (resultB2CDeal != null)
                    result.Add(resultB2CDeal);
            }

            resultAgentDeal = ent.Tkt_DealType.Where(x => x.DealTypeId == 6).FirstOrDefault();
            if (resultAgentDeal != null)
                result.Add(resultAgentDeal);

            return result.AsQueryable();
        }

        /// <summary>
        ///   Tkt_DealMasters list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllDealMasterList(int productId)
        {
            List<Tkt_DealMasters> all = GetAllDealMaster(productId).OrderBy(z => z.DealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealName + "  ( " + item.Tkt_DealType.DealTypeName + " Type )",
                    Value = item.DealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllDealMasterForAgentClassList(int productId)
        {
            List<Tkt_DealMasters> all = GetAllDealMasterForAgentClass(productId).OrderBy(z => z.DealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealName + "  ( " + item.Tkt_DealType.DealTypeName + " Type )",
                    Value = item.DealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }


        /// <summary>
        ///   Tkt_DealMasters list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllHotelDealMasterList()
        {
            List<Tkt_DealMasters> all = GetAllHotelDealMaster().ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealName + "  ( " + item.Tkt_DealType.DealTypeName + " Type )",
                    Value = item.DealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }

        public IQueryable<Tkt_DealMasters> GetAllHotelDealMaster()
        {
            return ent.Tkt_DealMasters.Where(x => x.ProductId == 2).OrderBy(xx => xx.DealMasterId).AsQueryable();
        }

        public IQueryable<Tkt_DealMasters> GetAllDealMaster(int productId)
        {
            return ent.Tkt_DealMasters.Where(x => x.ProductId == productId && x.DealTypeId!=2).OrderBy(xx => xx.DealMasterId).AsQueryable();
        }

        public IQueryable<Tkt_DealMasters> GetAllDealMasterForAgentClass(int productId)
        {
            return ent.Tkt_DealMasters.Where(x => x.ProductId == productId &&  x.DealTypeId==6).OrderBy(xx => xx.DealName).AsQueryable();
        }


        public IEnumerable<SelectListItem> GetAllIdentifier()
        {
            var allServiceProviders = new List<SelectListItem>();

            return allServiceProviders.AsEnumerable();
        }


        /// <summary>
        ///   AirlineNameList 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllAirlineNameList()
        {
            List<Airlines> all = AirlineNameList().OrderBy(z => z.AirlineName).ToList();
            var GetAllAirlineNameList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineName,
                    Value = item.AirlineId.ToString()
                };
                GetAllAirlineNameList.Add(teml);
            }
            return GetAllAirlineNameList.AsEnumerable();
        }


        /// <summary>
        ///   AirlineNameList 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetCurrencyList()
        {
            List<Currencies> all = ent.Currencies.OrderBy(xx => xx.CurrencyId).AsQueryable().ToList();

            var GetAllCurrencyList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {

                    Text = item.CurrencyCode,
                    Value = item.CurrencyId.ToString()
                };
                GetAllCurrencyList.Add(teml);
            }
            return GetAllCurrencyList.AsEnumerable();
        }

        public IQueryable<Airlines> AirlineNameList()
        {
            return ent.Airlines.OrderBy(xx => xx.AirlineId).AsQueryable();
        }


        /// <summary>
        ///   AgentName list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllAgentNameList()
        {
            List<Agents> all = GetAllAgentList().ToList();
            var GetAllAgentNameList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                GetAllAgentNameList.Add(teml);
            }
            return GetAllAgentNameList.AsEnumerable();
        }
        public IQueryable<Agents> GetAllAgentList()
        {
            return ent.Agents.AsQueryable();
        }

        /// <summary>
        ///   DealAppliedOn list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllDealAppliedOnList()
        {
            List<Tkt_DealAppliedOn> all = DealAppliedOnList().ToList();
            var GetAllDealAppliedOnList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealAppliedOnName,
                    Value = item.DealAppliedOnId.ToString()
                };
                GetAllDealAppliedOnList.Add(teml);
            }
            return GetAllDealAppliedOnList.AsEnumerable();
        }
        public IQueryable<Tkt_DealAppliedOn> DealAppliedOnList()
        {
            return ent.Tkt_DealAppliedOn.Where(x => x.isActive == true).OrderBy(xx => xx.DealAppliedOnId).AsQueryable();
        }

        /// <summary>
        ///   Tkt_DealCalculateOn list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAllDealCalculateOnList()
        {
            List<Tkt_DealCalculateOn> all = DealCalculateOnList().ToList();
            var GetAllDealAppliedOnList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealCalculateOnName,
                    Value = item.DealCalculateOnId.ToString()
                };
                GetAllDealAppliedOnList.Add(teml);
            }
            return GetAllDealAppliedOnList.AsEnumerable();
        }
        public IQueryable<Tkt_DealCalculateOn> DealCalculateOnList()
        {
            return ent.Tkt_DealCalculateOn.OrderBy(xx => xx.DealCalculateOnId).AsQueryable();
        }

        ////////// Add New Airline Deal ///////////////////////////////////////////////////////
        public int AddDealDetails(MasterDealviewModel model)
        {
            Tkt_DealDetails datamodel = new Tkt_DealDetails
            {
                DealMasterId = model.DealMasterId,
                AirlineId = model.AirlineId,
                FromCityId = model.FromCityId,
                ToCityId = model.ToCityId,

                AdultMarkup = model.AdultMarkup,
                ChildMarkup = model.ChildMarkup,
                InfantMarkup = model.InfantMarkup,
                isMarkupPercentage = model.isMarkupPercentage,
                AdultCommission = model.AdultCommission,
                ChildCommission = model.ChildCommission,
                InfantCommission = model.InfantCommission,
                isCommissionPercentage = model.isCommissionPercentage,

                USDAdultMarkup = model.USDAdultMarkup,
                USDChildMarkup = model.USDChildMarkup,
                USDInfantMarkup = model.USDInfantMarkup,
                isUSDMarkupPercentage = model.isUSDMarkupPercentage,
                USDAdultCommission = model.USDAdultCommission,
                USDChildCommission = model.USDChildCommission,
                USDInfantCommission = model.USDInfantCommission,

                isUSDCommissionPercentage = model.isUSDCommissionPercentage,
                isSectorWise = Convert.ToBoolean(model.isSectorWise),
                DealAppliedOnId = model.DealAppliedOnId,
                DealCalculateOnId = model.DealCalculateOnId,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                isDelete = model.isDelete,
            };
            ent.AddToTkt_DealDetails(datamodel);
            ent.SaveChanges();
            int DealMasterId = datamodel.DealMasterId;
            return DealMasterId;

        }
        ////////// create New Master Deal (Tkt_DealMasters)///////////////////////////////////////////
        public void AddDealMaster(MasterDealviewModel model, int productId)
        {
            Tkt_DealMasters datamodel = new Tkt_DealMasters
            {

                DealName = model.DealName,
                DealTypeId = model.DealTypeId,
                EffectiveFrom = model.EffectiveFrom,
                ExpireOn = model.ExpireOn,
                ProductId = productId

            };
            ent.AddToTkt_DealMasters(datamodel);
            ent.SaveChanges();
        }
        ////////////// Listing all Airline Deal Details /////////////////////////////////////////////////

        //////////// create New Master Deal (HTL_DealMasters)///////////////////////////////////////////
        //public void AddHotelDealMaster(MasterDealviewModel model)
        //{
        //    Htl_DealMasters datamodel = new Htl_DealMasters
        //    {

        //        DealName = model.DealName,
        //        DealTypeId = model.DealTypeId,
        //        EffectiveFrom = model.EffectiveFrom,
        //        ExpireOn = model.ExpireOn,

        //    };
        //    ent.AddToHtl_DealMasters(datamodel);
        //    ent.SaveChanges();
        //}
        //////////////// Listing all Airline Deal Details /////////////////////////////////////////////////


        public IQueryable<MasterDealviewModel> GetAllDealDetails()
        {

            var result = ent.Tkt_DealDetails.OrderBy(dd => dd.AirlineId).AsQueryable();
            List<MasterDealviewModel> detailslist = new List<MasterDealviewModel>();
            foreach (var item in result)
            {
                MasterDealviewModel obj = new MasterDealviewModel
                {

                    DealDetailsId = item.DealDetailsId,
                    DealMasterId = item.DealMasterId,
                    AirlineId = item.AirlineId,
                    AirlineName = item.Airlines.AirlineName,
                    //FromCity = item.AirlineCities.CityName,
                    //ToCity = item.AirlineCities1.CityName,
                    FromCity = GetAirlineCityNameByTypeId(item.FromCityId),
                    ToCity = GetAirlineCityNameByTypeId(item.ToCityId),

                    AdultMarkup = item.AdultMarkup,
                    ChildMarkup = item.ChildMarkup,
                    InfantMarkup = item.InfantMarkup,
                    isMarkupPercentage = item.isMarkupPercentage,
                    AdultCommission = item.AdultCommission,
                    ChildCommission = item.ChildCommission,
                    InfantCommission = item.InfantCommission,
                    isCommissionPercentage = item.isCommissionPercentage,

                    USDAdultMarkup = item.USDAdultMarkup,
                    USDChildMarkup = item.USDChildMarkup,
                    USDInfantMarkup = item.USDInfantMarkup,
                    isUSDMarkupPercentage = item.isUSDMarkupPercentage,
                    USDAdultCommission = item.USDAdultCommission,
                    USDChildCommission = item.USDChildCommission,
                    USDInfantCommission = item.USDInfantCommission,

                    isSectorWise = item.isSectorWise,
                    DealAppliedOnId = item.DealAppliedOnId,
                    DealAppliedOnName = item.Tkt_DealAppliedOn.DealAppliedOnName,
                    DealCalculateOnId = item.DealCalculateOnId,
                    DealCalculateOnName = item.Tkt_DealCalculateOn.DealCalculateOnName,

                    isUSDCommissionPercentage = item.isUSDCommissionPercentage,


                };
                detailslist.Add(obj);
            }
            return detailslist.AsQueryable();
        }

        ////////////// Listing all Airline Deal Details by Deal Master Id /////////////////////////////

        public IQueryable<MasterDealviewModel> GetAllDealDetailsByDealMasterId(int DealMasterId)
        {

            var result = ent.Tkt_DealDetails.OrderBy(dd => dd.AirlineId).Where(dd => dd.DealMasterId == DealMasterId).AsQueryable();
            List<MasterDealviewModel> detailslist = new List<MasterDealviewModel>();
            foreach (var item in result)
            {
                MasterDealviewModel obj = new MasterDealviewModel
                {

                    DealDetailsId = item.DealDetailsId,
                    DealMasterId = item.DealMasterId,
                    AirlineId = item.AirlineId,
                    AirlineName = item.Airlines.AirlineName,
                    FromCity = GetAirlineCityNameByTypeId(item.FromCityId),
                    ToCity = GetAirlineCityNameByTypeId(item.ToCityId),

                    AdultMarkup = item.AdultMarkup,
                    ChildMarkup = item.ChildMarkup,
                    InfantMarkup = item.InfantMarkup,
                    isMarkupPercentage = item.isMarkupPercentage,
                    AdultCommission = item.AdultCommission,
                    ChildCommission = item.ChildCommission,
                    InfantCommission = item.InfantCommission,
                    isCommissionPercentage = item.isCommissionPercentage,

                    USDAdultMarkup = item.USDAdultMarkup,
                    USDChildMarkup = item.USDChildMarkup,
                    USDInfantMarkup = item.USDInfantMarkup,
                    isUSDMarkupPercentage = item.isUSDMarkupPercentage,
                    USDAdultCommission = item.USDAdultCommission,
                    USDChildCommission = item.USDChildCommission,
                    USDInfantCommission = item.USDInfantCommission,

                    DealAppliedOnId = item.DealAppliedOnId,
                    DealAppliedOnName = item.Tkt_DealAppliedOn.DealAppliedOnName,
                    DealCalculateOnId = item.DealCalculateOnId,
                    DealCalculateOnName = item.Tkt_DealCalculateOn.DealCalculateOnName,
                    isUSDCommissionPercentage = item.isUSDCommissionPercentage,


                };
                detailslist.Add(obj);
            }
            return detailslist.AsQueryable();
        }

        /////////////////// Get Individual Details of Deal ofr edit/details /////////////////////////////////////////////////////////////

        public MasterDealviewModel GetDetailsOfIndividualDeal(int id)
        {
            var result = (from item in ent.Tkt_DealDetails
                          where item.DealDetailsId == id
                          select new MasterDealviewModel
                          {
                              DealDetailsId = item.DealDetailsId,
                              DealMasterId = item.DealMasterId,
                              AirlineId = item.AirlineId,
                              AirlineName = item.Airlines.AirlineName,
                              FromCity = item.AirlineCities.CityName,
                              ToCity = item.AirlineCities1.CityName,

                              AdultMarkup = item.AdultMarkup,
                              ChildMarkup = item.ChildMarkup,
                              InfantMarkup = item.InfantMarkup,
                              isMarkupPercentage = item.isMarkupPercentage,
                              AdultCommission = item.AdultCommission,
                              ChildCommission = item.ChildCommission,
                              InfantCommission = item.InfantCommission,
                              isCommissionPercentage = item.isCommissionPercentage,

                              USDAdultMarkup = item.USDAdultMarkup,
                              USDChildMarkup = item.USDChildMarkup,
                              USDInfantMarkup = item.USDInfantMarkup,
                              isUSDMarkupPercentage = item.isUSDMarkupPercentage,
                              USDAdultCommission = item.USDAdultCommission,
                              USDChildCommission = item.USDChildCommission,
                              USDInfantCommission = item.USDInfantCommission,


                              isSectorWise = item.isSectorWise,
                              DealAppliedOnId = item.DealAppliedOnId,
                              DealAppliedOnName = item.Tkt_DealAppliedOn.DealAppliedOnName,
                              DealCalculateOnId = item.DealCalculateOnId,
                              DealCalculateOnName = item.Tkt_DealCalculateOn.DealCalculateOnName,

                              isUSDCommissionPercentage = item.isUSDCommissionPercentage


                          }).SingleOrDefault();
            return result;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetAirlineCityNameByTypeId(int? City)
        {
            AirlineCities type = new AirlineCities();
            string CityName = "";
            if (City != null)
            {
                type = ent.AirlineCities.Where(xx => xx.CityID == City).SingleOrDefault();
                CityName = type.CityName;
            }

            return CityName;
        }
        //////////// Get Details of Deal Master By DealMasterId ////////////////////////////////////////////////////////

        public MasterDealviewModel GetDealMasterDetailsByDealMasterId(int DealMasterId)
        {
            var cc = (from aa in ent.Tkt_DealMasters
                      join bb in ent.Tkt_DealType
                      on aa.DealTypeId equals bb.DealTypeId
                      where aa.DealMasterId == DealMasterId
                      select new MasterDealviewModel
                      {
                          DealMasterId = DealMasterId,
                          DealName = aa.DealName,
                          DealTypeId = aa.DealTypeId,
                          DealTypeName = bb.DealTypeName,
                          EffectiveFrom = aa.EffectiveFrom,
                          ExpireOn = aa.ExpireOn,
                      }).SingleOrDefault();
            return cc;
        }
        ////////////////////////// Edit Deal Details ///////////////////////////////////////////////////////////////////////////

        public void UpdateDealDetails(MasterDealviewModel modeltosave)
        {
            Tkt_DealDetails comm = ent.Tkt_DealDetails.Where(u => u.DealDetailsId == modeltosave.DealDetailsId).FirstOrDefault();
            comm.DealDetailsId = modeltosave.DealDetailsId;

            comm.AdultCommission = modeltosave.AdultCommission;
            comm.ChildCommission = modeltosave.ChildCommission;
            comm.InfantCommission = modeltosave.InfantCommission;

            comm.AdultMarkup = modeltosave.AdultMarkup;
            comm.ChildMarkup = modeltosave.ChildMarkup;
            comm.InfantMarkup = modeltosave.InfantMarkup;

            comm.USDAdultMarkup = modeltosave.USDAdultMarkup;
            comm.USDChildMarkup = modeltosave.USDChildMarkup;
            comm.USDInfantMarkup = modeltosave.USDInfantMarkup;


            comm.isUSDMarkupPercentage = modeltosave.isUSDMarkupPercentage;
            comm.isMarkupPercentage = modeltosave.isMarkupPercentage;

            comm.isUSDCommissionPercentage = modeltosave.isUSDCommissionPercentage;
            comm.isCommissionPercentage = modeltosave.isCommissionPercentage;


            comm.USDAdultCommission = modeltosave.USDAdultCommission;
            comm.USDChildCommission = modeltosave.USDChildCommission;
            comm.USDInfantCommission = modeltosave.USDInfantCommission;

            comm.DealAppliedOnId = modeltosave.DealAppliedOnId;
            comm.DealCalculateOnId = modeltosave.DealCalculateOnId;

            ent.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            ent.SaveChanges();
            /////
        }
        ////////////////////////// Edit/Updates Master Deal Details ///////////////////////////////////////////////////////////////////////////

        public void UpdateMasterDealDetails(MasterDealviewModel modeltosave)
        {
            Tkt_DealMasters comm = ent.Tkt_DealMasters.Where(u => u.DealMasterId == modeltosave.DealMasterId).FirstOrDefault();
            comm.DealMasterId = modeltosave.DealMasterId;
            comm.DealName = modeltosave.DealName;
            comm.DealTypeId = modeltosave.DealTypeId;
            comm.EffectiveFrom = modeltosave.EffectiveFrom;
            comm.ExpireOn = modeltosave.ExpireOn;
            ent.ApplyCurrentValues(comm.EntityKey.EntitySetName, comm);
            ent.SaveChanges();
            /////
        }
        //////////////// Delete Deal Details by Id ///////////////////////////////////////////
        public void DeleteDealDetailsInfo(int id)
        {
            Tkt_DealDetails datatodelete = ent.Tkt_DealDetails.First(m => m.DealDetailsId == id);
            datatodelete.DealDetailsId = id;
            ent.DeleteObject(datatodelete);
            ent.SaveChanges();
        }
        //////////////////////////////////////////////////////////////////////////////
        public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult)
        {
            return GetAllAirlineCityList(AirlineCityName, maxResult).ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IEnumerable<AirlineCities> GetAllAirlineCityList(string AirlineCityNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.Where(x => (x.CityName.ToLower().StartsWith(AirlineCityNameCode.ToLower()) || x.CityName.ToLower().StartsWith(AirlineCityNameCode.ToLower()) || x.CityCode.ToUpper().StartsWith(AirlineCityNameCode.ToUpper()) || x.CityCode.ToUpper().StartsWith(AirlineCityNameCode.ToUpper()))).Take(maxResult).ToList().Select(x =>
                                new AirlineCities { CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                );
        }
        /////////////////////////////////// Airline Search          //////////////////////////////////////////////////////////
        public List<Airlines> GetAirlineName(string AirlineName, int maxResult)
        {
            return GetAllAirlineNameList(AirlineName, maxResult).ToList();
        }

        public IEnumerable<Airlines> GetAllAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => (x.AirlineCode.ToLower().StartsWith(AirlineNameCode.ToLower()) || x.AirlineName.ToLower().StartsWith(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        /////////////////////////Method For  Copy Deal   //////////////////////////////////////////////////////////

        public void CopyDealfromOneToAnother(string newDealName, int copyFromDealId, int dealTypeId, DateTime? effectiveFrom, DateTime? expireOn)
        {
            ent.CopyDeal(newDealName, copyFromDealId, dealTypeId, effectiveFrom, expireOn);

        }
        ///////////////////////////////////////// Check if Airline Name Already Exist ////////////////////////////
        public bool CheckIfSectorAlreadyExists(int AirlineId, int MasterdealId, int? FromCity, int? ToCity)
        {
            bool flag = false;
            var isdefault = ent.Tkt_DealDetails.Where(ii => ((ii.AirlineId == AirlineId) && (ii.DealMasterId == MasterdealId))).ToList();

            if (isdefault != null && isdefault.Count > 0)
            {
                foreach (var value in isdefault)
                {
                    if ((value.FromCityId == FromCity) && (value.ToCityId == ToCity))
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            else
                flag = true;
            return flag;

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CheckIfContainDefaultTypeDeal(int productId)
        {
            Tkt_DealMasters isdefault = ent.Tkt_DealMasters.Where(ii => ii.DealTypeId == 3 && ii.ProductId == productId).FirstOrDefault();
            if (isdefault != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfContainMasterTypeDeal(int productId)
        {
            Tkt_DealMasters isMaster = ent.Tkt_DealMasters.Where(ii => ii.DealTypeId == 1 && ii.ProductId == productId).FirstOrDefault();
            if (isMaster != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfContainSuperTypeDeal(int productId)
        {
            Tkt_DealMasters isSuper = ent.Tkt_DealMasters.Where(ii => ii.DealTypeId == 4 && ii.ProductId == productId).FirstOrDefault();
            if (isSuper != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfContainB2CTypeDeal(int productId)
        {
            Tkt_DealMasters isB2C = ent.Tkt_DealMasters.Where(ii => ii.DealTypeId == 5 && ii.ProductId == productId).FirstOrDefault();
            if (isB2C != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ////////////////////////////// Get All Agents Associated in deal ////////////////////////////////////////////////////
        public List<MasterDealviewModel> GetDealDetailsByAgent(int DealMasterId)
        {
            var cc = (from aa in ent.Tkt_DealMasters
                      join bb in ent.Core_AgentsDeals
                      on aa.DealMasterId equals bb.MasterDealId
                      where aa.DealMasterId == DealMasterId
                      select new MasterDealviewModel
                      {
                          AgentId = bb.AgentId,
                          AgentName = bb.Agents.AgentName,
                          DealName = aa.DealName,
                      }).ToList();
            return cc;
        }
        ////////////////////////////// Get Deal List By Airline ////////////////////////////////////////////////////
        public IQueryable<MasterDealviewModel> GetAllDealDetailsByAirline(int AirlineId)
        {

            var result = ent.Tkt_DealDetails.OrderBy(dd => dd.DealDetailsId).Where(dd => dd.AirlineId == AirlineId).AsQueryable();
            List<MasterDealviewModel> detailslist = new List<MasterDealviewModel>();
            foreach (var item in result)
            {
                MasterDealviewModel obj = new MasterDealviewModel
                {

                    DealDetailsId = item.DealDetailsId,
                    DealName = item.Tkt_DealMasters.DealName,
                    DealMasterId = item.DealMasterId,
                    AirlineId = item.AirlineId,
                    AirlineName = item.Airlines.AirlineName,
                    FromCity = GetAirlineCityNameByTypeId(item.FromCityId),
                    ToCity = GetAirlineCityNameByTypeId(item.ToCityId),

                    AdultMarkup = item.AdultMarkup,
                    ChildMarkup = item.ChildMarkup,
                    InfantMarkup = item.InfantMarkup,
                    isMarkupPercentage = item.isMarkupPercentage,
                    AdultCommission = item.AdultCommission,
                    ChildCommission = item.ChildCommission,
                    InfantCommission = item.InfantCommission,
                    isCommissionPercentage = item.isCommissionPercentage,

                    USDAdultMarkup = item.USDAdultMarkup,
                    USDChildMarkup = item.USDChildMarkup,
                    USDInfantMarkup = item.USDInfantMarkup,
                    isUSDMarkupPercentage = item.isUSDMarkupPercentage,
                    USDAdultCommission = item.USDAdultCommission,
                    USDChildCommission = item.USDChildCommission,
                    USDInfantCommission = item.USDInfantCommission,

                    DealAppliedOnId = item.DealAppliedOnId,
                    DealAppliedOnName = item.Tkt_DealAppliedOn.DealAppliedOnName,
                    DealCalculateOnId = item.DealCalculateOnId,
                    DealCalculateOnName = item.Tkt_DealCalculateOn.DealCalculateOnName,
                    isUSDCommissionPercentage = item.isUSDCommissionPercentage


                };
                detailslist.Add(obj);
            }
            return detailslist.AsQueryable();
        }

        public IEnumerable<SelectListItem> GetDealIdentifiers(int id)
        {
            List<ServiceProviders> all = GetAllServiceProviders().Where(xx => xx.isActive == true && xx.ServiceType == "FLT").OrderBy(z => z.AgentDealIdentifier).ToList();
            var serviceProviderList = new List<SelectListItem>();

            if (id == 1)
            {
                foreach (var item in all)
                {
                    var teml = new SelectListItem
                    {
                        Text = item.MasterDealIdentifier,
                        Value = item.ServiceProviderId.ToString()
                    };
                    serviceProviderList.Add(teml);
                }
            }
            else if (id == 2 || id == 6)
            {
                foreach (var item in all)
                {
                    var teml = new SelectListItem
                    {
                        Text = item.AgentDealIdentifier,
                        Value = item.ServiceProviderId.ToString()
                    };
                    serviceProviderList.Add(teml);
                }
            }
            else if (id == 3)
            {
                foreach (var item in all)
                {
                    var teml = new SelectListItem
                    {
                        Text = item.DefaultDealIdentifier,
                        Value = item.ServiceProviderId.ToString()
                    };
                    serviceProviderList.Add(teml);
                }
            }
            else if (id == 4)
            {
                foreach (var item in all)
                {
                    var teml = new SelectListItem
                    {
                        Text = item.SuperDealIdentifier,
                        Value = item.ServiceProviderId.ToString()
                    };
                    serviceProviderList.Add(teml);
                }
            }
            else if (id == 5)
            {
                foreach (var item in all)
                {
                    var teml = new SelectListItem
                    {
                        Text = item.B2CDealIdentifier,
                        Value = item.ServiceProviderId.ToString()
                    };
                    serviceProviderList.Add(teml);
                }
            }

            var _serviceProviderList = new List<SelectListItem>();
            foreach (var item in serviceProviderList)
            {
                int c = _serviceProviderList.Where(x => x.Text == item.Text).Count();
                if (c == 0)
                {
                    _serviceProviderList.Add(item);
                }
                
            }

            return _serviceProviderList;
        }

        public IQueryable<ServiceProviders> GetAllServiceProviders()
        {
            return ent.ServiceProviders.AsQueryable();
        }

        public Tkt_DealMasters GetDealMasterById(int? id)
        {
            return ent.Tkt_DealMasters.Where(x => x.DealMasterId == id).FirstOrDefault();
        }

        public int Save_Tkt_Deals(DealViewModel model)
        {
            Tkt_Deals objToSave = new Tkt_Deals();

            objToSave.DealMasterId = model.DealMasterId;
            objToSave.AirlineId = model.AirlineId;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.DealIdentifier = model.DealIdentifierText;
            objToSave.SectorType = model.SectorType;
            if (model.isSectorWise == true)
            {
                objToSave.FromCityId = model.FromCityId;
                objToSave.ToCityId = model.ToCityId;
            }
            else
            {
                objToSave.FromCityId = null;
                objToSave.ToCityId = null;
            }
            objToSave.AdultMarkup = model.AdultMarkup;
            objToSave.ChildMarkup = model.ChildMarkup;
            objToSave.InfantMarkup = model.InfantMarkup;

            objToSave.AdultYQCommission = model.AdultYQCommission;
            objToSave.ChildYQCommission = model.ChildYQCommission;
            objToSave.InfantYQCommission = model.InfantYQCommission;
            objToSave.isYQCommissionPercentage = model.isYQCommissionPercentage;

            objToSave.AdultBFCommission = model.AdultBFCommission;
            objToSave.ChildBFCommission = model.ChildBFCommission;
            objToSave.InfantBFCommission = model.InfantBFCommission;
            objToSave.isBFCommissionPercentage = model.isBFCommissionPercentage;


            objToSave.AdultYQBFCommission = model.AdultYQBFCommission;
            objToSave.ChildYQBFCommission = model.ChildYQBFCommission;
            objToSave.InfantYQBFCommission = model.InfantYQBFCommission;
            objToSave.isYQBFCommissionPercentage = model.isYQBFCommissionPercentage;


            objToSave.isSectorWise = model.isSectorWise;

            objToSave.AirlineClass = model.AirlineClass != null ? model.AirlineClass.Trim() : null;

            objToSave.isRoundTrip = model.isRoundTrip;
            objToSave.isMarkupPercentage = model.isMarkupPercentage;
            objToSave.DealCalculateOnId = model.DealCalculateOnId;
            objToSave.Cashback = model.Cashback;
            objToSave.VersionNo = 1;

            objToSave.MakerId = model.MakerId;
            objToSave.MakerDate = model.MakerDate;
            objToSave.isVerified = model.isVerified;
            objToSave.VerifiedBy = model.VerifiedBy;
            objToSave.VerifiedDate = model.VerifiedDate;

            ent.AddToTkt_Deals(objToSave);
            ent.SaveChanges();
            return objToSave.DealId;
        }

        public bool Update_Tkt_Deals(DealViewModel model)
        {

            Edit_Tkt_Deals(model.DealId, model.UpdatedBy.Value);

            Tkt_Deals objToUpdate = new Tkt_Deals();
            objToUpdate = ent.Tkt_Deals.Where(x => x.DealId == model.DealId).FirstOrDefault();


            objToUpdate.DealMasterId = model.DealMasterId;
            objToUpdate.AirlineId = model.AirlineId;
            objToUpdate.CurrencyId = model.CurrencyId;
            objToUpdate.DealIdentifier = model.DealIdentifierText;
            objToUpdate.SectorType = model.SectorType;
            if (model.isSectorWise == true)
            {
                objToUpdate.FromCityId = model.FromCityId;
                objToUpdate.ToCityId = model.ToCityId;
            }
            else if (model.isSectorWise == false)
            {
                objToUpdate.FromCityId = null;
                objToUpdate.ToCityId = null;
            }
            objToUpdate.AdultMarkup = model.AdultMarkup;
            objToUpdate.ChildMarkup = model.ChildMarkup;
            objToUpdate.InfantMarkup = model.InfantMarkup;
            objToUpdate.AdultYQCommission = model.AdultYQCommission;
            objToUpdate.ChildYQCommission = model.ChildYQCommission;
            objToUpdate.InfantYQCommission = model.InfantYQCommission;
            objToUpdate.isYQCommissionPercentage = model.isYQCommissionPercentage;

            objToUpdate.AdultBFCommission = model.AdultBFCommission;
            objToUpdate.ChildBFCommission = model.ChildBFCommission;
            objToUpdate.InfantBFCommission = model.InfantBFCommission;
            objToUpdate.isBFCommissionPercentage = model.isBFCommissionPercentage;

            objToUpdate.AdultYQBFCommission = model.AdultYQBFCommission;
            objToUpdate.ChildYQBFCommission = model.ChildYQBFCommission;
            objToUpdate.InfantYQBFCommission = model.InfantYQBFCommission;
            objToUpdate.isYQBFCommissionPercentage = model.isYQBFCommissionPercentage;

            objToUpdate.isSectorWise = model.isSectorWise;
           

            objToUpdate.AirlineClass = model.AirlineClass != null ? model.AirlineClass.Trim() : null;
            objToUpdate.isRoundTrip = model.isRoundTrip;

            objToUpdate.isMarkupPercentage = model.isMarkupPercentage;
            objToUpdate.DealCalculateOnId = model.DealCalculateOnId;

            objToUpdate.Cashback = model.Cashback;
            objToUpdate.UpdatedBy = model.UpdatedBy;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Delete_Tkt_Deals(int dealId, int userId)
        {
            Tkt_Deals objToDelete = new Tkt_Deals();
            ent.Tkt_SaveChangesOnDeal(dealId, userId, "D");
            return true;
        }

        public bool Delete_Tkt_DealMasters(int masterDealId, int userId)
        {
            //Tkt_DealMasters objToDelete = new Tkt_DealMasters();
            //objToDelete = ent.Tkt_DealMasters.Where(x => x.DealMasterId == masterDealId).FirstOrDefault();
            //ent.DeleteObject(objToDelete);            
            //ent.SaveChanges();
            ent.TKT_SaveChangesOnMasterDeal(masterDealId, userId, "D", false);
            return true;
        }

        public bool Delete_TKT_ForceDeleteMasterDeal(int masterDealId, int userId)
        {
            ent.TKT_SaveChangesOnMasterDeal(masterDealId, userId, "D", true);
            return true;
        }

        public bool Edit_Tkt_Deals(int dealId, int userId)
        {
            Tkt_Deals objToDelete = new Tkt_Deals();
            ent.Tkt_SaveChangesOnDeal(dealId, userId, "E");
            return true;
        }


        public IEnumerable<DealViewModel> GetAllDeals(int? dealMasterId, string FilterDealIdentifierId, int? FilterAirlineId, int? FilterCurrencyId)
        {
            List<DealViewModel> dealViewList = new List<DealViewModel>();

            IEnumerable<Tkt_Deals> deals = new List<Tkt_Deals>();
            if (dealMasterId != null)
                deals = ent.Tkt_Deals.Where(xx => xx.DealMasterId == dealMasterId);

            if (!string.IsNullOrEmpty(FilterDealIdentifierId))
                deals = deals.Where(x => x.DealIdentifier == FilterDealIdentifierId);

            if (FilterAirlineId != null)
                deals = deals.Where(x => x.AirlineId == FilterAirlineId);

            if (FilterCurrencyId != null)
                deals = deals.Where(x => x.CurrencyId == FilterCurrencyId);

            foreach (Tkt_Deals deal in deals)
            {
                DealViewModel dealViewModel = new DealViewModel();

                dealViewModel.DealId = deal.DealId;
                dealViewModel.DealMasterId = deal.DealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineName = deal.AirlinesReference.Value != null ? deal.AirlinesReference.Value.AirlineName : null;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.CurrenciesReference.Value.CurrencyCode;
                dealViewModel.DealIdentifierId = deal.DealId;
                dealViewModel.DealIdentifierText = deal.DealIdentifier;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.isSectorWise = deal.isSectorWise;
                dealViewModel.FromCityId = deal.FromCityId;

                //if (deal.FromCityId != null)
                //    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                //dealViewModel.ToCityId = deal.ToCityId;
                //if (deal.ToCityId != null)
                //    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;

                dealViewModel.AdultMarkup = deal.AdultMarkup;
                dealViewModel.ChildMarkup = deal.ChildMarkup;
                dealViewModel.InfantMarkup = deal.InfantMarkup;
                dealViewModel.AdultYQCommission = deal.AdultYQCommission;
                dealViewModel.ChildYQCommission = deal.ChildYQCommission;
                dealViewModel.InfantYQCommission = deal.InfantYQCommission;
                dealViewModel.isYQCommissionPercentage = deal.isYQCommissionPercentage;

                dealViewModel.AdultBFCommission = deal.AdultBFCommission;
                dealViewModel.ChildBFCommission = deal.ChildBFCommission;
                dealViewModel.InfantBFCommission = deal.InfantBFCommission;
                dealViewModel.isBFCommissionPercentage = deal.isBFCommissionPercentage;

                dealViewModel.AdultYQBFCommission = deal.AdultYQBFCommission;
                dealViewModel.ChildYQBFCommission = deal.ChildYQBFCommission;
                dealViewModel.InfantYQBFCommission = deal.InfantYQBFCommission;
                dealViewModel.isYQBFCommissionPercentage = deal.isYQBFCommissionPercentage;


                dealViewModel.AirlineClass = deal.AirlineClass != null ? deal.AirlineClass.Trim() : null; ;

                dealViewModel.isRoundTrip = deal.isRoundTrip;

                dealViewModel.isMarkupPercentage = deal.isMarkupPercentage;
                dealViewModel.DealCalculateOnId = deal.DealCalculateOnId;
                dealViewModel.DealCalculatedOnText = deal.Tkt_DealCalculateOnReference.Value.DealCalculateOnName;

                dealViewModel.Cashback = deal.Cashback;

                dealViewModel.MakerId = deal.MakerId;
                dealViewModel.MakerDate = deal.MakerDate;
                dealViewModel.isVerified = deal.isVerified;
                dealViewModel.VerifiedBy = deal.VerifiedBy;
                dealViewModel.VerifiedDate = deal.VerifiedDate;
                dealViewModel.UpdatedBy = deal.UpdatedBy;
                dealViewModel.UpdatedDate = deal.UpdatedDate;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.AirlineName).ThenBy(x => x.Currency);
        }

        public DealViewModel GetDealDetail(int? dealId)
        {
            List<DealViewModel> dealViewList = new List<DealViewModel>();

            //List<Tkt_Deals> deals = ent.Tkt_Deals.Where(xx => xx.isDelete == false).ToList();

            List<Tkt_Deals> deals = ent.Tkt_Deals.Where(xx => xx.DealId == dealId).ToList();
            DealViewModel dealViewModel = new DealViewModel();
            foreach (Tkt_Deals deal in deals)
            {


                dealViewModel.DealId = deal.DealId;
                dealViewModel.DealMasterId = deal.DealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineName = deal.AirlinesReference.Value != null ? deal.AirlinesReference.Value.AirlineName : null;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.CurrenciesReference.Value.CurrencyCode;
                dealViewModel.DealIdentifierId = GetDealIdentifierIdByIdentifier(deal.DealMasterId, deal.DealIdentifier);
                dealViewModel.DealIdentifierText = deal.DealIdentifier;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.isSectorWise = deal.isSectorWise;
                dealViewModel.FromCityId = deal.FromCityId;

                //if (deal.FromCityId != null)
                //    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                //dealViewModel.ToCityId = deal.ToCityId;
                //if (deal.ToCityId != null)
                //    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;

                dealViewModel.AdultMarkup = deal.AdultMarkup;
                dealViewModel.ChildMarkup = deal.ChildMarkup;
                dealViewModel.InfantMarkup = deal.InfantMarkup;
                dealViewModel.AdultYQCommission = deal.AdultYQCommission;
                dealViewModel.ChildYQCommission = deal.ChildYQCommission;
                dealViewModel.InfantYQCommission = deal.InfantYQCommission;
                dealViewModel.isYQCommissionPercentage = deal.isYQCommissionPercentage;

                dealViewModel.AdultBFCommission = deal.AdultBFCommission;
                dealViewModel.ChildBFCommission = deal.ChildBFCommission;
                dealViewModel.InfantBFCommission = deal.InfantBFCommission;
                dealViewModel.isBFCommissionPercentage = deal.isBFCommissionPercentage;

                dealViewModel.AdultYQBFCommission = deal.AdultYQBFCommission;
                dealViewModel.ChildYQBFCommission = deal.ChildYQBFCommission;
                dealViewModel.InfantYQBFCommission = deal.InfantYQBFCommission;
                dealViewModel.isYQBFCommissionPercentage = deal.isYQBFCommissionPercentage;


                dealViewModel.AirlineClass = deal.AirlineClass != null ? deal.AirlineClass.Trim() : null;
                dealViewModel.isRoundTrip = deal.isRoundTrip;

                dealViewModel.isMarkupPercentage = deal.isMarkupPercentage;
                dealViewModel.DealCalculateOnId = deal.DealCalculateOnId;
                dealViewModel.DealCalculatedOnText = deal.Tkt_DealCalculateOnReference.Value.DealCalculateOnName;

                dealViewModel.Cashback = deal.Cashback;

                dealViewModel.MakerId = deal.MakerId;
                dealViewModel.MakerDate = deal.MakerDate;
                dealViewModel.isVerified = deal.isVerified;
                dealViewModel.VerifiedBy = deal.VerifiedBy;
                dealViewModel.VerifiedDate = deal.VerifiedDate;
                dealViewModel.UpdatedBy = deal.UpdatedBy;
                dealViewModel.UpdatedDate = deal.UpdatedDate;


            }
            return dealViewModel;
        }

        public int GetDealIdentifierIdByIdentifier(int? id, string identifier)
        {
            var dealtype = GetDealMasterById(id ?? 0);

            List<ServiceProviders> all = GetAllServiceProviders().Where(xx => xx.isActive == true).ToList();
            int serviceProviderId = 0;
            if (dealtype.DealTypeId == 1 )
            {
                serviceProviderId = all.Where(x => x.MasterDealIdentifier == identifier).FirstOrDefault().ServiceProviderId;
            }
            else if (dealtype.DealTypeId == 2 || dealtype.DealTypeId == 6)
            {
                serviceProviderId = all.Where(x => x.AgentDealIdentifier == identifier).FirstOrDefault().ServiceProviderId;
            }
            else if (dealtype.DealTypeId == 3)
            {
                serviceProviderId = all.Where(x => x.DefaultDealIdentifier == identifier).FirstOrDefault().ServiceProviderId;
            }
            else if (dealtype.DealTypeId == 4)
            {
                serviceProviderId = all.Where(x => x.SuperDealIdentifier == identifier).FirstOrDefault().ServiceProviderId;
            }
            else if (dealtype.DealTypeId == 5)
            {
                serviceProviderId = all.Where(x => x.B2CDealIdentifier == identifier).FirstOrDefault().ServiceProviderId;
            }
            return serviceProviderId;
        }
    }
}