<%@ Page Language="C#" MasterPageFile="~/Views/Shared/HomePage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color: #515357; font-size: 18px; padding: 10px 0px 20px 15px;">
        <%: ViewData["Message"] %></h1>
    <ul class="productgrid">
        <li><a href="/Administrator/Dashboard">
            <img src="../../Content/images/administrator.jpg" width="152" height="76" alt="Airline" />Administrator</a></li>
        <li><a href="/Airline/Dashboard">
            <img src="../../Content/images/plane.jpg" width="152" height="76" alt="Airline" />Airline</a></li>
        <li><a href="/Bus/Dashboard">
            <img src="../../Content/images/bus.jpg" width="152" height="76" alt="Airline" />Bus</a></li>
        <li><a href="/Train/Dashboard">
            <img src="../../Content/images/train.jpg" width="152" height="76" alt="Airline" />Train</a></li>
        <li><a href="/Hotel/Dashboard">
            <img src="../../Content/images/hotel.jpg" width="152" height="76" alt="Airline" />Hotel</a></li>
        <li><a href="/MobileRechargeCard/Dashboard">
            <img src="../../Content/images/mobile-recharge.jpg" width="152" height="76" alt="Airline" />Mobile
            Recharge</a></li>
    </ul>
</asp:Content>
