<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.TravelFareModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
        if (TempData["classname"] != null)
        { %>
    <%: TempData["classname"]%>
    <%
    
        }
    %>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
   
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <input type="submit" value="Save"  /></li>
            <li>
               <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/TravelFare/Index'" />

            </li>
        </ul>
        <h3>
           Setup<span>&nbsp;</span><strong>Domestic Paper Fare</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Flight Type")%></label>
                        <%: Html.DropDownListFor(model => model.FlightTypeId, (SelectList)ViewData["FlightTypes"])%>
                        <%: Html.ValidationMessageFor(model => model.FlightTypeId, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Airline") %>
                        </label>
                        <%: Html.DropDownListFor(model => model.AirlineId, (SelectList)ViewData["Airline"],"---Select---")%>
                        <%: Html.ValidationMessageFor(model => model.AirlineId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Departure City") %></label>
                        <%: Html.DropDownListFor(model => model.DepartureCityId, (SelectList)ViewData["DepartureCity"], "----Select----")%>
                        <%: Html.ValidationMessageFor(model => model.DepartureCityId, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Arrival City") %></label>
                        <%: Html.DropDownListFor(model => model.DestinationCityId, (SelectList)ViewData["DepartureCity"], "----Select----")%>
                        <%: Html.ValidationMessageFor(model => model.DestinationCityId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Class") %></label>
                        <%: Html.DropDownListFor(model => model.FlightClassId, (SelectList)ViewData["FlightClasses"])%>
                        <%: Html.ValidationMessageFor(model => model.FlightClassId, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Tour Code") %></label>
                        <%:Html.TextBoxFor(model=>model.TourCode) %>
                        <%: Html.ValidationMessageFor(model => model.TourCode,"*")%>
                    </div>
                </div>
            </div>
            
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Flight Season") %>    </label>
                            <%:Html.DropDownListFor(model => model.FlightSeasonId, (SelectList)ViewData["FlightSeasons"])%>
                            <%:Html.ValidationMessageFor(model => model.FlightSeasonId, "*")%>
                    
                    </div>
                </div>
            </div>
             <br />
        <fieldset class="style1">                    
      <legend> One Way Fare</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Fare ")%>
                        </label>
                        <%: Html.TextBoxFor(model => model.OneWayFare)%>
                        <%: Html.ValidationMessageFor(model => model.OneWayFare)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Fare in $") %>
                        </label>
                        <%:Html.TextBoxFor(model=>model.OneWayFareUSD) %>
                    </div>
                </div>
            </div>
          </fieldset>


          <br />
       <fieldset class="style1">                    
      <legend> Round Trip Fare</legend>
           
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Going Fare ")%></label>
                            <%: Html.TextBoxFor(model => model.GoingFare, new {@class="txt" })%>
                            <%: Html.ValidationMessageFor(model => model.GoingFare)%>
                        
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    <label>
                            <%: Html.Label("Going Fare in $ ")%>  </label>
                            <%: Html.TextBoxFor(model => model.RoundWayGoingUSD)%>
                   </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                         <label>
                            <%: Html.Label("Return Fare ") %></label>
                        <%: Html.TextBoxFor(model => model.RoundWayFare, new {@class="txt" })%>
                        <%: Html.ValidationMessageFor(model => model.RoundWayFare) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Return Fare in $ ") %></label>
                        <%: Html.TextBoxFor(model => model.RoundWayReturnUSD)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Total Round Trip Fare")%>
                        </label>
                        <%:Html.TextBoxFor(model=>model.TotalRoundTripFare,new{@readonly = "readonly"}) %>
                        <%: Html.ValidationMessageFor(model => model.TotalRoundTripFare)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Total Round Trip in $") %>
                        </label>
                        <%:Html.TextBoxFor(model => model.RoundWayFareUSD, new { @readonly = "readonly" })%>
                    </div>
                </div>
            </div>
            </fieldset>
            <br />
             
            <fieldset class="style1">
        <legend>Child/Infant Fare</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                <label> <%:Html.Encode("Child Fare")%></label>
                    <%: Html.TextBoxFor(model => model.ChildFare)%>
                    <%: Html.ValidationMessageFor(model => model.ChildFare) %>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                <label>
                        <%:Html.Label("Child Fare ($)") %></label>
                <%: Html.TextBoxFor(model => model.ChildFareUSD)%>
                 <%: Html.ValidationMessageFor(model => model.ChildFareUSD)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Child Fare On") %></label>
                    <%:Html.DropDownListFor(model => model.ChildFareOn, (SelectList)ViewData["ChildFairOns"])%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                 <label> <%:Html.Encode("Type")%></label>
                    <%: Html.DropDownListFor(model => model.ChildFareType, (SelectList)ViewData["ChildFairTypes"])%>

                    
                </div>
            </div>
        </div>
        <hr />
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                <label>
                  <%: Html.Encode("Infant Fare")%></label>
                    <%: Html.TextBoxFor(model => model.InfantFare)%>
                    <%: Html.ValidationMessageFor(model => model.InfantFare) %>
                   
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.Label("Infant Fare ($)")%></label>
                  <%: Html.TextBoxFor(model => model.InfantFareUSD)%>
                    <%: Html.ValidationMessageFor(model => model.InfantFareUSD)%> 
                </div>
            </div>
        </div>

        
      
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Infant Fare On") %></label>
                    <%:Html.DropDownListFor(model => model.InfantFareOn, (SelectList)ViewData["ChildFairOns"])%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                   <label><%:Html.Encode("Type") %></label> 
                    <%: Html.DropDownListFor(model => model.InfantFareType, (SelectList)ViewData["ChildFairTypes"])%>
                  
                </div>
            </div>
        </div>
        </fieldset>
         
       <br />
        <fieldset class="style1">
            <legend>Other Charges</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Fuel Charge")%>
                        </label>
                        <%: Html.TextBoxFor(model => model.FuelCharge)%>
                        <%: Html.ValidationMessageFor(model => model.FuelCharge) %>
                    </div>
                </div>
                
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Refund Fee")%>
                        </label>
                        <%: Html.TextBoxFor(model => model.RefundFee) %>
                        <%: Html.ValidationMessageFor(model => model.RefundFee) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    <label>
                           <%: Html.LabelFor(model => model.RefundFeeDollar) %>
                    </label>
                    <%: Html.TextBoxFor(model => model.RefundFeeDollar) %>
                    <%: Html.ValidationMessageFor(model => model.RefundFeeDollar) %>

                       
                    </div>
                </div>
            </div>
           <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                     <label>
                            <%: Html.Label("Reissue Fee")%>
                        </label>
                        <%: Html.TextBoxFor(model => model.ReissueFee) %>
                        <%: Html.ValidationMessageFor(model => model.ReissueFee) %>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                       <%: Html.LabelFor(model => model.ReissueFeeDollar)%>
                    </label>
                    <%: Html.TextBoxFor(model => model.ReissueFeeDollar) %>
                    <%: Html.ValidationMessageFor(model => model.ReissueFeeDollar)%>
                </div>
            </div>
        </div>
            </fieldset>

          <br />
        <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Effective From")%> </label>
                            <%: Html.TextBoxFor(model => model.EffectiveFrom)%>
                            <%: Html.ValidationMessageFor(model => model.EffectiveFrom) %>
                       
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Expire On")%>
                        </label>
                        <%: Html.TextBoxFor(model => model.ExpireOn)%>
                    </div>
                </div>
            </div>

        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
             <label>
                        <%: Html.Label("Currencies")%></label>
                    <%: Html.DropDownListFor(model => model.CurrencyId, (SelectList)ViewData["CurrencyType"])%>
                    <%: Html.ValidationMessageFor(model => model.CurrencyId) %>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                 <div>
                     <label>  <%:Html.Label("Valid till further notice") %></label>
                    <%:Html.CheckBoxFor(model => model.ValidTillFurtherNotice)%>
                  </div>
                </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div id="Error">
                    <label>
                    <p style="color:Red" > <%= TempData["Error"] %>
                    <%=TempData["City"]%></p>
                    </label>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                  
                   
                </div>
            </div>
        </div>
         
        <div class="row1 mrg-top-20">
            <p class="txtstyle2">
                <%:Html.Label("Terms and Conditions") %></p>
            <%= Html.TextArea("Information", Model.TermsAndConditions, new { @class = "ckeditor" })%>
        </div>
        </div>
         <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button" onclick="document.location.href='/Airline/TravelFare/Index'" value="Cancel"  />  
                </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
        <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                /////// Get Flight Class Code  with respect to Airline Name////////////////////////////////////
                $("#AirlineId").live("change", function () {
                    id = $("#AirlineId").val();
                    if (id == "") {
                        $("#FlightClassId").empty();
                        $("#FlightClassId").append("<option value='" + "" + "'>" + "--Not selected--" + "</option>");
                        return false;
                    }
                    else {
                        $("#FlightClassId").empty();
                        //build the request url
                        var url = "/Airline/AjaxRequest/GetFlightClassCodeByAirline";
                        //fire off the request, passing it the id which is the MakeID's selected item value
                        $.getJSON(url, { id: id }, function (data) {
                            //Clear the Model list
                            $("#FlightClassId").empty();
                            //Foreach Model in the list, add a model option from the data returned
                            $.each(data, function (index, optionData) {

                                $("#FlightClassId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                            });
                        });
                    }
                }).change();

          });

        $(document).ready(function () {
            $(".save").click(function () {
                if ($("#DepartureCityId").val() == $("#DestinationCityId").val()) {
                    $("#Error").text("Departure and Destination city are equal").css("color", "Red");
                    return false;
                }
            });
        });
        //////////////////////////////////////////////////Start of Date Picker /////////////////////////////////////
        $(function () {
            var dates = $("#EffectiveFrom, #ExpireOn").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                disable: true,
                buttonImage: '../../Content/images/calendar.gif',
                showAnim: 'fold',
                onSelect: function (selectedDate) {
                    var option = this.id == "EffectiveFrom" ? "minDate" : "maxDate",
                instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
                instance.settings.dateFormat ||
                $.datepicker._defaults.dateFormat,
                selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });
        });

        //////////////////////////////////////////////////End of Date Picker /////////////////////////////////////

        $(document).ready(function () {
            $(".txt").each(function () {

                $(this).keyup(function () {
                    calculateSum();
                });
            });
            $(".txt1").each(function () {

                $(this).keyup(function () {
                    calculateSum1();
                });
            });
        });
        function calculateSum() {

            var sum = 0;
            //iterate through each textboxes and add the values
            $(".txt").each(function () {

                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }

            });
            //.toFixed() method will roundoff the final sum to 2 decimal places
            $("#TotalRoundTripFare").val(sum.toFixed(2));
        }

        //////////////Calculate sum in $/////////////////////////////
        function calculateSum1() {

            var sum = 0;
            //iterate through each textboxes and add the values
            $(".txt1").each(function () {

                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }

            });
            //.toFixed() method will roundoff the final sum to 2 decimal places
            $("#RoundWayFareUSD").val(sum.toFixed(2));
        }
    </script>
</asp:Content>
