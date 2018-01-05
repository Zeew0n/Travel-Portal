<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>
<%int counterIndex = Model.HotelDealId; %>
<% using (Html.BeginForm("Index", "DealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
    <thead>
        <th style="width: 65px;">
            Hotel
        </th>
        <th style="width: 150px;">
            Deal Identifier
        </th>
        <th style="width: 70px;">
            Currency
        </th>
        <th style="width: 87px;">
            Markup
        </th>
        <th style="width: 25px;">
            Is%
        </th>
        <th style="width: 25px;">
            Comm
        </th>
        <th style="width: 25px;">
            Is%
        </th>
    </thead>
    <tbody >
        <tr class="optional">
            
                <%:
        Html.HiddenFor(model => model.HotelDealId, new { @id ="editHotelDealId" })
                %>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
            <td>
                <%:Html.DropDownListFor(model => model.HotelId, Model.HotelList,"--Select--", new { @id = "editHotelId", @style = "width:112px;" })%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => Model.DealIdentifier, Model.DealIdentifierList, new { @id = "editDealIdentifier", @style="width:90px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText, new { @id = "editDealIdentifierText" })%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, new { @id = "editCurrencyId" })%>
            </td>
            <td>
                <p style="width: 85px;">
                    <span style="float: left; width: 35px;">Per Room</span>
                    <%:
            Html.TextBoxFor(model => model.MarkupOnPerRoom, new { @style = "width:40px;" })
                    %>
                </p><br />
                <p style="width: 85px; border-top:1px solid #ccc; padding-top:3px">
                    <span style="float: left; width: 35px;">Extra Guest Charge</span>
                    <%:Html.TextBoxFor(model => model.MarkupOnExtraGuestCharge, new { @style = "width:40px;" })%>
                </p>
            </td>
            <td>
                <%:Html.CheckBoxFor(model => model.isPercentMarkupOnPerRoom)%><br />
                <%:Html.CheckBoxFor(model => model.isPercentMarkupOnExtraGuestCharge)%>
            </td>
            <td>
                <%:Html.TextBoxFor(model => model.CommissionOnPerRoom, new { @style = "width:40px;" })%><br />
                <%:Html.TextBoxFor(model => model.CommissionOnExtraGuestCharge, new { @style = "width:40px;" })%><br />
            </td>
            <td>
                <%:Html.CheckBoxFor(model => model.isPercentCommissionOnPerRoom)%><br />
                <%:Html.CheckBoxFor(model => model.isPercentCommissionOnExtraGuestCharge)%>
            </td>
        </tr>
        <tr>
            <td colspan="10" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.HotelDealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Update" id="UpdateUpdate_<%=counterIndex %>" onclick="UpdateDeal('DealDetail_<%=Model.HotelDealId %>','myUpdateForm<%=Model.HotelDealId %>')"
                    class="update" />
                <input type="button" value="Cancel" onclick="CancelDeal('DealDetail_<%=Model.HotelDealId %>','<%=Model.HotelDealId %>')"
                    id="Cancel_<%=counterIndex %>" class="Canc" />
            </td>
        </tr>
    </tbody>
</table>
<%} %>
