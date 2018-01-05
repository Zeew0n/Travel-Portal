<%@ Page Title="" Language="C#"  MasterPageFile="~/Views/Shared/MRCMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.MobileRechargeCard.Models.CardValueModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation();%>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <input type="submit" value="Update" />
            </li>
            <li><%:Html.ActionLink("Cancel", "Index", new { controller = "CardValue", area = "MobileRechargeCard" }, new { @class = "linkButton" })%>
        </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Card Value</strong>
        </h3>
    </div>
    <%:Html.HiddenFor(model => model.CardValueId) %>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label><%:Html.Label("Card Value") %></label>
                    <%:Html.TextBoxFor(model => model.CardValue)%>
                    <%:Html.ValidationMessageFor(model => model.CardValue)%>
                </div>
            </div>          
        </div>
         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Card Desc") %></label>
                    <%: Html.TextBoxFor(model => model.CardValueDesc)%>
                    <%:Html.ValidationMessageFor(model => model.CardValueDesc)%>
                </div>
            </div>            
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                 <div>
                    <label>
                       <%: Html.Label("Is Active") %></label>
                    <%: Html.CheckBoxFor(model => model.IsActive)%>
                    <%:Html.ValidationMessageFor(model => model.IsActive)%>
                </div>
            </div>           
        </div>        
       
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
