<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<TravelPortalEntity.Airlines>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="pageTitle">
        <div class="float-right">
           
            <%:Html.ActionLink("Cancel", "Index", new { controller = "Airline" }, new { @class = "linkButton" })%>
        </div>
        <h3>
            <a class="icon_plane" href="#">Setup </a> <span>&nbsp;</span><strong> Airline Information</strong>
        </h3>
    </div>
     <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline Code:</label>
                        <%: Model.AirlineCode%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline Name:</label>
                        <%:Model.AirlineName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Country:</label>
                            <%if (Model.Countries!= null)
                              { %>
                        <%:Model.Countries.CountryName%>
                        <%}%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
