<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.OperatorBusCategoryModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   City Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm("Create", "MobileServiceProvider", FormMethod.Post, new { @class = "Validate", @autocomplete = "off", enctype = "multipart/form-data" }))
      {%>
    <div class="pageTitle">
     <div class="float-right">
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
       </div>         
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Operator Category</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusMasterId)%>: <span class="labelDetail">
                            <%: Model.BusMasterName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.BusCategoryId)%>: <span class="labelDetail">
                            <%: Model.BusCategorName%></span>
                    </div>
                </div>
            </div>
             <div class="form-box1-row">
            <div class="form-box1-row-content ">
                    <div style="text-align:left;font-weight:bold">
                        Facility 
                    </div>
                </div>
               
            </div>
            <div class="form-box1-row">
            <div class="form-box1-row-content ">
                    <div>
                            <%:MvcHtmlString.Create(Model.FacilityDetails)%>
                    </div>
                </div>
               
            </div>
             <div class="form-box1-row">
            <div class="form-box1-row-content ">
                    <div style="text-align:left;font-weight:bold">
                        Fare Rules 
                    </div>
                </div>
               
            </div>
            <div class="form-box1-row">
            <div class="form-box1-row-content ">
                    <div>
                            <%:MvcHtmlString.Create(Model.FareRules)%>
                    </div>
                </div>
               
            </div>
        </div>
       <%-- <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <div id="Div1">
                    </div>
                </li>
                <li>
                    <%:Html.ActionLink("Create", "Create", new { controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Edit", "Edit", new { id = Model.OBCategoryId, controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Delete", "Delete", new { id = Model.OBCategoryId, controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                </li>
                <li>
                    <%:Html.ActionLink("List", "Index", new { controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
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

