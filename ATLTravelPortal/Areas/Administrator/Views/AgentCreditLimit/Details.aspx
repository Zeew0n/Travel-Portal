<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Details", "AgentCreditLimit", new { id = Model.AgentCreditLimitId }, FormMethod.Post, new { @autocomplete = "off" }))
      {%>
        <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <div class="float-right">
            	<%:Html.ActionLink("Cancel", "Index", new { controller = "AgentCreditLimit" }, new { @class = "linkButton" })%>
            </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Credit Limit</strong>
        </h3>
    </div>

    <br />
    <div class="row-1">
   
        <div class="form-box1 round-corner">
           <%-- <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div> <label>
                       Amount:</label>
                    <%:Model.txtAmount%>
                    </div>
                </div>
                </div>--%>


            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div> <label>
                       Remarks:
                    </label>
                   <%: Html.TextAreaFor(model=>model.Comments, new { @Style = " width:168px; height:60px; font:11px Tahoma; padding:5px;" })%>
                   <%: Html.ValidationMessageFor(model=>model.Comments) %>
                    </div>
                </div>
            </div>
                  <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%--<%: Html.TextBoxFor(model => model.FromDate)%>--%>
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
                     <%--<%: Html.TextBoxFor(model => model.ToDate)%>--%>
                     <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(ATLTravelPortal.Helpers.TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                     <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                     <%: Html.HiddenFor(model=>model.hdfExpireOn) %>
                 </div>
             </div> 
             
        </div>
    </div>
     <div class="form-box1-row">
     <div class="form-box1-row-content float-left">
    <input type="submit" value="Approve" />
           <%-- <a href="/Administrator/AgentCreditLimit/Index"  class="linkButton">Reject</a>--%>
            <a href="/Administrator/AgentCreditLimit/Reject/<%:Model.AgentCreditLimitId %>"  class="linkButton">Reject</a>
          
           </div>
           </div>
             <div class="clearboth"></div>
<%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
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