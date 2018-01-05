using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace ATLTravelPortal.Helpers
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }

    public class ActiveStatus
    {
        public static IEnumerable<SelectListItem> GetStatus(string listSelectedValue)
        {

            List<Status> status = new List<Status>();
            status.Add(new Status { StatusId = 0, StatusName = "Active" });
            status.Add(new Status { StatusId = 1, StatusName = "InActive" });

            return from result in status
                   select new SelectListItem
                   {
                       Text = result.StatusName,
                       Value = result.StatusId.ToString(),
                       Selected = listSelectedValue == result.StatusId.ToString() ? true : false,
                   };

        }
    }

    //public class ChildFairTypes
    //{
    //    public string ChildFairTypeID { get; set; }
    //    public string ChildFairType { get; set; }

    //    public static IEnumerable<ChildFairTypes> GetChildFairType()
    //    {

    //        List<ChildFairTypes> _childFairType = new List<ChildFairTypes>();
    //        _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "", ChildFairType = "--Select--" });
    //        _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "P", ChildFairType = "PERCENTAGE" });
    //        _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "S", ChildFairType = "SLAB" });

    //        return _childFairType;
    //    }
    //}

    public class AccountTypes
    {
        public string AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

        public static IEnumerable<AccountTypes> GetAccountType()
        {
            List<AccountTypes> _accountType = new List<AccountTypes>();
            _accountType.Add(new AccountTypes { AccountTypeId = "", AccountTypeName = "--Select--" });
            _accountType.Add(new AccountTypes { AccountTypeId = "C", AccountTypeName = "CREDIT" });
            _accountType.Add(new AccountTypes { AccountTypeId = "D", AccountTypeName = "DEBIT" });

            return _accountType;
        }



    }

    public class ChildFairOns
    {
        public string ChildFairOnId { get; set; }
        public string ChildFairOnss { get; set; }

        public static IEnumerable<ChildFairOns> GetChildFairOn()
        {
            List<ChildFairOns> _childFairOn = new List<ChildFairOns>();
            _childFairOn.Add(new ChildFairOns { ChildFairOnId = "M", ChildFairOnss = "MARKET VALUE" });
            _childFairOn.Add(new ChildFairOns { ChildFairOnId = "N", ChildFairOnss = "NORMAL VALUE" });
            return _childFairOn;
        }
    }



    public class ChildFairTypes
    {
        public string ChildFairTypeID { get; set; }
        public string ChildFairType { get; set; }

        public static IEnumerable<ChildFairTypes> GetChildFairType()
        {

            List<ChildFairTypes> _childFairType = new List<ChildFairTypes>();
            _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "", ChildFairType = "--Select--" });
            _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "P", ChildFairType = "PERCENTAGE" });
            _childFairType.Add(new ChildFairTypes { ChildFairTypeID = "S", ChildFairType = "SLAB" });

            return _childFairType;
        }
    }


    //public class Adults
    //{
    //    public int NoOfAdults { get; set; }
    //    public static IEnumerable<Adults> GetAdultsOption()
    //    {
    //        List<Adults> _adultsOption = new List<Adults>{
    //                new Adults{NoOfAdults=1},
    //                new Adults{NoOfAdults=2},
    //                new Adults{NoOfAdults=3},
    //                new Adults{NoOfAdults=4},
    //                new Adults{NoOfAdults=5},
    //                new Adults{NoOfAdults=6},
    //                new Adults{NoOfAdults=7},
    //                new Adults{NoOfAdults=8},
    //                new Adults{NoOfAdults=9}
                   
    //        };
    //        return _adultsOption;
    //    }
    //}

    //public class Children
    //{
    //    public int NoOfChildren { get; set; }
    //    public static IEnumerable<Children> GetChildrenOption()
    //    {
    //        List<Children> _childrenOption = new List<Children>{
    //                new Children{NoOfChildren=0},
    //                new Children{NoOfChildren=1},
    //                new Children{NoOfChildren=2},
    //                new Children{NoOfChildren=3},
    //                new Children{NoOfChildren=4},
    //                new Children{NoOfChildren=5},
    //                new Children{NoOfChildren=6},
    //                new Children{NoOfChildren=7},
    //                new Children{NoOfChildren=8},
    //                new Children{NoOfChildren=9}
                   
    //        };
    //        return _childrenOption;
    //    }
    //}

    //public class Infants
    //{
    //    public int NoOfInfants { get; set; }
    //    public static IEnumerable<Infants> GetInfantsOption()
    //    {
    //        List<Infants> _infantsOption = new List<Infants>{
    //                new Infants{NoOfInfants=0},
    //                new Infants{NoOfInfants=1},
    //                new Infants{NoOfInfants=2},
    //                new Infants{NoOfInfants=3},
    //                new Infants{NoOfInfants=4},
    //                new Infants{NoOfInfants=5},
    //                new Infants{NoOfInfants=6},
    //                new Infants{NoOfInfants=7},
    //                new Infants{NoOfInfants=8},
    //                new Infants{NoOfInfants=9}
                 
    //        };
    //        return _infantsOption;
    //    }
    //}


    //public class ChildFairOns
    //{
    //    public string ChildFairOnId { get; set; }
    //    public string ChildFairOnss { get; set; }

    //    public static IEnumerable<ChildFairOns> GetChildFairOn()
    //    {
    //        List<ChildFairOns> _childFairOn = new List<ChildFairOns>();
    //        _childFairOn.Add(new ChildFairOns { ChildFairOnId = "M", ChildFairOnss = "MARKET VALUE" });
    //        _childFairOn.Add(new ChildFairOns { ChildFairOnId = "N", ChildFairOnss = "NORMAL VALUE" });
    //        return _childFairOn;
    //    }
    //}

    //public class Titles
    //{
    //    public int TitleID { get; set; }
    //    public string TitleName { get; set; }

    //    public static IEnumerable<Titles> GetTitles()
    //    {
    //        List<Titles> _childFairOn = new List<Titles>();
    //        _childFairOn.Add(new Titles { TitleID = 1, TitleName = "Mr." });
    //        _childFairOn.Add(new Titles { TitleID = 2, TitleName = "Mrs." });

    //        return _childFairOn;
    //    }
    //}


    #region Min

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinAttribute : ValidationAttribute
    {

        public const string _defaultErrorMessage = "'{0}' must be select!!";
        public int MinValue { get; set; }
        public bool IsMandatory { get; set; }

        public MinAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
            IsMandatory = true;
        }

        public override string FormatErrorMessage(string name)
        {

            return String.Format(CultureInfo.CurrentUICulture, _defaultErrorMessage, name, MinValue);
        }

        public override bool IsValid(object value)
        {
            Int32 boxed;

            if (Int32.TryParse(value.ToString(), out boxed))
            {
                return (boxed >= MinValue);
            }
            return false;
            //if (IsMandatory == false && (value == null || (string)value == "")) return true;
            //int valueAsInt = 
            //(int)(value == null ? 0 : value);
            //return (valueAsInt >= MinValue);


        }

    }

    public class MinValidator : DataAnnotationsModelValidator<MinAttribute>
    {

        string _minValue;
        bool _isMandatory;
        string _message;

        public MinValidator(ModelMetadata metadata, ControllerContext context
            , MinAttribute attribute)
            : base(metadata, context, attribute)
        {
            _minValue = attribute.MinValue.ToString();

            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _minValue);
            _isMandatory = attribute.IsMandatory;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "min",
            };
            //var rule1 = new ModelClientValidationRule
            //{
            //    ErrorMessage = _message,
            //    ValidationType = "min",
            //};
            //  rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("min", _minValue);
            return new[] { rule };

        }
    }

    #endregion

    public static class AirLineValidation
    {

        public static void RegisterValidation()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.Helpers.MinAttribute), typeof(ATLTravelPortal.Helpers.MinValidator));
        }

    }

    public class Prefix
    {
        public string PrefixName { get; set; }

        public static List<string> GetPrefix()
        {
            List<string> prefix = new List<string>();
            prefix.Add("Mr");
            prefix.Add("Mrs");
            prefix.Add("Master");
            prefix.Add("Ms");

            return prefix;
        }
    }

    public class CommissionType
    {
        public string Type { get; set; }

        public static List<string> GetCommissionType()
        {
            List<string> type = new List<string>();
            type.Add("Percentage");
            type.Add("Slab");

            return type;
        }
    }


    #region ApplicationSettings
    public class ApplicationSettings
    {
        public static int GetMaxPhotoSizeToUpload()
        {
            return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["MaxPhotoSizeToUpload"].ToString());
        }

        public static string[] GetThumbnailSize()
        {
            string[] ThumbnailSize = System.Web.Configuration.WebConfigurationManager.AppSettings["ThumbnailSize"].ToString().Split(',');
            return ThumbnailSize;
        }
    }


    #endregion



    #region ThumbnailGenerator Methods

    public class ThumbnailGenerator
    {
        public static bool ChangeHeightWidth(string location, System.Drawing.Image imgSourceImage, int iWidth, int iHeight)
        {
            try
            {
                System.Drawing.Bitmap oImage = new System.Drawing.Bitmap(imgSourceImage);
                oImage = (System.Drawing.Bitmap)oImage.GetThumbnailImage(iWidth, iHeight, null, IntPtr.Zero);
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                string sFilePath = location.Replace("_sm", "_th");
                oImage.Save(sFilePath, jpgEncoder, myEncoderParameters);
                imgSourceImage = oImage;
                return true;
            }
            catch
            {
                throw;
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }

    #endregion

    }

    //public class SearchedParameter
    //{

    //    public string StartCity { get; set; }

    //    public string EndCity { get; set; }
    //    public DateTime DepartureDate { get; set; }
    //    public DateTime? ReturnDate { get; set; }
    //    public int NoOfSeats { get; set; }
    //    public AirLines.Models.AirLine.SearchType ChosenSearchType { get; set; }
    //    public int hdStartCityId { get; set; }
    //    public string hdStartCityName { get; set; }
    //    public string hdStartCityCode { get; set; }
    //    public int hdEndCityId { get; set; }
    //    public string hdEndCityName { get; set; }
    //    public string hdEndCityCode { get; set; }
    //    public int NoOfAdults { get; set; }
    //    public int NoOfChildren { get; set; }
    //    public int NoOfInfants { get; set; }
    //}

    public static class CMSContents
    {
        public static string GetCMSContents(string RawContents)
        {
            string imagePath = WebConfigurationManager.AppSettings["ContentImageURL"];
            return Regex.Replace(RawContents, "ImageURL##", imagePath, RegexOptions.IgnoreCase);
        }
    }
}

