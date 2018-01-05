using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Collections;
using System.Reflection;



namespace ATLTravelPortal.App_Class.Validation
{

    #region RegularExpression
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RegularExpressionAttribute : ValidationAttribute
    {

        public const string _defaultErrorMessage = "Invalid '{0}'.";
        public readonly string _pattern;
        public enum EnumReqExp
        {
            [StringValue(@"^[-+]?[0-9]{1,10}(\.[0-9]{1,4})?$")]
            Decimal,
            [StringValue(@"^(\+|-)?[0-9][0-9]*(\.[0-9]*)?$")]
            Integer,
            //[StringValue(@"(^[-+]?\\d+(,?\\d*)*\\.?\\d*([Ee][-+]\\d*)?$)|(^[-+]?\\d?(,?\\d*)*\\.\\d+([Ee][-+]\\d*)?$)")]
            [StringValue(@"^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$")]
            Number,
            [StringValue(@"^\d+$")]
            Digit,
            [StringValue(@"^[0-9a-zA-Z\s]+$")]
            AlphaNumeric,
            [StringValue(@"(?\w+):\/\/(?<Domain>[\w.]+\/?)\S*")]
            Url,
            [StringValue(@"(?<First>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Second>
		                        2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Third>
		                        2[0-4]\d|25[0-5]|[01]?\d\d?)\.
		                        (?<Fourth>2[0-4]\d|25[0-5]|[01]?\d\d?)")]
            IpAddress,
            [StringValue(@"^[a-zA-Z\s]+$")]
            AlphaBet,
            [StringValue(@"^[a-zA-Z0-9_ -]*$")]
            AlphaNumericWithUnderScore,
            [StringValue(@"((\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*([,])*)*$")]
            MultipleEmail,

        }

        public bool IsMandatory { get; set; }

        public RegularExpressionAttribute(string dataType, bool _isMandatory = true)
            : base(_defaultErrorMessage)
        {
            if (dataType == "Decimal") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.Decimal);
            else if (dataType == "Integer") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.Integer);
            else if (dataType == "Number") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.Number);
            else if (dataType == "Digit") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.Digit);
            else if (dataType == "AlphaNumeric") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.AlphaNumeric);
            else if (dataType == "Url") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.Url);
            else if (dataType == "IpAddress") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.IpAddress);
            else if (dataType == "AlphaBet") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.AlphaBet);
            else if (dataType == "AlphaNumericWithUnderScore") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.AlphaNumericWithUnderScore);
            else if (dataType == "MultipleEmail") _pattern = EnumParser.GetStringValueAttributeValue(EnumReqExp.MultipleEmail);
            ErrorMessage = _defaultErrorMessage;
            IsMandatory = _isMandatory;
        }

        public override string FormatErrorMessage(string name)
        {

            return String.Format(CultureInfo.CurrentUICulture, _defaultErrorMessage, name, "");
        }

        public override bool IsValid(object value)
        {
            // if ((value == null || (string)value == "")) return true;
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }

    }

    public class RegularExpressionValidator : DataAnnotationsModelValidator<RegularExpressionAttribute>
    {
        string _pattern;
        string _RegularExpressionValue;
        bool _isMandatory;
        string _message;

        public RegularExpressionValidator(ModelMetadata metadata, ControllerContext context
            , RegularExpressionAttribute attribute)
            : base(metadata, context, attribute)
        {
            // _RegularExpressionValue = attribute.RegularExpressionValue.ToString();
            _pattern = attribute._pattern;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _RegularExpressionValue);
            _isMandatory = attribute.IsMandatory;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "regex",
            };
            //var rule1 = new ModelClientValidationRule
            //{
            //    ErrorMessage = _message,
            //    ValidationType = "RegularExpression",
            //};
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("regex", _pattern);
            return new[] { rule };

        }
    }
    #endregion

    #region length
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class lengthsAttribute : ValidationAttribute
    {

        private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";

        public int _minCharacters { get; set; }


        public lengthsAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;

        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }

    public class lengthsValidator : DataAnnotationsModelValidator<lengthsAttribute>
    {

        int _minValue;
        string _message;

        public lengthsValidator(ModelMetadata metadata, ControllerContext context
            , lengthsAttribute attribute)
            : base(metadata, context, attribute)
        {
            _minValue = attribute._minCharacters;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _minValue);

        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {

                ErrorMessage = _message,
                ValidationType = "minlength"
            };
            rule.ValidationParameters.Add("minlength", _minValue);

            return new[] { rule };
        }
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// 

    #region Min
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinAttribute : ValidationAttribute
    {

        public const string _defaultErrorMessage = "'{0}' must be greater than or equal to {1}.";
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

            if (value != null && Int32.TryParse(value.ToString(), out boxed))
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

    #region Decimal

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DecimalAttribute : ValidationAttribute
    {


        //string val = EnumParser.GetAttributeValue(EnumParser.enumReqExp.Foo);
        public const string _defaultErrorMessage = "'{0}' must be greater than or equal to {1}.";
        //private const string _pattern = @"^[-+]?\d{1,}(\.\d{1,3})?$";//@"^[+]?\\d*$";
        public readonly string _pattern = @"^[-+]?[0-9]{1,3}(\.[0-9]{1,3})?$";//@"^[+]?\\d*$";
        public bool IsMandatory { get; set; }

        public DecimalAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
            IsMandatory = true;
        }

        public override string FormatErrorMessage(string name)
        {

            return String.Format(CultureInfo.CurrentUICulture, _defaultErrorMessage, name, "");
        }

        public override bool IsValid(object value)
        {
            // if ((value == null || (string)value == "")) return true;
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }

    }

    public class DecimalValidator : DataAnnotationsModelValidator<DecimalAttribute>
    {
        string _pattern;
        string _DecimalValue;
        bool _isMandatory;
        string _message;

        public DecimalValidator(ModelMetadata metadata, ControllerContext context
            , DecimalAttribute attribute)
            : base(metadata, context, attribute)
        {
            // _DecimalValue = attribute.DecimalValue.ToString();
            _pattern = attribute._pattern;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _DecimalValue);
            _isMandatory = attribute.IsMandatory;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "regex",
            };
            //var rule1 = new ModelClientValidationRule
            //{
            //    ErrorMessage = _message,
            //    ValidationType = "Decimal",
            //};
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("regex", _pattern);
            return new[] { rule };

        }
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// 

    #region Max
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class MaxAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' must be less or equal to {1}.";
        public int MaxValue;
        public bool IsMandatory = true;

        public MaxAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, _defaultErrorMessage, name, MaxValue);

        }

        public override bool IsValid(object value)
        {
            if (IsMandatory == false && (value == null || (string)value == "")) return true;
            int valueAsInt = (int)(value == null ? 0 : value);
            return (valueAsInt <= MaxValue);


        }
    }

    public class MaxValidator : DataAnnotationsModelValidator<MaxAttribute>
    {

        int _maxValue;
        bool _isMandatory;
        string _message;

        public MaxValidator(ModelMetadata metadata, ControllerContext context
            , MaxAttribute attribute)
            : base(metadata, context, attribute)
        {

            _maxValue = attribute.MaxValue;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _maxValue);
            _isMandatory = attribute.IsMandatory;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "maxxxx"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("maxxxx", _maxValue);

            return new[] { rule };
        }
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// 

    #region Alphabet
    public class AlphabetAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "Please enter alphabet only.";
        private const string _pattern = @"[a-zA-Z]";
        public bool IsMandatory = true;

        public AlphabetAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
        }

        public override string FormatErrorMessage(string name)
        {
            return _defaultErrorMessage;

        }
        public override bool IsValid(object value)
        {
            // if ((value == null || (string)value == "")) return true;
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }
    }
    public class AlphabetValidator : DataAnnotationsModelValidator<AlphabetAttribute>
    {

        string _email;
        bool _isMandatory;
        string _message;

        public AlphabetValidator(ModelMetadata metadata, ControllerContext context
            , AlphabetAttribute attribute)
            : base(metadata, context, attribute)
        {
            //_email = attribute.Email;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _email);
            _isMandatory = attribute.IsMandatory;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "alphabet"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("alphabet", true);

            return new[] { rule };
        }
    }
    #endregion

   

    #region DateValidation
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RegularExpressionDateAttribute : ValidationAttribute
    {

        private const string _defaultDateErrorMessage = "'{0}' does not match the date pattern {1}.";
        public readonly string _datepattern;
        public enum EnumDateReqExp
        {
            [StringValue(@"((0?[1-9]|[12][0-9]|3[01]))[/|-](0?[1-9]|1[0-2])[/|-]((?:\d{4}|\d{2}))")]
            DDMMYYYY,
            [StringValue(@"(0?[1-9]|1[0-2])[/|-]((0?[1-9]|[12][0-9]|3[01]))[/|-]((?:\d{4}))")]
            MMDDYYYY,
            [StringValue(@"((0?[1-9]|[12][0-9]|3[01]))[/|-](0?[1-9]|1[0-2])[/|-]((?:\d{2}))")]
            DDMMYY,
            [StringValue(@"(0?[1-9]|1[0-2])[/|-]((0?[1-9]|[12][0-9]|3[01]))[/|-]((?:\d{2}))")]
            MMDDYY,
            [StringValue(@"(0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d")]
            DDMMYYYYWS,

        }



        public bool IsDateMandatory { get; set; }
        private string _dateFormat { get; set; }

        public RegularExpressionDateAttribute(string dateFormat)
            : base(_defaultDateErrorMessage)
        {
            if (dateFormat == "DD/MM/YYYY") _datepattern = EnumParser.GetStringValueAttributeValue(EnumDateReqExp.DDMMYYYY);// EnumParser.GetAttributeValue(EnumDateReqExp.DDMMYY);
            else if (dateFormat == "MM/DD/YYYY") _datepattern = EnumParser.GetStringValueAttributeValue(EnumDateReqExp.MMDDYYYY);
            else if (dateFormat == "DD/MM/YY") _datepattern = EnumParser.GetStringValueAttributeValue(EnumDateReqExp.DDMMYY);
            else if (dateFormat == "MM/DD/YY") _datepattern = EnumParser.GetStringValueAttributeValue(EnumDateReqExp.MMDDYY);
            else if (dateFormat == "DD MMM YYYY") _datepattern = EnumParser.GetStringValueAttributeValue(EnumDateReqExp.DDMMYYYYWS);
            ErrorMessage = _defaultDateErrorMessage;
            IsDateMandatory = true;
            _dateFormat = dateFormat;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessage, name, _dateFormat);
        }

        public override bool IsValid(object value)
        {
            DateTime dt = Convert.ToDateTime(value);
            string str = dt.ToShortDateString();
            // if ((value == null || (string)value == "")) return true;
            // string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsDateMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_datepattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }

    }

    public class RegularExpressionDateValidator : DataAnnotationsModelValidator<RegularExpressionDateAttribute>
    {
        string _pattern;
        string _RegularExpressionValue;
        bool _isMandatory;
        string _message;

        public RegularExpressionDateValidator(ModelMetadata metadata, ControllerContext context
            , RegularExpressionDateAttribute attribute)
            : base(metadata, context, attribute)
        {
            // _RegularExpressionValue = attribute.RegularExpressionValue.ToString();
            _pattern = attribute._datepattern;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _RegularExpressionValue);
            _isMandatory = attribute.IsDateMandatory;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "regex",
            };
            //var rule1 = new ModelClientValidationRule
            //{
            //    ErrorMessage = _message,
            //    ValidationType = "RegularExpression",
            //};
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("regex", _pattern);
            return new[] { rule };

        }
    }
    #endregion DateValidation

    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    #region time validation
    public class TimeAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' is not valid";
        private readonly object _typeId = new object();
        public bool IsMandatory;
        public TimeAttribute(string originalProperty, bool isMand)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            IsMandatory = isMand;

        }

        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty);
        }


        public override bool IsValid(object value)
        {
            string _pattern = "^((([0]?[1-9]|1[0-2])(:|\\.)[0-5][0-9]((:|\\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\\.)[0-5][0-9]((:|\\.)[0-5][0-9])?))$";
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }
    }

    public class TimeValidator : DataAnnotationsModelValidator<TimeAttribute>
    {
        bool _isMandatory;
        string _message;
        string regexp = "^((([0]?[1-9]|1[0-2])(:|\\.)[0-5][0-9]((:|\\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\\.)[0-5][0-9]((:|\\.)[0-5][0-9])?))$";

        public TimeValidator(ModelMetadata metadata, ControllerContext context
            , TimeAttribute attribute)
            : base(metadata, context, attribute)
        {
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName);
            _isMandatory = attribute.IsMandatory;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "regex"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("regex", regexp);

            return new[] { rule };



        }
    }
    #endregion

    public class CompareGreaterThanValuesAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' is not valid";
        private readonly object _typeId = new object();
        public bool IsMandatory;
        public string maxProperty { get; private set; }
        public string minProperty { get; private set; }

        public CompareGreaterThanValuesAttribute(string _minProperty, string _maxProperty, bool isMand)
            : base(_defaultErrorMessage)
        {
            maxProperty = _maxProperty;
            minProperty = _minProperty;
            IsMandatory = isMand;

        }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                maxProperty);
        }


        public override bool IsValid(object value)
        {

            try
            {
                //assuming validate only when class attribute defined, not field attribute.
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
                object CompareValue = properties.Find(minProperty, true /* ignoreCase */).GetValue(value);
                object PropertyValue = properties.Find(maxProperty, true /* ignoreCase */).GetValue(value);

                if (IsMandatory == false && CompareValue == null && PropertyValue == null)
                {
                    return true;
                }
                return Convert.ToDecimal(PropertyValue) > Convert.ToDecimal(CompareValue);
            }
            catch
            {
                return true;
            }

        }
    }

    public class CompareGreaterThanValuesValidator : DataAnnotationsModelValidator<CompareGreaterThanValuesAttribute>
    {
        bool _isMandatory;
        string _message;
        string _minProperty;

        public CompareGreaterThanValuesValidator(ModelMetadata metadata, ControllerContext context
            , CompareGreaterThanValuesAttribute attribute)
            : base(metadata, context, attribute)
        {
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName);
            _isMandatory = attribute.IsMandatory;
            _minProperty = attribute.minProperty;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "GreaterThan"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            //Attribute.ComValue1,Attribute.ComValue2

            rule.ValidationParameters.Add("GreaterThan", "#" + _minProperty);

            return new[] { rule };



        }
    }

    public enum CompareToOperation
    {
        EqualTo,
        LessThan,
        GreaterThan
    }

    public class CompareToAttribute : ValidationAttribute
    {
        CompareToOperation _Operation;
        string _ComparisionPropertyName1;
        string _ComparisionPropertyName2;

        public CompareToAttribute(CompareToOperation operation, string comparisonPropertyName1, string comparisonPropertyName2)
        {
            _Operation = operation;
            _ComparisionPropertyName1 = comparisonPropertyName1;
            _ComparisionPropertyName2 = comparisonPropertyName2;
        }

        private static IComparable GetComparablePropertyValue(object obj, string propertyName)
        {
            if (obj == null) return null;
            var type = obj.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo == null) return null;
            return propertyInfo.GetValue(obj, null) as IComparable;
        }

        public override bool IsValid(object value)
        {
            var comp1 = GetComparablePropertyValue(value, _ComparisionPropertyName1);
            var comp2 = GetComparablePropertyValue(value, _ComparisionPropertyName2);

            if (comp1 == null && comp2 == null)
                return true;

            if (comp1 == null || comp2 == null)
                return false;

            var result = comp1.CompareTo(comp2);

            switch (_Operation)
            {
                case CompareToOperation.LessThan: return result == -1;
                case CompareToOperation.EqualTo: return result == 0;
                case CompareToOperation.GreaterThan: return result == 1;
                default: return false;
            }
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, name);
        }

    }

    #region compare two fields value are equal
    public class CompareEqualsToValuesAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' is not valid";
        private readonly object _typeId = new object();
        public bool IsMandatory;//= true;
        public string maxProperty { get; private set; }
        public string minProperty { get; private set; }

        public CompareEqualsToValuesAttribute(string _sourceProperty, string _targetProperty, bool isMand)
            : base(_defaultErrorMessage)
        {
            maxProperty = _targetProperty;
            minProperty = _sourceProperty;
            IsMandatory = isMand;
        }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                maxProperty);
        }


        public override bool IsValid(object value)
        {

            try
            {
                //assuming validate only when class attribute defined, not field attribute.
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
                object CompareValue = properties.Find(minProperty, true /* ignoreCase */).GetValue(value);
                object PropertyValue = properties.Find(maxProperty, true /* ignoreCase */).GetValue(value);

                if (IsMandatory == false && CompareValue == null && PropertyValue == null)
                {
                    return true;
                }
                return (PropertyValue == CompareValue);
            }
            catch
            {
                return true;
            }

        }
    }

    public class CompareEqualsToValuesValidator : DataAnnotationsModelValidator<CompareEqualsToValuesAttribute>
    {
        bool _isMandatory;
        string _message;
        string _sourceProperty;

        public CompareEqualsToValuesValidator(ModelMetadata metadata, ControllerContext context
            , CompareEqualsToValuesAttribute attribute)
            : base(metadata, context, attribute)
        {
            //_message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName,_sourceProperty);
            _isMandatory = attribute.IsMandatory;
            _sourceProperty = attribute.minProperty;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "equalTo"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            //Attribute.ComValue1,Attribute.ComValue2

            rule.ValidationParameters.Add("equalTo", "#" + _sourceProperty);

            return new[] { rule };



        }
    }

    #endregion

    
    #region  Email
    public class EmailAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "Invalid Email Address.";
        private const string _pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
               @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
               @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        public bool IsMandatory = true;

        public EmailAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
        }

        public override string FormatErrorMessage(string name)
        {
            return _defaultErrorMessage;

        }
        public override bool IsValid(object value)
        {
            // if ((value == null || (string)value == "")) return true;
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));


        }
    }
    public class EmailValidator : DataAnnotationsModelValidator<EmailAttribute>
    {

        string _email;
        bool _isMandatory;
        string _message;

        public EmailValidator(ModelMetadata metadata, ControllerContext context
            , EmailAttribute attribute)
            : base(metadata, context, attribute)
        {
            //_email = attribute.Email;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _email);
            _isMandatory = attribute.IsMandatory;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "email"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("email", true);

            return new[] { rule };
        }
    }
    #endregion


    /// <summary>
    /// 
    /// </summary>
    /// 

    #region Multiple Email
    public class MultipleEmailAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "Invalid Email Address.";
        private const string _pattern = @"^[a-z0-9_+-]+(.[a-z0-9_+-]+)*@[a-z0-9-]+(.[a-z-0-9-]+)*.([a-z]{2,4})$";
        public bool IsMandatory = true;

        public MultipleEmailAttribute()
            : base(_defaultErrorMessage)
        {
            ErrorMessage = _defaultErrorMessage;
        }

        public override string FormatErrorMessage(string name)
        {
            return _defaultErrorMessage;
        }
        public override bool IsValid(object value)
        {
            // if ((value == null || (string)value == "")) return true;
            string str = Convert.ToString(value, CultureInfo.CurrentCulture);
            if (IsMandatory == false && string.IsNullOrEmpty(str))
            {
                return true;
            }
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_pattern, System.Text.RegularExpressions.RegexOptions.Singleline);

            return (regexp.IsMatch(str));
        }
    }

    public class MultipleEmailValidator : DataAnnotationsModelValidator<MultipleEmailAttribute>
    {

        string _email;
        bool _isMandatory;
        string _message;

        public MultipleEmailValidator(ModelMetadata metadata, ControllerContext context
            , MultipleEmailAttribute attribute)
            : base(metadata, context, attribute)
        {
            //_email = attribute.Email;
            _message = String.Format(CultureInfo.CurrentUICulture, attribute.ErrorMessage, metadata.DisplayName, _email);
            _isMandatory = attribute.IsMandatory;


        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _message,
                ValidationType = "multipleEmail"
            };
            rule.ValidationParameters.Add("required", (_isMandatory) ? true : false);
            rule.ValidationParameters.Add("multipleEmail", true);

            return new[] { rule };
        }
    }
    #endregion
    /// <summary>
    /// 
    /// </summary>
    /// 

    public static class ATLValidation
    {
        public static void RegisterValidation()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.RegularExpressionAttribute), typeof(ATLTravelPortal.App_Class.Validation.RegularExpressionValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.DecimalAttribute), typeof(ATLTravelPortal.App_Class.Validation.DecimalValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.MinAttribute), typeof(ATLTravelPortal.App_Class.Validation.MinValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.MaxAttribute), typeof(ATLTravelPortal.App_Class.Validation.MaxValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.EmailAttribute), typeof(ATLTravelPortal.App_Class.Validation.EmailValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.lengthsAttribute), typeof(ATLTravelPortal.App_Class.Validation.lengthsValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.RegularExpressionDateAttribute), typeof(ATLTravelPortal.App_Class.Validation.RegularExpressionDateValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.TimeAttribute), typeof(ATLTravelPortal.App_Class.Validation.TimeValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.CompareGreaterThanValuesAttribute), typeof(ATLTravelPortal.App_Class.Validation.CompareGreaterThanValuesValidator));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.CompareEqualsToValuesAttribute), typeof(ATLTravelPortal.App_Class.Validation.CompareEqualsToValuesValidator));

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ATLTravelPortal.App_Class.Validation.MultipleEmailAttribute), typeof(ATLTravelPortal.App_Class.Validation.MultipleEmailValidator));
        }
    }
}
