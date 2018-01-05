<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelAdditionalCharge>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="contentGrid" id="result">
   <h2>
        Details</h2>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            ChargeName:</label>
                        <%: Model.ChargeName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Rate:</label>
                        <%: Model.Rate%>
                    </div>
                </div>
            </div>
           <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Details:</label>
                        <%: Model.Detail%>
                    </div>
                </div>
            </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Active:</label>
                        <%: Model.isActive %>
                    </div>
                </div>
           
        </div>
    </div>
<%--
   <h2>HotelAdditionalChargeDetail</h2>

    <fieldset>
        <div class="display-label">
            ChargeName:</div>
        <div class="display-field">
            <%: Model.ChargeName %></div>
        <div class="display-label">
            Rate:</div>
        <div class="display-field">
            <%: Model.Rate%></div>
        <div class="display-label">
            Active:</div>
        <div class="display-field">
            <%: Model.isActive %></div>
    </fieldset>--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
