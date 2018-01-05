using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public enum AmPm
    {
        AM,
        PM
    }

    public class FlightFareInformationModel : IValidatableObject
    {
        [DisplayName("From")]
        public string DepartCity { get; set; }
        public int DepartCityId { get; set; }
        public IEnumerable<SelectListItem> DepartCityList { get; set; }

        [DisplayName("To")]
        public string ArriveCity { get; set; }
        public int ArriveCityId { get; set; }
        public IEnumerable<SelectListItem> ArriveCityList { get; set; }

      //  [RegularExpression(@"^(((0?[1-9]|1[012])/(0?[1-9]|1/d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$", ErrorMessage = "Not a valid date")]
        [Required(ErrorMessage=" ")]
        [MultipleDateValidation(@"^(((0?[1-9]|1[012])/(0?[1-9]|1/d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$", ErrorMessage = "Not a valid date")]
        [DisplayName("Departure Date")]
        public string DepartureDate { get; set; }

         [Required(ErrorMessage = " ")]
        [DisplayName("Task Begin Date")]
        public DateTime? TaskBeginDate { get; set; }

        public AmPm rdbAmPm { get; set; }

        [DisplayName("Time")]
        public string TimeId { get; set; }
        public string TimeName { get; set; }


        public string Hour { get; set; }
        public string Minute { get; set; }

       
       // [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        [Required(ErrorMessage = " ")]
        [MultipleEmailValidation("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z-0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid Email")]
        [DisplayName("Email Receivers")]
        public string EmailReceivers { get; set; }

        public int hdfDepartCityId { get; set; }
        public int hdfArriveCityId { get; set; }

         [Required(ErrorMessage = " ")]
        public string Duration { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            return null;
        }
    }

    public class MultipleEmailValidation : RegularExpressionAttribute
    {
        List<string> invalidEmails = new List<string>();
        public MultipleEmailValidation(string pattern)
            : base(pattern)
        {

        }



        public override bool IsValid(object value)
        {
            invalidEmails.Clear();
            string str = value.ToString();
            var emails = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string email in emails)
            {
                if (!base.IsValid(email))
                {
                    invalidEmails.Add(email);
                }

            }

            if (invalidEmails.Count > 0)
            {
                this.ErrorMessage = GetErrorMessage();
                return false;
            }
            return true;
        }

        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Following emails are invalid");
            if (invalidEmails.Count > 0)
            {
                foreach (string item in invalidEmails)
                {
                    sb.AppendLine(item);
                }
            }
            return sb.ToString();
        }
    }











    public class MultipleDateValidation : RegularExpressionAttribute
    {
        List<string> invalidDates = new List<string>();
        public MultipleDateValidation(string pattern)
            : base(pattern)
        {

        }



        public override bool IsValid(object value)
        {
            invalidDates.Clear();
            string str = value.ToString();
            var dates = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string date in dates)
            {
                if (!base.IsValid(date))
                {
                    invalidDates.Add(date);
                }

            }

            if (invalidDates.Count > 0)
            {
                this.ErrorMessage = GetErrorMessage();
                return false;
            }
            return true;
        }

        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Enter valid date.");
           
            return sb.ToString();
        }
    }
}