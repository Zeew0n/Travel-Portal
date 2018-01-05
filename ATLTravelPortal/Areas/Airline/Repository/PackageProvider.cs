using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Models;
using System.Web.Configuration;
using ATLTravelPortal.App_Class;
using System.Transactions;
using System.Data.SqlClient;

namespace ATLTravelPortal.Repository
{
    public class PackageProvider
    {
        DateTime currentDate = GeneralRepository.CurrentDateTime();
        ServiceResponse _response = null;
        EntityModel _entAT = new EntityModel();

        public PackageModel GetDetail(int packageId)
        {
            var result = (from a in _entAT.Air_Packages
                          where a.IsPublish == true
                          select new { a }
                              ).Where(x => x.a.PackageId == packageId).FirstOrDefault();
            PackageModel model = new PackageModel();
            if (result != null)
            {
                model = new PackageModel
                {
                    PackageId = result.a.PackageId,
                    CountryId = result.a.CountryId,
                    CityId = result.a.CityId,
                    Name = result.a.Name,
                    PackageCode = result.a.PackageCode,
                    URL = result.a.URL,
                    StartingPrice = Convert.ToDecimal(result.a.StartingPrice),
                    Description = result.a.Description,
                    Overview = result.a.Overview,
                    Itineary = result.a.Itineary,
                    Destination = result.a.Destination,
                    TermAndConditions = result.a.TermAndConditions,
                    InclusiveAndExclusive = result.a.InclusiveAndExclusive,
                    Rate = result.a.Rate,
                    ImageFolderName = result.a.ImageFolderName,
                    EffectiveFrom = result.a.EffectiveFrom,
                    ExpireOn = result.a.ExpireOn,
                    B2CMarkup = result.a.B2CMarkup,
                    CreatedBy = result.a.CreatedBy,
                    CreatedDate = result.a.CreatedDate,
                    UpdatedBy = result.a.UpdatedBy,
                    UpdatedDate = result.a.UpdatedDate,
                    IsPublish = result.a.IsPublish,
                };
            }
            var resultImageList = (from b in _entAT.Air_PackagesImage
                                   where b.PackageId == result.a.PackageId
                                   select new { ImageName = b.ImageName, IsDefault = b.IsDefault });

          
                model.ImageNameList = resultImageList.Select(x => x.ImageName).ToList();
           

            model.DefaultImageName = resultImageList.OrderByDescending(x => x.IsDefault).Select(x => x.ImageName).FirstOrDefault();

            model.StartingPrice = Convert.ToDecimal(result.a.StartingPrice) + (result.a.B2BMarkUp != null ? Convert.ToDecimal(result.a.B2BMarkUp) : 0);
            return model;
        }

       

      

        public int GetPackageIdByURL(string packageUrl)
        {

            var result = (from a in _entAT.Air_Packages
                          where a.IsPublish == true
                          select new { a }
                                 ).Where(x => x.a.URL == packageUrl).Select(x => x.a.PackageId).FirstOrDefault();
            return result;
        }
    }
}