using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using System.Data.SqlClient;
using ATLTravelPortal.Areas.Airline.Models;
using System.Web.Mvc;
using System.Transactions;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirPackageCustomizeInquiryProvider
    {

        EntityModel _ent = new EntityModel();       
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(AirPackageCustomizeInquiryModel model, string tranMode)
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

        public IEnumerable<AirPackageCustomizeInquiryModel> GetList()
        {
            int sno = 0;
            List<AirPackageCustomizeInquiryModel> model = new List<AirPackageCustomizeInquiryModel>();
            var result = _ent.Core_PackagesCustomizeInquiries;
            foreach (var item in result)
            {
                sno++;
                AirPackageCustomizeInquiryModel obj = new AirPackageCustomizeInquiryModel
                {
                    SNO=sno,
                    PId = item.InquiryId,
                    AgentId = item.AgentId,
                    TravelDateStart = item.TravelDateStart,
                    TravelDateEnd = item.TravelDateEnd,
                    Name = item.Name,
                    EmailAddress = item.EmailAddress,
                    NoOfAdult = item.NoOfAdult,
                    NoOfChild = item.NoOfChild,
                    ContactNo = item.ContactNo,
                    Remark = item.Remark,
                    Status = item.Status,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(AirPackageCustomizeInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Core_PackagesCustomizeInquiries obj = new Core_PackagesCustomizeInquiries
                    {                        
                        AgentId = model.AgentId,
                        TravelDateStart = model.TravelDateStart,
                        TravelDateEnd = model.TravelDateEnd,
                        Name = model.Name,
                        EmailAddress = model.EmailAddress,
                        NoOfAdult = model.NoOfAdult,
                        NoOfChild = model.NoOfChild,
                        ContactNo = model.ContactNo,
                        Remark = model.Remark,
                        Status = model.Status,

                    };
                    _ent.AddToCore_PackagesCustomizeInquiries(obj);
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

        public ServiceResponse Edit(AirPackageCustomizeInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Core_PackagesCustomizeInquiries.Where(x => x.InquiryId == model.PId).FirstOrDefault();
                    if (result != null)
                    {                        
                        result.AgentId = model.AgentId;
                        result.TravelDateStart = model.TravelDateStart;
                        result.TravelDateEnd = model.TravelDateEnd;
                        result.Name = model.Name;
                        result.EmailAddress = model.EmailAddress;
                        result.NoOfAdult = model.NoOfAdult;
                        result.NoOfChild = model.NoOfChild;
                        result.ContactNo = model.ContactNo;
                        result.Remark = model.Remark;
                        result.Status = model.Status;

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

        public AirPackageCustomizeInquiryModel GetDetails(int PId)
        {
            var result = _ent.Core_PackagesCustomizeInquiries.Where(x => x.InquiryId == PId).FirstOrDefault();
            AirPackageCustomizeInquiryModel obj = new AirPackageCustomizeInquiryModel
            {
                PId = result.InquiryId,
                AgentId = result.AgentId,
                TravelDateStart = result.TravelDateStart,
                TravelDateEnd = result.TravelDateEnd,
                Name = result.Name,
                EmailAddress = result.EmailAddress,
                NoOfAdult = result.NoOfAdult,
                NoOfChild = result.NoOfChild,
                ContactNo = result.ContactNo,
                Remark = result.Remark,
                Status = result.Status,
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            Core_PackagesCustomizeInquiries result = _ent.Core_PackagesCustomizeInquiries.Where(x => x.InquiryId == PId).FirstOrDefault();

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