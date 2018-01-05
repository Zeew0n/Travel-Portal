<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MEsCreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  

<div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                          <%:Html.ActionLink("New", "Create", new { controller = "MEsCreditLimit" }, new { @class = "linkButton" })%>
                        <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">Account Management</a> <span>&nbsp;</span><strong>MEs CreditLimit</strong>
            </h3>
        </div>
    </div>    
   <div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
      <thead>
        <tr>
            <th>
                MEs Name
            </th>
            <th>
                Currency
            </th>
            <th>
                Amount
            </th>
            <th>
                From
            </th>
            <th>
                To
            </th>
            <th>
                Actions
            </th>
        </tr>
  </thead>
    <% foreach (var item in Model.MEsCreditLimitList)
       { %>
    <tr>
        <td>
            <%:item.MEsName %>
        </td>
        <td>
            <%:item.CurrencyCode %>
        </td>
        <td>
            <%:item.Amount %>
        </td>
        <td>
            <%:item.EffictiveFrom %>
        </td>
        <td>
            <%:item.ExpireOn %>
        </td>
        <td>
           <a href="/Administrator/MEsCreditLimit/Edit/<%:item.MEsCreditLimitId %>" class="edit" title="Edit">
                        </a><a href="/Administrator/MEsCreditLimit/Delete/<%:item.MEsCreditLimitId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
        </td>
    </tr>
    <%} %>
    
      </table>
      </div>
</asp:Content>
