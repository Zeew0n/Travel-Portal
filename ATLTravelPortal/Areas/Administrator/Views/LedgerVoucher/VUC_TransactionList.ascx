<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.LedgerVoucherModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<link href="../../../../Content/css/global.css" rel="stylesheet" type="text/css" />
<link href="../../../../Content/css/reset.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="../../../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="../../../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
<link href="../../../../Content/css/text.css" rel="stylesheet" type="text/css" />
<div id="arihanTravel">
    <div class="content">
        <%
            int TranStatusId = 0;
            if (Model.TransactionList != null)
            {
                var preProductId = 0;


                foreach (var item in Model.TransactionList)
                {


                    Model.TranStatusId = item.TranStatusId;
                    var ProductId = item.ProductId;


                    if (ProductId == preProductId && preProductId > 0)
                    {
        %>
        <ul>
            <li>
                <label>
                    Tran Date:
                </label>
                <strong>
                    <%: TimeFormat.DateFormat( item.TranDate.ToString())%>
                </strong></li>
            <li>
                <label>
                    Voucher No:
                </label>
                <strong>
                    <%: item.VoucherNo %></strong> </li>
            <li>
                <label>
                    Product:
                </label>
                <strong>
                    <%: item.ProductName%></strong> </li>
            <li>
                <label>
                    Current Status:
                </label>
                <%if (Model.TranStatusId != 4)
                  { %>
                <strong>
                    <%: item.TranStatusName%></strong>
                <%} %>
                <% else
                  { %>
                <strong>Deleted</strong>
                <%} %>
            </li>
            <li>
                <label>
                    Created By:</label>
                <%:item.MakerName %>
            </li>
        </ul>
        <% if (Model.TranStatusId == 4)
           { %>
        <div class="form-box1-row-content float-right">
            <ul>
                <li>
                    <label>
                        Deleted By:
                    </label>
                    <strong>
                        <%: item.DeletedName%>
                    </strong></li>
                <li>
                    <label>
                        Deleted Date:
                    </label>
                    <strong>
                        <%: TimeFormat.DateFormat(item.DeleteDate.ToString())%>
                    </strong></li>
            </ul>
        </div>
        <%} %>
        <br />
        <%
                    }
                    preProductId++;

                }

            }
        %>
        <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead style="text-align: left; background: #666; color: #fff; height: 32px; vertical-align: middle;
                font-size: 14px;">
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                        Ledger Name
                    </th>
                    <th>
                        Narration
                    </th>
                    <th>
                        Dr Amount
                    </th>
                    <th>
                        Cr Amount
                    </th>
                </tr>
            </thead>
            <% var sno = 0;

               int count = Model.TransactionList.Count();
               if (count > 0)
               {
                   Model.txtSumDrAmount = Model.TransactionList.ElementAt(count - 1).txtSumDrAmount;
                   Model.txtSumCrAmount = Model.TransactionList.ElementAt(count - 1).txtSumCrAmount;
               }

               foreach (var item in Model.TransactionList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%: sno%>
                    </td>
                    <td>
                        <%: item.LegderName %>
                    </td>
                    <td>
                        <%:item.Narration1%>
                    </td>
                    <td>
                        <% if (item.Debit == "D")
                           {%>
                        <%:item.Amount%>
                        <%} %>
                    </td>
                    <td>
                        <% if (item.Debit == "C")
                           {%>
                        <%:item.Amount%>
                        <%} %>
                    </td>
                </tr>
            </tbody>
            <%} %>
        </table>
    </div>
    <br />
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Delete", "LedgerVoucher", new { @Id = Model.VoucherNo }, FormMethod.Post, new { @autocomplete = "off" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <%if (Model.TranStatusId != 4)
      { %>
    <div class="divLeft">
        <label>
            Remark:</label><br />
        <br />
        <%: Html.TextAreaFor(model => model.DeleteRemark, new { @Style = " width:400px; margin-left:43px; padding:5px;" })%>
        <span class="redtxt">*</span>
        <%: Html.ValidationMessageFor(model => model.DeleteRemark)%>
    </div>
    <br />
    <input type="submit" value="Delete" />
    <%} %>
    <%} %>
</div>
