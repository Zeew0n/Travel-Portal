<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusCategoryModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Catagory Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm("Create", "MobileServiceProvider", FormMethod.Post, new { @class = "Validate", @autocomplete = "off", enctype = "multipart/form-data" }))
      {%>
    <div class="pageTitle">
    <ul class="buttons-panel">
               
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
       
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Bus City</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusCategoryName)%>: <span class="labelDetail">
                            <%: Model.BusCategoryName%></span>
                    </div>
                </div>
               
            </div>
            
        </div>
     <%--   <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <div id="Div1">
                    </div>
                </li>
                <li>
                    <%:Html.ActionLink("Create", "Create", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Edit", "Edit", new { id = Model.BusCategoryId, controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Delete", "Delete", new { id = Model.BusCategoryId, controller = "BusCategory", area = "Bus" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                </li>
                <li>
                    <%:Html.ActionLink("List", "Index", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
        </div>--%>
    </div>
    <%} %>
    <p style="color: Red">
        <%:TempData["Error"] %>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

