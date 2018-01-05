<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.TicketAirlineSearchOrderModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
            <li>
                </li>
            <li>
                <input type="submit" value="Save" class="save" />            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Airline Sort</strong>
        </h3>
    </div>




    <div class="form-box1 round-corner">
    <div class="form-box1-row">
    <div class="form-box1-row-content float-left">
    <div>
    <label><%:Html.Label("Type")%></label>
    <%:Html.DropDownListFor(model => model.AirlineTypeId, (SelectList)ViewData["AirlineTypes"])%>
    </div>
    </div>
    
    </div>
        <div class="form-box1-row">


            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Airline")%>
                    </label>
                    <%:Html.TextBoxFor(model => model.AirlineName)%>
                </div>
            </div>
            
        </div>
    </div>
    <div style="color:Red">
    <%:TempData["Error"]%>
    <%:TempData["Airline"]%>
    </div>
    <div id ="Partial">
    <%Html.RenderPartial("OrderList"); %>
    </div>
    <div class="buttonBar">
<input type="submit" value="Save"  />   
                </div>
    
       <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<link href="../../../../Content/css/Sorting.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/AirlineSearchResult.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/SearchResult.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
//            var arr = [];
//            $("#contentLeft ul").sortable({
//                update: function (event, ui) {


//                    $("#contentLeft li").each(function () {
//                        arr.push($(this).attr('id'));

//                    });
//                    $("#SerialOrder").val(arr);
//                }

//            });
            ////////////////////////End of Sortable///////////////////////////

            $(function () {

                $("#AirlineName").autocomplete({
                    minlength: 2,
                    source: function (request, response) {
                        var typeId = $("#AirlineTypeId").val();
                        $.ajax({
                            url: "/Airline/AjaxRequest/FindAirlineByAirlineType", type: "POST", dataType: "json",
                            data: { searchText: request.term, AirlineTypeId: typeId, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                                }))
                            }
                        })
                    },
                    width: 150,
                    select: function (event, ui) {
                        //                        $("#AirlineTypeId").val(ui.item.id);

                    }

                });

            });
            //////////////////////End of Autocomplete////////////////////////////////////

            $("#AirlineTypeId").change(function () {

                var url = "/Airline/AirlineOrder/Index";
                var typeNumber = $("#AirlineTypeId").val();
                var Code = $("#AirlineName").val();
                $.ajax({
                    url: url,
                    data: "TypeId=" + typeNumber,
                    dataType: "html",
                    success: function (result) {
                        $("#Partial").empty().append(result);
                        $("#AirlineTypeId").val(typeNumber);
                        $("#AirlineName").val(Code);
                    }
                });

            });
            ////////////////End of AirlineTypeId Change////////////////////////////////
        });
        //////////////End of document Ready function/////////////////////

        
    </script>
</asp:Content>


