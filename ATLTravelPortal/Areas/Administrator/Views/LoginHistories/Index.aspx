<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LoginHistoriesModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login History Report
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
       
        <h3>
            <a href="#">Reports</a> <span>&nbsp;</span><strong>Login History</strong>
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
        <%if (Model.LoginHistoriesList != null && Model.LoginHistoriesList.Count() > 0)
          { %>
        
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            Agent Name
                        </th>
                        <th>
                            User Name
                        </th>
                        <th>
                            Full Name
                        </th>
                        <th>
                            LogIn Date
                        </th>
                        <th>
                            LogOut Date
                        </th>
                       
                    </tr>
                </thead>
              
                <%  var sno = 0;
                    foreach (var item in Model.LoginHistoriesList)
                    {

                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr id="tr_<%= sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                       <%: item.AgentName %>
                    </td>
                    <td>
                        <%: item.UserName%>
                    </td>
                    <td>
                        <%: item.FullName%>
                    </td>
                    <td>
                        <%: item.LogInDateTime%>
                    </td>
                   
                    <td>
                         <%: item.LogOutDateTime%>
                    </td>
                </tr>
                <% } %>
               
                <%}
                %>
            </table>
      
        <% if (Model.LoginHistoriesList != null && Model.LoginHistoriesList.Count() > 0)
           { %>
        <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.LoginHistoriesList.PageSize, ViewData.Model.LoginHistoriesList.PageNumber, ViewData.Model.LoginHistoriesList.TotalItemCount,new { FromDate = TimeFormat.DateFormat( Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat( Model.ToDate.ToString()) } )%>
       </div>
        <%} %>
       
        <%} %>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
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
                dateFormat: 'dd M yy',
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


       

    </script>
</asp:Content>
