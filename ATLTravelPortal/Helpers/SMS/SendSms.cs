using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace ATLTravelPortal.Helpers.SMS
{
    public class SendSms
    {
        public static bool Send(string MobileNo, string Message, string AppPrimaryId, string AppName = "Travel Portal", string MessageType = "Aleart") {
           try
                {
            string _Message = System.Web.HttpUtility.UrlEncode(Message);
            string pushUrl = System.Configuration.ConfigurationManager.AppSettings["SMSURL"]+"?MobileNo="+MobileNo+"&Message="+_Message+"&AppName="+AppName+"&AppPrimaryId="+AppPrimaryId+"&MessageType="+MessageType;
            WebClient client = new WebClient();
            var x = client.DownloadString(pushUrl);
            return true;
                }
        catch{ return false;}
                }
    }
}