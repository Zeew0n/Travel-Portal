<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelRoomTypes>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <%Html.EnableClientValidation(); %>

    <%
     if (ViewData["success"] != null)
     { %>
       <%: ViewData["success"] %>
         <%    
      }
      %>



        <%  using (Html.BeginForm("Create", "HotelRoomType", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off" }))
    
    {%>

   <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Room Type</h3>
        </div>
        <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelRoomType" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
    </div>


    



  

<%: Html.ValidationSummary(true, "Fix following errors!")%>

<fieldset>
    <legend></legend>
    <div class="editor-label">
        <%: Html.Label("Room Type") %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.TypeName)%>
        <%: Html.ValidationMessageFor(model => model.TypeName)%>
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
        <%: Html.TextAreaFor(model => model.Details)%>
        <%: Html.ValidationMessageFor(model => model.Details)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.isActive) %>
    </div>
    <div class="editor-field">
        <%: Html.CheckBoxFor(model => model.isActive)%>
    </div>
    <div class="editor-label">
        <label>
        </label>
    </div>
    <div class="editor-field">
         <%--<input type="submit" value="<%: Model.formSubmitBttnName %>" />--%>
        <%-- <input type="submit" value="Save" />
         <input type="button" value="Cancel" onclick="document.location.href='/HotelRoomType/List'" />--%>
   
      
    </div>
</fieldset>
<% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
  
   
</asp:Content>

