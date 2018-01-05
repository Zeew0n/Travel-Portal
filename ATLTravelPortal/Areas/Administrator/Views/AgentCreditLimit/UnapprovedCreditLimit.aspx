<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Unapproved CreditLimit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentCreditLimit" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a class="icon_plane" href="#">Account</a> <span>&nbsp;</span><strong> Unapproved CreditLimit</strong>
            </h3>
           
        </div>
  
       <div class="contentGrid">
        <p class="float-right"><span class="activeHgh"></span>:Unexpired&nbsp;&nbsp;| <span class="inactiveHgh"></span>:Expired</p>
        <% if (Model != null)
           { %>
        
        <%if (Model.CreditLimitList != null && Model.CreditLimitList.Count() > 0)
          { %>
           
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
                                    Agency Code
                                </th>
                                <th>Amount
                               </th>
                                 <th>
                                 Credit Limit Type
                               </th>
                               
                               <th >Action</th>
                            </thead>
                           
                            <% var sno = 0;
                               string cssActiveInacticehighlight = string.Empty;
                               foreach (var item in Model.CreditLimitList.Where(xx=>xx.isActive==true))
                               {

                                   sno++;
                                   cssActiveInacticehighlight = (item.hdfExpireOn < DateTime.Now ? "inactiveHgh" : "activeHgh");
                            %>
                            <tbody>
                                <tr>
                                    <td>
                                        <%:sno%>
                                    </td>
                                    <td>
                                        <%:item.AgencyName%>
                                    </td>
                                    <td>
                                        <%:item.AgencyCode %>
                                    </td>
                                    <td><%:item.txtAmount %><span class="<%:cssActiveInacticehighlight %>"></span></td>
                                    <td><%:item.CreditLimitTypeName  %></td>
                                    
                                    <td><%: Html.ActionLink("Approve Now", "Details", new { id = item.AgentCreditLimitId })%> |
                                     <a href="/Administrator/AgentCreditLimit/Delete/<%:item.AgentCreditLimitId %>" onclick="return confirm('Are you sure you want to delete this record?')" class="Delete">Delete</a>
                                      </td>
                                      </tr>
                            </tbody>
                            
                            <%
                                        } %>
                        </table>

       <%} %>
      
       <%} %>
         </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
