using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class OperatorBusCategoryRepository
    {
        int SNo = 1;
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _res = new BusMessageModel();
        public IEnumerable<OperatorBusCategoryModel> List()
        {
            var _res = _ent.Bus_OperatorBusCategory.OrderBy(x => x.BusMasterId);
            List<OperatorBusCategoryModel> model = new List<OperatorBusCategoryModel>();
            foreach (var items in _res)
            {
                OperatorBusCategoryModel obj = new OperatorBusCategoryModel
                {
                    Sno = SNo++,
                    OBCategoryId=items.OBCategoryId,
                    BusMasterId=items.BusMasterId,
                    BusMasterName=items.Bus_Master.BusMasterName,
                    BusCategoryId = items.BusCategoryId,
                    BusCategorName=items.Bus_Categories.BusCategoryName,
                    FacilityDetails=items.FacilityDetails,
                    FareRules=items.FareRules
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public BusMessageModel Create(OperatorBusCategoryModel model)
        {

            if (IsExists(model.OBCategoryId, model.BusMasterId,model.BusCategoryId) == false)
            {
                TravelPortalEntity.Bus_OperatorBusCategory obj = new TravelPortalEntity.Bus_OperatorBusCategory
                {
                    OBCategoryId = model.OBCategoryId,
                    BusMasterId = model.BusMasterId,
                    BusCategoryId = model.BusCategoryId,
                    FacilityDetails = model.FacilityDetails,
                    FareRules = model.FareRules,
                    CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                    CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate()
                };
                _ent.AddToBus_OperatorBusCategory(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Operator Category ");
                _res.ErrSource = "DataBase";
                _res.MsgType = 0;
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Operator Category ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }

            return _res;
        }
        public BusMessageModel Edit(OperatorBusCategoryModel model)
        {
            if (IsExists(model.OBCategoryId, model.BusMasterId, model.BusCategoryId) == false)
            {
                var obj = _ent.Bus_OperatorBusCategory.Where(x => x.OBCategoryId == model.OBCategoryId).FirstOrDefault();
                if (obj != null)
                {
                    obj.BusMasterId = model.BusMasterId;
                    obj.BusCategoryId = model.BusCategoryId;
                    obj.FacilityDetails = model.FacilityDetails;
                    obj.FareRules = model.FareRules;
                    obj.UpdatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                    obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Operator Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Operator Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Operator Category ");
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
                var obj = _ent.Bus_OperatorBusCategory.Where(x => x.OBCategoryId == Pid).FirstOrDefault();
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Operator Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Operator Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Operator Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public OperatorBusCategoryModel Detail(int? Pid)
        {
            OperatorBusCategoryModel model = new OperatorBusCategoryModel();
            if (Pid != null)
            {
                var result = _ent.Bus_OperatorBusCategory.Where(x => x.OBCategoryId == Pid).FirstOrDefault();
                if (result != null)
                {
                    model.OBCategoryId=result.OBCategoryId;
                    model.BusMasterId=result.BusMasterId;
                    model.BusMasterName=result.Bus_Master.BusMasterName;
                    model.BusCategoryId = result.BusCategoryId;
                    model.BusCategorName=result.Bus_Categories.BusCategoryName;
                    model.FacilityDetails=result.FacilityDetails;
                    model.FareRules = result.FareRules;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Operator Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Operator Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            model.Message = _res;
            return model;

        }

        public IPagedList<OperatorBusCategoryModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List().ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
        public bool IsExists(int? Pid, int BusMasterId, int BusCategoryId)
        {
            var result = _ent.Bus_OperatorBusCategory.Where(x => x.BusMasterId == BusMasterId && x.BusCategoryId == BusCategoryId && x.OBCategoryId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public OperatorBusCategoryModel Fill(OperatorBusCategoryModel model) {
            model.ddlBusCategorList = ddlBusCategoryList();
            model.ddlBusMasterList = ddlBusMasterList();
            return model;
        }
        public IEnumerable<SelectListItem> ddlBusCategoryList()
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
        public IEnumerable<SelectListItem> ddlBusMasterList()
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
    }
}