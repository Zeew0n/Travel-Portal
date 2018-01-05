using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;

namespace ATLTravelPortal.App_Class
{
    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion
    }

    public class SearchFilterAttribute : Attribute
    {
        #region Properties

        private string _columnName;
        private int _dataType;
        /// <summary>
        /// Holds the  WFWorkActivity for a value in an enum.
        /// </summary>
        public string ColumnName { get { return _columnName; } set { _columnName = value; } }
        public int DataType { get { return _dataType; } set { _dataType = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a  WFWorkActivity Attribute
        /// </summary>
        /// <param name="value"></param>
        public SearchFilterAttribute(string ColumnName, int DataType)
        {
            this._columnName = ColumnName;
            this._dataType = DataType;
        }

        #endregion
    }

    public static class EnumParser
    {
        public static string GetStringValueAttributeValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static A[] GetAttributeValue<A>(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            A[] attribs = fieldInfo.GetCustomAttributes(typeof(A), false) as A[];

            // Return the first if there was a match.
            //return attribs.Length > 0 ? attribs[0].StringValue : null;
            return attribs.Length > 0 ? attribs : null;
        }

        public static string GetEnumName<T>(string enumValue)
        {
            return ((T)Enum.Parse(typeof(T), enumValue.ToString(), true)).ToString();
        }

        public static string GetEnumStringValueAttribute<T>(string enumValue) where T : struct
        {
            string enumString = GetEnumName<T>(enumValue);

            string attrStringValue = "";
            if (enumString != null)
            {
                T value = (T)Enum.Parse(typeof(T), enumString, true);

                FieldInfo fi = value.GetType().GetField(value.ToString());

                StringValueAttribute[] attributes =
                    (StringValueAttribute[])fi.GetCustomAttributes(
                    typeof(StringValueAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attrStringValue = attributes[0].StringValue;
                else
                    attrStringValue = value.ToString();
            }
            return attrStringValue;
        }

        public static List<SelectListItem> GetEnumSelectOption<T>(bool TextFromStringValueAttribute = true) where T : struct
        {
            string SelectOptionText = "";
            Type enumType = typeof(T);
            List<SelectListItem> ddlList = new List<SelectListItem>();
            var enumValues = from Enum at
                               in Enum.GetValues(enumType)
                             select new
                             {
                                 Value = (int)Enum.Parse(enumType, at.ToString()),
                                 Text = Enum.Parse(enumType, at.ToString())
                             };

            foreach (var x in enumValues)
            {
                if (TextFromStringValueAttribute == true)
                {
                    SelectOptionText = EnumParser.GetEnumStringValueAttribute<T>(x.Text.ToString());
                }
                else
                {
                    SelectOptionText = x.Text.ToString();
                }
                ddlList.Add(new SelectListItem { Text = SelectOptionText, Value = x.Value.ToString() });
            }

            ddlList = ddlList.OrderBy(x => x.Text).ToList();
            ddlList.Insert(0, new SelectListItem { Text = "---Select---", Value = "" });
            return ddlList;
        }

        public static List<SelectListItem> GetEnumSelectOption(Type enumType)
        {

            List<SelectListItem> ddlList = new List<SelectListItem>();

            var enumValues = from Enum at
                               in Enum.GetValues(enumType)
                             select new
                             {
                                 Value = (int)Enum.Parse(enumType, at.ToString()),
                                 Text = Enum.Parse(enumType, at.ToString())
                             };

            foreach (var x in enumValues)
            {
                ddlList.Add(new SelectListItem { Text = x.Text.ToString(), Value = x.Value.ToString() });
            }

            ddlList = ddlList.OrderBy(x => x.Text).ToList();
            ddlList.Insert(0, new SelectListItem { Text = "---Select---", Value = "" });
            return ddlList;
        }


        public static int GetValueofEnumMember(Type enumType, string memeberName)
        {
            return (int)Enum.Parse(enumType, memeberName);
        }
    }

}