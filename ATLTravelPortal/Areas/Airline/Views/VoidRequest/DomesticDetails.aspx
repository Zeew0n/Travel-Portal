<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.VoidRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderAction("DomesticPNR");%>
    <% Html.RenderAction("DomesticPNRSegment");%>
    <% Html.RenderAction("DomesticPNRPassenger");%>
    <% Html.RenderAction("DomesticFare");%>

    <%using (Html.BeginForm())
      { %>
      <%:Html.HiddenFor(model=>model.ServiceProviderId) %>
    <%=Html.ValidationSummary(true)%>
    <div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>Extra Charge</b></h2> </div>
    <div style=" border:1px solid #ccc; padding:5px;">
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
                        </div>
     <p>
		    <input type="submit" value="Confirm" id="Confirm", name="Confirm" /> |
             <input type="submit" value="Reject" id="Reject" name="Reject" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>