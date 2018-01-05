using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class UpdateDatabaseRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

        public string UpdateCity()
        {
            string result = "Failed";
            BusApi.BusApiClient _api = new BusApi.BusApiClient();
            BusApi.BusCityRequest _req = new BusApi.BusCityRequest();
            _req.Auth = BusGeneralProvider.AAuth;
            _req.MaxResult = 10000;
            _req.CityName = "";

            var onlineresult = _api.CityList(_req);
            if (onlineresult != null && onlineresult.List.Any())
            {
                var localresult = _ent.Bus_Cities;
                foreach (var item in onlineresult.List)
                {
                    bool addnew = true;

                    foreach (var localitem in localresult)
                    {
                        if (item.Value == localitem.BusCityCode)
                        {
                            // edit data....
                            var editData = _ent.Bus_Cities.FirstOrDefault(x => x.BusCityCode == item.Value);
                            editData.BusCityName = item.Text;
                            _ent.ApplyCurrentValues(editData.EntityKey.EntitySetName, editData);
                            //_ent.SaveChanges();
                            addnew = false;
                        }
                    }
                    if (addnew == true)
                    {
                        //add data....
                        TravelPortalEntity.Bus_Cities obj = new TravelPortalEntity.Bus_Cities
                        {
                            BusCityCode = item.Value,
                            BusCityName = item.Text,
                            isActive = true,
                            CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                            CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate()
                        };
                        _ent.AddToBus_Cities(obj);
                        //_ent.SaveChanges();                                                
                    }
                }
                _ent.SaveChanges();
                result = "Updated";
            }

            return result;
        }

        public string UpdateStation()
        {
            string result = "Failed";
            BusApi.BusApiClient _api = new BusApi.BusApiClient();
            BusApi.StationRequest _req = new BusApi.StationRequest();
            _req.Auth = BusGeneralProvider.AAuth;
            _req.MaxResult = 10000;
            _req.StationName = "";

            var onlineresult = _api.GetStations(_req);
            if (onlineresult != null && onlineresult.List.Any())
            {

                foreach (var item in onlineresult.List.Where(x => x.StationCode.Trim() != ""))
                {                   
                    var localresult = _ent.Bus_Stations.FirstOrDefault(x => x.BusStationCode == item.StationCode);
                    if (localresult != null)
                    {
                        localresult.BusStationName = item.StationName;
                        localresult.BusCityCode = item.CityCode;
                        localresult.BusCityName = item.CityName;
                        _ent.ApplyCurrentValues(localresult.EntityKey.EntitySetName, localresult);
                    }

                    else
                    {
                        //add data....
                        TravelPortalEntity.Bus_Stations obj = new TravelPortalEntity.Bus_Stations
                        {
                            BusCityCode = item.CityCode,
                            BusCityName = item.CityName,
                            BusStationCode = item.StationCode,
                            BusStationName = item.StationName,
                        };
                        _ent.AddToBus_Stations(obj);
                        //_ent.SaveChanges();                       
                    }
                }
                _ent.SaveChanges();
                result = "Updated";
            }

            return result;
        }

        public string UpdateCategory()
        {
            string result = "Failed";
            BusApi.BusApiClient _api = new BusApi.BusApiClient();
            BusApi.BusCategoryRequest _req = new BusApi.BusCategoryRequest();
            _req.Auth = BusGeneralProvider.AAuth;
            _req.MaxResult = 10000;
            _req.BusCatagoryName = "";
            _req.BusOperatorCode = "";

            var onlineresult = _api.CategoryList(_req);
            if (onlineresult != null && onlineresult.List.Any())
            {
                var localresult = _ent.Bus_Categories;
                foreach (var item in onlineresult.List)
                {
                    bool addnew = true;

                    foreach (var localitem in localresult)
                    {
                        if (item.CategoryId == localitem.CategoryCode)
                        {
                            // edit data....
                            var editData = _ent.Bus_Categories.FirstOrDefault(x => x.CategoryCode == item.CategoryId);
                            editData.BusCategoryName = item.CatagoryName;
                            editData.OperatoCode = item.OperatorId;
                            _ent.ApplyCurrentValues(editData.EntityKey.EntitySetName, editData);
                            //_ent.SaveChanges();
                            addnew = false;
                        }
                    }
                    if (addnew == true)
                    {
                        //add data....
                        TravelPortalEntity.Bus_Categories obj = new TravelPortalEntity.Bus_Categories
                        {
                            BusCategoryName = item.CatagoryName,
                            CategoryCode = item.CategoryId,
                            OperatoCode = item.OperatorId
                        };
                        _ent.AddToBus_Categories(obj);
                        //_ent.SaveChanges();                                                
                    }
                }
                _ent.SaveChanges();
                result = "Updated";
            }

            return result;
        }

        public string UpdateOperator()
        {
            string result = "Failed";
            BusApi.BusApiClient _api = new BusApi.BusApiClient();
            BusApi.OperatorRequest _req = new BusApi.OperatorRequest();
            _req.Auth = BusGeneralProvider.AAuth;
            _req.MaxResult = 10000;
            _req.OperatorName = "";

            var onlineresult = _api.OperatorList(_req);
            if (onlineresult != null && onlineresult.List.Any())
            {
                var localresult = _ent.Bus_Master;
                foreach (var item in onlineresult.List)
                {
                    bool addnew = true;

                    foreach (var localitem in localresult)
                    {
                        if (item.Value == localitem.OperatorCode)
                        {
                            // edit data....
                            var editData = _ent.Bus_Master.FirstOrDefault(x => x.OperatorCode == item.Value);
                            editData.BusMasterName = item.Text;
                            editData.ContactPerson = "";
                            editData.ContactAddress = "";
                            editData.Phone = "";
                            editData.Mobile = "";
                            editData.BusMasterEmial = "";
                            editData.UpdateBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                            editData.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                            //editData.LogoUrl = "";
                            _ent.ApplyCurrentValues(editData.EntityKey.EntitySetName, editData);
                            //_ent.SaveChanges();
                            addnew = false;
                        }
                    }
                    if (addnew == true)
                    {
                        //add data....
                        TravelPortalEntity.Bus_Master obj = new TravelPortalEntity.Bus_Master
                        {
                            BusMasterName = item.Text,
                            OperatorCode = item.Value,
                            ContactPerson = "",
                            ContactAddress = "",
                            Phone = "",
                            Mobile = "",
                            BusMasterEmial = "",
                            CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                            CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate()
                        };
                        _ent.AddToBus_Master(obj);
                        //_ent.SaveChanges();                                                
                    }
                }
                _ent.SaveChanges();
                result = "Updated";
            }

            return result;
        }

        public string UpdateRouteSchedule()
        {
            string result = "Failed";
            BusApi.BusApiClient _api = new BusApi.BusApiClient();
            BusApi.RouteScheduleRequest _req = new BusApi.RouteScheduleRequest();
            _req.Auth = BusGeneralProvider.AAuth;
            _req.MaxResult = 10000;
            _req.OperatorCode = "";
            _req.RouteScheduleName = "";

            var onlineresult = _api.RouteScheduleList(_req);
            if (onlineresult != null && onlineresult.List.Any())
            {
                var localresult = _ent.OnlineBusRouteSchedule;
                foreach (var item in onlineresult.List)
                {
                    bool addnew = true;

                    foreach (var localitem in localresult)
                    {
                        if (item.RouteScheduleCode == localitem.RouteScheduleCode)
                        {
                            // edit data....
                            var editData = _ent.OnlineBusRouteSchedule.FirstOrDefault(x => x.RouteScheduleCode == item.RouteScheduleCode);
                            editData.RouteScheduleName = item.RouteScheduleName;
                            editData.RouteScheduleCode = item.RouteScheduleCode;
                            editData.Operatorcode = item.OperatorCode;
                            _ent.ApplyCurrentValues(editData.EntityKey.EntitySetName, editData);
                            //_ent.SaveChanges();
                            addnew = false;
                        }
                    }
                    if (addnew == true)
                    {
                        //add data....
                        TravelPortalEntity.OnlineBusRouteSchedule obj = new TravelPortalEntity.OnlineBusRouteSchedule
                        {
                            RouteScheduleName = item.RouteScheduleName,
                            RouteScheduleCode = item.RouteScheduleCode,
                            Operatorcode = item.OperatorCode
                        };
                        _ent.AddToOnlineBusRouteSchedule(obj);
                        //_ent.SaveChanges();                                                
                    }
                }
                _ent.SaveChanges();
                result = "Updated";
            }

            return result;
        }

    }
}

