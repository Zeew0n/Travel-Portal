<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <%:Html.ActionLink("New Deal", "CreateDeal", "HotelDeal", new { area="Hotel"}, new { @class = "createDeal linkButton", @title = "New Deal" })%>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Hotel Setup</a> <span>&nbsp;</span><strong>Deal SetUp</strong>
        </h3>
    </div>
    <% Html.RenderPartial("DealFilter"); %>
    <div style="overflow: auto; width: 100%;" id="divDealContentGridFilter">
        <% Html.RenderPartial("VUC_DealDetailList"); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/SearchResult.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/AirlineSearchResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">

        function EditDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            $('#' + divId).load("/Hotel/HotelDeal/AjaxDealDetail/" + dealId);
        }

        function CancelDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            $("#" + divId).load("/Hotel/HotelDeal/AjaxDealCancel/" + dealId);
        }

        function DeleteDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            var alertMsg = "";
            alertMsg = "Are you sure you want to delete?";
            if (confirm(alertMsg)) {
                $.ajax({
                    type: "POST",
                    url: "/Hotel/HotelDeal/Delete/",
                    data: { id: dealId },
                    error: function () {
                        $("#" + divId + "_loading").html('');
                        alert('Error occurred');
                    },
                    success: function (data) {
                        $("#" + divId + "_loading").html('');
                        if (data == true) {
                            $('#' + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
                        }
                        else {
                            alert(data);
                        }
                    },
                    dataType: "json"
                });
                return true;
            }
            $("#" + divId + "_loading").html('');
            return false;
        }

        $(function () {
            $('a.create').live("click", function (event) {
                loadCreateDialog(this, event, '#contentGrid');
            });


            $('a.createDeal').live("click", function (event) {
                loadcreateDealDialog(this, event, '#contentGrid');
            });

        });

        $('#saveDeal').live("click", function (event) {

            $("#loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            serializeFormData = $("form[id$=myForm]").serialize();
            $.ajax({
                type: "POST",
                url: '/Hotel/HotelDeal/Create/',
                data: serializeFormData,
                dataType: "html",
                async: true,
                cache: false,
                success: function (serverResponse) {
                    $("#lblSuccess").toggle().empty().html('Saved Successfully.&nbsp;&nbsp;').fadeOut(10000, function () { $(this).hide() });

                    $('#divDealContentGridFilter').append(serverResponse);
                    $("#loading").html('');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#loading").html('');
                    alert('Unable to save record.');
                }
            });

        });



        function UpdateDeal(divId, formId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            id = $("#editDealIdentifier").val();
            text = $("#editDealIdentifier option[value=" + id + "]").text();
            $("#editDealIdentifierText").val(text);
            serializeFormData = $("form[id$=" + formId + "]").serialize();
            $.ajax({
                type: "POST",
                url: '/Hotel/HotelDeal/AjaxDealEdit/',
                data: serializeFormData,
                dataType: "html",
                success: function (serverResponse) {
                    $("#" + divId).empty().html(serverResponse);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#" + divId + "_loading").html('');
                    alert(textStatus);
                }
            });
        }


        function loadCreateDialog(tag, event, target) {
            event.preventDefault();
            $(this).dialog('destroy');
            var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
            var url = $(tag).attr('href');
            var id = $("#filterDealMasterId").val();

            if (id == "") {
                alert('Please select Deal Name');
                return false;
            }
            var $title = $(tag).attr('title');
            var $dialog = $('<div></div>');
            $dialog.empty();
            $dialog
            .append($loading)
            .load(url + '/' + id)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 885
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale',
		        closeOnEscape: false,
		        open: function (event, ui) { $(".ui-dialog-titlebar-close").show(); }
		        //		       , buttons: { "Cancel": function () {
		        //		            $(this).remove();
		        //		        }
		        //		        }
		        //                , buttons: [
		        //                           {
		        //                               text: "Close",
		        //                               click: function () { $(this).remove(); }
		        //                           }
		        //                         ] 
		    });
            $dialog.dialog('open');
        };

        function loadcreateDealDialog(tag, event, target) {
            event.preventDefault();
            $(this).dialog('destroy');
            var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
            var url = $(tag).attr('href');
            var id = $("#DealMasterId").val();
            var $title = $(tag).attr('title');
            var $dialog = $('<div></div>');
            $dialog.empty();
            $dialog
            .append($loading)
            .load(url + '/' + id)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 885
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale'
		    });
            $dialog.dialog('open');
        };


        $(document).ready(function () {

            $("#filterDealMasterId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    var url = "/Airline/AjaxRequest/GetHotelDealIdentifiers";
                    $.getJSON(url, { id: id }, function (data) {
                        $("#filterDealIdentifier").empty();
                        $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                        $.each(data, function (index, optionData) {
                            $("#filterDealIdentifier").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();



            $("#filterDealIdentifier").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();


            //            $(".cityCodeDropdown").change(function () {
            //                alert('cool');
            //            }).change();

            $("#filterCountryCode").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    var url = "/Hotel/AjaxRequest/GetHtl_BookingDestinationCity";
                    $.getJSON(url, { id: filterCountryCode }, function (data) {
                        $("#filterCityId").empty();
                        $("#filterCityId").append("<option value=''>" + "-- Select--" + "</option>");
                        $.each(data, function (index, optionData) {
                            $("#filterCityId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });


                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();




            $("#filterCityId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();




            $("#filterCategory").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();




            $("#filterHotelId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();




            $("#filterCurrencyId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#filterDealMasterId").val();

                filterDealIdentifier = $("#filterDealIdentifier").val();
                filterDealIdentifierText = $("#filterDealIdentifier option[value=" + filterDealIdentifier + "]").text();
                filterDealIdentifierText = filterDealIdentifierText == "-- Select--" ? "" : filterDealIdentifierText;

                filterCountryCode = $("#filterCountryCode").val();
                filterCountryCode = filterCountryCode == "-- Select--" ? "" : filterCountryCode;

                filterCityId = $("#filterCityId").val();
                filterCategory = $("#filterCategory").val();
                filterHotelId = $("#filterHotelId").val();
                filterCurrency = $("#filterCurrency").val();


                if (id == "") {
                    $("#filterDealIdentifier").empty();
                    $("#filterDealIdentifier").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDeal/Index/',
                        data: { id: id, filterCountryCode: filterCountryCode, filterCategory: filterCategory, filterCityId: filterCityId, filterHotelId: filterHotelId, filterDealIdentifier: filterDealIdentifierText, filterCurrency: filterCurrency },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                            $("#loadingIndicator").html('');
                        }
                    });
                }
            }).change();
        });

        function populateCountry(contryCodeCtrl) {
            countryCode = $("#" + contryCodeCtrl.id).val();
            id = contryCodeCtrl.id.substring(contryCodeCtrl.id.lastIndexOf('_') + 1);
            var url = "/Hotel/AjaxRequest/GetHtl_BookingDestinationCity";
            $.getJSON(url, { id: countryCode }, function (data) {
                $("#editCityId_" + id).empty();
                $("#editCityId_" + id).append("<option value=''>" + "-- Select--" + "</option>");
                $.each(data, function (index, optionData) {
                    $("#editCityId_" + id).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                });
            });
        }
    </script>
</asp:Content>
