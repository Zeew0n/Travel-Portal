<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PromotionalFareSector>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["Error"] != null)
        { %>
    <%: TempData["Error"]%>
    <%
    
        }
    %>
    
   <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "PromotionalFare" }, new { @class = "linkButton" })%>
                        <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Promotional Fare</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
     
           
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        From City
                    </th>
                    <th>
                        To City
                    </th>
                    <th>
                        Airline
                    </th>
                    <th>
                       Class
                    </th>
                    <th>
                        Departure Time
                    </th>
                    <th>
                       Arrival Time
                    </th>
                    <th>
                        Flight Number
                    </th>
                    <th></th>
                </tr>
            </thead>
        <%int Sno = 1; %>
        <% for (int i = 0; i < Model.PromotionalFareSectorList.Count(); i++)
           {%>   
                <% if ((Model.PromotionalFareSectorList[i].PromotionalFareSegment.Count()) > 0)
                   {%>
                
         <%--   <% for (int j = 0; j < Model.PromotionalFareSectorList[i].PromotionalFareSegmentList.Count; j++)
               { %>--%>
               <%int j = 0; %>
            <tr>
                <td><%: Sno++ %></td>
                <td>
                    <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].FromCity%>
                </td>
                <td>
                    <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].ToCity%>
                </td>
                <td>
                    <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].AirlineCode%>
                </td>
                <td>
                    <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].Class%>
                </td>
                <td>
                   <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].DepartureTime%>
                </td>
                <td>
                   <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].ArrivalTime%>
                </td>
                <td>
                    <%--<%: TimeFormat.DateFormat( item.BookedDate.ToString())%>--%>
                    <%:Model.PromotionalFareSectorList[i].PromotionalFareSegment[j].FlightNo%>
                </td>
                <td>
                  <%: Html.ActionLink("Details", "Details", "PromotionalFare", new { PromotionalfareId = Model.PromotionalFareSectorList[i].PromotionalFareId }, null)%>
                  <%: Html.ActionLink("Edit", "Edit", "PromotionalFare", new { PromotionalfareId = Model.PromotionalFareSectorList[i].PromotionalFareId }, null)%>
                  <%: Html.ActionLink("Delete", "Delete", "PromotionalFare", new { PromotionalfareId = Model.PromotionalFareSectorList[i].PromotionalFareId }, null)%>
                </td>
            </tr>
         
           <%} %>
            <%} %>
            </table>
            
           
          
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
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

         
        

    </script>
</asp:Content>
