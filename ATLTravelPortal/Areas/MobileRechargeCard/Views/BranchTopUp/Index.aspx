<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.TopUpModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
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
            <a href="#" class="icon_plane">Report</a> <span>&nbsp;</span><strong>Topup Detail</strong>
        </h3>
    </div>
    <% Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("Index", "BranchTopUp", FormMethod.Post, new { @class = "Validate", enctype = "multipart/form-data" }))
      {%>
    <%: Html.ValidationSummary(true) %>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.ServiceProviderId)%>
                        <%:Html.DropDownListFor(model => model.ServiceProviderId, Model.ddlServiceProviderList)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.sType)%>
                        <%: Html.DropDownListFor  (model => model.sType,Model.ddlTypeList)%><span class="redtxt">*</span>
                        <%: Html.ValidationMessageFor(model=>model.sType) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.sMobileNo)%>
                        <%: Html.TextBoxFor(model => model.sMobileNo)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.sAmount)%>
                        <%: Html.TextBoxFor(model => model.sAmount)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.sFromdate)%>
                        <%:Html.TextBoxFor(model => model.sFromdate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.sTodate)%>
                        <%:Html.TextBoxFor(model => model.sTodate)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.sStatusId)%>
                        <%:Html.DropDownListFor(model => model.sStatusId, Model.ddlStatusList, "---ALL---")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <%if (Model.ListTopUp != null && Model.ListTopUp.Count() > 0)
                  { %>
                <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
                <%}
                  else
                  { %>
                No Records
                <%} %>
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
        <%} %>
    </div>
    <div id="ListContant">
        <% if (Model != null && Model.ListTopUp != null && Model.ListTopUp.Count() > 0)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        S.No.
                    </th>
                    <th>
                        Tran ID
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                        Mobile No
                    </th>
                    <th>
                        Amount
                    </th>
                </tr>
            </thead>
            <tbody>
                <% var sno = 0; int _totalCount = Model.ListTopUp.Count();
                   foreach (var item in Model.ListTopUp)
                   {
                       sno++;
                       var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter";
                       if (sno == _totalCount)
                       {
                %>
                <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                    </td>
                    <td>
                        Total Count
                    </td>
                    <td>
                        <%: item.SalesTranId%>
                    </td>
                    <td>
                        Total Amount
                    </td>
                    <td>
                        <%: item.RechargeAmount%>
                    </td>
                </tr>
                <%}
                       else
                       { %>
                <tr id="tr_<%= sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%=sno %>
                    </td>
                    <td>
                        <%: item.SalesTranId%>
                    </td>
                    <td>
                        <%: TimeFormat.DateFormat( item.SalesDate.ToString())%>
                    </td>
                    <td>
                        <%: item.MobileNo%>
                    </td>
                    <td>
                        <%: item.RechargeAmount%>
                    </td>
                </tr>
                <% }
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
            var dates = $("#sFromdate, #sTodate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "sFromdate" ? "minDate" : "maxDate",
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
