<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentClassesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 


         <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator"> <%:TempData["Error"]%>
                </div>
            </li>
            <li><input type="submit" onclick="document.location.href='/Airline/AgentClasses/Create'" value="New"  />   

            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Agent Class</strong>
        </h3>
    </div>




   <div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                Agent Type
            </th>
            <th>
                Description
            </th>
            
            <th>
                Action
            </th>
            </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = 0;

           foreach (var item in Model.AgentClassList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:item.SNO%>
                </td>
                <td>
                    <%--<%: String.Format("{0:yyyy/MMM/dd}", item.TranDate)%>--%>
                    <%:item.AgentTypeClasses %>
                </td>
                <td>
                    <p style="width: 630px; word-wrap:break-word;"><%: item.Description %></p>
                </td>
                
                <td>
                   <p><a href="/Airline/AgentClasses/Details/<%:item.AgentClassId %>" class="details" title="Details"></a>
                   <a href="/Airline/AgentClasses/Edit/<%:item.AgentClassId %>" class="edit" title="Edit"></a>
                   <a href="/Airline/AgentClasses/Delete/<%:item.AgentClassId %>" class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')"></a>
                   </p>
                </td>
                
            </tr>
        </tbody>
        <%}
            } %>
    </table>
      <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.AgentClassList.PageSize, ViewData.Model.AgentClassList.PageNumber, ViewData.Model.AgentClassList.TotalItemCount)%>
       </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
