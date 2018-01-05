using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ATLTravelPortal.Helpers
{
    public static class Validator
    {

        public static bool ValidateTime(this String str)
        {
            //Regex checkTime = new Regex("^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            Regex checkTime = new Regex("^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$");
           return checkTime.IsMatch(str);
           
        }
    }
}