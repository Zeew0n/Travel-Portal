<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerVoucherModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <ul class="buttons-panel float-right">
        <li>
            <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
        </li>
    </ul>
    <div class="pageTitle">
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Edit Voucher</strong>
        </h3>
    </div>
    <% using (Html.BeginForm("Edit", "LedgerVoucher", FormMethod.Get, new { @id = "ATForm", @autocomplete = "off" }))
       {%>
    <div class="row-1 ">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content">
                    <div>
                        <label>
                            Voucher Number</label>
                        <%:Html.TextBoxFor(model => model.VoucherNo)%>
                        <%:Html.ValidationMessageFor(model => model.VoucherNo)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
    <div class="form-box1-row">
        <p class="mrg-lft-130">
            <input type="submit" value="Search" class="btn3" />
        </p>
    </div>
     
    <%} %>
    <hr />
    <div id="divAjaxPlaceHolder">
        <%if (Model != null)
          {
              if (Model.TranList.Count > 0)
              { %>
        <%Html.RenderPartial("VUC_EditVoucher", Model); %>
        <%}
          } %>
    </div>
    <%:Session["ActionResponse"] %>
     <div class="buttonBar" align="right">
      <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/LedgerVoucher/Create'" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        .GridView thead.nobg
        {
            text-align: left;
            background: none !important;
            color: #000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.ui.autocomplete.selectFirst.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#TranDate").datepicker({
                defaultDate: new Date($(this).val()),
                numberOfMonths: 2,
                disable: true,
                buttonImage: '../../Content/images/calendar.gif',
                maxDate: new Date()
            });


            ///// Debit Credit Autocomplete /////////////////////////////////////////////////////
            var arr = new Array();
            arr[0] = 'Dr';
            arr[1] = 'Cr';

            $(function () {
                $('.firstinput').live('keydown.autocomplete', function () {
                    $(this).autocomplete({ source: arr, selectFirst: true });
                    var id = this.id.match(/\d/);
                    if (($("#DrCr" + id).val() == "Cr") || ($("#DrCr" + id).val() == "c") || ($("#DrCr" + id).val() == "C")) {
                        $("#Debit" + id).val('0');
                        $("#Debit" + id).attr('readonly', true);
                        $("#Credit" + id).attr('readonly', false);
                    }
                    else if (($("#DrCr" + id).val() == "Dr") || ($("#DrCr" + id).val() == "d") || ($("#DrCr" + id).val() == "D")) {
                        $("#Credit" + id).val('0');
                        $("#Credit" + id).attr('readonly', true);
                        $("#Debit" + id).attr('readonly', false);
                    }
                });

            });
            ///////////////////////////  auto complete for Ledger Name////////////////////////////////////////////

            ///////////////////////////  auto complete for Ledger Name////////////////////////////////////////////

            $(function () {
                $('.accountname').live('keydown.autocomplete', function () {
                    var id = this.id.match(/\d/);
                    $(this).autocomplete({
                        minlength: 2,
                        selectFirst: true,
                        source: function (request, response) {
                            $.ajax({
                                url: "/Administrator/AjaxRequest/FindLedgerName", type: "POST", dataType: "json",
                                data: { searchText: request.term, maxResult: 5 },
                                success: function (data) {
                                    response($.map(data, function (item) {
                                        return { label: item.LedgerName, value: item.LedgerName, id: item.LedgerId }
                                    }))
                                }
                            });
                        },
                        width: 150,
                        select: function (event, ui) {
                            $("#" + "TranList_" + id + "__LedgerId").val(ui.item.id);
                        }
                    });
                });
            });
            ///////////////////////////////////////////////////////////////////////////////////////

        });
    </script>
</asp:Content>
