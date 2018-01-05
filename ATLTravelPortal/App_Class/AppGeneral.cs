using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;




namespace ATLTravelPortal.App_Class
{
    public class AppGeneral 
    {
        public static int DefaultPageSize = ConfigurationManager.AppSettings["DefaultPageSize"] == null ? 30: Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageSize"]);
        public static DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}