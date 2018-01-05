<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<div id="DealDetail_<%=Model.DealId %>" style="border: 1px solid #ccc; margin-bottom: 10px;">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead class="optional">
            <th style="width: 100px;">
                Hotel
            </th>
            <th style="width: 100px;">
                Amount
            </th>
            <th style="width: 15px;">
                Is%
            </th>
        </thead>
        <tr class="optional" id="EditDealTemplate_<%=Model.DealId %>">
            <td>
                <label style="width: 112px;">
                    <%:Model.HotelName!=null?Model.HotelName:"For All Hotels" %></label>
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
