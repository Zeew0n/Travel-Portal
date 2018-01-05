<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PromotionalFareModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "PromotionalFareSetup", FormMethod.Post, new { @id = "myForm" }))
       { %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
                <label id="lblSuccess" style="display: none; color: Green; font-weight: bold;">
                </label>
            </li>
            <li>
                <%-- <input type="button" value="Save" id="SavePromotionalFare" />--%>
                <input type="submit" value="Save" />
            </li>
            <li>
                <input type="button" onclick="document.location.href='/Airline/PromotionalFareSetup/'"
                    value="Cancel" />
            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong>Promotional Fare</strong>
        </h3>
    </div>
    <input type="hidden" value="0" name="PromotionalFareSector.Index" id="PromotionalFareSector_Index" />
    <fieldset class="style1" style="padding-left: 5px; padding-right: 5px;">
        <legend>Segment Info</legend>
        <div id="Sector_0" class="SectorList">
            <input type="hidden" value="0" id="PromotionalFareSector_PromotionalFareSegment_0_Index"
                name="PromotionalFareSector.PromotionalFareSegment.Index" />
            <table class="tableCityPair" id="Sectors" style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <label>
                                From</label><br>
                            <%:Html.DropDownListFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].FromCityId, Model.PromotionalFareSector.PromotionalFareSegment[0].FromCityList, new { @style = "width:100px;" })%>
                        </td>
                        <td>
                            <label>
                                To</label><br>
                            <%:Html.DropDownListFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].ToCityId, Model.PromotionalFareSector.PromotionalFareSegment[0].ToCityList, new { @style = "width:100px;" })%>
                        </td>
                        <td>
                            <label>
                                Dept. Date/Time</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].DepartureDate, new { @class = "timepicker" })%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].DepartureDate)%>
                        </td>
                        <td>
                            <label>
                                Arr. Date/Time</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].ArrivalDate, new { @class = "timepicker" })%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].ArrivalDate)%>
                        </td>
                        <td>
                            <label>
                                Flight No.</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].FlightNo)%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[0].FlightNo)%>
                        </td>
                        <td>
                            <br />
                            <a href="javascript:void(0);" id="Cancel_Segment_0" rel="0" class="delete deleteSegment"
                                style="display: none; float: right;">&nbsp; </a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <% if (Model.PromotionalFareSector.PromotionalFareSegment != null)
           {
               for (int i = 1; i < Model.PromotionalFareSector.PromotionalFareSegment.Count; i++)
               {%>
        <div id="Sector_<%=i %>" class="SectorList">
            <input type="hidden" value="<%=i %>" id="PromotionalFareSector_PromotionalFareSegment_<%=i %>_Index"
                name="PromotionalFareSector.PromotionalFareSegment.Index" />
            <table class="tableCityPair" id="Table1" style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <label>
                                From</label><br>
                            <%:Html.DropDownListFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].FromCityId, Model.PromotionalFareSector.PromotionalFareSegment[i].FromCityList, new { @style = "width:100px;" })%>
                        </td>
                        <td>
                            <label>
                                To</label><br>
                            <%:Html.DropDownListFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].ToCityId, Model.PromotionalFareSector.PromotionalFareSegment[i].ToCityList, new { @style = "width:100px;" })%>
                        </td>
                        <td>
                            <label>
                                Dept. Date/Time</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].DepartureDate, new { @class = "timepicker" })%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].DepartureDate)%>
                        </td>
                        <td>
                            <label>
                                Arr. Date/Time</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].ArrivalDate, new { @class = "timepicker" })%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].ArrivalDate)%>
                        </td>
                        <td>
                            <label>
                                Flight No.</label><br>
                            <%:Html.TextBoxFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].FlightNo)%>
                            <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.PromotionalFareSegment[i].FlightNo)%>
                        </td>
                        <td>
                            <br />
                            <a href="javascript:void(0);" id="Cancel_Segment_<%=i %>" rel="<%=i %>" class="delete deleteSegment"
                                style="display: block; float: right;">&nbsp; </a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%}
           }%>
        <div class="buttonBar" id="addSegment">
            <a id="AddSector" href="javascript: void(0);">+ Add another flight</a>
        </div>
    </fieldset>
    <br />
    <fieldset class="style1" style="padding-bottom: 0px;">
        <legend>Sector Info</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Airline
                    </label>
                    <%:Html.DropDownListFor(model => model.PromotionalFareSector.AirlineId, Model.PromotionalFareSector.AirlinesList)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Tour Code</label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.TourCode)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Currency</label>
                    <%:Html.DropDownListFor(model => model.PromotionalFareSector.CurrencyId, Model.PromotionalFareSector.CurrencyList)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Class
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.BICClass)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Fare Basis
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.FareBasis)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Effective From</label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.EffectiveFrom, new { @class = "timepicker" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Expire On
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.ExpireOn, new { @class = "timepicker" })%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        No Of Pax
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.NoOfPax)%>
                    <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.NoOfPax)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Base Fare
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.BaseFare)%>
                    <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.BaseFare)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Other Charges
                    </label>
                    <%:Html.TextBoxFor(model => model.PromotionalFareSector.OtherCharges)%>
                    <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.OtherCharges)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row" style="border-left: 1px solid #CCCCCC; background: #F8F8F8;
            border-top: 1px solid #CCCCCC; float: right; margin-top: 10px; padding: 5px 10px;
            width: 62%;">
            <h4>
                <strong>Tax</strong></h4>
            <div class="float-left TaxesList" style="width: 100%; margin-bottom: 5px;" id="Tax_0">
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    <input type="hidden" value="0" id="PromotionalFareSector_Taxes_0_Index" name="PromotionalFareSector.Taxes.Index" />
                    <div>
                        <label style="width: 60px;">
                            Tax Name</label>
                        <%:Html.TextBoxFor(model => model.PromotionalFareSector.Taxes[0].TaxName, new { @style = "width:115px;" })%>
                        <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.Taxes[0].TaxName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    <div>
                        <label style="width: 60px;">
                            Tax Amount</label>
                        <%:Html.TextBoxFor(model => model.PromotionalFareSector.Taxes[0].TaxAmount, new { @style = "width:115px;" })%>
                        <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.Taxes[0].TaxAmount)%>
                    </div>
                </div>
                <div class="float-left" style="width: auto;">
                    <a href="javascript:void(0);" id="Cancel_0" rel="0" class="delete deleteTaxes" style="display: none;
                        float: right;">&nbsp; </a>
                </div>
            </div>
            <% if (Model.PromotionalFareSector.Taxes != null)
               {
                   for (int i = 1; i < Model.PromotionalFareSector.Taxes.Count; i++)
                   {%>
            <div class="float-left TaxesList" style="width: 100%; margin-bottom: 5px;" id="Tax_<%=i %>">
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    <input type="hidden" value="<%=i %>" id="PromotionalFareSector_Taxes_<%=i %>_Index"
                        name="PromotionalFareSector.Taxes.Index" />
                    <div>
                        <label style="width: 60px;">
                            Tax Name</label>
                        <%:Html.TextBoxFor(model => model.PromotionalFareSector.Taxes[i].TaxName, new { @style = "width:115px;" })%>
                        <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.Taxes[i].TaxName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    <div>
                        <label style="width: 60px;">
                            Tax Amount</label>
                        <%:Html.TextBoxFor(model => model.PromotionalFareSector.Taxes[i].TaxAmount, new { @style = "width:115px;" })%>
                        <%:Html.ValidationMessageFor(model => model.PromotionalFareSector.Taxes[i].TaxAmount)%>
                    </div>
                </div>
                <div class="float-left" style="width: auto;">
                    <a href="javascript:void(0);" id="Cancel_<%=i %>" rel="<%=i %>" class="delete deleteTaxes"
                        style="display: block; float: right;">&nbsp; </a>
                </div>
            </div>
            <%}
               } %>
            <div class="buttonBar clearboth" id="taxAddButton">
                <a id="AddTaxes" href="javascript: void(0);">+ Add Tax</a>
            </div>
        </div>
    </fieldset>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery-ui-1.8.13.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
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
        
        .validation-summary-errors p
        {
            margin: 0px;
            padding: 5px;
            position: absolute;
            overflow: auto;
            width: 218px;
            max-height: 80px;
            top: 123px;
            right: 15px;
            background-color: #fff;
            border: 1px solid #d5d5d5;
            color: #f00;
        }
        .field-validation-error
        {
            color: #FF0000;
        }
        .field-validation-valid
        {
            display: none;
        }
        input.input-validation-error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
        
        .validation-summary-valid
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/timepicker.js" type="text/javascript"></script>
    <script src="../../../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="../../../../Scripts/MicrosoftMvcValidation.debug.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.timepicker').live('click', function () {
                $(this).datetimepicker('destroy').datetimepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    numberOfMonths: 1,
                    minDate: 0
                }).focus();
            });
        });
    </script>
    <script type="text/javascript">
        var taxId = 0;
        var sectorId = 0;

        $("#AddTaxes").live('click', function () {
            var generateId = ++taxId
            var taxNameId = "PromotionalFareSector_Taxes_" + generateId.toString() + "__TaxName";
            var taxNameName = "PromotionalFareSector.Taxes[" + generateId.toString() + "].TaxName";
            var taxNameValidation = "PromotionalFareSector_Taxes_" + generateId.toString() + "__TaxName_validationMessage"

            var taxAmountId = "PromotionalFareSector_Taxes_" + generateId.toString() + "__TaxAmount";
            var taxAmountName = "PromotionalFareSector.Taxes[" + generateId.toString() + "].TaxAmount";
            var taxAmountValidation = "PromotionalFareSector_Taxes_" + generateId.toString() + "__TaxAmount_validationMessage"

            var item = $(".TaxesList:first").clone(true);
            $.each(item, function (index, element) {
                $(this).attr({ id: "Tax_" + generateId.toString() });
            });

            $("#PromotionalFareSector_Taxes_0_Index", item).attr({ id: 'PromotionalFareSector_Taxes_' + generateId.toString() + '_Index', name: 'PromotionalFareSector.Taxes.Index', value: generateId.toString() });

            $("#PromotionalFareSector_Taxes_0__TaxName", item).attr({ id: taxNameId, name: taxNameName });
            $("#PromotionalFareSector_Taxes_0__TaxAmount", item).attr({ id: taxAmountId, name: taxAmountName });
            $("#PromotionalFareSector_Taxes_0__TaxName_validationMessage", item).attr({ id: taxNameValidation });
            $("#PromotionalFareSector_Taxes_0__TaxAmount_validationMessage", item).attr({ id: taxAmountValidation });

            $("#Cancel_0", item).css({ "display": "block" });
            $("#Cancel_0", item).attr({ id: 'Cancel_' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#taxAddButton");
        });

        $(".deleteTaxes").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Tax_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });

        $("#AddSector").live('click', function () {
            var newSectorId = ++sectorId;
            var item = $(".SectorList:first").clone(true);
            $.each(item, function (index, element) {
                $(this).attr({ id: "Sector_" + newSectorId.toString() });
            });

            $("#PromotionalFareSector_PromotionalFareSegment_0_Index", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '_Index', name: 'PromotionalFareSector.PromotionalFareSegment.Index', value: newSectorId.toString() });

            $("#PromotionalFareSector_PromotionalFareSegment_0__FromCityId", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '__FromCityId', name: 'PromotionalFareSector.PromotionalFareSegment[' + newSectorId.toString() + "].FromCityId" });


            $("#PromotionalFareSector_PromotionalFareSegment_0__ToCityId", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '__ToCityId', name: 'PromotionalFareSector.PromotionalFareSegment[' + newSectorId.toString() + "].ToCityId" });


            $("#PromotionalFareSector_PromotionalFareSegment_0__DepartureDate", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '__DepartureDate', name: 'PromotionalFareSector.PromotionalFareSegment[' + newSectorId.toString() + "].DepartureDate" });

            $("#PromotionalFareSector_PromotionalFareSegment_0__ArrivalDate", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '__ArrivalDate', name: 'PromotionalFareSector.PromotionalFareSegment[' + newSectorId.toString() + "].ArrivalDate" });

            $("#PromotionalFareSector_PromotionalFareSegment_0__FlightNo", item).attr({ id: 'PromotionalFareSector_PromotionalFareSegment_' + newSectorId.toString() + '__FlightNo', name: 'PromotionalFareSector.PromotionalFareSegment[' + newSectorId.toString() + "].FlightNo" });


            $("#Cancel_Segment_0", item).css({ "display": "block" });
            $("#Cancel_Segment_0", item).attr({ id: 'Cancel_Segment_' + newSectorId.toString(), rel: newSectorId.toString() });

            item.insertBefore("#addSegment");
        });

        $(".deleteSegment").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Sector_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });
    </script>
    <%--    <script type="text/javascript">
        $('#SavePromotionalFare').live("click", function (event) {
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');                $("#myForm").validate();
            serializeFormData = $("form[id$=myForm]").serialize();

            if ($("#myForm").valid()) {
                $.ajax({
                    type: "POST",
                    url: '/Airline/PromotionalFareSetup/Create/',
                    data: serializeFormData,
                    dataType: "html",
                    async: true,
                    cache: false,
                    success: function (serverResponse) {
                        $("#lblSuccess").toggle().empty().html('Saved Successfully.&nbsp;&nbsp;').fadeOut(10000, function () { $(this).hide() });

                        document.location.href = '/Airline/PromotionalFareSetup/';
                        $("#loadingIndicator").html('');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $("#loadingIndicator").html('');
                        alert('Unable to save record.');
                    }
                });
            }
        });
    </script>--%>
</asp:Content>
