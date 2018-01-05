<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.NewsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("~/Views/Shared/Utility/VUC_ActionResponse.ascx"); %>
    <%using (Html.BeginForm("", "", FormMethod.Post, new { @autocomplete = "off" }))
      { %>
        <%=Html.ValidationSummary(true)%>
        <% Html.RenderPartial("VUC_Add"); %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  
    <script src="/Content/ckeditor/ckeditor.js" type="text/javascript"></script>
  
</asp:Content>
