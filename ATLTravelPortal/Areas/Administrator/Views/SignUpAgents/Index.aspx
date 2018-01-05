<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgencyModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination" %>
   <%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Sign-Up Agency
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
          
            <h3>
                <a class="icon_plane" href="#">Agent Management</a><span>&nbsp;</span><strong>Agent SignUp</strong>
            </h3>
        </div>
    </div>
    <% using (Html.BeginForm("Index", "SignUpAgents", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    
    <div>
        <label>
            <%: Html.Label("Agency Name/Code") %>
             <%:Html.AutoCompleteFor(model => model.AgencyName, x => x.AgencyName, "ListAllSignUpAgency", "Administrator/AjaxRequest", 3)%>
            <input type="submit" value="Search" class="btn1" />
        
        </label>
    </div>
    
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Agency Name
                </th>
                <th>
                    Agency Ref No.
                </th>
                <th>
                    Mobile No
                </th>
                <th>
                    Created On
                </th>
                <th colspan="2">
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.AgencyList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:item.AgencyName%>
                    </td>
                    <td>
                        <%:item.AgencyCode%>
                    </td>
                    <td>
                        <%:item.Mobile%>
                    </td>
                    <td>
                        <%:item.CreatedDate.ToShortDateString()%>
                    </td>
             

                      <td style="width: 55px;">

                      <%--<a href="/Administrator/AgentManagement/Edit/<%:item.AgentId %>" class="edit" title="Details"></a> --%>
                       <a href="/Administrator/SignUpAgents/Detail/<%:item.AgentId %>" class="details" title="Details">
                         <a href="/Administrator/SignUpAgents/Delete/<%:item.AgentId %>" class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')"></a>
                       
                   
                    </td>
                 
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
    <div class="pager">
        <%= Html.Pager(ViewData.Model.AgencyList.PageSize, ViewData.Model.AgencyList.PageNumber, ViewData.Model.AgencyList.TotalItemCount)%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

</asp:Content>