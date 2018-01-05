using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using System.Data.SqlClient;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using System.Transactions;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class TrainingInquiryProvider
    {

        EntityModel _ent = new EntityModel();       
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(TrainingInquiryModel model, string tranMode)
        {

            try
            {                       
                if (tranMode == "N")
                {
                    return Save(model);
                }
                else if (tranMode == "U")
                {

                    return Edit(model);

                }


            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false);
            }

            return _response;



        }

        public IEnumerable<TrainingInquiryModel> GetList()
        {
            List<TrainingInquiryModel> model = new List<TrainingInquiryModel>();
            var result = _ent.Core_TrainingSession;
            foreach (var item in result)
            {
                TrainingInquiryModel obj = new TrainingInquiryModel
                {
                    PId = item.TrainingSessionId,                   
                    FullName = item.FullName,
                    CompanyName = item.CompanyName,
                    EmailAddress = item.EmailAddress,
                    ContactNo = item.ContactNo,
                    IsAgent = item.IsAgent,
                    ObjectiveOfTraning = item.ObjectiveOfTraning,
                    PreferredDay = item.PreferredDay,
                    PrefferedTime = item.PrefferedTime,
                    Remarks = item.Remarks,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(TrainingInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Core_TrainingSession obj = new Core_TrainingSession
                    {                       
                        FullName = model.FullName,
                        CompanyName = model.CompanyName,
                        EmailAddress = model.EmailAddress,
                        ContactNo = model.ContactNo,
                        IsAgent = model.IsAgent,
                        ObjectiveOfTraning = model.ObjectiveOfTraning,
                        PreferredDay = model.PreferredDay,
                        PrefferedTime = model.PrefferedTime,
                        Remarks = model.Remarks,

                    };
                    _ent.AddToCore_TrainingSession(obj);
                    _ent.SaveChanges();
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Edit");
                    return _response;
                }
            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Edit");
            }
            return _response;
        }

        public ServiceResponse Edit(TrainingInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Core_TrainingSession.Where(x => x.TrainingSessionId == model.PId).FirstOrDefault();
                    if (result != null)
                    {                        
                        result.FullName = model.FullName;
                        result.CompanyName = model.CompanyName;
                        result.EmailAddress = model.EmailAddress;
                        result.ContactNo = model.ContactNo;
                        result.IsAgent = model.IsAgent;
                        result.ObjectiveOfTraning = model.ObjectiveOfTraning;
                        result.PreferredDay = model.PreferredDay;
                        result.PrefferedTime = model.PrefferedTime;
                        result.Remarks = model.Remarks;

                        _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                        _ent.SaveChanges();
                    }
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully updated!!", MessageType.Success, true, "Edit");
                }


            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Edit");
            }
            return _response;

        }

        public TrainingInquiryModel GetDetails(int PId)
        {
            var result = _ent.Core_TrainingSession.Where(x => x.TrainingSessionId == PId).FirstOrDefault();
            TrainingInquiryModel obj = new TrainingInquiryModel
            {
                PId = result.TrainingSessionId,
                FullName = result.FullName,
                CompanyName = result.CompanyName,
                EmailAddress = result.EmailAddress,
                ContactNo = result.ContactNo,
                IsAgent = result.IsAgent,
                ObjectiveOfTraning = result.ObjectiveOfTraning,
                PreferredDay = result.PreferredDay,
                PrefferedTime = result.PrefferedTime,
                Remarks = result.Remarks,
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            Core_TrainingSession result = _ent.Core_TrainingSession.Where(x => x.TrainingSessionId == PId).FirstOrDefault();

            try
            {
                _ent.DeleteObject(result);
                _ent.SaveChanges();
                _response = new ServiceResponse("Successfully deleted!!", MessageType.Success, true, "Delete");
                return _response;

            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Delete");
            }
            return _response;

        }

    }
}