using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Web;
namespace ATLTravelPortal.Areas.Bus.Pagination
{
    public class Pager
    {
        private ViewContext viewContext;
        private readonly int pageSize;
        private readonly int currentPage;
        private readonly int totalItemCount;
        private readonly RouteValueDictionary linkWithoutPageValuesDictionary;

        public Pager(ViewContext viewContext, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary, bool IsDdl, bool IsTotal, string action,string virtualPath)
        {
            this.viewContext = viewContext;
            this.pageSize = pageSize;
            this.currentPage = Math.Ceiling(Convert.ToDecimal (totalItemCount) / Convert.ToDecimal(pageSize)) >= currentPage?currentPage:1;
            this.totalItemCount = totalItemCount;
            //this.linkWithoutPageValuesDictionary = valuesDictionary;

            //get paramter from urlquery string
            RouteValueDictionary tRVD = new RouteValueDictionary(viewContext.RouteData.Values);
            foreach (string key in HttpContext.Current.Request.QueryString.Keys)
            {
                if (key != null)
                {
                    if (!tRVD.ContainsValue(tRVD[key]))
                    {
                        if (key != "page" && key != "pageRow")
                            tRVD[key] = HttpContext.Current.Request.QueryString[key].ToString();
                    }
                }
            }

            //get parameter from routervaluedictionary
            if (valuesDictionary != null)
            {
                foreach (var items in valuesDictionary)
                {
                    if (!tRVD.ContainsKey(items.Key))
                    {
                        tRVD.Add(items.Key, items.Value);
                    }
                }
            }


            this.linkWithoutPageValuesDictionary = tRVD;
        }

        public string RenderHtml(bool IsDdl, bool IsTotal, string action,string virtualPath)
        {
            int pageCount = (int)Math.Ceiling(this.totalItemCount / (double)this.pageSize);
            int nrOfPagesToDisplay = 10;

            var sb = new StringBuilder();

            // Previous
            if (this.currentPage > 1)
            {
                sb.Append(GeneratePageLink("&lt;", this.currentPage - 1, action, virtualPath));
            }
            else
            {
                sb.Append("<span class=\"disabled\">&lt;</span>");
            }

            int start = 1;
            int end = pageCount;

            if (pageCount > nrOfPagesToDisplay)
            {
                int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                int below = (this.currentPage - middle);
                int above = (this.currentPage + middle);

                if (below < 4)
                {
                    above = nrOfPagesToDisplay;
                    below = 1;
                }
                else if (above > (pageCount - 4))
                {
                    above = pageCount;
                    below = (pageCount - nrOfPagesToDisplay);
                }

                start = below;
                end = above;
            }

            if (start > 3)
            {
                sb.Append(GeneratePageLink("1", 1, action, virtualPath));
                sb.Append(GeneratePageLink("2", 2, action, virtualPath));
                sb.Append("...");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == this.currentPage)
                {
                    sb.AppendFormat("<span class=\"current\"> {0}</span>", i);
                }
                else
                {
                    sb.Append(GeneratePageLink(i.ToString(), i, action, virtualPath));
                }
            }
            if (end < (pageCount - 3))
            {
                sb.Append("...");
                sb.Append(GeneratePageLink((pageCount - 1).ToString(), pageCount - 1, action, virtualPath));
                sb.Append(GeneratePageLink(pageCount.ToString(), pageCount, action, virtualPath));
            }

            // Next
            if (this.currentPage < pageCount)
            {
                sb.Append(GeneratePageLink("&gt;", (this.currentPage + 1), action, virtualPath));
            }
            else
            {
                sb.Append("<span class=\"disabled\">&gt;</span>");
            }
            if (IsDdl == true)
            {
                sb.AppendFormat("<select id=\"recordDisplayCount\" style=\"width:50px\" onchange=\"RedirectPath('" + GeneratePageCountDdlLink(this.currentPage, virtualPath) + "')\" >" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 5) ? "selected" : "") + ">5</option>" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 10) ? "selected" : "") + ">10</option>" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 20) ? "selected" : "") + ">20</option>" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 30) ? "selected" : "") + ">30</option>" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 50) ? "selected" : "") + ">50</option>" +
                                       "<option " + ((ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize == 100) ? "selected" : "") + ">100</option>" +
                                       "</select>");
            }
            if (IsTotal == true)
            {
                sb.AppendFormat("<span class=\"totalRecord\"> Total Record(s)  ({0})</span>", this.totalItemCount);
            }
            return sb.ToString();
        }

        private string GeneratePageLink(string linkText, int pageNumber, string action,string virtualPath)
        {

            var pageLinkValueDictionary = new RouteValueDictionary(this.linkWithoutPageValuesDictionary);


            pageLinkValueDictionary.Add("page", pageNumber);
            //var virtualPathData = this.viewContext.RouteData.Route.GetVirtualPath(this.viewContext, pageLinkValueDictionary);
            var virtualPathData = RouteTable.Routes.GetVirtualPath(this.viewContext.RequestContext, pageLinkValueDictionary);
            var path = "";
            if (virtualPath.Trim() != "")
            {
                path = virtualPath + "?page=" + pageNumber.ToString();
            }
            else
            {
                path = String.Format(action, pageNumber);
            }

            //"javascript:nextPage('"+ pageNumber +"')";
            if (virtualPathData != null)
            {
                string linkFormat = "<a  href=\"{0}\"><span class=\"pageActiveLink\">{1}</span></a>";
                if (action.Trim() != "")
                {
                    return String.Format(linkFormat, path, linkText);
                }
                else
                {
                    if (virtualPath.Trim() != "")
                    {
                        return String.Format(linkFormat, path, linkText);
                    }
                    else
                    {
                        return String.Format(linkFormat, virtualPathData.VirtualPath, linkText);
                    }
                    
                }


            }
            else
            {
                return null;
            }
        }

        private string GeneratePageCountDdlLink(int pageNumber, string virtualPath)
        {



            var pageLinkValueDictionary = new RouteValueDictionary(this.linkWithoutPageValuesDictionary);


            pageLinkValueDictionary.Add("page", 1);
            //var virtualPathData = this.viewContext.RouteData.Route.GetVirtualPath(this.viewContext, pageLinkValueDictionary);
            var virtualPathData = RouteTable.Routes.GetVirtualPath(this.viewContext.RequestContext, pageLinkValueDictionary);
            if (virtualPath.Trim()!="")
            {
                return virtualPath + "?page=" + pageNumber.ToString();
            }
            else if (virtualPathData != null)
            {
                return virtualPathData.VirtualPath;
            }
            else
            {
                return null;
            }
        }
    }
}