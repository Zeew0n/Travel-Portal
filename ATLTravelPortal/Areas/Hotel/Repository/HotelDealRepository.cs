using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using System.ComponentModel;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelDealRepository
    {
        EntityModel entity = new EntityModel();

        public IEnumerable<SelectListItem> GetAllCountryList()
        {

            var all = (from ta in entity.Htl_BookingDestinationCity
                       select new { ta.CountryCode, ta.CountryName }).Distinct().OrderBy(x => x.CountryName).Where(x => x.CountryName != "" || x.CountryCode != "");

            var CountryList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CountryName,
                    Value = item.CountryCode
                };
                CountryList.Add(teml);
            }
            return CountryList.AsEnumerable();
        }

        public string GetCountryNameByCountryCode(string countryCode)
        {
            var htl_BookingDestinationCity = entity.Htl_BookingDestinationCity.Where(x => x.CountryCode == countryCode).FirstOrDefault();
            if (htl_BookingDestinationCity != null)
                return htl_BookingDestinationCity.CountryName;
            return string.Empty;
        }

        public IEnumerable<SelectListItem> GetAllCityList()
        {
            List<Htl_BookingDestinationCity> all = GetCountryList().ToList();
            var CityList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CityName,
                    Value = item.CityId.ToString()
                };
                CityList.Add(teml);
            }
            return CityList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllCityListByCountryCode(string countryCode)
        {
            List<Htl_BookingDestinationCity> all = GetCountryList(countryCode).ToList();
            var CityList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CityName,
                    Value = item.CityId.ToString()
                };
                CityList.Add(teml);
            }
            return CityList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllHotelList()
        {
            List<HTL_Hotels> all = GetHotelList().ToList();
            var HotelList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.HotelName,
                    Value = item.HotelId.ToString()
                };
                HotelList.Add(teml);
            }
            return HotelList.AsEnumerable();
        }

        public IQueryable<HTL_Hotels> GetHotelList()
        {
            return entity.HTL_Hotels.OrderBy(xx => xx.HotelId).AsQueryable();
        }

        public IQueryable<Tkt_DealMasters> GetAllDealMaster()
        {
            return entity.Tkt_DealMasters.Where(x => x.ProductId == 2).OrderBy(xx => xx.DealMasterId).AsQueryable();
        }

        public Tkt_DealMasters GetDealMasterById(int? id,int productId)
        {
            return entity.Tkt_DealMasters.Where(x => x.DealMasterId == id && x.ProductId == productId).FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetDealIdentifiers(int id)
        {
            List<ServiceProviders> all = GetAllServiceProviders().Where(xx => xx.isActive == true && xx.ServiceType == "HTL").ToList();
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

            return serviceProviderList;
        }

        public IQueryable<ServiceProviders> GetAllServiceProviders()
        {
            return entity.ServiceProviders.AsQueryable();
        }

        public IEnumerable<SelectListItem> GetCategoryList()
        {
            return GetEnumValueWithDesc(typeof(HotelCategory));
        }

        public IQueryable<Htl_BookingDestinationCity> GetCountryList()
        {
            return entity.Htl_BookingDestinationCity.OrderBy(xx => xx.CityId).AsQueryable();
        }

        public IQueryable<Htl_BookingDestinationCity> GetCountryList(string countryCode)
        {
            return entity.Htl_BookingDestinationCity.Where(x => x.CountryCode == countryCode).OrderBy(xx => xx.CityId).AsQueryable();
        }

        public static IEnumerable<SelectListItem> GetEnumValueWithDesc(Type enumType)
        {
            List<SelectListItem> ddl = new List<SelectListItem>();
            if (enumType.IsEnum)
            {
                foreach (System.Reflection.FieldInfo field in enumType.GetFields())
                {
                    if (field.IsDefined(typeof(DescriptionAttribute), false))
                    {
                        DescriptionAttribute desc = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                        ddl.Add(new SelectListItem { Value = ((int)((HotelCategory)Enum.Parse(typeof(HotelCategory), field.Name))).ToString(), Text = desc.Description });
                    }
                }
            }
            return ddl;
        }

        public bool Update_Htl_Deals(HotelDealViewModel model)
        {
            Edit_HTL_Deals(model.HotelDealId, model.UpdatedBy.Value);
            HTL_Deals objToUpdate = new HTL_Deals();
            objToUpdate = entity.HTL_Deals.Where(x => x.HotelDealId == model.HotelDealId).FirstOrDefault();


            objToUpdate.DealMasterId = model.DealMasterId;

            objToUpdate.HotelId = model.HotelId;

            objToUpdate.DealIdentifier = model.DealIdentifierText;
            objToUpdate.MarkupOnPerRoom = model.MarkupOnPerRoom;
            objToUpdate.isPercentMarkupOnPerRoom = model.isPercentMarkupOnPerRoom;
            objToUpdate.MarkupOnExtraGuestCharge = model.MarkupOnExtraGuestCharge;
            objToUpdate.isPercentMarkupOnExtraGuestCharge = model.isPercentMarkupOnExtraGuestCharge;
            objToUpdate.CommissionOnPerRoom = model.CommissionOnPerRoom;
            objToUpdate.isPercentCommissionOnPerRoom = model.isPercentCommissionOnPerRoom;
            objToUpdate.CommissionOnExtraGuestCharge = model.CommissionOnExtraGuestCharge;
            objToUpdate.isPercentCommissionOnExtraGuestCharge = model.isPercentCommissionOnExtraGuestCharge;
            objToUpdate.CurrencyId = model.CurrencyId;

            objToUpdate.UpdatedBy = model.UpdatedBy;
            objToUpdate.UpdatedDate = model.UpdatedDate;

            entity.ApplyCurrentValues(objToUpdate.EntityKey.EntitySetName, objToUpdate);
            entity.SaveChanges();
            return true;
        }

        public int Save_HTL_Deals(HotelDealViewModel model)
        {
            HTL_Deals objToSave = new HTL_Deals();

            objToSave.DealMasterId = model.DealMasterId;
            objToSave.HotelId = model.HotelId;

            objToSave.DealIdentifier = model.DealIdentifierText;
            objToSave.MarkupOnPerRoom = model.MarkupOnPerRoom;
            objToSave.isPercentMarkupOnPerRoom = model.isPercentMarkupOnPerRoom;
            objToSave.MarkupOnExtraGuestCharge = model.MarkupOnExtraGuestCharge;
            objToSave.isPercentMarkupOnExtraGuestCharge = model.isPercentMarkupOnExtraGuestCharge;
            objToSave.CommissionOnPerRoom = model.CommissionOnPerRoom;
            objToSave.isPercentCommissionOnPerRoom = model.isPercentCommissionOnPerRoom;
            objToSave.CommissionOnExtraGuestCharge = model.CommissionOnExtraGuestCharge;
            objToSave.isPercentCommissionOnExtraGuestCharge = model.isPercentCommissionOnExtraGuestCharge;
            objToSave.CurrencyId = model.CurrencyId;
            objToSave.VersionNo = 1;

            objToSave.MakerId = model.MakerId;
            objToSave.MakerDate = model.MakerDate;
            objToSave.isVerified = model.isVerified;
            objToSave.VerifiedBy = model.VerifiedBy;
            objToSave.VerifiedDate = model.VerifiedDate;

            entity.AddToHTL_Deals(objToSave);
            entity.SaveChanges();
            return objToSave.HotelDealId;
        }


        public int Save_Htl_BranchDeals(BranchDealViewModel model)
        {
            Htl_BranchDeals objToSave = new Htl_BranchDeals();

            objToSave.BranchDealMasterId = model.DealMasterId;
            objToSave.HotelId = model.HotelId;
            objToSave.Amount = Convert.ToDouble(model.Amount);
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;


            entity.AddToHtl_BranchDeals(objToSave);
            entity.SaveChanges();
            return objToSave.BranchDealId;
        }


        public int Save_Htl_DistributorDeals(BranchDealViewModel model)
        {
            Htl_DistributorDeals objToSave = new Htl_DistributorDeals();

            objToSave.DistributorDealMasterId = model.DealMasterId;
            objToSave.HotelId = model.HotelId;
            objToSave.Amount = Convert.ToDouble(model.Amount);
            objToSave.isPercentage = model.isPercentage;
            objToSave.CreatedBy = model.CreatedBy;
            objToSave.CreatedDate = DateTime.Now;


            entity.AddToHtl_DistributorDeals(objToSave);
            entity.SaveChanges();
            return objToSave.DistributorDealId;
        }

        public bool Delete_HTL_Deals(int dealId, int userId)
        {
            HTL_Deals objToDelete = new HTL_Deals();
            entity.HTL_SaveChangesOnDeal(dealId, userId, "D");
            return true;
        }

        public bool Edit_HTL_Deals(int dealId, int userId)
        {
            HTL_Deals objToDelete = new HTL_Deals();
            entity.HTL_SaveChangesOnDeal(dealId, userId, "E");
            return true;
        }

        public IEnumerable<HotelDealViewModel> GetAllDeals(int? dealMasterId, string filterCountryCode, int? filterCategory, int? filterCityId, int? filterHotelId, string filterDealIdentifier, int? filterCurrency)
        {
            List<HotelDealViewModel> dealViewList = new List<HotelDealViewModel>();

            IEnumerable<HTL_Deals> deals = new List<HTL_Deals>();

            if (dealMasterId != null)
                deals = entity.HTL_Deals.Where(xx => xx.DealMasterId == dealMasterId);

            if (filterHotelId != null)
                deals = deals.Where(x => x.HotelId == filterHotelId);

            if (!string.IsNullOrEmpty(filterDealIdentifier))
                deals = deals.Where(x => x.DealIdentifier == filterDealIdentifier);

            if (filterCurrency != null)
                deals = deals.Where(x => x.CurrencyId == filterCurrency);

            foreach (HTL_Deals deal in deals)
            {
                HotelDealViewModel dealViewModel = new HotelDealViewModel();

                dealViewModel.HotelDealId = deal.HotelDealId;
                dealViewModel.DealMasterId = deal.DealMasterId;
                dealViewModel.DealMaserText = "";

                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : null;
                dealViewModel.DealIdentifier = deal.DealIdentifier;
                dealViewModel.MarkupOnPerRoom = deal.MarkupOnPerRoom;
                dealViewModel.isPercentMarkupOnPerRoom = deal.isPercentMarkupOnPerRoom;
                dealViewModel.MarkupOnExtraGuestCharge = deal.MarkupOnExtraGuestCharge;
                dealViewModel.isPercentMarkupOnExtraGuestCharge = deal.isPercentMarkupOnExtraGuestCharge;
                dealViewModel.CommissionOnPerRoom = deal.CommissionOnPerRoom;
                dealViewModel.isPercentCommissionOnPerRoom = deal.isPercentCommissionOnPerRoom;
                dealViewModel.CommissionOnExtraGuestCharge = deal.CommissionOnExtraGuestCharge;
                dealViewModel.isPercentCommissionOnExtraGuestCharge = deal.isPercentCommissionOnExtraGuestCharge;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies.CurrencyCode;
                dealViewModel.MakerId = deal.MakerId;
                dealViewModel.MakerDate = deal.MakerDate;
                dealViewModel.isVerified = deal.isVerified;
                dealViewModel.VerifiedBy = deal.VerifiedBy;
                dealViewModel.VerifiedDate = deal.VerifiedDate;
                dealViewModel.UpdatedBy = deal.UpdatedBy;
                dealViewModel.UpdatedDate = deal.UpdatedDate;

                dealViewList.Add(dealViewModel);
            }
            return dealViewList.OrderBy(x => x.HotelId);
        }

        public HotelDealViewModel GetDealDetail(int? dealId)
        {
            List<HotelDealViewModel> dealViewList = new List<HotelDealViewModel>();

            List<HTL_Deals> deals = entity.HTL_Deals.Where(xx => xx.HotelDealId == dealId).ToList();
            HotelDealViewModel dealViewModel = new HotelDealViewModel();
            foreach (HTL_Deals deal in deals)
            {
                dealViewModel.HotelDealId = deal.HotelDealId;
                dealViewModel.DealMasterId = deal.DealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : null;
                dealViewModel.DealIdentifier = deal.DealIdentifier;
                dealViewModel.MarkupOnPerRoom = deal.MarkupOnPerRoom;
                dealViewModel.isPercentMarkupOnPerRoom = deal.isPercentMarkupOnPerRoom;
                dealViewModel.MarkupOnExtraGuestCharge = deal.MarkupOnExtraGuestCharge;
                dealViewModel.isPercentMarkupOnExtraGuestCharge = deal.isPercentMarkupOnExtraGuestCharge;
                dealViewModel.CommissionOnPerRoom = deal.CommissionOnPerRoom;
                dealViewModel.isPercentCommissionOnPerRoom = deal.isPercentCommissionOnPerRoom;
                dealViewModel.CommissionOnExtraGuestCharge = deal.CommissionOnExtraGuestCharge;
                dealViewModel.isPercentCommissionOnExtraGuestCharge = deal.isPercentCommissionOnExtraGuestCharge;
                dealViewModel.CurrencyId = deal.CurrencyId;
                dealViewModel.Currency = deal.Currencies.CurrencyCode;
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


        public BranchDealViewModel GetBranchDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Htl_BranchDeals> deals = entity.Htl_BranchDeals.Where(xx => xx.BranchDealId == dealId).ToList();
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


        public BranchDealViewModel GetDistributorDealDetail(int? dealId)
        {
            List<BranchDealViewModel> dealViewList = new List<BranchDealViewModel>();
            List<Htl_DistributorDeals> deals = entity.Htl_DistributorDeals.Where(xx => xx.DistributorDealId == dealId).ToList();
            BranchDealViewModel dealViewModel = new BranchDealViewModel();
            foreach (Htl_DistributorDeals deal in deals)
            {
                dealViewModel.DealId = deal.DistributorDealId;
                dealViewModel.DealMasterId = deal.DistributorDealMasterId;
                dealViewModel.DealMaserText = "";
                dealViewModel.HotelId = deal.HotelId;
                dealViewModel.HotelName = deal.HTL_Hotels != null ? deal.HTL_Hotels.HotelName : string.Empty;
                dealViewModel.Amount = deal.Amount;
                dealViewModel.isPercentage = deal.isPercentage;
                dealViewModel.UpdatedDate = deal.UpdatedDate;
            }
            return dealViewModel;
        }

        /////////////////////////////////// Airline Search          //////////////////////////////////////////////////////////
        public List<HTL_Hotels> GetHotelName(string HotelName, int maxResult)
        {
            return GetAllHotelNameList(HotelName, maxResult).ToList();
        }

        public IEnumerable<HTL_Hotels> GetAllHotelNameList(string HotelNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.HTL_Hotels.Where(x => (x.HotelCode.ToLower().StartsWith(HotelNameCode.ToLower()) || x.HotelName.ToLower().StartsWith(HotelNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new HTL_Hotels { HotelName = x.HotelName, HotelId = x.HotelId, HotelCode = x.HotelCode }
                );
        }
        /////////////////////////Method For  Copy Deal   //////////////////////////////////////////////////////////
    }

    public enum HotelCategory
    {
        [Description("Un Specified")]
        UnRated = 6,
        [Description("1 Star")]
        OneStar = 1,
        [Description("2 Star")]
        TwoStar = 2,
        [Description("3 Star")]
        ThreeStar = 3,
        [Description("4 Star")]
        FourStart = 4,
        [Description("5 Star")]
        FiveStar = 5
    }
}