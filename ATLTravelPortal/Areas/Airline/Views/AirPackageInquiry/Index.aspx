<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageInquiryModel>" %>
 <%@ Import Namespace="ATLTravelPortal.Helpers.Pagination"%>
 <%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Package Inquiry List</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null){ %>
    <%: TempData["success"]%>
    <% }%>
    
        <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <%--<li><a href="/Airline/AirPackageInquiry/Add" class="new linkButton" title="New">New Package</a>
                </li>--%>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Package Management</a> <span>&nbsp;</span><strong>Package Inquiry</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
                   
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">

            <thead>
                <tr>
                    <th>SNo.</th>
                    <th>Package Name</th>                    
                    <th>Name</th>           
                    <th>Contact</th>         
                    <th>Email</th> 
                    <th>Requested Date</th>           
                    <th>Action</th>                   
                </tr>
            </thead>
          <% if (Model != null)
           { %>

             <% if (Model.PackagesList != null && Model.PackagesList.Count() > 0)
              { %>  
           
            <% var sno = 0;
               foreach (var item in Model.PackagesList)
               {

                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
            <tr>
            <td><%:item.SNO%></td>
            <td><%: item.PackageName%></td>           
            <td><%: item.Name%></td>
             <td><%: item.ContactNo%></td>
            <td><%: item.EmailAddress%></td>   
            <td><%:TimeFormat.DateFormat( item.CreatedDate.ToString()) %></td>        
            <td>
                <p>
                    <%--<a href="/Airline/AirPackageInquiry/Edit/<%: item.PId %>" class="edit" title="Edit"></a>--%>
                    <a href="/Airline/AirPackageInquiry/Detail/<%: item.PId %>" class="details" title="Detail"></a>
                    <a href="/Airline/AirPackageInquiry/Delete/<%: item.PId %>" class="delete" title="Delete"
                        onclick="return confirm('Are you sure you want to delete?')"></a>
                    </p>
               </td>
            </tr>
          
          <%}

              }
           } %>

        </table>
       <%
            #region Data for paging
            //int TotalPages =Int32.Parse(ViewData["TotalPages"].ToString());
            //int CurrentPage = Int32.Parse(ViewData["CurrentPage"].ToString());
            //Html.RenderPartial("~/Views/Shared/Utility/VUC_Pagination.ascx", new ViewDataDictionary { { "TotalPages", TotalPages }, { "CurrentPage", CurrentPage } });
            #endregion
        %> 
        <%           
            if (Model.PackagesList != null && Model.PackagesList.Count() > 0)
            { 
         %>   
       <%--  <div class="paging">
         <%=MvcHtmlString.Create(Html.Pager(ATLTravelPortal.App_Class.AppGeneral.DefaultPageSize, Model.TablularRecordList.PageNumber, Model.TablularRecordList.TotalItemCount))%>
         </div>--%>

          <div class="pager">
    <%= Html.Pager(ViewData.Model.PackagesList.PageSize, ViewData.Model.PackagesList.PageNumber, ViewData.Model.PackagesList.TotalItemCount)%>
   </div>

        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
      


    </div>
    <div class="buttonBar">
        <%--<a href="/Airline/AirPackage/Add" class="new linkButton" title="New">New Package</a>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
   
    <%--<script language="javascript" type="text/javascript">

        $(document).ready(function () {

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
                        $("#AirlinesName").val(ui.item.id);


                    }

                });
            });

        });


        /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////
         
        

    </script>--%>
</asp:Content>
