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
        <label style="float: right" id="lblSuccess">
        </label>
        <label id="loading" style="width: 20px; float: right;">
        </label>
    </h3>
</div>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Create", "HotelDistributorDealSetup", FormMethod.Post, new { @id = "myForm" }))
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
            $("#HotelName").autocomplete({
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
                    $("#HotelId").val(ui.item.id);
                }
            });
        });      
    });
</script>
