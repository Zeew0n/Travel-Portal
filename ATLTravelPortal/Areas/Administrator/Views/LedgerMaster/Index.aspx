<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerMasterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="pageTitle">
        <div class="float-right">
            	<%:Html.ActionLink("New", "Create", new { controller = "LedgerMaster" }, new { @class = "linkButton" })%>
            </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Ledger Master</strong>
        </h3>
    </div>



    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Product
                </th>
                <th>
                    Account Group
                </th>
                <th>
                    Account Sub Group
                </th>
                <th>
                    Account Type
                </th>
                <th>
                    Ledger
                </th>
                <th>
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.LedgerMasterList)
               {
                   //sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNO%>
                    </td>
                    <td>
                        <%:item.ProductName%>
                    </td>
                    <td>
                        <%:item.AccGroupName%>
                    </td>
                    <td>
                        <%:item.AccSubGroupName%>
                    </td>
                    <td>
                        <%:item.AccTypeName%>
                    </td>
                    <td>
                        <%:item.LedgerName%>
                    </td>
                    <td>
                        <a href="LedgerMaster/Detail/<%:item.LedgerId %>" class="details" title="Details"></a>
                        <a href="LedgerMaster/Edit/<%:item.LedgerId %>" class="edit" title="Edit"></a>
                        <a href="LedgerMaster/Delete/<%:item.LedgerId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
        <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.LedgerMasterList.PageSize, ViewData.Model.LedgerMasterList.PageNumber, ViewData.Model.LedgerMasterList.TotalItemCount)%>
       </div>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
