<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentCLApprovedModel>" %>

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
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Agent Credit Limit</strong>
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
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="Div1">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.BranchOfficeId)%></label>
                        <%:Html.DropDownListFor(model => model.BranchOfficeId, Model.BranchOfficeOption, "---ALL---")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.DistributorID)%></label>
                        <%:Html.DropDownListFor(model=>model.DistributorID,Model.DistributorOption,"---ALL---") %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="Div2">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AgentId)%></label>
                        <%:Html.DropDownListFor(model => model.AgentId, Model.AgentOption, "---ALL---")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.UserID)%></label>
                        <%:Html.DropDownListFor(model => model.UserID, Model.UsersOption, "---ALL---")%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                        </label>
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
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.AgentCLApprovedListExport != null && Model.AgentCLApprovedListExport.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Agent(Code)
                    </th>
                    <th>
                        Currency
                    </th>
                    <th>
                        Amount
                    </th>
                    <th>
                        Type
                    </th>
                    <th>
                        Requestion
                    </th>
                    <th>
                        Checked Date
                    </th>
                    <th>
                        CheckedBy
                    </th>
                    <th>
                        Effective From
                    </th>
                    <th>
                        Expire On
                    </th>
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.AgentCLApprovedListExport)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr class="<%=classTblRow %>">
                <td>
                    <%:sno%>.
                </td>
                <td>
                    <a href="javascript: void(0);" class="detailsPopup">
                        <%: item.AgentName %>(<%:item.AgentCode %>) <span>Brach Office :
                            <%:item.BranchOfficeName %><br />
                            Distributor :
                            <%:item.DistributorName %><br />
                        </span></a>
                </td>
                <td>
                    <%: item.Currency %>
                </td>
                <td>
                    <%: item.Amount%>
                </td>
                <td>
                    <%:item.Type %>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.Requestion.ToString())%>
                </td>
                <td>
                    <%: TimeFormat.DateFormat(item.CheckerDate.ToString()) %>
                </td>
                <td>
                    <%: item.CheckedBy%>
                </td>
                <td>
                    <%:TimeFormat.DateFormat(item.EffectiveFrom.ToString())%>
                </td>
                <td>
                    <%:TimeFormat.DateFormat(item.ExpireOn.ToString()) %>
                </td>
            </tr>
            <% } %>
            <%}
            %>
        </table>
        <% if (Model.AgentCLApprovedListExport != null && Model.AgentCLApprovedListExport.Count() > 0)
           { %>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
        <%--..............................................................--%>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var dates = $("#FromDate, #ToDate").datepicker({
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    constrainInput: true,
                    numberOfMonths: 2,
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




            $("#BranchOfficeId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                id = $("#BranchOfficeId").val();

                if (id == "") {
                    $("#DistributorID").empty();
                    $("#AgentId").empty();
                    $("#DistributorID").append("<option value=''>" + "-- ALL--" + "</option>");
                    $("#AgentId").append("<option value=''>" + "-- ALL--" + "</option>");
                    ShowAllBackOfficeUsers();
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    var url = "/Administrator/AjaxRequest/GetDistributorByBranchOfficeId";
                    $.getJSON(url, { id: id }, function (data) {
                        $("#DistributorID").empty();
                        $("#UserID").empty();
                        $("#UserID").append("<option value=''>" + "-- ALL--" + "</option>");
                        $("#DistributorID").append("<option value=''>" + "-- ALL--" + "</option>");
                        $.each(data, function (index, optionData) {
                            $("#DistributorID").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();


            $("#DistributorID").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#DistributorID").val();

                if (id == "") {
                    $("#AgentId").empty();
                    $("#AgentId").append("<option value=''>" + "-- ALL--" + "</option>");
                    ShowAllBackOfficeUsers();
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    var url = "/Administrator/AjaxRequest/GetAgentsByDistributorId";
                    $.getJSON(url, { id: id }, function (data) {
                        $("#AgentId").empty();
                        $("#AgentId").append("<option value=''>" + "-- ALL--" + "</option>");
                        $.each(data, function (index, optionData) {
                            $("#AgentId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        ShowDistributorUsers(id);
                    });
                }
            }).change();

            function ShowAllBackOfficeUsers() {
                var url = "/Administrator/AjaxRequest/GetAllBackOfficeUsers";
                $.getJSON(url, { id: id }, function (data) {
                    $("#UserID").empty();
                    $("#UserID").append("<option value=''>" + "-- ALL--" + "</option>");
                    $.each(data, function (index, optionData) {
                        $("#UserID").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                });
            }

            function ShowDistributorUsers(id) {

                var url = "/Administrator/AjaxRequest/GetDistributorUsers";
                $.getJSON(url, { id: id }, function (data) {
                    $("#UserID").empty();
                    $("#UserID").append("<option value=''>" + "-- ALL--" + "</option>");
                    $.each(data, function (index, optionData) {
                        $("#UserID").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                });
            }

        });
    </script>
</asp:Content>
