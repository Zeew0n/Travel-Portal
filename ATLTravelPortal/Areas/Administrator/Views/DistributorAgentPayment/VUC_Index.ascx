<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        
        <%if (Model.AgentCashDepositsList != null && Model.AgentCashDepositsList.Count() > 0)
          { %>
            <%var CreditLimitByAgentWise = (from p in Model.AgentCashDepositsList select new { p.AgentId, p.AgencyName, p.AgentCode }).Distinct().ToList(); %> 
             <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                            class="GridView" width="100%">
                           <%-- tablesorter--%>
                            <thead>
                                <th>
                                    SN
                                </th>
                                <th>
                                    Agency Name
                                </th>
                                <th>
                                    Agency Code
                                </th>
                                <th>
                                     Details
                                </th>
                            </thead>
                            <%
                                if (Model != null)
                                {
                            %>
                            <% var sno = 0;

                            foreach (var item in CreditLimitByAgentWise)
                               {

                                   sno++;
                                  
                            %>
                            <tbody>
                                <tr>
                                    <td>
                                        <%:sno%>
                                    </td>
                                    <td>
                                        <%:item.AgencyName%>
                                    </td>
                                    <td>
                                        <%:item.AgentCode %>
                                    </td>
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0" class="SubGridView" style="border: 1px solid #ccc;
                                            margin: 5px 0px;">
                                            <thead>
                                                <th>
                                                    SN
                                                </th>
                                                <th>
                                                  Payment Mode
                                                </th>
                                                <th>
                                                   Deposit Amount
                                                </th>
                                                <th>Currency</th>
                                                <th>
                                                  Deposit Date
                                                </th>
                                                 <th>Status</th>
                                                 <th>Action</th>
                                            </thead>
                                            <% var usersno = 0;
                                               double? totalamount = 0;
                                               string cssActiveInacticehighlight = string.Empty;
                                               foreach (var eachitem in Model.AgentCashDepositsList.Where(xx => (xx.AgentId == item.AgentId)))
                                               {
                                                   usersno++;
                                                   cssActiveInacticehighlight = eachitem.status != 1 ? "inactiveHgh" : "activeHgh";
                                                   totalamount += eachitem.ChequeAmount;
                                                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                                                    %>
                                           <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                                            onmouseout="this.className='<%= classTblRow %>'">
                                                <td>
                                                    <%:usersno %>
                                                </td>
                                                 <td><%:eachitem.PaymentModeName %></td>
                                                <td>
                                                 <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", eachitem.ChequeAmount))%>
                                                </td>
                                                <td><%: eachitem.CurrencyName %></td>
                                                <td><%:ATLTravelPortal.Helpers.TimeFormat.DateFormat(eachitem.ChequeIssueDate.ToString()) %></td>
                                       
                                                 <td><%:(eachitem.status ==1 ? "Approved" :( (eachitem.status ==2 ? "Processing" : "Rejected"))) %><span class="<%:cssActiveInacticehighlight %>"></span></td>
                                                 
                                               
                                                  <td> 
                                             
                                                   <a href="/Administrator/DistributorAgentPayment/Details/<%:eachitem.DepositId %>" class="details"></a> 
                                                  |  <% if (eachitem.status != 1)
                                                      { %>
                                                   <a href="/Administrator/DistributorAgentPayment/Edit/<%:eachitem.DepositId %>" class="edit"></a> |
                                                    <%} %>
                                                 
                                                   <a href="/Administrator/DistributorAgentPayment/Delete/<%:eachitem.DepositId %>" class="delete" title="Reject" onclick="return confirm('Are you sure you want to reject this payment?')"></a>
                                                 
                                                  </td>
                                            </tr>
                                            <%} %>
                                               <tr style="background:#999;">
                                                 <td colspan="6" style="text-align:left; color:#fff;">
                                              <label>Total: <strong><%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", totalamount))%> </strong>
                                             </label>
                                              </td>
                                             
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                            <%} } %>
                        </table>
       <%} %>
       <%} %>
         </div>