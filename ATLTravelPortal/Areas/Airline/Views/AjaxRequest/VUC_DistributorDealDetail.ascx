<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<div id="DealDetail_<%=Model.DealId %>" style="border: 1px solid #ccc; margin-bottom: 10px;">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead class="optional">
            <th style="width: 100px;">
                Airline
            </th>
            <th style=" width:100px;">
                Sector Type
            </th>
            <th style="width:50px;">
                Currency
            </th>
            <th style="width: 100px;">
                Sector Info
            </th>
            <th style="width: 100px;">
                Amount
            </th>
            <th style="width: 30px;">
                Is%
            </th>
        </thead>
        <tr class="optional" id="EditDealTemplate_<%=Model.DealId %>">
            <td>
                <label style="width: 112px;">
                    <%:Model.AirlineName!=null?Model.AirlineName:"For All Airlines" %></label>
                    <br />
                    Class:
                    <%:Model.AirlineClass %>
                    <br />
            </td>
            <td>
                <%: Model.SectorType == "I" ? "International" : "Domestic"%>
            </td>
            <td>
                <%:Model.Currency %>
            </td>
            <td>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">From:</span><%:Model.FromCity%>
                </p>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Model.ToCity%></p>
                <br />
                On Roundtrip:
                <%:Html.CheckBoxFor(model => model.isRoundTrip, new { @disabled = "disabled" })%>
            </td>
            <td>
                <%: Model.Amount %>
            </td>
            <td>
                <label>
                    <%:Html.CheckBoxFor(model => model.isPercentage, new  {@disabled="disabled" })%></label>
            </td>
        </tr>
        <tr>
            <td colspan="13" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.DealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Delete" id="EditDelete_<%=Model.DealId %>" class="del"
                    onclick="return DeleteDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')" />
                <input type="button" value="Edit" id="EditEdit_<%=Model.DealId %>" onclick="EditDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')"
                    class="edit" />
            </td>
        </tr>
    </table>
</div>
