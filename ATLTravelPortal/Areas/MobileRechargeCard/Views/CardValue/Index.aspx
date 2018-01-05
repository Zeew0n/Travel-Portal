<%@ Page Title="" Language="C#"  MasterPageFile="~/Views/Shared/MRCMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.CardValueModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Card Type:Arihant Holidays
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
               <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
               
            </li>
            <li>
                <%:Html.ActionLink("New", "Create", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton", @title = "Create" })%>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Card Value</strong>
        </h3>
    </div>
    <div id="ListContant">
        <% if (Model != null)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Card Value
                </th>
                <th>
                    Card Desc
                </th>
                <th>
                    Status
                </th>
                <th>
                    Action
                </th>
            </thead>
            <tbody>
                <% var sno = 0;
                   foreach (var item in Model.CardValueList)
                   {
                       sno++;
                       var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter";
                %>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%: item.CardValue %>
                    </td>
                    <td>
                        <%: item.CardValueDesc%>
                    </td>
                    <td>
                        <%:item.StatusName%>
                    </td>
                    <td>
                        <p>
                            <%: Html.ActionLink(" ", "Details", new { id = item.CardValueId, controller = "CardValue" }, new { @class = "details", @title = "Details" })%>
                            <%:Html.ActionLink(" ", "Edit", new { id = item.CardValueId, controller = "CardValue" }, new { @class = "edit", @title = "Edit" })%>
                            <%:Html.ActionLink(" ", "Delete", new { id = item.CardValueId, controller = "CardValue" }, new { @class = "delete", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                        </p>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <%}
           else
           { %>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
