using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.SecurityAttributes;
using System.IO;


namespace ATLTravelPortal.Areas.Hotel.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class HotelPhotoController : Controller
    {
        HotelPhotoRepository _PhotoRepo = new HotelPhotoRepository();
        HotelPhotoCategoryRepository _PhotoCatRepo = new HotelPhotoCategoryRepository();
        HotelInfoRepository _HotelInfoRepo = new HotelInfoRepository();
        //
        // GET: /HotelPhoto/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadPhoto()
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "UploadPhoto",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Upload"
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult UploadPhoto(HotelPhotos model, List<HttpPostedFileBase> Picture)
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "UploadPhoto",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Upload"
                };
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                else
                {
                    try
                    {
                        var httpFileCollection = Request.Files;
                        for (int i = 0; i < httpFileCollection.Count; i++)
                        {
                            var httpPostedFile = httpFileCollection[i];
                            if (httpPostedFile.ContentLength > 0)
                            {
                                string FileExtension = Path.GetExtension(httpPostedFile.FileName);
                                int FileSize = httpPostedFile.ContentLength;
                                Int64 MaxPhotoSizeToUpload = ATLTravelPortal.Helpers.ApplicationSettings.GetMaxPhotoSizeToUpload();

                                if (FileSize <= MaxPhotoSizeToUpload)
                                {
                                    switch (httpPostedFile.ContentType)
                                    {
                                        case "image/pjpeg":
                                        case "image/jpeg":
                                        case "image/gif":
                                        case "image/png":

                                            if (model.CategoryName == null)
                                            {
                                                return View(viewModel);
                                            }
                                            

                                            string CategoryName = model.CategoryName;
                                            string HotelName = model.HotelName;

                                            string sfileName = Guid.NewGuid().ToString() + "_sm" + FileExtension;
                                            string sFilePath = Server.MapPath("/HotelUploads/" + HotelName + "/" + CategoryName + "/");

                                            if (!Directory.Exists(Server.MapPath("~/HotelUploads/")))
                                            {
                                                Directory.CreateDirectory(Server.MapPath("~/HotelUploads/"));
                                            }
                                            if (!Directory.Exists(Server.MapPath("~/HotelUploads/" + HotelName + "/" + CategoryName + "/")))
                                            {
                                                Directory.CreateDirectory(Server.MapPath("~/HotelUploads/" + HotelName + "/" + CategoryName + "/"));
                                            }

                                            string location = sFilePath + "/" + sfileName;
                                            httpPostedFile.SaveAs(location);
                                            //To make thumbnail of Uploaded Image

                                            string[] ThumbnailSize = ATLTravelPortal.Helpers.ApplicationSettings.GetThumbnailSize();
                                            ATLTravelPortal.Helpers.ThumbnailGenerator.ChangeHeightWidth(location, System.Drawing.Image.FromFile(location), int.Parse(ThumbnailSize[0]), int.Parse(ThumbnailSize[1]));

                                            // Save into database
                                            Htl_HotelPhotos obj = new Htl_HotelPhotos();
                                            obj.Picture = sfileName;
                                            obj.PhotoCategoryId = int.Parse(CategoryName);
                                            obj.Title = "";
                                            obj.Details = "";
                                            obj.isActive = true;

                                            obj.CreatedBy = ATLTravelPortal.App_Class.AppSession.LogUserID;
                                            obj.CreatedDate = DateTime.Now;

                                            //ser.HotelPhotoAdd(sfileName, int.Parse(CategoryName), "", int.Parse(HotelName), true, App_Class.AppSession.LogUserID, DateTime.Now);
                                            _PhotoRepo.HotelPhotoAdd(obj);
                                            break;
                                        default:
                                            return Content("Invalid Image Type");
                                    }
                                    ViewData["success"] = "Photos Uploaded Successfully!";
                                }
                                else
                                {
                                    ViewData["success"] = "Photos size exceeds!";
                                }
                            }
                        }
                       
                    }
                    catch
                    {
                        throw;
                    }
                }

                //ViewData["success"] = "Photos Uploaded Successfully!";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

        public ActionResult List()
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "List",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "List Photos"
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult List(HotelPhotos model)
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(model.HotelName == null ? 0 : int.Parse(model.HotelName), model.CategoryName == null ? 0 : int.Parse(model.CategoryName)),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "List",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "List Photos"
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

        public ActionResult Edit()
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Edit",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save Changes"
                };
                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

     

        [HttpPost]
        public ActionResult Edit(HotelPhotos model, List<HotelPhotos> DetailsList)
        {
            try
            {
                

                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    //Delete All Checked Photos From Folder as well as Database/Save into dabase
                    foreach (var list in DetailsList)
                    {
                        if (model.DeletedCheckedList != null)
                        {
                            foreach (var ToDelete in model.DeletedCheckedList)
                            {
                                if (list.PhotoId == ToDelete)
                                {
                                    string _PicturePath = list.HiddenPictureName;

                                    Htl_HotelPhotos obj = new Htl_HotelPhotos();
                                    obj.PhotoId = ToDelete;
                                    obj.Picture = _PicturePath;
                                    obj.Title = list.Title;
                                    obj.Details = list.Details;
                                    obj.PhotoCategoryId = int.Parse(list.CategoryName);
                                    obj.isActive = false;
                                    obj.isDeleted = true;
                                    obj.UpdatedBy = App_Class.AppSession.LogUserID;
                                    obj.UpdatedDate = DateTime.Now;

                                    _PhotoRepo.HotelPhotoDelete(obj);
                                }
                            }
                        }
                    }

                    foreach (var list in DetailsList)
                    {
                        if (model.DeletedCheckedList != null)
                        {
                            foreach (var ToDelete in model.DeletedCheckedList)
                            {
                                if (list.PhotoId != ToDelete)
                                {
                                    //Update database with necessary changes
                                    string _PicturePath = list.HiddenPictureName;
                                    Htl_HotelPhotos obj = new Htl_HotelPhotos();
                                    obj.PhotoId = list.PhotoId;
                                    obj.Picture = _PicturePath;
                                    obj.Title = list.Title == null ? "" : list.Title;
                                    obj.Details = list.Details;
                                    obj.PhotoCategoryId = int.Parse(list.CategoryName);
                                    obj.isActive = true;
                                    obj.isDeleted = false;
                                    obj.UpdatedBy = App_Class.AppSession.LogUserID;
                                    obj.UpdatedDate = DateTime.Now;

                                    _PhotoRepo.HotelPhotoEdit(obj);
                                }
                            }
                        }
                        else
                        {
                            //Update database with necessary changes
                            Htl_HotelPhotos obj = new Htl_HotelPhotos();
                            string _PicturePath = list.HiddenPictureName;
                            obj.PhotoId = list.PhotoId;
                            obj.Picture = _PicturePath;
                            obj.Title = list.Title;
                            obj.Details = list.Details;
                            obj.PhotoCategoryId = int.Parse(list.CategoryName);
                            obj.isActive = true;
                            obj.isDeleted = false;
                            obj.UpdatedBy = App_Class.AppSession.LogUserID;
                            obj.UpdatedDate = DateTime.Now;

                            _PhotoRepo.HotelPhotoEdit(obj);
                        }
                    }

                    var viewModel = new HotelPhotos
                    {
                        HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                        HotelNameList = _HotelInfoRepo.HotelInfoList(),
                        PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    };
                    ViewData["success"] = "Photos Edited Successfully!";

                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                var viewModel1 = new HotelPhotos
                    {
                        HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                        HotelNameList = _HotelInfoRepo.HotelInfoList(),
                        PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                        //formActionName = "Edit",
                        //formControllerName = "HotelPhoto",
                        //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                        //formSubmitBttnName = "Save Changes"
                    };

                ViewData["success"] = ex.Message;
                return View(viewModel1);
            }
        }

        public ActionResult Delete()
        {
            try
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Delete",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Delete"
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                var viewModel = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Delete",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Delete"
                };

                ViewData["success"] = ex.Message;
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(HotelPhotos model)
        {
            var viewModel = new HotelPhotos
            {
                HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                HotelNameList = _HotelInfoRepo.HotelInfoList(),
                PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                //formActionName = "Delete",
                //formControllerName = "HotelPhoto",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Delete"
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                //Delete All Checked Categories Photos From Folder as well as Database
                if (model.DeletedCheckedList != null)
                {
                    foreach (var ToDelete in model.DeletedCheckedList)
                    {
                        _PhotoRepo.HotelPhotoDeleteByPhotoCategoryId(ToDelete, App_Class.AppSession.LogUserID, DateTime.Now);
                    }
                }

                var viewModel1 = new HotelPhotos
                {
                    HotelPhotosList = _PhotoRepo.HotelPhotoList(0, 0),
                    HotelNameList = _HotelInfoRepo.HotelInfoList(),
                    PhotoCategoryList = _PhotoCatRepo.HotelPhotoCategoryList(),

                    //formActionName = "Delete",
                    //formControllerName = "HotelPhoto",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Delete"
                };

                ViewData["success"] = "Photos Deleted Successfully!";
                return View(viewModel1);
            }
        }

        /// <summary>
        /// Get Models
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        //public JsonResult GetHotelPhotoCategory(string id)
        //{
        //    JsonResult result = new JsonResult();
        //    var filteredModels = _PhotoCatRepo.HotelPhtoCategoryByHotelId(int.Parse(id));

        //    result.Data = filteredModels.ToList();
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}
    }  

}
