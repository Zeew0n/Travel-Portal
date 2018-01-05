<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

 <% if (Model != null)
           { %>
        <%if (Model.CreditLimitList != null && Model.CreditLimitList.Count() > 0)
          { %>
        <%var CreditLimitByAgentWise = (from p in Model.CreditLimitList.Where(xx => xx.isActive == true) select new { p.ddlAgentId, p.AgencyName, p.AgencyCode }).Distinct().ToList(); %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <%-- tablesorter--%>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Distributor Name
                </th>
                <th>
                    Distributor Code
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
                        <%:item.AgencyCode %>
                    </td>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0" class="SubGridView" style="border: 1px solid #ccc;
                            margin: 5px 0px;">
                            <thead>
                                <th>
                                    SN
                                </th>
                                <th>
                                    Amount
                                </th>
                                <th>
                                    Currency
                                </th>
                                <th>
                                    Credit Limit Type
                                </th>
                                <th>
                                    Is Approve?
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                            </thead>
                            <% var usersno = 0;
                               double? totalamount = 0;
                               double? totalamountInUse = 0;
                               string cssActiveInacticehighlight = string.Empty;
                               foreach (var eachitem in Model.CreditLimitList.Where(xx => (xx.AgencyName == item.AgencyName && xx.isActive == true)))
                               {
                                   usersno++;
                                   cssActiveInacticehighlight = eachitem.hdfEffectiveFrom == null ? "inactiveHgh" : (eachitem.hdfExpireOn < DateTime.Now ? "inactiveHgh" : "activeHgh");
                                   totalamount += eachitem.txtAmount;
                                   totalamountInUse += eachitem.hdfEffectiveFrom == null ? 0 : (eachitem.hdfExpireOn < DateTime.Now ? 0 : eachitem.txtAmount);
                                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                            %>
                            <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                                onmouseout="this.className='<%= classTblRow %>'">
                                <td>
                                    <%:usersno %>
                                </td>
                                <td>
                                    <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", eachitem.txtAmount))%><span
                                        class="<%:cssActiveInacticehighlight %>"></span>
                                </td>
                                <td>
                                    <%:eachitem.CurrencyName%>
                                </td>
                                <td>
                                    <%:eachitem.CreditLimitTypeName %>
                                </td>
                                <% if (eachitem.isApproved == true)
                                   { %>
                                <td>
                                    Approve
                                </td>
                                <%} %>
                                <%else
                                   { %>
                                <td>
                                    <%: Html.ActionLink("Approve Now", "Details", new{id=eachitem.AgentCreditLimitId}) %>
                                </td>
                                <%} %>
                                <td>
                                    <%--  ---- details region in popup---------------------%>
                                    <a href="javascript: void(0);" class="detailsPopup">Details <span>Created by
                                        <%:eachitem.CreatedBy %><br />
                                        Approved by
                                        <%:eachitem.ApprovedBy %><br />
                                        Effectivee from
                                        <%:ATLTravelPortal.Helpers.TimeFormat.DateFormat(eachitem.hdfEffectiveFrom.ToString()) %><br />
                                        Expire on
                                        <%:ATLTravelPortal.Helpers.TimeFormat.DateFormat(eachitem.hdfExpireOn.ToString()) %><br />
                                        Remarks
                                        <%:eachitem.Comments %><br />
                                        <b></b></span></a>
                                    <%--  ---- details region in popup---------------------%>
                                    | <a href="/Administrator/BranchOfficeCreditLimit/Edit/<%:eachitem.AgentCreditLimitId %>">Edit</a>
                                    |
                                    <% if (eachitem.isApproved != true)
                                       { %>
                                    <a href="/Administrator/BranchOfficeCreditLimit/Delete/<%:eachitem.AgentCreditLimitId %>" onclick="return confirm('Are you sure you want to delete this record?')">
                                        Delete</a>
                                    <%}
                                       else
                                       { %>
                                    <a href="javascript: void(0);" class="detailsPopup">Delete<span>You need to un-approve
                                        first in order to delete this records?</span></a>
                                    <%} %>
                                </td>
                            </tr>
                            <%} %>
                            <tr style="background: #999;">
                                <td colspan="6" style="text-align: left; color: #fff;">
                                    <label>
                                        Total: <strong>
                                            <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", totalamount))%>
                                        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        Active Amount:
                                        <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", totalamountInUse))%>&nbsp;&nbsp;&nbsp;&nbsp;
                                        Expired Amount:
                                        <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}",totalamount- totalamountInUse))%></label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
            <%}
                                } %>
        </table>
        <%} %>
        <%} %>