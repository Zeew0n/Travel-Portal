<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PurchaseSalesReportOfMEModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <div>
        <div class="pageTitle">
            <h2>
                <a href="#" class="icon_plane">Report</a> <span>&nbsp;</span><strong>Purchase sales
                    Report of MEs</strong>
            </h2>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx");%>
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
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CurrencyID)%></label>
                        <%:Html.DropDownListFor(model => model.CurrencyID,Model.CurrencyList,"--Select--")%>
                        <%:Html.ValidationMessageFor(model=>model.CurrencyID) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.MEsNameID)%></label>
                            <% if (Model.UserTypeId != 4)
                               { %>
                        <%:Html.DropDownListFor(model => model.MEsNameID, Model.MENameList, "--Select--")%>
                        <%} %>
                        <% else
                               {  %>
                                <%:Html.DropDownListFor(model => model.MEsNameID, Model.MENameList)%>
                        <%} %>
                        <%:Html.ValidationMessageFor(model=>model.MEsNameID) %>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <%} %>
     <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                   <tr>
                        <td>SNo</td>
                        <td>Agent Name</td>
                        <% if(Model.UserTypeId != 4){ %>
                        <td>Purchase</td>
                        <%} %>
                        <td>Sales</td>
                        <td>Receipt</td>
                   </tr>
            </thead>
            <tbody>
                <% if (Model.PurchaseSalesReportOfMElist != null)
                   {
                       %>
                   


                   <%     var SNo = 1;
                       foreach (var item in Model.PurchaseSalesReportOfMElist)
                     {
                        
                       %>
                        
                     <tr>
                     <%if (SNo != Model.PurchaseSalesReportOfMElist.Count())
                       {%>
                        <td><%:SNo%></td><%}
                       else
                       { %> 
                           <td><b><%:"Total" %></b></td>
                        <%} %>   
                        <td><%:item.AgentName%></td>
                        <% if (Model.UserTypeId != 4)
                           { %>
                        <td><%:item.Purchase%></td>
                        <%} %>
                        <td><%:item.Sales%></td>
                        <td><%:item.Receipt%></td>
                     </tr>
                     
                   <%SNo++; %>
                   <%}
                   }%>

            </tbody>

            </table>
            </div>

    </asp:Content>
    <asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
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
    </script>
</asp:Content>