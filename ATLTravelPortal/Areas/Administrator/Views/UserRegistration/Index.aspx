<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<List<TravelPortalEntity.vw_BackofficeUsers>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All Registered Backoffice User :Arihant Holidays
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TempData["TemoResetPassword"] != null)
      { %>
    <div class="ui-widget">
        <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all">
            <p>
                <span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
                Password Successfully Changed.Here is new password.<strong>
                    <%string Resetpass = (string)TempData["TemoResetPassword"];%></strong>
                <%:Html.TextBox("PassReset", Resetpass)%>
            </p>
        </div>
    </div>
    <%}%>
    <%if (TempData["ResponseMsg"] != null)
      { %>
    <div class="ui-widget">
        <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all">
            <p>
                <span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-alert"></span>
                <strong>Alert:</strong>
                <%:TempData["ResponseMsg"] %></p>
        </div>
    </div>
    <%}%>
    <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
              {
                  UpdateTargetId = "UserPartial",
                  InsertionMode = InsertionMode.Replace
              ,
                  HttpMethod = "Post"
              }, new { @class = "validate" }))
      { %>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <input type="button" value="New" class="new" onclick="document.location.href='/Administrator/UserRegistration/Create/'" /></li>
            </ul>
        </div>
        <h3>
            <a class="icon_plane" href="#">User Management</a> <span>&nbsp;</span><strong>User Registration</strong>
        </h3>
    </div>
    <div id="UserPartial">
        <%Html.RenderPartial("UserPartial"); %>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
