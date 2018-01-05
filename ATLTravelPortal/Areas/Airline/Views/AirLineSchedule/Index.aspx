<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Domestic Airline Schedule List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
                      {
                          UpdateTargetId = "Partial",
                          InsertionMode = InsertionMode.Replace
                      ,
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
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
            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong> Domestic Airline Schedule</strong>
        </h3>
    </div>
    <div class="box1">
        <div class="row-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                <ul><li class="float-left" style="margin-right:10px;">
                    <%: Html.Label("Airline")%>
                    <%=Html.TextBox("SearchAirline", "")%>
                   </li>
                   <li class="float-left"><input type="submit" value="Search" />
                    </li>
                    <li class="float-left"><input type="button" value="Create" onclick="document.location.href='/Airline/AirLineSchedule/Create'" />
                    </li>
                </ul>
                </div>
            </div>
           
        </div>
    </div>
    <div id="Partial">
        <%Html.RenderPartial("ListPartial"); %>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/AirlineSearchResult.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/SearchResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            //        $(".delete").click(function () {
            //            var id = $(this).attr("id");
            //            id = id.substr(2);
            //            $.ajax({
            //                type: "GET",
            //                url: "/AirLineSchedule/Delete",
            //                data: "id=" + id,
            //                //data: status,
            //                dataType: "html",
            //                success: function (result) {

            //                    $("#Partial").empty().append(result);


            //                }
            //            });
            //        });
            ////////////////////////////////////////////////End of Delete///////////////////////////////////
        });
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
        
    </script>
</asp:Content>
