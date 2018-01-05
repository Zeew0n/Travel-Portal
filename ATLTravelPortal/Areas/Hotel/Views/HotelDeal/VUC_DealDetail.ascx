<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>
<div id="DealDetail_<%=Model.HotelDealId %>" style=" border:1px solid #ccc; margin-bottom:10px;""> 
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
<thead class="optional">
    <th style="width:65px;">Hotel</th>
    <th style="width:150px;">Deal Identifier</th>
    <th style="width:70px;">Currency</th>
    <th style="width:87px;">Markup</th>
    <th style="width:25px;">Is%</th>
    <th style="width:25px;">Comm</th>
    <th style="width:25px;">Is%</th>
    
</thead>
<tr class="optional" id="EditDealTemplate_<%=Model.HotelDealId %>">
    
 <td>
        
        <%: Model.HotelName%>
    </td>


    <td>
 <%:Model.DealIdentifier%>
    </td>
    <td>   <%:Model.Currency %></td>

    <td>
        
        <p style="width: 87px;">
            <span style="float: left; width: 67px;">Per Room</span><label style="width: 40px;"><%:Model.MarkupOnPerRoom%></label></p>
        <p style="width: 87px; border-top:1px solid #ccc;">
            <span style="float: left; width: 67px;">Extra Guest Charge</span>
            <label style="width: 40px;">
                <%:Model.MarkupOnExtraGuestCharge%></label></p>
     
    </td>
    <td>
       
        <%
string checkvalue = "";
checkvalue = Model.isPercentMarkupOnPerRoom == true ? "checked=checked" : "";
string guestChargeValue = "";
guestChargeValue = Model.isPercentMarkupOnExtraGuestCharge == true ? "checked=checked" : "";
            
             %>
        <input type="checkbox" <%=checkvalue %> disabled="disabled" /><br />
        <input type="checkbox" <%=guestChargeValue %> disabled="disabled" /><br />
    </td>
    <td>
        
        <label style="width: 40px;">
            <%:Model.CommissionOnPerRoom%></label><br />
        <label style="width: 40px;">
            <%:Model.CommissionOnExtraGuestCharge%></label><br />
       
    </td>
    <td>
        <%
string checkvalue1 = "";
checkvalue1 = Model.isPercentCommissionOnPerRoom == true ? "checked=checked" : "";
string guestChargeValue1 = "";
guestChargeValue1 = Model.isPercentCommissionOnExtraGuestCharge == true ? "checked=checked" : "";
            
             %>
        <input type="checkbox" <%=checkvalue1%> disabled="disabled" /><br />
        <input type="checkbox" <%=guestChargeValue1%> disabled="disabled" />
    </td>
 
    
</tr>
<tr>
    <td colspan="10" style="text-align:right; height:30px; vertical-align:middle;">
         <label id="DealDetail_<%=Model.HotelDealId %>_loading" style="width:20px; float:left;"></label>
        <input type="button" value="Delete" id="EditDelete_<%=Model.HotelDealId %>" class="del" onclick="return DeleteDeal('DealDetail_<%=Model.HotelDealId %>','<%=Model.HotelDealId %>')" />
        <input type="button" value="Edit" id="EditEdit_<%=Model.HotelDealId %>" onclick="EditDeal('DealDetail_<%=Model.HotelDealId %>','<%=Model.HotelDealId %>')" class="edit" />
    </td>
</tr>
</table>
</div>
