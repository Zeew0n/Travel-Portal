<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.FlightInquiryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Flight Inquiry List</asp:Content>
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
                <li><%--<a href="/Airline/AirPackage/Add" class="new linkButton" title="New">New Package</a>--%>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Flight Inquiry Management</a> <span>&nbsp;</span><strong>Flight Inquiry</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
                   
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">

            <thead>
                <tr>
                    <th>SNo.</th>
                    <th>Flight Type</th>
                    <th>Journey Type</th>
                    <th>Start From</th>                    
                    <th>Destination</th>
                    <th>Departure Date</th>            
                    <th>Return Date</th>   
                    <th>Status</th>         
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
            <td><%:sno%></td>
            <td><%: item.FlightType%></td>
            <td><%: item.JourneyType%></td>
            <td><%: item.OriginCity%></td>
            <td><%: item.DepartureCity%></td>           
            <td><%: item.DepartureDate%></td>           
            <td><%: item.ReturnDate%></td>     
            <td><%: item.Status%></td>           
            <td>
                <p>
                   <%-- <a href="/Airline/FlightInquiry/Edit/<%: item.PId %>" class="edit" title="Edit"></a>--%>
                    <a rel="/Airline/FlightInquiry/Detail/<%: item.PId %>" class="details FlightInquiryDialogOpener" title="Detail" ></a>
                    <a href="/Airline/FlightInquiry/Delete/<%: item.PId %>" class="delete" title="Delete"
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
        <div id="FlightInquiryDialog"  title="Flight Inquiry Detail" style="display:none;"><img src="/Content/Icons/indicator-big.gif" alt="loading..." /></div>
        
    <div class="buttonBar">
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   <script type="text/javascript">
    $(document).ready(function () {
    var $DialogOpener = $(".FlightInquiryDialogOpener");
    var $DialogContainer = $("#FlightInquiryDialog");
    /* The following code is executed once the DOM is loaded */
    // Configuring the reminder confirmation dialog
    $DialogContainer.dialog({
        resizable: false,
        height: 600,
        width: 800,
        modal: true,
        autoOpen: false,
        buttons: {
        }
   });
   $DialogOpener.live("click", function () {

       var alertMsg = "'Are you sure to save the details?'";
       var $inquiryDialog = $DialogContainer.dialog('open');
       packagename = $DialogOpener.attr("packagename");
       var url = $(this).attr('rel');       
       $DialogContainer.empty().html('<img src="/Content/Icons/indicator-big.gif" alt="Loading..." />');
       $.get(url, function (responseResult) {           
           //$("#FlightInquiryDialog").empty().html(responseResult);
           $DialogContainer.empty().html(responseResult);
       });
       return false;

   });
});

   </script>

</asp:Content>
