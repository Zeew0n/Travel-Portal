using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Repository;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBranchDealProvider
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

        public IQueryable<Airlines> AirlineNameList()
        {
            return ent.Airlines.OrderBy(xx => xx.AirlineId).AsQueryable();
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

        public IEnumerable<SelectListItem> GetAllBranchDealMasterList(int productId, int branchofficeid)
        {
            string BranchCode = GetBranchCodeByBranchId(branchofficeid);
            List<Core_BranchDealMasters> all = GetAllDealMaster(productId, branchofficeid).OrderBy(z => z.BranchDealName).ToList();
            var GetAllDealMasterList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                   
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

        public IEnumerable<BranchDealViewModel> GetAllDeals(int? dealMasterId, string FilterDealIdentifierId, int? FilterHotelId, int? FilterCurrencyId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Htl_BranchDeals> deals = new List<Htl_BranchDeals>();
            if (dealMasterId != null)
                deals = ent.Htl_BranchDeals.Where(xx => xx.BranchDealMasterId == dealMasterId);

            if (FilterHotelId != null)
                deals = deals.Where(x => x.HotelId == FilterHotelId);

            foreach (Htl_BranchDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : string.Empty;


                dealViewModel.Amount = deal.Amount;
                dealViewModel.isPercentage = deal.isPercentage;

                dealViewModel.CreatedBy = deal.CreatedBy;
                dealViewModel.UpdatedDate = deal.UpdatedDate;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.AirlineName).ThenBy(x => x.Currency);
        }

        public string GetAirlineNameByAirlineId(int? Airlineid)
        {
            var res = ent.Airlines.Where(x => x.AirlineId == Airlineid).Select(x => x.AirlineName).FirstOrDefault();
            return res;
        }

        public bool Update_Htl_BranchDeals(BranchDealViewModel model)
        {
            Htl_BranchDeals objToUpdate = new Htl_BranchDeals();
            objToUpdate = ent.Htl_BranchDeals.Where(x => x.BranchDealId == model.DealId).FirstOrDefault();
            objToUpdate.BranchDealMasterId = model.DealMasterId;
            objToUpdate.HotelId = model.HotelId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdateBy = model.UpdatedBy;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            ent.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            ent.SaveChanges();
            return true;
        }

        public bool Update_Htl_DistributorDeals(BranchDealViewModel model)
        {
            Htl_DistributorDeals objToUpdate = new Htl_DistributorDeals();
            objToUpdate = ent.Htl_DistributorDeals.Where(x => x.DistributorDealId == model.DealId).FirstOrDefault();
            objToUpdate.DistributorDealMasterId = model.DealMasterId;
            objToUpdate.HotelId = model.HotelId;
            objToUpdate.Amount = Convert.ToDouble(model.Amount);
            objToUpdate.isPercentage = model.isPercentage;
            objToUpdate.UpdateBy = model.UpdatedBy;
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

        public BranchDealViewModel GetDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Htl_BranchDeals> deals = ent.Htl_BranchDeals.Where(xx => xx.BranchDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Htl_BranchDeals deal in deals)
            {
                dealViewModel.DealId = deal.BranchDealId;
                dealViewModel.DealMasterId = deal.BranchDealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : string.Empty;
                dealViewModel.Amount = deal.Amount;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
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

        public BranchDealViewModel GetDistributorDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Htl_DistributorDeals> deals = ent.Htl_DistributorDeals.Where(xx => xx.DistributorDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Htl_DistributorDeals deal in deals)
            {
                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : string.Empty;

                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;
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

        public bool Delete_Htl_BranchDeals(int dealId, int userId)
        {
            Htl_BranchDeals result = ent.Htl_BranchDeals.Where(x => x.BranchDealId == dealId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
            return true;
        }

        public bool Delete_Htl_DistributorDeals(int dealId, int userId)
        {
            Htl_DistributorDeals result = ent.Htl_DistributorDeals.Where(x => x.DistributorDealId == dealId).FirstOrDefault();
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
            ent.DeleteObject(result);
            ent.SaveChanges();
            // ent.Core_SaveChangesOnDistributorMasterDeal(masterDealId, userId, "D", false);
            return true;
        }

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

        public void AddDealMaster(MasterBranchDealviewModel model)
        {
            Core_BranchDealMasters datamodel = new Core_BranchDealMasters
            {
                BranchDealName = model.BranchOfficeCode + "-" + model.DealName,
                ProductId = model.ProductID,
                BranchOfficeId = model.BranchOfficeId,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
            };
            ent.AddToCore_BranchDealMasters(datamodel);
            ent.SaveChanges();
        }

        public void AddDistributorDealMaster(MasterBranchDealviewModel model, int productId)
        {
            Core_DistributorDealMasters datamodel = new Core_DistributorDealMasters
            {
                DistributorDealName = model.DistributorCode + "-" + model.DealName,
                ProductId = productId,
                DistributorId = model.BranchOfficeId,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
            };
            ent.AddToCore_DistributorDealMasters(datamodel);
            ent.SaveChanges();
        }

        public IEnumerable<BranchDealViewModel> GetAllDistributorDeals(int? dealMasterId, string FilterDealIdentifierId, int? FilterHotelId, int? FilterCurrencyId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();

            IEnumerable<Htl_DistributorDeals> deals = new List<Htl_DistributorDeals>();
            if (dealMasterId != null)
                deals = ent.Htl_DistributorDeals.Where(xx => xx.DistributorDealMasterId == dealMasterId);

            if (FilterHotelId != null)
                deals = deals.Where(x => x.HotelId == FilterHotelId);

            foreach (Htl_DistributorDeals deal in deals)
            {
                BranchDealViewModel dealViewModel = new BranchDealViewModel();

                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;

                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : string.Empty;
                dealViewModel.DealIdentifierId = deal.DistributorDealId;

                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
                dealViewModel.Amount = deal.Amount;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.HotelName).ThenBy(x => x.Currency);
        }
    }
}