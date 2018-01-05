<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<div id="DealDetail_<%=Model.DealId %>" style="border: 1px solid #ccc; margin-bottom: 10px;">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead class="optional">
            <th style="width: 200px;">
                Operator
            </th>
            <th style="width: 200px;">
                Category
            </th>
            <th style="width: 100px;">
                Sector Type
            </th>          
            <th style="width: 270px;">
                Sector
            </th>
            <th style="width: 270px;">
            Currency
            </th>
             <th style="width: 150px;">
                Amount
            </th>
            <th style="width: 15px;" class="brdRight">
                Is%
            </th>
        </thead>
        <tr class="optional" id="EditDealTemplate_<%=Model.DealId %>">
            <td>
                <label style="width: 112px;">
                    <%:Model.BusOperatorName!=""?Model.BusOperatorName:"For All"%></label>
            </td>
            <td>
                <label style="width: 112px;">
                    <%:Model.BusCategoryName!=""?Model.BusCategoryName:"For All" %></label>
            </td>
            <td>
                <%: Model.SectorType == "I" ? "International" : "Domestic"%>
            </td>
             <td>
           <%if ((Model.FromCity != null) && (Model.ToCity != null))
             { %>
                From:<%:Model.FromCity%><br />
                To:<%: Model.ToCity%>
                <%} %>
                <%else
               { %>
               For All Sector
                <%} %>
              </td>
             <td>
                <%:Model.Currency %>
            </td>
            <td>
                <%: Model.Amount %>
            </td>
            <td>
                
                    <%:Html.CheckBoxFor(model => model.isPercentage, new  {@disabled="disabled" })%>
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
