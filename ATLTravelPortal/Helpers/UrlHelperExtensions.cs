using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace ATLTravelPortal.Helpers
{
    public static class UrlHelperExtensions
    {
        internal static Uri ActionFull(this UrlHelper urlHelper, string actionName)
        {
            return new Uri(HttpContext.Current.Request.Url, urlHelper.Action(actionName));
        }

        internal static Uri ActionFull(this UrlHelper urlHelper, string actionName, string controllerName)
        {
            return new Uri(HttpContext.Current.Request.Url, urlHelper.Action(actionName, controllerName));
        }

        /// <summary>
        /// Returns an absolute url for an action
        /// </summary>
        /// <param name="url">UrlHelper</param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static string AbsoluteAction(this UrlHelper url, string action, object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

            string absoluteAction = string.Format("{0}://{1}{2}",
                                                  requestUrl.Scheme,
                                                  requestUrl.Authority,
                                                  url.Action(action, routeValues));

            return absoluteAction;
        }

        ///// <summary>
        ///// Returns an absolute url for an action
        ///// </summary>
        ///// <param name="url">UrlHelper</param>
        ///// <param name="action"></param>
        ///// <param name="controller"></param>
        ///// <returns></returns>
        //public static string AbsoluteAction(this UrlHelper url, string scheme, string controllerName, string action, object routeValues)
        //{
        //    Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

        //    string absoluteAction = string.Format("{0}://{1}{2}",
        //                                          requestUrl.Scheme,
        //                                          requestUrl.Authority,
        //                                          url.Action(action, controllerName, routeValues));

        //    return absoluteAction;
        //}

        /// <summary>
        /// Returns an absolute url for an action
        /// </summary>
        /// <param name="url">UrlHelper</param>
        /// <param name="scheme"></param>
        /// <param name="action"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static string AbsoluteAction(this UrlHelper url, string scheme, string action, object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

            string absoluteAction = string.Format("{0}://{1}{2}",
                                                  scheme,
                                                  requestUrl.Authority,
                                                  url.Action(action, routeValues));

            return absoluteAction;
        }




        public static string AbsolutePath(string originalUrl)
        {
            return originalUrl.Substring(0, GetNthIndex(originalUrl, '/', 3));
        }

        public static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

    }
}