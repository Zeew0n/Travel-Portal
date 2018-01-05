<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<List<ATLTravelPortal.Areas.Airline.Models.PromotionalFareListModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "PromotionalFareSetup" }, new { @class = "linkButton" })%>
                        <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Promotional Fare</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null && Model.Count > 0)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Airline
                    </th>
                    <th>
                        From-To
                    </th>
                    <th>
                        Dept Date/Time
                    </th>
                    <th>
                        Arrival Date/Time
                    </th>
                    <th>
                        Currency/Base Fare/Tax/OtherCharges
                    </th>
                    <th>
                        Effective From
                    </th>
                    <th>
                        Expire On
                    </th>
                    <th>
                        No of Pax
                    </th>
                    <th>
                        Flight No
                    </th>
                    <th>Action</th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.AirlineName %>
                </td>
                <td>
                    [<%:item.FromCity%>-<%:item.ToCity %>]
                </td>
                <td>
                    <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.DepartureDate.ToString())%>/<%:item.DepartureTime %>
                </td>
                <td>
                    <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.ArrivalDate.ToString())%>/<%:item.DepartureTime %>
                </td>
                <td>
                    <%:item.Currency %>/<%:item.BaseFare %>/<%:item.Tax %>/<%:item.OtherCharges %>
                </td>
                <td>
                    <%:item.EffectiveFrom %>
                </td>
                <td>
                    <%:item.ExpireOn %>
                </td>
                <td>
                    <%:item.NoOfPax%>
                </td>
                <td><%:item.FlightNo %></td>
                <td>
                          <p>
                          <%--  <a href="javascript:void(0);" class="details"
                                title="Details"></a>--%>
                                 <a href="/Airline/PromotionalFareSetup/Details/<%:item.PromotionalFareId %>"
                                    class="details" title="Details"></a>
                                <a href="/Airline/PromotionalFareSetup/Edit/<%:item.PromotionalFareId %>"
                                    class="edit" title="Edit"></a>
                                    <a href="/Airline/PromotionalFareSetup/Delete/<%:item.PromotionalFareId %>"
                                        class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                    </a>
                                    
                        </p>
                </td>
            </tr>
            <% } %>
        </table>

        <%} %>
        <% if (Model.Count == 0)
           { %>
        <%Html.RenderPartial("NoRecordsFound"); %>
        <% }%>
    </div>
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
