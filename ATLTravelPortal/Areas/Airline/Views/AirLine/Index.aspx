<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<System.Linq.EnumerableQuery<ATLTravelPortal.Areas.Airline.Models.AirLines>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Airline Info:Arihant Holidays
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li>
                    </li>
                <li>
                    
                </li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Airline Information</strong>
            </h3>
        </div>
        <%using (Ajax.BeginForm("Index", new { controller = "AirLine", action = "Index", }
               , new AjaxOptions()
                      {
                          UpdateTargetId = "Airline",
                          InsertionMode = InsertionMode.Replace
                      ,
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
          { %>
        <div class="row-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                <ul><li class="float-left" style="margin-right:10px;">
                    <%: Html.Label("Airline")%>
                    <%=Html.TextBox("SearchAirline", "", new { @class = "required" })%>
                    </li>

                     <li class="float-left" style="margin-right:10px;">
                    <%: Html.Label("Airline")%>
                    <%=Html.DropDownList("AirlineType",(SelectList)ViewData["AirlineType"]) %>
                    </li> 

                    <li class="float-left" style="margin-right:10px;">
                    <%: Html.Label("Status") %>
                    <%=Html.DropDownList("ddlStatus", (SelectList)ViewData["Status"])%>
                    </li>
                    <li class="float-left"><input type="submit" value="Search" />
                    </li>
                    <li class="float-left"><input type="button" value="New" onclick="document.location.href='/Airline/AirLine/Create'" />
                    </li>
                    </ul>
                    
                </div>
                
            </div>
        </div>
        <div class="row-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <%--<%using (Ajax.BeginForm("Active", new { controller = "Airline" }, new AjaxOptions() { HttpMethod = "Post" }))
                          {%>--%>
                        <%-- <%=Ajax.ActionLink("Active", "Active", new { controller = "Airline", action = "Active" }, new AjaxOptions() {   HttpMethod = "Post" })%>--%>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <%using (Ajax.BeginForm("Active", new { controller = "Airline" }, new AjaxOptions() { HttpMethod = "Post" }))
                          {%>
                    </div>
                </div>
            </div>
        </div>
        <input type="button" onclick="Activate(this)" value="Activate" name="submit" id="Active" />
        <input type="button" onclick="Activate(this)" value="Deactivate" name="submit" id="InActive" />
        <div id="Airline">
            <%Html.RenderPartial("AirlineSearchResult"); %>
        </div>
        <%}

          }%>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        label.error
        {
            font-weight: bold;
            color: #b80000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
        $('.validate').validate();
        $(function () {
            $("#SearchAirline").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                            }))
                        }
                    })
                },
                width: 150,
                select: function (event, ui) {
                    $("#AirlineId").val(ui.item.id);

                }

            });

        });
      
        ////////////////////////////Start of searching Airline By Status //////////////////////////////
        $(function () {
            $("#ddlStatus").change(function () {
                $("#SearchAirline").val(' ');
                LoadBanks($("#ddlStatus").val());

            });
        });

        function LoadBanks(companyId) {


            var Type = $("#AirlineType").val();


            var Mode = $("#ddlStatus").val();
            $.ajax({
                type: "GET",
                url: "/Airline/AirLine/Index",
                data: "IsActive=" + Mode + "&Type=" + Type,
                //data: status,
                dataType: "html",
                success: function (result) {

                    $("#Airline").empty().append(result);


                }
            });
        }

        /////////////////////////////////////End of searching Airline By Status///////////////////////////

        $(function () {
            $("#AirlineType").change(function () {
                var Type = $("#AirlineType").val();
                var Mode = $("#ddlStatus").val();
                $.ajax({
                    type: "GET",
                    url: "/Airline/AirLine/Index",
                    data: "IsActive=" + Mode + "&Type=" + Type,
                    //data: status,
                    dataType: "html",
                    success: function (result) {

                        $("#Airline").empty().append(result);


                    }
                });
            });
        });
        //////////////////////////  Starting of Changing the Status  Active////////////////////////////////////

        function Activate(thisElm) {
            var name = $("#AirlineList").attr("value");
            var allVals = new Array();

            var btnName = $("#" + thisElm.id).attr('value');

            var Type = $("#AirlineType").val();

            $('#tr1 :checked').each(function () {
                allVals.push($(this).val());
            });

            $.ajax({
                type: "POST",
                url: "/Airline/AirLine/Active",

                data: "chkAirLine=" + allVals + "&Mode=" + btnName + "&Type=" + Type,
                dataType: "html",
                success: function (result) {

                    $("#Airline").empty().append(result);
                    if (btnName == "Activate") {
                        $("#ddlStatus").val("1");
                    }
                    else
                        $("#ddlStatus").val("2");

                }
            });
        }
       
    </script>
    <script type="text/javascript">
        function beginList(args) {
            // Animate
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');

        }

        function successList() {
            // Animate loadingAnimation
            $("#loadingIndicator").html('');

        }
        
        
    </script>
</asp:Content>
