<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>
<%     if (Model.DealList != null)
       { %>
<%  int counterIndex = 0;
    foreach (var item in Model.DealList)
    {   %>
<% Html.RenderPartial("VUC_DealDetail", item); %>
<%
counterIndex++;
    } %>
<%} %>
