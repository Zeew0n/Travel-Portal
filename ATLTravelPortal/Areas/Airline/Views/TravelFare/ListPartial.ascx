<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.TravelFareModel>" %>
<%--Starting of  Region determining All AirLine for particular AirLine Schedule --%>
<%if (Model.airlineTravelportalList != null)
  {
%>
<div class="box1">
    <%var q = (from p in Model.airlineTravelportalList select new { p.AirlineNmae }).Distinct().ToList(); %>
    <%--Starting of  Region determining All AirLine for particular AirLine Schedule--%>
    <% for (int i = 0; i < q.Count(); i++)
       {%>
    <%var k = (from l in Model.airlineTravelportalList where l.AirlineNmae == q.ToList()[i].AirlineNmae select l).OrderBy(x => x.DepartureCityName).ToList(); %>
   <fieldset class="style1">
    <legend><a id="displayUserinfo_<%:q.ToList()[i].AirlineNmae%>" href="javascript:toggle('<%:q.ToList()[i].AirlineNmae%>');">
                <% =k.ElementAtOrDefault(0).AirlineNmae%> &dArr;
        </a></legend>
    <div class="row2" style="margin-left:5px; margin-right:5px;">
        <div class="row3">
            <div class="col4">
                FlightClass Name</div>
            <div class="col4">
                DepartureCity Name</div>
            <div class="col4">
                DestinationCity Name</div>
            <div class="col4">
                OneWay Fare</div>
            <div class="col4">
                RoundWay Fare
            </div>
        </div>
        <div id="toggleUserinfo_<%:q.ToList()[i].AirlineNmae%>" style="display: none">
            <% for (int m = 0; m < k.Count(); m++)
               { %>
            <%--Starting of  Region determining AirLine for particular AirLine Schedule--%>
            <div class="search-details">
                <div class="heading-going">
                    <%-- <%:k[m].FromCity%> - <%:k[m].ToCity%>--%>
                </div>
                <div class="info">
                    <div class="row3">
                        <div class="col4">
                            <ul class="inline">
                                <li class="width"><strong>
                                    <%:k[m].FlightClassName%></strong></li>
                            </ul>
                        </div>
                        <div class="col4">
                            <ul class="inline">
                                <li class="width"><strong>
                                    <%:k[m].DepartureCityName%></strong></li>
                            </ul>
                        </div>
                        <div class="col4">
                            <ul class="inline">
                                <li class="width"><strong>
                                    <%:k[m].DestinationCityName%></strong></li>
                            </ul>
                        </div>
                        <div class="col1">
                            <ul class="inline">
                                <li class="width"><strong>
                                    <%: String.Format("{0:F}", k[m].OneWayFare)%></strong></li>
                            </ul>
                        </div>
                        <div class="col1">
                            <ul class="inline">
                                <li class="width"><strong>
                                    <%: String.Format("{0:F}", k[m].RoundWayFare)%></strong></li>
                            </ul>
                        </div>
                        <div class="col4">
                            <ul class="inline">
                                <li class="width">
                                    <%:Html.ActionLink(" ", "Details", new { id = k[m].PaperFareId, controller = "TravelFare" }, new { @title = "Details", @class = "details" })%>
                                </li>
                            </ul>
                        </div>
                        <div class="col4">
                            <ul class="inline">
                                <li class="width">
                                    <%:Html.ActionLink(" ", "Edit", new { id = k[m].PaperFareId, controller = "TravelFare" }, new { @title = "Edit", @class = "edit" })%>
                                    <%:Html.ActionLink(" ", "Delete", new { id = k[m].PaperFareId, controller = "TravelFare" }, new { @title = "Delete", @class = "delete", onclick = "return confirm('Are you sure you want to delete?')" })%>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <%--End of  Region determining deal AirLine for particular AirLine Schedule--%>
            <%}
            %>
        </div>
    </div>
    </fieldset><br />
    <%}
    %>
    <%--End of  Region determining All AirLine for particular AirLine Schedule--%>
</div>
<%} %>
<script type="text/javascript">
    function toggle(user_id) {
        e = document.getElementById('toggleUserinfo_' + user_id);
        a = document.getElementById('displayUserinfo_' + user_id);
        if (e.style.display == 'block') {
            e.style.display = 'none';

        }
        else {
            e.style.display = 'block';

        }
    }
            
</script>
