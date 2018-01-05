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
using ATL.Core.Parser;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirPackageProvider
    {

        EntityModel _ent = new EntityModel();
        //AdminSession session = (AdminSession)System.Web.HttpContext.Current.Session["WorkFlowSession"];
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(AirPackageModel model, string tranMode)
        {

            try
            {
                bool isExist = IsPackageExist(model.PackageId, model.Name);
                if (isExist == true)
                {
                    _response = new ServiceResponse("Package with same name already exist!!", MessageType.Warning, false, "Add");
                    return _response;
                }
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

        public IEnumerable<AirPackageModel> GetList()
        {
            int sno = 0;
            List<AirPackageModel> model = new List<AirPackageModel>();
            var result = _ent.Air_Packages.OrderBy(x => x.Name);
            foreach (var item in result)
            {
                sno++;
                AirPackageModel obj = new AirPackageModel
                {
                    SNO=sno,
                    PackageId = item.PackageId,
                    CountryId = item.CountryId,
                    ZoneId = item.ZoneId,
                    CountryName=GetCountryName(item.CountryId),
                    Name = item.Name,
                    PackageCode = item.PackageCode,
                    URL = item.URL,
                    //Tags = item.Tags,
                    StartingPrice = item.StartingPrice,
                    Overview = item.Overview,
                    Itineary = item.Itineary,
                    Destination = item.Destination,
                    TermAndConditions = item.TermAndConditions,
                    InclusiveAndExclusive = item.InclusiveAndExclusive,
                    Rate = item.Rate,
                    ImageFolderName = item.ImageFolderName,
                    //EffectiveFrom = item.EffectiveFrom,
                    //ExpireOn = item.ExpireOn,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,
                    IsPublish = item.IsPublish,

                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        private string GetCountryName(int id)
        {
            return _ent.Countries.Where(x => x.CountryId == id).Select(x => x.CountryName).FirstOrDefault();
        }

        public ServiceResponse Save(AirPackageModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Air_Packages obj = new Air_Packages
                    {
                        PackageId = model.PackageId,
                        CountryId = model.CountryId,
                        ZoneId = model.ZoneId,
                        //CityId = model.CityId,
                        PackageGroupId=model.PackageGroupId,
                        Name = model.Name.Trim(),
                        PackageCode = model.PackageCode,
                        URL = model.URL.Trim(),
                        //Tags = model.Tags,
                        StartingPrice = model.StartingPrice,
                        StartingPriceINR = model.StartingINR,
                        StartingPriceUSD = model.StartingUSD,
                        Overview = model.Overview,
                        Itineary = model.Itineary,
                        Destination = model.Destination,
                        TermAndConditions = model.TermAndConditions,
                        InclusiveAndExclusive = model.InclusiveAndExclusive,
                        Rate = model.Rate,
                        ImageFolderName = AppGuid.NewGuid(Convert.ToChar("D")),
                        EffectiveFrom = DateTime.UtcNow,
                        ExpireOn = DateTime.UtcNow,
                        CreatedBy = session.AppUserId,
                        CreatedDate = currentDate,
                        IsPublish = model.IsPublish,

                        Duration = model.Duration,
                        Description = model.PackageSummary,
                        IsB2CPackage = true,
                        //IsB2BPackage = model.IsB2BPackage,
                        //B2CMarkup = model.B2CMarkup,
                        //B2BMarkUp = model.B2BMarkUp,
                        isFeatured=false
                    };
                    _ent.AddToAir_Packages(obj);
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

        public ServiceResponse Edit(AirPackageModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Air_Packages.Where(x => x.PackageId == model.PackageId).FirstOrDefault();
                    if (result != null)
                    {
                        result.PackageId = model.PackageId;
                        result.CountryId = model.CountryId;
                        result.ZoneId = model.ZoneId;
                        //result.CityId = model.CityId;
                        result.PackageGroupId = model.PackageGroupId;
                        result.Name = model.Name.Trim();
                        result.PackageCode = model.PackageCode;
                        result.URL = model.URL.Trim();
                        //result.Tags = model.Tags;
                        result.StartingPrice = model.StartingPrice;
                        result.StartingPriceINR = model.StartingINR;
                        result.StartingPriceUSD = model.StartingUSD;
                        result.Overview = model.Overview;
                        result.Itineary = model.Itineary;
                        result.Destination = model.Destination;
                        result.TermAndConditions = model.TermAndConditions;
                        result.InclusiveAndExclusive = model.InclusiveAndExclusive;
                        result.Rate = model.Rate;
                        result.EffectiveFrom = DateTime.UtcNow;
                        result.ExpireOn = DateTime.UtcNow;

                        result.UpdatedBy = session.AppUserId;
                        result.UpdatedDate = currentDate;
                        result.IsPublish = model.IsPublish;

                        result.Duration = model.Duration;
                        result.Description = model.PackageSummary;
                        result.IsB2CPackage = true;
                        //result.IsB2BPackage = model.IsB2BPackage;
                        //result.B2CMarkup = model.B2CMarkup;
                        //result.B2BMarkUp = model.B2BMarkUp;
                        result.isFeatured = false;

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

        public AirPackageModel GetDetails(int PackageId)
        {
            var result = _ent.Air_Packages.Where(x => x.PackageId == PackageId).FirstOrDefault();
            AirPackageModel obj = new AirPackageModel
            {
                PackageId = result.PackageId,
                CountryId = result.CountryId,
                //CityId = result.CityId,
                ZoneId = result.ZoneId,
                PackageGroupId=result.PackageGroupId,
                Name = result.Name,
                PackageCode = result.PackageCode,
                URL = result.URL,
                //Tags = result.Tags,
                StartingPrice = result.StartingPrice,
                StartingINR = result.StartingPriceINR,
                StartingUSD = result.StartingPriceUSD,
                Overview = result.Overview,
                Itineary = result.Itineary,
                Destination = result.Destination,
                TermAndConditions = result.TermAndConditions,
                InclusiveAndExclusive = result.InclusiveAndExclusive,
                Rate = result.Rate,
                ImageFolderName = result.ImageFolderName,
                //EffectiveFrom = result.EffectiveFrom,
                //ExpireOn = result.ExpireOn,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                UpdatedBy = result.UpdatedBy,
                UpdatedDate = result.UpdatedDate,
                Duration = result.Duration,
                PackageSummary = result.Description,
                //IsB2BPackage = (bool)result.IsB2BPackage,
                IsB2CPackage = (bool)result.IsB2CPackage,
                //B2BMarkUp = result.B2BMarkUp,
                //B2CMarkup = result.B2CMarkup,
                IsPublish = result.IsPublish,
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PackageId)
        {
            Air_Packages result = _ent.Air_Packages.Where(x => x.PackageId == PackageId).FirstOrDefault();

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

        //public List<SelectListItem> GetSelectListOptionContentType()
        //{
        //    try
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList = App_Classes.EnumParser.GetEnumSelectOption(typeof(App_Classes.AppGeneral.ContentType));
        //        return ddlList;

        //    }
        //    catch
        //    {
        //        throw;

        //    }

        //}

        public bool IsPackageExist(int PackageId, string PackageName)
        {
            var result = _ent.Air_Packages.Where(x => x.PackageId != PackageId && x.Name.Trim().ToLower() == PackageName.Trim().ToLower()).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;


        }

        public bool IsPackageCodeExist(int PackageId, string PackageCode)
        {
            var result = _ent.Air_Packages.Where(x => x.PackageId != PackageId && x.PackageCode.Trim().ToLower() == PackageCode.Trim().ToLower()).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;


        }

        public string GetPackageImageFolderName(int PackageId)
        {
            return _ent.Air_Packages.Where(x => x.PackageId == PackageId).Select(x => x.ImageFolderName).FirstOrDefault();        
        }

        public static List<SelectListItem> GetSelectListOptionDuration()
        {
            Type enumType = typeof(Package.EnumPackageDuration);
            List<SelectListItem> ddlList = new List<SelectListItem>();

            var enumValues = from Enum at
                               in Enum.GetValues(enumType)
                             select new
                             {
                                 Value = (int)Enum.Parse(enumType, at.ToString()),
                                 Text = Enum.Parse(enumType, at.ToString())
                             };

            foreach (var x in enumValues)
            {
                ddlList.Add(new SelectListItem { Text = App_Class.EnumParser.GetEnumStringValueAttribute<Package.EnumPackageDuration>(x.Text.ToString()), Value = x.Text.ToString() });
            }

            ddlList = ddlList.OrderBy(x => x.Text).ToList();
            ddlList.Insert(0, new SelectListItem { Text = "---Select---", Value = "" });
            return ddlList;
        }

        public AirPackageModel GetPackageGroupNameDdl(AirPackageModel _model)
        {
            AirPackageGroupProvider _apgp = new AirPackageGroupProvider();
            _model.ddlPackageGroupName = new SelectList(_apgp.GetPackageGroupNameList(), "PackageGroupId", "GroupName");
            return _model;
        }

        public IList<Core_LayoutZone> GetZoneList()
        {
            return (_ent.Core_LayoutZone.OrderBy(x => x.ZoneId).ToList());
        }

        //public AirPackageModel GetCurrencyListDdl(AirPackageModel _model)
        //{
        //    GeneralProvider _gp = new GeneralProvider();
        //    _model.ddlCurrencyList = new SelectList(_gp.GetCurrencyList(),"CurrencyId","CurrencyCode");
        //    return _model;
        
        //}
       


    }
}