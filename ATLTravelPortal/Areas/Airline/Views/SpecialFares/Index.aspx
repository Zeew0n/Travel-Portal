﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SpecialFaresModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "SpecialFares" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Special Fare</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    From City
                </th>
                <th>
                    To City
                </th>
                <th>
                    Airline
                </th>
                <th>
                    Regular Fare
                </th>
                <th>
                    Special Fare
                </th>
                <th>
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.ListSpecialFares)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:item.FromCityName%>
                    </td>
                    <td>
                        <%: item.ToCityName %>
                    </td>
                    <td>
                        <%: item.AirlineName %>
                    </td>
                    <td>
                        <%: item.RegularFare %>
                    </td>
                    <td>
                        <%: item.SpecialFare %>
                    </td>
                    <td>
                        <a href="/Airline/SpecialFares/Edit/<%:item.SpecialFareId %>" class="edit" title="Edit">
                        </a><a href="/Airline/SpecialFares/Detail/<%:item.SpecialFareId %>" class="details"
                            title="Detail"></a><a href="/Airline/SpecialFares/Delete/<%:item.SpecialFareId %>"
                                class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                            </a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
           <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.ListSpecialFares.PageSize, ViewData.Model.ListSpecialFares.PageNumber, ViewData.Model.ListSpecialFares.TotalItemCount)%>
       </div>
    </div>
</asp:Content>
