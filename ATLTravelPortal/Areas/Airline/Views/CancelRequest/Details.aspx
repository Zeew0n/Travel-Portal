<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.CancelRequestModel>" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Airline.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <%
        PNRsModel _modPNR = new PNRsModel();
        PNRSegmentsModel _modPNRSeg = new PNRSegmentsModel();
        PassengersModel _modPassenger = new PassengersModel();

        ATLTravelPortal.Areas.Airline.Repository.PNRDetailProvider _provider = new ATLTravelPortal.Areas.Airline.Repository.PNRDetailProvider();

        _modPNR = _provider.GetPNRDetail((int)Model.PNRId);
        _modPNRSeg.PNRSegmentsList = _provider.GetPNRSegmentList((int)Model.PNRId);
        _modPassenger.PassengersList = _provider.GetPassengersList((int)Model.PNRId);
     
    %>
    <%Html.RenderPartial("VUC_PNR", _modPNR); %>
    <%Html.RenderPartial("VUC_PNRSegment", _modPNRSeg); %>
    <%Html.RenderPartial("VUC_PNRPassenger", _modPassenger); %>


     <%using (Html.BeginForm())
        { %>
    <%=Html.ValidationSummary(true)%>
    <div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>Extra Charge</b></h2> </div>
    <div style=" border:1px solid #ccc; padding:5px;">
    <%-- <table>
  <tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.ArihantCancellationCharge)%> </th>
        <td><%: Html.TextBoxFor(model => model.ArihantCancellationCharge)%></td>
         <%: Html.ValidationMessageFor(model => model.ArihantCancellationCharge)%>
</tr>
</table>--%>


  <div class="borderBox">
        <div class="row-1">
        <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   
                     
                    </div></div>
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Cancellation Charge
                        </label>
                     
                    <%: Html.TextBoxFor(model => model.ArihantCancellationCharge)%>
                    <%: Html.ValidationMessageFor(model => model.ArihantCancellationCharge)%>
                    <%: Html.ValidationMessageFor(model => model.ArihantCancellationCharge)%>
                    </div>
                  
                </div>
                </div>


             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Remarks
                        </label>
                     
                         <%: Html.TextAreaFor(model => model.Remarks, new { @id = "Remarks", @rows = "2", @cols = "20", @Style = " width:168px; height:60px; font:11px Tahoma; padding:5px;" })%>
                         <%: Html.ValidationMessageFor(model => model.Remarks)%>
                    </div>
                  
                </div>
                <div class="clearboth"></div>
               
             <input type="submit" value="Approve Cancel" name="CancelledTicket" /> |
               <input type="submit" value="Reject Cancel" name="CancelledTicket" /> |
		    <%: Html.ActionLink("Back to List", "Index", new { @class = "linkButton" })%>
              
            </div>
            </div>
            </div>


</div>

     

    <%--  <p>
		    <input type="submit" value="Confirm" /> |
		    <%: Html.ActionLink("Back to List", "Index", new { @class = "linkButton" })%>
        </p>--%>
        <%} %>




           <%--   -----------------------------------------------  comment and remark region -----------------------------------------------------------------------%>
 
          <%--  <a href="javascript: void(0);" onclick="javascript: $('#pnrstatuscomment').slideToggle('normal');" style="font-size:14px; font-weight:bold; margin-top:2px;">Show Remark</a>
             <div class="borderBox" id="pnrstatuscomment" style="display:none;">
              <div style="overflow: hidden;">
        <%if (Model.CommentList != null)
          {
        %>
        <%foreach (var item in Model.CommentList)
          {
              var createdby = item.CreatedBy;
        %>
        <div style="width: 400px;">
         
                <span class="float-left" style="margin-right: 11px; margin-top: 4px;">
                    <img src="../../../../Content/images/icons/comment.png" /></span> <span style="color: #FF7902">
                        <%: item.CreatedName%>
                        On
                        <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.CreatedDate.ToString())%>:</span>
            <p style="border: 1px solid #eaeaea; padding: 5px; width: 400px; margin-bottom: 10px;
                margin-left: 43px;">
                <%:item.Remark%>
            </p>
        </div>
        <%} %>
        <%} %>
       
    </div>
             </div>--%>
         <%-----------------------------------------------End  comment and remark region -----------------------------------------------------------------------%>




</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/global.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/buttons.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        th, td
        {
            text-align: left;
            vertical-align: top;
        }
        .pageTitle span {
    height: auto;
    width: auto;
     background:none;
  
    </style>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

