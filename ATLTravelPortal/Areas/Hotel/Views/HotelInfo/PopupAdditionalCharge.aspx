<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelAdditionalCharge>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PopupAdditionalCharge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <% Html.EnableClientValidation();%>     
        
    
    <% using (Html.BeginForm("PopupAdditionalCharge", "HotelInfo", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
             
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ChargeName)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.ChargeName, new { @class = "required" })%>
            <%: Html.ValidationMessageFor(model => model.ChargeName)%>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Detail)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Detail)%>
            <%: Html.ValidationMessageFor(model => model.Detail)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Rate)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Rate)%>
            <%: Html.ValidationMessageFor(model => model.Rate)%>
        </div>
            
       <%-- <div class="editor-label">
            <%: Html.LabelFor(model => model.HotelName)%>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.HotelName, Model.HotelNameList)%>
            <%: Html.ValidationMessageFor(model => model.HotelName)%>
        </div>--%>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.isActive)%>
        </div>
        <div class="editor-field">
            <%: Html.CheckBoxFor(model => model.isActive)%>
           
        </div>
            
         <div class="editor-label"> <label></label>
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
