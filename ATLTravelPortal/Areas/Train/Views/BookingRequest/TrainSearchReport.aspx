<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TrainMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainSearchLogModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TrainSearchReport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>   
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Train Setting</a> <span>&nbsp;</span><strong>Train Search Log</strong>
            </h3>
        </div>
    </div>

    
     <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
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
                            <%: Html.LabelFor(model => model.AgentId)%></label>
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"], "---ALL---")%>
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
        <%if (Model.PagedList != null && Model.PagedList.Count() > 0)
          { %>
           <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
             <thead>
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            Agent Name
                        </th>
                        <th>
                            No Of Search
                        </th>
                   </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.PagedList)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
               %>
                  <tr>
                      <td>
                          <%:sno%>
                      </td>
                      <td>
                          <%:item.AgentName%>
                      </td>
                      <td>
                          <%:item.NoOfSearch%>
                      </td>
                 </tr>
              <% } %>
        
          
            <%}%>
        </table>
        <%} %>
    </div>
     <div class="pager" align="center">
  
            <%= Html.Pager(ViewData.Model.PagedList.PageSize, ViewData.Model.PagedList.PageNumber, ViewData.Model.PagedList.TotalItemCount, new { FromDate = TimeFormat.DateFormat(Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat(Model.ToDate.ToString()) })%>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
<script type="text/javascript">
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
</script>
</asp:Content>
