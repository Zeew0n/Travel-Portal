<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelFacilities>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <%Html.EnableClientValidation(); %>
<%
    if ( ViewData["success"] != null )
    { %>
     <%: ViewData["success"] %>
    
     <%
    
    }
 %>

 
    <%  using (Html.BeginForm("Create", "HotelFacility", FormMethod.Post, 
        new { @id = "ATForm", @autocomplete = "off"}))
    {%>

  <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Facility</h3>
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

 




    <%: Html.ValidationSummary(true, "Fix following errors!")%>
    

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
                <%--<input type="submit" value="<%: Model.formSubmitBttnName %>" />--%>
                <%--<input type="submit" value="Save" />
                <input type="button" value="Cancel" onclick="document.location.href='/HotelFacility/List'"  />--%>
            </div>
    </fieldset>

<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
   
   
</asp:Content>
