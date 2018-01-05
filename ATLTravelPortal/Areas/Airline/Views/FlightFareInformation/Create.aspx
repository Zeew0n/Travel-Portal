<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.FlightFareInformationModel>" %>
    <%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm("Create", "FlightFareInformation", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
       { %>
 


     <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
            </li>
        </ul>
       <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li></li>
        </ul>
         <div class="float-right">
        <input type="submit" value="New" />
    </div>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Flight Fare Information</strong>
        </h3>
    </div>
    </div>


   
    <div class="form-box1 round-corner">
    <fieldset class="style1">
        <legend>Flight Info</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <div>
                    <label>
                       <%: Html.LabelFor(model => model.DepartCity)%></label>
                   <%-- <%: Html.DropDownListFor(model => model.DepartCityId, Model.DepartCityList, "---Select---")%>
                    <%: Html.HiddenFor(model => model.hdfDepartCityId) %>--%>
                    <% List<SelectListItem> DepartCityList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = true, Value = "KTM", Text = "KTM"},
                                        new SelectListItem {Selected = false, Value = "BOM", Text = "BOM"},
                                       
                                         
                                    };%>
                    <%:Html.DropDownListFor(model => model.DepartCity, DepartCityList, new { @style = "width:75px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.ArriveCity)%></label>
                 <%--  <%: Html.DropDownListFor(model => model.ArriveCityId, Model.ArriveCityList,"---Select---")%>
                    <%: Html.HiddenFor(model => model.hdfArriveCityId)%>--%>
                      <% List<SelectListItem> ArriveCityList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = true, Value = "DOH", Text = "DOH"},
                                        new SelectListItem {Selected = false, Value = "SHJ", Text = "SHJ"},
                                       
                                         
                                    };%>
                    <%:Html.DropDownListFor(model => model.ArriveCity, ArriveCityList, new { @style = "width:75px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.DepartureDate) %>(mm/dd/yyyy) eg. (04/20/2012)
                    </label>
                    <%:Html.TextAreaFor(model => model.DepartureDate, new { @Style = " width:168px; height:60px; font:11px Tahoma; padding:5px;" })%>
                    <span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model=>model.DepartureDate) %>
                </div>
            </div>
        </div>
      
</fieldset>
<br />
<fieldset class="style1">
        <legend>Task Detail</legend>

        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.TaskBeginDate) %>
                    </label>
                
                   <%: Html.TextBox("TaskBeginDate", (Model != null && Model.TaskBeginDate != null && Model.TaskBeginDate != DateTime.MinValue) ?
                                                  (TimeFormat.DateFormat(Model.TaskBeginDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                             <span class="redtxt">*</span>
                             <%: Html.ValidationMessageFor(model=>model.TaskBeginDate) %>
                  
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:550px;">
                <div>
                    <label>
                        Time</label>

                     <%:Html.TextBoxFor(model => model.Duration, new { @class = "callDuration" })%> <span class="redtxt">*</span>
                     <%: Html.ValidationMessageFor(model=>model.Duration) %>
                       <i>(Hr:Min)</i>
            
                    <%: Html.RadioButtonFor(model => Model.rdbAmPm, "AM", new { @checked = "checked" })%>
                    AM
               
                    <%: Html.RadioButtonFor(model => Model.rdbAmPm, "PM")%>
                    PM
                  
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.EmailReceivers) %>
                    </label>
                    <%:Html.TextAreaFor(model => model.EmailReceivers, new { @Style = " width:168px; height:60px; font:11px Tahoma; padding:5px;" })%>
                    <span class="redtxt">*</span>
                    <%:Html.ValidationMessageFor(x=>x.EmailReceivers) %>
                </div>
            </div>
        </div>
       
       </fieldset>

    </div>
   <%-- <div class="buttonBar">
        <input type="submit" value="Create Task" />
    </div>--%>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    

    <script language="javascript" type="text/javascript">





        $(function () {
            var dates = $("#TaskBeginDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                minDate:new Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "TaskBeginDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });


        $(".callDuration").live('click', function () {
            $(".callDuration").mask("99:99", { placeholder: "0" });
        });

    </script>
</asp:Content>
