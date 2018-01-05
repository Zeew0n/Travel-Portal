using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.App_Class;



namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirPackageGroupProvider
    {
        EntityModel _ent = new EntityModel();

        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();

        public void AddPackage(AirPackageGroupModel _model)
        {
            Air_PackageGroups _obj = new Air_PackageGroups()
            {
                CountryId = _model.CountryId,
                ZoneId = _model.ZoneId,
                //Cityid = _model.CityId,
                GroupName = _model.GroupName,
                URL = _model.URL,
                Destination = _model.Destination,
                ImageFolderName = AppGuid.NewGuid(Convert.ToChar("D")),
                //IsB2BPackage = _model.IsB2BPackage,
                IsB2CPackage = true,
                CreatedBy=session.AppUserId,
                CreatedDate=currentDate,
                isFeatured=false,
                isPublished=true

            };

            _ent.AddToAir_PackageGroups(_obj);
            _ent.SaveChanges();
         
        }

        public IEnumerable<AirPackageGroupModel> ListPackage()
        {
            int sno = 0;
            var result = _ent.Air_PackageGroups;
            List<AirPackageGroupModel> _model = new List<AirPackageGroupModel>();
            foreach (var item in result)
            {
                sno++;
                AirPackageGroupModel _obj = new AirPackageGroupModel
                {
                     SNO=sno,
                    PackageGroupID=item.PackageGroupId,                 
                    CountryId = item.CountryId,
                    //CityId=item.Cityid,
                    GroupName = item.GroupName,
                    URL = item.URL,
                    Destination = item.Destination,
                    ImageFolderName = item.ImageFolderName,
                    IsB2BPackage = item.IsB2BPackage,
                    IsB2CPackage = item.IsB2CPackage,
                    CreatedBy=item.CreatedBy,
                    CreatedDate=item.CreatedDate,
                    UpdatedBy=item.UpdatedBy,
                    UpdatedDate=item.UpdatedDate,
                    CountryName=GetCountryName(item.CountryId),
                    CityName=GetCityName(item.Cityid),

                };  _model.Add(_obj);
             }

            return _model;
        
        }

        private string GetCountryName(int id)
        {
            return _ent.Countries.Where(x=>x.CountryId==id).Select(x=>x.CountryName).FirstOrDefault();
        }

        private string GetCityName(int? id)
        {
            return _ent.Core_Cities.Where(x => x.CityId == id).Select(x => x.CityName).FirstOrDefault();
        }

        
        public void EditPackage(AirPackageGroupModel _model)
        {
            Air_PackageGroups result = _ent.Air_PackageGroups.Where(u => u.PackageGroupId == _model.PackageGroupID).FirstOrDefault();

            result.PackageGroupId = _model.PackageGroupID;
            result.CountryId = _model.CountryId;
            result.ZoneId = _model.ZoneId;
            //result.Cityid = _model.CityId;
            result.GroupName = _model.GroupName;
            result.URL = _model.URL;
            result.Destination = _model.Destination;           
            //result.IsB2BPackage = _model.IsB2BPackage;
            result.IsB2CPackage = true;
            result.UpdatedBy = session.AppUserId;
            result.UpdatedDate = currentDate;
            result.isPublished = true;
            result.isFeatured = false;


            _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            _ent.SaveChanges();
             
        }

        public AirPackageGroupModel PackageDetails(int id)
        {
            Air_PackageGroups result = _ent.Air_PackageGroups.Where(u => u.PackageGroupId == id).FirstOrDefault();
            AirPackageGroupModel _model = new AirPackageGroupModel();

            _model.PackageGroupID = result.PackageGroupId;
            _model.CountryId = result.CountryId;
            _model.ZoneId = result.ZoneId;
            //_model.CityId = result.Cityid;
            _model.GroupName = result.GroupName;
            _model.URL = result.URL;
            _model.Destination = result.Destination;
            _model.ImageFolderName = result.ImageFolderName;
            //_model.IsB2BPackage = result.IsB2BPackage;
            _model.IsB2CPackage = result.IsB2CPackage;
            _model.CreatedBy = result.CreatedBy;
            _model.CreatedDate = result.CreatedDate;
            _model.UpdatedBy = result.UpdatedBy;
            _model.UpdatedDate = result.UpdatedDate;

            return _model;
        }


        public void DeletePackage(int id)
        {
            Air_PackageGroups result = _ent.Air_PackageGroups.Where(u=>u.PackageGroupId==id).FirstOrDefault();
            try
            {
                _ent.DeleteObject(result);
                _ent.SaveChanges();
            }
            catch (Exception ex)
            {
              
            }
        }

        public AirPackageGroupModel getddl(AirPackageGroupModel _model)
        {

            CoreCityProvider _ccp = new CoreCityProvider();
            CountryProvider _cp = new CountryProvider();   
                  
            _model.ddlCityList = new SelectList(_ccp.GetCityList(),"CityId","CityName");
            _model.ddlCountryList = new SelectList(_cp.GetCountryList(),"CountryId","CountryName");
            _model.ddlZoneList = new SelectList(GetZoneList(), "ZoneId", "ZoneValue",_model.ZoneId);
            

            return _model;

        }


        public string GetPackageGroupImageFolderName(int id)
        {           
            return _ent.Air_PackageGroups.Where(u => u.PackageGroupId == id).Select(u => u.ImageFolderName).FirstOrDefault();
        }

        public List<Air_PackageGroups> GetPackageGroupNameList()
        {
           var result = _ent.Air_PackageGroups;
           return result.ToList();
        }

        public IList<Core_LayoutZone> GetZoneList()
        {
            return (_ent.Core_LayoutZone.OrderBy(x => x.ZoneId).ToList());
        }

        
        
   }
}