<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MassEmailingModel>" %>

<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models.Enums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("Index", "MassEmailing", FormMethod.Post, new { @id = "myForm"}))
      { %>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
            </li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">
                    <label id="massMessageType">
                        Agent Management</label></a> <span>&nbsp;</span><strong>
                            <label id="messageTypeLabel">
                                Mass Emailing</label>
                        </strong>
            </h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AgentClassId) %></label>
                    <%:Html.DropDownListFor(model => model.AgentClassId, Model.AgentClasses, "--ALL--")%>
                    <%: Html.ValidationMessageFor(model => model.AgentClassId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AgentDealId) %></label>
                    <%:Html.DropDownListFor(model => model.AgentDealId, Model.AgentDeals, "--ALL--")%>
                    <%: Html.ValidationMessageFor(model => model.AgentDealId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AgentTypeId) %></label>
                    <%:Html.DropDownListFor(model => model.AgentTypeId, Model.AgentTypes, "--ALL--")%>
                    <%: Html.ValidationMessageFor(model => model.AgentTypeId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.ZoneId) %></label>
                    <%:Html.DropDownListFor(model => model.ZoneId, Model.Zones, "--ALL--")%>
                    <%: Html.ValidationMessageFor(model => model.ZoneId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.DistrictId) %></label>
                    <%:Html.DropDownListFor(model => model.DistrictId, Model.Districts, "--ALL--")%>
                    <%: Html.ValidationMessageFor(model => model.DistrictId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Subject) %></label>
                    <%:Html.TextBoxFor(model => model.Subject, new { @style = "width:662px;" })%>
                    <%: Html.ValidationMessageFor(model => model.Subject)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.SpecifiedAgents) %></label>
                    <%:Html.TextBoxFor(model => model.SpecifiedAgents, new { @style = "width:662px;" })%>
                    <%--  <div class="acFieldContainer ui-helper-clearfix">
                        <%: Html.TextBoxFor(model => model.SpecifiedAgents, new { @style = "width :50px; border:0px;" })%></div>--%>
                    <%: Html.ValidationMessageFor(model => model.SpecifiedAgents)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row" id="freeEmailArea">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.FreeEmail) %></label>
                    <%:Html.TextAreaFor(model => model.FreeEmail, new { @style = "width: 244px; height: 117px;;" })%>
                    <%: Html.ValidationMessageFor(model => model.FreeEmail)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row" id="freeMobileNoArea">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.FreeMobileNo) %></label>
                    <%:Html.TextAreaFor(model => model.FreeMobileNo, new { @style = "width: 244px; height: 117px;;",@onkeypress = "return CheckNumericValue(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.FreeMobileNo)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%:Html.LabelFor(model=>model.MessageType) %></label>
                    <%: Html.RadioButtonFor(model => model.MessageType, ATLTravelPortal.Areas.Administrator.Models.Enums.MessageType.Email, new  {@id="EmailMessageType" })%>
                    Email &nbsp;&nbsp;&nbsp;
                    <%: Html.RadioButtonFor(model => model.MessageType, ATLTravelPortal.Areas.Administrator.Models.Enums.MessageType.SMS, new { @id = "SMSMessageType" })%>
                    SMS
                    <input type="hidden" value="<%=Model.MessageType %>" id="myTest" />
                </div>
            </div>
        </div>
        <div class="form-box1-row" id="smsArea">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%:Html.LabelFor(model=>model.SMSMessage) %></label>
                    <%:Html.TextAreaFor(model => model.SMSMessage, new  {@style="width:300px; height:125px;" })%>
                </div>
            </div>
        </div>
        <div id="trSms">
        <div class="form-box1-row" id="emailArea">
            <div class="form-box1-row-content float-left" style="width: 100%;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.EmailMessage) %>
                    </label>
                    <div style="width: 670px; float: left">
                        <%= Html.TextAreaFor(model=>model.EmailMessage, new { @class = "ckeditor" })%>
                    <span class="redtxt">*</span>
                        <%: Html.ValidationMessageFor(model => model.EmailMessage)%>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
    <div class="buttonBar">
        <input type="submit" value="Send Email" class="btn1" id="submitButton" />
        <input type="button" value="Reset Form" class="btn1" id="resetFormButton" />
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="/Content/autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json.cycle.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.ui.autocomplete.selectFirst.js" type="text/javascript"></script>
     <script type="text/javascript">
         function CheckNumericValue(e) {
             var key = e.which ? e.which : e.keyCode;
                          
             if ((key >= 48 && key <= 57) || key == 44 || key == 32 || key == 59 || key == 8) {
                 return true;
             }
             else {

                 return false;
             }
         }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            ////////////////////////////////////////////////////////////////////////////////////////////
            /////// Get Districts name with respect to Zones Name////////////////////////////////////
            $("#ZoneId").live("change", function () {
                id = $("#ZoneId").val();
                if (id == "") {
                    $("#DistrictId").empty();
                    $("#DistrictId").append("<option value=''>--ALL--</option>");
                    return false;
                }
                else {
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetDistrictOptionsByZoneId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list                 
                        $("#DistrictId").empty();
                        $("#DistrictId").append("<option value=''>--ALL--</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {
                            $("#DistrictId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        $("#loadingIndicator").html('');
                    });
                }
            }).change();
            ////////////////////////////////////////////////////////////////////////////////////////////



            $(function () {
                function split(val) {
                    return val.split(/,\s*/);
                }
                function extractLast(term) {
                    return split(term).pop();
                }
                $("#SpecifiedAgents")
                // don't navigate away from the field on tab when selecting an item
			.bind("keydown", function (event) {
			    if (event.keyCode === $.ui.keyCode.TAB &&
						$(this).data("autocomplete").menu.active) {
			        event.preventDefault();
			    }
			})
			.autocomplete({
			    minLength: 3,
			    selectFirst: true,
			    source: function (request, response) {
			        $.ajax({
			            url: "/Administrator/AjaxRequest/FindAgents", type: "POST", dataType: "json",
			            data: { term: extractLast(request.term), maxResults: 10 },
			            success: function (data) {
			                response($.map(data, function (item) {
			                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId, agentCode: item.AgentCode }
			                }))
			            },
			            error: function (XMLHttpRequest, textStatus, error) {//302
			                alert('HTTP ' + textStatus + ' Error Encountered: ' + error);
			            }
			        });
			    },
			    search: function () {
			        // custom minLength
			        var term = extractLast(this.value);
			        if (term.length < 1) {
			            return false;
			        }
			    },
			    focus: function () {
			        // prevent value inserted on focus
			        return false;
			    },
			    select: function (event, ui) {
			        var terms = split(this.value);
			        // remove the current input
			        terms.pop();
			        // add the selected item
			        terms.push(ui.item.value);
			        // add placeholder to get the comma-and-space at the end
			        terms.push("");
			        this.value = terms.join(", ");
			        return false;
			    }
			});
            });

            var choosedMessageType = $('input:radio[name=MessageType]:checked').val();
            if (choosedMessageType == "Email") {
                $('#smsArea').hide();
                $('#freeMobileNoArea').hide();
                $('#freeEmailArea').show();
                $("#emailArea").show();
                $("#submitButton").val("Send Email");
                $("#messageTypeLabel").html('Mass Emailing');
               // $("#massMessageType").html('Mass Emailing');
            }
            else if (choosedMessageType == "SMS") {
                $('#smsArea').show();
                $('#freeMobileNoArea').show();
                $('#freeEmailArea').hide();
                $("#emailArea").hide();
                $("#submitButton").val("Send SMS");
                $("#messageTypeLabel").html('Mass SMSing');
                //$("#massMessageType").html('Mass SMSing');
            }

            $("#EmailMessageType").live("click", function () {
                $('#smsArea').hide();
                $('#freeMobileNoArea').hide();
                $('#freeEmailArea').show();
                $("#emailArea").show();
                $("#submitButton").val("Send Email");
                $("#messageTypeLabel").html('Mass Emailing');
               // $("#massMessageType").html('Mass Emailing');
            });

            $("#SMSMessageType").live("click", function () {
                $('#smsArea').show();
                $('#freeMobileNoArea').show();
                $('#freeEmailArea').hide();
                $("#emailArea").hide();
                $("#submitButton").val("Send SMS");
                $("#messageTypeLabel").html('Mass SMSing');
               // $("#massMessageType").html('Mass SMSing');
            });


            $("#resetFormButton").live("click", function () {                
                $(':input', '#myForm')
                .not(':button, :submit, :reset, :hidden')
                .val('');
            });
        });

        function checkValidation() {
            var choosedMessageType = $('input:radio[name=MessageType]:checked').val();
            if (choosedMessageType == "Email") {
                return true;
            }
            else if (choosedMessageType == "SMS") {
                var smsContent = $("#SMSMessage").val();
                if (smsContent == "") {
                    alert("Enter SMS Text");
                    return false;
                }
                return true;
            }
        }
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("input[name$='MessageType']").click(function () {
                var radio_value = $(this).val();
                if (radio_value == 'SMS') {
                    $('#EmailMessage').val($(this).val());
//                    $("#trSms").children().hide();
//                    $('#EmailMessage').attr('disabled', true);
                }
            });
        });


    </script>
</asp:Content>
