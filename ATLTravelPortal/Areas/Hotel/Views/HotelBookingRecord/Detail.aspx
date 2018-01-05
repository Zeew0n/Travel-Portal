<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingDetailModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
    <div class="float-right">
     <%:Html.ActionLink("Back To List", "Index", new { controller = "HotelBookingRecord", area = "Hotel" }, new { @class = "linkButton" })%>
    </div>
        <h3>
            Hotel <span>&nbsp;</span> Booking Detail
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <%Html.RenderPartial("Common/VUC_BookingDetail"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   <link rel="Stylesheet" href="<%:Url.Content("~/Content/css/hotelAdmin.css")%>" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function ToggleDiv(divId) {
            $("#" + divId).toggle();
            if ($("#Sign" + divId).html() == "+") {
                $("#Sign" + divId).html("-")
            }
            else {
                $("#Sign" + divId).html("+")
            }
        }
    </script>
</asp:Content>
