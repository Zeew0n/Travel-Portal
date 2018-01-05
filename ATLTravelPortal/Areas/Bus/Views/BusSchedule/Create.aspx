<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Bus Schedule
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%using (Html.BeginForm())
      {%>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <%Html.RenderPartial("Utility/VUC_Message", Model.Message); %></li>
            <li>
                <input type="submit" value="Save" />
            </li>
            <li>
                <%:Html.ActionLink("Cancel", "Index", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong> Create Bus Schedule</strong>
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
                        <%: Html.DropDownListFor(model => model.BusCategoryId, Model.ddlBusCategoryList)%>
                        <%: Html.ValidationMessageFor(model => model.BusCategoryId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.DepartureCityId)%>
                        <%: Html.DropDownListFor(model => model.DepartureCityId, Model.ddlBusCityList)%>
                        <%: Html.ValidationMessageFor(model => model.DepartureCityId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.DestinationCityId)%>
                        <%: Html.DropDownListFor(model => model.DestinationCityId, Model.ddlBusCityList)%>
                        <%: Html.ValidationMessageFor(model => model.DestinationCityId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.DepartureTime)%>
                        <%: Html.EditorFor(model => model.DepartureTime)%>
                        <%: Html.ValidationMessageFor(model => model.DepartureTime)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ArrivalTime)%>
                        <%: Html.EditorFor(model => model.ArrivalTime)%>
                        <%: Html.ValidationMessageFor(model => model.ArrivalTime)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.TypeName)%>
                        <%: Html.DropDownListFor(model => model.TypeName, Model.ddlTypeList)%>
                        <%: Html.ValidationMessageFor(model => model.TypeName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.DurationHHMM)%>
                        <%: Html.TextBoxFor(model => model.DurationHHMM)%>
                        <%: Html.ValidationMessageFor(model => model.DurationHHMM)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.Rate)%>
                        <%: Html.EditorFor(model => model.Rate)%>
                        <%: Html.ValidationMessageFor(model => model.Rate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ActualRate)%>
                        <%: Html.EditorFor(model => model.ActualRate)%>
                        <%: Html.ValidationMessageFor(model => model.ActualRate)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.PurchaseRate)%>
                        <%: Html.EditorFor(model => model.PurchaseRate)%>
                        <%: Html.ValidationMessageFor(model => model.PurchaseRate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.AgentCommission)%>
                        <%: Html.EditorFor(model => model.AgentCommission)%>
                        <%: Html.ValidationMessageFor(model => model.AgentCommission)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.KiloMeter)%>
                        <%: Html.EditorFor(model => model.KiloMeter)%>
                        <%: Html.ValidationMessageFor(model => model.KiloMeter)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content ">
                    <div class="days">
                        <div>
                            <%: Html.LabelFor(model => model.Sunday)%>
                            <%: Html.CheckBoxFor(model => model.Sunday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Monday)%>
                            <%: Html.CheckBoxFor(model => model.Monday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Tuesday)%>
                            <%: Html.CheckBoxFor(model => model.Tuesday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Wednesday)%>
                            <%: Html.CheckBoxFor(model => model.Wednesday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Thursday)%>
                            <%: Html.CheckBoxFor(model => model.Thursday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Friday)%>
                            <%: Html.CheckBoxFor(model => model.Friday)%></div>
                        <div>
                            <%: Html.LabelFor(model => model.Saturday)%>
                            <%: Html.CheckBoxFor(model => model.Saturday)%></div>
                    </div>
                </div>
            </div>
        </div>
        <%--   <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <%Html.RenderPartial("Utility/VUC_Message",Model.Message); %></li>
                <li>
                    <input type="submit" value="Save" />
                </li>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BusSchedule", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
            </ul>
        </div>--%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <%--<link href="../../Scripts/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="<%:Url.Content("~/Scripts/jquery.ui.timepicker.js") %>" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#Daily').click(function () {
                $('#Daily').is(':checked') ? ($("input:checkbox").attr('checked', 'true')) : ($("input[type='checkbox']").removeAttr('checked'));

            });

            $("#DepartureTime").timepicker({
                ampm: false,
                timeFormat: 'hh:mm'
            });

            $("#ArrivalTime").timepicker({
                ampm: false,
                timeFormat: 'hh:mm'
            });
            /////////////////////////////////////////////////End of Time Format//////////////////////////////////////////////




            $("#BusMasterId").change(function () {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                id = $("#BusMasterId").val();

                if (id == "") {
                    $("#BusCategoryId").empty();
                    $("#BusCategoryId").append("<option value=''>" + "-- ALL--" + "</option>");
                    $("#loadingIndicator").html('');
                    return false;


                }
                else {
                    var url = "/Bus/AjaxRequest/GetCategoryByMasterId/";
                    $.getJSON(url, { id: id }, function (data) {
                        $("#BusCategoryId").empty().append("<option value=''>" + "-- ALL--" + "</option>");                       

                        $.each(data, function (index, optionData) {                           
                            $("#BusCategoryId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();
        });
    </script>
</asp:Content>
