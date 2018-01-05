<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.ProfitLossReportModel>" %>

<div class="contentGrid">
    <table id="Expenses" cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;
        width: 397px; float: left; border-right:2px;" class="GridView2" width="100%">
        <thead>
        <tr>
            <th colspan="3" style="text-align:center;">
                Liabilities
            </th>
        </tr>
        <tr>
            <th>
                SNo
            </th>
            <th>
                Ledger Name
            </th>
            <th>
                Amount
            </th>
            <%--<th>
            Total
            </th>--%>
        </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = 0;

           int count = Model.BalanceSheetList.Count();
           if (count > 0)
           {
               Model.txtSumLiabilities = Model.BalanceSheetList.ElementAt(count - 1).txtSumLiabilities;
           }



           foreach (var item in Model.BalanceSheetList.Where(x => x.txtAsset == 0))
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.txtLedgerName %>
                </td>
                <td>
                    <%: item.txtLiabilities%>
                </td>
            </tr>
        </tbody>
        <%      }%>
        <tbody>
            <tr>
                <% if (Model.BalanceSheetList != null)
                   {
                       if (count > 0)
                       {
                %>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total Liabilities:<%:Model.txtSumLiabilities == null ? "" : (Model.txtSumLiabilities).ToString()%>
                </td>
                <%}
              }
                %>
            </tr>
        </tbody>
        <%}%>
    </table>


    <table id="Income" cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;
        float: right; width: 399px;" class="GridView3">
        <thead>
        <tr>
            <th colspan="3" style="text-align:center;">
                Assets
            </th>
        </tr>
        <tr>
            <th>
                SNo
            </th>
            <th>
                Ledger Name
            </th>
            <th>
                Amount
            </th>
            <%--<th>
            Total
            </th>--%>
        </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% 
            var sno = 0;

            int count = Model.BalanceSheetList.Count();
            if (count > 0)
            {
                Model.txtSumAsset = Model.BalanceSheetList.ElementAt(count - 1).txtSumAsset;
            }



            foreach (var item in Model.BalanceSheetList.Where(x => x.txtLiabilities == 0))
            {
                sno++;
                var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.txtLedgerName%>
                </td>
                <td>
                    <%: item.txtAsset%>
                </td>
            </tr>
        </tbody>
        <%      }%>
        <tbody>
            <tr>
                <% if (Model.BalanceSheetList != null)
                   {
                       if (count > 0)
                       {
                %>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total Asset:<%:Model.txtSumAsset == null ? "" : (Model.txtSumAsset).ToString()%>
                </td>
                <%}
              }
                %>
            </tr>
        </tbody>
        <%}%>
    </table>
</div>