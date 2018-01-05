<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Bank Management
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%Html.ValidationSummary(); %>
    <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
                      {
                          UpdateTargetId = "ListPartial",
                          InsertionMode = InsertionMode.Replace
                      ,
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
      { %>


     <div class="pageTitle">
        <div class="float-right">
            	<%:Html.ActionLink("New", "Create", new { controller = "BankManagement" }, new { @class = "linkButton float-left" })%>
              <%-- <%:Ajax.ActionLink("New", "Create", new { controller = "BankManagements", action = "Create" }, new AjaxOptions(), new {@class="new" })%>--%>
              <input type="submit" value="Search"  />
              <%=Ajax.ActionLink("Show All"
                                    , "Index"
                                    , new
                                    {
                                        controller = "BankManagement",
                                        action = "Index",
                                    }
                                    , new AjaxOptions() { UpdateTargetId = "ListPartial", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "linkButton float-right" })%>    
            </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Bank Management</strong>
        </h3>
    </div>



     <% Html.EnableClientValidation(); %>
     <%: Html.ValidationSummary(true)%>
   
    <div id="ListPartial">
    <%Html.RenderPartial("BanksList"); %>
    </div>
      <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
