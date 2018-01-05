using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ATLTravelPortal.Helpers
{
    public static class TempDataExtensions
    {
        public static void Keep(this TempDataDictionary tempData, string key)
        {
            var value = tempData[key];
            tempData[key] = value;
        }
    }
}