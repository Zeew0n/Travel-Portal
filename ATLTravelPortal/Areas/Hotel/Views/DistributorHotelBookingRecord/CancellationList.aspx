<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingCancelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CancellationList
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <h3>
            Hotel <span>&nbsp;</span> Booking Cancel List
        </h3>
    </div>
    <%using (Html.BeginForm())
      {%>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
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
                    HotelName
                </th>
                <th>
                    Request Date
                </th>
            </thead>
            <tbody>
                <%foreach (var item in Model.TabularList)
                  {

                      var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNo %>
                    </td>
                    <td>
                        <%:item.BookingDetail.Guests[0].GuestState%>
                        <%:item.BookingDetail.Guests[0].FirstName%>
                        <%:item.BookingDetail.Guests[0].FirstName%>
                        <%:item.BookingDetail.Guests[0].LastName %>
                    </td>
                    <td>
                        <%:item.BookingDetail.HotelName %>
                    </td>
                    <td>
                        <%:item.CreatedOn.ToShortDateString() %>
                    </td>
                </tr>
                <%  }%>
            </tbody>
        </table>
        <div class="pager">
            <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Hotel.Pagination.PagingExtensions.Pager(this.Html, ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Hotel/DistributorHotelBookingRecord/CancellationList")))%>
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
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="../../../../Content/css/hotel.css" rel="stylesheet" type="text/css" />
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
