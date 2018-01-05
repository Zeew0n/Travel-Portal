using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Areas.Hotel.Models;
using System.Runtime.Serialization;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    [MetadataType(typeof(HotelInfoValidation))]
    public partial class HotelInfos
    {
        public Int64 HotelId { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string OptionalPhone { get; set; }

        public string Email { get; set; }

        public string OptionalEmail { get; set; }


        public string Details { get; set; }

        public string Web { get; set; }

        public string HotelCode { get; set; }

        public bool isActive { get; set; }

        public string Logo { get; set; }

        public string HotelName { get; set; }


        public int? CountryId { get; set; }

        public int StatusId { get; set; }

       public List<SelectListItem > CountryList { get; set; }

        public List<SelectListItem> HotelTypeList { get; set; }

        public IEnumerable<HotelTypeInfos > HotelTypeLists { get; set; }


        public IEnumerable<Htl_HotelCountries> HotelCountryList { get; set; }      

      public IEnumerable<Htl_HotelDesignations> DesignationList { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }

       public Htl_HotelInfos HotelInfo { get; set; }


       public IEnumerable<Htl_HotelCityInfoAssociation> HotelCityInfo { get; set; }

       public IEnumerable<Htl_HotelAdditionalChargeAssociation> HotelAdditionalChargeAssociationList { get; set; }

       public IEnumerable<Htl_HotelFacilityAssociation> HotelFacilityAssociationList { get; set; }

       public IEnumerable<Htl_RoomTypeAssociation > HotelRoomTypeAssociationList { get; set; }
     
        public Int32 HotelType { get; set; }

        #region tbl_HotelRoomType
        [DataMember]
        public int HotelRoomTypeId { get; set; }

        [DataMember]
        public string TypeName { get; set; }

        [DataMember]
        public IEnumerable<HotelRoomTypes> HotelRoomTypeList { get; set; }

        [DataMember]
        public int[] HotelRoomTypeCheckBoxList { get; set; }

        #endregion

        #region tbl_Hotel_RoomTypeAssociation
        [DataMember]
        public int HotelId_RoomTypeAssociation { get; set; }

        //[DataMember]
        //public IEnumerable<RoomTypeAssociation> HotelRoomTypeAssociationSelectedCheckBoxList { get; set; }

           [DataMember]
        public IEnumerable<Htl_GetHotelRoomTypeByHotelId_Result> HotelRoomTypeAssociationSelectedCheckBoxList { get; set; }

        
        #endregion

        #region tbl_Hotel_HotelFacilityAssociation
        [DataMember]
        public int HotelId_HotelFacilityAssociation { get; set; }

        //[DataMember]
        //public IEnumerable<HotelFacilityAssociation> HotelFacilityAssociationSelectedCheckBoxList { get; set; }

          [DataMember]
        public IEnumerable<Htl_GetHotelFacilityByHotelId_Result> HotelFacilityAssociationSelectedCheckBoxList { get; set; }


        
        #endregion

        #region tbl_Hotel_HotelCityInfoAssociation
        [DataMember]
        public int HotelId_HotelCityInfoAssociation { get; set; }

        //[DataMember]
        //public IEnumerable<HotelCityInfoAssociation> HotelCityInfoAssociationSelectedCheckBoxList { get; set; }

        [DataMember]
        public IEnumerable<Htl_GetHotelCityInfoAssociationByHotelId_Result> HotelCityInfoAssociationSelectedCheckBoxList { get; set; }

        
        #endregion

        #region tbl_Hotel_HotelAdditionalChargeAssociation
        [DataMember]
        public int HotelId_HotelAdditionalChargeAssociation { get; set; }

        //[DataMember]
        //public IEnumerable<Hotel_HotelAdditionalChargeAssociation> HotelAdditionalChargeAssociationSelectedCheckBoxList { get; set; }

        [DataMember]
        public IEnumerable<Htl_GetHotelAdditionalChargeByHotelId_Result> HotelAdditionalChargeAssociationSelectedCheckBoxList { get; set; }

        #endregion

        #region tbl_HotelFacility
        [DataMember]
        public int FacilityId { get; set; }

        [DataMember]
        public string FacilityName { get; set; }

        [DataMember]
        public IEnumerable<HotelFacilities> HotelFacityList { get; set; }

        [DataMember]
        public int[] HotelFacilityCheckBoxList { get; set; }

        #endregion

        #region tbl_HotelCityInfo
        [DataMember]
        public int CityId { get; set; }

        [DataMember]
        public string CityName { get; set; }

        [DataMember]
        public IEnumerable<Htl_HotelCityInfos> HotelCityInfoList { get; set; }

        [DataMember]
        public int[] HotelCityInfoCheckBoxList { get; set; }

        #endregion

        #region tbl_HotelAdditionalCharge
        [DataMember]
        public int ChargeId { get; set; }

        [DataMember]
        public string ChargeName { get; set; }

        [DataMember]
        public IEnumerable<HotelAdditionalCharge> HotelAdditionalChargeList { get; set; }

        [DataMember]
        public int[] HotelAdditionalChargeCheckBoxList { get; set; }
        #endregion

        //#region Form Action
        //[DataMember]        
        //public string formActionName { get; set; }

        //[DataMember]
        //public string formControllerName { get; set; }

        //[DataMember]
        //public string formOnSubmitAction { get; set; }

        //[DataMember]
        //public string formSubmitBttnName { get; set; }
        //#endregion  
      
        #region HotelContactInfo
        public Htl_HotelContactInfos HotelContactInfo { get; set; }
        #endregion
    }     

    public class HotelInfoValidation
    {
        [Required(ErrorMessage = "Please Select HotelType")]
        [DisplayName("Hotel Type")]       
        public Int32 HotelType { get; set; }
    }
}
