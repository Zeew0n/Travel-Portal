using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace ATLTravelPortal.App_Class
{
    public class AppSession
    {
        public static int LogUserID
        {
            get
            {
                if (HttpContext.Current.Session["LogUserID"] != null)
                {
                    return (int)HttpContext.Current.Session["LogUserID"];
                }
                else
                {
                    HttpContext.Current.Session["LogUserID"] = 1;
                    return 0;
                }
            }
            set
            {
                try
                {
                    HttpContext.Current.Session.Remove("LogUserID");
                }
                catch { }
                HttpContext.Current.Session["LogUserID"] = value;
            }

        }
    }
}