using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class GuestDetailModel
    {
        public long GuestId { get; set; }
        public long No { get; set; }
        public long BookingRecordId { get; set; }
        [Required(ErrorMessage="*")]
        public string Title { get; set; }
        [Required(ErrorMessage = "*")]
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string GuestState { get; set; }
        public string Country { get; set; }
        public string ZipCoade { get; set; }
        public string GuestType { get; set; }
        //[GuestType] [int] NULL,
        public int RoomIndex { get; set; }
        public bool IsLeadGuest { get; set; }
        //[RoomIndex] [int] NULL,
    }
}