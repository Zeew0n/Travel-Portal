<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OnLineAirlineSettingsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm())
       { %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li></li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Online Airline Setting</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.ServiceProvider) %>
                    </label>
                    <%:Html.DropDownListFor(model => model.ServiceProvider, Model.ServiceProviderList)%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model=>model.ServiceProvider) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AirlineCode) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.AirlineCode)%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model=>model.AirlineCode) %>
                    <%:Html.HiddenFor(model=>model.hdfAirlineName) %>
                </div>
            </div>
        </div>
    </div>
    <div class="buttonBar">
        <input type="submit" value="Make Online" />
    </div>
<%--    <div style="color: Red">
        <%:TempData["Error"]%>
        <%:TempData["AirlineCode"]%>
    </div>--%>
    <div id="Partial">
        <%Html.RenderPartial("ListPartial"); %>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/Sorting.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/AirlineSearchResult.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/SearchResult.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table.tablesorter thead tr .header
        {
            background-image: url(../../../../Content/images/bg.png);
            background-repeat: no-repeat;
            background-position: center right;
            cursor: pointer;
            height: 20px;
            line-height: 20px;
            padding: 0 0 0 4px;
            text-align: left;
            font-weight: bold;
        }
        
        table.tablesorter thead tr .headerSortUp
        {
            background-image: url(../../../../Content/images/asc.png);
        }
        table.tablesorter thead tr .headerSortDown
        {
            background-image: url(../../../../Content/images/desc.png);
        }
        
        table thead th:hover
        {
            background-color: Yellow;
            color: Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("table.tablesorter").tablesorter({ widthFixed: true, headers: { 0: { sorter: false }, 4: { sorter: false}} });

        });
    </script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $(function () {
                $("#AirlineCode").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AjaxRequest/FindAirlinesCode", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    // return { label: item.AirlineCode, value: item.AirlineCode, id: item.AirlineId }
                                    return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineCode, id: item.AirlineId }

                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfAirlineName").val(ui.item.id);
                    }

                });
            });


            $("#ServiceProvider").change(function () {
                var url = "/Airline/OnLineAirlineSettings/Index";
                var serviceprovider = $("#ServiceProvider").val();
                var Code = $("#AirlineCode").val();
                $.ajax({
                    type: "GET",
                    url: url,
                    data: { id: serviceprovider },
                    dataType: "html",
                    success: function (result) {
                        $("#Partial").empty().append(result);
                        $("#ServiceProvider").val(serviceprovider);
                        $("#AirlineCode").val(Code);
                    }
                });
            });



            ////////////////End of ServiceProviderId Change////////////////////////////////
        });
        //////////////End of document Ready function/////////////////////
      
    </script>
</asp:Content>
