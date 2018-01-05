using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;
using System.Web.Mvc;
using System.IO;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusMasterRepository
    {
        int SNo = 1;
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _res = new BusMessageModel();
        public IEnumerable<BusMasterModel> List()
        {
            var _res = _ent.Bus_Master.OrderBy(x => x.BusMasterName);
            List<BusMasterModel> model = new List<BusMasterModel>();
            foreach (var items in _res)
            {
                BusMasterModel obj = new BusMasterModel
                {
                    Sno = SNo++,
                    BusMasterId = items.BusMasterId,
                    BusMasterName = items.BusMasterName,
                    ContactAddress=items.ContactAddress,
                    ContactPerson=items.ContactPerson,
                    Mobile=items.Mobile,
                    Phone=items.Phone
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public BusMessageModel Create(BusMasterModel model)
        {
            string _imageName = "";
            _res = UploadFileMaster(model.LogoImage, out _imageName);
            if (_res.MsgNumber > 0)
            {
                return _res;
            }
            if (IsExists(model.BusMasterId, model.BusMasterName) == false)
            {
                TravelPortalEntity.Bus_Master obj = new TravelPortalEntity.Bus_Master
                {
                    BusMasterName = model.BusMasterName,
                    ContactAddress=model.ContactAddress,
                    ContactPerson=model.ContactPerson,
                    CreatedBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(),
                    CreatedDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate(),
                    Mobile=model.Mobile,
                    Phone=model.Phone,
                    LogoUrl = _imageName,
                    BusMasterEmial= model.Email
                };
                _ent.AddToBus_Master(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Category ");
                _res.ErrSource = "DataBase";
                _res.MsgType = 0;
                _res.MsgNumber = 0;
                _res.MsgStatus = true;
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Category ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }

            return _res;
        }
        public BusMessageModel Edit(BusMasterModel model)
        {
            string _imageName = "";
            if (model.LogoImage != null)
            {
                _res = UploadFileMaster(model.LogoImage, out _imageName);
            }
            if (_res.MsgNumber > 0)
            {
                return _res;
            }
            if (IsExists(model.BusMasterId, model.BusMasterName) == false)
            {
                var obj = _ent.Bus_Master.Where(x => x.BusMasterId == model.BusMasterId).FirstOrDefault();
                if (obj != null)
                {
                    obj.BusMasterName = model.BusMasterName;
                    obj.ContactAddress=model.ContactAddress;
                    obj.ContactPerson=model.ContactPerson;
                    obj.UpdateBy = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
                    obj.UpdateDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
                    obj.Mobile = model.Mobile;
                    obj.Phone=model.Phone;
                    if (!string.IsNullOrEmpty(_imageName.ToString()))
                    {
                        obj.LogoUrl = _imageName;
                    }
                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Bus Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.AlreadyExist, "Bus Category ");
                _res.MsgNumber = 1001;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }


            return _res;
        }
        public BusMessageModel Delete(int? Pid)
        {
            if (Pid != null)
            {
                var obj = _ent.Bus_Master.Where(x => x.BusMasterId == Pid).FirstOrDefault();
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Bus Category ");
                    _res.MsgNumber = 0;
                    _res.MsgStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            return _res;
        }
        public BusMasterModel Detail(int? Pid)
        {
            BusMasterModel model = new BusMasterModel();
            if (Pid != null)
            {
                var result = _ent.Bus_Master.Where(x => x.BusMasterId == Pid).FirstOrDefault();
                if (result != null)
                {
                    model.BusMasterId = result.BusMasterId;
                    model.BusMasterName = result.BusMasterName;
                    model.ContactAddress = result.ContactAddress;
                    model.ContactPerson = result.ContactPerson;
                    model.Mobile = result.Mobile;
                    model.Phone = result.Phone;
                    model.LogoUrl = BusGeneralRepository.OperatorLogoUrl + result.LogoUrl;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                    _res.MsgNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Bus Category ");
                _res.MsgNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            model.Message = _res;
            return model;

        }

        public IPagedList<BusMasterModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List().ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
        public bool IsExists(int? Pid, string ProviderCode = null)
        {
            var result = _ent.Bus_Master.Where(x => x.BusMasterName.ToLower() == ProviderCode.ToLower() && x.BusMasterId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public IEnumerable<SelectListItem> ddlMasterList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var result = ent.Bus_Master.OrderBy(o => o.BusMasterName);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "--Select--", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.BusMasterId.ToString(), Value = item.BusMasterName.ToString() });
            }
            return ddlList;
        }
        private string ValidateImage(HttpPostedFileBase file)
        {
            List<string> ValidExtensions = new List<string>();
            ValidExtensions.Add(".PNG");
            ValidExtensions.Add(".JPG");
            ValidExtensions.Add(".GIF");
            foreach (string item in ValidExtensions)
            {
                var x = file.FileName.ToLower().EndsWith(item.ToLower());
                if (x == true)
                {
                    return item;
                }
            }
            return "";
        }

        private BusMessageModel UploadFileMaster(HttpPostedFileBase UploadedFile, out string ImageName)
        {
            string ImageFileName = "";
            if (UploadedFile != null)
            {
                string Extensions = ValidateImage(UploadedFile);
                if (Extensions != "")
                {
                    try
                    {
                        var fname = UploadedFile.FileName;
                        string UploadDirPath = BusGeneralRepository.OperatorLogoPath;
                        if (UploadedFile.ContentLength > 0)
                        {
                            ImageFileName = BusGeneralRepository.RandomProductImageName + Extensions;
                            var path = Path.Combine(UploadDirPath, ImageFileName);
                            UploadedFile.SaveAs(path);
                        }
                        else
                        {
                            ImageFileName = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        _res.ActionMessage = ex.Message;
                        _res.ErrSource = "DataBase";
                        _res.MsgType = 3;
                        _res.MsgNumber = 1001;
                        _res.MsgStatus = true;
                    }
                }
                else
                {
                    _res.ActionMessage = "Invalid File Format, valid format are ( PNG , JPG , GIF). ";
                    _res.ErrSource = "DataBase";
                    _res.MsgType = 3;
                    _res.MsgNumber = 1001;
                    _res.MsgStatus = true;
                }
            }
            ImageName = ImageFileName;
            return _res;
        }
       
        
    }
}