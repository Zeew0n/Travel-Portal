<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>


    <div class="contentGrid">
   
        <% if (Model != null)
           { %>
         
        <%if (Model.CreditLimitList != null && Model.CreditLimitList.Count() > 0)
          { %>
          <strong> Details Credit Limit For <%:Model.CreditLimitList.FirstOrDefault().AgencyName %>(<%:Model.CreditLimitList.FirstOrDefault().AgencyCode %>)</strong>
             <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                            class="GridView" width="100%">
                            <thead>
                                <th>
                                    SN
                                </th>
                            <th>
                            Amount
                        </th>
                        <th>
                            Effective Date
                        </th>
                            <th>
                            Expiry Date
                        </th>
                        <th>
                            Credit Limit Type
                        </th>
                        <th></th>
                            </thead>
                      
                            <% var sno = 0;
                               double? totalamount = 0;
                               foreach (var item in Model.CreditLimitList)
                               {

                                   sno++;
                                   totalamount += item.txtAmount;
                            %>
                            <tbody>
                                <tr>
                                    <td>
                                        <%:sno%>
                                    </td>
                                    <td>
                                    <%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", item.txtAmount))%>
                                </td>
                                <td>
                                    <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.hdfEffectiveFrom.ToString())%>
                                </td>
                                <td>
                                <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.hdfExpireOn.ToString())%>
                                </td>
                                <td><%:item.CreditLimitTypeName%></td>
                                <td><%:(item.isApproved==true ? "Approved" :"Unapproved" )%></td>
                                    
                                </tr>
                            </tbody>
                            <%}
                                         %>
                            <tbody>
                              <tr style="background:#999;">
                                                 <td colspan="6" style="text-align:left;">
                                              <label>Total: <strong><%:(string.Format(System.Globalization.CultureInfo.GetCultureInfo("hi-IN"), "{0:#,0.#}", totalamount))%></strong></label>
                                              </td>
                                            </tr>
                            </tbody>
                            
                        </table>

       <%} %>
      
       <%} %>
         </div>