using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.Collections.Generic;
using System;
using ATLTravelPortal.Helpers;



namespace ATLTravelPortal.Areas.Airline.Models
{

    public class AirLineInfoModels
    {
        #region AirlineInfo
        
        [Required]
        [StringLength(200, ErrorMessage="*")]
        [LocalizedDisplayName("AirLine Name", NameResourceType = typeof(Resources.LableStrings))]        
        public string Name { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "*")]
        [LocalizedDisplayName("AirLine Code", NameResourceType = typeof(Resources.LableStrings))]       
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Select AirLine Countries")]
        [DisplayName("Native Countries")]
        public Int32 CountryId { get; set; }
        
        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Web", NameResourceType = typeof(Resources.LableStrings))]       
        public string Web { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Address", NameResourceType = typeof(Resources.LableStrings))]       
        public string AirlineAddress { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Phone 1", NameResourceType = typeof(Resources.LableStrings))]       
        public string Phone1 { get; set; }

        [StringLength(200, ErrorMessage = "Must be under 200 Characters")]
        [LocalizedDisplayName("Phone 2", NameResourceType = typeof(Resources.LableStrings))]       
        public string Phone2 { get; set; }

        [StringLength(200, ErrorMessage = "Must be under 200 Characters")]
        [LocalizedDisplayName("Email Address 1", NameResourceType = typeof(Resources.LableStrings))]       
        public string EmailAddress1 { get; set; }

        [StringLength(200, ErrorMessage = "Must be under 200 Characters")]
        [LocalizedDisplayName("Email Address 2", NameResourceType = typeof(Resources.LableStrings))]       
        public string EmailAddress2 { get; set; }

        [DisplayName("Image")]
        public HttpPostedFileBase Picture { get; set; }

        public string ImagePath { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Contact Person Name 1", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPersonName1 { get; set; }


        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Address", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson1Address1 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Phone 1", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson1Phone1 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Phone 2", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson1Phone2 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Email Address", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson1EmailAddress { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Contact Person Name 2", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPersonName2 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Address", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson2Address1 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Phone 1", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson2Phone1 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Phone 2", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson2Phone2 { get; set; }

        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [LocalizedDisplayName("Email Address", NameResourceType = typeof(Resources.LableStrings))]       
        public string ContactPerson2EmailAddress { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }

       

        public IEnumerable<SelectListItem> airLinesTypeList { get; set; }
        public IEnumerable<SelectListItem> airLinesNativeCountryList { get; set; }


        //public string id { get; set; }
        public int id { get; set; }
        public string AirType_Name { get; set; }
        public string CountryName { get; set; }
        public string Status_Name { get; set; }

        public IEnumerable<AirLineInfoModels> airLineList { get; set; }

        
        
        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }

        #endregion

        #region AirLine Ticket Category

        public int AirLineTicketCategoryId { get; set; }
        public string AirLineTicketCategoryName { get; set; }
        public IEnumerable<AirLineInfoModels> airLineTicketCategoryListing { get; set; }
        public IEnumerable<Int32> airlineTicketcategoryListingUpdate { get; set; }
        public IEnumerable<AirLineTicketCategoryModel> AirlineticketSelectedCheckBoxList { get; set; }

        public int[] AirLineTicketCategoryCheckBoxList { get; set; }

        #endregion

        #region AirLine Type

        public int AirLineTypeId { get; set; }
        public string AirlineTypeName { get; set; }
        public IEnumerable<AirLineInfoModels> airLineTypeListing { get; set; }
        public IEnumerable<Int32> airLineTypeListingUpdate { get; set; }
        public IEnumerable<AirLineTypeModels> AirLineTypeSelectedCheckBoxList { get; set; }
        
        public int[] AirLineTypeCheckBoxList { get; set; }


        #endregion


        public IEnumerable<object> checkboxList { get; set; }
    }

    public class AirLineTypeModels
    {
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
       // [StringLength(400, ErrorMessage = "Must be under 400 Characters")]
        [DisplayName("AirLine Type")]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        //public string id { get; set; }
        public int id { get; set; }
        public IEnumerable<AirLineTypeModels> AirLineTypeList { get; set; }

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }
    }

    public class AirLineTicketCategoryModel
    {
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        //[StringLength(100, ErrorMessage = "Must be under 100 Characters")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        //[StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [DisplayName("Active")]
        public bool Active { get; set; }

        //public string id { get; set; }
        public int id { get; set; }
        public IEnumerable<AirLineTicketCategoryModel> airLineTicketCategoryList { get; set; }

        public int[] AirLineCategoryCheckBoxList { get; set; }

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }
    }

    public class AirLineCityInfoModels
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        [StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        [DisplayName("City Name")]
        public string Name { get; set; }
      
        public string id { get; set; }
        public IEnumerable<AirLineCityInfoModels> AirLineCityInformationList { get; set; }

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }

    }

    public class AirLineInventoryModels
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("AirLine Name")]
        public string AirLine_Name { get; set; }

        [Required(ErrorMessage = "Please Select Departure City")]
        [DisplayName("Departure City")]
        public string DepartureCity_Name { get; set; }
        //public int DepartureCity { get; set; }

        [Required(ErrorMessage = "Please Select Destination City")]
        [DisplayName("Destination City")]
        public string DestinationCity_Name { get; set; }
        //public int DestinationCity { get; set; }

        [Required(ErrorMessageResourceName = "Select", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        [DisplayName("Rate")]
        public double Rate { get; set; }

        [Required(ErrorMessageResourceName = "Select", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        [DisplayName("Commission")]
        public double Commission { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        [HiddenInput]
        public int Json_Departure_city_Id { get; set; }

        [HiddenInput]
        public int Json_Destination_city_Id { get; set; }

        [HiddenInput]
        public int Json_AirLine_Id { get; set; }

        public IEnumerable<SelectListItem> airLinesNameList { get; set; }
        public IEnumerable<SelectListItem> airLinesDepartureCityList { get; set; }
        public IEnumerable<SelectListItem> airLinesDestinationCityList { get; set; }

        public string id { get; set; }
        public int AirLineName { get; set; }
        //public string DepartureCity_Name {get; set;}
        //public string DestinationCity_Name { get; set; }
        public int DepartureCity { get; set; }
        public int DestinationCity { get; set; }
        
        public IEnumerable<AirLineInventoryModels> airLineInventoryList {get; set;}

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }
    }
        
    public class TranTypeModels
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        [StringLength(100, ErrorMessage = "Must be under 100 Characters")]
        [DisplayName("Name")]
        public string Name { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        //[StringLength(200, ErrorMessage = "Must be under 200 Characters")]
        [DisplayName("Description")]
        public string Description { get; set; }

        public string id { get; set; }
        
        public IEnumerable<ATLTravelPortal.Areas.Airline.Models.TranTypeModels> TranType { get; set; }
       

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }
    }

    public class AirLines
    {
        [Required(ErrorMessage = "*")]
        public string txtAirLineName { get; set; }

        public int AirLineId { get; set; }
        public string AirLineCode { get; set; }
        public string Photo { get; set; }
        public int pageNo { get; set; }
        public int flag { get; set; }
        public int numberOfPage { get; set; }
        public int currentPageNo { get; set; }
        public string CountryName { get; set; }
        
        public IEnumerable<AirLines> AirLineList { get; set; }
    }
    public class AirlineModelForAirlineGroup
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
    }
}