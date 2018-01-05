<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SectorSalesModel>" %>

  <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sector Sales Report
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
            <li>
               </li>
            <li>
                
            </li>
        </ul>
        <h3>
            Reports<span>&nbsp;</span><strong> Sector Sales</strong>
        </h3>
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
          <div class="form-box1 round-corner">
                 <div class="form-box1-row">
                 <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Currency</label>
                        <%:Html.DropDownListFor(model => model.CurrencyId, (SelectList)ViewData["Currencies"])%>
                         <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
                    </div>
                </div>
                 <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Type</label>
                               <% List<SelectListItem> TypeList = new List<SelectListItem>{
                                        new SelectListItem {Selected = true, Text = "Admin", Value = "1"},
                                         new SelectListItem {Selected = false, Text = "Agent", Value = "2"},
                                        new SelectListItem {Selected = false, Text = "Branch", Value = "3"},
                                        new SelectListItem {Selected = false, Text = "Distributor", Value = "4"}
                                        
                                    };%>
                        <%:Html.DropDownListFor(model => model.TypeId, TypeList)%>
                         <%: Html.ValidationMessageFor(model => model.TypeId, "*")%>
                    </div>
                </div>
            </div>
            </div>
            </div>
            <div class="buttonBar  reportLeftDiv ">
            <input class="float-right" type="submit" value="Search" />
        </div>
  
    <% } %>
    <div class="contentGrid">

        <% if (Model != null)
           { %>

             <%if (Model.SectorSalesList != null && Model.SectorSalesList.Count() > 0)
              { %>
           
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                   <th>SNo.</th>
                   <th>MPNRId</th>
                   <th>GDSRef</th>
                   <th>Service Provider</th>
                   <th>Airline</th>
                   <th>Sector</th>
                   <th>Class</th>
                   <th>Ticket Number</th>
                   <% if (Model.TypeId == 1)
                      { %>
                   <th>Admin Amount</th>
                   <%} %>
                   <% if (Model.TypeId == 2)
                      { %>
                   <th>Agent Amount</th>
                   <%} %>
                   <% if (Model.TypeId == 3)
                      { %>
                   <th>Branch Amount</th>
                   <%} %>
                   <% if (Model.TypeId == 4)
                      { %>
                   <th>Distributor Amount</th>
                   <%} %>
                   <th>Booked Date</th>
                </tr>
            </thead>

            <%  var sno = 0;
                foreach (var item in Model.SectorSalesList)
               {
                   
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
            <tr>
             <td> <%:sno%>. </td>
              <td><%: item.MPNRId %> </td>
              <td><%: item.GDSReferenceNumber %></td>
              <td><%: item.ServiceProviderName %></td>
              <td><%: item.AirlineCode %></td>
              <td><%: item.Sector %></td>
              <td><%: item.Class %></td>
              <td><%: item.TicketNumber %></td>
              <% if (Model.TypeId == 1)
                 { %>
              <td><%: item.AdminAmount%></td>
              <%} %>
              <% if (Model.TypeId == 2)
                 { %>
              <td><%: item.AgentAmount%></td>
              <%} %>
              <% if (Model.TypeId == 3)
                 { %>
              <td><%: item.BranchAmount%></td>
              <%} %>
              <% if (Model.TypeId == 4)
                 { %>
              <td><%: item.DistributorAmount%></td>
              <%} %>
              <td><%: TimeFormat.DateFormat( item.CreatedDate.ToString()) %></td>
            </tr>
            <% } %>
            <%-- end of if loop--%>




            <%}
            %>
        </table>

          <%--new code--%>
        <% if (Model.SectorSalesList != null && Model.SectorSalesList.Count() > 0)
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


        ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
        $(document).ready(function () {

            $(function () {
                $("#AirlinesName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/SectorSales/FindAirline", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        // $("#AirlinesName").val(ui.item.id);
                        $("#hdfAirlineName").val(ui.item.id);

                       // alert(ui.item.id);


                    }

                });
            });



        });

       
        /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////




         
        

    </script>
</asp:Content>