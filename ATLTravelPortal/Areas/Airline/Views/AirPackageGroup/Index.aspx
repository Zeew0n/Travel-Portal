<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageGroupModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Group Package</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li><a href="/Airline/AirPackageGroup/Create" class="new linkButton" title="New">New
                    Group Package</a> </li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Package Management</a> <span>&nbsp;</span><strong>Package
                    Group</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                        Country
                    </th>
                    <th>
                        City
                    </th>
                    <th>
                        Group Name
                    </th>
                    <th>
                        URL
                    </th>
                    <th>
                        Destination
                    </th>
                    <th>
                        Images
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <%if (Model != null)
              {%>
            <%var sno = 0;

              foreach (var item in Model.PackageList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";                  
                    
            %>
            <tr>
                <td>
                    <%:item.SNO %>
                </td>
                <td>
                    <%:item.CountryName%>
                </td>
                <td>
                    <%:item.CityName==null?"":item.CityName %>
                </td>
                <td>
                    <%:item.GroupName %>
                </td>
                <td>
                    <%:item.URL %>
                </td>
                <td>
                    <% string messagetext = StringExtensionMethods.StripTagsRegexCompiled(item.Destination); %>
                    <%=((messagetext.Trim().Count()> 100 ? messagetext.Trim().Substring(0, 100) : messagetext.Trim())) %>
                </td>
                <%-- <%if (item.Destination.Count() > 200)
                      {%>
                     <% var aaa = item.Destination.Substring(0,160); %>
                    <td><%=HttpUtility.HtmlDecode(aaa)%></td>
             
                  
                    <%} %>

                    <%  else { %>
                         <td><%=HttpUtility.HtmlDecode(item.Destination) %></td>
                        <% } %>--%>
                <td>
                    <a href="/Airline/AirPackageGroupImage/Index/<%:item.PackageGroupID %>">Images</a>
                </td>
                <td>
                    <%--<a href="/Airline/AirPackageGroup/Details/<%:item.PackageGroupID %>" class="details" title="Details"></a>--%>
                    <a href="/Airline/AirPackageGroup/Edit/<%:item.PackageGroupID %>" class="edit" title="Edit">
                    </a><a href="/Airline/AirPackageGroup/Delete/<%:item.PackageGroupID %>" class="delete"
                        title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                    </a>
                </td>
            </tr>
            <%} %>
            <%} %>
        </table>
          <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.PackageList.PageSize, ViewData.Model.PackageList.PageNumber, ViewData.Model.PackageList.TotalItemCount)%>
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
