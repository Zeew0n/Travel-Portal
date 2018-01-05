using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.MobileRechargeCard.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Repository
{
    public class CardValueRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        public ActionResponse Create(CardValueModel model)
        {
            if (IsExists(model.CardValueId, model.CardValue) == false)
            {
                MRC_CardValue obj = new MRC_CardValue
                {
                    CardValue = model.CardValue,
                    CardValueDesc = model.CardValueDesc,
                    IsActive = model.IsActive,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate,
                };
                _ent.AddToMRC_CardValue(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Card Value");
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ErrNumber = 0;
                _res.ResponseStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Card Value");
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ErrNumber = 0;
                _res.ResponseStatus = true;
            }
            return _res;
        }
        public IEnumerable<CardValueModel> List()
        {
            var result = _ent.MRC_CardValue.OrderBy(x=>x.CardValue);
            List<CardValueModel> _response = new List<CardValueModel>();
            foreach (var item in result)
            {
                CardValueModel model = new CardValueModel
                {
                    CardValueId = item.CardValueId,
                    CardValue = (double)item.CardValue,
                    CardValueDesc = item.CardValueDesc,
                    IsActive = item.IsActive,
                    StatusName = item.IsActive == true ? "Active" : item.IsActive == false ? "Blocked" : "N/A",

                };
                _response.Add(model);
            }
            return _response.AsEnumerable();
        }
        public CardValueModel Detail(int? Id, out ActionResponse _ores)
        {
            CardValueModel obj = new CardValueModel();
            if (Id != null)
            {
                var result = _ent.MRC_CardValue.Where(x => x.CardValueId == Id).FirstOrDefault();
                if (result != null)
                {
                    obj.CardValueId = result.CardValueId;
                    obj.CardValue = (double)result.CardValue;
                    obj.CardValueDesc = result.CardValueDesc;
                    obj.IsActive = result.IsActive;
                    obj.StatusName = result.IsActive == true ? "Active" : result.IsActive == false ? "Blocked" : "N/A";
                    obj.CreatedBy = (int)result.CreatedBy;
                    obj.CreatedDate = (DateTime)result.CreatedDate;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Card Value");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Card Value");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }

            _ores = _res;
            return obj;
        }
        public ActionResponse Delete(int? id, int ModifiedBy, DateTime ModifiedDate)
        {
            if (id != null)
            {
                var obj = _ent.MRC_CardValue.First(m => m.CardValueId == id);
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyDeleted, "Card Value");
                    _res.ErrNumber = 0;
                    _res.ResponseStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Card Value");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Card Value");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            return _res;
        }
        public ActionResponse Edit(CardValueModel model)
        {
            if (IsExists(model.CardValueId, model.CardValue) == false)
            {
                var result = _ent.MRC_CardValue.Where(x => x.CardValueId == model.CardValueId).FirstOrDefault();
                result.CardValue = (double)model.CardValue;
                result.CardValueDesc = model.CardValueDesc;
                result.IsActive = model.IsActive;
                result.ModifiedBy =ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                result.ModifiedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                if (result != null)
                {
                    _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                    _ent.SaveChanges();
                }
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Card Value");
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ErrNumber = 0;
                _res.ResponseStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Card Value");
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ErrNumber = 0;
                _res.ResponseStatus = true;
            }
            return _res;
        }
        public IEnumerable<SelectListItem> OptionList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.MRC_CardValue.Where(x => x.IsActive ==true);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.CardValue.ToString(), Value = item.CardValueId.ToString() });
            }
            return ddlList;
        }
       
        public bool IsExists(int Pid, double? val = null)
        {

            var result = _ent.MRC_CardValue.Where(x => x.CardValue == val && x.CardValueId != Pid ).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;

        }
    }
}