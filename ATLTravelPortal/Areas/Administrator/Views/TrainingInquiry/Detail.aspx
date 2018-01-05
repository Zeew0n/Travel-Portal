<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.TrainingInquiryModel>" %>

   <%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineSchedule/Index'" />--%>
                
 <div class="pageTitle">
  <div class="float-right">
        <input type="button" onclick="document.location.href='/Administrator/TrainingInquiry/Index'" value="Cancel" />
    </div>
    <ul class="buttons-panel">
        <li><div id="loadingIndicator"></div></li>
        <li></li>
    </ul>
   <a href="#">Inquiry</a> <span>&nbsp;</span><strong>Training</strong><span>&nbsp;</span><strong>Detail</strong>
</div>

<div class="form-box1 round-corner">
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">

        <div><label>Name: </label><%: Model.FullName %></div>

        <div><label>ContactNo: </label><%: Model.ContactNo%></div>

        <div><label>Email Address: </label><%: Model.EmailAddress %></div>
        
        <div><label>CompanyName: </label><%: Model.CompanyName%></div>
        
        <div><label>ObjectiveOfTraning: </label><%: Model.ObjectiveOfTraning%></div>
        
        <div><label>PreferredDay No: </label><%: Model.PreferredDay%></div>
        
        <div><label>Remark: </label><%: Model.Remarks%></div>
        
      
      
      </div>
    </div>
</div> 

<%--<div>
<input type="Submit" name="bttnSubmit" value="Reply" />
</div>--%>
    
     <%-- <div class="buttonBar">
        <input type="button" onclick="document.location.href='/Administrator/TrainingInquiry/Index'" value="Cancel" />
    </div>--%>

</asp:Content>

