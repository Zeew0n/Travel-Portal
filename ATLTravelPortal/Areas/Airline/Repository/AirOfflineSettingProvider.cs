using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using System.Data.SqlClient;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirOfflineSettingProvider
    {
        private TravelPortalEntity.EntityModel _entity = new EntityModel();
        private ServiceResponse _response;

        public Airlines GetAirlineById(int id)
        {
            return _entity.Airlines.Where(x => x.AirlineId == id).FirstOrDefault();

        }

        public List<AirOfflineSettingModel> GetOfflineAirlineList()
        {
            var list = new List<AirOfflineSettingModel>();
            if (_entity.Air_OffLineAirlineSettings.Count() > 0)
            {
                foreach (var data in _entity.Air_OffLineAirlineSettings)
                {
                    var airlineData = GetAirlineById(data.AirlineId);
                    var airline = new AirOfflineSettingModel()
                                 {
                                     PId = data.OfflineAirlineSettingId,
                                     AirlineId = data.AirlineId,
                                     IsOffline = data.IsOffline,
                                     AirlineName = airlineData.AirlineName,
                                     AirlineCode = airlineData.AirlineCode
                                 };

                    list.Add(airline);
                }
            }
            return list;
        }

        public AirOfflineSettingModel GetOfflineAirlineById(int id)
        {
            //  var detail = _entity.air_off

            var model = new AirOfflineSettingModel();
            model.AirlineCode = "9W";
            model.AirlineId = 1;
            model.AirlineName = "Jet Airways";

            return model;
        }

        public ServiceResponse ActionSaveUpdate(AirOfflineSettingModel model, string tranMode)
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

        public ServiceResponse Edit(AirOfflineSettingModel model)
        {

            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    foreach (var item in model.AirlineList)
                    {
                        var result = _entity.Air_OffLineAirlineSettings.Where(x => x.OfflineAirlineSettingId == item.PId).FirstOrDefault();
                        if (result != null)
                        {
                            result.IsOffline = item.IsOffline;
                            _entity.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                            _entity.SaveChanges();
                        }

                    }
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Edit");
                }
                catch (Exception ex)
                {
                    _response = new ServiceResponse("Error occured while editing record!!", MessageType.Warning, false, "Edit");
                    return _response;
                }
                return _response;
            }
        }

        public ServiceResponse Save(AirOfflineSettingModel model)
        {
            try
            {

                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (var data in model.AirlineList)
                    {
                        var result = _entity.Air_OffLineAirlineSettings.Where(x => x.AirlineId == data.AirlineId).FirstOrDefault();
                        if (result != null)
                        {
                            result.IsOffline = data.IsOffline;
                            _entity.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                            _entity.SaveChanges();
                        }
                        else
                        {
                            var setting = new Air_OffLineAirlineSettings()
                                              {
                                                  AirlineId = data.AirlineId,
                                                  ServiceProviderId = 5,
                                                  IsOffline = data.IsOffline,
                                                  CreatedBy = 1,
                                                  CreatedDate = DateTime.Now
                                              };
                            _entity.AddToAir_OffLineAirlineSettings(setting);
                            _entity.SaveChanges();
                        }
                    }

                    ts.Complete();
                    _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Edit");
                    return _response;

                }
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Edit");
                return _response;

            }
        }

        public bool Delete(int pId)
        {

            var result = _entity.Air_OffLineAirlineSettings.Where(x => x.OfflineAirlineSettingId == pId).FirstOrDefault();
            if (result != null)
            {
                _entity.DeleteObject(result);
                _entity.SaveChanges();
                return true;
            }
            return false;

        }

        public bool IsOfflineAirAlreadyExist(int id)
        {

            var result = _entity.Air_OffLineAirlineSettings.Where(x => x.AirlineId == id).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            return false;

        }
    }
}