<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.AgentServiceProviderNames>" %>
<%int count = (int)ViewData["Count"];%>
<%string checkvalue = Model.ServiceProviderExistance == true ? "checked=checked" : "";%>
    <fieldset class="style1" style=" width:200px; float:left; padding: 0 10px 0;">
                <legend> <input type="checkbox" name="ServiceProviders[<%:count %>].ServiceProviderId" value="<%=Model.ServiceProviderId%>" <%:checkvalue %> id="checked<%:Model.ServiceProviderId%>" class="ServiceProvidercheckbox"/>&nbsp;&nbsp;&nbsp;
                <%:Model.ServiceProviderName%>
             
                </legend> 

    <div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse; font-size:13px;"
        class="GridView" width="100%" id="myTable">
            <th>
            </th>
            <th>
                Balance Check On
            </th>
        <% for (int counter = 0; counter < Model.AgentAccountSettingBasedOnServiceProvider.Count(); counter++)
       {
           var classTblRow = (counter % 2 == 0) ? "GridAlter" : "GridItem";  
        %>
        <tbody>
            <tr id="tr_<%=counter %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
              <td style=" font-size:16px; text-align:center;">
                <%:Model.AgentAccountSettingBasedOnServiceProvider.ElementAt(counter).Currency%>
                 <%:Html.Hidden("ServiceProviders[" + count + "].AgentAccountSettingBasedOnServiceProvider[" + counter + "].CurrencyId", Model.AgentAccountSettingBasedOnServiceProvider.ElementAt(counter).CurrencyId)%>
            </td>
            <td>
          <%:Html.DropDownList("ServiceProviders[" + count + "].AgentAccountSettingBasedOnServiceProvider[" + counter + "].BalanceCheckOnType", Model.AgentAccountSettingBasedOnServiceProvider.ElementAt(counter).balancecheckon, "--Select--", new { @Class = "checked" + Model.ServiceProviderId + "childbalancecheckon", @style = "font-size:13px;padding:4px;" })%>
            </td>
            </tr>
        </tbody>
        <%}%>
      
    </table>
       
        <%--<%:Html.HiddenFor(model=>model.ServiceProviderId) %>--%>
</div>

   </fieldset>
 