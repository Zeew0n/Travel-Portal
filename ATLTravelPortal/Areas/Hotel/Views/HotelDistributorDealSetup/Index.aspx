<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
                <label class="pageTitle" style="display: block;" id="lblDealMasterSuccess">
                </label>
            </li>
            <li>
                <%:Html.ActionLink("New Deal", "Create", "HotelMasterDistributorDealSetUp", new { area="Hotel"}, new { @class = "createDeal linkButton", @title = "New Deal" })%>
            </li>
            <li><a href="javascript:void(0);" id="DeleteMasterDeal" class="linkButton" title="Delete Deal">
                Delete Deal</a></li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Deal SetUp</strong>
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
        //////////////////////////////////////////////////////////////////////////////////////////////////

        $('#DeleteMasterDeal').live("click", function (event) {
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

            var masterDealId = $("#DealMasterId").val();
            var text = $("#DealMasterId option[value=" + masterDealId + "]").text();

            if (masterDealId == "") {
                alert('Please select Deal Name');
                $("#loadingIndicator").html('');
                return false;
            }
            var alertMsg = "";
            alertMsg = "Do you want to delete " + text + " ?";
            if (confirm(alertMsg)) {
                $.ajax({
                    type: "POST",
                    url: "/Hotel/HotelMasterDistributorDealSetup/Delete/",
                    data: { id: masterDealId, name: text },
                    error: function () {
                        $("#loadingIndicator").html('');
                        alert('Can not delete the deal ' + text);
                    },
                    success: function (data) {
                        $("#loadingIndicator").html('');
                        if (data.isVerified == true) {
                            $("#lblDealMasterSuccess").toggle().empty().html('<h3>Deleted Successfully.&nbsp;&nbsp;</h3>').fadeOut(10000, function ()
                            { $(this).hide() });
                            var dealMasterList = data.DealMasterList;
                            $("#DealMasterId").empty();
                            $("#DealMasterId").append("<option value=''>" + "---Select---" + "</option>");
                            $.each(dealMasterList, function (index, optionData) {
                                $("#DealMasterId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                            });

                        }
                        else if (data.isVerified == false) {
                            DeleteMasterDealForceFully(masterDealId, text);
                        }
                    },
                    dataType: "json"
                });
                return true;
            }
            $("#loadingIndicator").html('');
            return false;
        });

        function DeleteMasterDealForceFully(masterDealId, text) {
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

            if (masterDealId == "") {
                alert('Please select Deal Name');
                $("#loadingIndicator").html('');
                return false;
            }
            var alertMsg = "";
            alertMsg = 'Can not delete the deal ' + text + '. Do you want to delete deal ' + text + ' forcefully?';
            if (confirm(alertMsg)) {
                $.ajax({
                    type: "POST",
                    url: "/Hotel/AjaxRequest/DeleteDistributorMasterDealForceFully/",
                    data: { id: masterDealId, name: text },
                    error: function () {
                        $("#loadingIndicator").html('');
                        alert('Can not delete the deal ' + text);
                    },
                    success: function (data) {
                        $("#loadingIndicator").html('');
                        if (data.isVerified == true) {
                            $("#lblDealMasterSuccess").toggle().empty().html('<h3>Deleted Successfully.&nbsp;&nbsp;</h3>').fadeOut(10000, function ()
                            { $(this).hide() });
                            var dealMasterList = data.DealMasterList;
                            $("#DealMasterId").empty();
                            $("#DealMasterId").append("<option value=''>" + "---Select---" + "</option>");
                            $.each(dealMasterList, function (index, optionData) {
                                $("#DealMasterId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                            });
                            $("#divDealContentGridFilter").empty();
                        }
                        else if (data.isVerified == false) {
                            alert('Can not delete the deal ' + text);
                        }
                    },
                    dataType: "json"
                });
                return true;
            }
            $("#loadingIndicator").html('');
            return false;
        }

        function EditDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            source = $("#Source").val();

            $('#' + divId).load("/Hotel/AjaxRequest/AjaxDistributorDealDetail/" + dealId + "?source=" + source);
        }

        function CancelDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            $("#" + divId).load("/Hotel/AjaxRequest/AjaxDistributorDealCancel/" + dealId);
        }

        function DeleteDeal(divId, dealId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            var alertMsg = "";
            alertMsg = "Are you sure you want to delete?";
            if (confirm(alertMsg)) {
                $.ajax({
                    type: "POST",
                    url: "/Hotel/HotelDistributorDealSetup/Delete/",
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



        $('#saveDeal').live("click", function (event) {

            $("#loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            serializeFormData = $("form[id$=myForm]").serialize();
            $.ajax({
                type: "POST",
                url: '/Hotel/HotelDistributorDealSetup/Create/',
                data: serializeFormData,
                dataType: "html",
                async: true,
                cache: false,
                success: function (serverResponse) {
                    $("#lblSuccess").toggle().empty().html('Saved Successfully.&nbsp;&nbsp;').fadeOut(10000, function () { $(this).hide() });

                    $('#divDealContentGridFilter').prepend(serverResponse);
                    $("#loading").html('');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#loading").html('');
                    //alert(textStatus);
                    alert('Unable to save record.');
                }
            });

        });


        function UpdateDeal(divId, formId) {
            $("#" + divId + "_loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            id = $("#editDealIdentifierId").val();
            text = $("#editDealIdentifierId option[value=" + id + "]").text();
            $("#editDealIdentifierText").val(text);
            serializeFormData = $("form[id$=" + formId + "]").serialize();
            $.ajax({
                type: "POST",
                url: '/Hotel/HotelDistributorDealSetup/Edit/',
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

        $(function () {
            $('a.create').live("click", function (event) {
                loadCreateDialog(this, event, '#contentGrid');
            });


            $('a.createDeal').live("click", function (event) {
                loadcreateDealDialog(this, event, '#contentGrid');
            });

        });


        function loadCreateDialog(tag, event, target) {
            event.preventDefault();
            $(this).dialog('destroy');
            var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
            var url = $(tag).attr('href');
            var id = $("#DealMasterId").val();



            FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
            FilterDealIdentifierText = $("#FilterDealIdentifierId option[value=" + FilterDealIdentifierId + "]").text();
            FilterDealIdentifierText = FilterDealIdentifierText == "-- Select--" ? "" : FilterDealIdentifierText;
            FilterHotelId = $("#FilterHotelId").val();
            FilterCurrencyId = $("#FilterCurrencyId").val();
            source = $("#source1").val();

            url = url + '/' + id + '/?FilterDealIdentifierId=' + FilterDealIdentifierId + '&FilterDealIdentifierText=' + FilterDealIdentifierText + '&FilterHotelId=' + FilterHotelId + '&FilterCurrencyId=' + FilterCurrencyId + '&source1=' + source;



            if (id == "") {
                alert('Please select Deal Name');
                return false;
            }
            var $title = $(tag).attr('title');
            var $dialog = $('<div></div>');
            $dialog.empty();
            $dialog
            .append($loading)
            .load(url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 885
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale'
                , closeOnEscape: true
		        , open: function (event, ui) { $(".ui-dialog-titlebar-close").show(); }
                 , close: function (event, ui) {
                     $(this).remove();
                 }
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
                , close: function (event, ui) {
                    $(this).remove();
                }
                , closeOnEscape: true
		    });
            $dialog.dialog('open');
        };



        $(document).ready(function () {
            $("#DealMasterId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#DealMasterId").val();
                source = $("#Source").val();


                FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
                FilterHotelId = $("#FilterHotelId").val();
                FilterCurrencyId = $("#FilterCurrencyId").val();
                if (id == "") {
                    $("#FilterDealIdentifierId").empty();
                    $("#FilterDealIdentifierId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    var url = "/Airline/AjaxRequest/GetDealIdentifiers";
                    $.getJSON(url, { id: id, source: source }, function (data) {
                        $("#FilterDealIdentifierId").empty();
                        $("#FilterDealIdentifierId").append("<option value=''>" + "-- Select--" + "</option>");
                        $.each(data, function (index, optionData) {
                            $("#FilterDealIdentifierId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDistributorDealSetup/Index/',
                        data: { id: id, FilterDealIdentifierId: FilterDealIdentifierId, FilterHotelId: FilterHotelId, FilterCurrencyId: FilterCurrencyId, Source: source },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);

                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                        }
                    });
                }
            }).change();

            $("#FilterDealIdentifierId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

                id = $("#DealMasterId").val();
                source = $("#Source").val();

                FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
                FilterDealIdentifierText = $("#FilterDealIdentifierId option[value=" + FilterDealIdentifierId + "]").text();
                FilterDealIdentifierText = FilterDealIdentifierText == "-- Select--" ? "" : FilterDealIdentifierText;
                FilterAirlineId = $("#FilterHotelId").val();
                FilterCurrencyId = $("#FilterCurrencyId").val();
                if (id == "") {
                    $("#FilterDealIdentifierId").empty();
                    $("#FilterDealIdentifierId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelBranchDealSetup/Index/',
                        data: { id: id, FilterDealIdentifierId: FilterDealIdentifierText, FilterHotelId: FilterHotelId, FilterCurrencyId: FilterCurrencyId, Source: source },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);
                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                        }
                    });
                }
            }).change();



            $("#FilterHotelName").live("change", function () {
                var text = $(this).val();

                if (text == '') {
                    $("#FilterHotelId").val('');

                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    id = $("#DealMasterId").val();
                    source = $("#Source").val();

                    FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
                    FilterDealIdentifierText = $("#FilterDealIdentifierId option[value=" + FilterDealIdentifierId + "]").text();
                    FilterDealIdentifierText = FilterDealIdentifierText == "-- Select--" ? "" : FilterDealIdentifierText;
                    FilterHotelId = $("#FilterHotelId").val();
                    FilterCurrencyId = $("#FilterCurrencyId").val();
                    if (id == "") {
                        $("#FilterDealIdentifierId").empty();
                        $("#FilterDealIdentifierId").append("<option value=''>" + "-- Select--" + "</option>");
                        $("#loadingIndicator").html('');
                        return false;
                    }
                    else {
                        $.ajax({
                            type: "GET",
                            url: '/Hotel/HotelDistributorDealSetup/Index/',
                            data: { id: id, FilterDealIdentifierId: FilterDealIdentifierText, FilterHotelId: FilterHotelId, FilterCurrencyId: FilterCurrencyId, Source: source },
                            dataType: "html",
                            async: true,
                            cache: false,
                            success: function (serverResponse) {
                                $("#divDealContentGridFilter").empty().append(serverResponse);
                                $("#loadingIndicator").html('');
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                //alert(textStatus);
                                alert('Sorry, Some error occurred');
                            }
                        });
                    }
                }

            });


            $("#FilterHotelName").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Hotel/AjaxRequest/FindHotels", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 10 },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.HotelName + " (" + item.HotelCode + ")", value: item.HotelName + " (" + item.HotelCode + ")", id: item.HotelId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {

                    $("#FilterHotelId").val(ui.item.id);

                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    id = $("#DealMasterId").val();
                    FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
                    FilterDealIdentifierText = $("#FilterDealIdentifierId option[value=" + FilterDealIdentifierId + "]").text();
                    FilterDealIdentifierText = FilterDealIdentifierText == "-- Select--" ? "" : FilterDealIdentifierText;
                    FilterHotelId = $("#FilterHotelId").val();
                    FilterCurrencyId = $("#FilterCurrencyId").val();


                    $.ajax({
                        type: "GET",
                        url: '/Hotel/HotelDistributorDealSetup/Index/',
                        data: { id: id, FilterDealIdentifierId: FilterDealIdentifierText, FilterHotelId: FilterHotelId, FilterCurrencyId: FilterCurrencyId },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);
                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //alert(textStatus);
                            alert('Sorry, Some error occurred');
                        }
                    });

                }
            });



            $("#FilterCurrencyId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                id = $("#DealMasterId").val();
                source = $("#Source").val();

                FilterDealIdentifierId = $("#FilterDealIdentifierId").val();
                FilterDealIdentifierText = $("#FilterDealIdentifierId option[value=" + FilterDealIdentifierId + "]").text();
                FilterDealIdentifierText = FilterDealIdentifierText == "-- Select--" ? "" : FilterDealIdentifierText;
                FilterAirlineId = $("#FilterAirlineId").val();
                FilterCurrencyId = $("#FilterCurrencyId").val();
                if (id == "") {
                    $("#FilterDealIdentifierId").empty();
                    $("#FilterDealIdentifierId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;
                }
                else {
                    $.ajax({
                        type: "GET",
                        url: '/Airline/BranchDealSetup/Index/',
                        data: { id: id, FilterDealIdentifierId: FilterDealIdentifierText, FilterAirlineId: FilterAirlineId, FilterCurrencyId: FilterCurrencyId, Source: source },
                        dataType: "html",
                        async: true,
                        cache: false,
                        success: function (serverResponse) {
                            $("#divDealContentGridFilter").empty().append(serverResponse);
                            $("#loadingIndicator").html('');
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert('Sorry, Some error occurred');
                        }
                    });
                }
            }).change();
        });
    </script>
</asp:Content>
