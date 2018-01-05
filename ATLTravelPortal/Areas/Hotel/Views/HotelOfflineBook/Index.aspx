<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelOfflineBookModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  
   <div class="pageTitle">
            <h3>
                Hotel <span>&nbsp;</span> Offline Booking List
            </h3>
        </div>
          <%using(Html.BeginForm()){%>
          
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
                Agent Name
                </th>
                <th> Hotel Name</th>
                <th>
                   Hotel Address
                </th>
               <%-- <th>
                    Hotel Detail
                </th>--%>
               <%-- <th>
                    Rooms
                </th>--%>
                <th>
                    Check In 
                </th>
                <th>
                    Check Out 
                </th>
                <th>
                    Booking Date 
                </th>
                <th>Type</th>
                <th>
                    Action
                </th>
            </thead>
            <tbody>
               <%foreach (var item in Model.TabularList)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                    <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                        onmouseout="this.className='<%= classTblRow %>'">
                        <td>
                        <%:sno.ToString() %>
                        </td>
                        
                        <td>
                           <%:item.GuestName %>
                        </td>
                        <td>
                        <%: item.AgentName %>
                        </td>
                       <td>
                            <%:item.HotelName %>
                            
                        </td>
                        <td>
                          <%-- <%:item.CityName %>, <%:item.CountryName %>--%>
                          <%: item.HotelAddress %>
                        </td>
                        
                       <%-- <td>
                            <%:item.NoOfRoom %>
                        </td>--%>
                        <td>
                            <%:TimeFormat.DateFormat( item.CheckInDate.ToString())%>
                        </td>
                        <td>
                        <%:TimeFormat.DateFormat( item.CheckOutDate.ToString())%>
                        </td>
                        <td>
                        <%:TimeFormat.DateFormat( item.CreatedDate.ToString()) %>
                        </td>

                        <td>
            <% if (item.TicketStatusId == 28)
               {%>
             <img src="../../../../Content/images/b2c.png" /><%}
               else
               {%>
             <img src="../../../../Content/images/b2b.png" /><%} %>
        </td>

                        <td>
                            <p>
                               <%:Html.ActionLink("Detail", "Detail", new { id = item.BookingRecordId, controller = "HotelOfflineBook", area = "Hotel" }, new { @class = "", @title = "Details" })%>
                            </p>
                        </td>
                    </tr>
               <%  }%>
               <%} %>
                <%} %>
            </tbody>
        </table>
      <div class="pager">
           
             <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Hotel.Pagination.PagingExtensions.Pager(this.Html, ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Hotel/HotelOfflineBook")))%>
       
        </div>
        </div>
        <% } %>
        

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script type="text/javascript">
 function RedirectPath(url) {
            var rowPageValue = $('#recordDisplayCount').val();
            document.location.href = url + "&pageRow=" + rowPageValue;
        }
         </script>
</asp:Content>
