<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ServiceProviderAccountSettingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Service Provider Setting
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
                </li>
            </ul>
        </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Service Provider Setting</strong>
        </h3>
    </div>
    <div id="ListTable">
        <% int counter = 0;
           foreach (var item in Model.ServiceProviders)
           {
               item.CountIndex = counter; %>
        <%Html.RenderPartial("IndividualServiceProvider", item); %>
        <% counter++;
         } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        .error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
