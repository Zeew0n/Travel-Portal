<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.GroupBookingReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box3">
        <div class="buttons-panel">
            <div class="float-right">
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/GroupBookingReport/'" />
            </div>
        </div>
        <div class="userinfo">
            <h3>
                Group Booking Report</h3>
        </div>
    </div>
    <% using (Html.BeginForm("Create", "GroupBookingReport", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <fieldset class="style1">
        <%-- <div>Group Quote Details</h1></div>--%>
        <legend>Group Quote Details</legend>
        <div class="row-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Group Name:</label>
                            <%: Model.GroupName %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                Company Name:</label>
                            <%:Model.CompanyName%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Contact Name:</label>
                            <%:Model.ContactName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                Mobile No.:</label>
                            <%:Model.MobilePhone%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Phone No.:</label>
                            <%:Model.ContactPhone%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                Address1:</label>
                            <%:Model.AddressLine1%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Address2:</label>
                            <%:Model.AddressLine2%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                City</label>
                            <%:Model.SuburbTownCity%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Post Code:</label>
                            <%:Model.PostCode%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                State Name:</label>
                            <%:Model.State%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Country:</label>
                            <%:Model.CountryName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                Group Type:</label>
                            <%:Model.GroupTypeName%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                Excess Baggage Request:</label>
                            <%:Model.isExcessBaggage%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Comment:</label>
                            <%:Model.Comments%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </fieldset>
    <br />
    <fieldset class="style1">
        <legend>Itinerary Details</legend>
        <div class="contentGrid" width="98%" style="margin: 1% 1% 0;">
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" id="myTable">
                <thead>
                    <th>
                        From
                    </th>
                    <th>
                        To
                    </th>
                    <th>
                        Departure Date
                    </th>
                    <th>
                        Adults
                    </th>
                    <th>
                        Children
                    </th>
                    <th>
                        Infants
                    </th>
                    <th>
                        Cabin Class
                    </th>
                </thead>
                <tbody>
                    <% foreach (var item in Model.GroupBookingList)
                       { %>
                    <tr>
                        <td>
                            <%: item.FromCityName%>
                        </td>
                        <td>
                            <%:item.ToCityName%>
                        </td>
                        <td>
                            <%: TimeFormat.DateFormat(item.DepartDate.ToString())%>
                        </td>
                        <td>
                            <%:item.AdultsId%>
                        </td>
                        <td>
                            <%:item.ChildrenId%>
                        </td>
                        <td>
                            <%:item.InfantsId%>
                        </td>
                        <td>
                            <%:item.CabinClass%>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </fieldset>
    <%} %>
    <br />
    <fieldset class="style1">
        <%
            if (TempData["CommentCannotBeDeleted"] != null)
            { %>
        <%: TempData["CommentCannotBeDeleted"]%>
        <%
    
        }
        %>
        <legend>Group Booking Comment Section </legend>
        <% using (Html.BeginForm("Create", "GroupBookingReport", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
           {%>
        <div class="divLeft" style="margin-left: 10px;">
            <%: Html.LabelFor(model => model.StatusId)%>
            <%:Html.DropDownListFor(model => model.StatusId, (SelectList)ViewData["GroupBookingStatus"])%>
        </div>
        <br />
        <br />
        <div style="padding: 10px;">
            <%if (Model.GroupBookingCommtList != null)
              {
          
            %>
            <%foreach (var item in Model.GroupBookingCommtList)
              {
                  var groupbookingid = item.GroupBookingId;
                  var commentid = item.groupbookingcommentid;
            %>
            <div style="width: 400px;">
                <%int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId(); %>
                <%if (LogedUserId == item.CreatedBy)
                  { %>
                <span class="float-left" style="margin-right: 11px; margin-top: 4px;">
                    <img src="../../../../Content/Icons/comment.png" /></span>
                <p style="margin-left: 43px; width: 400px; color: #FF7902;">
                    <span class="float-right">
                        <%--  <a href="/Airline/GroupBookingReport/Delete?groupbookingid=<%:item.GroupBookingId %>&commentid=<%:item.groupbookingcommentid %>" class="delete title="Delete"
                            onclick="return confirm('Are you sure you want to delete the comment?')"></a>--%>
                        <%:Html.ActionLink(" ", "Delete", new { groupbookingid = groupbookingid, commentid = commentid }
         , new { @class = "delete", @onclick = "return confirm('Are you sure you want to delete the comment?')" })%>
                    </span>
                    <%} %>
                    <%: item.CreatedName %>
                    On
                    <%: TimeFormat.DateFormat(item.CreatedDate.ToString()) %>:
                </p>
                <p style="border: 1px solid #eaeaea; padding: 5px; width: 400px; margin-bottom: 10px;
                    margin-left: 43px;">
                    <%:item.PostComment%>
                </p>
            </div>
            <%} %>
            <%} %>
            <div class="divLeft">
                <%: Html.TextAreaFor(model => model.PostComment, new { @Style = " width:400px; margin-left:43px; padding:5px;" })%>
            </div>
            <div class="divLeft" style="margin-left: 43px;">
                <input type="submit" value="Submit" class="btn3" />
                <%:Html.HiddenFor(mm => mm.GroupBookingId)%>
            </div>
            <%} %>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
