<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bus Schedule
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
     
        <ul class="buttons-panel">
            <li>
                <%:Html.ActionLink("New", "Create", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
    
               <h3>
            Bus <span>&nbsp;</span> Update Rate
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <div class="rptSearchResult">
        <%if (Model != null)
          {
              if (Model.TabularList.Count() > 0)
              {
                  var sno = 0; %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th style="width: 40px">
                    S.No.
                </th>
                <th>
                    Bus Operator
                </th>
                <th style="width: 80px">
                    Bus Category
                </th>
                <th style="width: 100px">
                    From City
                </th>
                <th style="width: 100px">
                    To City
                </th>
                <th style="width: 60px">
                    Time
                </th>
                <th style="width: 45px">
                    Rate
                </th>
                <th style="width: 60px">
                </th>
                <th style="width: 45">
                    Fare
                </th>
                <th style="width: 60px">
                </th>
            </thead>
            <tbody>
                <% 
                  foreach (var item in Model.TabularList)
                  {
                      string _txtRate = "txtRate_" + item.ScheduleId;
                      string _txtActualRate = "txtActualRate_" + item.ScheduleId;
                      string _tdRate = "tdRate_" + item.ScheduleId;
                      string _tdActualRate = "tdActualRate_" + item.ScheduleId;
                      string _hiRate = "hiRate_" + item.ScheduleId;
                      string _hiActualRate = "hiActualRate_" + item.ScheduleId;
                      //sno++;
                      var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.Sno %>
                    </td>
                    <td>
                        <%:item.BusMasterName%>
                    </td>
                    <td>
                        <%:item.BusCategoryName %>
                    </td>
                    <td>
                        <%:item.DepartureCityName %>
                    </td>
                    <td>
                        <%:item.DestinationCityName %>
                    </td>
                    <td>
                        <%:item.DepartureTime %>
                    </td>
                    <td>
                        <input type="text" id="<%=_txtRate %>" value="<%=item.Rate %>" style="font-size: 1.2em;
                            font-weight: bold; width: 40px;" onkeyup="RateChange(<%=item.ScheduleId %>)" />
                        <input type="hidden" id="<%=_hiRate  %>" value="<%=item.Rate %>" />
                    </td>
                    <td id="<%=_tdRate %>" onclick="UpdateRate(<%=item.ScheduleId %>)">
                        
                    </td>
                    <td >
                        <input type="text" id="<%=_txtActualRate%>" value="<%=item.ActualRate %>" style="font-size: 1.2em;
                            font-weight: bold; width: 40px;" onkeyup="ActualRateChange(<%=item.ScheduleId %>)" />
                        <input type="hidden" id="<%=_hiActualRate  %>" value="<%=item.ActualRate %>" />
                    </td>
                    <td id="<%=_tdActualRate %>" onclick="UpdateActualRate(<%=item.ScheduleId %>)">
                        
                    </td>
                </tr>
                <%  }%>
            </tbody>
        </table>
       <%-- <%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize)
            {%>--%>
        <div class="pager">
         <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Bus.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Bus/BusSchedule/UpdateRate")))%>
         <%--   <%:MvcHtmlString.Create(ATLTravelPortal.Helpers.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount))%>--%>
        </div>
        <%  }
              //}
              else
              { %>
        <%Html.Partial("Utility/VUC_NoRecordsFound"); %>
        <%  }
          }
          else
          {%>
        <% Html.Partial("Utility/VUC_NoRecordsFound");%>
        <%} %>
    </div>
   <%-- <div class="buttonBar">
        <ul class="buttons-panel">
            <li>
                <%:Html.ActionLink("Create", "Create", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
    <style type="text/css">
        .change
        {
            font-weight: bold;
            color: #E0731F;
            cursor: pointer;
        }
        .update
        {
            font-weight: bold;
            color: #00930E;
            background-color:#00930E;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="<%:Url.Content("~/Areas/bus/Scripts/atl-bus-message.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function RedirectPath(url) {
            var rowPageValue = $('#recordDisplayCount').val();
            document.location.href = url + "&pageRow=" + rowPageValue;
        }
        function RateChange(id) {
            if ($('#txtRate_' + id).val() == $('#hiRate_' + id).val()) {
                $('#tdRate_' + id).removeClass('change');
                $('#tdRate_' + id).html('');
            } else {
                $('#tdRate_' + id).html('Update');
                $('#tdRate_' + id).addClass('change');
            }
        }
        function UpdateRate(id) {
            if ($('#txtRate_' + id).val() != $('#hiRate_' + id).val()) {
                var getUrl = '/Bus/BusGeneral/JsonUpdateRate/';
                var amt = $('#txtRate_' + id).val();
                var sendData = "id=" + id + "&Amount=" + amt;
                $.ajax({
                    type: 'GET',
                    data: sendData,
                    url: getUrl,
                    datatype: 'JSON',
                    success: function (getdata) {
                        if (getdata.MsgNumber == 0) {
                            $('#tdRate_' + id).removeClass('change');
                            $('#tdRate_' + id).html('');
                            $('#tdRate_' + id).addClass('update');
                            $('#hiRate_' + id).val($('#txtRate_' + id).val())
                        }
                        $("#messageBox").html(getMessage(getdata));
                    }
                });
            }
        }
        function ActualRateChange(id) {
            if ($('#txtActualRate_' + id).val() == $('#hiActualRate_' + id).val()) {
                $('#tdActualRate_' + id).removeClass('change');
                $('#tdActualRate_' + id).html('');
            } else {
                $('#tdActualRate_' + id).html('Update');
                $('#tdActualRate_' + id).addClass('change');
            }
        }
        function UpdateActualRate(id) {
            if ($('#txtActualRate_' + id).val() != $('#hiActualRate_' + id).val()) {
                var getUrl = '/Bus/BusGeneral/JsonUpdateRate/';
                var amt = $('#txtActualRate_' + id).val();
                var sendData = "id=" + id + "&Amount=" + amt;
                $.ajax({
                    type: 'GET',
                    data: sendData,
                    url: getUrl,
                    datatype: 'JSON',
                    success: function (getdata) {
                        if (getdata.MsgNumber == 0) {
                            $('#tdActualRate_' + id).removeClass('change');
                            $('#tdActualRate_' + id).html('');
                            $('#tdActualRate_' + id).addClass('update');
                            $('#hiActualRate_' + id).val($('#txtActualRate_' + id).val())
                        }
                        $("#messageBox").html(getMessage(getdata));
                    }
                });
            }
        }
    </script>
</asp:Content>
