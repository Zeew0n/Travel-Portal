<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.TravelFareModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
            <input type="button" value="Create" onclick="document.location.href='/Airline/TravelFare/Create'" />
            </li>
            <li>
                <input type="button" value="Edit" onclick="document.location.href='/Airline/TravelFare/Edit/<%:Model.PaperFareId%>'" /></li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/TravelFare/Index'" />
            </li>
        </ul>
        <h3>
            Setup<span>&nbsp;</span><strong>Domestic Paper Fare</strong>
        </h3>
    </div>
    <div class="row-1">
        <%=Html.HiddenFor(model => Model.PaperFareId)%>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline:</label>
                        <%: Model.AirlineNmae %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Flight Season</label>
                        <%: Model.FlightSeasonName %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Departure City:</label>
                        <%: String.Format("{0:F}", Model.DepartureCityName) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Destination City:</label>
                        <%: String.Format("{0:F}", Model.DestinationCityName) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Flight Class:</label>
                        <%: String.Format("{0:F}", Model.FlightClassName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Flight Type:</label>
                        <%: String.Format("{0:F}", Model.FlightTypes)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            One-way Fare:</label>
                        <%: String.Format("{0:F}", Model.OneWayFare)%>
                    </div>
                    <%--<div><label>One-way Fare Basis:</label>
                                    <%: String.Format("{0:F}", Model.OneWayFareBasis)%>
                                </div> --%>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            One-way Fare in $:</label>
                        <%: String.Format("{0:F}", Model.OneWayFareUSD)%>
                    </div>
                </div>
                <%--<div class="form-box1-row-content float-right">
                    
                </div>--%>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Fuel Charge:</label>
                        <%: String.Format("{0:F}", Model.FuelCharge)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Going Fare:</label>
                        <%: String.Format("{0:F}", Model.GoingFare)%>
                    </div>
                    <%--<div><label>Round-trip Fare Basis:</label>
                                    <%: String.Format("{0:F}", Model.RoundWayFareBasis)%>
                                </div>  --%>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Return Fare:</label>
                        <%: String.Format("{0:F}", Model.RoundWayFare)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Going Fare in $:</label>
                        <%: String.Format("{0:F}", Model.RoundWayGoingUSD)%>
                    </div>
                    <%--<div><label>Round-trip Fare Basis:</label>
                                    <%: String.Format("{0:F}", Model.RoundWayFareBasis)%>
                                </div>  --%>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Return Fare in $:</label>
                        <%: String.Format("{0:F}", Model.RoundWayReturnUSD)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Total RoundWay Fare:</label>
                        <%: String.Format("{0:F}", Model.TotalRoundTripFare)%>
                    </div>
                    <%--<div><label>Round-trip Fare Basis:</label>
                                    <%: String.Format("{0:F}", Model.RoundWayFareBasis)%>
                                </div>  --%>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Total RoundWay Fare in $:
                        </label>
                        <%: String.Format("{0:F}", Model.RoundWayFareUSD)%>
                        <%--<label>
                            Currencies:</label>
                        <%:Model.CurrencyName %>--%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Effective From:</label>
                        <%--  <%: String.Format("{0:g}", Model.EffectiveFrom) %>--%>
                        <%: Model.EffectiveFrom.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"].ToString())%>
                    </div>
                </div>
                <%DateTime d = Convert.ToDateTime(Model.ExpireOn);%>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Expire On:</label>
                        <%--<%: String.Format("{0:g}", Model.ExpireOn) %>--%>
                        <%--<%: Model.ExpireOn.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"].ToString())%>--%>
                        <%:d.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"].ToString()) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Child Fare:</label>
                        <%: String.Format("{0:F}", Model.ChildFare)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Child Fare Type:</label>
                        <%: String.Format("{0:F}", Model.ChildFareType)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Infant Fare:</label>
                        <%: String.Format("{0:F}", Model.InfantFare)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Infant Fare Type:</label>
                        <%: String.Format("{0:F}", Model.InfantFareType)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Refund Fee:</label>
                        <%: String.Format("{0:F}", Model.RefundFee)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Reissue Fee:</label>
                        <%: String.Format("{0:g}", Model.ReissueFee) %>
                    </div>
                </div>
            </div>
            <%--<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                        
                                 <div><label>Fuel Charge:</label>
                                       <%: String.Format("{0:F}", Model.FuelCharge)%>
                                </div>                      
                        </div>--%>
            <%-- <div class="form-box1-row-content float-right">                        
                                 <div><label>Reissue Fee:</label>
                                        <%: String.Format("{0:g}", Model.ReissueFee) %>
                                       
                                </div>                    
                        </div>--%>
            <%--</div>--%>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Tour Code</label>
                        <%: String.Format("{0:F}", Model.TourCode) %>
                    </div>
                    <%--<div><label>Currencies:</label>
                                       <%: String.Format("{0:F}", Model.CurrencyName)%>
                                </div>   --%>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Valid till further notice</label>
                        <%:Model.ValidTillFurtherNotice %>
                    </div>
                </div>
            </div>
        </div>
        <div class="buttonBar">
            <input type="button" value="Create" onclick="document.location.href='/TravelFare/Create'" />
            <input type="button" value="Edit" onclick="document.location.href='/TravelFare/Edit/<%:Model.PaperFareId%>'" />
            <input type="button" onclick="document.location.href='/TravelFare/Index'" value="Cancel" />
        </div>
    </div>
    <p>
        <%--<input type="button" value="Edit" class="btn1" /> --%>
        <%-- <%:Html.ActionLink("Cancel",
    "Index", new { controller = "TravelFare" }, new {@class="cancel" })%>--%>
        <%--<input
    type="button" class="btn1" onclick="document.location.href='/AdminAirlineSalesCommissions/'"
    value="Back to List"/>--%>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
