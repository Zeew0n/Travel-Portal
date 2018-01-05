using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusScheduleRepository
    {
        int SNo = 1;
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _res = new BusMessageModel();
        public IEnumerable<BusScheduleModel> List()
        {
            var _res = _ent.Bus_Schedules.OrderBy(x => x.Bus_Master.BusMasterName).OrderBy(o => o.Bus_Categories.BusCategoryName);
            List<BusScheduleModel> model = new List<BusScheduleModel>();
            foreach (var items in _res)
            {
                BusScheduleModel obj = new BusScheduleModel
                {
                    Sno = SNo++,
                    ArrivalTime = items.ArrivalTime,
                    BusCategoryId = items.BusCategoryId,
                    BusCategoryName = items.Bus_Categories.BusCategoryName,
                    BusMasterId = items.BusMasterId,
                    BusMasterName = items.Bus_Master.BusMasterName,
                    DepartureCityId = items.DepartureCityId,
                    DepartureCityName = items.Bus_Cities.BusCityName + "(" + items.Bus_Cities.BusCityCode + ")",
                    DepartureTime = items.DepartureTime,
                    DestinationCityId = items.DestinationCityId,
                    DestinationCityName = items.Bus_Cities1.BusCityName + "(" + items.Bus_Cities1.BusCityCode + ")",
                    Friday = items.Friday,
                    Monday = items.Monday,
                    Saturday = items.Saturday,
                    ScheduleId = items.ScheduleId,
                    Sunday = items.Sunday,
                    Thursday = items.Thursday,
                    Tuesday = items.Tuesday,
                    Wednesday = items.Wednesday,
                    Rate = items.GovRate,
                    ActualRate = items.ActualRate,
                    TypeName = items.BusType,
                    PurchaseRate = items.PurchaseRate,
                    AgentCommission = items.AgentCommission
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public BusMessageModel Create(BusScheduleModel model)
        {

            if (IsExists(model.ScheduleId, model.BusMasterId, model.BusCategoryId, model.DepartureCityId, model.DestinationCityId, model.DepartureTime) == false)
            {
                TravelPortalEntity.Bus_Schedules obj = new TravelPortalEntity.Bus_Schedules
                {
                    ArrivalTime = model.ArrivalTime,
                    BusCategoryId = model.BusCategoryId,
                    BusMasterId = model.BusMasterId,
                    DepartureCityId = model.DepartureCityId,
                    DepartureTime = model.DepartureTime,
                    DestinationCityId = model.DestinationCityId,
                    Friday = model.Friday,
                    Monday = model.Monday,
                    Saturday = model.Saturday,
                    Sunday = model.Sunday,
                    Thursday = model.Thursday,
                    Tuesday = model.Tuesday,
                    Wednesday = model.Wednesday,
                    GovRate = model.Rate,
                    ActualRate = model.ActualRate,
                    KM = model.KiloMeter,
                    CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                    CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate(),
                    DurationHHMM = model.DurationHHMM,
                    BusType = model.TypeName,
                    PurchaseRate = model.PurchaseRate,
                    AgentCommission = model.AgentCommission
                };
                _ent.AddToBus_Schedules(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Schedule ");
                _res.ErrSource = "DataBase";
                _res.MsgType = 0;
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Schedule ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }

            return _res;
        }
        public BusMessageModel Edit(BusScheduleModel model)
        {
            if (IsExists(model.ScheduleId, model.BusMasterId, model.BusCategoryId, model.DepartureCityId, model.DestinationCityId, model.DepartureTime) == false)
            {
                var obj = _ent.Bus_Schedules.Where(x => x.ScheduleId == model.ScheduleId).FirstOrDefault();
                if (obj != null)
                {
                    obj.ArrivalTime = model.ArrivalTime;
                    obj.BusCategoryId = model.BusCategoryId;
                    obj.BusMasterId = model.BusMasterId;
                    obj.DepartureCityId = model.DepartureCityId;
                    obj.DepartureTime = model.DepartureTime;
                    obj.DestinationCityId = model.DestinationCityId;
                    obj.Friday = model.Friday;
                    obj.Monday = model.Monday;
                    obj.Saturday = model.Saturday;
                    obj.Sunday = model.Sunday;
                    obj.Thursday = model.Thursday;
                    obj.Tuesday = model.Tuesday;
                    obj.Wednesday = model.Wednesday;
                    obj.GovRate = model.Rate;
                    obj.ActualRate = model.ActualRate;
                    obj.KM = model.KiloMeter;
                    obj.UpdateBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                    obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                    obj.BusType = model.TypeName;
                    obj.DurationHHMM = model.DurationHHMM;
                    obj.PurchaseRate = model.PurchaseRate;
                    obj.AgentCommission = model.AgentCommission;
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Schedule ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;

                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Schedule ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public BusMessageModel Delete(long? Pid)
        {
            if (Pid != null)
            {
                var obj = _ent.Bus_Schedules.Where(x => x.ScheduleId == Pid).FirstOrDefault();
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Schedule ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            return _res;
        }
        public BusScheduleModel Detail(int? Pid)
        {
            BusScheduleModel model = new BusScheduleModel();
            if (Pid != null)
            {
                var result = _ent.Bus_Schedules.Where(x => x.ScheduleId == Pid).FirstOrDefault();
                if (result != null)
                {
                    model.ArrivalTime = result.ArrivalTime;
                    model.BusCategoryId = result.BusCategoryId;
                    model.BusCategoryName = result.Bus_Categories.BusCategoryName;
                    model.BusMasterId = result.BusMasterId;
                    model.BusMasterName = result.Bus_Master.BusMasterName;
                    model.DepartureCityId = result.DepartureCityId;
                    model.DepartureCityName = result.Bus_Cities.BusCityName + "(" + result.Bus_Cities.BusCityCode + ")";
                    model.DepartureTime = result.DepartureTime;
                    model.DestinationCityId = result.DestinationCityId;
                    model.DestinationCityName = result.Bus_Cities1.BusCityName + "(" + result.Bus_Cities1.BusCityCode + ")";
                    model.Friday = result.Friday;
                    model.Monday = result.Monday;
                    model.Saturday = result.Saturday;
                    model.ScheduleId = result.ScheduleId;
                    model.Sunday = result.Sunday;
                    model.Thursday = result.Thursday;
                    model.Tuesday = result.Tuesday;
                    model.Wednesday = result.Wednesday;
                    model.Rate = result.GovRate;
                    model.ActualRate = result.ActualRate;
                    model.KiloMeter = result.KM;
                    model.TypeName = result.BusType;
                    model.DurationHHMM = result.DurationHHMM;
                    model.PurchaseRate = result.PurchaseRate;
                    model.AgentCommission = result.AgentCommission;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            model.Message = _res;
            return model;

        }
        public BusScheduleModel Fill(BusScheduleModel model)
        {
            model.ddlBusCategoryList = ddlCategoryList();
            model.ddlBusCityList = ddlCityList();
            model.ddlBusMasterList = ddlMasterList();
            model.ddlTypeList = ddlTypeList();
            return model;
        }
        public IPagedList<BusScheduleModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List().ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
        public bool IsExists(long ScheduleId, int BusMasterId, int BusCategoryId, int DepartureCityId, int DestinationCityId, TimeSpan DepartureTime)
        {
            var result = _ent.Bus_Schedules.Where(x => x.BusMasterId == BusMasterId && x.BusCategoryId == BusCategoryId && x.DepartureCityId == DepartureCityId && x.DestinationCityId == DestinationCityId && x.DepartureTime == DepartureTime && x.ScheduleId != ScheduleId).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public IEnumerable<SelectListItem> ddlMasterList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Master.OrderBy(o => o.BusMasterName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Value = item.BusMasterId.ToString(), Text = item.BusMasterName.ToString() });
            }
            return ddlList;
        }

        public IEnumerable<SelectListItem> ddlTypeList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Master.OrderBy(o => o.BusMasterName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            ddlList.Add(new SelectListItem { Text = "Day(दिवा)", Value = "Day(दिवा)" });
            ddlList.Add(new SelectListItem { Text = "Night(रात्री)", Value = "Night(रात्री)" });

            return ddlList;
        }

        public IEnumerable<SelectListItem> ddlCategoryList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Categories.OrderBy(o => o.BusCategoryName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Value = item.BusCategoryId.ToString(), Text = item.BusCategoryName.ToString() });
            }
            return ddlList;
        }
        public IEnumerable<SelectListItem> ddlCityList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Cities.OrderBy(o => o.BusCityName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Value = item.BusCityId.ToString(), Text = item.BusCityName.ToString() + "(" + item.BusCityCode + ")" });
            }
            return ddlList;
        }
        public BusMessageModel UpdateRate(long? id, double? Amount)
        {
            Amount = Amount == null ? 0 : Amount;
            var obj = _ent.Bus_Schedules.Where(x => x.ScheduleId == id).FirstOrDefault();
            if (obj != null && Amount > 0)
            {
                obj.GovRate = Amount.Value;
                obj.UpdateBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Schedule ");
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            return _res;
        }
        public BusMessageModel UpdateActualRate(long id, double Amount)
        {
            Amount = Amount == null ? 0 : Amount;
            var obj = _ent.Bus_Schedules.Where(x => x.ScheduleId == id).FirstOrDefault();
            if (obj != null && Amount > 0)
            {
                obj.ActualRate = Amount;
                obj.UpdateBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Schedule ");
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Schedule ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            return _res;
        }
        public IEnumerable<Bus_Categories> GetAllCategoryByMasterId(int masterid)
        {
          

            var result = from a in _ent.Bus_Categories
                         join b in _ent.Bus_OperatorBusCategory on a.BusCategoryId equals b.BusCategoryId
                         where b.BusMasterId == masterid
                         select a;

          
            return result.ToList();

        }


        public IEnumerable<Bus_Cities> GetAllBusCities(string searchText, int maxResults)
        {
            return _ent.Bus_Cities.Where(x => x.BusCityName.Contains(searchText) || (x.BusCityCode.Contains(searchText)));

        }
    }
}