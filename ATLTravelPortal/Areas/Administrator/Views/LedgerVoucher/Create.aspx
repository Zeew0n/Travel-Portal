<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerVoucherModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Ledger Voucher Entry
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <ul class="buttons-panel float-right">
        <li>
            <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
        </li>
    </ul>
    <div class="pageTitle">
        <div class="float-right">
            <a href="/Administrator/LedgerVoucher/Edit" class="linkButton">Edit Voucher</a>
        </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Voucher Entry</strong>
        </h3>
    </div>
    <% using (Html.BeginForm("Search", "LedgerVoucher", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off", enctype = "multipart/form-data", target = "_blank" }))
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
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Product")%></label>
                        <%:Html.DropDownListFor(model => model.ProductId, (SelectList)ViewData["ProductList"], "---Select ---")%>
                        <%:Html.ValidationMessageFor(model => model.ProductId,"*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Currency")%></label>
                        <%:Html.DropDownListFor(model => model.CurrencyID, (SelectList)ViewData["CurrencyList"], "---Select ---")%>
                        <%:Html.ValidationMessageFor(model => model.CurrencyID, "*")%>
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
                        <tr>
                            <td>
                                <%: Html.TextBox("DrCr0", "", new { @class = "firstinput" })%>
                            </td>
                            <td>
                                <%: Html.TextBox("AccountName0","", new { @class = "accountname" })%>
                                <%: Html.Hidden("LedgerId0")%>
                            </td>
                            <td>
                                <%: Html.TextBox("Narration0")%>
                            </td>
                            <td>
                                <%: Html.TextBox("Debit0", "0", new { @class = "SectorFare" })%>
                            </td>
                            <td>
                                <%: Html.TextBox("Credit0", "0", new { @class = "lastinput" })%>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <thead class="nobg">
                            <th colspan="2">
                            </th>
                            <th>
                                <label>
                                    Entry Summary</label>
                            </th>
                            <th>
                                <label id="lblTotalDrAmt">
                                </label>
                            </th>
                            <th>
                                <label id="lblTotalCrAmt">
                                </label>
                            </th>
                        </thead>
                    </table>
                </div>
                <div class="buttonBar">
                    <input type="submit" value="Save" class="btn1" disabled="disabled" id="Savebtn" />
                    <%: Html.Hidden("noOfentry")%>
                    <label class="redtxt">
                    </label>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <%:Session["ActionResponse"] %>
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
        });

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////Assigning Dynamic IP Record /////////////////////////////////////////////
        $().ready(function () {
            $('#form1')[0].reset();  // Reset all form

            $('.lastinput').live("keypress", function (event) {
                var id = this.id.match(/\d/);
                var rowsCount = $('#Ledgerentry tr').size();
                var indexNo = parseInt(rowsCount) - 2;
                if (event.keyCode == 9 || event.keyCode == 13) {

                    //$('#Credit' + indexNo - 1).removeAttr('class');
                    // $('#DrCr' + indexNo - 1).removeAttr('class');

                    var rowToAdd = $('<tr></tr>');
                    rowToAdd.append($('<td></td>')
                    .append($('<input type="text"/>')
                        .attr('name', 'DrCr' + indexNo)
                        .attr('id', 'DrCr' + indexNo)
                        .attr('class', 'firstinput')

                    )
                )
                .append($('<td></td>')
                    .append($('<input type="text"/>')
                        .attr('name', 'AccountName' + indexNo)
                        .attr('id', 'AccountName' + indexNo)
                          .attr('class', 'accountname')
                    )
                     .append($('<input type="hidden"/>')
                        .attr('name', 'LedgerId' + indexNo)
                        .attr('id', 'LedgerId' + indexNo)
                )
                )

                .append($('<td></td>')
                    .append($('<input type="text"/>')
                        .attr('name', 'Narration' + indexNo)
                        .attr('id', 'Narration' + indexNo)
                        .attr('class', 'Narration required')
                    )
                )
                .append($('<td></td>')
                    .append($('<input type="text"/>')
                        .attr('name', 'Debit' + indexNo)
                          .attr('id', 'Debit' + indexNo)
                        .attr('class', 'SectorFare')
                         .attr('value', '0')

                    )
                )
                .append($('<td></td>')
                    .append($('<input type="text"/>')
                        .attr('name', 'Credit' + indexNo)
                         .attr('id', 'Credit' + indexNo)
                        .attr('class', 'lastinput')
                         .attr('value', '0')
                    )
                )

                 .append($('<td></td>')
                    .append($('<span></span>')
                    .attr('class', 'btn_o')
                        .append($('<span></span>')
                        .attr('class', ' btn_i')
                            .append($('<input type="button" value="Cancel"/>')
                                .attr('name', 'Cancel' + indexNo)
                                .attr('class', 'btn1 Cancel')
                            )
                        )
                    )
                )

                    $('#Ledgerentry:last').append(rowToAdd);
                    //                    $("#DrCr" + indexNo).focus();
                    $('#noOfentry').val(indexNo + 2);
                }


            });

            $(".SectorFare").live("keyup", function () {
                CalculateTotalDrCrAmount();
            });
            $(".lastinput").live("keyup", function () {
                CalculateTotalDrCrAmount();
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
                            $("#LedgerId" + id).val(ui.item.id);

                        }
                    });
                });
            });
            ///////////////////////////////////////////////////////////////////////////////////////

            function CalculateTotalDrCrAmount() {
                var allDrSectors = $('.SectorFare'); //gets all elements that have class name as 'SectorFare'
                var allCrSectors = $('.lastinput');
                //// Calculate Debit 
                var totalDrAmt = 0;
                var sectorDrCount = 0;
                sectorDrCount = $(allDrSectors).length;
                //// Calculate credit
                var totalCrAmt = 0;
                var sectorCrCount = 0;
                sectorCrCount = $(allCrSectors).length;
                ///////////////////////////////////////////////
                for (var i = 0; i <= sectorDrCount - 1; i++) {
                    if (isNaN(parseFloat($(allDrSectors[i]).val())))
                        $(allDrSectors[i]).val('0');
                    totalDrAmt += parseFloat($(allDrSectors[i]).val());
                }
                for (var i = 0; i <= sectorCrCount - 1; i++) {
                    if (isNaN(parseFloat($(allCrSectors[i]).val())))
                        $(allCrSectors[i]).val('0');

                    totalCrAmt += parseFloat($(allCrSectors[i]).val());
                }
                $('#lblTotalCrAmt').html('Rs: ' + totalCrAmt);
                $('#lblTotalDrAmt').html('Rs: ' + totalDrAmt);
                //////////////////////////////////////////////////

                if (totalDrAmt == totalCrAmt) {
                    $('#Savebtn').removeAttr("disabled");
                    $('.redtxt').html('');
                }
                else {
                    $('#Savebtn').attr('disabled', 'disabled');
                    $('.redtxt').html('Please Check Debit and Credit');
                }
            }


            $(document).ready(function () {
                $('.Cancel').live('click', function () {
                    $(this).parent().parent().parent().parent().remove();
                    //Re assign the name
                    var index = 1;
                    $('.DrCr').each(function () {
                        $(this).attr('name', 'DrCr' + index);
                        index = parseInt(index) + 1;
                    });
                    index = 1;
                    $('.AccountName').each(function () {
                        $(this).attr('name', 'AccountName' + index);
                        index = parseInt(index) + 1;
                    });
                    index = 1;
                    $('.Narration').each(function () {
                        $(this).attr('name', 'Narration' + index);
                        index = parseInt(index) + 1;
                    });
                    index = 1;
                    $('.Debit').each(function () {
                        $(this).attr('name', 'Debit' + index);
                        index = parseInt(index) + 1;
                    });
                    index = 1;
                    $('.Credit').each(function () {
                        $(this).attr('name', 'Credit' + index);
                        index = parseInt(index) + 1;
                    });


                    var rowsCount = $('#Ledgerentry tr').size();
                    rowsCount = parseInt(rowsCount) - 1;
                    $('#noOfentry').val(rowsCount);


                    CalculateTotalDrCrAmount(); //To Recalculate the total amout if some has delete the rows
                });
            });
        });
    </script>
</asp:Content>
