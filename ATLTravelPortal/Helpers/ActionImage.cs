using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Ajax;
namespace ATLTravelPortal.Helpers
{
    public static class HtmlHelpers
    {

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, object routeValues)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, null, routeValues, new RouteValueDictionary());
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, object routeValues, object htmlanchorAttributes)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlanchorAttributes), null);
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlanchorAttributes, IDictionary<string, object> htmlImageAttributes)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, null, routeValues, htmlanchorAttributes, htmlImageAttributes);
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, string controllerName, object routeValues, object htmlanchorAttributes)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlanchorAttributes), null);
        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlanchorAttributes, object htmlImageAttributes)
        {
            return htmlHelper.ActionImage(imageUrl, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlanchorAttributes), new RouteValueDictionary(htmlImageAttributes));
        }


        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlanchorAttributes, IDictionary<string, object> htmlImageAttributes)
        {
            // get the bare url for the Action using the current
            // request context
            //
            var _url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controllerName, routeValues);

            UrlHelper imageUrlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            imageUrl = imageUrlHelper.Content(imageUrl);

            return GetImageLink(_url, linkText, imageUrl, htmlanchorAttributes, htmlImageAttributes);

        }

        public static string ActionImage(this HtmlHelper htmlHelper, string imageUrl, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlanchorAttributes, IDictionary<string, object> htmlImageAttributes)
        {

            // get the bare url for the Action using the current
            // request context
            //
            var _url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controllerName, routeValues, protocol, hostName);

            UrlHelper imageUrlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            imageUrl = imageUrlHelper.Content(imageUrl);

            return GetImageLink(_url, linkText, imageUrl, htmlanchorAttributes, htmlImageAttributes);

        }
        /// <summary>
        /// /  ActionImage for ajax
        /// </summary>
        public static string ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);
            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions).ToString();
            return link.Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing));

        }





        /// <summary>
        /// Build up the anchor and image tag.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="htmlanchorAttributes">The HTML anchor attributes.</param>
        /// <param name="htmlImageAttributes">The HTML image attributes.</param>
        /// <returns></returns>
        internal static string GetImageLink(string url, string linkText, string imageUrl, IDictionary<string, object> htmlanchorAttributes, IDictionary<string, object> htmlImageAttributes)
        {
            // build up the image link.
            // <a href=\"ActionUrl\"><img src=\"ImageUrl\" alt=\"Your Link Text\" /></a>
            //

            var _linkText = !string.IsNullOrEmpty(linkText) ? HttpUtility.HtmlEncode(linkText) : string.Empty;

            // build the img tag
            //
            TagBuilder _image = new TagBuilder("img");



            _image.MergeAttributes(htmlImageAttributes);
            _image.MergeAttribute("src", imageUrl);
            _image.MergeAttribute("alt", _linkText);
            _image.SetInnerText(null);
            // build the anchor tag
            //
            TagBuilder _link = new TagBuilder("a");
            _link.MergeAttributes(htmlanchorAttributes);
            _link.MergeAttribute("href", url);

            // place the img tag inside the anchor tag.
            //
            _link.InnerHtml = _image.ToString(TagRenderMode.SelfClosing);

            // render the image link.
            //
            return _link.ToString(TagRenderMode.Normal);

        }


        /// <summary>
        /// Merges the 2 source route value dictionaries.
        /// </summary>
        /// <param name="routeValueDictionary1">RouteValueDictionary 1.</param>
        /// <param name="routeValueDictionary2">RouteValueDictionary 2.</param>
        /// <returns></returns>
        internal static RouteValueDictionary MergeRouteValueDictionaries(RouteValueDictionary routeValueDictionary1, RouteValueDictionary routeValueDictionary2)
        {
            var _mergedRouteValues = new RouteValueDictionary();

            if ((routeValueDictionary1 != null) & (routeValueDictionary2 != null))
            {
                foreach (KeyValuePair<string, object> routeElement in routeValueDictionary1)
                {
                    _mergedRouteValues[routeElement.Key] = routeElement.Value;
                }

                foreach (KeyValuePair<string, object> routeElement in routeValueDictionary2)
                {
                    _mergedRouteValues[routeElement.Key] = routeElement.Value;
                }

                return _mergedRouteValues;
            }

            return null;
        }

    }
}