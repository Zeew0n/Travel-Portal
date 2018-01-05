<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusCategoryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Bus Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%using (Html.BeginForm())
      {%>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
              <input type="submit" value="Update" />
                </li>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Edit Category</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.HiddenFor(m=>m.BusCategoryId) %>
                         <%: Html.LabelFor(model => model.BusCategoryName)%>
                        <%: Html.TextBoxFor(model => model.BusCategoryName)%>
                        <%: Html.ValidationMessageFor(model => model.BusCategoryName)%>
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
                    <%Html.RenderPartial("Utility/VUC_Message",Model.Message); %></li>
                
            </ul>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
