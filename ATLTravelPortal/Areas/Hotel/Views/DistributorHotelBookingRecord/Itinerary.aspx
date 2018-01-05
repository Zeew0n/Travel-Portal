<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelItinearyModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Itinerary
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <%if (Model.Message.MsgNumber == 1)
          { %>
        <ul class="buttons-panel">
            <li>Email :
                <input type="text" id="Text1" style="width: 250px; padding-right: 20px;" />
                <input id="Button1" type="button" class="cmdSendEmail" onclick="javascript:sendEmail('Text1','<%=Model.BookingRecordId %>')"
                    value="Send itineary" />
            </li>
            <li>
                <%:Html.ActionLink("Print Itinerary", "PrintItineary", new { id = Model.BookingRecordId, controller = "DistributorHotelBookingRecord", area = "Hotel" }, new { @target = "_blank", @class = "linkButton linkButtonHtl" })%>
            </li>
        </ul>
        <%} %>
        <h3>
            Hotel <span>&nbsp;</span> Booking Itinerary
        </h3>
    </div>
     <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <%if (Model.Message.MsgNumber == 1)
      { %>
    <%:Html.Partial("Common/VUC_Itinerary", Model)%>
  <%--  <div class="buttonBar">
        <ul class="buttons-panel">
            <li>Email :
                <input type="text" id="emailId" style="width: 250px; padding-right: 20px;" />
                <input class="cmdSendEmail" type="button" onclick="javascript:sendEmail('emailId','<%=Model.BookingRecordId %>')"
                    value="Send itineary" />
            </li>
            <li style="width: ">
                <%:Html.ActionLink("Print Itinerary", "PrintItineary", new { id = Model.BookingRecordId, controller = "HotelBookingRecord", area = "Hotel" }, new { @target = "_blank", @class = "linkButton linkButtonHtl" })%>
            </li>
        </ul>
    </div>--%>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<link href="<%=Url.Content("~/Content/css/hotelAdmin.css")%>" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        var loadingImg = '<%=Url.Content("~/Content/Icons/loading.gif") %>';
        function sendEmail(emailId, id) {
            var msgwidth1 = $(window).width();
            var msgheight1 = $(window).height();
            var html = ' <div id="MessagePupUp" class="htl-successBox">';
            html += '<img src="' + loadingImg + '" /><br />';
            html += '<strong>Sending e-mail</strong>';
            html += '<div>';
            var email = $('#' + emailId).val()
           $("#messageBox").html(html);
            $(function () {
                $.ajax({
                    type: "POST",
                    url: "/Hotel/HotelBookingRecord/EmailItinerary",
                    data: { id: id, emal: email },
                    dataType: "html",
                    traditional: true,
                    success: function (result) {
                        $("#messageBox").html(result)
                    },
                    error: function () {
                        $("#msgBox").remove();
                    }
                });
            });
        }
    </script>
</asp:Content>
