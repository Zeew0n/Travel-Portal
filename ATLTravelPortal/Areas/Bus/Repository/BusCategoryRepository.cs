using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusCategoryRepository
    { 
        int Sno = 1;
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _res = new BusMessageModel();
        public IEnumerable<BusCategoryModel> List()
        {
           
            var _res = _ent.Bus_Categories.OrderBy(x => x.BusCategoryName);
            List<BusCategoryModel> model = new List<BusCategoryModel>();
            foreach (var items in _res)
            {
                BusCategoryModel obj = new BusCategoryModel
                {
                   SNo=Sno++,
                    BusCategoryId = items.BusCategoryId,
                    BusCategoryName = items.BusCategoryName,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public BusMessageModel Create(BusCategoryModel model)
        {

            if (IsExists(model.BusCategoryId, model.BusCategoryName) == false)
            {
                TravelPortalEntity.Bus_Categories obj = new TravelPortalEntity.Bus_Categories
                {
                    BusCategoryName = model.BusCategoryName,
                };
                _ent.AddToBus_Categories(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Category ");
                _res.ErrSource = "DataBase";
                _res.MsgType = 0;
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Category ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }

            return _res;
        }
        public BusMessageModel Edit(BusCategoryModel model)
        {
            if (IsExists(model.BusCategoryId, model.BusCategoryName) == false)
            {
                var obj = _ent.Bus_Categories.Where(x => x.BusCategoryId == model.BusCategoryId).FirstOrDefault();
                if (obj != null)
                {
                    obj.BusCategoryName = model.BusCategoryName;
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Category ");
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
                var obj = _ent.Bus_Categories.Where(x => x.BusCategoryId == Pid).FirstOrDefault();
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public BusCategoryModel Detail(int? Pid)
        {
            BusCategoryModel model = new BusCategoryModel();
            if (Pid != null)
            {
                var result = _ent.Bus_Categories.Where(x => x.BusCategoryId == Pid).FirstOrDefault();
                if (result != null)
                {
                    model.BusCategoryId = result.BusCategoryId;
                    model.BusCategoryName = result.BusCategoryName;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            model.Message = _res;
            return model;

        }

        public IPagedList<BusCategoryModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List().ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
        public bool IsExists(int? Pid, string ProviderCode = null)
        {
            var result = _ent.Bus_Categories.Where(x => x.BusCategoryName.ToLower() == ProviderCode.ToLower() && x.BusCategoryId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public IEnumerable<SelectListItem> ddlCategoriesList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Categories.OrderBy(o => o.BusCategoryName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.BusCategoryId.ToString(), Value = item.BusCategoryName.ToString() });
            }
            return ddlList;
        }
    }
}