<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.FXRateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>Approve FX Rate</strong>
        </h3>
    </div>
    <div class="contentGrid">
        <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                <th>
                 SNo
                </th>
                    <th>
                        Rate
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                       Action
                    </th>
                </tr>
            </thead>
            <%
                var sno = 0;
                foreach (var item in Model.FXRateList)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:item.SNO %>
                </td>
                <td>
                    <%: String.Format("{0:F}", item.ExchangeRate) %>
                </td>
                <td>
                    <%: String.Format("{0:g}", item.CreatedDate) %>
                </td>
                <td>
                    <% if (item.isApproved == false)
                       { %>
                    <%: Html.ActionLink("Approve", "Approve", new {  id=item.FXRateId}, new { @onclick = "return confirm('Do you want to approve?')" })%>
                    <%} %>
                </td>
                <td>
                </td>
            </tr>
            <% } %>
        </table>

          <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.FXRateList.PageSize, ViewData.Model.FXRateList.PageNumber, ViewData.Model.FXRateList.TotalItemCount)%>
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
