<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.AgentClassDealModel>" %>
<% 
    int sno = Model.CreatedBy;
%>
<td class="<%=sno %>" style="font-size: 16px; text-align: center;">
    <%: Html.Label(Model.AgentClassName)%>
    <input type="hidden" name="AgentClassId_<%=sno %>" id="AgentClassId_<%=sno %>" value="<%=Model.AgentClassId %>" />
</td>
<td>
    <%:Html.DropDownListFor(model => model.DealMasterId, Model.AirlineDealList, "--Select--", new { @id = "MasterDealId_" + sno, @style = "font-size:13px;padding:4px;width:100px;" })%>
</td>
<td>
    <%:Html.DropDownListFor(model => model.HotelMasterDealId, Model.HotelDealList, "--Select--", new { @id = "HotelMasterDealId_" + sno, @style = "font-size:13px;padding:4px;width:100px;" })%>
</td>
<td>
    <%:Html.DropDownListFor(model => model.BusMasterDealId, Model.BusDealList, "--Select--", new { @id = "BusMasterDealId_" + sno, @style = "font-size:13px;padding:4px;width:100px;" })%>
</td>
<td>
    <%:Html.DropDownListFor(model => model.MobileMasterDealId, Model.MobileDealList, "--Select--", new { @id = "MobileMasterDealId_" + sno, @style = "font-size:13px;padding:4px; width:100px;" })%>
</td>
<td>
    <input type="button" value="Save" id="Save_<%=sno %>" onclick="SaveAgentClassDeal('<%=sno%>')" />
</td>
<td>
    <label style="float: right" id="lblSuccess_<%=sno %>">
    </label>
    <label id="loading_<%=sno %>" style="width: 20px; float: right;">
    </label>
</td>
