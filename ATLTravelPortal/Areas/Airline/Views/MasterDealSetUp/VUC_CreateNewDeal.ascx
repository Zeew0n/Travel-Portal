<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.MasterDealviewModel>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Create", "MasterDealSetUp", FormMethod.Post, new { @class = "validate" }))
   {%>
<%: Html.ValidationSummary(true)%>

<div class="pageTitle">
    <ul class="buttons-panel">
        <li>
            <div id="loadingIndicator">
            </div>
        </li>
        <li>
            <input type="submit" value="Save" />           
        </li>
    </ul>
    <h3>
        <label class="icon_plane">
            Setup</label>
        <span>&nbsp;</span><strong>Create New Deal</strong>
    </h3>
</div>

<div class="row-1">
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.DealName)%></label>
                    <%: Html.TextBoxFor(model => model.DealName, new { @class = "required" })%>
                    <%: Html.ValidationMessageFor(model => model.DealName, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.DealTypeId)%></label>
                    <%: Html.DropDownListFor(model => model.DealTypeId, Model.DealTypeList, "--- Select---")%>
                    <%: Html.ValidationMessageFor(model => model.DealTypeId, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.EffectiveFrom)%></label>
                    <%: Html.TextBoxFor(model => model.EffectiveFrom, new { Class="showDatePicker"})%>
                    <%: Html.ValidationMessageFor(model => model.EffectiveFrom, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.ExpireOn)%></label>
                    <%: Html.TextBoxFor(model => model.ExpireOn, new { Class = "showDatePicker" })%>
                    <%: Html.ValidationMessageFor(model => model.ExpireOn, "*")%>
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
        </div>
     <%--   <div class="buttonBar">
            <input type="submit" value="Save" />            
        </div>--%>
    </div>
</div>
<%} %>
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
