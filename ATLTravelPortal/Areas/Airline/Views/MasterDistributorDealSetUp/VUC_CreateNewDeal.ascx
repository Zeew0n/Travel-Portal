﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.MasterBranchDealviewModel>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Create", "MasterDistributorDealSetUp", FormMethod.Post, new { @class = "validate" }))
   {%>
<%: Html.ValidationSummary(true)%>

<div class="pageTitle">
    <ul class="buttons-panel">
        <li>
            <div id="loadingIndicator">
            </div>
        </li>
        <li>
            <%--<input type="submit" value="Save" />   --%>        
        </li>

    </ul>
    <h3>
        <label class="icon_plane">
            Setup</label>
        <span>&nbsp;</span><strong>Create New Deal</strong>
    </h3>
</div>

<%--<div class="row-1">
    <div class="form-box1 round-corner">
--%>
   <%-- <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.BranchOfficeId)%></label>
                     <%: Html.DropDownListFor(model => model.BranchOfficeId,Model.BranchOffices, new { @class = "required" })%>
                    <%: Html.ValidationMessageFor(model => model.BranchOfficeId, "*")%>
                </div>
            </div>
          
        </div>--%>


        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.DealName)%></label>
                  <%: Model.DistributorCode + "-"%>  <%: Html.TextBoxFor(model => model.DealName, new { @class = "required", @onkeypress = "return CheckDealName(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.DealName, "*")%>
                </div>
            </div>
          
        </div>
          <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.CopyDeal)%></label>
                    <%: Html.CheckBoxFor(model => model.CopyDeal)%>
                    <%: Html.ValidationMessageFor(model => model.CopyDeal, "*")%>
                </div>
            </div>
            
             <div class="form-box1-row-content float-left" id="MasterDealDiv">
                <div>
                    <label>
                        Deal</label>
                    <%: Html.DropDownListFor(model => model.DealMasterId, Model.DealMasterList)%>

                </div>
                </div>

                <div>
                <div class="buttonBar">
            <input type="submit" value="Save" />            
        </div>
        </div>
    </div>
  

<%} %>
<script type="text/javascript">
    function CheckDealName(e) {
        var key = e.which ? e.which : e.keyCode;
        //A-Z a-z and space key//              
        if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || key == 32 || (key >= 48 && key <= 57) || key == 13 || key == 9 || key == 27) {
            return true;
        }
        else {

            return false;
        }
    }
</script>
<script type="text/javascript">

    ///////////////////////////////////////////////////////////////////////////////////////////
    $(function () {
        var cb2 = $("#CopyDeal");
        cb2.change(toggle_cb2);
        toggle_cb2.call(cb2[0]);
    });
    function toggle_cb2() {
        if ($(this).is(":checked")) {
            $("#MasterDealDiv").show();
        } else {

            $("#MasterDealDiv").hide();
        }
    }
    ////////////////////////////////////////////////////////
    $(function () {
        var dates = $("#EffectiveFrom, #ExpireOn").datepicker({
            defaultDate: "+1d",
            changeMonth: true,
            changeYear: true,
            constrainInput: true,
            numberOfMonths: 2,
            disable: true,
            buttonImage: '../../Content/images/calendar.gif',
            showAnim: 'fold',

            onSelect: function (selectedDate) {
                var option = this.id == "EffectiveFrom" ? "minDate" : "maxDate",
                instance = $(this).data("datepicker");
                date = $.datepicker.parseDate(
                instance.settings.dateFormat ||
                $.datepicker._defaults.dateFormat,
                selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });
    });
</script>
