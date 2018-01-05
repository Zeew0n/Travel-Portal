<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelFacilities>" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Hotel Type
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Html.EnableClientValidation();%>  
     <%
    if ( ViewData["success"] != null )
    { %>
     <%: ViewData["success"] %>    
     <%    
    }
    %>

       <%  using (Html.BeginForm("Edit", "HotelFacility", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off" }))
   
    {%>
 <div class="box3">
        <div class="userinfo">
            <h2>Edit Hotel Facility</h2>
        </div>
        <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelFacility" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
    </div>
            

    <fieldset>
         <div class="editor-label">
                <%: Html.LabelFor(model => model.FacilityName)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FacilityName)%>
                <%: Html.ValidationMessageFor(model => model.FacilityName)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Details)%>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Details)%>
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
       
            </div>
    </fieldset>

<% } %>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
  
   
</asp:Content>
