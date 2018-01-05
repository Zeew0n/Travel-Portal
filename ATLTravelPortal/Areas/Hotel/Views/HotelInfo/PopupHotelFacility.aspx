<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelFacilities>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PopupHotelFacility
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <%Html.EnableClientValidation(); %>

     <% using (Html.BeginForm("PopupHotelFacility", "HotelInfo", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
             <div class="editor-label">
            <%: Html.LabelFor(model => model.FacilityName)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.FacilityName, new { @class = "required" })%>
            <%: Html.ValidationMessageFor(model => model.FacilityName)%>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Details)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Details)%>
            <%: Html.ValidationMessageFor(model => model.Details)%>
        </div>

      
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.isActive)%>
        </div>
        <div class="editor-field">
            <%: Html.CheckBoxFor(model => model.isActive)%>
            
        </div>
            
         <div class="editor-label"> <label></label>
           </div>
            <div class="editor-field">
                <input type="submit" value="<%: Model.formSubmitBttnName %>" />
                
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
