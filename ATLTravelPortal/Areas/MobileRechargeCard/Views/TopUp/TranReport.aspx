<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MRCMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.AgentTranModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TranReport
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
            </li>
            <li></li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Report</a> <span>&nbsp;</span><strong>Agent Transactions</strong>
        </h3>
    </div>
    <% Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("TranReport", "TopUp", FormMethod.Post, new { @class = "Validate", enctype = "multipart/form-data" }))
      {%>
    <%: Html.ValidationSummary(true) %>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.FromDate)%>
                        <%:Html.TextBoxFor(model => model.FromDate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ToDate)%>
                        <%:Html.TextBoxFor(model => model.ToDate)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.ReportType)%>
                        <%:Html.DropDownListFor(model => model.ReportType,Model.ddlReportType)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
        <%} %>
    </div>
    <div id="ListContant">
        <% if (Model != null && Model.List != null && Model.List.Count() > 0)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        S.No.
                    </th>
                    <th>
                        Agent Code
                    </th>
                    <th>
                        Agent Name
                    </th>
                    <%if (Model.ReportType == "ByDate")
                      { %>
                    <th>
                        Date
                    </th>
                    <%} %>
                    <th>
                        Is Success
                    </th>
                    <th>
                        Tran Count
                    </th>
                </tr>
            </thead>
            <tbody>
                <% var sno = 0; int _totalCount = Model.List.Count();
                   foreach (var item in Model.List)
                   {
                       sno++;
                       var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter";
                      
                %>
                <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%: sno%>
                    </td>
                    <td>
                        <%: item.AgentCode%>
                    </td>
                    <td>
                        <%: item.AgentName%>
                    </td>
                    <%if (Model.ReportType == "ByDate")
                      { %>
                    <td>
                        <%: item.TranDate%>
                    </td>
                    <%} %>
                    <td>
                        <%: item.IsSuccess%>
                    </td>
                    <td>
                        <%: item.TranCount%>
                    </td>
                </tr>
                <% 
                   } %>
            </tbody>
        </table>
        <%}
           else
           { %>
        <%-- <%Html.RenderPartial("Utility/VUC_NoRecordsFound"); %>--%>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="<%:Url.Content("~/Content/themes/redmond/jquery.ui.all.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%:Url.Content("~/Content/themes/redmond/jquery.ui.base.css") %>" rel="stylesheet"
        type="text/css" />
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
                dateFormat: 'dd M yy',
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
        //////////////////////////////End of Date Picker /////////////////////////////////////////////////

    </script>
</asp:Content>
