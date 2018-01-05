<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelTypeInfos>" %>

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
                            Hotel Type:</label>
                        <%: Model.HotelTypeName  %>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Code:</label>
                        <%: Model.Description %>
                    </div>
                </div>
   
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Is Active:</label>
                        <%: Model.isActive %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<fieldset>
        <div class="display-label">
            Hotel Type</div>
        <div class="display-field">
            <%: Model.HotelTypeName  %></div>
        <div class="display-label">
            Description</div>
        <div class="display-field">
            <%: Model.Description %></div>
        <div class="display-label">
            Active</div>
        <div class="display-field">
            <%: Model.isActive %></div>        
    </fieldset>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
