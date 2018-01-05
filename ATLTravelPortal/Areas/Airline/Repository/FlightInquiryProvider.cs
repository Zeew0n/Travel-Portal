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
    public class FlightInquiryProvider
    {

        EntityModel _ent = new EntityModel();       
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(FlightInquiryModel model, string tranMode)
        {

            try
            {                       
                if (tranMode == "N")
                {
                    
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

        public IEnumerable<FlightInquiryModel> GetList()
        {
            List<FlightInquiryModel> model = new List<FlightInquiryModel>();
            var result = _ent.B2CFlightInquiry;//.OrderBy(x => x.);
            foreach (var item in result)
            {
                FlightInquiryModel obj = new FlightInquiryModel
                {                    
                    PId = item.FlightInquiryId,                    
                    FlightType = item.FlightType,
                    JourneyType = item.JourneyType,
                    
                    HddnOriginCityId = item.OriginCity,
                    HddnDepartureCityId = item.DepartureCity,
                    DepartureDate = item.DepartureDate,
                    ReturnDate = item.ReturnDate,
                    NoOfAdult = item.NoOfAdult,
                    NoOfChildren = item.NoOfChildren,
                    NoOfInfant = item.NoOfInfant,
                    PassengerNumber = item.PassengerNumber,
                    CabinClass = item.CabinClass,
                    Nationality = item.Nationality,
                    AirlinePreference = item.AirlinePreference,
                    Status = item.Status,

                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Edit(FlightInquiryModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.B2CFlightInquiry.Where(x => x.FlightInquiryId == model.PId).FirstOrDefault();
                    if (result != null)
                    {                        
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

        public FlightInquiryModel GetDetails(int PId)
        {
            var result = _ent.B2CFlightInquiry.Where(x => x.FlightInquiryId == PId).FirstOrDefault();
            FlightInquiryModel obj = new FlightInquiryModel
            {
                PId = result.FlightInquiryId,
                FlightType = result.FlightType,
                JourneyType = result.JourneyType,
                HddnOriginCityId = result.OriginCity,
                HddnDepartureCityId = result.DepartureCity,
                //OriginCity = result.OriginCity.
                DepartureDate = result.DepartureDate,
                ReturnDate = result.ReturnDate,
                NoOfAdult = result.NoOfAdult,
                NoOfChildren = result.NoOfChildren,
                NoOfInfant = result.NoOfInfant,
                PassengerNumber = result.PassengerNumber,
                CabinClass = result.CabinClass,
                Nationality = result.Nationality,
                AirlinePreference = result.AirlinePreference,
                Status = result.Status,
                ContactName = result.ContactName,
                ContactNumber = result.ContactNumber,
                EmailAddress = result.EmailAddress,
                CompanyAgentName= result.CompanyAgentName,

                FlightInquiryPax = (from a in _ent.B2CFlightInquiryPax
                                      where a.FlightInquiryId == PId 
                                      select new FlightInquiryPaxModel{
                                          FlightInquiryPaxId = a.FlightInquiryPaxId,
                                          FlightInquiryId = a.FlightInquiryId,
                                          Title = a.Title,
                                          FirstName = a.FirstName,
                                          MiddleName = a.MiddleName,
                                          LastName = a.LastName,
                                          Gender = a.Gender,
                                          PassengerType = a.PassengerType,
                                          ContactNumber = a.ContactNumber,
                                          EmailAddress = a.EmailAddress,                                                      
                                                                                                     
                                                                                                     
                        
                        }).OrderBy(x=>x.PassengerType).ToList(),
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            B2CFlightInquiry result = _ent.B2CFlightInquiry.Where(x => x.FlightInquiryId == PId).FirstOrDefault();
            var resultInquiryPax = _ent.B2CFlightInquiryPax.Where(x => x.FlightInquiryId == PId);
            try
            {
                foreach (var item in resultInquiryPax)
                {
                    var delResult = _ent.B2CFlightInquiryPax.Where(x => x.FlightInquiryId == item.FlightInquiryPaxId).FirstOrDefault();
                    _ent.DeleteObject(delResult);
                    _ent.SaveChanges();
                
                }
                
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