<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelBookingCancelModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ProcessCancellation
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="pageTitle">
        <h3>
            Hotel <span>&nbsp;</span> Pending Cancel Detail
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <%if (Model.Message.MsgNumber == 1 && Model.IsProcessed == false)
      { %>
    <% using (Html.BeginForm("ProcessCancellation", "HotelBookingProcess", FormMethod.Post, new { @id = "frm" }))
       {%>
    <%:Html.HiddenFor(model => model.BookingCancelId)%>
    <div class="buttonBar" style="clear: both; height: 30px;">
        <ul class="buttons-panel">
            <%if (Model.Message.MsgNumber == 1 && Model.IsProcessed == false)
              { %>
            <li>
                <input id="Cancel" type="button" value="Cancel" onclick="location.href='/Hotel/HotelBookingProcess/PendingCancellationList'"/>
                <input id="cmdSubmit" type="submit" value="Get Cancilation Status" onclick="frm.cmdSubmit.disabled=true;" />
            </li>
            <%}
              else if (Model.Message.MsgNumber == 1 && Model.IsProcessed == true)
              { %>
            <li>Email :
                <input type="text" id="emailId" style="width: 250px; padding-right: 20px;" />
                <input id="cmdSendEmail" type="button" value="Send Cancel Email" />
            </li>
            <li>
                <%:Html.ActionLink("Print Cancel Detail", "PrintCancel", new { id = Model.BookingRecordId, controller = "HotelBookingRecord", area = "Hotel" }, new { @target = "_blank", @class = "linkButton linkButtonHtl" })%>
            </li>
            <li>
                <input id="cmdViewEmailFormat" type="button" value="View Email Format" onclick="javascript:ViewEmailFormat('<%:Url.Content("~/Hotel/HotelBookingRecord/CancellationEmail")%>')" />
            </li>
            <%} %>
        </ul>
    </div>
    <%} %>
    <div id="msg">
    </div>
    <%}%>
    <%Html.RenderPartial("Common/VUC_BookingDetail", Model.BookingDetail); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 <link rel="Stylesheet" href="<%=Url.Content("~/Content/css/hotelAdmin.css")%>" type="text/css" />
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
