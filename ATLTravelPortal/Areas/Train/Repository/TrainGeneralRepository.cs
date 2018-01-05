using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Train.Models;

namespace ATLTravelPortal.Areas.Train.Repository
{
    public class TrainGeneralRepository
    {
        public static TrainMessageModel Message
        {
            get { return (TrainMessageModel)System.Web.HttpContext.Current.Session["TrainMessage"]; }
            set { System.Web.HttpContext.Current.Session["TrainMessage"] = value; }
        }
        public static int DefaultPageSize
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PageSize"] == null)
                {
                    return 20;
                }
                else { return (int)System.Web.HttpContext.Current.Session["PageSize"]; }
            }
            set { System.Web.HttpContext.Current.Session["PageSize"] = value; }
        }
        public static string TrainPNRLocation
        {
            get {
                var xx = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationSettings.GetConfig("TrainSetting");
                return xx["PNRLocation"].ToString();
            }
        }
        public static string RandomFileName
        {
            get { return Guid.NewGuid().ToString(); }
        }
        public static List<string> PNRFileFormat
        {
            get
            {
                var xx = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationSettings.GetConfig("TrainSetting");
                var x = xx["PNRFileFormat"].ToString().Split(',');
                List<string> ValidExtensions = new List<string>();
                foreach (var item in x) {
                    ValidExtensions.Add(item);
                }
                return ValidExtensions;
            }
        }
    }
}