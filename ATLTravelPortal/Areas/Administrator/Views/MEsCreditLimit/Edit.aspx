<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MEsCreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
               <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
                <label id="lblSuccess" style="display: none; color: Green; font-weight: bold;">
                </label>
            </li>           
        </ul>
        <h3>
            MEs CreditLimit <span>&nbsp;</span><strong>Edit</strong>
        </h3>
    </div>
          <% Html.RenderPartial("VUC_Add"); %>
           <div>
        <input type="submit" value="Save" />
       <input type="button" onclick="document.location.href='/Administrator/MEsCreditLimit/Index'"
            value="Back To List" class="float-right" />
    </div>

    <% } %>  
</asp:Content>

