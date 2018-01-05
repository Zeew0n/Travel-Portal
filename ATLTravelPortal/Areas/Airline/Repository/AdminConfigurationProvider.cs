using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AdminConfigurationProvider
    {
        EntityModel ent = new EntityModel();

        public void AdminConfigurationAdd(AdminConfigurationModel modelToSave)
        {
            Core_AdminConfiguration datamodel = new Core_AdminConfiguration
            {
                EmailEveryTimeBookingIsMade = modelToSave.chkEmailEveryTimeBookingIsMade,
                EmailEveryTimePNRIsReleased = modelToSave.chkEmailEveryTimePNRIsMade,
                SendEmailTo = modelToSave.txtSendMailTo,
                MarkupChargeIncludeInTax = modelToSave.rdbMarkupCharge == MarkupCharge.includeinTax ? true : false,
                MarkupChargeIncludeInFare = modelToSave.rdbMarkupCharge == MarkupCharge.includeinFare ? true : false,
                isPercentDomesticServiceCharge = Convert.ToBoolean(modelToSave.ddlDomesticType),
                DomesticServiceChargeValue = (Double) (modelToSave.txtDomesticValue == null ? 0 : modelToSave.txtDomesticValue),
                isPercentInternationalServiceCharge = Convert.ToBoolean(modelToSave.ddlInternationType),
                InternationalServiceChargeValue = (Double) (modelToSave.txtInternationalValue == null ? 0 : modelToSave.txtInternationalValue),
                TTL = (int)(modelToSave.TTL == null ? 0 : modelToSave.TTL)
            };
            ent.AddToCore_AdminConfiguration(datamodel);
            ent.SaveChanges();

            //to return primary key
         //  return modelToSave.AdminConfugrationId;

        }

        //public bool checkDuplicateRow()
        //{
        //   var chk=  ent.Core_AdminConfiguration.ToList();
            
        //   if (chk.Count == 0)
        //   {
        //       return true;
        //   }
        //   else
        //   {
        //       return false;
        //   }
        //}


        //to check the duplicate insertion


        public int checkDuplicateRow()
        {
            var chk = ent.Core_AdminConfiguration.SingleOrDefault();
            if (chk != null)
            {

                return chk.AdminConfigurationId;
            }
            else
            {
                return 0;
            }
        }

        public void AdminConfigurationEdit(AdminConfigurationModel model)
        {
            Core_AdminConfiguration result = ent.Core_AdminConfiguration.Where(x => x.AdminConfigurationId == model.AdminConfugrationId).FirstOrDefault();
            //  result.AdminConfigurationId = model.AdminConfigurationId;

            result.EmailEveryTimeBookingIsMade = model.chkEmailEveryTimeBookingIsMade;
            result.EmailEveryTimePNRIsReleased = model.chkEmailEveryTimePNRIsMade;
            result.SendEmailTo = model.txtSendMailTo;
            result.MarkupChargeIncludeInTax = model.rdbMarkupCharge == MarkupCharge.includeinTax ? true : false;
            result.MarkupChargeIncludeInFare = model.rdbMarkupCharge == MarkupCharge.includeinFare ? true : false;
            result.isPercentDomesticServiceCharge = model.ddlDomesticType == 2 ? true : false;
           // result.DomesticServiceChargeValue = (Double) model.txtDomesticValue;
            result.DomesticServiceChargeValue = (Double) (model.txtDomesticValue == null ? 0 : model.txtDomesticValue);
            result.isPercentInternationalServiceCharge = model.ddlInternationType == 2 ? true : false;
            //result.InternationalServiceChargeValue = (Double) model.txtInternationalValue;
            result.InternationalServiceChargeValue = (Double) (model.txtInternationalValue == null ? 0 : model.txtInternationalValue);
            //result.TTL = (int) model.TTL;
            result.TTL = (int) (model.TTL == null ? 0 : model.TTL);

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        public AdminConfigurationModel GetAdminConfigurationDetail(int id)
        {
            Core_AdminConfiguration result = ent.Core_AdminConfiguration.Where(x => x.AdminConfigurationId == id).FirstOrDefault();

            AdminConfigurationModel model = new AdminConfigurationModel();

            model.AdminConfugrationId = result.AdminConfigurationId;

            model.chkEmailEveryTimeBookingIsMade = (bool)result.EmailEveryTimeBookingIsMade;
            model.chkEmailEveryTimePNRIsMade = (bool)result.EmailEveryTimePNRIsReleased;
            model.txtSendMailTo = result.SendEmailTo;
            model.rdbMarkupCharge = result.MarkupChargeIncludeInTax == true ? MarkupCharge.includeinTax : MarkupCharge.includeinFare;
            model.ddlDomesticType = result.isPercentDomesticServiceCharge == true ? 2 : 0;
            model.txtDomesticValue = (Double)result.DomesticServiceChargeValue;
            model.ddlInternationType = result.isPercentInternationalServiceCharge == true ? 2 : 0;
            model.txtInternationalValue = (Double)result.InternationalServiceChargeValue;
            model.TTL = result.TTL;

            return model;
        }

        public Core_AdminConfiguration GetCoreAdminConfiguration()
        {
            return ent.Core_AdminConfiguration.FirstOrDefault();
        }

    }
}