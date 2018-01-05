<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageCustomizeInquiryModel>" %>
   <%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineSchedule/Index'" />--%>
                
 <div class="pageTitle">
    <ul class="buttons-panel">
        <li><div id="loadingIndicator"></div></li>
        <li></li>
    </ul>
     <div class="float-right">
        <input type="button" onclick="document.location.href='/Airline/AirPackageCustomizeInquiry/Index'" value="Cancel" />
    </div>
    <h3><a href="#" class="icon_plane">Package</a> <span>&nbsp;</span><strong>Customize Package Inquiry Detail</strong></h3>
</div>

<div class="form-box1 round-corner">
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
             
       

        <div><label>Travel Start Date: </label><%: TimeFormat.DateFormat( Model.TravelDateStart.ToString()) %></div>        
        <div><label>Travel End Date: </label><%: TimeFormat.DateFormat( Model.TravelDateEnd.ToString()) %></div>
        
        <div><label>Name: </label><%: Model.Name %></div>
        
        <div><label>Email Address: </label><%: Model.EmailAddress %></div>
        
        <div><label>No. of Adult: </label><%: Model.NoOfAdult %></div>
        
        <div><label>No. of Child: </label><%: Model.NoOfChild %></div>
        
        <div><label>Contact No: </label><%: Model.ContactNo %></div>
        
        <div><label>Remark: </label><%: Model.Remark %></div>
        
      
      
      </div>
    </div>
</div> 

<%--<div>
<input type="Submit" name="bttnSubmit" value="Reply" />
</div>--%>
    
     <%-- <div class="buttonBar">
        <input type="button" onclick="document.location.href='/Airline/AirPackageCustomizeInquiry/Index'" value="Cancel" />
    </div>--%>

</asp:Content>

