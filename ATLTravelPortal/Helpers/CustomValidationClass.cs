using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq; 
using System.Text;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Configuration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ATLTravelPortal.Helpers
{
    public class CustomValidationClass
    {
        ModelStateDictionary _modelState;
        public CustomValidationClass(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        //validate for user management form
        public bool Validateentry(string AgentName, string Address, string PanNo, string Email, string Phone, string BussinessClassTypeMarkup, string EconomyClassTypeMarkup, string TotalMarkup)
        {
            string eMailmessage;
            TextValidation(AgentName, "AgentName", "Enter the correct value");
            TextValidation(Address, "Address", "Enter the correct value");
            TextValidation(PanNo, "PanNo", "Enter the correct value");
            TextValidation(Phone, "Phone", "Enter the correct value");
            DecimalValidation(BussinessClassTypeMarkup, "EconomyClassTypeMarkup", "Enter the correct value");
            DecimalValidation(EconomyClassTypeMarkup, "EconomyClassTypeMarkup", "Enter the correct value");
            TextValidation(TotalMarkup, "TotalMarkup", "Enter the correct value");
            if (!EmailValidation(Email, out eMailmessage))
            {
                _modelState.AddModelError("Email", eMailmessage);
            }
            return _modelState.IsValid;
        }
        public bool ValidatePassengerentry(string LastName, string FirstName, string PassportNo, string MobileNo, string Email, string DOB)
        {
            string eMailmessage;
            TextValidation(FirstName, "FirstName", "Enter the first name");
            TextValidation(LastName, "LastName", "Enter the last name");
            TextValidation(PassportNo, "PassportNo", "Enter the Passport No.");
            TextValidation(MobileNo, "MobileNo", "Enter Mobile No.");
            TextValidation(DOB, "DOB", "Enter Date of Birth");
            //TextValidation(Email, "EmailAddress1", "Enter Email Address");
            if (!EmailValidation(Email, out eMailmessage))
            {
                _modelState.AddModelError("EmailAddress1", eMailmessage);
            }
            return _modelState.IsValid;
        }
           public bool ValidateVoucherentry(string Todate,string fromdate)
        {

            TextValidation(Todate, "ToDate", "Enter the correct value");
            TextValidation(fromdate, "FromDate", "Enter the correct value");
            return _modelState.IsValid;
        }
        #region Validation


        public static bool EmailValidation(string email, out string emailMsg)
        {
            //email = email.Trim();
            const string EmailRegEx = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                  + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                  + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                  + @"[a-zA-Z]{2,}))$";

            Regex rgx = new Regex(EmailRegEx);
            if (string.IsNullOrEmpty(email))
            {
                emailMsg = "Please enter the email id";
                return false;
            }
            else
            {

                if (rgx.IsMatch(email.Trim()))
                {
                    emailMsg = "";
                    return true;
                }
                else
                {
                    emailMsg = "Please enter the valid email id";
                    return false;
                }
            }
        }

        public void TextValidation(string text, string key, string errMsg)
        {
            if (string.IsNullOrEmpty(text))
            {
                _modelState.AddModelError(key, errMsg);
            }
            _modelState.SetModelValue(key, new ValueProviderResult(text, text, System.Threading.Thread.CurrentThread.CurrentCulture));// collection.ToValueProvider()["FirstName"]);
        }
        public void NameValidation(string text, string key, string errMsg)
        {
            const string regex = @"^[a-zA-Z''-'\s]{1,40}$";
            Regex rgx = new Regex(regex);
            if ((string.IsNullOrEmpty(text)) || (!rgx.IsMatch(text)))
            {
                _modelState.AddModelError(key, errMsg);
            }
            _modelState.SetModelValue(key, new ValueProviderResult(text, text, System.Threading.Thread.CurrentThread.CurrentCulture));// collection.ToValueProvider()["FirstName"]);
        }

        public void DecimalValidation(string text, string key, string errMsg)
        {
            //const string regex1 = @"^\d+$";
            const string regex2 = @"^\d+(\.\d\d)?$";
            Regex rgx = new Regex(regex2);
            //Regex reg = new Regex(regex2);
            if ((string.IsNullOrEmpty(text)) || (!rgx.IsMatch(text))/*|| (!reg.IsMatch(text))*/)
            {
                _modelState.AddModelError(key, errMsg);
            }
            _modelState.SetModelValue(key, new ValueProviderResult(text, text, System.Threading.Thread.CurrentThread.CurrentCulture));// collection.ToValueProvider()["FirstName"]);
        }
        public bool NumericTextValidation(string text, string key)
        {
            bool result = false;
            if (string.IsNullOrEmpty(text.Trim()))
            {
                _modelState.AddModelError(key, "Empty Numeric field value");
                return result;
            }

            // check if text box contains numeric values
            try
            {
                const string regularExp = @"(^-?\d{1,3}\.$)|(^-?\d{1,3}$)|(^-?\d{0,3}\.\d{1,2}$)";

                if (!Regex.IsMatch(text, regularExp))
                {
                    _modelState.AddModelError(key, "This is not valid numeric/decimal");
                    return false;
                }
                else
                {
                    result = true;
                }
                //long temp = long.Parse(text);
            }
            catch (Exception ex)
            {
                _modelState.AddModelError(key, ex.Message);
                //_modelState.SetModelValue(key, new ValueProviderResult(text, text, System.Threading.Thread.CurrentThread.CurrentCulture));// collection.ToValueProvider()["FirstName"]);
                result = false;
            }
            _modelState.SetModelValue(key, new ValueProviderResult(text, text, System.Threading.Thread.CurrentThread.CurrentCulture));// collection.ToValueProvider()["FirstName"]);
            return result;
        }

        public class PhoneValidator
        {

            static IDictionary<string, Regex> countryRegex = new Dictionary<string, Regex>() {
           { "USA", new Regex("^[2-9]\\d{2}-\\d{3}-\\d{4}$")},
           { "UK", new Regex("(^1300\\d{6}$)|(^1800|1900|1902\\d{6}$)|(^0[2|3|7|8]{1}[0-9]{8}$)|(^13\\d{4}$)|(^04\\d{2,3}\\d{6}$)")},
           { "Netherlands", new Regex("(^\\+[0-9]{2}|^\\+[0-9]{2}\\(0\\)|^\\(\\+[0-9]{2}\\)\\(0\\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\\-\\s]{10}$)")},
            };


            /// <summary>
            /// ////////////////////
            /// </summary>
            /// 
            [MetadataType(typeof(PaperFlightFareMetadata))]
            public partial class PaperFareRules
            {
                 [Bind(Exclude = "PaperFareId")]
                 public class PaperFlightFareMetadata
                 {
                 
                     [DisplayName("Airline")]
                     public object AirlineId { get; set; }

                 
                     [DisplayName("Flight Season")]
                     public object FlightSeasonId { get; set; }

                     [DisplayName("Departure City")]
                     public object DepartureCityId { get; set; }

                     [DisplayName("Destination City")]
                     public object DestinationCityId { get; set; }

                      [DisplayName("Flight Class")]
                     public object FlightClassId { get; set; }

                     [Required(ErrorMessage = "OneWay Fare Basis is required")]
                      [DisplayFormat(ConvertEmptyStringToNull = false)]
                     // [DataType(DataType.Text)] 
                      public object OneWayFareBasis { get; set; }

                      [Required(ErrorMessage = "OneWay Fare is required")]
                      [DataType(DataType.Currency)]
                     public object OneWayFare { get; set; }

                      [Required(ErrorMessage = "Roundway Fare Basis is required")]
                      [DisplayFormat(ConvertEmptyStringToNull = false)]
                     // [DataType(DataType.Text)] 
                      public object RoundWayFareBasis { get; set; }

                     [Required(ErrorMessage = "Round Fare is required")]
                     [DataType(DataType.Currency)]
                     public object RoundWayFare { get; set; }


                     [Required(ErrorMessage = "Effective Date is required")]
                     [DataType(DataType.Date)]
                     public object EffectiveFrom { get; set; }

                     [Required(ErrorMessage = "Expiry Date is required")]
                     [DataType(DataType.Date)]
                     public object ExpireOn { get; set; }

                      [DisplayName("Flight Type")]
                     public object FlightTypeId { get; set; }

                      [Required(ErrorMessage = "Infant Fare is required")]
                      [DataType(DataType.Currency)]
                     public object ChildFare { get; set; }

                      [Required(ErrorMessage = "Childer Fare is required")]
                      [DataType(DataType.Currency)]
                      public object InfantFare { get; set; }

                      [Required(ErrorMessage = "Refund Fee is required")]
                      [DataType(DataType.Currency)]
                     public object RefundFee { get; set; }

                      [Required(ErrorMessage = "Reissue Fee is required")]
                      [DataType(DataType.Currency)]
                     public object ReissueFee { get; set; }

                      [DisplayName("Currencies Type")]
                     public object CurrencyId { get; set; }
                 }

            }

        #endregion
        }
    }
}