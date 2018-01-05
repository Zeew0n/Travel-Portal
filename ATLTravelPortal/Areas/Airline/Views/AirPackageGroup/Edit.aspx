<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageGroupModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% Html.RenderPartial("~/Views/Shared/Utility/VUC_ActionResponse.ascx"); %>
   <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

     <div class="pageTitle">
            <ul class="buttons-panel">
                <li><div id="loadingIndicator"></div></li>

                <li><input type="submit" value="Update" /> </li>
                <li>
                    <input type="button" onclick="document.location.href='/Airline/AirPackageGroup/Index'" value="Cancel" />
                </li>
           </ul>          
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create Group Package</strong>
        </h3>
    </div>
        <% Html.RenderPartial("VUC_Create"); %>
  <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script src="/Content/ckeditor/ckeditor.js" type="text/javascript"></script> 
</asp:Content>
