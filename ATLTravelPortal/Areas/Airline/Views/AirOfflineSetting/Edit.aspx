<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel.AirOfflineSettingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <%: Html.HiddenFor(model=>model.AirlineId) %>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.AirlineName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AirlineName, new { ReadOnly = "ReadOnly" })%>
                <%: Html.ValidationMessageFor(model => model.AirlineName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AirlineCode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AirlineCode,new {ReadOnly="ReadOnly"}) %>
                <%: Html.ValidationMessageFor(model => model.AirlineCode) %>
            </div>
                   
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IsOffline) %>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(model => model.IsOffline) %>
                <%: Html.ValidationMessageFor(model => model.IsOffline) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

