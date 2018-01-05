<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "DealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
    <thead>
        <th style="width: 88px;">
            Deal Identifier
        </th>
        <th style="width: 65px;">
            Sector Type
        </th>
        <th style="width: 49px;">
            Currency
        </th>
        <th style="width: 75px;">
            <%:Html.LabelFor(model => model.AirlineName)%>
        </th>
        <th style="width: 150px;">
            Sector Info
        </th>
        <th style="width: 70px;">
            Markup
        </th>
          <th style="width: 15px;">
                Is%
            </th>
        <th style="width: 70px; vertical-align: bottom;" class="brdLeft">
            <br />
            <div style="position: relative;">
                <span style="position: absolute; top: -21px; left: -4px; width: 273px; background: #515357;
                    display: red; color: #fff; text-align: center;">Commission</span>
            </div>
            YQ
        </th>
        <th style="width: 15px; vertical-align: bottom;" class="brdRight">
            Is%
        </th>
        <th style="width: 70px; vertical-align: bottom;" class="">
            BF
        </th>
        <th style="width: 15px; vertical-align: bottom;" class="brdRight">
            Is%
        </th>
        <th style="width: 70px; vertical-align: bottom;" class="">
            YQ+BF
        </th>
        <th style="width: 15px; vertical-align: bottom;">
            Is%
        </th>
    </thead>
    <tbody>
        <tr class="optional">
            <td>
                <%:Html.DropDownListFor(model => Model.DealIdentifierId, Model.DealIdentifierList, new { @id = "editDealIdentifierId", @style="width:90px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText, new { @id = "editDealIdentifierText" })%>
            </td>
            <td>
                <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "International", Value = "I"},
                         new SelectListItem { Text = "Domestic", Value = "D"},
                        };%>
                <%:Html.DropDownListFor(model => model.SectorType, sectorTypeList, new  {@id="editSectorType" })%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, new { @id = "editCurrencyId" })%>
            </td>
            <td>
                <%:
    
        Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })
               
                %>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%:Html.TextBoxFor(model => model.AirlineName, new { id="editAirlineName_"+counterIndex,@style ="width:75px;", @class = "airAutoComplete",
                                                         @name = "editAirlineName_" + counterIndex}) %>
                <%: Html.HiddenFor(model => model.AirlineId, new { @id = "editAirlineId_" + counterIndex }) %>
                <%:Html.ValidationMessageFor(model => model.AirlineName)%>
                <br />
                Class:
                <%:Html.TextBoxFor(model => model.AirlineClass, new { @style = "width:75px;" })%>
                <%:Html.ValidationMessageFor(model => model.AirlineClass)%>
                <br />
                Cashback:
                <%:Html.TextBoxFor(model => model.Cashback, new { @style = "width:75px;" })%>
                <%:Html.ValidationMessageFor(model => model.Cashback)%>
            </td>
            <td>
                On Sector
                <%:Html.CheckBoxFor(model=>model.isSectorWise) %>
                <p style="width: 110px;">
                    <span style="float: left; width: 35px;">From:</span>
                    <%: Html.TextBoxFor(model => model.FromCity, new { @id = "editFromCity_"+counterIndex, @class = "fromCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.FromCityId, new {@id="editFromCityId_"+counterIndex})%>
                    <%: Html.ValidationMessageFor(model => model.FromCity, "*")%>
                </p>
                <p style="width: 110px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Html.TextBoxFor(model => model.ToCity, new { @id = "editToCity_"+counterIndex, @class = "toCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.ToCityId, new  {@id="editToCityId_"+counterIndex })%>
                    <%: Html.ValidationMessageFor(model => model.ToCity, "*")%>
                </p>
                <br />
                On Roundtrip:
                <%:Html.CheckBoxFor(model=>model.isRoundTrip) %>
            </td>
            <td class="brdLeft brdnone">
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Adult</label>
                    <label>
                        <%:Html.TextBoxFor(model => model.AdultMarkup, new { @style="width:40px;"})%></label>
                </p>
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Child</label>
                    <label>
                        <%:Html.TextBoxFor(model => model.ChildMarkup, new { @style="width:40px;"})%></label>
                </p>
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Infant</label>
                    <label>
                        <%:Html.TextBoxFor(model => model.InfantMarkup, new { @style="width:40px;" })%></label>
                </p>
                
                <p>
                        Calculate On
                    <label>
                        <%:Html.DropDownListFor(model => model.DealCalculateOnId, Model.DealCalculateOnList, new { @style = "width:40px;" })%></label>
                </p>
            </td>
            <td>
            <label>
                        <%:Html.CheckBoxFor(model=>model.isMarkupPercentage) %></label>
            </td>
            <td class="brdnone">
                <%:Html.TextBoxFor(model => model.AdultYQCommission, new { @style="width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.ChildYQCommission, new { @style = "width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.InfantYQCommission, new { @style="width:40px;" })%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isYQCommissionPercentage) %><br />
            </td>
            <td class="brdnone">
                <%:Html.TextBoxFor(model => model.AdultBFCommission, new { @style="width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.ChildBFCommission, new { @style = "width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.InfantBFCommission, new { @style = "width:40px;" })%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isBFCommissionPercentage) %><br />
            </td>
            <td class="brdnone">
                <%:Html.TextBoxFor(model => model.AdultYQBFCommission, new { @style="width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.ChildYQBFCommission, new { @style = "width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.InfantYQBFCommission, new { @style = "width:40px;" })%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isYQBFCommissionPercentage) %><br />
            </td>
        </tr>
        <tr>
            <td colspan="13" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.DealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Update" id="UpdateUpdate_<%=counterIndex %>" onclick="UpdateDeal('DealDetail_<%=Model.DealId %>','myUpdateForm<%=Model.DealId %>')"
                    class="update" />
                <input type="button" value="Cancel" onclick="CancelDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')"
                    id="Cancel_<%=counterIndex %>" class="Canc" />
            </td>
        </tr>
    </tbody>
</table>
<%} %>
<script type="text/javascript" language="javascript">
    $(".airAutoComplete").live("change", function () {
        var text = $(this).val();
        var idCtrl = $(this).attr("id");
        var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

        if (text == '')
            $("#editAirlineId_" + idCounter).val('');
    });   
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $(".airAutoComplete").autocomplete({
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
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

                    $("#editAirlineId_" + idCounter).val(ui.item.id);
                }
            });
        });

        $(function () {
            $(".fromCityAutoComplete").autocomplete({
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
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);
                    $("#editFromCityId_" + idCounter).val(ui.item.id);
                }
            });
        });

        $(function () {
            $(".toCityAutoComplete").autocomplete({
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
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);
                    $("#editToCityId_" + idCounter).val(ui.item.id);
                }
            });
        });
    });
</script>
