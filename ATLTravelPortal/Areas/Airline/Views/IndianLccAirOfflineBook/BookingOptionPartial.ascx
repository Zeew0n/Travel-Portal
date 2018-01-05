<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookInputModel>" %>
   <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("BookOption", "IndianLccAirOfflineBook", FormMethod.Post, new { @onsubmit = "return false;" }))
       {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BookingType) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.BookingType, new[]
        { 
            new SelectListItem { Text = "International", Value = "International" }, 
            new SelectListItem { Text = "Domestic", Value = "Domestic" } 
        }, "-- Select--", new { @class = "required"}) %>
                <%: Html.ValidationMessageFor(model => model.BookingType,"*") %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JourneyType) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.JourneyType, new[]
        { 
            new SelectListItem { Text = "Oneway", Value = "OneWay" }, 
            new SelectListItem { Text = "Roundtrip", Value = "RoundTrip" } 
        }, "-- Select--", new { @class = "required" }) %>
                <%: Html.ValidationMessageFor(model => model.JourneyType, "*") %>
            </div>
            
            <p>
                <input type="button" value="Create" onclick="jqueryPost(this.form,'ContentBookingFormPanel')" style=" text-transform:capitalize;" />
            </p>
        </fieldset>
        <div id="ContentBookingFormPanel">
        
        </div>
    <% } %>
    



