<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Models.PageViewModel.AvailableBalanceViewModel>" %>
<script src="../../Scripts/jquery.li-scroller.1.0.js" type="text/javascript"></script>

<script src="../../Scripts/slidedeck.jquery.lite.js" type="text/javascript"></script>
<link href="../../Content/css/slidedeck.skin.css" rel="stylesheet" type="text/css" />
<link href="../../Content/css/slidedeck.skin.ie.css" rel="stylesheet" type="text/css" />
<%if (Model != null)
  {%>
<div class="balanceContent">
    <div id="slidedeck_frame" class="balanceDtls">
        <div id="slidedeck_frame" class="skin-slidedeck">
            <dl class="slidedeck">
                <dt>NPR</dt>
                <dd>
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td style="text-align: right;">
                                    Credit Limit:
                                </td>
                                <td style="text-align: left; padding-left: 4px;">
                                    <strong>
                                        <% if (Model.CreditLimitNPR.Value != 0)
                                           { %>
                                        <%:(string.Format("{0:#,#.#}", Model.CreditLimitNPR))%>
                                        <%}
                                           else
                                           { %>
                                        N/A
                                        <%} %>
                                    </strong>
                                    <%if (Model.isLowBalanceNPR)
                                      { %>
                                    <a href="" class="lowBalance"><span>
                                        <p style="color: Red; font-size: 11px;">
                                            Low Balance NPR</p>
                                    </span></a>
                                    <%} %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    Remaining Balance:
                                </td>
                                <td style="text-align: left; padding-left: 4px;">
                                    <strong>
                                        <% if (Model.CurrentBalanceNPR.Value != 0) %>
                                        <%{ %>
                                        <%:(string.Format("{0:#,#.#}", Model.CurrentBalanceNPR))%>
                                        <%} %>
                                        <%else
                                           { %>
                                        N/A
                                        <%} %>
                                    </strong>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </dd>
                <%if (Model.CreditLimitUSD.Value > 0 || Model.CurrentBalanceUSD.Value > 0)
                  { %>
                <dt>USD</dt>
                <dd>
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td style="text-align: right;">
                                    Credit Limit:
                                </td>
                                <td style="text-align: left; padding-left: 4px;">
                                    <strong>
                                        <%:(string.Format("{0:#,#.#}", Model.CreditLimitUSD))%></strong>
                                    <%if (Model.isLowBalanceUSD)
                                      { %>
                                    <a href="" class="lowBalance"><span>
                                        <p style="color: Red; font-size: 11px;">
                                            Low Balance USD</p>
                                    </span></a>
                                    <%} %>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    Remaining Balance:
                                </td>
                                <td style="text-align: left; padding-left: 4px;">
                                    <strong>
                                        <%:(string.Format("{0:#,#.#}", Model.CurrentBalanceUSD))%></strong>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </dd>
                <%} %>
            </dl>
        </div>
        <script type="text/javascript">
            $('.slidedeck').slidedeck();
        </script>
    </div>
   
</div>
<%} %>
<div class="extendBtn">
    <a href="#">&nbsp;</a>
</div>
<script type="text/javascript">
    $('.extendBtn').live("click", function (event) {
        event.preventDefault();
        if ($('.balanceContent').css("display") == "none") {
            $('.balanceContent').css('display', 'block');
            $(this).addClass('expanded').removeClass('collapsed');
        }
        else {
            $('.balanceContent').css('display', 'none');
            $(this).addClass('collapsed').removeClass('expanded');
        }
    });
</script>


