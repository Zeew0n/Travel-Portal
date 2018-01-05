<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.AccountSettingBasedOnServiceProvider>" %>

<td style=" font-size:16px; text-align:center;">
    <%: Html.Label(Model.Currency)%>
     <%:Html.HiddenFor(model=>model.CurrencyId) %>
</td>
<td>
    <%:Html.DropDownListFor(model => model.BalanceCheckOnType, Model.balancecheckon, "--Select--", new { @style = "font-size:13px;padding:4px;" })%>
</td>
<td>
    <%:Html.CheckBoxFor(model => model.IsTransOnLocalCurrency)%>
</td>

