<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelTypeInfos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
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


   <%  using (Html.BeginForm("Create", "HotelTypeInfo", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off" }))
   
    {%>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Type</h3>
        </div>
        <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelTypeInfo" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
    </div>
   

    
    <fieldset>
         <div class="editor-label">
                <%: Html.LabelFor(model => model.HotelTypeName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.HotelTypeName) %>
                <%: Html.ValidationMessageFor(model => model.HotelTypeName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.isActive) %>
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

