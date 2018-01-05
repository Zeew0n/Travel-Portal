<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>
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
<% using (Html.BeginForm("Create", "HotelDeal", FormMethod.Post, new { @id = "myForm" }))
   { %>
<%: Html.HiddenFor(model=>model.DealMasterId) %>
<%: Html.HiddenFor(model=>model.DealIdentifierText) %>
<div style="overflow: auto; width: 100%;">
    <table class="GridView" cellspacing="0" cellpadding="0" border="0" width="100%">
        <tbody>
            <tr class="optional">
                <td>
                    <%:Html.LabelFor(model => model.HotelId)%><br />
                    <%:Html.DropDownListFor(model => model.HotelId, Model.HotelList,"--Select--", new { @style = "width:112px;" })%>
                </td>
                <td>
                    <%:Html.LabelFor(model => model.DealIdentifier)%><br />
                    <%:Html.DropDownListFor(model => model.DealIdentifier, Model.DealIdentifierList)%>
                </td>
                <td>
                    <%:Html.LabelFor(model => model.CurrencyId)%><br />
                    <%:Html.DropDownListFor(model=>model.CurrencyId,Model.CurrencyList) %>
                </td>
                <td>
                    Markup
                    <p style="width: 85px;">
                        <span style="float: left; width: 35px;">Per Room</span>
                        <%:Html.TextBoxFor(model => model.MarkupOnPerRoom, new { @style = "width:40px;" })%>
                    </p>
                    <p style="width: 85px;">
                        <span style="float: left; width: 35px;">Extra Guest Charge</span>
                        <%:Html.TextBoxFor(model => model.MarkupOnExtraGuestCharge, new { @style = "width:40px;" })%>
                    </p>
                </td>
                <td>
                    Is%<br />
                    <%:Html.CheckBoxFor(model => model.isPercentMarkupOnPerRoom)%><br />
                    <%:Html.CheckBoxFor(model => model.isPercentMarkupOnExtraGuestCharge)%>
                </td>
                <td>
                    Commission<br />
                    <%:Html.TextBoxFor(model => model.CommissionOnPerRoom, new { @style = "width:40px;" })%><br />
                    <%:Html.TextBoxFor(model => model.CommissionOnExtraGuestCharge, new { @style = "width:40px;" })%><br />
                </td>
                <td>
                    Is%<br />
                    <%:Html.CheckBoxFor(model => model.isPercentCommissionOnPerRoom)%><br />
                    <%:Html.CheckBoxFor(model => model.isPercentCommissionOnExtraGuestCharge)%>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<%} %>
<script type="text/javascript">
    $(document).ready(function () {
        $("#CountryCode").change(function () {
            $("#loading").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            filterCountryCode = $("#CountryCode").val();            
            if (filterCountryCode == "") {
//                $("#CityId").empty();
//                $("#CityId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#loading").html('');
                return false;
            }
            else {
                var url = "/Hotel/AjaxRequest/GetHtl_BookingDestinationCity";
                $.getJSON(url, { id: filterCountryCode }, function (data) {
                    $("#CityId").empty();
                    $("#CityId").append("<option value=''>" + "-- Select--" + "</option>");
                    $.each(data, function (index, optionData) {
                        $("#CityId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                });
                $("#loading").html('');
            }
        }).change();


        $("#DealIdentifier").change(function () {
            var id = $("#DealIdentifier").val();
            var text = $("#DealIdentifier option[value=" + id + "]").text();
            $("#DealIdentifierText").val(text)
        }).change();
    });
</script>
