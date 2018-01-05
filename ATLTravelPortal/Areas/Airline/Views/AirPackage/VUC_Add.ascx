<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.AirPackageModel>" %>

  
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <input type="submit" value="<%: Model.formSubmitBttnName %>" class="save" /></li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="<%: Model.formCancelOnClick %>" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create Package</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left" style="width: 90%;">
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.PackageGroupId) %>
                        <%: Html.DropDownListFor(model => model.PackageGroupId, Model.ddlPackageGroupName, "--Select--")%>
                        <%: Html.ValidationMessageFor(model => model.PackageGroupId)%>
                    </div>
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.CountryId) %>
                        <%: Html.DropDownListFor(model => model.CountryId, Model.ddlCountryList, new { @onchange = "JqueryAjaxLoadSelectOption(this.value,'CityId','/AirLine/AjaxRequest/GetCoreCityOptions/')" })%>
                        <%: Html.ValidationMessageFor(model => model.CountryId)%>
                    </div>
                     <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.ZoneId) %>
                        <%: Html.DropDownListFor(model => model.ZoneId, Model.ddlZoneList,"Select")%>
                        <%: Html.ValidationMessageFor(model => model.ZoneId)%>
                    </div>
                    
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.Name) %>
                        <%: Html.TextBoxFor(model => model.Name)%>
                        <%: Html.ValidationMessageFor(model => model.Name)%>
                    </div>
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.PackageCode)%>
                        <%: Html.TextBoxFor(model => model.PackageCode)%>
                        <%: Html.ValidationMessageFor(model => model.PackageCode)%>
                    </div>
                    
                </div>
                 <div class="form-box1-row-content float-left" style="width: 90%;">
                     <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.URL)%>
                        <%: Html.TextBoxFor(model => model.URL, new { @style = "width :550px;" } )%>
                        <%: Html.ValidationMessageFor(model => model.URL)%>
                     </div>
                 <%--   <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.Tags)%>
                         <div class="acFieldContainer ui-helper-clearfix"><%: Html.TextBoxFor(model => model.Tags, new { @style = "width :50px; border:0px;" })%></div>
                        <%: Html.ValidationMessageFor(model => model.Tags)%>
                    </div>
                    --%>
                    <div>
                        <%: Html.LabelFor(model => model.PackageSummary)%>
                        <%: Html.TextAreaFor(model => model.PackageSummary, new { @style = "width :550px;" })%>
                        <%: Html.ValidationMessageFor(model => model.PackageSummary)%>
                    </div>
                    <%
                        double? totalstartingPrice = Model.StartingPrice + Convert.ToDouble( Model.B2BMarkUp);
                         %>
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.StartingPrice)%>
                       <%-- <%: Html.TextBoxFor(model => model.StartingPrice)%>--%>
                       <%: Html.TextBox("StartingPrice", totalstartingPrice)%>
                        <%: Html.ValidationMessageFor(model => model.StartingPrice)%>
                    </div>
                   <%-- <div>
                          <%: Html.LabelFor(model=>model.StartingNPR) %>
                          <%: Html.TextBoxFor(model=>model.StartingNPR,null) %>
                          <%: Html.ValidationMessageFor(model=>model.StartingNPR) %>
                    </div>--%>
                    <div style=" padding-bottom:4px">
                          <%: Html.LabelFor(model=>model.StartingINR) %>
                          <%: Html.TextBoxFor(model => model.StartingINR)%>
                         
                          
                    </div>
                    <div style=" padding-bottom:4px">
                          <%: Html.LabelFor(model=>model.StartingUSD) %>
                          <%: Html.TextBoxFor(model => model.StartingUSD)%>
                         
                    </div>
                  
                     <div>
                        <%: Html.LabelFor(model => model.Duration)%>
                        <%: Html.TextBoxFor(model => model.Duration)%>
                        <%: Html.ValidationMessageFor(model=>model.Duration) %>
                    </div>

                 </div>
                  <div style="width: 90%;">  
                     <div>
                        <%: Html.LabelFor(model => model.Itineary)%>
                        <%: Html.TextAreaFor(model => model.Itineary, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.Itineary)%>
                    </div>

                     <div>
                        <%: Html.LabelFor(model => model.InclusiveAndExclusive)%>
                        <%: Html.TextAreaFor(model => model.InclusiveAndExclusive, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.InclusiveAndExclusive)%>
                    </div>

                    <div>
                        <%: Html.LabelFor(model => model.Overview)%>
                        <%: Html.TextAreaFor(model => model.Overview, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.Overview)%>
                    </div>

                    <div>
                        <%: Html.LabelFor(model => model.Rate)%>
                        <%: Html.TextAreaFor(model => model.Rate, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.Rate)%>
                    </div>
                   
                   
                    <div>
                        <%: Html.LabelFor(model => model.TermAndConditions)%>
                        <%: Html.TextAreaFor(model => model.TermAndConditions, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.TermAndConditions)%>
                    </div>                    
                   
                    
                               
                </div>
              <%--   <div class="form-box1-row-content float-left" style="width: 90%;">
                    <div>
                        <%: Html.LabelFor(model => model.IsB2BPackage)%>
                        <%: Html.CheckBoxFor(model => model.IsB2BPackage)%>
                        <%: Html.ValidationMessageFor(model => model.IsB2BPackage)%>
                    </div>
                     <div>
                        <%: Html.LabelFor(model => model.B2BMarkUp)%>
                        <%: Html.TextBoxFor(model => model.B2BMarkUp)%>
                        <%: Html.ValidationMessageFor(model => model.B2BMarkUp)%>
                    </div>

                    <div>
                        <%: Html.LabelFor(model => model.IsB2CPackage)%>
                        <%: Html.CheckBoxFor(model => model.IsB2CPackage)%>
                        <%: Html.ValidationMessageFor(model => model.IsB2CPackage)%>
                    </div>
                 <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.B2CMarkup)%>
                        <%: Html.TextBoxFor(model => model.B2CMarkup)%>
                        <%: Html.ValidationMessageFor(model => model.B2CMarkup)%>
                    </div>
                   
                    <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.EffectiveFrom)%>
                        <%: Html.TextBoxFor(model => model.EffectiveFrom)%>
                        <%: Html.ValidationMessageFor(model => model.EffectiveFrom)%>
                    </div>
                    <%--div>
                     <%: Html.LabelFor(model => model.EffectiveFrom)%>
                      <%: Html.TextBox("EffectiveFrom", (Model != null && Model.EffectiveFrom != null && Model.EffectiveFrom != DateTime.MinValue) ?
                                                                                (ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.EffectiveFrom.ToString())) :
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(ATLTravelPortal.Helpers.TimeFormat.DateFormat(DateTime.Now.ToString()))))%>
                <%: Html.ValidationMessageFor(model => model.EffectiveFrom, "*")%>
                 </div>--%>
                  <%--  <div style=" padding-bottom:4px">
                        <%: Html.LabelFor(model => model.ExpireOn)%>
                        <%: Html.TextBoxFor(model => model.ExpireOn)%>
                        <%: Html.ValidationMessageFor(model => model.ExpireOn)%>
                    </div>--%>
                    <%-- <div>
                     <%: Html.LabelFor(model => model.ExpireOn)%>
                      <%: Html.TextBox("EffectiveFrom", (Model != null && Model.EffectiveFrom != null && Model.EffectiveFrom != DateTime.MinValue) ?
                                                                                (ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.EffectiveFrom.ToString())) :
                            (ATLTravelPortal.Helpers.TimeFormat.DateFormat(ATLTravelPortal.Helpers.TimeFormat.DateFormat(DateTime.Now.ToString()))))%>
                <%: Html.ValidationMessageFor(model => model.EffectiveFrom, "*")%>
                 </div>--%>
                    
                
                    <div>
                        <%: Html.LabelFor(model => model.IsPublish)%>
                        <%: Html.CheckBoxFor(model => model.IsPublish)%>
                        <%: Html.ValidationMessageFor(model => model.IsPublish)%>
                    </div>  
                    </div>
                <div class="form-box1-row-content float-left">
                </div>
            </div>
        </div>
    </div>
    <div align="left" class="buttonBar" >
     <input type="submit" value="<%: Model.formSubmitBttnName %>" class="save" />
      </div>
   
<link href="/Content/autocomplete.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/json.cycle.js" type="text/javascript"></script>
<script src="/Scripts/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("input[id='Name']").keyup(function () {
            var valTitle = $(this).val();
            var valURL = valTitle.split(' ').join('-').toLowerCase();
            $("input[id='URL']").val(valURL);
        });
    });
</script>
<script type="text/javascript">
//    $(document).ready(function () {
//        $(function () {
//            var currentTime = new Date();           
//            var month = currentTime.getMonth()+1;
//            var day = currentTime.getDate();
//            var year = currentTime.getFullYear();
//            var d = month + "/" + day + "/" + year;
//            $('#EffectiveFrom').datepicker({ dateFormat: 'mm/dd/yy', numberOfMonths: 2, showOn: 'button', buttonImage: '/Content/Icons/calendar.png', buttonImageOnly: false }).val(d);
//            var c = month + "/" + (day + 1) + "/" + year;
//            $('#ExpireOn').datepicker({ dateFormat: 'mm/dd/yy', numberOfMonths: 2, showOn: 'button', buttonImage: '/Content/Icons/calendar.png', buttonImageOnly: false }).val(c);
//        });
    //    });
    $(document).ready(function () {
        $(function () {
            var dates = $("#EffectiveFrom, #ExpireOn").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
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
    });
        function JqueryAjaxLoadSelectOption(selValue, targetElm, url) {  
            $.ajax({
                async: false,
                type: "POST",
                url: url + selValue,
                contentType: "text/json",
                data: ({ id: selValue }),
                beforeSend: function () {
                    $("#" + targetElm).attr('disabled', 'disabled');
                    $("#" + targetElm).addClass('ac_loading');
                },

                success: function (jsonResult) {

                    var evlResult = JSON.retrocycle(jsonResult);
                    var selOption = "";
                    selOption = ParseJsonResultForSelectOptions(evlResult);
                    tempTargetElm = targetElm.split(',');
                    for (var i = 0; i < tempTargetElm.length; i++) {
                        // alert(tempTargetElm.length + " : " + tempTargetElm[i]);
                        $("#" + tempTargetElm[i]).empty().append(selOption);
                        $("#" + tempTargetElm[i]).removeClass('ac_loading');
                        $("#" + tempTargetElm[i]).removeAttr('disabled');
                    }


                },
                error: function (jsonResult) {
                    // alert(jsonResult);
                }
            });

        }


        function ParseJsonResultForSelectOptions(evlResult) {
            var selOption = "";
            $.each(evlResult, function (key, item) {
                var isSelected = (item['Selected'] == "true") ? "Selected='Selected'" : "";
                //var otherAttrib = (item['Attribs']!=undefined)? item['Attribs']:"";
                var otherAttrib = "";
                $.each(item, function (name, value) {
                    if (name != 'Selected' && name != 'Value' && name != 'Text') {
                        otherAttrib += " " + name + '="' + value + '" ';
                    }
                });
                selOption += "<option value='" + item['Value'] + "' " + isSelected + " " + otherAttrib + " >"
                + evlResult[key].Text + "</option>";
            });
            return selOption;
        }


        $(function () {

            //attach autocomplete
            $("#Tags").autocomplete({

                //define callback to format results
                source: function (req, add) {

                    //pass request to server
                    $.getJSON("/Airline/Tags/GetTagListAuto/?callback=?", req, function (data) {

                        //create array for response objects
                        var suggestions = [];

                        //process response
                        $.each(data, function (i, val) {
                            suggestions.push(val.name);
                        });

                        //pass array to callback
                        add(suggestions);
                    });
                },

                //define select handler
                select: function (e, ui) {

                    //create formatted friend
                    var friend = ui.item.value,
							span = $("<span>").text(friend),
							a = $("<a>").addClass("remove").attr({
							    href: "javascript:",
							    title: "Remove " + friend
							}).text("x").appendTo(span);                   
                    span.insertBefore("#Tags");
                },

                //define select handler
                change: function () {

                    //prevent 'to' field being updated and correct position
                    $("#Tags").val("").css("top", 2);
                }
            });

            //add click handler to friends div
            $(".acFieldContainer").click(function () {

                //focus 'to' field
                $("#Tags").focus();
            });

            //add live handler for clicks on remove links
            $(".remove", ".acFieldContainers").live("click", function () {

                //remove current friend
                $(this).parent().remove();

                //correct 'to' field position
                if ($(".acFieldContainer span").length === 0) {
                    $("#Tags").css("top", 0);
                }
            });
        });

</script>

<script type="text/javascript">

    $(document).ready(function () {

        $('#saveDeal').live("click", function (event) {

            var StartingPrice = $("#StartingPrice").val();
            var StartingINR = $("#StartingINR").val();
            var StartingUSD = $("#StartingUSD").val();

           
        });



    });
</script>