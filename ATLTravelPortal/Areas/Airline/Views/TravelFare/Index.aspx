<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.TravelFareModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Arihant Holidays:Travel Fare
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
        <ul class="float-right">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                 <a href="/Airline/TravelFare/Create" class="new linkButton" title="New">Create</a>            </li>
            <li>
               
            </li>
        </ul>
        <h3>
           Setup<span>&nbsp;</span><strong>Paper Fare List</strong>
        </h3>
    </div>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
            <ul><li class="float-left" style="margin-right:10px;">
                <%: Html.Label("Airline")%>
                <%=Html.TextBox("SearchAirline", "")%>
                </li>
                <li class="float-left" style="margin-right:10px;">
                <%: Html.Label("Airline Type")%>
                <%=Html.DropDownList("AirlineType", (SelectList)ViewData["AirlineType"])%>
                </li>
                   <li class="float-left"><input type="submit" value="Search" />
                    </li>
                   
                </ul>
            </div>
        </div>
       
    </div>
    <div id="Partial">
        <%Html.RenderPartial("ListPartial"); %>
    </div>
   
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    
    <link href="../../../../Content/css/SearchResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">


$(document).ready(function () {
             $('.validate').validate();
    $(function () {
     var Types = $("#AirlineType").val();
     
             $("#SearchAirline").autocomplete({
            minlength:2,
                 source: function (request, response) {
                     $.ajax({
                         url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
                         data: { searchText: request.term, maxResult: 5,Type: $("#AirlineType").val() },

                         success: function (data) {
                             response($.map(data, function (item) {
                                 return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                             }))
                         }
                     });
                 },
                 width: 150,
                 
             });
         });
         });
       



////////////////////////////////////////End of document Ready Function ///////////////////////////////////////
$(function () {
          
          $("#AirlineType").change(function () {
          $("#SearchAirline").val(' ');

          var Type = $("#AirlineType").val();
           $.ajax({
                type: "GET",
                url: "/Airline/TravelFare/Index",
                data: "AirlineType=" + Type,
                //data: status,
                dataType: "html",
                success: function (result) {

                    $("#Partial").empty().append(result);


                }
            });
          });
    });

//////////////////////////////////////////////End of dropdown change function//////////////////////////
    
          
    </script>
</asp:Content>
