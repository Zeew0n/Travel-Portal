<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelOfflineBookModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
   <% using (Html.BeginForm("Detail", "HotelOfflineBook", FormMethod.Post, new { @id = "frm" }))
       {%>
    <div class="pageTitle">
    <%--  <div class="float-right" >
        <ul class="buttons-panel">
            <li>
                 <input type="submit" value="Issue Ticket" name="Issue" id="Issue" onclick="return confirm('Are
    you sure you want to Issue?')" class="float-left" />
            </li>
             <li>
             <input type="submit" value="Cancel Ticket" id="Cancel" name="Cancel" onclick="return confirm('Are you sure
    you want to Reject?')" />
            </li>
            <li>
                <%:Html.ActionLink("Back to list", "Index", new { controller = "HotelOfflineBook", area = "Hotel" }, new { @class = "linkButton linkButtonHtl" })%>
            </li>
          
        </ul>
    </div>--%>
        <h3>
            Hotel <span>&nbsp;</span> Offline Booking List
        </h3>

    </div>
   
    <%:Html.HiddenFor(model => model.BookingRecordId)%>
    <%:Html.Partial("Common/VUC_BookingDetail",Model.BookingDetail)%>

    <div class="clearboth"></div>

    <div class="row-1">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Booking Id") %>
                            </label>
                            <%: Html.TextBoxFor(model => model.GDSBookingId)%>
                        </div>
                    </div>
                </div>
                  <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Booking Reference#") %>
                            </label>
                            <%: Html.TextBoxFor(model => model.BookingReferenceNo)%>
                        </div>
                    </div>
                </div>
                 <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Booking Confirmation#") %>
                            </label>
                            <%: Html.TextBoxFor(model => model.BookingConformationNo)%>
                        </div>
                    </div>
                </div>
        </div>


    <div class="buttonBar" style="clear:both;">
        <ul class="buttons-panel">
            <li>
                 <input type="submit" value="Issue Ticket" name="Issue" id="Issue" onclick="return confirm('Are
    you sure you want to Issue?')" class="float-left" />
            </li>
             <li>
             <input type="submit" value="Cancel Ticket" id="Cancel" name="Cancel" onclick="return confirm('Are you sure
    you want to Reject?')" />
            </li>
            <li>
                <%:Html.ActionLink("Back to list", "Index", new { controller = "HotelOfflineBook", area = "Hotel" }, new { @class = "linkButton linkButtonHtl" })%>
            </li>
          
        </ul>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
