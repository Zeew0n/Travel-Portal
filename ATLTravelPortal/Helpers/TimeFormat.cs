using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Helpers
{
    public class TimeFormat
    {
        public static string GetFormattedTime(string time)
        {
            if (time.Length <= 3)
            {
                time = time.PadLeft(4, '0');
            }

            var dateTime = DateTime.ParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture);

            return dateTime.ToString("HH:mm");
        }

        public static String ConvertToHourMin(string minus)
        {
            int tmp;
            var isInMinute = int.TryParse(minus.Trim(), out tmp);

            if (!isInMinute)
                return minus;           

            int mins = !string.IsNullOrEmpty(minus) ? int.Parse(minus) : 0;
            int hours = (mins - mins % 60) / 60;
            int minutes = (mins - hours * 60);

            //return hours + (hours > 1 ? " Hrs" : " Hr") + " " + minutes + (minutes > 1 ? " Mins" : " Min");
            return (hours > 1 ? hours + " Hrs" : (hours == 1 ? hours + " Hr" : "")) + " " + (minutes > 1 ? minutes + " Mins" : (minutes == 1 ? minutes + " Min" : ""));
        }


        public static string GetTotalDuration(string d1, string d2)
        {
            if (d1.Length <= 3)
            {
                d1 = d1.PadLeft(4, '0');
            }

            var date1 = DateTime.ParseExact(d1, "HHmm", System.Globalization.CultureInfo.CurrentCulture);

            if (d2.Length <= 3)
            {
                d2 = d2.PadLeft(4, '0');
            }

            var date2 = DateTime.ParseExact(d2, "HHmm", System.Globalization.CultureInfo.CurrentCulture);


            int[] TimeArry1 = { date1.Hour, date1.Minute, date1.Second };
            int[] TimeArray2 = { date2.Hour, date2.Minute, date2.Second };

            int tHours1 = TimeArry1[0];
            int tHours2 = TimeArray2[0];

            int tMinutes1 = TimeArry1[1];
            int tMinutes2 = TimeArray2[1];

            int tSeconds1 = TimeArry1[2];
            int tSeconds2 = TimeArray2[2];

            return (tHours1 + tHours2).ToString() + "h " + (tMinutes1 + tMinutes2).ToString() + "m";
        }

        public static string GetTimeDifference(DateTime d1, DateTime d2)
        {
            return d1.Subtract(d2).ToString();
        }
        public static String DateFormat(string date)
        {
            var xxx = !string.IsNullOrEmpty(date) ?
                Convert.ToDateTime(date).ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]) :
                null;//DateTime.Now.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"]);
            return xxx;
        }
        public static string GetAMPMTimeFormat(string time)
        {
            var dateTime = DateTime.Parse(time);
            return dateTime.ToString("hh:mm tt");
        }


        public static string GetTBOFormattedTime(string time)
        {
            string[] timeArray = new string[2];
            if (!string.IsNullOrEmpty(time))
                timeArray = time.Split(':');

            string hr, min;
            hr = min = string.Empty;

            if (timeArray.Length > 1)
            {
                hr = timeArray[0];
                min = timeArray[1];
            }
            else if (timeArray.Length == 1)
            {
                hr = timeArray[0];
            }
            hr = hr.PadLeft(2, '0');
            min = min.PadLeft(2, '0');
            return hr + ":" + min;
        }
    }
}