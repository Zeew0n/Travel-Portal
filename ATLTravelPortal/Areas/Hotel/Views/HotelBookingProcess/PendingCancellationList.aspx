<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingCancelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PendingCancellationList
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="pageTitle">
            <h3>
                Hotel <span>&nbsp;</span>  Pending Cancel List
            </h3>
        </div>
        
         <%using(Html.BeginForm()){%>
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
                <th> Guest Name</th>
                <th>
                   HotelName
                </th>
                <th>
                    Status
                </th>
                <th>
                    Request Date 
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
                       <%:item.BookingDetail.Guests[0].Title %> <%:item.BookingDetail.Guests[0].FirstName%> <%:item.BookingDetail.Guests[0].MiddleName%> <%:item.BookingDetail.Guests[0].LastName %>
                        </td>
                        <td>
                           <%=item.BookingDetail.HotelName %>
                        </td>
                        <td>
                            <%:item.CancelStatus %>
                        </td>
                        <td>
                            <%:item.CreatedOn.ToShortDateString() %>
                        </td>
                       
                        <td>
                            <p>
                               <%:Html.ActionLink("Detail", "ProcessCancellation", new { id = item.BookingCancelId, controller = "HotelBookingProcess", area = "Hotel" }, new { @class = "", @title = "Details" })%>
                            </p>
                        </td>
                    </tr>
               <%  }%>
            </tbody>
        </table>
               <%--<%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize)
                {%>--%>
        <div class="pager">
            <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Hotel.Pagination.PagingExtensions.Pager(this.Html, ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Hotel/HotelBookingProcess/PendingCancellationList")))%>
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

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
       <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
 
<script type="text/javascript">
    
    function RedirectPath(url) {
        var rowPageValue = $('#recordDisplayCount').val();
        document.location.href = url + "&pageRow=" + rowPageValue;
    }
</script>
</asp:Content>
