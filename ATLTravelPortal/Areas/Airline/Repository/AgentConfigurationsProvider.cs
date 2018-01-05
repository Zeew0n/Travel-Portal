using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentConfigurationsProvider
    {
        EntityModel ent = new EntityModel();


        public void AgentConfigurationAdd(AgentConfigurationsModel modelToSave)
        {
            Core_AgentConfiguration datamodel = new Core_AgentConfiguration
            {
                AgentId = modelToSave.AgentId,
                ShowFareOnETicket = modelToSave.rdbgroupFare == Fare.ShowFare ? true : false,
                ShowAllFare = modelToSave.rdbAllFares == AllFares.showallfares ? true:false,
                HideAllFare = modelToSave.rdbAllFares == AllFares.hideallfares ? true:false,
                ShowOnlyPublishedFares = modelToSave.rdbAllFares == AllFares.showonlypublishedfares ? true:false,
                EmailEveryTimeBookingIsMade = modelToSave.chkEmailBooking,
                EmailEveryTimePNRIsReleased = modelToSave.chkEmailPNR,
                SendEmailTo = modelToSave.txtSendMailTo,
                ServiceChargeIncludeInTax = modelToSave.rdbServiceCharge == ServiceCharge.includeintax ? true:false,
                ShowasServiceCharge = modelToSave.rdbServiceCharge == ServiceCharge.showasservicecharge ? true:false,
                isPercentDomesticServiceCharge = Convert.ToBoolean( modelToSave.ddlDomesticType),
                DomesticServiceChargeValue = modelToSave.txtDomesticValue,
                isPercentInternationalServiceCharge = Convert.ToBoolean( modelToSave.ddlInternationType),
                InternationalServiceChargeValue = modelToSave.txtInternationalValue
            };
            ent.AddToCore_AgentConfiguration(datamodel);
            ent.SaveChanges();
           
        }




        public void AgentConfigurationEdit(AgentConfigurationsModel model)
        {
            Core_AgentConfiguration result = ent.Core_AgentConfiguration.Where(x => x.AgentId == model.AgentId).FirstOrDefault();
          //  result.AgentConfugrationId = model.AgentConfugrationId;
            result.ShowFareOnETicket = model.rdbgroupFare == Fare.ShowFare?true:false;
            result.ShowAllFare = model.rdbAllFares == AllFares.showallfares ? true : false;
            result.HideAllFare = model.rdbAllFares == AllFares.hideallfares ? true : false;
            result.ShowOnlyPublishedFares = model.rdbAllFares == AllFares.showonlypublishedfares ? true : false;
            result.EmailEveryTimeBookingIsMade = model.chkEmailBooking;
            result.EmailEveryTimePNRIsReleased = model.chkEmailPNR;
            result.SendEmailTo = model.txtSendMailTo;
            result.ServiceChargeIncludeInTax = model.rdbServiceCharge == ServiceCharge.includeintax ? true : false;
            result.ShowasServiceCharge = model.rdbServiceCharge == ServiceCharge.showasservicecharge ? true : false;
            //result.isPercentDomesticServiceCharge = Convert.ToBoolean( model.ddlDomesticType);
            result.isPercentDomesticServiceCharge = model.ddlDomesticType == 2 ? true : false;
            result.DomesticServiceChargeValue = model.txtDomesticValue;
           // result.isPercentInternationalServiceCharge = Convert.ToBoolean(model.ddlInternationType);
            result.isPercentInternationalServiceCharge = model.ddlInternationType == 2 ? true : false;
            result.InternationalServiceChargeValue = model.txtInternationalValue;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

        }

        // for checking duplicate insertion of AgentId
        public bool CheckDuplicateAgentId(int Id)
        {
            Core_AgentConfiguration result = ent.Core_AgentConfiguration.Where(x => x.AgentId == Id).FirstOrDefault();

            if (result != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        public AgentConfigurationsModel GetAgentConfigurationDetail(int id)
        {
             AgentConfigurationsModel model = new AgentConfigurationsModel(); 
            Core_AgentConfiguration result = ent.Core_AgentConfiguration.Where(x => x.AgentId == id).FirstOrDefault();
            if (result != null)
            {


                model.AgentConfugrationId = result.AgentConfugrationId;
                model.AgentId = (int)result.AgentId;
                model.rdbgroupFare = result.ShowFareOnETicket == true ? Fare.ShowFare : Fare.HideFare;

                // model.rdbAllFares = result.ShowAllFare == true?AllFares.showallfares : AllFares.hideallfares;

                if (result.ShowAllFare == true)
                {
                    model.rdbAllFares = result.ShowAllFare == true ? AllFares.showallfares : AllFares.hideallfares;
                }

                if (result.HideAllFare == true)
                {
                    model.rdbAllFares = result.HideAllFare == true ? AllFares.hideallfares : AllFares.showallfares;
                }

                if (result.ShowOnlyPublishedFares == true)
                {
                    model.rdbAllFares = result.ShowOnlyPublishedFares == true ? AllFares.showonlypublishedfares : AllFares.showallfares;
                }

                model.chkEmailBooking = (bool)result.EmailEveryTimeBookingIsMade;
                model.chkEmailPNR = (bool)result.EmailEveryTimePNRIsReleased;
                model.txtSendMailTo = result.SendEmailTo;
                model.rdbServiceCharge = result.ServiceChargeIncludeInTax == true ? ServiceCharge.includeintax : ServiceCharge.showasservicecharge;
                model.ddlDomesticType = result.isPercentDomesticServiceCharge == true ? 2 : 0;
                model.txtDomesticValue = (Double)result.DomesticServiceChargeValue;
                model.ddlInternationType = result.isPercentInternationalServiceCharge == true ? 2 : 0;
                model.txtInternationalValue = (Double)result.InternationalServiceChargeValue;
            }
            return model;
        }

        public Core_AgentConfiguration GetCore_AgentConfugrations(int AgentId)
        {
          return ent.Core_AgentConfiguration.Where(x => x.AgentId == AgentId).FirstOrDefault();          
        }
    }
}