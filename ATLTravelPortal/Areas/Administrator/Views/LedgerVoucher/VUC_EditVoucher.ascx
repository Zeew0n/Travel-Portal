<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.LedgerVoucherModel>" %>
<% using (Html.BeginForm())
   {%>
<%: Html.ValidationSummary(true)%>
<div class="row-1 ">
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.TranDate)%></label>
                    <%:Html.TextBoxFor(model => model.TranDate)%>
                    <%:Html.ValidationMessageFor(model => model.TranDate)%>
                    <%:Html.HiddenFor(model => model.VoucherNo) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Product")%></label>
                    <%:Html.DropDownListFor(model => model.ProductId, Model.ProductList, "---Select ---")%>
                    <%:Html.ValidationMessageFor(model => model.ProductId,"*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Currency")%></label>
                    <%:Html.DropDownListFor(model => model.CurrencyID, Model.CurrencyList, "---Select ---")%>
                    <%:Html.ValidationMessageFor(model => model.CurrencyID, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.CheckerRemark)%></label>
                    <%:Html.TextAreaFor(model => model.CheckerRemark, new { @cols="40" ,@rows="5"})%>
                    <%:Html.ValidationMessageFor(model => model.CheckerRemark, "*")%>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row-1">
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <h3>
            </h3>
            <div class="contentGrid">
                <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                    class="GridView" width="100%" id="Ledgerentry">
                    <thead>
                        <th>
                            Dr/Cr
                        </th>
                        <th>
                            Account Name
                        </th>
                        <th>
                            Narration
                        </th>
                        <th>
                            Debit
                        </th>
                        <th>
                            Credit
                        </th>
                    </thead>
                    <% 
           for (int i = 0; i < Model.TranList.Count; i++)
           { %>
                    <tr>
                        <td>
                            <%:Html.TextBoxFor(model => model.TranList[i].Debit, new {@class="firstinput" })%>
                            <%:Html.HiddenFor(model => model.TranList[i].TranID)%>
                        </td>
                        <td>
                            <%:Html.TextBoxFor(model => model.TranList[i].LegderName, new { @class = "accountname" })%>
                            <%:Html.HiddenFor(model => model.TranList[i].LedgerId)%>
                        </td>
                        <td>
                            <%:Html.TextBoxFor(model => model.TranList[i].Narration1)%>
                        </td>
                        <td>
                            <%:Html.TextBoxFor(model => model.TranList[i].DebitAmount)%>
                        </td>
                        <td>
                            <%:Html.TextBoxFor(model => model.TranList[i].CreditAmount)%>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <%} %>
                    <thead class="nobg">
                        <th colspan="2">
                        </th>
                        <th>
                            <label>
                                Entry Summary</label>
                        </th>
                        <th>
                            <label id="lblTotalDrAmt">
                                <%:Model.txtSumDrAmount %>
                            </label>
                        </th>
                        <th>
                            <label id="lblTotalCrAmt">
                                <%:Model.txtSumCrAmount %>
                            </label>
                        </th>
                    </thead>
                </table>
            </div>
            <div class="buttonBar">
                <input type="submit" value="Save" class="btn1" id="Savebtn" />
                <%: Html.Hidden("noOfentry")%>
                <label class="redtxt">
                </label>
            </div>
        </div>
    </div>
</div>
<%} %>