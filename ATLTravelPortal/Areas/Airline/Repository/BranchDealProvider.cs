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
    public class BranchDealProvider
    {
        EntityModel ent = new EntityModel();
        AirLineCityInformationProvider cityProvider = new AirLineCityInformationProvider();

        public Core_BranchDealMasters GetBranchDealMasterById(int? id)
        {
            return ent.Core_BranchDealMasters.Where(x => x.BranchDealMasterId == id).FirstOrDefault();
        }

        public Core_DistributorDealMasters GetDistributorDealMasterById(int? id)
        {
            return ent.Core_DistributorDealMasters.Where(x => x.DistributorDealMasterId == id).FirstOrDefault();
        }


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

        public IEnumerable<SelectListItem> GetAllBusOperatorList()
        {
            List<Bus_Master> all = BusOperatorNameList().ToList();
            var GetAllBusOperatorNameList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BusMasterName,
                    Value = item.BusMasterId.ToString()
                };
                GetAllBusOperatorNameList.Add(teml);
            }
            return GetAllBusOperatorNameList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllBusCategoryList(int masterId)
        {
            List<Bus_Categories> all = GetAllCategoryByMasterId(masterId).ToList();
            var GetAllBusCategoryNameList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BusCategoryName,
                    Value = item.BusCategoryId.ToString()
                };
                GetAllBusCategoryNameList.Add(teml);
            }
            return GetAllBusCategoryNameList.AsEnumerable();
        }


        public IQueryable<Airlines> AirlineNameList()
        {
            return ent.Airlines.OrderBy(xx => xx.AirlineId).AsQueryable();
        }

        public IQueryable<Bus_Master> BusOperatorNameList()
        {
            return ent.Bus_Master.OrderBy(xx => xx.BusMasterName).AsQueryable();
        }

        public IQueryable<Bus_Categories> GetAllCategoryByMasterId(int masterid)
        {
            var result = from a in ent.Bus_Categories
                         join b in ent.Bus_OperatorBusCategory on a.BusCategoryId equals b.BusCategoryId
                         where b.BusMasterId == masterid
                         orderby a.BusCategoryName
                         select a;

            return result;
        }


        public string GetBranchCodeByBranchId(int branchofficeid)
        {
            var res = ent.BranchOffices.Where(x => x.BranchOfficeId == branchofficeid).Select(x => x.BranchOfficeCode).FirstOrDefault();
            return res;
        }

        public string GetDistributorCodeByDistributorId(int distributorid)
        {
            var res = ent.Distributors.Where(x => x.DistributorId == distributorid).Select(x => x.DistributorCode).FirstOrDefault();
            return res;
        }


        public IEnumerable<SelectListItem> GetAllDistributorDealMasterList(int productId, int distributorid)
        {
            string DistributorCode = GetDistributorCodeByDistributorId(distributorid);
            List<Core_DistributorDealMasters> all = GetAllDistributorDealMaster(productId, distributorid).OrderBy(z => z.DistributorDealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    //Text = DistributorCode + " ( " + item.DistributorDealName + " ) ",
                    Text = item.DistributorDealName,
                    Value = item.DistributorDealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }

        public IQueryable<Core_DistributorDealMasters> GetAllDistributorDealMaster(int productId, int distributorid)
        {
            return ent.Core_DistributorDealMasters.Where(x => (x.ProductId == productId && x.DistributorId == distributorid)).OrderBy(xx => xx.DistributorDealMasterId).AsQueryable();
        }

        public IQueryable<Core_BranchDealMasters> GetAllBranchDealMaster(int productId, int branchOfficeId)
        {
            return ent.Core_BranchDealMasters.Where(x => (x.ProductId == productId && x.BranchOfficeId == branchOfficeId)).OrderBy(xx => xx.BranchDealMasterId).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetAllBranchDealMasterList(int productId, int branchofficeid)
        {
            string BranchCode = GetBranchCodeByBranchId(branchofficeid);
            List<Core_BranchDealMasters> all = GetAllDealMaster(productId, branchofficeid).OrderBy(z => z.BranchDealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    //Text = BranchCode + " ( " + item.BranchDealName + " ) ",
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealMasterList.Add(teml);
            }
            return GetAllDealMasterList.AsEnumerable();
        }

        public IQueryable<Core_BranchDealMasters> GetAllDealMaster(int productId, int branchofficeid)
        {
            return ent.Core_BranchDealMasters.Where(x => (x.ProductId == productId && x.BranchOfficeId == branchofficeid)).OrderBy(xx => xx.BranchDealMasterId).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetCurrencyList()
        {
            List<Currencies> all = ent.Currencies.Where(z => z.CurrencyCode == "NPR" || z.CurrencyCode == "USD").OrderBy(xx => xx.CurrencyId).AsQueryable().ToList();

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

        public IEnumerable<BranchDealViewModel> GetAllDeals(int? dealMasterId, string FilterDealIdentifierId, int? FilterAirlineId, int? FilterCurrencyId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Air_BranchDeals> deals = new List<Air_BranchDeals>();
            if (dealMasterId != null)
                deals = ent.Air_BranchDeals.Where(xx => xx.BranchDealMasterId == dealMasterId);

            if (FilterAirlineId != null)
                deals = deals.Where(x => x.AirlineId == FilterAirlineId);

            foreach (Air_BranchDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineName = GetAirlineNameByAirlineId(dealViewModel.AirlineId);//.AirlinesReference.Value != null ? deal.AirlinesReference.Value.AirlineName : null;
                dealViewModel.AirlineClass = deal.Class;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;
                dealViewModel.DealIdentifierId = deal.BranchDealId;
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;
                dealViewModel.isRoundTrip = deal.isRoundTrip;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.AirlineName).ThenBy(x => x.Currency);
        }
        public string GetAirlineNameByAirlineId(int? Airlineid)
        {
            var res = ent.Airlines.Where(x => x.AirlineId == Airlineid).Select(x => x.AirlineName).FirstOrDefault();
            return res;
        }

        public bool Update_Air_BranchDeals(BranchDealViewModel model)
        {

            // Edit_Air_BranchDeals(model.DealId, model.UpdatedBy.Value);

            Air_BranchDeals objToUpdate = new Air_BranchDeals();
            objToUpdate = ent.Air_BranchDeals.Where(x => x.BranchDealId == model.DealId).FirstOrDefault();
            objToUpdate.BranchDealMasterId = model.DealMasterId;
            objToUpdate.AirlineId = model.AirlineId;
            objToUpdate.Class = model.AirlineClass != null ? model.AirlineClass.Trim() : model.AirlineClass;
            objToUpdate.SectorType = model.SectorType;
            objToUpdate.CurrencyId = model.CurrencyId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.FromCityId = model.FromCityId;
            objToUpdate.ToCityId = model.ToCityId;
            objToUpdate.isRoundTrip = model.isRoundTrip;
            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }
        public bool Update_Air_DistributorDeals(BranchDealViewModel model)
        {

            // Edit_Air_BranchDeals(model.DealId, model.UpdatedBy.Value);

            Air_DistributorDeals objToUpdate = new Air_DistributorDeals();
            objToUpdate = ent.Air_DistributorDeals.Where(x => x.DistributorDealId == model.DealId).FirstOrDefault();
            objToUpdate.DistributorDealMasterId = model.DealMasterId;
            objToUpdate.AirlineId = model.AirlineId;
            objToUpdate.Class = model.AirlineClass != null ? model.AirlineClass.Trim() : model.AirlineClass;
            objToUpdate.SectorType = model.SectorType;
            objToUpdate.CurrencyId = model.CurrencyId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.FromCityId = model.FromCityId;
            objToUpdate.ToCityId = model.ToCityId;
            objToUpdate.isRoundTrip = model.isRoundTrip;
            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Update_Bus_DistributorDeals(BranchDealViewModel model)
        {

            // Edit_Air_BranchDeals(model.DealId, model.UpdatedBy.Value);

            Bus_DistributorDeals objToUpdate = new Bus_DistributorDeals();
            objToUpdate = ent.Bus_DistributorDeals.Where(x => x.DistributorDealId == model.DealId).FirstOrDefault();
            objToUpdate.DistributorDealMasterId = model.DealMasterId;
            objToUpdate.BusMasterId = model.BusOperatorId;
            objToUpdate.BusCategoryId = model.BusCategoryId;

            objToUpdate.SectorType = model.SectorType;
            objToUpdate.CurrencyId = model.CurrencyId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.FromCityId = model.FromCityId;
            objToUpdate.ToCityId = model.ToCityId;

            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Update_Mobile_DistributorDeals(BranchDealViewModel model)
        {
            MRC_DistributorDeal objToUpdate = new MRC_DistributorDeal();
            objToUpdate = ent.MRC_DistributorDeal.Where(x => x.DistributorDealId == model.DealId).FirstOrDefault();
            objToUpdate.DistributorDealMasterId = model.DealMasterId;

            objToUpdate.ServiceProviderId = model.DealIdentifierId;

            objToUpdate.Commission = Convert.ToDouble(model.Amount);

            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedBy = model.UpdatedBy;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Update_Mobile_BranchDeals(BranchDealViewModel model)
        {
            MRC_BranchDeals objToUpdate = new MRC_BranchDeals();
            objToUpdate = ent.MRC_BranchDeals.Where(x => x.BranchDealId == model.DealId).FirstOrDefault();
            objToUpdate.BranchDealMasterId = model.DealMasterId;

            objToUpdate.ServiceProviderId = model.DealIdentifierId;

            objToUpdate.Commission = Convert.ToDouble(model.Amount);

            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedBy = model.UpdatedBy;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }


        public bool Update_Bus_BranchDeals(BranchDealViewModel model)
        {

            // Edit_Air_BranchDeals(model.DealId, model.UpdatedBy.Value);

            Bus_BranchDeals objToUpdate = new Bus_BranchDeals();
            objToUpdate = ent.Bus_BranchDeals.Where(x => x.BranchDealId == model.DealId).FirstOrDefault();
            objToUpdate.BranchDealMasterId = model.DealMasterId;
            objToUpdate.BusMasterId = model.BusOperatorId;
            objToUpdate.BusCategoryId = model.BusCategoryId;

            objToUpdate.SectorType = model.SectorType;
            objToUpdate.CurrencyId = model.CurrencyId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.FromCityId = model.FromCityId;
            objToUpdate.ToCityId = model.ToCityId;

            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Edit_Air_BranchDeals(int dealId, int userId)
        {

            ent.Tkt_SaveChangesOnDeal(dealId, userId, "E");
            return true;
        }


        public int Save_Air_BranchDeals(BranchDealViewModel model)
        {
            Air_BranchDeals objToSave = new Air_BranchDeals();

            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.AirlineId = model.AirlineId;
            objToSave.Class = model.AirlineClass;
            objToSave.SectorType = model.SectorType != null ? model.SectorType.Trim() : model.SectorType;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;
            objToSave.isRoundTrip = model.isRoundTrip;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToAir_BranchDeals(objToSave);
            ent.SaveChanges();
            return objToSave.BranchDealId;
        }
        public int Save_Air_DistributorDeals(BranchDealViewModel model)
        {
            Air_DistributorDeals objToSave = new Air_DistributorDeals();

            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.AirlineId = model.AirlineId;
            objToSave.Class = model.AirlineClass != null ? model.AirlineClass.Trim() : model.AirlineClass;
            objToSave.SectorType = model.SectorType;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;
            objToSave.isRoundTrip = model.isRoundTrip;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToAir_DistributorDeals(objToSave);
            ent.SaveChanges();
            return objToSave.DistributorDealId;
        }

        public int Save_Bus_DistributorDeals(BranchDealViewModel model)
        {
            Bus_DistributorDeals objToSave = new Bus_DistributorDeals();

            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.BusMasterId = model.BusOperatorId;
            objToSave.BusCategoryId = model.BusCategoryId;

            objToSave.SectorType = model.SectorType;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;

            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToBus_DistributorDeals(objToSave);
            ent.SaveChanges();
            return objToSave.DistributorDealId;
        }

        public int Save_Mobile_DistributorDeals(BranchDealViewModel model)
        {
            MRC_DistributorDeal objToSave = new MRC_DistributorDeal();

            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.ServiceProviderId = model.DealIdentifierId;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Commission = Convert.ToDouble(model.Amount);

            ent.AddToMRC_DistributorDeal(objToSave);
            ent.SaveChanges();
            return objToSave.DistributorDealId;
        }

        public int Save_Mobile_BranchDeals(BranchDealViewModel model)
        {
            MRC_BranchDeals objToSave = new MRC_BranchDeals();

            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.ServiceProviderId = model.DealIdentifierId;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Commission = Convert.ToDouble(model.Amount);

            ent.AddToMRC_BranchDeals(objToSave);
            ent.SaveChanges();
            return objToSave.BranchDealId;
        }
        public int Save_Bus_BranchDeals(BranchDealViewModel model)
        {
            Bus_BranchDeals objToSave = new Bus_BranchDeals();

            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.BusMasterId = model.BusOperatorId;
            objToSave.BusCategoryId = model.BusCategoryId;

            objToSave.SectorType = model.SectorType;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;

            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToBus_BranchDeals(objToSave);
            ent.SaveChanges();
            return objToSave.BranchDealId;
        }

        public BranchDealViewModel GetDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Air_BranchDeals> deals = ent.Air_BranchDeals.Where(xx => xx.BranchDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Air_BranchDeals deal in deals)
            {
                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineClass = deal.Class != null ? deal.Class.Trim() : deal.Class;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;
                dealViewModel.AirlineName = GetAirlineNameByAirlineId(dealViewModel.AirlineId);
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;
                dealViewModel.isRoundTrip = deal.isRoundTrip;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;
            }
            return dealViewModel;
        }

        public BranchDealViewModel GetMasterDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Core_BranchDealMasters> deals = ent.Core_BranchDealMasters.Where(xx => xx.BranchDealMasterId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Core_BranchDealMasters deal in deals)
            {
                dealViewModel.DealMasterId = deal.BranchDealMasterId;
                dealViewModel.branchofficeid = deal.BranchOfficeId;
                dealViewModel.DealMaserText = deal.BranchDealName;
            }
            return dealViewModel;
        }

        public BranchDealViewModel GetDistributorMasterDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Core_DistributorDealMasters> deals = ent.Core_DistributorDealMasters.Where(xx => xx.DistributorDealMasterId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Core_DistributorDealMasters deal in deals)
            {
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;
                dealViewModel.distributorid = deal.DistributorId;
                dealViewModel.DealMaserText = deal.DistributorDealName;
            }
            return dealViewModel;
        }


        public BranchDealViewModel GetBranchMasterDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Core_BranchDealMasters> deals = ent.Core_BranchDealMasters.Where(xx => xx.BranchDealMasterId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Core_BranchDealMasters deal in deals)
            {
                dealViewModel.DealMasterId = deal.BranchDealMasterId;
                dealViewModel.branchofficeid = deal.BranchOfficeId;
                dealViewModel.DealMaserText = deal.BranchDealName;
            }
            return dealViewModel;
        }




        public BranchDealViewModel GetDistributorDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Air_DistributorDeals> deals = ent.Air_DistributorDeals.Where(xx => xx.DistributorDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Air_DistributorDeals deal in deals)
            {
                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineClass = deal.Class != null ? deal.Class.Trim() : deal.Class;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;
                dealViewModel.AirlineName = GetAirlineNameByAirlineId(dealViewModel.AirlineId);
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;
                dealViewModel.isRoundTrip = deal.isRoundTrip;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;
            }
            return dealViewModel;
        }


        public BranchDealViewModel GetBusDistributorDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Bus_DistributorDeals> deals = ent.Bus_DistributorDeals.Where(xx => xx.DistributorDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Bus_DistributorDeals deal in deals)
            {
                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;

                dealViewModel.BusOperatorName = deal.Bus_Master != null ? deal.Bus_Master.BusMasterName : string.Empty;
                dealViewModel.BusOperatorId = deal.BusMasterId;
                dealViewModel.BusCategoryId = deal.BusCategoryId;
                dealViewModel.BusCategoryName = deal.Bus_Categories != null ? deal.Bus_Categories.BusCategoryName : string.Empty;
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = deal.Bus_Cities != null ? deal.Bus_Cities.BusCityName : string.Empty;

                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = deal.Bus_Cities1 != null ? deal.Bus_Cities1.BusCityName : string.Empty;


                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewModel;
        }

        public BranchDealViewModel GetMobileDistributorDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<MRC_DistributorDeal> deals = ent.MRC_DistributorDeal.Where(xx => xx.DistributorDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (MRC_DistributorDeal deal in deals)
            {
                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.DealIdentifierId = deal.ServiceProviderId;
                dealViewModel.DealIdentifierText = deal.ServiceProviders != null ? deal.ServiceProviders.ServiceProviderName : string.Empty;

                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Commission;

                dealViewList.Add(dealViewModel);
            }
            return dealViewModel;
        }

        public BranchDealViewModel GetMobileBranchDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<MRC_BranchDeals> deals = ent.MRC_BranchDeals.Where(xx => xx.BranchDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (MRC_BranchDeals deal in deals)
            {
                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.DealIdentifierId = deal.ServiceProviderId;
                dealViewModel.DealIdentifierText = deal.ServiceProviders != null ? deal.ServiceProviders.ServiceProviderName : string.Empty;

                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Commission;

                dealViewList.Add(dealViewModel);
            }
            return dealViewModel;
        }

        public BranchDealViewModel GetBusBranchDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Bus_BranchDeals> deals = ent.Bus_BranchDeals.Where(xx => xx.BranchDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Bus_BranchDeals deal in deals)
            {
                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;

                dealViewModel.BusOperatorName = deal.Bus_Master != null ? deal.Bus_Master.BusMasterName : string.Empty;
                dealViewModel.BusOperatorId = deal.BusMasterId;
                dealViewModel.BusCategoryId = deal.BusCategoryId;
                dealViewModel.BusCategoryName = deal.Bus_Categories != null ? deal.Bus_Categories.BusCategoryName : string.Empty;
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = deal.Bus_Cities != null ? deal.Bus_Cities.BusCityName : string.Empty;

                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = deal.Bus_Cities1 != null ? deal.Bus_Cities1.BusCityName : string.Empty;


                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewModel;
        }

        public void Air_BranchDealChangesLogs(BranchDealViewModel model)
        {
            Air_BranchDealChangesLogs objToSave = new Air_BranchDealChangesLogs();
            objToSave.BranchDealId = model.DealId;
            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.AirlineId = model.AirlineId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;
            objToSave.isRoundTrip = model.isRoundTrip;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToAir_BranchDealChangesLogs(objToSave);
            ent.SaveChanges();
        }

        public void Air_DistributorDealChangesLogs(BranchDealViewModel model)
        {

            Air_DistributorDealChangesLogs objToSave = new Air_DistributorDealChangesLogs();
            objToSave.DistributorDealId = model.DealId;
            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.AirlineId = model.AirlineId;
            objToSave.FromCityId = model.FromCityId;
            objToSave.ToCityId = model.ToCityId;
            objToSave.isRoundTrip = model.isRoundTrip;
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;
            objToSave.Amount = Convert.ToDouble(model.Amount);

            ent.AddToAir_DistributorDealChangesLogs(objToSave);
            ent.SaveChanges();
        }

        public void Mobile_DistributorDealChangesLogs(BranchDealViewModel model)
        {
            //Tkt_MobileDealChangesLogs objToSave = new Tkt_MobileDealChangesLogs();
            //objToSave.DistributorDealId = model.DealId;
            //objToSave.DistributorDealMasterId = model.DealMasterId;
            //objToSave.AirlineId = model.AirlineId;
            //objToSave.FromCityId = model.FromCityId;
            //objToSave.ToCityId = model.ToCityId;
            //objToSave.isRoundTrip = model.isRoundTrip;
            //objToSave.isPercentage = model.isPercentage;
            //objToSave.CreatedBy = model.CreatedBy;
            //objToSave.CreatedDate = DateTime.Now;
            //objToSave.Amount = Convert.ToDouble(model.Amount);

            //ent.AddToAir_DistributorDealChangesLogs(objToSave);
            //ent.SaveChanges();
        }

        public void Mobile_BranchDealChangesLogs(BranchDealViewModel model)
        {
            //Tkt_MobileDealChangesLogs objToSave = new Tkt_MobileDealChangesLogs();
            //objToSave.DistributorDealId = model.DealId;
            //objToSave.DistributorDealMasterId = model.DealMasterId;
            //objToSave.AirlineId = model.AirlineId;
            //objToSave.FromCityId = model.FromCityId;
            //objToSave.ToCityId = model.ToCityId;
            //objToSave.isRoundTrip = model.isRoundTrip;
            //objToSave.isPercentage = model.isPercentage;
            //objToSave.CreatedBy = model.CreatedBy;
            //objToSave.CreatedDate = DateTime.Now;
            //objToSave.Amount = Convert.ToDouble(model.Amount);

            //ent.AddToAir_DistributorDealChangesLogs(objToSave);
            //ent.SaveChanges();
        }

        public void Air_BranchDealMasterChangesLogs(BranchDealViewModel model)
        {
            Air_BranchDealMasterChangesLogs objToSave = new Air_BranchDealMasterChangesLogs();

            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.BranchOfficeId = model.branchofficeid;
            objToSave.BranchDealName = model.DealMaserText;
            objToSave.CreateDate = DateTime.Now;
            objToSave.CreatedBy = model.branchofficeid;


            ent.AddToAir_BranchDealMasterChangesLogs(objToSave);
            ent.SaveChanges();
        }

        public void Air_DistributorDealMasterChangesLogs(BranchDealViewModel model)
        {
            Air_DistributorDealMasterChangesLogs objToSave = new Air_DistributorDealMasterChangesLogs();

            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.DistributorId = model.distributorid;
            objToSave.DistributorDealName = model.DealMaserText;
            objToSave.CreateDate = DateTime.Now;
            objToSave.CreatedBy = model.distributorid;


            ent.AddToAir_DistributorDealMasterChangesLogs(objToSave);
            ent.SaveChanges();
        }


        public void Mobile_DistributorDealMasterChangesLogs(BranchDealViewModel model)
        {
            //Air_DistributorDealMasterChangesLogs objToSave = new Air_DistributorDealMasterChangesLogs();

            //objToSave.DistributorDealMasterId = model.DealMasterId;
            //objToSave.DistributorId = model.distributorid;
            //objToSave.DistributorDealName = model.DealMaserText;
            //objToSave.CreateDate = DateTime.Now;
            //objToSave.CreatedBy = model.distributorid;


            //ent.AddToAir_DistributorDealMasterChangesLogs(objToSave);
            //ent.SaveChanges();
        }


        public bool Delete_Air_BranchDeals(int dealId, int userId)
        {
            Air_BranchDeals result = ent.Air_BranchDeals.Where(x => x.BranchDealId == dealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            return true;
        }
        public bool Delete_Air_DistributorDeals(int dealId, int userId)
        {
            Air_DistributorDeals result = ent.Air_DistributorDeals.Where(x => x.DistributorDealId == dealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            return true;
        }

        public bool Delete_Mobile_DistributorDeals(int dealId, int userId)
        {
            MRC_DistributorDeal result = ent.MRC_DistributorDeal.Where(x => x.DistributorDealMasterId == dealId).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
            return true;
        }


        public bool Delete_Mobile_BranchDeals(int dealId, int userId)
        {
            MRC_BranchDeals result = ent.MRC_BranchDeals.Where(x => x.BranchDealMasterId == dealId).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
            return true;
        }


        public bool Delete_AgentClassDeals(int dealId, int userId)
        {
            AgentClassDeals result = ent.AgentClassDeals.Where(x => x.DealMasterId == dealId).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
            return true;
        }

        public bool Delete_Core_AgentsDeals(int dealId, int userId)
        {
            Core_AgentsDeals result = ent.Core_AgentsDeals.Where(x => x.MasterDealId == dealId).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
            return true;
        }


        //public bool Delete_Mobile_BranchDeals(int dealId, int userId)
        //{
        //    MRC_BranchDeals result = ent.MRC_BranchDeals.Where(x => x.BranchDealId == dealId).FirstOrDefault();
        //    ent.DeleteObject(result);
        //    ent.SaveChanges();
        //    return true;
        //}

        public bool Delete_Bus_DistributorDeals(int dealId, int userId)
        {
            Bus_DistributorDeals result = ent.Bus_DistributorDeals.Where(x => x.DistributorDealId == dealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            return true;
        }

        public bool Delete_Bus_BranchDeals(int dealId, int userId)
        {
            Bus_BranchDeals result = ent.Bus_BranchDeals.Where(x => x.BranchDealId == dealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            return true;
        }


        public bool Delete_Core_BranchDealMasters(int masterDealId, int userId)
        {
            Core_BranchDealMasters result = ent.Core_BranchDealMasters.Where(x => x.BranchDealMasterId == masterDealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            // ent.Core_SaveChangesOnBranchMasterDeal(masterDealId, userId, "D", false);
            return true;
        }

        public bool Delete_Core_DistributorDealMasters(int masterDealId, int userId)
        {
            Core_DistributorDealMasters result = ent.Core_DistributorDealMasters.Where(x => x.DistributorDealMasterId == masterDealId).FirstOrDefault();
            if (result != null)
            {
                ent.DeleteObject(result);
                ent.SaveChanges();
            }
            // ent.Core_SaveChangesOnDistributorMasterDeal(masterDealId, userId, "D", false);
            return true;
        }

        //public bool Delete_Core_BranchDealMasters(int masterDealId, int userId)
        //{
        //    Core_BranchDealMasters result = ent.Core_BranchDealMasters.Where(x => x.BranchDealMasterId == masterDealId).FirstOrDefault();
        //    if (result != null)
        //    {
        //        ent.DeleteObject(result);
        //        ent.SaveChanges();
        //    }
        //    // ent.Core_SaveChangesOnDistributorMasterDeal(masterDealId, userId, "D", false);
        //    return true;
        //}

        public bool Delete_Core_DistributorDeals(int masterDealId, int userId)
        {
            var result = ent.Air_DistributorDeals.Where(x => x.DistributorDealMasterId == masterDealId);
            foreach (var item in result)
            {
                ent.DeleteObject(item);

            }
            ent.SaveChanges();
            return true;
        }


        //public bool Delete_Mobile_DistributorDeals(int masterDealId, int userId)
        //{
        //    var result = ent.MRC_DistributorDeal.Where(x => x.DistributorDealMasterId == masterDealId);
        //    foreach (var item in result)
        //    {
        //        ent.DeleteObject(item);

        //    }
        //    ent.SaveChanges();
        //    return true;
        //}

        public bool Delete_Core_BranchDeals(int masterDealId, int userId)
        {
            var result = ent.Air_BranchDeals.Where(x => x.BranchDealMasterId == masterDealId);
            foreach (var item in result)
            {
                ent.DeleteObject(item);

            }
            ent.SaveChanges();
            return true;
        }

        public bool Delete_Bus_Core_BranchDeals(int masterDealId, int userId)
        {
            var result = ent.Bus_BranchDeals.Where(x => x.BranchDealMasterId == masterDealId);
            foreach (var item in result)
            {
                ent.DeleteObject(item);
            }
            ent.SaveChanges();
            return true;
        }
        public void AddDealMaster(MasterBranchDealviewModel model, int productId)
        {
            Core_BranchDealMasters datamodel = new Core_BranchDealMasters
            {

                BranchDealName = model.BranchOfficeCode + "-" + model.DealName,
                ProductId = productId,
                BranchOfficeId = model.BranchOfficeId,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,

            };
            ent.AddToCore_BranchDealMasters(datamodel);
            ent.SaveChanges();
        }
        //model.BranchOfficeCode + "-" + model.DealName,

        public void AddDistributorDealMaster(MasterBranchDealviewModel model, int productId)
        {
            Core_DistributorDealMasters datamodel = new Core_DistributorDealMasters
            {

                DistributorDealName = model.DistributorCode + "-" + model.DealName,
                //model.DealName,
                ProductId = productId,
                DistributorId = model.BranchOfficeId,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,

            };
            ent.AddToCore_DistributorDealMasters(datamodel);
            ent.SaveChanges();
        }



        public IEnumerable<BranchDealViewModel> GetAllDistributorDeals(int? dealMasterId, string FilterDealIdentifierId, int? FilterAirlineId, int? FilterCurrencyId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Air_DistributorDeals> deals = new List<Air_DistributorDeals>();
            if (dealMasterId != null)
                deals = ent.Air_DistributorDeals.Where(xx => xx.DistributorDealMasterId == dealMasterId);

            if (FilterAirlineId != null)
                deals = deals.Where(x => x.AirlineId == FilterAirlineId);

            foreach (Air_DistributorDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.AirlineId = deal.AirlineId;
                dealViewModel.AirlineClass = deal.Class;
                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;
                dealViewModel.AirlineName = GetAirlineNameByAirlineId(dealViewModel.AirlineId);//.AirlinesReference.Value != null ? deal.AirlinesReference.Value.AirlineName : null;
                dealViewModel.DealIdentifierId = deal.DistributorDealId;
                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = cityProvider.GetAirLineCityinfoByid(deal.FromCityId.Value).CityName;
                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = cityProvider.GetAirLineCityinfoByid(deal.ToCityId.Value).CityName;
                dealViewModel.isRoundTrip = deal.isRoundTrip;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.AirlineName).ThenBy(x => x.Currency);
        }


        public IEnumerable<BranchDealViewModel> GetAllBusDistributorDeals(int? dealMasterId, int? FilterBusOperatorId, int? FilterBusCategoryId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Bus_DistributorDeals> deals = new List<Bus_DistributorDeals>();
            if (dealMasterId != null)
                deals = ent.Bus_DistributorDeals.Where(xx => xx.DistributorDealMasterId == dealMasterId);

            if (FilterBusOperatorId != null)
                deals = deals.Where(x => x.BusMasterId == FilterBusOperatorId);

            if (FilterBusCategoryId != null)
                deals = deals.Where(x => x.BusCategoryId == FilterBusCategoryId);

            foreach (Bus_DistributorDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;

                dealViewModel.BusOperatorName = deal.Bus_Master != null ? deal.Bus_Master.BusMasterName : string.Empty;
                dealViewModel.BusOperatorId = deal.BusMasterId;
                dealViewModel.BusCategoryId = deal.BusCategoryId;
                dealViewModel.BusCategoryName = deal.Bus_Categories != null ? deal.Bus_Categories.BusCategoryName : string.Empty;

                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = deal.Bus_Cities != null ? deal.Bus_Cities.BusCityName : string.Empty;

                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = deal.Bus_Cities1 != null ? deal.Bus_Cities1.BusCityName : string.Empty;


                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.BusOperatorName).ThenBy(x => x.BusCategoryName);
        }

        public IEnumerable<BranchDealViewModel> GetAllMobileDistributorDeals(int? dealMasterId, int? FilterDealIdentifierId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<MRC_DistributorDeal> deals = new List<MRC_DistributorDeal>();
            if (dealMasterId != null)
                deals = ent.MRC_DistributorDeal.Where(xx => xx.DistributorDealMasterId == dealMasterId);

            if (FilterDealIdentifierId != null)
            {
                deals = deals.Where(x => x.ServiceProviderId == FilterDealIdentifierId);
            }

            foreach (MRC_DistributorDeal deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealIdentifierId = deal.ServiceProviderId;
                dealViewModel.DealIdentifierText = deal.ServiceProviders != null ? deal.ServiceProviders.ServiceProviderName : string.Empty;
                dealViewModel.DealMaserText = "";
                dealViewModel.Amount = deal.Commission;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.BusOperatorName).ThenBy(x => x.BusCategoryName);
        }

        public IEnumerable<BranchDealViewModel> GetAllMobileBranchDeals(int? dealMasterId, int? FilterDealIdentifierId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<MRC_BranchDeals> deals = new List<MRC_BranchDeals>();
            if (dealMasterId != null)
                deals = ent.MRC_BranchDeals.Where(xx => xx.BranchDealMasterId == dealMasterId);

            if (FilterDealIdentifierId != null)
            {
                deals = deals.Where(x => x.ServiceProviderId == FilterDealIdentifierId);
            }

            foreach (MRC_BranchDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealIdentifierId = deal.ServiceProviderId;
                dealViewModel.DealIdentifierText = deal.ServiceProviders != null ? deal.ServiceProviders.ServiceProviderName : string.Empty;
                dealViewModel.DealMaserText = "";
                dealViewModel.Amount = deal.Commission;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.BusOperatorName).ThenBy(x => x.BusCategoryName);
        }

        public IEnumerable<BranchDealViewModel> GetAllBusBranchDeals(int? dealMasterId, int? FilterBusOperatorId, int? FilterBusCategoryId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Bus_BranchDeals> deals = new List<Bus_BranchDeals>();
            if (dealMasterId != null)
                deals = ent.Bus_BranchDeals.Where(xx => xx.BranchDealMasterId == dealMasterId);

            if (FilterBusOperatorId != null)
                deals = deals.Where(x => x.BusMasterId == FilterBusOperatorId);

            if (FilterBusCategoryId != null)
                deals = deals.Where(x => x.BusCategoryId == FilterBusCategoryId);

            foreach (Bus_BranchDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealMaserText = "";

                dealViewModel.SectorType = deal.SectorType;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies != null ? deal.Currencies.CurrencyCode : string.Empty;

                dealViewModel.BusOperatorName = deal.Bus_Master != null ? deal.Bus_Master.BusMasterName : string.Empty;
                dealViewModel.BusOperatorId = deal.BusMasterId;
                dealViewModel.BusCategoryId = deal.BusCategoryId;
                dealViewModel.BusCategoryName = deal.Bus_Categories != null ? deal.Bus_Categories.BusCategoryName : string.Empty;

                dealViewModel.FromCityId = deal.FromCityId;
                if (deal.FromCityId != null)
                    dealViewModel.FromCity = deal.Bus_Cities != null ? deal.Bus_Cities.BusCityName : string.Empty;

                dealViewModel.ToCityId = deal.ToCityId;
                if (deal.ToCityId != null)
                    dealViewModel.ToCity = deal.Bus_Cities1 != null ? deal.Bus_Cities1.BusCityName : string.Empty;


                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.BusOperatorName).ThenBy(x => x.BusCategoryName);
        }


        public void CopyDealfromOneToAnother(string newDealName, int? copyFromDealId, int? productId, int? branchOfficeId, int? createdBy)
        {
            ent.CopyBrachDeal(newDealName, copyFromDealId, productId, branchOfficeId, createdBy);

        }
        public void CopyDealfromOneToAnotherfordistributor(string newDealName, int? copyFromDealId, int? productId, int? distributorId, int? createdBy)
        {
            ent.CopyDistributorDeal(newDealName, copyFromDealId, productId, distributorId, createdBy);

        }

        public void CopyDealFromOneToAnotherForMobileDistributor(string newDealName, int? copyFromDealId, int? productId, int? distributorId, int? createdBy)
        {
            ent.CopyDistributorDeal(newDealName, copyFromDealId, productId, distributorId, createdBy);

        }
        public void CopyDealFromOneToAnotherForMobileBranch(string newDealName, int? copyFromDealId, int? productId, int? distributorId, int? createdBy)
        {
            ent.CopyMobileBranchDeal(newDealName, copyFromDealId, productId, distributorId, createdBy);
        }

        public string GetBusOperatorById(int busMasterID)
        {
            var data = ent.Bus_Master.Where(x => x.BusMasterId == busMasterID).FirstOrDefault();
            if (data != null)
                return data.BusMasterName;
            else
                return string.Empty;
        }

        public string GetBusCategoryById(int busCategoryID)
        {
            var data = ent.Bus_Categories.Where(x => x.BusCategoryId == busCategoryID).FirstOrDefault();
            if (data != null)
                return data.BusCategoryName;
            else
                return string.Empty;
        }

    }
}