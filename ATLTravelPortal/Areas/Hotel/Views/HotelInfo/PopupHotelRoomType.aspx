<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelRoomTypes>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PopupHotelRoomType
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
      <% Html.EnableClientValidation();%>     
     <% using (Html.BeginForm("PopupHotelRoomType", "HotelInfo", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>


     <fieldset>
    <legend></legend>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.TypeName) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.TypeName) %>
        <%: Html.ValidationMessageFor(model => model.TypeName) %>
    </div>
   
    <div class="editor-label">
        <%:Html.LabelFor (model=>model.RoomCapacity) %>
    </div>
    <div class="editor-field">
        <%:Html.TextBoxFor(model=>model.RoomCapacity) %>
        <%: Html.ValidationMessageFor(model => model.RoomCapacity)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.Details) %>
    </div>
    <div class="editor-field">
        <%: Html.TextAreaFor(model => model.Details) %>
        <%: Html.ValidationMessageFor(model => model.Details) %>
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
        if (ViewData["success"] != null)
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
