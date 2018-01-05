<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineCityModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="pageTitle">
        <div class="float-right">
           
            <%:Html.ActionLink("Cancel", "Index", new { controller = "AirLineCity" }, new { @class = "linkButton" })%>
        </div>
        <h3>
            <a class="icon_plane" href="#">Setup </a> <span>&nbsp;</span><strong> Airport Information</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            City Code:</label>
                        <%: Model.CityCode%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            City Name:</label>
                        <%:Model.CityName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Country:</label>
                            <%if (Model.CountryName!= null)
                              {%>
                            <%:Model.CountryName %>
                            <%} %>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
