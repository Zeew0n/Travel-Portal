<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ProfitLossReportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profit Loss 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
                      {
                          UpdateTargetId = "ListPartial",
                          InsertionMode = InsertionMode.Replace
                      ,       OnBegin="beginAgentList",
                          OnSuccess = "successAgentList",
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
      { %>
 
     <div class="pageTitle">
       
        <h3>
            <a href="#">Reports</a> <span>&nbsp;</span><strong>Profit Loss</strong>
        </h3>
    </div>

    <div class="row-1">
        <div class="form-box1 round-corner">
            
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ProductId)%></label>
                        <%:Html.DropDownListFor(model => model.ProductId, (SelectList)ViewData["ProductList"], "---Select---")%>
                    </div>
                </div>


                  <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AppliedDate)%></label>
                        <%: Html.CheckBoxFor(model => model.AppliedDate, new { @id = "cb1" })%>
                    </div>
                </div>


            </div>
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%: Html.TextBoxFor(model => model.FromDate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBoxFor(model => model.ToDate)%>
                    </div>
                </div>
            </div>
           
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" /><label class="redtxt" id="loadingIndicator"></label>
            </p>
        </div>
    </div>


    <div id="ListPartial">
        <%Html.RenderPartial("ListPartial"); %>
    </div>

    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet" type="text/css" />
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script type="text/javascript">
      function beginAgentList(args) {
          // Animate
          $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');

      }
      function successAgentList() {
          // Animate loadingAnimation
          $("#loadingIndicator").html('');
      }

      function failureAgentList() {
          alert("Could not retrieve List.");
      }
</script>

     <script language="javascript" type="text/javascript">

         $(document).ready(function () {
             $("#AgentId").change(function () {
                 if ($("#AgentId").val() == 0) {
                     return false;

                 }
                 var url = "/AjaxRequest/GetProductByAgent";
                 $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
                 $.getJSON(url, { AgentId: $("#AgentId").val() }, function (data) {

                     $('#ProductId').removeAttr('disabled');
                     $("#ProductId").empty();
                     $("#ProductId").append("<option value='" + 0 + "'>" + 'Select' + "</option>");
                     $.each(data, function (index, optionData) {
                         $("#loadingIndicator").html(' ');
                         $("#ProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                     });
                 });
             }).change();
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


