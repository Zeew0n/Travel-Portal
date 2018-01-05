<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingProcessModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <h3>
            Hotel <span>&nbsp;</span> Pending Booking Detail
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <%using (Html.BeginForm())
      {%>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
    <% } %>
    <div class="rptSearchResult">
        <%if (Model != null)
          {
              if (Model.TabularList.Count() > 0)
              {
                  var sno = 0; %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    S.No.
                </th>
                <th>
                    Guest Name
                </th>
                <th>
                    Location
                </th>
                <th>
                    Hotel Detail
                </th>
                <th>
                    Rooms
                </th>
                <th>
                    Check In
                </th>
                <th>
                    Check Out
                </th>
                <th>
                    Booking Date
                </th>
                <th>
                    Action
                </th>
            </thead>
            <tbody>
                <%foreach (var item in Model.TabularList)
                  {
                      //sno++;
                      var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNo %>
                    </td>
                    <td>
                        <%:item.GuestName%>
                    </td>
                    <td>
                        <%:item.CityName %>,
                        <%:item.CountryName %>
                    </td>
                    <td>
                        <%:item.HotelName %>
                    </td>
                    <td>
                        <%:item.NoOfRoom %>
                    </td>
                    <td>
                        <%:item.CheckInDate.ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%:item.CheckOutDate.ToString("MM/dd/yyyy")%>
                    </td>
                    <td>
                        <%:item.CreatedDate.ToString("MM/dd/yyyy") %>
                    </td>
                    <td>
                        <p>
                            <%:Html.ActionLink("Detail", "Process", new { id = item.BookingRecordId, controller = "BranchOfficeHotelBookingProcess", area = "Hotel" }, new { @class = "", @title = "Details" })%>
                        </p>
                    </td>
                </tr>
                <%  }%>
            </tbody>
        </table>
        <%--  <%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize)
                {%>--%>
        <div class="pager">
            <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Hotel.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount,true,true,"", Url.Content("~/Hotel/DistributorHotelBookingProcess")))%>
        </div>
        <%  }

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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function RedirectPath(url) {
            var rowPageValue = $('#recordDisplayCount').val();
            document.location.href = url + "&pageRow=" + rowPageValue;
        }
    </script>
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Areas/Hotel//Scripts/atl-list-function-1.0.0.js")%>"
        type="text/javascript"></script>
</asp:Content>
