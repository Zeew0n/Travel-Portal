using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel;

namespace ATLTravelPortal.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescriptionByValue(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static IList<EnumDescription> GetEnumDescription(Type enumType)
        {
            List<EnumDescription> enumList = new List<EnumDescription>();
            if (enumType.IsEnum)
            {
                foreach (FieldInfo field in enumType.GetFields())
                {
                    if (field.IsDefined(typeof(DescriptionAttribute), false))
                    {
                        DescriptionAttribute desc = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
                        enumList.Add(new EnumDescription() { Name = field.Name, Description = desc.Description });
                    }
                }
            }
            return enumList;
        }

    }
    public class EnumDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }



    public enum BookingSourceEnum
    {

        [Description("Air Arabia")]
        AirArabia = 1,
        [Description("Abacus")]
        Abacus = 2,
        [Description("Galileo")]
        Galileo = 3,
       
    }

    public enum IndianLccBookingSourceEnum
    {

        [Description("TBO")]
        TBO = 1,
        [Description("Indigo Normal")]
        IndigoNormal = 2,
        [Description("Indigo Special")]
        IndigoSpecial = 3,
        [Description("GoAir Normal")]
        GoAirNormal = 4,
        [Description("GoAir Special")]
        GoAirSpecial = 5,
        [Description("SpiceJet")]
        SpiceJet = 6,
        [Description("Tiger")]
        Tiger = 7,
        [Description("Herms")]
        Herms = 8,
        [Description("Amadeus")]
        Amadeus = 9,
        [Description("Galileo")]
        Galileo = 10,
        [Description("Indigo Corporate")]
        IndigoCorporate = 11,

    }
}