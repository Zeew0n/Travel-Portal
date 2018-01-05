<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Package List</asp:Content>
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
                <li><a href="/Airline/AirPackage/Add" class="new linkButton" title="New">New</a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Package Management</a> <span>&nbsp;</span><strong>Package</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">                   
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
            <thead>
                <tr>
                    <th>SNo.</th>
                    <th>Package Name</th>
                    <th>Package Code</th>
                    <th>Starting Price</th>
                    <th>Country</th>
                    <th>Is Publish</th>          
                    <th>Images</th>            
                    <th>Action</th>                   
                </tr>
            </thead>
          <% if (Model != null)
           { %>

             <% if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
              { %>  
           
            <% var sno = 0;
               foreach (var item in Model.TablularRecordList)
               {

                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
            <tr>
            <td><%:item.SNO%></td>
            <td><%: item.Name%></td>
            <td><%: item.PackageCode%></td>
            <td><%: item.StartingPrice%></td>
            <td><%: item.CountryName%></td>
            <td><%: item.IsPublish%></td>           
           <td><a href="/Airline/AirPackageImage/Index/<%:item.PackageId %>">Images</a></td>    
            <td>
                <p>
                    <a href="/Airline/AirPackage/Edit/<%: item.PackageId %>" class="edit" title="Edit"></a>
                    <a href="/Airline/AirPackage/Delete/<%: item.PackageId %>" class="delete" title="Delete"
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
            if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
            { 
         %>   
         <div class="paging">
         <%=MvcHtmlString.Create(Html.Pager(ATLTravelPortal.App_Class.AppGeneral.DefaultPageSize, Model.TablularRecordList.PageNumber, Model.TablularRecordList.TotalItemCount))%>
         </div>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
      


    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript">

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
         
        

    </script>
</asp:Content>
