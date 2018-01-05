using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using System.Data.SqlClient;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusGeneralRepository
    {
        public static int DefaultPageSize = 30;
        public static BusMessageModel CatchException(Exception ex = null)
        {
            BusMessageModel _res = new BusMessageModel();
            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Source != null)
                    {
                        if (ex.InnerException.Source == ".Net SqlClient Data Provider")
                        {
                            SqlException sql = (SqlException)ex.InnerException;
                            _res.MsgNumber = sql.Number;
                            _res.ActionMessage = SqlErrorMessage(sql);
                            _res.MsgType = 2;
                            _res.MsgStatus = true;
                        }
                        else
                        {
                            _res.MsgNumber = 50000;
                            _res.ActionMessage = Resources.SQLErrorMessage.Error;
                            _res.MsgType = 3;
                            _res.MsgStatus = true;
                        }
                    }
                    else
                    {
                        _res.MsgNumber = 50000;
                        _res.ActionMessage = Resources.SQLErrorMessage.Error;
                        _res.MsgType = 3;
                        _res.MsgStatus = true;
                    }

                }
                else
                {
                    _res.MsgNumber = 50000;
                    _res.ActionMessage = Resources.SQLErrorMessage.Error;
                    _res.MsgType = 3;
                    _res.MsgStatus = true;
                }
            }
            else
            {
                _res.MsgNumber = 1005;
                _res.ActionMessage = Resources.Message.UnCompleteForm;
                _res.MsgType = 3;
                _res.MsgStatus = true;
            }
            return _res;
        }
        public static string OperatorLogoPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["BusOperatorLogoPath"].ToString(); }
        }
        public static string OperatorLogoUrl
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["BusOperatorLogoUrl"].ToString(); }
        }
        public static string RandomProductImageName
        {
            get{ return Guid.NewGuid().ToString();}
        }
        public static string SqlErrorMessage(SqlException ex)
        {
            if (ex.Number == 50000)
                return ex.Message;
            else if (ex.Number == 241)
                return Resources.SQLErrorMessage.Error241;
            else if (ex.Number == 242)
                return Resources.SQLErrorMessage.Error242;
            else if (ex.Number == 245)
                return Resources.SQLErrorMessage.Error245;
            else if (ex.Number == 2627)
                return Resources.SQLErrorMessage.Error2627;
            else if (ex.Number == 8152)
                return Resources.SQLErrorMessage.Error8152;
            else if (ex.Number == 547)
                return Resources.SQLErrorMessage.Error547;
            else
                return Resources.SQLErrorMessage.Error;
        }
        public static BusMessageModel ActionMessage
        {
            get { return (BusMessageModel)HttpContext.Current.Session["ActionMessage"]; }
            set { HttpContext.Current.Session["ActionMessage"] = value; }
        }
        public static void SetRequestPageRow()
        {
            try
            {
                if (HttpContext.Current.Request.QueryString["pageRow"] != null)
                {
                    int pageRow = Convert.ToInt32(HttpContext.Current.Request.QueryString["pageRow"]);
                    DefaultPageSize = pageRow <= 0 ? DefaultPageSize : pageRow;
                }
            }
            catch
            {
                //do nothing
            }
        }
    }
}