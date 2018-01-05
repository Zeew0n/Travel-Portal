<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" 
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.UnApprovedVoucherModel>" %>

    <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#">Account Management</a> <span>&nbsp;</span><strong>Unapprove Voucher</strong>
            </h3>
        </div>
    </div>
    <% using (Html.BeginForm())
       {%>
    <%if (Model.UnApprovedVoucherList != null)
      {
    %>
    <%var q = (from p in Model.UnApprovedVoucherList select new { p.ProductName }).Distinct().ToList(); %>
    <% for (int i = 0; i < q.Count(); i++)
       {%>
    <div class="type-option" style="margin-bottom: -10px; margin-top: 15px;">
        <h5 class="float-left">
            <a id="displayUserinfo_<% =q.ToList()[i].ProductName%>"><strong>
                <% =q.ToList()[i].ProductName%></strong></a></h5>
    </div>
    <%var k = (from l in Model.UnApprovedVoucherList where l.ProductName == q.ToList()[i].ProductName select l).ToList(); %>
    <%var s = (from t in k select new { t.VoucherNo }).Distinct().ToList(); %>
    <% for (int j = 0; j < s.Count(); j++)
       {%>
    <%var l = (from m in k where m.VoucherNo == s.ToList()[j].VoucherNo select m).ToList(); %>
    <div class="row2">
        <div class="contentGrid">
            <ul class="inline">
                <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                    class="GridView" width="100%">
                    <thead>
                        <tr>
                            <%-- <th>
                SNo
            </th>--%>
                            <th>
                                TranDate
                            </th>
                            <th>
                                LedgerName
                            </th>
                            <th>
                                Narration
                            </th>
                            <th>
                                Credit Amount
                            </th>
                            <th>
                                Debit Amount
                            </th>
                        </tr>
                    </thead>
                    <% 
           foreach (var item in l)
           {

               var sno = 0;
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
                    <tbody>
                        <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                            onmouseout="this.className='<%= classTblRow %>'">
                            <%--<td>
                    <%:sno%>
                </td>--%>
                            <td>
                                <%: TimeFormat.DateFormat( item.TranDate.ToString())%>
                            </td>
                            <td>
                                <%: item.LedgerName%>
                            </td>
                            <td>
                                <%: item.Narration1%>
                            </td>
                            <td>
                                <%: item.CreditAmount%>
                            </td>
                            <td>
                                <%: item.DebitAmount%>
                            </td>
                        </tr>
                    </tbody>
                    <%} %>
                    <tbody>
                    </tbody>
                </table>
                <div class="buttons-panel">
                    <ul>
                        <li>
                            <input type="button" value="Approve" class="btn3" onclick="document.location.href='/Administrator/UnApprovedVoucher/Approve/<%:s.ToList()[j].VoucherNo%>'" />
                        </li>
                        <li>
                            <input type="button" value="Reject" class="btn3" onclick="document.location.href='/Administrator/UnApprovedVoucher/Cancel/<%:s.ToList()[j].VoucherNo%>'" />
                        </li>
                    </ul>
                </div>
            </ul>
        </div>
    </div>
    <%}
       } %>
    <%} %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JsContent" runat="server">
</asp:Content>
