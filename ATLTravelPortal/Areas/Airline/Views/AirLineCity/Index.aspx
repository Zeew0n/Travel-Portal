<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<TravelPortalEntity.AirlineCities>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Arihant Holidays:Airport Information
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
                      {
                          UpdateTargetId = "AirlineCity",
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
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Airport Information</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
            <ul><li class="float-left" style="margin-right:10px;">
                <%: Html.Label("City Code") %>
                <%=Html.TextBox("SearchCity","")%>
                </li><li class="float-left" style="margin-right:10px;">
                <%: Html.Label("Type") %>
                <%=Html.DropDownList("AirlineType",(SelectList)ViewData["AirlineType"]) %>
                </li>
                <li class="float-left"><input type="submit" value="Search" />
                    </li>
                    <li class="float-left"><input type="button" value="New" onclick="document.location.href='/Airline/AirLineCity/Create'" />
                    </li>
                </ul>
            </div>
        </div>
        
    </div>
    <div id="AirlineCity">
        <%Html.RenderPartial("AirlineCitySearchResult"); %>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        label.error
        {
            font-weight: bold;
            color: #b80000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
         $(document).ready(function () {
             $('.validate').validate();
           
         $(function () {
             $("#SearchCity").autocomplete({
             minlength:3,
                 source: function (request, response) {
                     $.ajax({
                         url: "/Airline/AjaxRequest/FindAirlineCity", type: "POST", dataType: "json",
                         data: { searchText: request.term, maxResult: 5 },

                         success: function (data) {
                             response($.map(data, function (item) {
                                 return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                             }))
                         }
                     });
                 },
                 width: 150,
                 
             });
         });
         
          });
          ////////////////////////////////End of Ready Function //////////////////////////////////////
          $(function () {
          
          $("#AirlineType").change(function () {
          $("#SearchCity").val(' ');
          var Type = $("#AirlineType").val();
           $.ajax({
                type: "GET",
                url: "/Airline/AirLineCity/Index",
                data: "AirlineType=" + Type,
                //data: status,
                dataType: "html",
                success: function (result) {

                    $("#AirlineCity").empty().append(result);


                }
            });
          });
          });

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
