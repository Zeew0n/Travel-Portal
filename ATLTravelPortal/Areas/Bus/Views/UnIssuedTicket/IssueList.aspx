<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>
 <%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <%-- <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Booked Ticket Report
            </h3>
        </div>
    </div>

      <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
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
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <% } %>
--%>
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
                        Action
                    </th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.TabularList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.BusMasterName%>
                </td>
                <td>
                    [<%:item.FromCityName%>-<%:item.ToCityName %>]
                </td>
                <td>
                    <%:item.DepartureDate.ToShortDateString() %>
                </td>
                <td>
                    <%:item.DepartureTime%>
                </td>
                <td>
                    <%:item.BusCategoryName %>
                </td>
                <td>
                    <%:item.Type %>
                </td>
                <td>
                    <p>
                      <%:Html.ActionLink("Detail", "Details", new { id = item.BusPNRId, controller = "BusSchedule", area = "Bus" }, new { title = "Details" })%>
                      <%:Html.ActionLink("Itinerary", "Detail", new { id = item.BusPNRId, controller = "Itinerary", area = "Bus" }, new { title = "Edit"})%>
                      <%:Html.ActionLink("Print", "Print", new { id = item.BusPNRId, controller = "Itinerary", area = "Bus" }, new { title = "Edit", target = "_blank" })%>
                    </p>
                </td>
            </tr>
            <% } %>
        </table>
                <%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize)
                    {%>
        <div class="pager">
            <%:MvcHtmlString.Create(ATLTravelPortal.Helpers.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount))%>
        </div>
        <%}
        } %>
        <% if (Model.TabularList.Count == 0)
           { %>
        <%Html.RenderPartial("NoRecordsFound"); %>
        <% }%>
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
