<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AdminConfigurationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Settings</strong>
            </h3>
        </div>
    </div>
    <% Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("Index", "BranchSettings", FormMethod.Post))
      { %>
    <div class="box3">
        <div class="buttons-panel float-right">
            <ul>
                <li>
                    <input type="submit" value="Save" class="save" />
                </li>
            </ul>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <legend>____________________________________Airline Bypass Deal________________________________________</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.RadioButtonFor(model => model.ByPass, "Allow")%>
                        Allow
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.RadioButtonFor(model => model.ByPass, "Disallow")%>
                        Disallow
                        <%: Html.HiddenFor(model=>model.SettingID) %>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>
    <hr />
    <div class="row-1">
        <div class="form-box1 round-corner">
            <legend>____________________________________Bus Bypass Deal________________________________________</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.RadioButtonFor(model => model.BusByPass, "BusAllow")%>
                        Allow
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.RadioButtonFor(model => model.BusByPass, "BusDisallow")%>
                        Disallow
                        <%: Html.HiddenFor(model=>model.BusSettingID) %>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>
    <hr />
    <div class="row-1">
        <div class="form-box1 round-corner">
            <legend>____________________________________Mobile Bypass Deal________________________________________</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.RadioButtonFor(model => model.MobileByPass, "MobileAllow")%>
                        Allow
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.RadioButtonFor(model => model.MobileByPass, "MobileDisallow")%>
                        Disallow
                        <%: Html.HiddenFor(model=>model.MobileSettingID) %>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>
    <hr />
    <div class="row-1">
        <div class="form-box1 round-corner">
            <legend>____________________________________Hotel Bypass Deal________________________________________</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.RadioButtonFor(model => model.HotelByPass, "HotelAllow")%>
                        Allow
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.RadioButtonFor(model => model.HotelByPass, "HotelDisallow")%>
                        Disallow
                        <%: Html.HiddenFor(model=>model.HotelSettingID) %>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>
    <hr />
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
