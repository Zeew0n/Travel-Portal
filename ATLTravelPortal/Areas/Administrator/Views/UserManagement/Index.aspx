<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="TravelPortalEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	User
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User</h2>
<%List<View_AgentDetails> rinss = (List<View_AgentDetails>)ViewData["list"];%>
   <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
         <tr>
            <th>S.No.</th>
            <th>
                User Name
            </th>
            <th>
                Agent 
            </th>
            <th>
                Email
            </th>
            <th>CreateDate</th>
            <th>Phone No.</th>
            <th>Address</th>
            <th>
                Approved Status
            </th>
            <th>Action</th>
           

        </tr>

    <% var Sno=0;
       foreach (View_AgentDetails item in rinss)
        {
            Sno++;
            %>
    
        <tr id="tr_<%:Sno %>>">
             <td>
                <%:Sno%>
             </td>
            <td>
                <%: item.UserName   %>
            </td>
            <td>
                <%: item.AgentName   %>
            </td>
            <td>
              <%: item.Email  %>
            </td>
            <td>
              <%: item.CreateDate  %>
            </td>
            <td>
              <%: item.Phone  %>
            </td>
            <td>
              <%: item.Address  %>
            </td>
            <td>
              <%: item.IsApproved  %>
            </td>
            <td>
            <%: Html.ActionLink("Details", "UserDetails", new { id = item.UserId })%> |
           <%-- <%: Html.ActionLink("Delete", "Delete", new { id = item.UserId }, new { onclick = "return confirm('Do you really want to deletethis item?')" })%>--%>
                 
            </td>

            
        </tr>
    
    <% } %>

    </table>
    <p>
     <div class="paging">
 <%using (Html.BeginForm("Index", "UserManagement", FormMethod.Post))
   { %>
    <table class="grid_tbl" border="0" width="100%">
        <tr>
            <td>
                <%int currentPage = Convert.ToInt32(ViewData["CurrentPage"].ToString());
                  int pageNo = Convert.ToInt32(ViewData["PageNo"].ToString());%>
                  <input type="hidden" value="<%=currentPage %>" name="CurrentPage" />
            </td>
        </tr>
        <tr>
            <td>
                 <div class="Right">
                
                    <%=Html.ActionLink("<<First", "Index", "UserManagement", new { flag = 1, firstOrLastPage = 1 }, new { @class = "" })%>
                    <%if (currentPage == 1)
                      { %>
                        <input type="submit" value="Previous" name="Previous1" disabled="disabled" />
                    <%}
                      else
                      { %>
                        <input type="submit" value="Previous" name="Previous"/>     
                    <%} %>
                    Page <%=currentPage %> of <%=pageNo %>
                    
                    <%if (currentPage == pageNo)
                      { %>
                        <input type="submit" value="Next" name="NextLast" disabled="disabled" />
                    <%} else{%>
                        <input type="submit" value="Next" name="Next"/>
                    <%} %>
                        
                    <%=Html.ActionLink("Last>>", "Index", "UserManagement", new { flag = 2, firstOrLastPage = pageNo }, new { @class = "" })%>
                 </div>
            </td>
        </tr>
    </table>
    <%} %>
</div>
    </p>
    <p>
        <%: Html.ActionLink("Create New", "Create")%>
    </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
