using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    
    public class MEsCreditLimitProvider
    {
        EntityModel Entity_Model = new EntityModel();

        public List<Currencies> GetCurrency()
        {
            return Entity_Model.Currencies.Where(x=>x.CurrencyId==1 || x.CurrencyId==2).ToList();
        }
        public List<UsersDetails> GetMEsList()
        {
            return Entity_Model.UsersDetails.Where(x => x.UserTypeId == 4).OrderBy(x => x.FullName).ToList();
        }

        public List<MEsCreditLimitModel> GetAllCreditLimitList()
        {
            List<MEsCreditLimitModel> model = new List<MEsCreditLimitModel>();
            
            var Data = Entity_Model.MEsCreditLimits.Where(x=>x.isActive==true).OrderByDescending(c => c.MEsCreditLimitId);
            foreach (var item in Data)
            {
                MEsCreditLimitModel data = new MEsCreditLimitModel()
                {
                    CurrencyID = item.CurrencyId,
                    EffictiveFrom = item.EffectiveFrom,
                    Amount = item.Amount,
                    ExpireOn = item.ExpireOn,
                    MEsID=item.MEsId,
                    MEsCreditLimitId = item.MEsCreditLimitId,
                    MEsName=item.UsersDetails.FullName,
                    CurrencyCode=item.Currencies.CurrencyCode
                };
                model.Add(data);
            }
            return model;
        }

        public void Insert(MEsCreditLimitModel model,int AppUserId)
        {
            

            ResetIsActive(model.MEsID, model.CurrencyID);
            var objToSave = new MEsCreditLimits()
            {
                CurrencyId = model.CurrencyID,
                EffectiveFrom = model.EffictiveFrom,
                Amount = model.Amount??0,
                ExpireOn = model.ExpireOn,
                MEsId = model.MEsID,
                CreatedBy = AppUserId,
                CreatedDate=DateTime.UtcNow,
                isActive=true
                
            };

            Entity_Model.MEsCreditLimits.AddObject(objToSave);
            Entity_Model.SaveChanges();
        }

        private void ResetIsActive(int MEsId, int CurrentyId)
        {
            var result = Entity_Model.MEsCreditLimits.Where(x => x.MEsId == MEsId && x.CurrencyId == CurrentyId && x.isActive == true).FirstOrDefault();
            if (result != null)
            {
                result.isActive = false;
                Entity_Model.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                Entity_Model.SaveChanges();
            }
        }

        public void Delete(int MEsCreditLimitId, int AppUserId)
        {
            var objToDelete = Entity_Model.MEsCreditLimits.Where(x => x.MEsCreditLimitId == MEsCreditLimitId).FirstOrDefault();
            objToDelete.isActive = false;
            objToDelete.UpdatedBy = AppUserId;
            objToDelete.UpdatedDate = DateTime.UtcNow;
            Entity_Model.ApplyCurrentValues(objToDelete.EntityKey.EntitySetName, objToDelete);
            Entity_Model.SaveChanges();

        }

    }
}