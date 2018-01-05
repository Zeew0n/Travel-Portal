<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingProcessModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Process
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% using (Html.BeginForm("Process", "HotelBookingProcess", FormMethod.Post, new { @id = "frm" }))
       {%>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <input type="submit" value="Get Booking Ststus" />
            </li>
            <li>
                <%:Html.ActionLink("Cancel", "Index", new { controller = "HotelSearch", area = "Hotel" }, new { @class = "linkButton linkButtonHtl"})%>
            </li>
        </ul>
        <h3>
            Hotel <span>&nbsp;</span> Pending Booking List
        </h3>
    </div>
    <%if (Model.Message.MsgStatus == true)
      {
    %>
    <%:Html.Partial("Utility/VUC_Message",Model.Message) %>
    <%}%>
    <%:Html.HiddenFor(model => model.BookingRecordId)%>
    <%:Html.Partial("Common/VUC_BookingDetail",Model.BookingDetail)%>
    <div class="buttonBar" style="clear:both;">
        <ul class="buttons-panel">
            <li>
                <input type="submit" value="Get Booking Ststus" />
            </li>
            <li>
                <%:Html.ActionLink("Cancel", "Index", new { controller = "HotelSearch", area = "Hotel" }, new { @class = "linkButton linkButtonHtl"})%>
            </li>
        </ul>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 <link rel="Stylesheet" type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css")%>"/>
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
