<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MRCMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.MobileTopupModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
        </ul>
        <h3>
            Report <span>&nbsp;</span><strong>Mobile Topup</strong>
        </h3>
    </div>
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
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.AgentId)%></label>
                    <%:Html.DropDownListFor(model => model.AgentId,Model.Agents, "---ALL---")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.ServiceProviderId)%></label>
                    <%:Html.DropDownListFor(model => model.ServiceProviderId,Model.ServiceProviders, "---ALL---")%>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.IsSucces)%></label>
                        <%:Html.DropDownListFor(model => model.IsSucces,Model.SuccessFlags, "---ALL---")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
            <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
        </div>
    </div>
    <% } %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.MobileTopupModelList != null && Model.MobileTopupModelList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Agent Name
                    </th>
                    <th>
                        Service Provider
                    </th>
                    <th>
                        Sales Price
                    </th>
                    <th>
                        Is Success
                    </th>
                    <th>
                        Status Message
                    </th>
                    <th>
                        Sales Date
                    </th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.MobileTopupModelList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.AgentName %>
                </td>
                <td>
                    <%:item.ServiceProvierName%>
                </td>
                <td>
                    <%: item.SalesPrice%>
                </td>
                <td>
                    <%: item.IsSucces%>
                </td>
                <td>
                    <%:item.StatusMessage %>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.SalesDate.ToString()) %>
                </td>
            </tr>
            <% } %>
            <%}
            %>
        </table>
        <% if (Model.MobileTopupModelList.ToList().Count == 0)
           { %>
        <%Html.RenderPartial("NoRecordsFound"); %>
        <% }%>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var dates = $("#FromDate, #ToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "FromDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });
    </script>
</asp:Content>
