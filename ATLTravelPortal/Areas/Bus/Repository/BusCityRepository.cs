using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Models;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using ATLTravelPortal.Areas.Bus.Models;
using TravelPortalEntity;
//using ATLTravelPortal.Models;
using System.Web.Mvc;
using ATLTravelPortal.Helpers.Pagination;
namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusCityRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _res = new BusMessageModel();
        public IEnumerable<BusCityModel> List()
        {
            int sno = 1;
            var _res = _ent.Bus_Cities.OrderBy(x => x.BusCityName);
            List<BusCityModel> model = new List<BusCityModel>();
            foreach (var items in _res)
            {
                BusCityModel obj = new BusCityModel
                {
                    SNo=sno++,
                    BusCityId = items.BusCityId,
                    BusCityCode = items.BusCityCode,
                    BusCityName = items.BusCityName,
                    StatusName = items.isActive == true ? "Active" : "Bloked"
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public BusMessageModel Create(BusCityModel model)
        {

            if (IsExists(model.BusCityId, model.BusCityName) == false)
            {
                Bus_Cities obj = new Bus_Cities
                {
                    BusCityCode = model.BusCityCode,
                    BusCityName = model.BusCityName,
                    isActive = true,
                    CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                    CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate()
                };
                _ent.AddToBus_Cities(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus City ");
                _res.ErrSource = "DataBase";
                _res.MsgType = 0;
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus City ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }

            return _res;
        }
        public BusMessageModel Edit(BusCityModel model)
        {
            if (IsExists(model.BusCityId, model.BusCityName) == false)
            {
                var obj = _ent.Bus_Cities.Where(x => x.BusCityId == model.BusCityId).FirstOrDefault();
                if (obj != null)
                {
                    obj.BusCityName = model.BusCityName;
                    obj.BusCityCode = model.BusCityCode;
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus City ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus City ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus City ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public BusMessageModel Delete(int? Pid)
        {
            if (Pid != null)
            {
                var obj = _ent.Bus_Cities.Where(x => x.BusCityId == Pid).FirstOrDefault();
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus City ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus City ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus City ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public BusCityModel Detail(int? Pid)
        {
            BusCityModel model = new BusCityModel();
            if (Pid != null)
            {
                var result = _ent.Bus_Cities.Where(x => x.BusCityId == Pid).FirstOrDefault();
                if (result != null)
                {
                    model.BusCityId = result.BusCityId;
                    model.BusCityCode = result.BusCityCode;
                    model.BusCityName = result.BusCityName;
                    model.IsActive = result.isActive;
                    model.StatusName = result.isActive == true ? "Active" : "Bloked";
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus City ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus City ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            model.Message = _res;
            return model;

        }

        public IPagedList<BusCityModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List().ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
        public bool IsExists(int? Pid, string ProviderCode = null)
        {
            var result = _ent.Bus_Cities.Where(x => x.BusCityName.ToLower() == ProviderCode.ToLower() && x.BusCityId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public IEnumerable<SelectListItem> ddlBusCityList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Cities.Where(x => x.isActive == true).OrderBy(o => o.BusCityName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.BusCityId.ToString(), Value = item.BusCityName.ToString() });
            }
            return ddlList;
        }
    }
}