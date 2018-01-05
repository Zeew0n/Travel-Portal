<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bus Schedule Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
    <ul class="buttons-panel">
        <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
                </li></ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Bus Schedule Details</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusMasterId)%>: <span class="labelDetail">
                            <%: Model.BusMasterName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.BusCategoryId)%>: <span class="labelDetail">
                            <%: Model.BusCategoryName%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.DepartureCityId)%>: <span class="labelDetail">
                            <%: Model.DepartureCityName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.DestinationCityId)%>: <span class="labelDetail">
                            <%: Model.DestinationCityName%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.DepartureTime)%>: <span class="labelDetail">
                            <%: Model.DepartureTime%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ArrivalTime)%>: <span class="labelDetail">
                            <%: Model.ArrivalTime%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.TypeName)%>: <span class="labelDetail">
                            <%: Model.TypeName%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.DurationHHMM)%>: <span class="labelDetail">
                            <%: Model.DurationHHMM%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.Rate)%>: <span class="labelDetail">
                            <%: Model.Rate%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    <%: Html.LabelFor(model => model.ActualRate)%>: <span class="labelDetail">
                            <%: Model.ActualRate%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.PurchaseRate)%>: <span class="labelDetail">
                            <%: Model.PurchaseRate%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    <%: Html.LabelFor(model => model.AgentCommission)%>: <span class="labelDetail">
                            <%: Model.AgentCommission%></span>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.KiloMeter)%>: <span class="labelDetail">
                            <%: Model.KiloMeter%></span>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                    <div class="daydtl">
                        <%if (Model.Sunday == true) %>
                        <%: Html.LabelFor(model => model.Sunday)%>
                        <%if (Model.Monday == true) %>
                        <%: Html.LabelFor(model => model.Monday)%><%if (Model.Tuesday == true) %>
                        <%: Html.LabelFor(model => model.Tuesday)%>
                        <%if (Model.Wednesday == true) %>
                        <%: Html.LabelFor(model => model.Wednesday)%>
                        <%if (Model.Thursday == true) %>
                        <%: Html.LabelFor(model => model.Thursday)%>
                        <%if (Model.Friday == true) %>
                        <%: Html.LabelFor(model => model.Friday)%>
                        <%if (Model.Saturday == true) %>
                        <%: Html.LabelFor(model => model.Saturday)%>
                    </div>
                </div>
            </div>
        </div>
      <%--  <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <div id="Div1">
                    </div>
                </li>
                <li>
                    <%:Html.ActionLink("Create", "Create", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Edit", "Edit", new { id = Model.ScheduleId, controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                <li>
                    <%:Html.ActionLink("Delete", "Delete", new { id = Model.ScheduleId, controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                </li>
                <li>
                    <%:Html.ActionLink("List", "Index", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
