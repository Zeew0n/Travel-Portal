<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusCityModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   City Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm("Create", "MobileServiceProvider", FormMethod.Post, new { @class = "Validate", @autocomplete = "off", enctype = "multipart/form-data" }))
      {%>
    <div class="pageTitle">
        
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Bus City</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusCityCode)%>: <span class="labelDetail">
                            <%: Model.BusCityCode%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.BusCityName)%>: <span class="labelDetail">
                            <%: Model.BusCityName%></span>
                    </div>
                </div>
            </div>
            
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.StatusName)%>: <span class="labelDetail">
                            <%: Model.StatusName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                       
                    </div>
                </div>
            </div>
        </div>
        <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <div id="Div1">
                    </div>
                </li>
                <li>
                    <%:Html.ActionLink("Create", "Create", new { controller = "BusCity", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Edit", "Edit", new { id = Model.BusCityId, controller = "BusCity", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Delete", "Delete", new { id = Model.BusCityId, controller = "BusCity", area = "Bus" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                </li>
                <li>
                    <%:Html.ActionLink("List", "Index", new { controller = "BusCity", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
        </div>
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

