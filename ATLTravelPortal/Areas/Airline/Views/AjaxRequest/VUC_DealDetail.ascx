<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<div id="DealDetail_<%=Model.DealId %>" style="border: 1px solid #ccc; margin-bottom: 10px;">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead class="optional">
            <th style="width: 88px;">
                Deal Identifier
            </th>
            <th style="width: 65px;">
                Sector Type
            </th>
            <th style="width: 49px;">
                Currency
            </th>
            <th style="width: 100px;">
                Airline
            </th>
            <th style="width: 150px;">
                Sector Info
            </th>
            <th style="width: 70px;">
                Markup
            </th>

              <th style="width: 15px;">
                Is%
            </th>
            <th style="width: 70px; vertical-align: bottom;" class="brdLeft">
                <br />
                <div style="position: relative;">
                    <span style="position: absolute; top: -21px; left: -4px; width: 273px; background: #e3e3e3;
                        display: red; color: #000; text-align: center;">Commission</span>
                </div>
                YQ
            </th>
            <th style="width: 15px; vertical-align: bottom;" class="brdRight">
                Is%
            </th>
            <th style="width: 70px; vertical-align: bottom;" class="">
                BF
            </th>
            <th style="width: 15px; vertical-align: bottom;" class="brdRight">
                Is%
            </th>
            <th style="width: 70px; vertical-align: bottom;" class="">
                YQ+BF
            </th>
            <th style="width: 15px; vertical-align: bottom;">
                Is%
            </th>
        </thead>
        <tr class="optional" id="EditDealTemplate_<%=Model.DealId %>">
            <td>
                <%: Model.DealIdentifierText %>
            </td>
            <td>
                <%: Model.SectorType == "I" ? "International" : "Domestic"%>
            </td>
            <td>
                <%:Model.Currency %>
            </td>
            <td>
                <label style="width: 112px;">
                    <%:Model.AirlineName!=null?Model.AirlineName:"For All Airlines" %></label>
                <br />
                Class:
                <%:Model.AirlineClass!=null?Model.AirlineClass:"For All" %>
                <br />
                Cashback:
                <%:Model.Cashback %>
            </td>
            <td>
                <% if (Model.isSectorWise == false)
                   { %>
                <span>For All Sectors</span>
                <%}
                   else if (Model.isSectorWise == true)
                   { %>
                On Sector:
                <%
                       string isSectorWisecheckvalue = "";
                       isSectorWisecheckvalue = Model.isSectorWise == true ? "checked=checked" : ""; %>
                <input type="checkbox" <%=isSectorWisecheckvalue %> disabled="disabled" />
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">From:</span><%:Model.FromCity%>
                </p>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Model.ToCity%></p>
                <%} %>
                <br />
                On Roundtrip:
                <%:Html.CheckBoxFor(model => model.isRoundTrip, new { @disabled = "disabled" })%>
            </td>
            <td class="brdLeft brdnone">
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Adult</label>
                    <label>
                        <%:Model.AdultMarkup %></label>
                </p>
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Child</label>
                    <label>
                        <%:Model.ChildMarkup %></label>
                </p>
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Infant</label>
                    <label>
                        <%:Model.InfantMarkup %></label>
                </p>
                <p style="width: 85px;">
                    <label style="float: left; width: 35px;">
                        Is%</label>
                    <label>
                        <%:Html.CheckBoxFor(model => model.isMarkupPercentage, new  {@disabled="disabled" })%></label>
                </p>
                <p>
                   
                        Calculate On
                    <label>
                        <%:Model.DealCalculatedOnText %>
                    </label>
                </p>
            </td>
            <td>
            <label>
                        <%:Html.CheckBoxFor(model => model.isMarkupPercentage, new  {@disabled="disabled" })%></label>
            </td>
            <td class="brdnone">
                <label>
                    <%:Model.AdultYQCommission %></label><br />
                <label>
                    <%:Model.ChildYQCommission %></label><br />
                <label>
                    <%:Model.InfantYQCommission %></label>
            </td>
            <td>
                <%
                    string isYQCommissionPercentage = "";
                    isYQCommissionPercentage = Model.isYQCommissionPercentage == true ? "checked=checked" : ""; %>
                <input type="checkbox" <%=isYQCommissionPercentage %> disabled="disabled" />
                <br />
            </td>
            <td class="brdnone">
                <label>
                    <%:Model.AdultBFCommission %></label><br />
                <label>
                    <%:Model.ChildBFCommission %></label><br />
                <label>
                    <%:Model.InfantBFCommission %></label>
            </td>
            <td>
                <%
                    string isBFCommissionPercentage = "";
                    isBFCommissionPercentage = Model.isBFCommissionPercentage == true ? "checked=checked" : ""; %>
                <input type="checkbox" <%=isBFCommissionPercentage %> disabled="disabled" />
                <br />
            </td>
            <td class="brdnone">
                <label>
                    <%:Model.AdultYQBFCommission %></label><br />
                <label>
                    <%:Model.ChildYQBFCommission %></label><br />
                <label>
                    <%:Model.InfantYQBFCommission %></label>
            </td>
            <td>
                <%
                    string isYQBFCommissionPercentage = "";
                    isYQBFCommissionPercentage = Model.isYQBFCommissionPercentage == true ? "checked=checked" : ""; %>
                <input type="checkbox" <%=isYQBFCommissionPercentage %> disabled="disabled" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="13" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.DealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Delete" id="EditDelete_<%=Model.DealId %>" class="del"
                    onclick="return DeleteDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')" />
                <input type="button" value="Edit" id="EditEdit_<%=Model.DealId %>" onclick="EditDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')"
                    class="edit" />
            </td>
        </tr>
    </table>
</div>
