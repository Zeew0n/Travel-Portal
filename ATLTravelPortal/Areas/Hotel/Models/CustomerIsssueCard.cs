using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class CustomerIsssueCard
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Customer")]
        public long CustomerID { get; set; }
        public int CustomerCardsId { get; set; }
        public long HFCustomerID { get; set; }

        public Int32 CardId { get; set; }
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Product")]
        public Int32 ProductId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
        public Int32 AgentId { get; set; }
        public string AgentName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Customer Code")]
        public string CustomerCode { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("First Name ")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name ")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Gender ")]
        public string Gender { get; set; }
      

        [Required(ErrorMessage = "*")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Address1")]
        public string Address1 { get; set; }

        [DisplayName("Address2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("House No")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Country")]
        public int CountryID { get; set; }
        public List<SelectListItem> CountryList { get;set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Work Phone")]
        public string WorkPhone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Fax No")]
        public string FaxNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Profession")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Customer Type")]
        public int CustomerTypeId { get; set; }
        public string CustomerTpeName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Customer Status")]
        public string CustomerStatus { get; set; }

        [DisplayName("Create Date")]
        public DateTime Created { get; set; }

        [DisplayName("Created By")]
        public Int32 CreatedBy { get; set; }

        [DisplayName("Updated Date")]
        public DateTime Updated { get; set; }

        [DisplayName("Updated By")]
        public Int32 UpdatedBy { get; set; }

        public string formSubmitBttnName { get; set; }

        public List<String> CustomerCard { get; set; }
        public List<int> CustomerCardId { get; set; }

        public List<SelectListItem> AgentList { get; set; }

        public IEnumerable<SelectListItem> CustomerTypeList { get; set; }
       

        public IEnumerable<SelectListItem> CustomerStatusList { get; set; }

        public List<CustomerIsssueCard> customerissuecard { get; set; }

        public List<Int32> CardIds { get; set; }

       


       


       


        



    }
}