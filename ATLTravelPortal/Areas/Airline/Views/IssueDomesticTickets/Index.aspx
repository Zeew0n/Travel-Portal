<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.IssueDomesticTicketsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Issue Domestic Tickets
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <div class="pageTitle">
        <h3>
            <a href="#" class="icon_plane">Tickets</a> <span>&nbsp;</span><strong>Issue Domestic
                Tickets</strong>
        </h3>
    </div>
    <%if (Model != null)
      { %>
    <div style="border: 1px solid #ccc; padding: 10px;">
        <h4>
            <strong>
                <%:Model.AgentName%></strong></h4>
        Phone No:
        <%:Model.Phone%>
       
    </div>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Index", "IssueDomesticTickets", FormMethod.Post, new { @id = "issueDomesticTickets", enctype = "multipart/form-data" }))
       { %>
    <%:Html.HiddenFor(model=>model.MPNRId) %>
    <%:Html.HiddenFor(model=>model.DoOnlyUploadETicket) %>
    <%if (Model.DomesticPnrsList != null)
      { %>
    <%if (Model.DomesticPnrsList.Count > 0)
      { %>
    <%for (int pnr = 0; pnr < Model.DomesticPnrsList.Count; pnr++)
      { %>
    <br />
    <div id="PnrContainer" style="border: 1px solid #ccc; background: #F7FAFC; padding: 10px;">
       <center><h4>
            Itinerary Information</h4></center> 
        <div class="contentGrid">
            <%if (Model.DomesticPnrsList[pnr].ItinaryList != null)
              { %>
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                            From
                        </th>
                        <th>
                            To
                        </th>
                        <th>
                            Airline
                        </th>
                        <th>
                            BIC
                        </th>
                        <th>
                            Departure Date/Time
                        </th>
                        <th>
                            Arrival Date/Time
                        </th>
                    </tr>
                </thead>
                <%if (Model.DomesticPnrsList[pnr].ItinaryList.Count > 0)
                  { %>
                <% for (int i = 0; i < Model.DomesticPnrsList[pnr].ItinaryList.Count; i++)
                   { %>
                <tr>
                    <td>
                        <%:Model.DomesticPnrsList[pnr].ItinaryList[i].From%>
                        <%:Html.HiddenFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].SegmentId)%>
                    </td>
                    <td>
                        <%:Model.DomesticPnrsList[pnr].ItinaryList[i].To%>
                    </td>
                    <td>
                        <%:Html.DropDownListFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].AirlineId, Model.DomesticPnrsList[pnr].ItinaryList[i].AirlineNameList, new { @style = "width:100px;" })%>
                        <%:Html.HiddenFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].AirlineId)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].BIC, new { style = "width:80px;" })%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].DepartureDate, new { @class = "timepicker" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].DepartureDate)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].ArrivalDate, new { @class = "timepicker" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].ItinaryList[i].ArrivalDate)%>
                    </td>
                </tr>
                <%} %>
                <%} %>
            </table>
            <%} %>
        </div>
        <br />
       <center><h4>
            Fare/Passenger Information</h4></center> 
        <div class="contentGrid">
            <%if (Model.DomesticPnrsList[pnr].PassengersList != null)
              { %>
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Type
                        </th>
                        <th>
                            Ticket No
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Base Fare
                        </th>
                        <th>
                            Tax
                        </th>
                        <th>
                            FSC
                        </th>
                        <th>
                            Markup
                        </th>
                        <th>
                            Discount
                        </th>
                        <th>
                            Commission
                        </th>
                    </tr>
                </thead>
                <% for (int i = 0; i < Model.DomesticPnrsList[pnr].PassengersList.Count; i++)
                   { %>
                <tr>
                    <td>
                        <%if (!Model.DomesticPnrsList[pnr].PassengersList[i].isDeleted)
                          { %>
                        <%: Html.ActionLink("Remove", "Delete", new { id = Model.MPNRId, pId = Model.DomesticPnrsList[pnr].PassengersList[i].PassengerId, mode = "remove" })%>
                        <%}
                          else if (Model.DomesticPnrsList[pnr].PassengersList[i].isDeleted)
                          { %>
                        <%: Html.ActionLink("Include", "Delete", new { id = Model.MPNRId, pId = Model.DomesticPnrsList[pnr].PassengersList[i].PassengerId, mode = "include" })%>
                        <%} %>
                    </td>
                    <td>
                        <%if (Model.DomesticPnrsList[pnr].PassengersList[i].isDeleted)
                          {%>
                        <span style="text-decoration: line-through; color: Red;">
                            <%:Model.DomesticPnrsList[pnr].PassengersList[i].Name%></span>
                        <%}
                          else if (!Model.DomesticPnrsList[pnr].PassengersList[i].isDeleted)
                          {
                        %><span>
                            <%:Model.DomesticPnrsList[pnr].PassengersList[i].Name%></span>
                        <%} %>
                    </td>
                    <td>
                        <%: Model.DomesticPnrsList[pnr].PassengersList[i].PassengerType%>
                        <%:Html.HiddenFor(model => model.DomesticPnrsList[pnr].PassengersList[i].PassengerId)%>
                    </td>
                    <%if (Model.DomesticPnrsList[pnr].PassengersList[i].FareList.Count > 0)
                      { %>
                    <%for (int t = 0; t < Model.DomesticPnrsList[pnr].PassengersList[i].FareList.Count; t++)
                      { %>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].TicketNumber, new { style = "width:150px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].TicketNumber)%>
                    </td>
                    <td>                     
                       <%: Model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].Currency%> 
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingBaseFare, new { style = "width:80px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingBaseFare)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingTax, new { style = "width:40px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingTax)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingFSC, new { style = "width:40px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].SellingFSC)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].MarkupAmount, new { style = "width:40px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].MarkupAmount)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].DiscountAmount, new { style = "width:40px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].DiscountAmount)%>
                    </td>
                    <td>
                        <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].CommissionAmount, new { style = "width:40px;" })%>
                        <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PassengersList[i].FareList[t].CommissionAmount)%>
                    </td>
                    <%} %>
                    <%} %>
                </tr>
                <%} %>
            </table>
            <%} %>
        </div>
        <div>
            PNR Number
            <%:Html.TextBoxFor(model => model.DomesticPnrsList[pnr].PNR)%>
            <%:Html.ValidationMessageFor(model => model.DomesticPnrsList[pnr].PNR)%>
            <%:Html.HiddenFor(model => model.DomesticPnrsList[pnr].PnrId)%>
        </div>
    </div>
    <%} %>
    <%} %>
    <%} %>
    <br />
    <%if (Model.DomesticPnrsList != null)
      { %>
    <div>
        <h6>
            Upload eTicket</h6>
        <input type="file" id="eTicket" name="eTicket" />
        <input type="submit" id="Update" value="Update" onclick="return ValidateFile();" />   
         <%:Html.ActionLink("Cancel PNR", "CancelPNR", new { id = Model.MPNRId }, new { @class = "linkButton", @onclick = "return confirm('Do you want to Cancel PNR?')" })%>   
          <%:Html.ActionLink("Return to List", "Index","UnIssuedDomesticTicket",null, new { @class = "linkButton"})%>
        <span id="fileError" style="color: Red;"></span>
    </div>
    <%} %>
    <% } %>
    <%}
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery-ui-1.8.13.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        #ui-datepicker-div, .ui-datepicker
        {
            font-size: 80%;
        }
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
            margin-bottom: -25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: 0 10px 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
        .ui-tpicker-grid-label
        {
            background: none;
            border: none;
            margin: 0;
            padding: 0;
        }
        
        .validation-summary-errors p
        {
            margin: 0px;
            padding: 5px;
            position: absolute;
            overflow: auto;
            width: 218px;
            max-height: 80px;
            top: 123px;
            right: 15px;
            background-color: #fff;
            border: 1px solid #d5d5d5;
            color: #f00;
        }
        .field-validation-error
        {
            color: #FF0000;
        }
        .field-validation-valid
        {
            display: none;
        }
        input.input-validation-error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
        
        .validation-summary-valid
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/timepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.timepicker').datetimepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
                numberOfMonths: 1,
                minDate: 0
            });
        });
    </script>
    <script type="text/javascript">
        var validFilesTypes = ["zip"];
        function ValidateFile() {
            var path = $("#eTicket").val();
            if (path == "") {
                $("#fileError").html("eTicket file is required. Please upload a File with" + " extension:\n\n" + validFilesTypes.join(", "));
                isValidFile = false;
                return isValidFile;
            }

            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                $("#fileError").html("Invalid File. Please upload a File with" + " extension:\n\n" + validFilesTypes.join(", "));
            }
            if (isValidFile) {
                if (confirm("Do you want to Update PNR")) {
                    return isValidFile;
                }               
            }
            return false;
        }

    </script>
</asp:Content>
