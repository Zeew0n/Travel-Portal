using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class HotelInfoModels
    {
        [Required(ErrorMessage = "Hotel Name Required")]
        [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
        [DisplayName("Name")]
        public string HotelName { get; set; }



        [Required(ErrorMessage = "Hotel Code Required")]
        [StringLength(10, ErrorMessage = "Must be under 10 Characters")]
        [DisplayName("Code")]
        public string HotelCode { get; set; }

        [Required(ErrorMessage = "Please Select HotelType")]
        [DisplayName("Type")]
        public Int32 HotelType { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        [DisplayName("City")]
        public int City { get; set; }

        [Required(ErrorMessage = "Hotel Details Required")]
        [StringLength(10, ErrorMessage = "Must be under 10 Characters")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Active")]
        public bool Active { get; set; }

        public string id { get; set; }
        public IEnumerable<HotelInfoModels> HotelInfo { get; set; }
        public Int64 HotelId { get; set; }
        public IEnumerable<SelectListItem> HotelTypeList { get; set; }
        public IEnumerable<SelectListItem> HotelCityList { get; set; }

        public string HotelType_Name { get; set; }
        public string HotelCity_Name { get; set; }

        //public string formActionName { get; set; }
        //public string formControllerName { get; set; }
        //public string formOnSubmitAction { get; set; }
        //public string formSubmitBttnName { get; set; }


    }

    public class HotelTypeModels
    {
        [Required(ErrorMessage = "Hotel Type Name Required")]
        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [DisplayName("Hotel Type Name")]
        public string HotelType { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [DisplayName("Is Active")]
        public bool Active { get; set; }

        public string id { get; set; }
        public IEnumerable<HotelTypeModels> HotelTypeList { get; set; }

        //public string formActionName { get; set; }
        //public string formControllerName { get; set; }
        //public string formOnSubmitAction { get; set; }
        //public string formSubmitBttnName { get; set; }

    }

    public class HotelCityInfoModels
    {
        [Required(ErrorMessage = "City Name Required")]
        [StringLength(500, ErrorMessage = "Must be under 500 characters")]
        [DisplayName("City Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int Country { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(500, ErrorMessage = "Must be under 500 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [DisplayName("Active")]
        public bool Active { get; set; }

        public string id { get; set; }
        public string ContryName_Name { get; set; }
        public IEnumerable<HotelCityInfoModels> HotelCityInformationList { get; set; }
        public IEnumerable<SelectListItem> HotelCountryList { get; set; }

        //public string formActionName { get; set; }
        //public string formControllerName { get; set; }
        //public string formOnSubmitAction { get; set; }
        //public string formSubmitBttnName { get; set; }
    }

    public class HotelRoomTypeModels
    {
        [Required(ErrorMessage = "Room Type Required")]
        [StringLength(200, ErrorMessage = "Must be under 200 characters")]
        [DisplayName("Hotel Room Type")]
        public string HotelRoomType { get; set; }


        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(500, ErrorMessage = "Must be under 500 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please Select Hotel")]
        [DisplayName("Hotel")]
        public long Hotel { get; set; }


        [Required(ErrorMessage = "Hotel Room capacity is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "*")]
        public int RoomCapacity { get; set; }

        public string HotelName { get; set; }
        public string id { get; set; }

        public IEnumerable<SelectListItem> hotelNameList { get; set; }
        public IEnumerable<HotelRoomTypeModels> HotelRoomTypeList { get; set; }

        //public string formActionName { get; set; }
        //public string formControllerName { get; set; }
        //public string formOnSubmitAction { get; set; }
        //public string formSubmitBttnName { get; set; }
    }

    public class HotelRoomTypeAssociationModels
    {
        [Required(ErrorMessage = "Please Select Hotel Name")]
        [DisplayName("Hotel Name")]
        public int HotelName { get; set; }

        [Required(ErrorMessage = "Please Select Hotel Room Type")]
        [DisplayName("Hotel Room Type")]
        public int HotelRoomType { get; set; }

        public IEnumerable<SelectListItem> hotelnamelist { get; set; }
        public IEnumerable<SelectListItem> hotelroomtypelist { get; set; }


        public string id { get; set; }
        public string HotelName_Name { get; set; }
        public string HotelRoomType_Name { get; set; }

        public IEnumerable<HotelRoomTypeAssociationModels> HotelRoomTypeAssociation { get; set; }

        //public string formActionName { get; set; }
        //public string formControllerName { get; set; }
        //public string formOnSubmitAction { get; set; }
        //public string formSubmitBttnName { get; set; }
    }

    public class HotelFacilityAssociationModels
    {
        public int HotelId { get; set; }
        public int HotelFacilityId { get; set; }
        public string HotelFacilityName { get; set; }

        public IEnumerable<HotelFacilityAssociationModels> HotelFacilityAssociation { get; set; }

        //    public string formActionName { get; set; }
        //    public string formControllerName { get; set; }
        //    public string formOnSubmitAction { get; set; }
        //    public string formSubmitBttnName { get; set; }
        //}

        public class HotelCityInfoAssociationModels
        {
            public int HotelId { get; set; }
            public int CityId { get; set; }
            public string HotelCityInfoName { get; set; }

            public string HotelName { get; set; }
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }

            public IEnumerable<HotelCityInfoAssociationModels> HotelCityInfoAssociationList { get; set; }

            public IEnumerable<SelectListItem> HotelNameList { get; set; }
            public IEnumerable<SelectListItem> HotelCityInfoList { get; set; }

            [HiddenInput]
            public int HiddenCityId { get; set; }
            [HiddenInput]
            public Int64 HiddenHotelId { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }
        }

        public class HotelAdditionalChargeAssociationModels
        {
            public int HotelId { get; set; }
            public int ChargeId { get; set; }
            public string ChargeName { get; set; }
        }

        public class HotelInventoryModels
        {
            [Required(ErrorMessage = "Please Select Hotel Name")]
            [DisplayName("Hotel Name")]
            public int HotelName { get; set; }

            [Required(ErrorMessage = "Please Select Room Type")]
            [DisplayName("Room Type")]
            public int Roomtype { get; set; }

            [Required(ErrorMessage = "Please Select No. of Vacant Room")]
            [DisplayName("No. of Room")]
            public int NoofVacantRoom { get; set; }

            [Required(ErrorMessage = "Rate Required")]
            [RegularExpression(@"\-?\d+(\.\d+)?", ErrorMessage = "*")]
            //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "*")]
            [DisplayName("Rate")]
            public string Rate { get; set; }


            [Required(ErrorMessage = "Commission Required")]
            [RegularExpression(@"\-?\d+(\.\d+)?", ErrorMessage = "*")]
            //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "*")]
            [DisplayName("Commission")]
            public string Commission { get; set; }

            [Required(ErrorMessage = "Feature Required")]
            [DisplayName("Feature")]
            public string Feature { get; set; }

            [DisplayName("Active")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> hotelNameList { get; set; }
            public IEnumerable<SelectListItem> roomTypeList { get; set; }
            //public IEnumerable<SelectListItem> noofVacantRoomlist { get; set; }

            public string id { get; set; }
            public string Hotel_Name { get; set; }
            public string Room_Type { get; set; }
            public string NoofVacant_Room { get; set; }
            public IEnumerable<HotelInventoryModels> hotelInventoryList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelStatusModels
        {
            [Required(ErrorMessage = "Status Name Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 characters")]
            [DisplayName("Status Name")]
            public string StatusName { get; set; }

            [Required(ErrorMessage = "Details Required")]
            [StringLength(255, ErrorMessage = "Must be under 255 characters")]
            [DisplayName("Details")]
            public string Details { get; set; }

            [DisplayName("Active")]
            public bool Active { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string id { get; set; }
            public IEnumerable<HotelStatusModels> HotelStatus { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelCountryModels
        {
            [Required(ErrorMessage = "Countrky Name is Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Country Name")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "Country Code is Required")]
            [StringLength(3, ErrorMessage = " Please Select 3 Character Country Code")]
            [DisplayName("Country Code")]
            public string CountryCode { get; set; }

            [Required(ErrorMessage = "Please Select ISo Country Code")]
            [StringLength(2, ErrorMessage = " Please Select 2 Character ISO Country Code")]
            [DisplayName("ISO Country Code")]
            public string ISOCountryCode { get; set; }

            public int HotelStatusId { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }


            [DisplayName("Active")]
            public bool Active { get; set; }

            public string id { get; set; }
            public IEnumerable<HotelCountryModels> HotelCountryList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }
        }

        public class HotelCultureInformationModels
        {
            [Required(ErrorMessage = "CultureInformation is Required")]
            [StringLength(10, ErrorMessage = "Must be under 10 Characters")]
            [DisplayName("Culture Information")]
            public string CultureInformation { get; set; }

            [Required(ErrorMessage = "Display Name is Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Display Name")]
            public string DisplayName { get; set; }

            [Required(ErrorMessage = "Native Name is Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Native Name")]
            public string NativeName { get; set; }

            [Required(ErrorMessage = "English Name is Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("English Name")]
            public string EnglishName { get; set; }

            [Required(ErrorMessage = "Please Select Country Name")]
            [DisplayName("Country Name")]
            public int CountryName { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> CountryNameList { get; set; }

            public string id { get; set; }
            public string CountryName_Name { get; set; }
            public IEnumerable<HotelCultureInformationModels> HotelCultureInformationList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }
        }

        public class HotelFacilityModels
        {
            [Required(ErrorMessage = "Hotel Facility Name is Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Facility Name")]
            public string FacilityName { get; set; }

            [Required(ErrorMessage = "Facility Details is Required")]
            [StringLength(255, ErrorMessage = "Must be under 255 Characters")]
            [DisplayName("Details")]
            public string Details { get; set; }

            [Required(ErrorMessage = "Please Select Hotel Name")]
            [DisplayName("Hotel Name")]
            public int HotelName { get; set; }


            [DisplayName("Active")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> HotelNameList { get; set; }

            public string id { get; set; }
            public string HotelName_Name { get; set; }
            public IEnumerable<HotelFacilityModels> HotelFacilityList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelAdditionalChargeModels
        {
            [Required(ErrorMessage = "Additional Charge Name is Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Charge Name")]
            public string ChargeName { get; set; }

            [Required(ErrorMessage = "Additional Charge Detail is Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Details")]
            public string Details { get; set; }

            [Required(ErrorMessage = "Hotel Rate is Required")]
            [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "*")]
            [DisplayName("Rate")]
            public string Rate { get; set; }

            [Required(ErrorMessage = "Please Select Hotel Name")]
            [DisplayName("Hotel Name")]
            public int HotelName { get; set; }


            [DisplayName("Active")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> HotelNameList { get; set; }

            public string id { get; set; }
            public string HotelName_Name { get; set; }
            public IEnumerable<HotelAdditionalChargeModels> HotelAdditionalChargeList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelPhotoCategoryModels
        {
            public int PhotoCategoryId { get; set; }

            [Required(ErrorMessage = "Please Select Category Name")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Category Name")]
            public string CategoryName { get; set; }

            [Required(ErrorMessage = "Please Select Hotel Details")]
            [StringLength(255, ErrorMessage = "Must be under 255 Characters")]
            [DisplayName("Details")]
            public string Details { get; set; }

            [Required(ErrorMessage = "Please Select Hotel Name")]
            [DisplayName("Hotel Name")]
            public int HotelName { get; set; }

            [DisplayName("Active")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> HotelNameList { get; set; }

            public string id { get; set; }
            public string HotelName_Name { get; set; }
            public IEnumerable<HotelPhotoCategoryModels> HotelPhotoCategoryList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }
        }

        public class HotelGoogleMapModels
        {

            [Required(ErrorMessage = "Please Select Hotel Name")]
            [DisplayName("Hotel Name")]
            public int HotelName { get; set; }


            [Required(ErrorMessage = "Please Enter Latitude")]
            [RegularExpression(@"\-?\d+(\.\d+)?", ErrorMessage = "*")]
            [DisplayName("Latitude")]
            public decimal Latitude { get; set; }

            [Required(ErrorMessage = "Please Enter Longitude")]
            [RegularExpression(@"\-?\d+(\.\d+)?", ErrorMessage = "*")]
            [DisplayName("Longitude")]
            public decimal Longitude { get; set; }


            [DisplayName("Active")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public IEnumerable<SelectListItem> HotelNameList { get; set; }

            public string id { get; set; }
            public string HotelName_Name { get; set; }
            public IEnumerable<HotelGoogleMapModels> HotelGoogleMapList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelInformationModels
        {
            #region tbl_HotelInfo

            public Int64 HotelId { get; set; }

            [Required(ErrorMessage = "Hotel Name Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Hotel Name")]
            public string HotelName { get; set; }

            [Required(ErrorMessage = "Hotel Code Required")]
            [StringLength(10, ErrorMessage = "Must be under 10 Characters")]
            [DisplayName("Hotel Code")]
            public string HotelCode { get; set; }

            [Required(ErrorMessage = "Please Select Native Country")]
            [DisplayName("Native Country")]
            public int CountryId { get; set; }

            [Required(ErrorMessage = "Web Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Web")]
            public string Web { get; set; }

            [Required(ErrorMessage = "Please Select HotelType")]
            [DisplayName("Hotel Type")]
            public Int32 HotelType { get; set; }

            [Required(ErrorMessage = "Email Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Email")]
            public string Email { get; set; }

            [StringLength(50, ErrorMessage = "Must be under 50 Characters")]
            [DisplayName("Alternate Email")]
            public string OptionalEmail { get; set; }

            [Required(ErrorMessage = "Address Required")]
            [StringLength(255, ErrorMessage = "Must be under 255 Characters")]
            [DisplayName("Address")]
            public string Address { get; set; }

            public HttpPostedFileBase Logo { get; set; }

            [Required(ErrorMessage = "Phone Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Phone")]
            public string Phone { get; set; }

            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Alternate Phone")]
            public string OptionalPhone { get; set; }

            [StringLength(255, ErrorMessage = "Must be under 255 Characters")]
            [DisplayName("Details")]
            public string Details { get; set; }

            [Required(ErrorMessage = "Required")]
            [DisplayName("Status")]
            public int StatusId { get; set; }

            public bool Deleted { get; set; }

            public IEnumerable<HotelInformationModels> HotelInformation { get; set; }

            public IEnumerable<SelectListItem> HotelCountryList { get; set; }
            public IEnumerable<SelectListItem> HotelTypeList { get; set; }
            public IEnumerable<SelectListItem> Status { get; set; }

            public string HotelType_Name { get; set; }
            public string HotelCountry_Name { get; set; }
            #endregion

            #region tbl_HotelContactInfo

            public Int64 ContactInfoId { get; set; }

            [Required(ErrorMessage = "Owner Name Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Full Name")]
            public string OwnerFullName { get; set; }

            [Required(ErrorMessage = "Owner Email Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Email")]
            public string OwnerEmail { get; set; }

            [Required(ErrorMessage = "Owner Mobile Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Mobile")]
            public string OwnerMobile { get; set; }

            [Required(ErrorMessage = "Owner Landline Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Landline")]
            public string OwnerLandline { get; set; }

            [Required(ErrorMessage = "Owner TempAddress Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Temporary Address")]
            public string OwnerTempAddress { get; set; }

            [Required(ErrorMessage = "Owner PermAddress Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Permanent Address")]
            public string OwnerPermAddress { get; set; }

            [Required(ErrorMessage = "Owner Designation Required")]
            [DisplayName("Designation")]
            public int OwnerDesignationId { get; set; }

            [Required(ErrorMessage = "Date of Birth Required")]
            [DisplayName("DOB")]
            public DateTime OwnerDOB { get; set; }

            [Required(ErrorMessage = "Contact Name Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Full Name")]
            public string ContactFullName { get; set; }

            [Required(ErrorMessage = "Contact Email Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Email")]
            public string ContactEmail { get; set; }

            [Required(ErrorMessage = "Contact Mobile Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Mobile")]
            public string ContactMobile { get; set; }

            [Required(ErrorMessage = "Contact Landline Required")]
            [StringLength(20, ErrorMessage = "Must be under 20 Characters")]
            [DisplayName("Landline")]
            public string ContactLandline { get; set; }

            [Required(ErrorMessage = "Contact TempAddress Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Temporary Address")]
            public string ContactTempAddress { get; set; }

            [Required(ErrorMessage = "Contact PermAddress Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Permanent Address")]
            public string ContactPermAddress { get; set; }


            [Required(ErrorMessage = "Designation Required")]
            [DisplayName("Designation")]
            public int ContactDesignationId { get; set; }

            [Required(ErrorMessage = "Contact DOB Required")]
            [DisplayName("DOB")]
            public DateTime ContactDOB { get; set; }

            public IEnumerable<SelectListItem> DesignationList { get; set; }


            #endregion

            #region tbl_HotelRoomType

            public int HotelRoomTypeId { get; set; }
            public string TypeName { get; set; }

            public IEnumerable<HotelInformationModels> HotelRoomTypeList { get; set; }

            public int[] HotelRoomTypeCheckBoxList { get; set; }

            #endregion

            #region tbl_Hotel_RoomTypeAssociation
            public int HotelId_RoomTypeAssociation { get; set; }
            public IEnumerable<HotelRoomTypeAssociationModels> HotelRoomTypeAssociationSelectedCheckBoxList { get; set; }
            #endregion

            #region tbl_Hotel_HotelFacilityAssociation
            public int HotelId_HotelFacilityAssociation { get; set; }
            public IEnumerable<HotelFacilityAssociationModels> HotelFacilityAssociationSelectedCheckBoxList { get; set; }
            #endregion

            #region tbl_Hotel_HotelCityInfoAssociation

            public int HotelId_HotelCityInfoAssociation { get; set; }
            public IEnumerable<HotelCityInfoAssociationModels> HotelCityInfoAssociationSelectedCheckBoxList { get; set; }
            #endregion

            #region tbl_Hotel_HotelAdditionalChargeAssociation

            public int HotelId_HotelAdditionalChargeAssociation { get; set; }
            public IEnumerable<HotelAdditionalChargeAssociationModels> HotelAdditionalChargeAssociationSelectedCheckBoxList { get; set; }
            #endregion

            #region tbl_HotelFacility

            public int FacilityId { get; set; }
            public string FacilityName { get; set; }

            public IEnumerable<HotelInformationModels> HotelFacityList { get; set; }

            public int[] HotelFacilityCheckBoxList { get; set; }

            #endregion

            #region tbl_HotelCityInfo

            public int CityId { get; set; }
            public string CityName { get; set; }
            public IEnumerable<HotelInformationModels> HotelCityInfoList { get; set; }
            public int[] HotelCityInfoCheckBoxList { get; set; }

            #endregion

            #region tbl_HotelAdditionalCharge
            public int ChargeId { get; set; }
            public string ChargeName { get; set; }

            public IEnumerable<HotelInformationModels> HotelAdditionalChargeList { get; set; }
            public int[] HotelAdditionalChargeCheckBoxList { get; set; }
            #endregion

            //#region Form Action
            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }
            //#endregion

        }

        public class HotelCurrencySettingModels
        {
            [Required(ErrorMessage = "Currency Name Required")]
            [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
            [DisplayName("Name")]
            public string CurrencyName { get; set; }


            [Required(ErrorMessage = "Currency Symbol is Required")]
            [StringLength(3, ErrorMessage = "Must be of length 3")]
            [DisplayName("Symbol")]
            public string Symbol { get; set; }

            [Required(ErrorMessage = "ISO Code is Required")]
            [StringLength(3, ErrorMessage = "Must be of length 3")]
            [DisplayName("ISO Code")]
            public string IsoCode { get; set; }

            [DisplayName("Current")]
            public bool Current { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string id { get; set; }
            public IEnumerable<HotelCurrencySettingModels> CurrencySettingList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelMailSettingModels
        {
            [Required(ErrorMessage = "SMTPHost Required")]
            [StringLength(50, ErrorMessage = "Must be under 50 characters")]
            [DisplayName("SMTPHost")]
            public string SMTPHost { get; set; }

            [Required(ErrorMessage = "Port Required")]
            [RegularExpression(@"\-?\d+(\.\d+)?", ErrorMessage = "*")]
            [DisplayName("Port")]
            public string Port { get; set; }

            [Required(ErrorMessage = "Email Required")]
            [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
            [DisplayName("AdminEmail")]
            public string AdminEmail { get; set; }


            [DisplayName("Current")]
            public bool Current { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }

            public string id { get; set; }
            public IEnumerable<HotelMailSettingModels> HotelMailSettingList { get; set; }

            //public string formActionName { get; set; }
            //public string formControllerName { get; set; }
            //public string formOnSubmitAction { get; set; }
            //public string formSubmitBttnName { get; set; }

        }

        public class HotelPhotoModels
        {
            public Int64 PhotoId { get; set; }
            [DisplayName("Photos")]
            public IList<HttpPostedFileBase> Picture { get; set; }
            public string PictureName { get; set; }
            public string PicturePath { get; set; }

            [DisplayName("Title")]
            public string Title { get; set; }

            public string Details { get; set; }

            [DisplayName("Photo Category")]
            public int PhotoCategoryId { get; set; }

            [DisplayName("Status")]
            public bool Active { get; set; }

            public bool Deleted { get; set; }

            public int CreatedBy { get; set; }

            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }

            public DateTime UpdatedDate { get; set; }

            public string id { get; set; }

            public IEnumerable<HotelPhotoModels> HotelPhotosList { get; set; }
            public IEnumerable<SelectListItem> HotelNameList { get; set; }

            [DisplayName("Hotel")]
            public string HotelName { get; set; }

            public IEnumerable<SelectListItem> PhotoCategoryList { get; set; }

            public int[] DeletedCheckedList { get; set; }

            [DisplayName("Photo Category")]
            public string CategoryName { get; set; }


        }
    }
}