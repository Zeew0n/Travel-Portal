<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookInputModel>" %>
  <%@ Import Namespace="ATLTravelPortal.Helpers" %>
    <% using (Html.BeginForm("Index", "IndianLccAirOfflineBook", FormMethod.Post, new { @class = "validate" }))%>
    <% { %>
 <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            From Date</label>
                         <%--  <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>--%>
                            <%: Html.TextBoxFor(model=>model.FromDate) %>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%--<label>To Date</label>
                          <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Now.AddDays(1).ToString()))))%>--%>
                             <%: Html.TextBoxFor(model => model.ToDate)%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
       
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <%} %>
