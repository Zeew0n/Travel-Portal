<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookInputModel>" %>

  <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("BookOption", "AirOfflineBook", FormMethod.Post, new { @onsubmit ="return false;" }))
       {%>
        <%: Html.ValidationSummary(true) %>
        <br />
        <fieldset>
           
            
            <div class="editor-label">
             <strong>  <%: Html.LabelFor(model => model.BookingType) %></strong> 
            </div>
           
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.BookingType, new[]
        { 
            new SelectListItem { Text = "International", Value = "International" }, 
            new SelectListItem { Text = "Domestic", Value = "Domestic" } 
        }, "-- Select--", new { @class = "required"}) %>
        <span class="redtxt">*</span>
                <%: Html.ValidationMessageFor(model => model.BookingType,"*") %>
            </div>
            <br />
            <div class="editor-label">
             <strong>   <%: Html.LabelFor(model => model.JourneyType) %></strong>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.JourneyType, new[]
        { 
            new SelectListItem { Text = "Oneway", Value = "OneWay" }, 
            new SelectListItem { Text = "Roundtrip", Value = "RoundTrip" } 
        }, "-- Select--", new { @class = "required" }) %>
        <span class="redtxt">*</span>
                <%: Html.ValidationMessageFor(model => model.JourneyType, "*") %>
            </div>
            <br />
            <p>
                <input type="button" value="Create" onclick="jqueryPost(this.form,'ContentBookingFormPanel')" />
            </p>
        </fieldset>
        <div id="ContentBookingFormPanel">
        
        </div>
    <% } %>
    

