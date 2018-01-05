<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.ServiceProviderNames>" %>
<%  var gridClass = (Model.CountIndex % 2 == 0) ? "leftView" : "rightView"; %>
<fieldset class="style1 <%=gridClass %>" style="padding: 5px 10px;">
    <legend>
        <%:Model.ServiceProviderName%></legend>
    <%using (Html.BeginForm("Index", "ServiceProviderAccountSetting", FormMethod.Post, new { @class = "validate" }))
      { %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" class="simpleStyle" width="100%"
            id="myTable">
            <thead>
                <th>
                    Currency
                </th>
                <th>
                    Balance Check On
                </th>
            </thead>
            <% for (int counter = 0; counter < Model.AccountSettingBasedOnServiceProvider.Count(); counter++)
               {
                   var classTblRow = (counter % 2 == 0) ? "GridAlter" : "GridItem";
              
            %>
            <tbody>
                <tr id="tr_<%=counter %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:Model.AccountSettingBasedOnServiceProvider.ElementAt(counter).Currency%>
                        <%:Html.Hidden("AccountSettingBasedOnServiceProvider[" + counter + "].CurrencyId", Model.AccountSettingBasedOnServiceProvider.ElementAt(counter).CurrencyId)%>
                    </td>
                    <td>
                        <%:Html.DropDownList("AccountSettingBasedOnServiceProvider[" + counter + "].BalanceCheckOnType", Model.AccountSettingBasedOnServiceProvider.ElementAt(counter).balancecheckon, "--Select--", new {@Class="required" })%>
                    </td>
                </tr>
            </tbody>
            <%}%>
        </table>
        <input type="submit" value="Save" class="float-right" />
        <%:Html.HiddenFor(model=>model.ServiceProviderId) %>
    </div>
    <%} %>
</fieldset>
<style type="text/css">
    .leftView, .rightView
    {
        width: 45%;
        padding: 5px 10px;
        margin-bottom: 10px;
    }
    .leftView
    {
        float: left;
        clear: left;
    }
    .rightView
    {
        float: right;
        clear: right;
    }
    fieldset.style1
    {
        border: 1px solid #CCCCCC;
    }
    fieldset.style1
    {
        background: #F5F5F5;
    }
    fieldset.style1 form
    {
        background: #fff;
    }
</style>
