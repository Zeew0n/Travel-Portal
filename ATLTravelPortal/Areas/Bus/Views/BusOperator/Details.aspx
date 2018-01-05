<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusMasterModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Bus Operator Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm("Create", "MobileServiceProvider", FormMethod.Post, new { @class = "Validate", @autocomplete = "off", @enctype = "multipart/form-data" }))
      {%>
    <div class="pageTitle">
      <ul class="buttons-panel">
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BusOperator", area = "Bus" }, new { @class = "linkButton" })%>
             </ul>   
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Bus Operator</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusMasterName)%>: <span class="labelDetail">
                            <%: Model.BusMasterName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ContactPerson)%>: <span class="labelDetail">
                            <%: Model.ContactPerson%></span>
                    </div>
                </div>
            </div>
            
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.ContactAddress)%>: <span class="labelDetail">
                            <%: Model.ContactAddress%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                       <%: Html.LabelFor(model => model.Phone)%>: <span class="labelDetail">
                            <%: Model.Phone%></span>
                    </div>
                    <div>
                       <%: Html.LabelFor(model => model.Mobile)%>: <span class="labelDetail">
                            <%: Model.Mobile%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                <div style="width:98%;text-align:center;">Orerator Logo</div>
                <div id="img" style="overflow: auto; max-height: 175px; min-height: 80px;text-align:center;">
                  <img id="peoImg" src="<%=Model.LogoUrl %>" width="70" height="70" alt="<%=Model.BusMasterName%>" />
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                </div></div>

        </div>
        <%--<div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <div id="Div1">
                    </div>
                </li>
                <li>
                    <%:Html.ActionLink("Create", "Create", new { controller = "BusOperator", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Edit", "Edit", new { id = Model.BusMasterId, controller = "BusOperator", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Delete", "Delete", new { id = Model.BusMasterId, controller = "BusOperator", area = "Bus" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                </li>
                <li>
                    <%:Html.ActionLink("List", "Index", new { controller = "BusOperator", area = "Bus" }, new { @class = "linkButton" })%>
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

