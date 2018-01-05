<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.B2CHitCountModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        
        <div class="display-field">Count:<%: Model.Count %></div>
        
    </fieldset>
</asp:Content>--%>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">B2C</a> <span>&nbsp;</span><strong>Site Visit Count</strong>
            </h3>
        </div>
    </div>
 
    <div class="row-1">
        <div class="form-box1 round-corner">
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
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <% } %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.CountB2CHitCount != null)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                   <th>Total number of count</th>
                   
                </tr>
            </thead>
         <tr>
         <td>
        <b> <%: Model.CountB2CHitCount%></b>
         </td>
         </tr>
            <%}
            %>
        </table>
      
        <%} %>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
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

