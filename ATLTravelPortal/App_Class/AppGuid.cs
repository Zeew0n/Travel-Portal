using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.App_Class
{
    public class AppGuid
    {
        /// <summary>
        /// D : outputs: 12345678-1234-1234-1234-123456789abc => 36 characters (Hyphenated, same as ToString()) /n
        /// N : outputs: 12345678123412341234123456789abc => 32 characters (Digits only)
        /// B : outputs: {12345678-1234-1234-1234-123456789abc} => 38 characters (Braces)
        /// P : outputs: (12345678-1234-1234-1234-123456789abc) => 38 characters (Parentheses)
        /// outputs: 12345678-1234-1234-1234-123456789abc  => 36 characters (Hyphenated)
        /// 
        /// </summary>
        /// <param name="Type">Type is GUID : D,N,B,P</param>
        /// <returns></returns>

        public static string NewGuid(char Type)
        {
            string reqType = Type.ToString();
            string guid;
            switch (reqType)
            {
                case "D":
                    guid = Guid.NewGuid().ToString("D");

                    break;
                case "N":
                    guid = Guid.NewGuid().ToString("N");

                    break;
                case "B":
                    guid = Guid.NewGuid().ToString("B");

                    break;
                case "P":
                    guid = Guid.NewGuid().ToString("P");

                    break;
                default:
                    guid = Guid.NewGuid().ToString();

                    break;

            }

            return guid;
        }
    }
}