<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TravelPortalHome.Master" Inherits="System.Web.Mvc.ViewPage<ATBackOffice.Models.Admin.LedgerVoucherModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Ledger Summary</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <%--<li class="create"><a href="#">Create</a></li>--%>
                <li>
                    <input type="submit" value="Search" class="search" /></li>
                <li>
                    <%:Html.ActionLink("Showall", "Index", new { controller = "AirLineLedgerTransactionSummary" }, new {@class="showall" })%>
                    <%--<input type = "button" value="ShowAll" class="showall" onclick="document.location.href='/AirLineLedgerTransactionSummary/'" />--%></li>
            </ul>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AgentId) %></label>
                       <%-- <%: Html.DropDownListFor(model => model.AgentId, new SelectList((List<ATBackOffice.DataModel.Agents>)ViewData["agentList"], "AgentId", "AgentName"))%>--%>
                        <%: Html.DropDownListFor(model => model.AgentId, new SelectList((List<ATBackOffice.DataModel.Agents>)ViewData["agentList"], "AgentId", "AgentName"))%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AppliedDate) %></label>
                        <%: Html.CheckBoxFor(model => model.AppliedDate, new { @id = "cb1" })%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate) %></label>
                        <%: Html.TextBoxFor(model => model.FromDate) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate) %></label>
                        <%: Html.TextBoxFor(model => model.ToDate) %>
                    </div>
                </div>
            </div>
            
    <% } %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Date
                </th>
                
                <th>
                    Debit
                </th>
                <th>
                    Credit
                </th>
                <th>
                </th>
                <th>
                    Balance
                </th>
                <th>
                    <%--PNRGroupId--%>
                </th>
                <%--<th>Action</th>--%>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.LedgerVoucherlist)
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
                    <%--<td>
                <%: item.TranID %>
            </td>--%>
                    <td>
                        <%: String.Format("{0:yyyy/MMM/dd}", item.ToDate)%>
                    </td>
                    
                    <td>
                        <%: String.Format("{0:F}",item.AgentName )%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.AgentName)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.AgentName)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.AgentName)%>
                    </td>
                    <td>
                        <%--<%: item.PNRGroupId%>--%>
                        <%
                            if (item.AgentId != -1)
                            {
                        %>
                        <%--<%: Html.ActionLink("Details", "Details", new { id=item.PNRGroupId })%>--%>
                        <%: Html.ActionLink("Details", "Details", new { id = item.AgentId }, new { onclick = "ShowThickBox('Detail',this.href+'?keepThis=true&TB_iframe=true&height=300&width=950');return false;" })%>
                        <% } %>
                    </td>
                </tr>
            </tbody>
            <%}
             } %>
        </table>
    </div>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 <link href="../../Content/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../Scripts/jquery.Datepicker-1.8.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.thickbox.js" type="text/javascript"></script>
    <script src="../../Scripts/ATL.jquery.functions.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
$(function () {
            var cb1 = $("#cb1");
            cb1.change(toggle_cb1);
            toggle_cb1.call(cb1[0]);
        });
        function toggle_cb1() {
            if ($(this).is(":checked")) {
                $("#DateFilter").show();
                $("#FromDate").val('');
                $("#ToDate").val('');
            } else {
                $("#DateFilter").hide();
            }
        }
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
