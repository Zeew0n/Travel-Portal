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
    public class AirPackageInquiryProvider
    {

        EntityModel _ent = new EntityModel();       
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(AirPackageInquiryModel model, string tranMode)
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

        public IEnumerable<AirPackageInquiryModel> GetList()
        {
            int sno = 0;
            List<AirPackageInquiryModel> model = new List<AirPackageInquiryModel>();
            var result = (from a in _ent.Core_PackagesInquiries
                         join b in _ent.Air_Packages on a.PackageId equals b.PackageId
                         select new{a,PackageName = b.Name}
                              )
                         .OrderBy(x => x.PackageName).OrderByDescending(x=>x.a.CreatedDate);
            foreach (var item in result)
            {
                sno++;
                AirPackageInquiryModel obj = new AirPackageInquiryModel
                {      
                   SNO =sno,
                    PId = item.a.PackagesInquiryId,
                    AgentId = item.a.AgentId,
                    PackageId = item.a.PackageId,
                    //PackageName = item.PackageName,
                    PackageName = item.a.PackageId == -1? item.a.PackageName : item.a.Air_Packages.Name,
                    Title = item.a.Title,
                    TravelDate = item.a.TravelDate,
                    Name = item.a.Name,
                    EmailAddress = item.a.EmailAddress,
                    NoOfAdult = item.a.NoOfAdult,
                    NoOfChild = item.a.NoOfChild,
                    ContactNo = item.a.ContactNo,
                    Remark = item.a.Remark,
                    CreatedBy = item.a.CreatedBy,
                    CreatedDate = item.a.CreatedDate,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(AirPackageInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Core_PackagesInquiries obj = new Core_PackagesInquiries
                    {                        
                        AgentId = model.AgentId,
                        PackageId = model.PackageId,
                        Title = model.Title,
                        TravelDate = model.TravelDate,
                        Name = model.Name,
                        EmailAddress = model.EmailAddress,
                        NoOfAdult = model.NoOfAdult,
                        NoOfChild = model.NoOfChild,
                        ContactNo = model.ContactNo,
                        Remark = model.Remark,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate,

                    };
                    _ent.AddToCore_PackagesInquiries(obj);
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

        public ServiceResponse Edit(AirPackageInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Core_PackagesInquiries.Where(x => x.PackagesInquiryId == model.PId).FirstOrDefault();
                    if (result != null)
                    {
                        result.PackagesInquiryId = model.PId;
                        result.AgentId = model.AgentId;
                        result.PackageId = model.PackageId;
                        result.Title = model.Title;
                        result.TravelDate = model.TravelDate;
                        result.Name = model.Name;
                        result.EmailAddress = model.EmailAddress;
                        result.NoOfAdult = model.NoOfAdult;
                        result.NoOfChild = model.NoOfChild;
                        result.ContactNo = model.ContactNo;
                        result.Remark = model.Remark;
                        result.CreatedBy = model.CreatedBy;
                        result.CreatedDate = model.CreatedDate;

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

        public AirPackageInquiryModel GetDetails(int PId)
        {
            var result = _ent.Core_PackagesInquiries.Where(x => x.PackagesInquiryId == PId).FirstOrDefault();
            AirPackageInquiryModel obj = new AirPackageInquiryModel
            {
                PId = result.PackagesInquiryId,
                AgentId = result.AgentId,
                PackageId = result.PackageId,
                PackageName = result.PackageId==-1?result.PackageName : result.Air_Packages.Name,
                Title = result.Title,
                TravelDate = result.TravelDate,
                Name = result.Name,
                EmailAddress = result.EmailAddress,
                NoOfAdult = result.NoOfAdult,
                NoOfChild = result.NoOfChild,
                ContactNo = result.ContactNo,
                Remark = result.Remark,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            Core_PackagesInquiries result = _ent.Core_PackagesInquiries.Where(x => x.PackagesInquiryId == PId).FirstOrDefault();

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