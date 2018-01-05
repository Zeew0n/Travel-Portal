<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotoCategories>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%: Html.ValidationSummary(true, "Fix following errors!")%>
    <%Html.EnableClientValidation(); %>
<%
    if ( ViewData["success"] != null )
    { %>
     <%: ViewData["success"] %>    
     <%    
    }
 %>
 

  <%  using (Html.BeginForm("Edit", "HotelPhotoCategory", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off" })) 
   
    {%>

<div class="box3">
        <div class="userinfo">
            <h2>Edit Hotel Photo Category</h2>
        </div>
        <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelPhotoCategory" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
    </div>

    <fieldset>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.CategoryName)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.CategoryName, new { @class = "required" })%>
            <%: Html.ValidationMessageFor(model => model.CategoryName)%>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Details)%>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Details)%>
            <%: Html.ValidationMessageFor(model => model.Details)%>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.HotelId)%>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.HotelId, new SelectList(Model.HotelNameList, "HotelId", "HotelName"))%>
            <%: Html.ValidationMessageFor(model => model.HotelId)%>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.isActive)%>
        </div>
        <div class="editor-field">
            <%: Html.CheckBoxFor(model => model.isActive)%>
            
        </div>
            
         <div class="editor-label"> <label></label>
           </div>
           
    </fieldset>

<% } %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">

  
</asp:Content>
