<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelAdditionalCharge>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
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


    <%  using (Html.BeginForm("Create","HotelAdditionalCharge", FormMethod.Post, 
        new { @id = "ATForm", @autocomplete = "off"}))
    {%>


   <div class="box3">
        <div class="userinfo">
            <h2>Hotel Additional Charge</h2>
        </div>
        <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelAdditionalCharge" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
    </div>


   
    

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
