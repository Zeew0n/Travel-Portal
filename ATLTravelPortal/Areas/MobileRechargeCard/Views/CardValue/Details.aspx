<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MRCMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.CardValueModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
           <%-- <li>
                <%:Html.ActionLink("Create", "Create", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
            <li>
                <%:Html.ActionLink("Edit", "Edit", new { id = Model.CardValueId, controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
            <li>
                <%:Html.ActionLink("Delete", "Delete", new { id = Model.CardValueId, controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
            </li>--%>
            <li>
                <%:Html.ActionLink("Cancel", "Index", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Card Value</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.Label("Card Value") %>: <span class="labelDetail">
                        <%: Model.CardValue %></span>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%: Html.Label("Card Desc") %>: <span class="labelDetail">
                        <%: Model.CardValueDesc%></span>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%: Html.Label("Status") %>: <span class="labelDetail">
                        <%:Model.StatusName%></span>
                </div>
            </div>
        </div>
    </div>
 <%--   <div class="buttonBar">
        <ul class="buttons-panel">
            <li>
                <%:Html.ActionLink("Create", "Create", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
            <li>
                <%:Html.ActionLink("Edit", "Edit", new { id = Model.CardValueId, controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
            <li>
                <%:Html.ActionLink("Delete", "Delete", new { id = Model.CardValueId, controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
            </li>
            <li>
                <%:Html.ActionLink("List", "Index", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
            </li>
        </ul>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
