<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.ProfitLossReportModel>" %>


<div class="contentGrid">
  

        <table id="Expenses" cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;
        width: 397px; float: left; border-right:2px;" class="GridView2" width="100%">
        <thead>
        <tr>
            <th colspan="3" style="text-align:center; ">
                Expenses
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
        </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = 0;

           int count = Model.ProfitLossReportlist.Count();
           if (count > 0)
           {
               Model.txtSumExpenses = Model.ProfitLossReportlist.ElementAt(count - 1).txtSumExpenses;
           }



           foreach (var item in Model.ProfitLossReportlist.Where(x => x.txtIncome == 0))
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
                    <%: item.txtExpenses%>
                </td>
            </tr>
        </tbody>
        <%      }%>
        <tbody>
            <tr>
                <% if (Model.ProfitLossReportlist != null)
                   {
                       if (count > 0)
                       {
                %>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total Expenses:<%:Model.txtSumExpenses == null ? "" : (Model.txtSumExpenses).ToString()%>
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
            <th colspan="3" style="text-align:center; ">
                Income
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
        </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% 
            var sno = 0;

            int count = Model.ProfitLossReportlist.Count();
            if (count > 0)
            {
                Model.txtSumIncome = Model.ProfitLossReportlist.ElementAt(count - 1).txtSumIncome;
            }



            foreach (var item in Model.ProfitLossReportlist.Where(x => x.txtExpenses == 0))
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
                    <%: item.txtLedgerName %>
                </td>
                <td>
                    <%: item.txtIncome%>
                </td>
            </tr>
        </tbody>
        <%      }%>
        <tbody>
            <tr>
                <% if (Model.ProfitLossReportlist != null)
                   {
                       if (count > 0)
                       {
                %>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total Income:<%:Model.txtSumIncome == null ? "" : (Model.txtSumIncome).ToString()%>
                </td>
                <%}
              }
                %>
            </tr>
        </tbody>
        <%}%>
    </table>
</div>


