<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.UnIssuedInternationalTicketModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  

    <% Html.RenderAction("PNR", "AjaxRequest");%>
    <% Html.RenderAction("PNRSegment", "AjaxRequest");%>
    <% Html.RenderAction("PNRPassenger", "AjaxRequest");%>
    <% Html.RenderAction("Fare", "AjaxRequest");%>

    

    <%using (Html.BeginForm())
      {
           %>
            
      
    <%=Html.ValidationSummary(true)%>
    <div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>Extra Charge (Used for cancellation only)</b></h2> </div>
      <table>
    <tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.AirlineCancellationCharge)%> </th>
        <td><%: Html.TextBoxFor(model => model.AirlineCancellationCharge)%></td>
         <%: Html.ValidationMessageFor(model => model.AirlineCancellationCharge)%>
</tr>
  <tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.ArihantCancellationCharge)%> </th>
        <td><%: Html.TextBoxFor(model => model.ArihantCancellationCharge)%></td>
         <%: Html.ValidationMessageFor(model => model.ArihantCancellationCharge)%>
</tr>
<tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.isAgentWillPaycharge)%> </th>
        <td><%: Html.CheckBoxFor(model => model.isAgentWillPaycharge)%></td>
         <%: Html.ValidationMessageFor(model => model.isAgentWillPaycharge)%>
</tr>

</table>
<hr />
     <p>
		    <input type="submit" value="Issue PNR" name="submitButton"/>
            <input type="submit" value="Cancel PNR" name="submitButton"/>
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <%} %>
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

