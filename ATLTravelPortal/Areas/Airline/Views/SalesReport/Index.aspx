<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SalesReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sales Report
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
    <% using (Html.BeginForm("Index", "SalesReport", FormMethod.Post))
       {%>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Report</a> <span>&nbsp;</span><strong>Sales Report</strong>
            </h3>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
    <div class="row-1">
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
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%: Html.TextBoxFor(model => model.FromDate)%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBoxFor(model => model.ToDate)%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Currency)%></label>
                    <%=Html.DropDownListFor(model => model.Currency, new SelectList((IEnumerable)ViewData["Currency"], "Value", "Text", "---Select---"))%>
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
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.salesReportSummary != null && Model.salesReportSummary.Count() > 0)
          { %>
        <div style="width: 100%; display: inline-block; clear: both;">
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                            SNo.
                        </th>
                        <th>
                            Code
                        </th>
                        <th>
                            Cash
                        </th>
                        <th>
                            Tax
                        </th>
                        <th>
                            Commission
                        </th>
                        <th>
                            Payable
                        </th>
                    </tr>
                </thead>
                <% var sno = 0;


                   int count = Model.salesReportSummary.Count();
                   if (count > 0)
                   {
                       Model.SumAgentBillingStatement_Cash = Model.salesReportSummary.ElementAt(count - 1).SumAgentBillingStatement_Cash;
                       Model.SumAgentBillingStatement_Tax = Model.salesReportSummary.ElementAt(count - 1).SumAgentBillingStatement_Tax;
                       Model.SumAgentBillingStatement_Commission = Model.salesReportSummary.ElementAt(count - 1).SumAgentBillingStatement_Commission;
                       Model.SumAgentBillingStatement_Payable = Model.salesReportSummary.ElementAt(count - 1).SumAgentBillingStatement_Payable;
                   }




                   foreach (var item in Model.salesReportSummary)
                   {
                       sno++;
                       var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr>
                    <td>
                        <%: sno %>.
                    </td>
                    <td>
                        <%: item.AirlineCode%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.Cash)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.Tax)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.Commission)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.Payable)%>
                    </td>
                </tr>
                <% } %>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <b>
                        <%:Model.SumAgentBillingStatement_Cash == null ? "" : (Model.SumAgentBillingStatement_Cash).ToString()%>
                    </b>
                </td>
                <td>
                    <b>
                        <%:Model.SumAgentBillingStatement_Tax == null ? "" : (Model.SumAgentBillingStatement_Tax).ToString()%>
                    </b>
                </td>
                <td>
                    <b>
                        <%:Model.SumAgentBillingStatement_Commission == null ? "" : (Model.SumAgentBillingStatement_Commission).ToString()%>
                    </b>
                </td>
                <td>
                    <b>
                        <%:Model.SumAgentBillingStatement_Payable == null ? "" : (Model.SumAgentBillingStatement_Payable).ToString()%>
                    </b>
                </td>
                <%}
                %>
                </tbody>
            </table>
            <div>
                <input type="button" class="ui-accordion-header" value="Details show/hide" />
                <% using (Html.BeginForm("Index1", "SalesReport", FormMethod.Post, new { @onsubmit = "return SubmitForm();", @id = "ATForm" }))
                   { %>
                <% Html.RenderPartial("~/Views/Shared/ExportDataAlternate.ascx"); %>
                <%:Html.Hidden("SalesAgentId",Model.AgentId,new  {@name="AgentId"}) %>
                <%:Html.Hidden("SalesFromDate", Model.FromDate, new { @name = "FromDate" })%>
                <%:Html.Hidden("SalesToDate",Model.ToDate,new  {@name="ToDate"}) %>
                <%:Html.Hidden("SalesCurrency",Model.Currency,new  {@name="Currency"}) %>
                <% } %>
                <%if (Model.salesReportDetails != null && Model.salesReportDetails.Count() > 0)
                  { %>
                <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                    class="GridView  ui-accordion-content" width="100%">
                    <thead>
                        <tr>
                            <th>
                                SNo.
                            </th>
                            <th>
                                Code
                            </th>
                            <th>
                                Agent
                            </th>
                            <th>
                                Ticket Number
                            </th>
                            <th>
                                Issued Date
                            </th>
                            <th>
                                Cash
                            </th>
                            <th>
                                Tax
                            </th>
                            <th>
                                Commission
                            </th>
                            <th>
                                Payable
                            </th>
                            <th>
                            </th>
                            <th>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <% var sno = 0;


                           int count = Model.salesReportDetails.Count();
                           if (count > 0)
                           {
                               Model.SumAgentBillingStatementDetails_Cash = Model.salesReportDetails.ElementAt(count - 1).SumAgentBillingStatementDetails_Cash;
                               Model.SumAgentBillingStatementDetails_Tax = Model.salesReportDetails.ElementAt(count - 1).SumAgentBillingStatementDetails_Tax;
                               Model.SumAgentBillingStatementDetails_Commission = Model.salesReportDetails.ElementAt(count - 1).SumAgentBillingStatementDetails_Commission;
                               Model.SumAgentBillingStatementDetails_Payable = Model.salesReportDetails.ElementAt(count - 1).SumAgentBillingStatementDetails_Payable;
                           }




                           foreach (var item in Model.salesReportDetails)
                           {
                               sno++;
                               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                        %>
                        <tr>
                            <td>
                                <%: sno %>.
                            </td>
                            <td>
                                <%: item.AirlineCode%>
                            </td>
                            <td>
                                <%--  ---- details region in popup---------------------%>
                                <a href="javascript: void(0);" class="detailsPopup">
                                    <%: item.AgentName %>(<%:item.AgentCode %>) <span>Brach Office :
                                        <%:item.BranchOfficeName %><br />
                                        Distributor :
                                        <%:item.DistributorName %><br />
                                    </span></a>
                                <%--  ---- details region in popup---------------------%>
                            </td>
                            <td>
                                <%: item.TicketNumber%>
                            </td>
                            <td>
                                <%: TimeFormat.DateFormat( item.IssuedDate.ToString())%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.Cash)%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.Tax)%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.Commission)%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.Payable)%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.serviceProviderName)%>
                            </td>
                            <td>
                                <%: String.Format("{0:F}", item.issueFrom)%>
                            </td>
                        </tr>
                        <% } %>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <b>
                                <%:Model.SumAgentBillingStatementDetails_Cash == null ? "" : (Model.SumAgentBillingStatementDetails_Cash).ToString()%>
                            </b>
                        </td>
                        <td>
                            <b>
                                <%:Model.SumAgentBillingStatementDetails_Tax == null ? "" : (Model.SumAgentBillingStatementDetails_Tax).ToString()%>
                            </b>
                        </td>
                        <td>
                            <b>
                                <%:Model.SumAgentBillingStatementDetails_Commission == null ? "" : (Model.SumAgentBillingStatementDetails_Commission).ToString()%>
                            </b>
                        </td>
                        <td>
                            <b>
                                <%:Model.SumAgentBillingStatementDetails_Payable == null ? "" : (Model.SumAgentBillingStatementDetails_Payable).ToString()%>
                            </b>
                        </td>
                        <%}
                        %>
                    </tbody>
                </table>
            </div>
            <%} %>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SubmitForm() {

            var agentid = $("#AgentId").val();

            $("#SalesAgentId").val($("#AgentId").val());
            $("#SalesFromDate").val($("#FromDate").val());
            $("#SalesToDate").val($("#ToDate").val());
            $("#SalesCurrency").val($("#Currency").val());

            return true;

        }
    </script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            //            $("#AgentId").change(function () {
            //                if ($("#AgentId").val() == 0) {
            //                    return false;

            //                }
            //                var url = "/AjaxRequest/GetProductByAgent";

            //                $.getJSON(url, { AgentId: $("#AgentId").val() }, function (data) {

            //                    $('#ProductId').removeAttr('disabled');
            //                    $("#ProductId").empty();
            //                    $("#ProductId").append("<option value='" + 0 + "'>" + 'Select' + "</option>");
            //                    $.each(data, function (index, optionData) {
            //                        $("#ProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
            //                    });
            //                });
            //            }).change();
            /////////////////End of loading product according to Agents///////////////////////////////////
            $("#showall").click(function () {
                var productId = $("#ProductId").val();
                var AgentId = $("#AgentId").val();
                var FDate = $("#FromDate").val();
                var TDate = $("#ToDate").val();
                //var IsApproved = $("#UnApproved").val();UnApproved
                var IsApproved = false;
                if ($("#UnApproved").attr('checked')) {
                    IsApproved = true;
                }


                $.ajax(

             {

                 type: "GET",

                 url: "/LedgerVoucher/Index",

                 data: "productId=" + productId + "&AgentId=" + AgentId + "&FDate=" + FDate + "&TDate=" + TDate + "&IsApproved=" + IsApproved,

                 success: function (result) {
                     $("#ListPartial").empty().append(result);

                 },

                 error: function (req, status, error) {

                     //        alert("Sorry! We could not receive your feedback at this time.");

                 }

             });

            });
        });
        ///////////////////////////End of document ready function ////////////////////////////////////


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
        //////////////////////////////End of Date Picker /////////////////////////////////////////////////
        function EnableDisableElementBySelectionAppliedDate(thisElm, targetElm) {
            if (thisElm == "checked") {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).val("")
            }
            else {
                $("#" + targetElm).removeAttr('disabled', 'disabled');
            }
        }
    </script>
</asp:Content>
