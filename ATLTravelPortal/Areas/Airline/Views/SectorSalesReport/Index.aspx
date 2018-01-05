<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SectorSalesReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Segment Sales
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
   <%-- <%using (Ajax.BeginForm("Index", "SectorSalesReport", new AjaxOptions()
                      {
                          UpdateTargetId = "ListPartial",
                          InsertionMode = InsertionMode.Replace
                      ,
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
      { %>--%>
        <% using (Html.BeginForm())
      { %>
    <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Segment Sales</strong>
            </h3>
        </div>
    </div>

     <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>

    <div class="row-1">
        <div class="form-box1 round-corner">

            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                         <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                       <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>


             <div class="form-box1-row">
                 <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AirlineTypesId)%></label>
                        <%:Html.DropDownListFor(model => model.AirlineTypesId, (SelectList)ViewData["AirlineTypes"])%>
                        <%: Html.ValidationMessageFor(model => model.AirlineTypesId, "*")%>
                    </div>
                </div>
            </div>


              <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.DepartCity)%></label>
                       <%: Html.TextBoxFor(model => model.DepartCity) %>
                        <%: Html.HiddenFor(model => model.hdfDepartCityId) %>
                       
                          
                    </div>
                </div>

                  <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ArriveCity)%></label>
                        <%: Html.TextBoxFor(model => model.ArriveCity) %>
                         <%: Html.HiddenFor(model => model.hdfArriveCityId)%>
                    </div>
                </div>
            </div>


             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Agent)%></label>
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"], "---All---")%>
                        <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
                          
                    </div>
                </div>
            </div>

           
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>



    <%} %>

  

    <%--<div id="ListPartial">
        <%Html.RenderPartial("ListPartial",Model); %>
    </div>--%>


    <div class="contentGrid">


         <%if (Model.SegmentSalesReportList != null && Model.SegmentSalesReportList.Count() > 0)
           { %>

       <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
        <thead>
      
        <tr>
            <th>
                SNo
            </th>
            <th>
                Depart
            </th>
            <th>
                Arrive
            </th>
            <th>
                Segment
            </th>
            <th>
            Status
            </th>
        </tr>
        </thead>
      
        <% var sno = 0;


           int count = Model.SegmentSalesReportList.Count();
           if (count > 0)
           {
               Model.txtSumMainSegment = Model.SegmentSalesReportList.ElementAt(count - 1).txtSumMainSegment;
               Model.txtSumTotalBookedTicketStatus = Model.SegmentSalesReportList.ElementAt(count - 1).txtSumTotalBookedTicketStatus;
               Model.txtSumTotalCancelledTicketStatus = Model.SegmentSalesReportList.ElementAt(count - 1).txtSumTotalCancelledTicketStatus;
               Model.txtDifference = Model.SegmentSalesReportList.ElementAt(count - 1).txtDifference;
           }




           foreach (var item in Model.SegmentSalesReportList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
               
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.DepartCity%>
                </td>
                <td>
                    <%: item.ArriveCity%>
                    </td>
             
           
                <td>
             
               
              <%: Html.ActionLink(item.SegmentId.Value.ToString(), "Detail", new { DepartCityId = item.DepartCityId, ArriveCityId = item.ArriveCityId, FromDate = Model.FromDate, Todate = Model.ToDate }, new { @class = "Details" })%> 
                </td>
                <td>
                <%: item.TicketStatusName %>
                </td>
            </tr>
      
     </tbody>
        <%      }%>
        <tbody>
            <tr>


                <% if (Model.SegmentSalesReportList != null)
                   {


                       if (count > 0)
                       {
                %>

                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
               <%-- <td>
                    Total Segments:<%:Model.txtSumMainSegment == null ? "" : (Model.txtSumMainSegment).ToString()%>

                </td>--%>
                 <td>
                        <b>Net: <%:Model.txtDifference == null ? "" : Model.txtDifference.ToString()%></b>
                        </td>
                        <td></td>
                <%}
                   }
                %>
            </tr>
        </tbody>



        <%--new code--%>
         <% if (Model.SegmentSalesReportList != null && Model.SegmentSalesReportList.Count() > 0)
            { %>
           
        <% }
            else
            {
                Html.RenderPartial("NoRecordsFound");
            } 
                %>
<%--..............................................................--%>


 <%------------------------  Data for paging ------------------------%>
       <%--  <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> --%>
          <%------------------------End  Data for paging ------------------------%>










          <%-- <%if (Model.SegmentSalesReportList != null && Model.SegmentSalesReportList.Count() > 0)
             { %>
         <table class="grid_tbl paging" border="0" width="100%">
        <tr>
            <td>
                
                 <%=Ajax.ActionLink("<<First", "Index", new { controller = "SectorSalesReport", action = "Index", pageNo = 1 },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 

                 <%=Ajax.ActionLink("Previous", "Index", new { controller = "SectorSalesReport", action = "Index", pageNo = currentPage, flag = 1 },
                 new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                  <%=Ajax.ActionLink("Next", "Index", new { controller = "SectorSalesReport", action = "Index", pageNo = currentPage, flag = 2 },
                    new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                     
                 <%=Ajax.ActionLink("Last>>", "Index", new { controller = "SectorSalesReport", action = "Index", pageNo = numberOfPage },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                
            </td>
        </tr>
     </table>
     <%} %>--%>

      

        <%}%>

       <%-- <%} %>--%>
      
       
    </table>

     <div>
                        <b>Total Booked:<%:Model.txtSumTotalBookedTicketStatus == null ? "" : Model.txtSumTotalBookedTicketStatus.ToString() %></b>
                       <br />
                       
                        <b>Total Cancelled:<%:Model.txtSumTotalCancelledTicketStatus == null ? "" : Model.txtSumTotalCancelledTicketStatus.ToString()%></b>
                      
                        </div>
    
  
</div>

  
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            /////////////////////// POP UP Function //////////////////////////////////////
            $(function () {
                $('a.Details').live("click", function (event) {
                    loadDetailsDialog(this, event, '#contentGrid');

                });

            });
            function loadDetailsDialog(tag, event, target) {
                event.preventDefault();
                var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
                var $url = $(tag).attr('href');
                var $title = $(tag).attr('title');
                var $dialog = $('<div></div>');
                $dialog.empty();
                $dialog
            .append($loading)
            .load($url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 500
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale'
		    });

                //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

                $dialog.dialog('open');
            };
            /////////////////End of new fucntion/////////////////
          

//            $("#showall").click(function () {
//                var productId = $("#ProductId").val();
//                var AgentId = $("#AgentId").val();
//                var FDate = $("#FromDate").val();
//                var TDate = $("#ToDate").val();
//                //var IsApproved = $("#UnApproved").val();UnApproved
//                var IsApproved = false;
//                if ($("#UnApproved").attr('checked')) {
//                    IsApproved = true;
//                }


//                $.ajax(

//             {

//                 type: "GET",

//                 url: "/LedgerVoucher/Index",

//                 data: "productId=" + productId + "&AgentId=" + AgentId + "&FDate=" + FDate + "&TDate=" + TDate + "&IsApproved=" + IsApproved,

//                 success: function (result) {
//                     $("#ListPartial").empty().append(result);

//                 },

//                 error: function (req, status, error) {

//                     //        alert("Sorry! We could not receive your feedback at this time.");

//                 }

//             });

//            });
        });
        ///////////////////////////End of document ready function ////////////////////////////////////


        $(function () {
            var dates = $("#FromDate, #ToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "FromDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });
        //////////////////////////////End of Date Picker /////////////////////////////////////////////////
        function EnableDisableElementBySelectionAppliedDate(thisElm, targetElm) {
            if (thisElm == "checked") {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).val("")
            }
            else {
                $("#" + targetElm).removeAttr('disabled', 'disabled');
            }
        }




//        /////// Get DepartCity on selecting AirlineType////////////////////////////////////
//        $(document).ready(function () {

//            $("#AirlineTypesId").change(function () {
//                id = $("#AirlineTypesId").val();
//                if (id == "") {
//                    return false;
//                }
//                else {
//                    //build the request url
//                    var url = "/AjaxRequest/GetDepartCityNameBasedonAirlineTypeId";
//                    //fire off the request, passing it the id which is the MakeID's selected item value
//                    $.getJSON(url, { id: id }, function (data) {
//                        //Clear the Model list
//                        $("#DepartCityId").empty();
//                        $("#DepartCityId").append("<option value=''>" + "-- Select--" + "</option>");
//                        //Foreach Model in the list, add a model option from the data returned
//                        $.each(data, function (index, optionData) {

//                            $("#DepartCityId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
//                        });
//                    });
//                }
//            }).change();

//        });
//        ////////////////////////////////////////////////////////////////////////




//        /////// Get ArriveCity on selecting AirlineType////////////////////////////////////
//        $(document).ready(function () {

//            $("#AirlineTypesId").change(function () {
//                id = $("#AirlineTypesId").val();
//                if (id == "") {
//                    return false;
//                }
//                else {
//                    //build the request url
//                    var url = "/AjaxRequest/GetDepartCityNameBasedonAirlineTypeId";
//                    //fire off the request, passing it the id which is the MakeID's selected item value
//                    $.getJSON(url, { id: id }, function (data) {
//                        //Clear the Model list
//                        $("#ArriveCityId").empty();
//                        $("#ArriveCityId").append("<option value=''>" + "-- Select--" + "</option>");
//                        //Foreach Model in the list, add a model option from the data returned
//                        $.each(data, function (index, optionData) {

//                            $("#ArriveCityId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
//                        });
//                    });
//                }
//            }).change();

//        });
        //        ////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
        $(document).ready(function () {
//           $("#AirlineTypesId").live("change",function () {
//            
//                var airlinetypes = $("#AirlineTypesId").val();
            $(function () {
                var airlinetypes = $("#AirlineTypesId").val();
                    $("#DepartCity").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "/Airline/SectorSalesReport/FindAirlineCity", type: "POST", dataType: "json",
                                data: { searchText: request.term, maxResult: 5, airlinetypes: airlinetypes },

                                success: function (data) {
                                    response($.map(data, function (item) {
                                        return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                    }))
                                }
                            });
                        },
                        width: 150,
                        select: function (event, ui) {
                            // $("#DepartCity").val(ui.item.id);
                            $("#hdfDepartCityId").val(ui.item.id);


                        }

                    });
//                });

                $(function () {


                    $("#ArriveCity").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "/Airline/SectorSalesReport/FindAirlineCity", type: "POST", dataType: "json",
                                data: { searchText: request.term, maxResult: 5, airlinetypes: airlinetypes },

                                success: function (data) {
                                    response($.map(data, function (item) {
                                        return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                    }))
                                }
                            });
                        },
                        width: 150,
                        select: function (event, ui) {
                            // $("#ArriveCity").val(ui.item.id);
                            $("#hdfArriveCityId").val(ui.item.id);

                        }

                    });
                });

            });

        });
        /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////



         
        

    </script>
</asp:Content>