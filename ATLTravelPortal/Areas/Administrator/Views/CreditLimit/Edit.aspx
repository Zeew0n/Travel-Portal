<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "CreditLimit", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="pageTitle">
      <div class="float-right">
            <input type="submit" value="Save" class="btn3" />
              <%:Html.ActionLink("Cancel", "Index", new { controller = "CreditLimit" }, new { @class = "linkButton float-right" })%>
        </div>
       
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Credit Limit Management(Branch Office)</strong><span>&nbsp;</span><strong>Edit</strong>
        </h3>
   
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Agent:</label>
                    <%:Html.DropDownListFor(model => model.ddlAgentId, (SelectList)ViewData["Agent"], "-----Select-----")%>
                    <%: Html.ValidationMessageFor(model => model.ddlAgentId, "*")%>
                    <%: Html.HiddenFor( model=>model.hdfagentid) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Credit Limit Type:</label>
                    <%:Html.DropDownListFor(model => model.ddlTypeId, (SelectList)ViewData["Type"], "-----Select-----")%>
                    <%: Html.ValidationMessageFor(model => model.ddlTypeId, "*")%>
                    <%: Html.HiddenFor(model=>model.hdfTypeid) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Bank:</label>
                    <%:Html.DropDownListFor(model => model.ddlBankId, (SelectList)ViewData["Bank"], "-----Select-----")%>
                    <%: Html.ValidationMessageFor(model => model.ddlBankId, "*")%>
                    <%: Html.HiddenFor(model =>model.hdfbank) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Amount:</label>
                    <%: Html.TextBoxFor(model => model.txtAmount)%>
                    <%: Html.ValidationMessageFor(model => model.txtAmount, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.LabelFor(model => model.CurrencyId)%></label>
                    <%:Html.DropDownListFor(model => model.CurrencyId, (SelectList)ViewData["Currency"])%>
                    <%:Html.ValidationMessageFor(model=>model.CurrencyId, "*") %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.FromDate)%></label>
                    <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(ATLTravelPortal.Helpers.TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                    <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    <%: Html.HiddenFor(model=>model.hdfEffectiveFrom) %>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.ToDate)%></label>
                    <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(ATLTravelPortal.Helpers.TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                    <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    <%: Html.HiddenFor(model=>model.hdfExpireOn) %>
                </div>
            </div>
            Is Approved
            <%: Html.CheckBox("isApproved", Model.isApproved) %>
        </div>
     <%--   <div class="buttonBar">
            <input type="submit" value="Save" class="btn3" />
        </div>--%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#FromDate, #ToDate").live('click', function () {
                $(this).datepicker({
                    showOn: 'focus',
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

                }).focus();
            });
        });
    
    </script>
</asp:Content>
