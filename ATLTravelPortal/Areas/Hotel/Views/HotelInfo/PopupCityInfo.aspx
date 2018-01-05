<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelCityInfos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PopupCityInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("PopupCityInfo", "HotelInfo", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
        <legend></legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.CityName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.CityName)%>
            <%: Html.ValidationMessageFor(model => model.CityName)%>
        </div>
         <div class="editor-label">
                <%: Html.LabelFor(model => model.CountryId)%>
            </div>
            <div class="editor-field">               
               <%: Html.DropDownListFor(model => model.CountryId, new SelectList(Model.HotelCountryList, "CountryId", "CountryName"))%>                
               <%= Html.ValidationMessageFor(m => m.CountryId)%>   
            </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Details) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Details)%>
            <%: Html.ValidationMessageFor(model => model.Details)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.isActive) %>
        </div>
        <div class="editor-field">
            <%: Html.CheckBoxFor(model => model.isActive) %>            
        </div>
        <div class="editor-label">
            <label>
            </label>
        </div>
        <div class="editor-field">
            <input type="submit" value="Save" />  
            
                <%
                    if ( ViewData["success"] != null )
                    { %>
                     <%: ViewData["success"] %>    
                     <%    
                    }
                 %>          
        </div>
    </fieldset>
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">

</asp:Content>
