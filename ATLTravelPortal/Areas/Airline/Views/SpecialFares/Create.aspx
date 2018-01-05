<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SpecialFaresModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
     <%if (TempData["ErrorMessage"] != null)
      { %>
    <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all"> 
		    <p><span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
           <strong><% = TempData["ErrorMessage"]%></strong></p>
    </div>
    <%} %>
    <% using (Html.BeginForm("Create", "SpecialFares", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       { %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li></li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Special Fare</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.FromCityName) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.FromCityName)%><span
                        class="redtxt">*</span>
                     <%: Html.ValidationMessageFor(model=>model.FromCityName) %>
                     <%:Html.HiddenFor(model => model.hdfFromCityId)%>
                    
                </div>
            </div>
        </div>
      
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                <label>
                <%: Html.LabelFor(model=>model.ToCityName) %>
                </label>
                    <%:Html.TextBoxFor(model => model.ToCityName)%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.ToCityName)%>
                     <%:Html.HiddenFor(model => model.hdfToCityId)%>
                        <div id="checkcityname">
                                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model=>model.AirlineName) %>
                </label>
                
                    <%:Html.TextBoxFor(model => model.AirlineName)%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.AirlineName)%>
                      <%:Html.HiddenFor(model => model.hdfAirlineName) %>
                </div>
            </div>
        </div>

         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model=>model.RegularFare) %>
                </label>
                
                    <%:Html.TextBoxFor(model => model.RegularFare)%><span
                        class="redtxt">*</span>
                      <%:Html.HiddenFor(model => model.RegularFare)%>

                </div>
            </div>
        </div>
         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model=>model.SpecialFare) %>
                </label>
                    <%:Html.TextBoxFor(model => model.SpecialFare)%><span
                        class="redtxt">*</span>
                     <%:Html.HiddenFor(model => model.SpecialFare)%>

                </div>
            </div>
        </div>


         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model=>model.EffectiveFrom) %>
                </label>
               
                    <%:Html.TextBoxFor(model => model.EffectiveFrom)%><span
                        class="redtxt">*</span>
                </div>
            </div>
        </div>
         <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model=>model.ExpireOn) %>
                </label>
                
                    <%:Html.TextBoxFor(model => model.ExpireOn)%><span
                        class="redtxt">*</span>
                </div>
            </div>
        </div>




    </div>
    <div class="buttonBar">
        <input type="submit" value="Save" />
        <input type="button" onclick="document.location.href='/Airline/SpecialFares/Index'"
            value="Cancel" />
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   <script type="text/javascript" language="javascript">
       $(function () {
           var dates = $("#EffectiveFrom, #ExpireOn").datepicker({
               defaultDate: "+1d",
               changeMonth: true,
               changeYear: true,
               constrainInput: true,
               numberOfMonths: 2,
               dateFormat: 'dd M yy',
               //minDate: Date(),
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






       ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
       $(document).ready(function () {

           $(function () {
               $("#AirlineName").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "/Airline/SectorSales/FindAirline", type: "POST", dataType: "json",
                           data: { searchText: request.term, maxResult: 5 },

                           success: function (data) {
                               response($.map(data, function (item) {
                                   return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                               }))
                           }
                       });
                   },
                   width: 150,
                   select: function (event, ui) {
                       $("#hdfAirlineName").val(ui.item.id);
                   }

               });
           });



       });


       /////////////////////////////////////////End  Autocomplete ///////////////////////////////////////////////



       ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
       $(document).ready(function () {

           $(function () {

               $("#FromCityName").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "/Airline/SpecialFares/FindAirlineCity", type: "POST", dataType: "json",
                           data: { searchText: request.term, maxResult: 5},

                           success: function (data) {
                               response($.map(data, function (item) {
                                   return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                               }))
                           }
                       });
                   },
                   width: 150,
                   select: function (event, ui) {
                       $("#hdfFromCityId").val(ui.item.id);
                   }

               });


               $(function () {
                   $("#ToCityName").autocomplete({
                       source: function (request, response) {
                           $.ajax({
                               url: "/Airline/SpecialFares/FindAirlineCity", type: "POST", dataType: "json",
                               data: { searchText: request.term, maxResult: 5 },

                               success: function (data) {
                                   response($.map(data, function (item) {
                                       return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                   }))
                               }
                           });
                       },
                       width: 150,
                       select: function (event, ui) {

                           $("#hdfToCityId").val(ui.item.id);
                       }

                   });
               });

           });

       });
       /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////
       $(document).ready(function () {
           $("#ToCityName").blur(function () {
               $("#checkcityname").show();
               if ($("#hdfFromCityId").val() == $("#hdfToCityId").val()) {
                   $("#checkcityname").attr({ color: "Red" });
                   $("#checkcityname").html("<span style = 'color:red'>From City and To City shold be different. </span>")
               }
               else {
                   $("#checkcityname").hide();
               }


           });
       });





        </script>
  
 
</asp:Content>
