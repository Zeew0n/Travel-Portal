using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Helpers
{
    public static class TBOEnumHelper
    {

        //If Description is not used.
        public static SelectList ToSelectList(this Enum enumeration)
        {
            var list = (from Enum d in Enum.GetValues(enumeration.GetType())
                        select new { ID = (int)Enum.Parse(enumeration.GetType(), Enum.GetName(enumeration.GetType(), d)), Name = d.ToString() }).ToList();
            return new SelectList(list, "ID", "Name");
        }
        
        //If Description is used.


        public static SelectList ToSelectList<T>()
        {
            var type = typeof(T);

            if (type.IsEnum)
            {
                var list = new List<object>();

                var members = type.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);

                foreach (var memberInfo in members)
                {

                    var attribute = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

                    var value = memberInfo.Name;

                    list.Add(attribute != null
                        ? new { Text = attribute.Description, Value = value }
                        : new { Text = value, Value = value });

                }
                return new SelectList(list, "Value", "Text");
            }

            throw new Exception("this method is purely for enumerations.");
        }

        public static T Parse<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}