<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<TravelPortalEntity.GetLoginHistory_Result>>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LoginHistories
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <% using (Html.BeginForm())
    {%>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
<div class="box3">
        	<div class="userinfo">
            <h3 class="loginhistory">Login History</h3>
            </div>
            
            <div class="buttons-panel">
            	
            </div>    	
        </div>
  <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
            <th>SN</th>
          <th>
                AgentName
            </th>
            <th>
                UserName
            </th>
            <th>
                FullName
            </th>
            <th>
                LogedinDateTime
            </th>
            <th>
                LogedoutDateTime
            </th>
        </thead>


         <%
     if (Model != null)
     {
         %>
     <% var sno = 0;

        foreach (var item in Model)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

       <tbody >
    <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
           
          <td>
                <%:sno%>
            </td>
         
         <td>
                <%: item.AgentName%>
            </td>
            <td>
                <%: item.UserName%>
            </td>
            <td>
                <%: item.FullName%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.LogedinDateTime)%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.LogedoutDateTime)%>
            </td>
        </tr> 

        </tbody>
        <%}
     } %>
    </table>

  </div>
 <div class="Adminpager">
    <%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount)%>
</div>
  
  <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
 <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
</asp:Content>

