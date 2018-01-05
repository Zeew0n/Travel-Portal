<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotoCategories>" %>

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
                            Category Name
                        </label>
                        <%: Model.CategoryName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Details
                        </label>
                        <%: Model.Details %>
                    </div>
                </div>
            </div>
           
              <div class="form-box1-row-content float-left">
              <div>
                        <label>
                            HotelName
                        </label>
                        <%: Model.HotelName %>
                        
                    </div>
              </div>
                   
               <div class="form-box1-row-content float-left">
                <div>
                        <label>
                            isActive
                        </label>
                        <%: Model.isActive %>
               </div>
               </div> 
             </div>
        </div>
    </div>
    
    <%--<h2>Detail</h2>

      
<fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">CategoryName:</div>
        <div class="display-field"><%: Model.CategoryName %></div>
        
        <div class="display-label">Details:</div>
        <div class="display-field"><%: Model.Details %></div>
        
        <div class="display-label">Active:</div>
        <div class="display-field"><%: Model.isActive %></div>
        
        <div class="display-label">HotelName:</div>
        <div class="display-field"><%: Model.HotelId%></div>
        
    </fieldset>
--%>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
