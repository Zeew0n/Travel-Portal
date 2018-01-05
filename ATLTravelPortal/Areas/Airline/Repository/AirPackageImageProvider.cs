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
using System.Configuration;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirPackageImageProvider
    {

        EntityModel _ent = new EntityModel();
        //AdminSession session = (AdminSession)System.Web.HttpContext.Current.Session["WorkFlowSession"];
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;
        string packageRootFolder = null;
        public ServiceResponse ActionSaveUpdate(AirPackageImageModel model, string tranMode)
        {

            try
            {
                return Save(model);
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

        public IEnumerable<AirPackageImageModel> GetList(int PackageId)
        {
            List<AirPackageImageModel> model = new List<AirPackageImageModel>();
            var result = _ent.Air_PackagesImage.Where(x => x.PackageId == PackageId).OrderBy(x => x.ImageName);
            foreach (var item in result)
            {
                AirPackageImageModel obj = new AirPackageImageModel
                {         
                    PackageImageId = item.PackageImageId,
                    PackageId = item.PackageId,
                    PackageName = item.Air_Packages.Name,
                    PackageImageFolder = item.Air_Packages.ImageFolderName,
                    ImageName = item.ImageName,
                    ImageCaption = item.ImageCaption,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(AirPackageImageModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _response = ManagePackageFolder(model);
                    if (!_response.ResponseStatus)
                    {                        
                        return _response;                                        
                    }

                    foreach (var item in model.ImageUploader)
                    {
                        var file = item.UploadedFile;
                        string UploadedFileName = ManageImage(file);

                        Air_PackagesImage obj = new Air_PackagesImage
                        {                            
                            PackageId = model.PackageId,
                            ImageName = UploadedFileName,
                            ImageCaption = item.UploadedImageCaption,

                        };
                        _ent.AddToAir_PackagesImage(obj);
                        _ent.SaveChanges();
                    }
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Save");
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

        private string ManageImage(HttpPostedFileBase file) 
        {
            int Hight = int.Parse(ConfigurationManager.AppSettings["PackageThumbnailHight"].ToString());
            int Width = int.Parse(ConfigurationManager.AppSettings["PackageThumbnailWidth"].ToString());
            try
            {
                string UploadedFileName = AppUploader.UploadFileAndRename(file, AppUploader.ContentPathMode.absolute, packageRootFolder);
                AppUploader.ResizeImage(packageRootFolder + "\\" + UploadedFileName, packageRootFolder + "\\Images\\" + UploadedFileName, 500, 500,true);
                AppUploader.ResizeImage(packageRootFolder + "\\" + UploadedFileName, packageRootFolder + "\\Thumbnail\\" + UploadedFileName, Width, Hight, true);
                return UploadedFileName;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        
        }

        private ServiceResponse ManagePackageFolder(AirPackageImageModel model)
        {

            if (string.IsNullOrEmpty(model.PackageImageFolder))
            {
                AirPackageProvider _p = new AirPackageProvider();
                model.PackageImageFolder = _p.GetPackageImageFolderName(model.PackageId);

            }
            packageRootFolder = model.PackageImageRootPath + "\\" + model.PackageImageFolder;
            if (!AppUploader.IsDirectoryExist(model.PackageImageFolder, model.PackageImageRootPath))
            {
                if (!AppUploader.CreateDirectory(model.PackageImageFolder, model.PackageImageRootPath))
                {
                    _response = new ServiceResponse("Error Occured while uploading folder/images!!", MessageType.Error, false, "Save");
                    return _response;

                }
                CreatePackageImageFolder("Images", packageRootFolder);
                CreatePackageThumbnailFolder("Thumbnail", packageRootFolder);
            }

            _response = new ServiceResponse("Error Occured while uploading folder/images!!", MessageType.Success, true, "Save");
            return _response;

        }


        private bool CreatePackageImageFolder(string directoryName, string parentDirectoryPath)
        {          
            if (AppUploader.CreateDirectory(directoryName, parentDirectoryPath))
            {
                return true;
            }
            return true;
        }

        private bool CreatePackageThumbnailFolder(string directoryName, string parentDirectoryPath)
        {
            if (AppUploader.CreateDirectory(directoryName, parentDirectoryPath))
            {
                return true;
            }
            return true;
        }

       
        public App_Class.ServiceResponse Delete(int PackageImageId)
        {
            Air_PackagesImage result = _ent.Air_PackagesImage.Where(x => x.PackageImageId == PackageImageId).FirstOrDefault();

            try
            {
                AirPackageProvider _p = new AirPackageProvider();
                string PackageImageFolder = _p.GetPackageImageFolderName(result.PackageId);
                string imageName = result.ImageName;

                _ent.DeleteObject(result);
                _ent.SaveChanges();
                if (!string.IsNullOrEmpty(PackageImageFolder) && !string.IsNullOrEmpty(imageName))
                {
                    AirPackageImageModel model = new AirPackageImageModel();
                    AppUploader.DeleteFileByName(model.PackageImageRootPath + "\\" + PackageImageFolder, imageName);
                    AppUploader.DeleteFileByName(model.PackageImageRootPath + "\\" + PackageImageFolder + "\\Images", imageName);
                    AppUploader.DeleteFileByName(model.PackageImageRootPath + "\\" + PackageImageFolder + "\\Thumbnail", imageName);
                }
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

        public App_Class.ServiceResponse SetDefaultImage(int PackageImageId)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    Air_PackagesImage result = _ent.Air_PackagesImage.Where(x => x.PackageImageId == PackageImageId).FirstOrDefault();
                    if (result != null)
                    {
                        var resultAll = _ent.Air_PackagesImage.Where(x => x.PackageId == result.PackageId && x.PackageImageId != PackageImageId);
                        if (resultAll != null)
                        {
                            foreach (var item in resultAll)
                            {
                                item.IsDefault = false;
                                _ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                                _ent.SaveChanges();
                            }


                        }

                        result.IsDefault = true;
                        _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                        _ent.SaveChanges();
                    }
                    ts.Complete();
                }
               
                _response = new ServiceResponse("Successfully updated!!", MessageType.Success, true, "SetDefault");
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