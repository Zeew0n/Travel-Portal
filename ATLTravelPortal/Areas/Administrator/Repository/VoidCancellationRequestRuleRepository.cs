using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class VoidCancellationRequestRuleRepository
    {
        EntityModel entity = new EntityModel();


        public IEnumerable<VoidCancellationRequestRuleModel> GetVoidCancellationRequestList()
        {
            var Data = entity.Core_VoidCancellationRequestRule.OrderBy(x => x.VoidCancellationRuleId);
            List<VoidCancellationRequestRuleModel> VoidCancellationRequestList = new List<VoidCancellationRequestRuleModel>();
            foreach (var item in Data)
            {
                VoidCancellationRequestRuleModel singleone = new VoidCancellationRequestRuleModel()
                {
                    Product = item.Core_Products.ProductName!=null? item.Core_Products.ProductName:String.Empty,
                    SunDay = item.SUN,
                    MonDay = item.MON,
                    TuesDay = item.TUE,
                    WednesDay = item.WED,
                    ThrusDay = item.THU,
                    FriDay = item.FRI,
                    SaturDay = item.SAT,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    FromTime = item.FromTime,
                    ToTime = item.ToTime,
                    WithinHour = item.WithInHours,
                    RuleOn = item.RuleOn,
                    VoidCancellationRuleId = item.VoidCancellationRuleId 
                    

                };

                VoidCancellationRequestList.Add(singleone);
            }
            return VoidCancellationRequestList;
        }

        public void SaveToVoidCancellationRequest(VoidCancellationRequestRuleModel model)
        {
            Core_VoidCancellationRequestRule ObjToSave = new Core_VoidCancellationRequestRule()
            {
                ProductId = model.ProductId,
                SUN = model.SunDay,
                MON = model.MonDay,
                TUE = model.TuesDay,
                WED = model.WednesDay,
                THU = model.ThrusDay,
                FRI = model.FriDay,
                FromTime = model.FromTime,
                ToTime = model.ToTime,
                WithInHours = model.WithinHour,
                RuleOn = model.RuleOn,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate



            };
            entity.AddToCore_VoidCancellationRequestRule(ObjToSave);
            entity.SaveChanges();
        }

        public VoidCancellationRequestRuleModel GetEdit(int VoidCancellationRuleId)
        {

            var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.VoidCancellationRuleId == VoidCancellationRuleId).FirstOrDefault();

            VoidCancellationRequestRuleModel model = new VoidCancellationRequestRuleModel()
            {
                ProductId = Data.ProductId,
                SunDay = Data.SUN,
                MonDay = Data.MON,
                TuesDay = Data.TUE,
                WednesDay = Data.WED,
                ThrusDay = Data.THU,
                FriDay = Data.FRI,
                FromTime = Data.FromTime,
                ToTime = Data.ToTime,
                RuleOn = Data.RuleOn,
                WithinHour = Data.WithInHours,
                VoidCancellationRuleId = Data.VoidCancellationRuleId,
                temp = Data.ProductId
            };
            return model;
        }

        public void SaveEdit(VoidCancellationRequestRuleModel model)
        {
            var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.VoidCancellationRuleId == model.VoidCancellationRuleId).FirstOrDefault();

            Data.ProductId = model.ProductId;
            Data.SUN = model.SunDay;
            Data.MON = model.MonDay;
            Data.TUE = model.TuesDay;
            Data.WED = model.WednesDay;
            Data.THU = model.ThrusDay;
            Data.FRI = model.FriDay;
            Data.SAT = model.SaturDay;
            Data.FromTime = model.FromTime;
            Data.ToTime = model.ToTime;
            Data.WithInHours = model.WithinHour;
            Data.RuleOn = model.RuleOn;
            Data.CreatedBy = model.CreatedBy;
            Data.CreatedDate = model.CreatedDate;

            entity.ApplyCurrentValues(Data.EntityKey.EntitySetName, Data);
            entity.SaveChanges();
        }


         public IEnumerable<SelectListItem> GetProducts()
        {
            var Data = entity.Core_Products.OrderBy(x => x.ProductId);
            List<SelectListItem> ProductCollection = new List<SelectListItem>();

            foreach (var item in Data)
            {
                SelectListItem singleone = new SelectListItem()
                {
                    Value = item.ProductId.ToString(),
                    Text = item.ProductName
                };
                ProductCollection.Add(singleone);
            }
            return ProductCollection;         
        }

        public IEnumerable<SelectListItem> GetRuleOn()
        {
            List<SelectListItem> RuleOn = new List<SelectListItem>();
            RuleOn.Add(new SelectListItem { Value = "Void", Text = "Void" });
            RuleOn.Add(new SelectListItem { Value = "Cancel", Text = "Cancel" });

            return RuleOn;
        }
        public bool Check(int? id)
        {
            var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.ProductId== id).FirstOrDefault();
            if (Data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.VoidCancellationRuleId == id).FirstOrDefault();
            entity.DeleteObject(Data);
            entity.SaveChanges();
            return true;
        }

        public bool CheckforEdit(VoidCancellationRequestRuleModel model)
        {
            if (model.ProductId != model.temp)
            {
                var Data = entity.Core_VoidCancellationRequestRule.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                if (Data == null)
                {
                    return true;
                }
                else { return false; }
            }
            else {
                return true;
            }
        }
    }
}