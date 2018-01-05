<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.OperatorBusCategoryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Bus Operator Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%using (Html.BeginForm())
      {%>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
           
        </ul>
     
            <ul class="buttons-panel">
                
                    <%Html.RenderPartial("Utility/VUC_Message", Model.Message); %>
  
                    <input type="submit" value="Save" />
              
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                
            </ul>
    
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create Bus Operator
                Category</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.BusMasterId)%>
                        <%: Html.DropDownListFor(model => model.BusMasterId,Model.ddlBusMasterList)%>
                        <%: Html.ValidationMessageFor(model => model.BusMasterId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.BusCategoryId)%>
                        <%: Html.DropDownListFor(model => model.BusCategoryId, Model.ddlBusCategorList)%>
                        <%: Html.ValidationMessageFor(model => model.BusCategoryId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                   <div style="text-align:left;font-weight:bold">
                        Facility 
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                    <div>
                        <%: Html.TextAreaFor(model => model.FacilityDetails, new { @style = "width: 640px; margi:-10px 0 0 0; height:250px; position:relative: top:10px" })%>
                        <%: Html.ValidationMessageFor(model => model.FacilityDetails)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                    <div style="text-align:left;font-weight:bold">
                        Fare Rules 
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                    <div>
                        <%: Html.TextAreaFor(model => model.FareRules, new { @style = "width: 640px; margi:-10px 0 0 0; height:250px; position:relative: top:10px" })%>
                        <%: Html.ValidationMessageFor(model => model.FareRules)%>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <%Html.RenderPartial("Utility/VUC_Message", Model.Message); %></li>
                <li>
                    <input type="submit" value="Save" />
                </li>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "OperatorBusCategory", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
        </div>--%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="<%:Url.Content("~/Areas/Bus/Scripts/jquery.nicEdit.js") %>" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var myEditorFacility;
        bkLib.onDomLoaded(function () {
            myEditorFacility = new nicEditor().panelInstance('FacilityDetails');
            myEditorFacility.addEvent('blur', function () {
                document.getElementById("FacilityDetails").value = myEditorFacility.instanceById('FacilityDetails').getContent();
            });
        });
        var myEditorFareRules;
        bkLib.onDomLoaded(function () {
            myEditorFareRules = new nicEditor().panelInstance('FareRules');
            myEditorFareRules.addEvent('blur', function () {
                document.getElementById("FareRules").value = myEditorFareRules.instanceById('FareRules').getContent();
            });
        });
    </script>
</asp:Content>
