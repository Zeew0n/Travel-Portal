<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("Edit", "DistributorCreditLimit", FormMethod.Post))
       {%>
        <%: Html.ValidationSummary(true)%>
      <div class="pageTitle">
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Credit Limit Management</strong>
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
                    <label> <%:Html.LabelFor(model => model.CurrencyId)%></label>
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
             Is Approved
             <%: Html.CheckBox("isApproved", Model.isApproved) %>
             </div>

           <div class="buttonBar" >
               <input type="submit" value="Save" class="btn3" />      
          </div> 

           </div>

       

    <%} %>
    </asp:Content>

    <asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

 <script type="text/javascript">

     $(function () {
         var minDate = new Date('<%: Model.hdfEffectiveFrom %>');
         var maxDate = new Date('<%: Model.hdfExpireOn %>');

         var dates = $("#FromDate,#ToDate").datepicker({
             defaultDate: "+1d",
             changeMonth: true,
             changeYear: true,
             minDate: minDate,
             maxDate: maxDate,
             constrainInput: true,
             numberOfMonths: 2,
             disable: true,
             showAnim: 'fold',
             dateFormat: 'dd M yy',
             buttonImage: '../../Content/images/calendar.gif',
             buttonImageOnly: true,
             showOn: 'both',
             buttonText: 'Choose Date',
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

