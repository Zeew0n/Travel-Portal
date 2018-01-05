using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class HotelInfoController : Controller
    {
        
        HotelInfoRepository _HotelInfoRepo = new HotelInfoRepository();
        HotelTypeInfoRepository _HotelTypeInfoRepo = new HotelTypeInfoRepository();
        HotelRoomTypeRepository _RoomTypeRepo = new HotelRoomTypeRepository();
        HotelFacilityRepository _FacilityRepo = new HotelFacilityRepository();
        HotelCityInfoRepository _CityInfoRepo = new HotelCityInfoRepository();
        HotelAdditionalChargeRepository _AdditionalChargeRepo = new HotelAdditionalChargeRepository();
        HotelCountryRepository _CountryRepo = new HotelCountryRepository();
        HotelDesignationRepository _DesignationRepo = new HotelDesignationRepository();
        HotelContactInfoRepository _ContactRepo = new HotelContactInfoRepository();
        HotelCityInfoAssociationRepository _CityInfoAssociation = new HotelCityInfoAssociationRepository();
        
        //
        // GET: /HotelInfo/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            return View(_HotelInfoRepo.HotelInfoList());
        }

        public ActionResult Delete(int id)
        {
            _HotelInfoRepo.DeleteAdditionalCharge(id);
            _HotelInfoRepo.DeleteCityList(id);
            _HotelInfoRepo.DeleteFacilityList(id);
            _HotelInfoRepo.DeleteRoomTypeList(id);
            _HotelInfoRepo.HotelInfoDelete(id);
           

            return View("List", _HotelInfoRepo.HotelInfoList());
        }

        public ActionResult Create()
        {
            var viewModel = new HotelInfos
            {
                HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                HotelFacityList = _FacilityRepo.HotelFacilityList(),
          
                HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                CountryList = _HotelInfoRepo.GetCountryList(),
                DesignationList = _DesignationRepo.HotelDesignationList(),
               // Status=Hotels.Helpers.ActiveStatus.GetStatus(""),

                    //formActionName = "Create",
                    //formControllerName = "HotelInfo",
                    //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                    //formSubmitBttnName = "Save",
            };
            return View(viewModel);
        }
    
         [HttpPost]
        public ActionResult Create(HotelInfos model, FormCollection frmColl)
        {
           

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                bool Status = model.StatusId == 0 ? true : false;

                string strHotelRoomTypeList = string.Empty, strHotelFacityList = string.Empty, strHotelCityInfoList = string.Empty, strHotelAdditionalChargeList = string.Empty;
                string sfileName = string.Empty;

                var httpFileCollection = Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    var httpPostedFile = httpFileCollection[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        string FileExtension = Path.GetExtension(httpPostedFile.FileName);
                        int FileSize = httpPostedFile.ContentLength;

                        if (FileSize <= ATLTravelPortal.Helpers.ApplicationSettings.GetMaxPhotoSizeToUpload())
                        {
                            switch (httpPostedFile.ContentType)
                            {
                                case "image/pjpeg":
                                case "image/jpeg":
                                case "image/gif":
                                case "image/png":
                                    sfileName = Guid.NewGuid().ToString() + FileExtension;
                                    string sFilePath = Server.MapPath("/HotelUploads/Logo/");

                                    if (!Directory.Exists(Server.MapPath("~/HotelUploads/")))
                                    {
                                        Directory.CreateDirectory(Server.MapPath("~/HotelUploads/"));
                                    }
                                    if (!Directory.Exists(Server.MapPath("~/HotelUploads/Logo/")))
                                    {
                                        Directory.CreateDirectory(Server.MapPath("~/HotelUploads/Logo/"));
                                    }

                                    string location = sFilePath + "/" + sfileName;
                                    httpPostedFile.SaveAs(location);
                                    break;
                                default:
                                    return Content("Invalid Image Type");
                            }
                        }
                    }
                }

                foreach (string item in frmColl)
                {
                    if (item.Contains("chkbox"))
                    {
                        if (item.Contains("roomtype"))
                        {
                            string[] arrayCheckBox = item.Split('_');

                            if (strHotelRoomTypeList == "")
                                strHotelRoomTypeList = arrayCheckBox[1].ToString();
                            else
                                strHotelRoomTypeList = strHotelRoomTypeList + "," + arrayCheckBox[1].ToString();
                        }
                        else if (item.Contains("facility"))
                        {
                            string[] arrayCheckBox = item.Split('_');
                            if (strHotelFacityList == "")
                                strHotelFacityList = arrayCheckBox[1].ToString();
                            else
                                strHotelFacityList = strHotelFacityList + "," + arrayCheckBox[1].ToString();
                        }
                        else if (item.Contains("city"))
                        {
                            string[] arrayCheckBox = item.Split('_');
                            if (strHotelCityInfoList == "")
                                strHotelCityInfoList = arrayCheckBox[1].ToString();
                            else
                                strHotelCityInfoList = strHotelCityInfoList + "," + arrayCheckBox[1].ToString();
                        }
                        else if (item.Contains("additionalcharge"))
                        {
                            string[] arrayCheckBox = item.Split('_');
                            if (strHotelAdditionalChargeList == "")
                                strHotelAdditionalChargeList = arrayCheckBox[1].ToString();
                            else
                                strHotelAdditionalChargeList = strHotelAdditionalChargeList + "," + arrayCheckBox[1].ToString();
                        }
                    }
                }


              
       
                        Htl_HotelInfos obj = new Htl_HotelInfos();
                        var ts = (TravelSession)Session["TravelSessionInfo"];
                        obj.HotelName = model.HotelName;
                        obj.CountryId = model.HotelInfo.CountryId;
                        //obj.CountryList = model.CountryList;



                        //obj.HotelType = model.HotelType;
                        //obj.HotelTypeList = model.HotelTypeList;
                
                       //obj.HotelTypeList = _HotelTypeInfoRepo.HotelTypeInfoList();

                        obj.HotelCode = model.HotelCode;
                        obj.OptionalEmail = model.OptionalEmail;
                        obj.Address = model.Address;
                        obj.Web = model.Web;
                        obj.Phone = model.Phone;
                        obj.Email = model.Email;
                        obj.Details = model.Details;
                        obj.OptionalPhone = model.OptionalPhone;
                        obj.isActive = model.isActive;
                        obj.isDeleted = false;
                        obj.Logo = model.Logo;
                        obj.CreatedBy = App_Class.AppSession.LogUserID;
                        obj.CreatedDate = DateTime.Now;

                       long Hotelid= _HotelInfoRepo.HotelInfoAdd(obj);


                        Htl_HotelContactInfos objs = new Htl_HotelContactInfos();
                        objs.HotelId = Hotelid;
                        objs.OwnerFullName = model.HotelContactInfo.OwnerFullName;
                        objs.OwnerDesignationId = model.HotelContactInfo.OwnerDesignationId;
                       
                        objs.OwnerEmail = model.HotelContactInfo.OwnerEmail;
                        objs.OwnerMobile = model.HotelContactInfo.OwnerMobile;
                        objs.OwnerLandline = model.HotelContactInfo.OwnerLandline;
                        objs.OwnerTempAddress = model.HotelContactInfo.OwnerTempAddress;
                        objs.OwnerPermAddress = model.HotelContactInfo.OwnerPermAddress;
                        objs.OwnerDOB = model.HotelContactInfo.OwnerDOB;
                        objs.ContactFullName = model.HotelContactInfo.ContactFullName;
                        objs.ContactEmail = model.HotelContactInfo.ContactEmail;
                        objs.ContactMobile = model.HotelContactInfo.ContactMobile;
                        objs.ContactLandline = model.HotelContactInfo.ContactLandline;
                        objs.ContactTempAddress = model.HotelContactInfo.ContactTempAddress;
                        objs.ContactPermAddress = model.HotelContactInfo.ContactPermAddress;
                        objs.ContactDOB = model.HotelContactInfo.ContactDOB;
                        objs.ContactDesignationId = model.HotelContactInfo.ContactDesignationId;
                        objs.isDeleted = false;
                        objs.CreatedBy = App_Class.AppSession.LogUserID;
                        objs.CreatedDate = DateTime.Now;
                        _HotelInfoRepo.HotelContactInfoAdd (objs);


                        Htl_RoomTypeAssociation c = new Htl_RoomTypeAssociation();
                        c.HotelId = Hotelid;
                        string[] sring = strHotelRoomTypeList.Split(',');
                        foreach (string strs in sring)
                            if (string.IsNullOrEmpty(strs))
                            {
                                obj.CountryId = model.HotelInfo.CountryId;
                                //obj.CountryList = model.CountryList;  
                            }

                            else
                            {
                                c.HotelId = Hotelid;
                                c.HotelRoomTypeId = Convert.ToInt32(strs);
                                _HotelInfoRepo.HotelRoomTypeAssociationAdd(c);
                            }
                        c.HotelId = Hotelid;



                         HotelCityInfoAssociation p = new HotelCityInfoAssociation();
                         p.HotelId = Hotelid;
                      
                       
                        string[] str = strHotelCityInfoList.Split(',');
                        foreach (string strs in str)
                            if (string.IsNullOrEmpty(strs))
                            {
                                obj.CountryId = model.HotelInfo.CountryId;
                                //obj.CountryList = model.CountryList;
                               
                            }

                            else
                            {
                                p.HotelId = Hotelid;
                                p.CityId = Convert.ToInt32(strs);
                                _HotelInfoRepo.HotelCityInfoAssociationAdd(p);
                            }
                            p.HotelId =Hotelid ;

                            Htl_HotelAdditionalChargeAssociation a = new Htl_HotelAdditionalChargeAssociation();
                            a.HotelId = Hotelid;
                            string[] strg = strHotelAdditionalChargeList.Split(',');
                            foreach (string strs in strg)
                                if (string.IsNullOrEmpty(strs))
                                {
                                    obj.CountryId = model.HotelInfo.CountryId;
                                    //obj.CountryList = model.CountryList;
                                   
                                }

                                else
                                {
                                    a.HotelId = Hotelid;
                                    a.ChargeId = Convert.ToInt32(strs);
                                    _HotelInfoRepo.HotelAdditionalChargeAssociationAdd(a);
                                }

                            Htl_HotelFacilityAssociation b = new Htl_HotelFacilityAssociation();
                            b.HotelId = Hotelid;
                            string[] strng = strHotelFacityList.Split(',');
                            foreach (string strs in strng)
                                if (string.IsNullOrEmpty(strs))
                                {
                                    obj.CountryId = model.HotelInfo.CountryId;
                                    //obj.CountryList = model.CountryList;
                                   
                                }

                                else
                                {
                                    b.HotelId = Hotelid;
                                    b.FacilityId  = Convert.ToInt32(strs);
                                    _HotelInfoRepo.HotelFacilityAssociationAdd(b);
                                }

                            //Htl_RoomTypeAssociation c = new Htl_RoomTypeAssociation();
                            //c.HotelId = Hotelid;
                            //string[] sring = strHotelRoomTypeList.Split(',');
                            //foreach (string strs in sring)
                            //    if (string.IsNullOrEmpty(strs))
                            //    {
                            //        return View("Create");
                            //    }

                            //    else
                            //    {
                            //        c.HotelId = Hotelid;
                            //        c.HotelRoomTypeId = Convert.ToInt32(strs);
                            //        _HotelInfoRepo.HotelRoomTypeAssociationAdd(c);
                            //    }
                            //c.HotelId = Hotelid;
                       return RedirectToAction("List");
                      
                    }
                }

   


                
        public ActionResult Edit(int id)
        {
            HotelInfos recordToEdit;

            recordToEdit = _HotelInfoRepo.HotelInfoById(id);
            
            var viewModel = new HotelInfos
            {
                
                //HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                HotelFacityList = _FacilityRepo.HotelFacilityList(),
                HotelFacilityAssociationList=_HotelInfoRepo.HotelFacilityList(id),
                HotelInfo=_HotelInfoRepo.HotelInfoLists(id),
                HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
               HotelCityInfoList =_CityInfoRepo.HotelCityInfoList(),
                //HotelCityInfoAssociationSelectedCheckBoxList = _CityInfoAssociation.HotelCityInfoAssociationByHotelId(id),
                CountryList = _HotelInfoRepo.GetCountryList (),
               HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                DesignationList = _DesignationRepo.HotelDesignationList(),
             };
            return View("Edit", viewModel);
        }
           

         
         
        [HttpPost]
        public ActionResult Edit(int id, HotelInfos model, FormCollection frmColl)
        {
           
           

                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    bool Status = model.StatusId == 0 ? true : false;

                    string strHotelRoomTypeList = string.Empty, strHotelFacityList = string.Empty, strHotelCityInfoList = string.Empty, strHotelAdditionalChargeList = string.Empty;
                    string sfileName = string.Empty;

                    var httpFileCollection = Request.Files;
                    for (int i = 0; i < httpFileCollection.Count; i++)
                    {
                        var httpPostedFile = httpFileCollection[i];
                        if (httpPostedFile.ContentLength > 0)
                        {
                            string FileExtension = Path.GetExtension(httpPostedFile.FileName);
                            int FileSize = httpPostedFile.ContentLength;

                            if (FileSize <= ATLTravelPortal.Helpers.ApplicationSettings.GetMaxPhotoSizeToUpload())
                            {
                                switch (httpPostedFile.ContentType)
                                {
                                    case "image/pjpeg":
                                    case "image/jpeg":
                                    case "image/gif":
                                    case "image/png":
                                        sfileName = Guid.NewGuid().ToString() + FileExtension;
                                        string sFilePath = Server.MapPath("/HotelUploads/Logo/");

                                        if (!Directory.Exists(Server.MapPath("~/HotelUploads/")))
                                        {
                                            Directory.CreateDirectory(Server.MapPath("~/HotelUploads/"));
                                        }
                                        if (!Directory.Exists(Server.MapPath("~/HotelUploads/Logo/")))
                                        {
                                            Directory.CreateDirectory(Server.MapPath("~/HotelUploads/Logo/"));
                                        }

                                        string location = sFilePath + "/" + sfileName;
                                        httpPostedFile.SaveAs(location);
                                        break;
                                    default:
                                        return Content("Invalid Image Type");
                                }
                            }
                        }
                    }

                    foreach (string item in frmColl)
                    {
                        if (item.Contains("chkbox"))
                        {
                            if (item.Contains("roomtype"))
                            {
                                string[] arrayCheckBox = item.Split('_');

                                if (strHotelRoomTypeList == "")
                                    strHotelRoomTypeList = arrayCheckBox[1].ToString();
                                else
                                    strHotelRoomTypeList = strHotelRoomTypeList + "," + arrayCheckBox[1].ToString();
                            }
                            else if (item.Contains("facility"))
                            {
                                string[] arrayCheckBox = item.Split('_');
                                if (strHotelFacityList == "")
                                    strHotelFacityList = arrayCheckBox[1].ToString();
                                else
                                    strHotelFacityList = strHotelFacityList + "," + arrayCheckBox[1].ToString();
                            }
                            else if (item.Contains("city"))
                            {
                                string[] arrayCheckBox = item.Split('_');
                                if (strHotelCityInfoList == "")
                                    strHotelCityInfoList = arrayCheckBox[1].ToString();
                                else
                                    strHotelCityInfoList = strHotelCityInfoList + "," + arrayCheckBox[1].ToString();
                            }
                            else if (item.Contains("additionalcharge"))
                            {
                                string[] arrayCheckBox = item.Split('_');
                                if (strHotelAdditionalChargeList == "")
                                    strHotelAdditionalChargeList = arrayCheckBox[1].ToString();
                                else
                                    strHotelAdditionalChargeList = strHotelAdditionalChargeList + "," + arrayCheckBox[1].ToString();
                            }
                        }
                    }
                     


                    Htl_HotelInfos obj = new Htl_HotelInfos();
                    var ts = (TravelSession)Session["TravelSessionInfo"];
                    obj.HotelId = id;
                    obj.HotelName = model.HotelInfo.HotelName;
                    obj.CountryId = model.HotelInfo.CountryId;
                    //obj.CountryList = model.HotelCountryList;
                    obj.HotelCode = model.HotelInfo.HotelCode;
                    obj.OptionalEmail = model.HotelInfo.OptionalEmail;
                    obj.Address = model.HotelInfo.Address;
                    obj.Web = model.HotelInfo.Web;
                    obj.Phone = model.HotelInfo.Phone;
                    obj.Email = model.HotelInfo.Email;
                    obj.Details = model.HotelInfo.Details;
                    obj.OptionalPhone = model.HotelInfo.OptionalPhone;
                    obj.isActive = model.HotelInfo.isActive;
                    obj.isDeleted = false;
                    obj.Logo = model.HotelInfo.Logo;
                    //obj.UpdatedBy  = ts.AppUserId;
                    obj.UpdatedDate  = DateTime.Now;

                    long Hotelid = _HotelInfoRepo.HotelInfoEdit(obj);

                    Htl_HotelContactInfos objs = new Htl_HotelContactInfos();
                        objs.HotelId = Hotelid;
                        obj.CountryId = model.HotelInfo.CountryId;
                        objs.OwnerFullName = model.HotelContactInfo.OwnerFullName;
                        objs.OwnerDesignationId = model.HotelContactInfo.OwnerDesignationId;
                        objs.OwnerEmail = model.HotelContactInfo.OwnerEmail;
                        objs.OwnerMobile = model.HotelContactInfo.OwnerMobile;
                        objs.OwnerLandline = model.HotelContactInfo.OwnerLandline;
                        objs.OwnerTempAddress = model.HotelContactInfo.OwnerTempAddress;
                        objs.OwnerPermAddress = model.HotelContactInfo.OwnerPermAddress;
                        objs.OwnerDOB = model.HotelContactInfo.OwnerDOB;
                        objs.ContactFullName = model.HotelContactInfo.ContactFullName;
                        objs.ContactEmail = model.HotelContactInfo.ContactEmail;
                        objs.ContactMobile = model.HotelContactInfo.ContactMobile;
                        objs.ContactLandline = model.HotelContactInfo.ContactLandline;
                        objs.ContactTempAddress = model.HotelContactInfo.ContactTempAddress;
                        objs.ContactPermAddress = model.HotelContactInfo.ContactPermAddress;
                        objs.ContactDOB = model.HotelContactInfo.ContactDOB;
                        objs.ContactDesignationId = model.HotelContactInfo.ContactDesignationId;
                        objs.isDeleted = false;
                        //obj.UpdatedBy = ts.AppUserId;
                        obj.UpdatedDate = DateTime.Now;
                        _HotelInfoRepo.HotelContactInfoEdit (objs);




                        HotelCityInfoAssociation p = new HotelCityInfoAssociation();
                        p.HotelId = Hotelid;
                        _HotelInfoRepo.DeleteCityList(id);
                       HotelInfos recordToEdit;
                       recordToEdit = _HotelInfoRepo.HotelInfoById(id);
                        string[] str = strHotelCityInfoList.Split(',');
                        foreach (string strs in str)
                            if (string.IsNullOrEmpty(strs))
                          
                
                            {

                                var viewModel = new HotelInfos
                                {
                                    HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                                    HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                                    HotelFacityList = _FacilityRepo.HotelFacilityList(),
                                    HotelFacilityAssociationList = _HotelInfoRepo.HotelFacilityList(id),
                                    HotelInfo = _HotelInfoRepo.HotelInfoLists(id),
                                    HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                                    HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
                                    HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                                    CountryList = _HotelInfoRepo.GetCountryList(),
                                    HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                                    HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                                    DesignationList = _DesignationRepo.HotelDesignationList(),
                                    CountryId = model.HotelInfo.CountryId,
                                   // HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                                    };
                                //return RedirectToAction ("Edit", viewModel);
                            }

                            else
                        {
                            p.HotelId = Hotelid;
                            p.CityId = Convert.ToInt32(strs);
                           
                             _HotelInfoRepo.HotelCityInfoAssociationEdit(p);
                        }
                            
                  


                      
                        Htl_HotelAdditionalChargeAssociation q = new Htl_HotelAdditionalChargeAssociation();
                        p.HotelId = Hotelid;
                        _HotelInfoRepo.DeleteAdditionalCharge(id);
                        HotelInfos recordTobeEdit;
                     recordTobeEdit = _HotelInfoRepo.HotelInfoById(id);
                        string[] strg = strHotelAdditionalChargeList.Split(',');
                        foreach (string strs in strg)
                            if (string.IsNullOrEmpty(strs))
                            {
                                var viewModel = new HotelInfos
                                {
                                    HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                                    HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                                    HotelFacityList = _FacilityRepo.HotelFacilityList(),
                                    HotelFacilityAssociationList = _HotelInfoRepo.HotelFacilityList(id),
                                    HotelInfo = _HotelInfoRepo.HotelInfoLists(id),
                                    HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                                    HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
                                    HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                                    CountryList = _HotelInfoRepo.GetCountryList(),
                                    HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                                    HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                                    DesignationList = _DesignationRepo.HotelDesignationList(),
                                    CountryId = model.HotelInfo.CountryId,
                                    // HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                                };
                                //return RedirectToAction("Edit", viewModel);
                            }

                            else
                            {
                                q.HotelId = Hotelid;
                                q.ChargeId  = Convert.ToInt32(strs);
                                _HotelInfoRepo.HotelAdditionalChargeAssociationEdit(q);
                            }

                        Htl_HotelFacilityAssociation r = new Htl_HotelFacilityAssociation();
                        p.HotelId = Hotelid;
                        _HotelInfoRepo.DeleteFacilityList(id);
                       HotelInfos recordToEdited;
                        recordToEdited = _HotelInfoRepo.HotelInfoById(id);
                        string[] strig = strHotelFacityList.Split(',');
                        foreach (string strs in strig)
                            if (string.IsNullOrEmpty(strs))
                            {
                                var viewModel = new HotelInfos
                                {
                                    HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                                    HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                                    HotelFacityList = _FacilityRepo.HotelFacilityList(),
                                    HotelFacilityAssociationList = _HotelInfoRepo.HotelFacilityList(id),
                                    HotelInfo = _HotelInfoRepo.HotelInfoLists(id),
                                    HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                                    HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
                                    HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                                    CountryList = _HotelInfoRepo.GetCountryList(),
                                    HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                                    HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                                    DesignationList = _DesignationRepo.HotelDesignationList(),
                                    CountryId = model.HotelInfo.CountryId,
                                    // HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                                };
                                //return RedirectToAction("Edit", viewModel);
                            }

                            else 
                            {
                                r.HotelId = Hotelid;
                               r.FacilityId  = Convert.ToInt32(strs);
                                _HotelInfoRepo.HotelFacilityAssociationEdit (r);
                            }

                        Htl_RoomTypeAssociation s = new Htl_RoomTypeAssociation();
                        p.HotelId = Hotelid;
                        _HotelInfoRepo.DeleteRoomTypeList(id);
                         HotelInfos recordToEdits;
                        recordToEdits = _HotelInfoRepo.HotelInfoById(id);
                        string[] strng = strHotelRoomTypeList.Split(',');
                        foreach (string strs in strng)
                            if (string.IsNullOrEmpty(strs))
                            {
                                var viewModel = new HotelInfos
                                {
                                    HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                                    HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                                    HotelFacityList = _FacilityRepo.HotelFacilityList(),
                                    HotelFacilityAssociationList = _HotelInfoRepo.HotelFacilityList(id),
                                    HotelInfo = _HotelInfoRepo.HotelInfoLists(id),
                                    HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                                    HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
                                    HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                                    CountryList = _HotelInfoRepo.GetCountryList(),
                                    HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                                    HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                                    DesignationList = _DesignationRepo.HotelDesignationList(),
                                    CountryId = model.HotelInfo.CountryId,
                                    // HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                                };
                                //return RedirectToAction("Edit", viewModel);
                            }

                            else
                            {
                                s.HotelId = Hotelid;
                                s.HotelRoomTypeId = Convert.ToInt32(strs);
                                _HotelInfoRepo.HotelRoomTypeAssociationEdit (s);
                            }

                        
                    ViewData["success"] = "Record successfully edited.";

                    /// return to view after success
                    
                   /// recordToEdit = _HotelInfoRepo.HotelInfoById(id);

                    var viewModel1 = new HotelInfos
                    {
                        HotelRoomTypeList = _RoomTypeRepo.HotelRoomTypeList(),
                        HotelRoomTypeAssociationList = _HotelInfoRepo.HotelRoomTypeList(id),
                        HotelFacityList = _FacilityRepo.HotelFacilityList(),
                        HotelFacilityAssociationList = _HotelInfoRepo.HotelFacilityList(id),
                        HotelInfo = _HotelInfoRepo.HotelInfoLists(id),
                        HotelContactInfo = _ContactRepo.HotelContactInfoHotelId(id),
                        HotelCityInfo = _HotelInfoRepo.HotelCityList(id),
                        HotelAdditionalChargeList = _AdditionalChargeRepo.HotelAdditionalChargeList(),
                        HotelAdditionalChargeAssociationList = _HotelInfoRepo.HotelAdditionalChargeList(id),
                        DesignationList = _DesignationRepo.HotelDesignationList(),
                        CountryId = model.CountryId,
                        HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),
                        CountryList = _HotelInfoRepo.GetCountryList(),
                        // HotelTypeList = _HotelInfoRepo.GetHotelTypeList(),
                    };
                    ViewData["success"] = "Record successfully edited.";
                    return View("Edit", viewModel1);
                   
                }              
            }            
     


        public ActionResult Detail(int id)
        {
            return View(_HotelInfoRepo.HotelInfoById(id));
        }

        public ActionResult PopupAdditionalCharge()
        {
            var viewModel = new HotelAdditionalCharge
            {               
                //formActionName = "PopupAdditionalCharge",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save",
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PopupAdditionalCharge(HotelAdditionalCharge model, string returnUrl)
        {
            var viewModel = new HotelAdditionalCharge
            {
                //formActionName = "PopupAdditionalCharge",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save",

            };
            if (!ModelState.IsValid)
            {               
               return View(viewModel);
            }
            else
            {
                //Htl_HotelAdditionalCharge obj = new Htl_HotelAdditionalCharge();

                //obj.ChargeName = model.ChargeName;
                //obj.Detail = model.Detail;
                //obj.Rate = model.Rate;
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _AdditionalChargeRepo.HotelAdditionalChargeAdd(model);

                ViewData["success"] = "Record successfully added.";
               
                 return RedirectToAction ("Create");
            }
        }


        public ActionResult PopupCityInfo()
        {
            var viewModel = new HotelCityInfos
            {
                HotelCountryList = _CountryRepo.HotelCountryList(),

                //formActionName = "PopupCityInfo",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save",
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PopupCityInfo(HotelCityInfos model)
        {
            var viewModel = new HotelCityInfos
            {
                HotelCountryList = _CountryRepo.HotelCountryList(),
                //formActionName = "PopupCityInfo",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save",
            };

            if (!ModelState.IsValid)
            { 
                return View(viewModel);
            }
            else
            {
                //Htl_HotelCityInfos obj = new Htl_HotelCityInfos();
                //obj.CityName = model.CityName;
                //obj.Details = model.Details;
                //obj.CountryId = model.CountryId;
                //obj.isActive = model.isActive;
                //obj.isDeleted = false;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _CityInfoRepo.HotelCityInfoAdd(model);

                ViewData["success"] = "Record successfully added.";

                return RedirectToAction("Create");
            }
        }


        public ActionResult PopupHotelRoomType()
        {
            var viewModel = new HotelRoomTypes
            {
                //formActionName = "PopupHotelRoomType",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save"
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PopupHotelRoomType(HotelRoomTypes model)
        {
            var viewModel = new HotelRoomTypes
            {
                //formActionName = "PopupHotelRoomType",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save"
            };
            if (!ModelState.IsValid)
            {               
                return View(viewModel);
            }
            else
            {
                //Htl_HotelRoomTypes obj = new Htl_HotelRoomTypes();
                //obj.TypeName = model.TypeName;
                //obj.Details = model.Details;
                //obj.RoomCapacity = model.RoomCapacity;
                //obj.isActive = model.isActive;
                //obj.isDeleted = false;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _RoomTypeRepo.HotelRoomTypeAdd(model);

                ViewData["success"] = "Record successfully added.";
                return RedirectToAction("Create");
            }
        }


        public ActionResult PopupHotelFacility()
        {
            var viewModel = new HotelFacilities
            {
                //formActionName = "PopupHotelFacility",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save"
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PopupHotelFacility(HotelFacilities model)
        {
            var viewModel = new HotelFacilities
            {
                //formActionName = "HotelFacility",
                //formControllerName = "HotelInfo",
                //formOnSubmitAction = "return SaveConfirm(this,\'C\')",
                //formSubmitBttnName = "Save",
            };
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                //Htl_HotelFacilities obj = new Htl_HotelFacilities();

                //obj.FacilityName = model.FacilityName;
                //obj.Details = model.Details;
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _FacilityRepo.HotelFacilityAdd(model);

                ViewData["success"] = "Record successfully added.";
                return RedirectToAction("Create");
            }
        }
    }
}
