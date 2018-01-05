using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ATLTravelPortal.Helpers
{
    public static class RandomGenerator
    {
        public static string RandomString(Random r, int len)
        {
            string str
            = "1234567890";
            StringBuilder sb = new StringBuilder();

            while ((len--) > 0)
                sb.Append(str[(int)(r.NextDouble() * str.Length)]);

            return sb.ToString();
        }
        public static string GenerateRandomAlphanumeric()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
            Enumerable.Repeat(chars, 6)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray());
            return result;
        }

    }
}