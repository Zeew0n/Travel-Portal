<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<script src="../../../../Scripts/jquery.ui.autocomplete.selectFirst.js" type="text/javascript"></script>
<link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
    type="text/css" />
<link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
    type="text/css" />
<div class="pageTitle">
    <ul class="buttons-panel">
        <li>
            <div id="loadingIndicator">
            </div>
        </li>
        <li>
            <input type="submit" value="Save" id="saveDeal" />
        </li>
    </ul>
    <h3>
        <label class="icon_plane">
            Setup</label>
        <span>&nbsp;</span><strong>Create New Deal</strong><span>&nbsp;</span>
        <label class="icon_plane" id="ChoosedDealName">
            <%:Html.Encode(Model.DealMaserText) %></label>
        <label style="float:right" id="lblSuccess"></label>
        <label id="loading" style="width: 20px; float: right;"></label>
    </h3>
</div>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Create", "BranchDealSetup", FormMethod.Post, new { @id = "myForm" }))
   { %>
<%: Html.HiddenFor(model=>model.DealMasterId) %>
<div style="overflow: auto; width: 100%;">
    <table class="GridView" cellspacing="0" cellpadding="0" border="0" width="100%">
        <tbody>
            <% Html.RenderPartial("DealTemplate"); %>
        </tbody>
    </table>
</div>
<%} %>
<script type="text/javascript">
    $(document).ready(function () {

        $(function () {
            $("#AirlineName").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
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
                    $("#AirlineId").val(ui.item.id);
                }
            });
        });

        $(function () {
            $("#FromCity").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlineCity", type: "POST", dataType: "json",
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
                    $("#FromCityId").val(ui.item.id);

                }
            });
        });

        $(function () {
            $("#ToCity").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlineCity", type: "POST", dataType: "json",
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
                    $("#ToCityId").val(ui.item.id);
                }
            });
        });

        $("#DealIdentifierId").change(function () {
            var id = $("#DealIdentifierId").val();
            var text = $("#DealIdentifierId option[value=" + id + "]").text();
            $("#DealIdentifierText").val(text)
        }).change();
    });
</script>
