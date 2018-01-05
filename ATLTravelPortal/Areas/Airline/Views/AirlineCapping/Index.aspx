<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineCappingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Airline Capping List</strong>
        </h3>
    </div>

    <div class="row-1">
        
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                
                    <div>
                        <ul>
                        <li class="float-left" style="margin-right:10px;">
                            <%: Html.Label("GDS") %>
                        <%: Html.DropDownListFor(model => model.ServiceProviderId, new SelectList((List<TravelPortalEntity.ServiceProviders>)ViewData["GDSList"], "ServiceProviderId", "ServiceProviderName"))%>
                        <%: Html.ValidationMessageFor(model => model.ServiceProviderId) %></li>
                        <li class="float-left">
                        <input type="submit" value="Search" class="btn1" />
                        </li><li class="float-left">
                    <input type="button" onclick="document.location.href='/Airline/AirlineCapping/Create'"
                        value="Create"  /></li></ul>
                    </div>
               
            </div>
           
           
        </div>
    </div>

    <%} %>
    
            <%
                if (Model != null)
                {
                    
            %>
            <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Airline
                </th>
                <th>
                    Total Ticket
                </th>
                <th>
                    Action
                </th>
            </thead>
            <% var sno = 0;

               foreach (var item in Model.airlineCappingList)
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
                        <%: item.AirlineName%>
                    </td>
                    <td>
                        <%: item.TotalTicketNumber%>
                    </td>
                    <td>
                        <p>
                            <%--<%:Html.ActionLink(" ","Details",new{controller="AirlineCapping"},new{@class="details",@title="Details"}) %>--%>
                            <%:Html.ActionLink(" ","Edit",new{controller="AirlineCapping",id=item.cappingId},new{@class="edit",@title="Edit"}) %>
                            <%-- <a href="/AirlineCappings/Edit/<%: item.cappingId %>" class="edit" title="Edit"></a>--%>
                            <%--<a href="#" class="delete" title="Delete"></a>--%>

                            <a href="/Airline/AirlineCapping/Delete/<%: item.cappingId %>"
                            class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                        </a>
                        </p>
                    </td>
                </tr>
            </tbody>
            <%}
             } %>
        </table>
    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
