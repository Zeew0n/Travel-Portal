<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage <ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="myLoadingBox" style="display:none;"><strong>....... Process on creating offline Ticket........</strong></div>
 <% Html.RenderAction("BookOption", "IndianLccAirOfflineBook"); %>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery-ui-1.8.13.custom.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .error
        {
            color: #FF0000;
        }
        
        input.error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
        label.error
        {
            display: none;
        }
        
        input
        {
        text-transform: uppercase; 
        }
        
        
        
        #ui-datepicker-div, .ui-datepicker
        {
            font-size: 80%;
        }
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
            margin-bottom: -25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: 0 10px 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
        .ui-tpicker-grid-label
        {
            background: none;
            border: none;
            margin: 0;
            padding: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/Scripts/ATL.jquery.funtion.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-timepicker.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.validate').validate();
        });
  function submitBookingForm(thisForm, targetElm) {
            var alertMsg = "'Are you sure you want to Create Offline Booking?'";
            
            var isValid = $("#" + thisForm.id).valid();
            if (isValid && alertMsg != "") {
                if (confirm(alertMsg)) {
                    jqueryPost(thisForm, targetElm);
                }
            }
            return false;
            
        }
    <%-- Delete--%>

        var paxLastId = 1;
        var segLastId = 1;

        $(".delete").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Passenger_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });

        $(".deleteSegment").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Segment_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });

    </script>
    <!-- AutoComplete-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.agentAutoComplete').live('click', function () {
                $(this).autocomplete('destroy').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AjaxRequest/GetAgentNameListAC", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#UserDetail_AgentId").val(ui.item.id);
                    }
                });
            });
        }); 
  
    </script>
    <%--  Date and Mask--%>
    <script type="text/javascript">


        $('.passportExpire').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                defaultDate: new Date(),
                   changeMonth: true,
                changeYear: true,
                dateFormat: 'dd M yy',
                minDate: '+0d',
                maxDate: '+30y',
            }).focus();
        });


        $('.birthDate').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                defaultDate: new Date(),
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                      maxDate: new Date(),
                numberOfMonths: 1,
                disable: true,
                showAnim: 'fold',
                dateFormat: 'dd M yy',
                     yearRange: '-95'
            }).focus();
        });

      
        
        

        $('.DOB').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                defaultDate: new Date(),
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 1,
                disable: true,
                showAnim: 'fold',
                dateFormat: 'dd M yy',
                maxDate: new Date()

            }).focus();
        });



        $('.timepicker').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
                numberOfMonths: 1,
                dateFormat: 'dd M yy',
                minDate: 0
            }).focus();
        });


        $(".time").live('click', function () {

           $(".time").mask("99:99", { placeholder: "0" });


  
        });


    </script>
    <%--  Passenger 0--%>
    <script type="text/javascript">
        $("#AddPassenger0").live("click", function () {

            var generateId = ++paxLastId;

            var paxTypeId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PaxType";
            var paxType = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PaxType";

            var prefixId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Prefix";
            var prefix = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Prefix";

            var firstNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FirstName";
            var firstName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FirstName";


            var lastNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__LastName";
            var lastName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].LastName";

            var phoneId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Phone";
            var phone = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Phone";

            var dobId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__DOB";
            var dob = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].DOB";

            var passportnumberId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportNumber";
            var passportnumberName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportNumber";

            var passportIssuedCountryId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportIssuedCountryId";
            var passportIssuedCountry = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportIssuedCountryId";

            var passportIssuedDateId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportIssuedDate";
            var passportIssuedDate = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportIssuedDate";

            var passportExpDateId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportExpDate";
            var passportExpDateName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportExpDate";

            var nationalityId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__NationalityId";
            var nationalityName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].NationalityId";


            var mealId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Meal";
            var meal = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Meal";

            var seatId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Seat";
            var seat = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Seat";

            var ffAirNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirline";
            var ffAirName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirline";

            var ffAirlineId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirlineId";
            var ff = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirlineId";

            var ffNoId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerNo";
            var ffno = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerNo";



            var currencyId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_Currency";
            var currency = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.Currency";

            var baseFareId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingBaseFare";
            var baseFare = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingBaseFare";

            var taxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingTax";
            var tax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingTax";

            var ocId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingOtherCharges";
            var oc = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingOtherCharges";

            var commId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_CommissionAmount";
            var comm = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.CommissionAmount";

            var ticketId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_TicketNumber";
            var ticket = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.TicketNumber";

            var serviceTaxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingServiceTax";
            var serviceTax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingServiceTax";

            var agentServiceChargeId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_AgentServiceCharge";
            var agentServiceCharge = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.AgentServiceCharge";

            var fscId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingFSC";
            var fsc = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingFSC";



            var item = $(".Passenger0:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Passenger_" + generateId.toString() });
            });


            $("#PNRDetails_00_Index", item).attr({ id: 'PNRDetails_00_Index', value: generateId.toString() });
            $("#PNRDetails_0__PassengerDetail_0__PaxType", item).attr({ id: paxTypeId, name: paxType });
            $("#PNRDetails_0__PassengerDetail_0__Prefix", item).attr({ id: prefixId, name: prefix });
            $("#PNRDetails_0__PassengerDetail_0__FirstName", item).attr({ id: firstNameId, name: firstName });
            $("#PNRDetails_0__PassengerDetail_0__LastName", item).attr({ id: lastNameId, name: lastName });
            $("#PNRDetails_0__PassengerDetail_0__Phone", item).attr({ id: phoneId, name: phone }).removeAttr('class');
            $("#PNRDetails_0__PassengerDetail_0__DOB", item).attr({ id: dobId, name: dob });


            $("#PNRDetails_0__PassengerDetail_0__PassportNumber", item).attr({ id: passportnumberId, name: passportnumberName });
            $("#PNRDetails_0__PassengerDetail_0__PassportIssuedCountryId", item).attr({ id: passportIssuedCountryId, name: passportIssuedCountry });
            $("#PNRDetails_0__PassengerDetail_0__PassportIssuedDate", item).attr({ id: passportIssuedDateId, name: passportIssuedDate });
            $("#PNRDetails_0__PassengerDetail_0__PassportExpDate", item).attr({ id: passportExpDateId, name: passportExpDateName });
            $("#PNRDetails_0__PassengerDetail_0__NationalityId", item).attr({ id: nationalityId, name: nationalityName });


            $("#PNRDetails_0__PassengerDetail_0__Meal", item).attr({ id: mealId, name: meal });
            $("#PNRDetails_0__PassengerDetail_0__Seat", item).attr({ id: seatId, name: seat });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerAirline", item).attr({ id: ffAirNameId, name: ffAirName });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerAirlineId", item).attr({ id: ffAirlineId, name: ff });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerNo", item).attr({ id: ffNoId, name: ffno });


            $("#PNRDetails_0__PassengerDetail_0__FareDetail_Currency", item).attr({ id: currencyId, name: currency });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingBaseFare", item).attr({ id: baseFareId, name: baseFare });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingTax", item).attr({ id: taxId, name: tax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingOtherCharges", item).attr({ id: ocId, name: oc });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_CommissionAmount", item).attr({ id: commId, name: comm });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_TicketNumber", item).attr({ id: ticketId, name: ticket });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingFSC", item).attr({ id: fscId, name: fsc });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingServiceTax", item).attr({ id: serviceTaxId, name: serviceTax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_AgentServiceCharge", item).attr({ id: agentServiceChargeId, name: agentServiceCharge });

            $("#Cancel_0", item).css({ "display": "block" });
            $("#Cancel_0", item).attr({ id: 'Cancel_' + generateId.toString(), rel: generateId.toString() });



            item.insertBefore("#AddPassenger0");
        });
    </script>
    <%--  Segment 0--%>
    <script type="text/javascript">
        $("#AddSegment0").live("click", function () {
            var generateId = ++segLastId;

            var deptCityId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartCityId";
            var deptCity = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartCityId";

            var deptTimeId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartTime";
            var deptTime = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartTime";

            var arriveTimeId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalTime";
            var arriveTime = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalTime";

            var arriveCityId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalCityId";
            var arriveCity = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalCityId";

            var deptDateId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartDate";
            var deptDate = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartDate";

            var arriveDateId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalDate";
            var arriveDate = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalDate";

            var bicId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__BIC";
            var bic = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].BIC";

            var segairlineId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__AirlineId";
            var segairline = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].AirlineId";

            var segairlineNoId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__FlightNumber";
            var segairlineNo = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].FlightNumber";


            var segairlinePnrId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__AirlineRefNumber";
            var segairlinePnr = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].AirlineRefNumber";

            var segDurationId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__Duration";
            var segDuration = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].Duration";

            var item = $(".Segment0:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Segment_" + generateId.toString() });
            });

            $("#PNRDetails_SegmentDetail00_Index", item).attr({ id: 'PNRDetails_SegmentDetail00_Index', value: generateId.toString() });

            $("#PNRDetails_0__SegmentDetail_0__DepartCityId", item).attr({ id: deptCityId, name: deptCity });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalCityId", item).attr({ id: arriveCityId, name: arriveCity });
            $("#PNRDetails_0__SegmentDetail_0__DepartDate", item).attr({ id: deptDateId, name: deptDate });
            $("#PNRDetails_0__SegmentDetail_0__DepartTime", item).attr({ id: deptTimeId, name: deptTime });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalDate", item).attr({ id: arriveDateId, name: arriveDate });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalTime", item).attr({ id: arriveTimeId, name: arriveTime });
            $("#PNRDetails_0__SegmentDetail_0__BIC", item).attr({ id: bicId, name: bic });
            $("#PNRDetails_0__SegmentDetail_0__AirlineId", item).attr({ id: segairlineId, name: segairline });
            $("#PNRDetails_0__SegmentDetail_0__FlightNumber", item).attr({ id: segairlineNoId, name: segairlineNo });
            $("#PNRDetails_0__SegmentDetail_0__AirlineRefNumber", item).attr({ id: segairlinePnrId, name: segairlinePnr });
            $("#PNRDetails_0__SegmentDetail_0__Duration", item).attr({ id: segDurationId, name: segDuration });

            $("#Cancel_Seg0", item).css({ "display": "block" });
            $("#Cancel_Seg0", item).attr({ id: 'Cancel_Seg' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddSegment0");
        });


    </script>
    <%-- Passenger RoundTrip 1--%>
    <script type="text/javascript">
        $("#AddPassenger1").live("click", function () {
            var generateId = ++paxLastId;

            var paxTypeId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PaxType";
            var paxType = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PaxType";

            var prefixId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Prefix";
            var prefix = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Prefix";

            var firstNameId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FirstName";
            var firstName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FirstName";

            var lastNameId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__LastName";
            var lastName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].LastName";

            var phoneId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Phone";
            var phone = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Phone";

            var dobId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__DOB";
            var dob = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].DOB";

            var passportnumberId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportNumber";
            var passportnumberName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportNumber";

            var passportIssuedCountryId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportIssuedCountryId";
            var passportIssuedCountry = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportIssuedCountryId";

            var passportIssuedDateId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportIssuedDate";
            var passportIssuedDate = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportIssuedDate";

            var passportExpDateId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportExpDate";
            var passportExpDateName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportExpDate";

            var nationalityId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__NationalityId";
            var nationalityName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].NationalityId";


            var mealId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Meal";
            var meal = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Meal";

            var seatId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Seat";
            var seat = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Seat";

            var ffAirlineId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirlineId";
            var ff = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirlineId";

            var ffNoId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FrequentFlyerNo";
            var ffno = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FrequentFlyerNo";


            var currencyId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_Currency";
            var currency = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.Currency";

            var baseFareId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingBaseFare";
            var baseFare = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingBaseFare";

            var taxId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingTax";
            var tax = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingTax";

            var ocId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingOtherCharges";
            var oc = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingOtherCharges";

            var commId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_CommissionAmount";
            var comm = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.CommissionAmount";

            var ticketId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_TicketNumber";
            var ticket = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.TicketNumber";


            var serviceTaxId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingServiceTax";
            var serviceTax = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingServiceTax";

            var agentServiceChargeId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingServiceTax";
            var agentServiceCharge = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingServiceTax";

            var fscId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingFSC";
            var fsc = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingFSC";


            var item = $(".Passenger1:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Passenger_" + generateId.toString() });
            });

            $("#PNRDetails_10_Index", item).attr({ id: 'PNRDetails_10_Index', value: generateId.toString() });

            $("#PNRDetails_1__PassengerDetail_0__PaxType", item).attr({ id: paxTypeId, name: paxType });
            $("#PNRDetails_1__PassengerDetail_0__Prefix", item).attr({ id: prefixId, name: prefix });
            $("#PNRDetails_1__PassengerDetail_0__FirstName", item).attr({ id: firstNameId, name: firstName });
            $("#PNRDetails_1__PassengerDetail_0__LastName", item).attr({ id: lastNameId, name: lastName });
            $("#PNRDetails_1__PassengerDetail_0__Phone", item).attr({ id: phoneId, name: phone }).removeAttr('class'); ;
            $("#PNRDetails_1__PassengerDetail_0__DOB", item).attr({ id: dobId, name: dob });

            $("#PNRDetails_1__PassengerDetail_0__PassportNumber", item).attr({ id: passportnumberId, name: passportnumberName });
            $("#PNRDetails_1__PassengerDetail_0__PassportIssuedCountryId", item).attr({ id: passportIssuedCountryId, name: passportIssuedCountry });
            $("#PNRDetails_1__PassengerDetail_0__PassportIssuedDate", item).attr({ id: passportIssuedDateId, name: passportIssuedDate });
            $("#PNRDetails_1__PassengerDetail_0__PassportExpDate", item).attr({ id: passportExpDateId, name: passportExpDateName });
            $("#PNRDetails_1__PassengerDetail_0__NationalityId", item).attr({ id: nationalityId, name: nationalityName });

            $("#PNRDetails_1__PassengerDetail_0__Meal", item).attr({ id: mealId, name: meal });
            $("#PNRDetails_1__PassengerDetail_0__Seat", item).attr({ id: seatId, name: seat });
            $("#PNRDetails_1__PassengerDetail_0__FrequentFlyerAirlineId", item).attr({ id: ffAirlineId, name: ff });
            $("#PNRDetails_1__PassengerDetail_0__FrequentFlyerNo", item).attr({ id: ffNoId, name: ffno });

            $("#PNRDetails_1__PassengerDetail_0__FareDetail_Currency", item).attr({ id: currencyId, name: currency });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingBaseFare", item).attr({ id: baseFareId, name: baseFare });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingTax", item).attr({ id: taxId, name: tax });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingOtherCharges", item).attr({ id: ocId, name: oc });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_CommissionAmount", item).attr({ id: commId, name: comm });

            $("#PNRDetails_1__PassengerDetail_0__FareDetail_TicketNumber", item).attr({ id: ticketId, name: ticket });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingFSC", item).attr({ id: fscId, name: fsc });

            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingServiceTax", item).attr({ id: serviceTaxId, name: serviceTax });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_AgentServiceCharge", item).attr({ id: agentServiceChargeId, name: agentServiceCharge });

            $("#Cancel_0", item).css({ "display": "block" });
            $("#Cancel_0", item).attr({ id: 'Cancel_' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddPassenger1");

        });
        
    </script>
    <%-- Segment RoundTrip 1--%>
    <script type="text/javascript">

        $("#AddSegment1").live("click", function () {
            var generateId = ++segLastId;

            var deptCityId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartCityId";
            var deptCity = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartCityId";


            var deptTimeId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartTime";
            var deptTime = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartTime";

            var arriveTimeId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalTime";
            var arriveTime = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalTime";

            var arriveCityId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalCityId";
            var arriveCity = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalCityId";

            var deptDateId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartDate";
            var deptDate = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartDate";

            var arriveDateId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalDate";
            var arriveDate = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalDate";

            var bicId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__BIC";
            var bic = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].BIC";

            var segairlineId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__AirlineId";
            var segairline = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].AirlineId";

            var segairlineNoId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__FlightNumber";
            var segairlineNo = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].FlightNumber";


            var segairlinePnrId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__AirlineRefNumber";
            var segairlinePnr = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].AirlineRefNumber";


            var segDurationId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__Duration";
            var segDuration = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].Duration";

            var item = $(".Segment1:first").clone(true);
            $.each(item, function (index, element) {
                $(this).attr({ id: "Segment_" + generateId.toString() });
            });

            $("#PNRDetails_SegmentDetail10_Index", item).attr({ id: 'PNRDetails_SegmentDetail10_Index', value: generateId.toString() });
            $("#PNRDetails_1__SegmentDetail_0__DepartCityId", item).attr({ id: deptCityId, name: deptCity });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalCityId", item).attr({ id: arriveCityId, name: arriveCity });
            $("#PNRDetails_1__SegmentDetail_0__DepartDate", item).attr({ id: deptDateId, name: deptDate });
            $("#PNRDetails_1__SegmentDetail_0__DepartTime", item).attr({ id: deptTimeId, name: deptTime });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalDate", item).attr({ id: arriveDateId, name: arriveDate });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalTime", item).attr({ id: arriveTimeId, name: arriveTime });
            $("#PNRDetails_1__SegmentDetail_0__BIC", item).attr({ id: bicId, name: bic });
            $("#PNRDetails_1__SegmentDetail_0__AirlineId", item).attr({ id: segairlineId, name: segairline });
            $("#PNRDetails_1__SegmentDetail_0__FlightNumber", item).attr({ id: segairlineNoId, name: segairlineNo });
            $("#PNRDetails_1__SegmentDetail_0__AirlineRefNumber", item).attr({ id: segairlinePnrId, name: segairlinePnr });
            $("#PNRDetails_1__SegmentDetail_0__Duration", item).attr({ id: segDurationId, name: segDuration });

            $("#Cancel_Seg0", item).css({ "display": "block" });
            $("#Cancel_Seg0", item).attr({ id: 'Cancel_Seg' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddSegment1");
        });

    </script>
</asp:Content>
