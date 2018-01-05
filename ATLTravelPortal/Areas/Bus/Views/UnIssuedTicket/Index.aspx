<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
     <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Unissued Tickets</strong>
            </h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AgentId)%></label>
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"], "---ALL---")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <ul class="buttons-panel">
                    <li>
                        <input type="submit" value="Search" class="btn3" /></li>
                </ul>
            </div>
        </div>
    </div>
  
    <div class="contentGrid">
        <% if (Model != null && Model.TabularList.Count > 0)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        Operator Name
                    </th>
                    <th>
                        From - To
                    </th>
                    <th>
                        Departure Date
                    </th>
                    <th>
                        Departure Time
                    </th>
                    <th>
                        Category
                    </th>
                    <th>
                        Type
                    </th>
                     <th>
                        
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.TabularList)
                {

                    //sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:item.Sno%>
                </td>
                <td>
                    <%:item.FullName %>
                </td>
                <td>
                    <%: item.BusMasterName%>
                </td>
                <td>
                    [<%:item.FromCityName%>-<%:item.ToCityName%>]
                </td>
                <td>
                    <%:TimeFormat.DateFormat( item.DepartureDate.ToString())%>
                </td>
                <td>
                    <%:TimeFormat.GetAMPMTimeFormat( item.DepartureTime.ToString())%>
                </td>
                <td>
                    <%:item.BusCategoryName%>
                </td>
                <td>
                    <%:item.Type%>
                </td>
                 <td>
                    <% if (item.TicketStatusId == 28)
               {%>
             <img src="../../../../Content/images/b2c.png" /><%}
               else
               {%>
             <img src="../../../../Content/images/b2b.png" /><%} %>
                </td>
                <td style="width:100px;">
                    <p>
                        <a href="/Bus/UnIssuedTicket/Details/<%=item.BusPNRId %>"  title="Details"> Detail
                        </a>&nbsp;&nbsp;<a href="/Bus/UnIssuedTicket/Edit/<%:item.BusPNRId %>"  title="Edit"> Edit
                        </a>&nbsp;&nbsp;<a href="/Bus/UnIssuedTicket/Edit/<%:item.BusPNRId %>"  title="Edit"> Issue
                        </a>
                    </p>
                </td>
            </tr>
            <% } %>
        </table>
        <%--<%  if (Model.TabularList.TotalItemCount > 0)
                    {%>--%>
        <div class="pager">
        
        <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Bus.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Bus/UnIssuedTicket/Index")))%>
          
        </div>
        <%}
           //}
            %>
        <% if (Model.TabularList.Count == 0)
           { %>
        <%Html.RenderPartial("NoRecordsFound"); %>
        <% }%>

          <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">
    function RedirectPath(url) {
        var rowPageValue = $('#recordDisplayCount').val();
        document.location.href = url + "&pageRow=" + rowPageValue;
    }
    </script>
</asp:Content>
