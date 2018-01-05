<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerTransactionSummaryModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2></h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
       <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Ledger Transaction Summary</strong>
            </h3>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx");%>
     <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.DateFrom)%></label>
                        <%: Html.TextBox("DateFrom", (Model != null && Model.DateFrom != null && Model.DateFrom != DateTime.MinValue) ?
                                                        (TimeFormat.DateFormat(Model.DateFrom.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.DateFrom, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.DateTo)%></label>
                        <%: Html.TextBox("DateTo", (Model != null && Model.DateTo != null && Model.DateTo != DateTime.MinValue) ?
                                                        (TimeFormat.DateFormat(Model.DateTo.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.DateTo, "*")%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-2">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="Div2">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>Product</label>
                        <%:Html.DropDownListFor(model => model.ProductId, Model.ProductsOption, "---ALL---")%>
                        <%: Html.ValidationMessageFor(model=>model.ProductId) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>Currency</label>
                        <%:Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyOption)%>
                        <%:Html.ValidationMessageFor(model=>model.CurrencyId,"*") %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-3">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="Div3">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>Ledger Of</label>
                        <%:Html.DropDownListFor(model => model.LedgerOf, Model.LedgerOfOption)%>
                        <%:Html.ValidationMessageFor(model=>model.LedgerOf,"*") %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                       <label> Filter Type</label>
                       <%: Html.DropDownListFor(model=>model.FilterType,Model.FilterTypeOption,"---All---") %>
                       <%: Html.ValidationMessageFor(model=>model.FilterType,"*") %>
                    </div>
                     <div class="form-box1-row-content float-left">
                        <label>Filter Value</label>
                         <%: Html.TextBoxFor(model=>model.FilterValue) %>
                         <%: Html.ValidationMessageFor(model=>model.FilterValue) %>
                   </div> 
                </div>
            </div>
        </div>
    </div>
   
     <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                        </label>
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
        <% if (Model != null)
           { %>
        <%if (Model.LedgerTransactionList != null && Model.LedgerTransactionList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SN
                    </th>
                   <%-- <th>
                        Ledger Id
                    </th>--%>
                    <th>
                        Ledger Name
                    </th>
                    <th>
                       Opening Balance
                    </th>
                    <th>
                        Dr
                    </th>
                    <th>
                        Cr
                    </th>
                    <th>
                        Closing Balance
                    </th>
                  
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.LedgerTransactionList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr class="<%=classTblRow %>">
                <td>
                    <%:sno%>.
                </td>
               <%-- <td>
                    <%: item.LedgerId%>
                </td>--%>
                <td>
                    <%:item.LedgerName%>
                </td>
                <td>
                    <%: item.OpeningBalance%>
                </td>
                <td>
                <%: item.Dr%>
                </td>
                <td>
                <%:item.Cr%>
                </td>
                <td>
                <%:item.ClosingBalance%>
                </td>
                </tr>
                <%}
          }%>
           <% if (Model.LedgerTransactionList!= null && Model.LedgerTransactionList.Count() > 0)
           { %>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
          <% } %>
               
        </table>

    </div>
   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var dates = $("#DateFrom, #DateTo").datepicker({
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    constrainInput: true,
                    numberOfMonths: 2,
                    onSelect: function (selectedDate) {
                        var option = this.id == "DateFrom" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                        date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                        dates.not(this).datepicker("option", option, date);
                    }
                });
            });
        });
</script>
</asp:Content>
