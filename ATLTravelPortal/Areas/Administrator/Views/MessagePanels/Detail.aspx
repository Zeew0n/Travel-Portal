<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MessagePanelsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
            </li>
            <li>
               <%-- <%:Html.ActionLink("Cancel", "Index", new { controller = "MessagePanels" }, new { @class = "cancel" })%>--%>
                 <input type="button" onclick="document.location.href='/Administrator/MessagePanels/Index'"
                    value="Cancel" /></li>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Message Panel</a> <span>&nbsp;</span><strong>Details</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%= System.Web.HttpUtility.HtmlDecode(Model.MessageText)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
