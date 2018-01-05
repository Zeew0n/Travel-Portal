<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainBookingRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Canceled Request
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <div class="box3">
        <div class="userinfo">
            <div class="row-1">
                <div class="pageTitle">
                    <h3>
                        <a class="icon_plane" href="#">Booking Request</a> <span>&nbsp;</span><strong>Cancelled
                            List</strong>
                    </h3>
                </div>
            </div>
        </div>
    </div>
    <%Html.RenderPartial("~/Areas/Train/Views/BookingRequest/VUC_SearchOption.ascx", Model);%>
    <%Html.RenderPartial("VUC_Index", Model);%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script src="<%:Url.Content("~/Areas/Train/Scripts/Train-Main.js") %>" type="text/javascript"></script>
</asp:Content>
