<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.GroupBookingReportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
 <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Group Booking </strong>
            </h3>
        </div>
    </div>
              <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
        <tr>
            <th>S.No.</th>
            <th>Group Name</th>
            <th>Company</th>
            <th>Contact Name</th>
            <th>Status</th>
            <th>Action</th>   
            </tr>        
        </thead>

       
     <% var sno = 0;

        foreach (var item in Model.GroupBookingList)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SN0%>
                    </td>
                    <td>
                        <%:item.GroupName%>
                    </td>
                    <td>
                       <%:item.CompanyName%>
                    </td>
                    <td>
                       <%:item.ContactName%>
                    </td>
                    <td>
                    <%: item.Status%>
                    </td>
                    <td>
                       
                        <a href="/Airline/GroupBookingReport/Detail/<%:item.GroupBookingId %>" class="details" title="Detail"></a>
                        
                    </td>
                </tr>
            </tbody>
           <%} %>
                
        </table>
          <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.GroupBookingList.PageSize, ViewData.Model.GroupBookingList.PageNumber, ViewData.Model.GroupBookingList.TotalItemCount)%>
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>