<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelFacilities>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="contentGrid" id="result">
    <h2>Details</h2>

 <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           Facility Name:</label>
                        <%: Model.FacilityName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Details:</label>
                        <%: Model.Details%>
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
          </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
