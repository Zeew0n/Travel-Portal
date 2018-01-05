using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.App_Class;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirPackageGroupImageProvider
    {

        EntityModel _ent = new EntityModel();
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;
        string packageRootFolder = null;
        public ServiceResponse ActionSaveUpdate(AirPackageGroupImageModel _model, string tranMode)
        {

            try
            {
                return Save(_model);
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

        



        public IEnumerable<AirPackageGroupImageModel> GetList(int id)
        {
            List<AirPackageGroupImageModel> _model = new List<AirPackageGroupImageModel>();
            var result = _ent.Air_PackageGroupImage.Where(u => u.PackageGroupId == id).OrderBy(u => u.ImageName);
            foreach (var item in result)
            {
                AirPackageGroupImageModel _obj = new AirPackageGroupImageModel()
                {
                    PackageGroupImageId = item.PackageGroupImageId,
                    PackageGroupId = item.PackageGroupId,
                    PackageGroupName = item.Air_PackageGroups.GroupName,
                    PackageGroupImageFolder = item.Air_PackageGroups.ImageFolderName,
                    ImageCaption = item.ImageCaption,
                    ImageName = item.ImageName

                };
                _model.Add(_obj);
                           
            }
            return _model.AsEnumerable();
            
          
        }


        public ServiceResponse Save(AirPackageGroupImageModel _model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _response = ManagePackageFolder(_model);
                    if (!_response.ResponseStatus)
                    {
                        return _response;
                    }

                    foreach (var item in _model.ImageUploader)
                    {
                        var file = item.UploadedFile;
                        string UploadedFileName = ManageImage(file);

                        Air_PackageGroupImage _obj=new Air_PackageGroupImage()
                        {
                            PackageGroupId=_model.PackageGroupId,
                            ImageName=UploadedFileName,
                            ImageCaption=item.UploadedImageCaption,
                           
                        };
                        _ent.AddToAir_PackageGroupImage(_obj);
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
                AppUploader.ResizeImage(packageRootFolder + "\\" + UploadedFileName, packageRootFolder + "\\Images\\" + UploadedFileName, 500, 500, true);
                AppUploader.ResizeImage(packageRootFolder + "\\" + UploadedFileName, packageRootFolder + "\\Thumbnail\\" + UploadedFileName, Width, Hight, true);
                return UploadedFileName;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        private ServiceResponse ManagePackageFolder(AirPackageGroupImageModel _model)
        {

            if (string.IsNullOrEmpty(_model.PackageGroupImageFolder))
            {
             //   AirPackageProvider _p = new AirPackageProvider();
                //_model.PackageImageFolder = _p.GetPackageImageFolderName(_model.PackageId);

              AirPackageGroupProvider _p = new AirPackageGroupProvider();
              _model.PackageGroupImageFolder = _p.GetPackageGroupImageFolderName(_model.PackageGroupId);

            }
            packageRootFolder = _model.PackageImageRootPath + "\\" + _model.PackageGroupImageFolder;
            if (!AppUploader.IsDirectoryExist(_model.PackageGroupImageFolder, _model.PackageImageRootPath))
            {
                if (!AppUploader.CreateDirectory(_model.PackageGroupImageFolder, _model.PackageImageRootPath))
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


        public App_Class.ServiceResponse Delete(int id)
        {
            Air_PackageGroupImage result = _ent.Air_PackageGroupImage.Where(u=>u.PackageGroupImageId== id).FirstOrDefault();

            try
            {
                AirPackageGroupProvider _p = new AirPackageGroupProvider();
                string PackageGroupImageFolder = _p.GetPackageGroupImageFolderName(result.PackageGroupId);
                string imageName = result.ImageName;

                _ent.DeleteObject(result);
                _ent.SaveChanges();
                if (!string.IsNullOrEmpty(PackageGroupImageFolder) && !string.IsNullOrEmpty(imageName))
                {
                    AirPackageGroupImageModel _model = new AirPackageGroupImageModel();
                    AppUploader.DeleteFileByName(_model.PackageImageRootPath + "\\" + PackageGroupImageFolder, imageName);
                    AppUploader.DeleteFileByName(_model.PackageImageRootPath + "\\" + PackageGroupImageFolder + "\\Images", imageName);
                    AppUploader.DeleteFileByName(_model.PackageImageRootPath + "\\" + PackageGroupImageFolder + "\\Thumbnail", imageName);
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

        public App_Class.ServiceResponse SetDefaultGroupImage(int id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    Air_PackageGroupImage result = _ent.Air_PackageGroupImage.Where(u => u.PackageGroupImageId == id).FirstOrDefault();
                    if (result != null)
                    {
                        var resultAll = _ent.Air_PackageGroupImage.Where(u => u.PackageGroupId == result.PackageGroupId && u.PackageGroupImageId != id);
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