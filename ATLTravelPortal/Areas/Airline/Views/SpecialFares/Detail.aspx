<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SpecialFaresModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li></li>
        </ul>
         <div class="float-right">
        <input type="button" onclick="document.location.href='/Airline/SpecialFares/Index'"
            value="Cancel" />
    </div>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Special Fare</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        From City:
                    </label>
                    <%: Model.FromCityName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        To City:
                    </label>
                    <%: Model.ToCityName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Airline Name:
                    </label>
                    <%: Model.AirlineName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Regular Fare:
                    </label>
                    <%: Model.RegularFare %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Special Fare:
                    </label>
                    <%: Model.SpecialFare %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Effective From:
                    </label>
                    <%: TimeFormat.DateFormat( Model.EffectiveFrom.ToString()) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Expire On:
                    </label>
                    <%:TimeFormat.DateFormat( Model.ExpireOn.ToString()) %>
                </div>
            </div>
        </div>
    </div>
   <%-- <div class="buttonBar">
        <input type="button" onclick="document.location.href='/Airline/SpecialFares/Index'"
            value="Cancel" />
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
