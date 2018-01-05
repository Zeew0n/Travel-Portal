using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using ATLTravelPortal.Areas.Hotel.Pagination;

namespace ATLTravelPortal.Areas.Hotel.Pagination
{
	public static class PagingExtensions
	{
		#region HtmlHelper extensions

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, bool IsDdl , bool IsTotal,string action,string virtualPath)
		{
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, null, IsDdl, IsTotal, action, virtualPath);
		}

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, bool IsDdl, bool IsTotal, string action, string virtualPath)
		{
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, null, true, true, action, virtualPath);
		}

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, object values, bool IsDdl, bool IsTotal, string action, string virtualPath)
		{
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, new RouteValueDictionary(values), IsDdl, IsTotal, action, virtualPath);
		}

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, object values, bool IsDdl, bool IsTotal, string action, string virtualPath)
		{
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, new RouteValueDictionary(values), IsDdl, IsTotal, action, virtualPath);
		}

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary, bool IsDdl, bool IsTotal, string action, string virtualPath)
		{
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, valuesDictionary, IsDdl, IsTotal, action, virtualPath);
		}

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, RouteValueDictionary valuesDictionary, bool IsDdl, bool IsTotal, string action, string virtualPath)
		{
			if (valuesDictionary == null)
			{
				valuesDictionary = new RouteValueDictionary();
			}
			if (actionName != null)
			{
				if (valuesDictionary.ContainsKey("action"))
				{
					throw new ArgumentException("The valuesDictionary already contains an action.", "actionName");
				}
				valuesDictionary.Add("action", actionName);
			}
            var pager = new Pager(htmlHelper.ViewContext, pageSize, currentPage, totalItemCount, valuesDictionary, IsDdl, IsTotal, action, virtualPath);
            return pager.RenderHtml(IsDdl, IsTotal, action, virtualPath);
		}

		#endregion

		#region IQueryable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion

		#region IEnumerable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion
	}
}