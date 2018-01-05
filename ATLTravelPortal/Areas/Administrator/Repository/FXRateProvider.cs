using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class FXRateProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        public List<FXRateModel> List()
        {
            int sno = 0;
            var data = ent.Core_FXRate.ToList().OrderByDescending(x=>x.CreatedDate);
            List<FXRateModel> model = new List<FXRateModel>();

            foreach (var item in data)
            {
                sno++;
                FXRateModel temp = new FXRateModel
                {
                    SNO=sno,
                    ExchangeRate=item.ExchangeRate,
                    CreatedDate=item.CreatedDate,
                    isApproved=item.isApproved,
                    FXRateId=item.FXRateId
                };
                model.Add(temp);
            }
            return model.ToList();
        }

        public ActionResponse Create(FXRateModel model)
        {
            if (model.ExchangeRate > 0)
            {
                Core_FXRate dbmodel = new Core_FXRate
                {
                    BaseCurrencyID = 1,
                    CurrencyID = 2,
                    ExchangeRate = (Double)model.ExchangeRate,
                    CreatedBy = model.CreatedBy,
                   // CreatedDate = model.CreatedDate,
                   CreatedDate = DateTime.Now,
                 
                    isApproved = false
                };
                ent.AddToCore_FXRate(dbmodel);
                ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "FX Rate");
                _res.ErrNumber = 0;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidField, "Exchange Rate");
                _res.ErrNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            return _res;
        }
        public ActionResponse Approve(int? FXRateId)
        {
            if (FXRateId != null)
            {
                Core_FXRate result = ent.Core_FXRate.Where(x => x.FXRateId == FXRateId).FirstOrDefault();
                result.isApproved = true;
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyApproved, "FX Rate");
                _res.ErrNumber = 0;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "FX Rate");
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            return _res;
           
        }
    }
}