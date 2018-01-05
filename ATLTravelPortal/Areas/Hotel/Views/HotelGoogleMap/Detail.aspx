<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.HotelCityInfoAssociation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentGrid" id="result">
        <h2>
            Details
            <br />
            Please Refresh web page Every Time To view Google Map.
        </h2>
        <table class="data-table">
            <tr>
                <th>
                    S.No.
                </th>
                <th>
                    Hotel Name
                </th>
                <th>
                    City Name
                </th>
                <th>
                    Latitude
                </th>
                <th>
                    Longitude
                </th>
            </tr>
            <%  var sno = 0;
                foreach (var item in Model)
                {
                    sno++;
            %>
            <tr id="tr_<%: sno %>">
                <td>
                    <%=sno%>
                </td>
                <td>
                    <%: item.HotelName%>
                </td>
                <td>
                    <%: item.CityName%>
                </td>
                <td>
                    <%: item.Latitude%>
                </td>
                <td>
                    <%: item.Longitude%>
                </td>
            </tr>
            <%:Html.HiddenFor(model => item.HotelId)%>
            <% } %>
        </table>
          <div id="map_canvas" style="width: 300px; height: 300px;">
    </div>
    </div>
    

  
    <script src="http://maps.google.com/maps?file=api&amp;v=2&async=2&amp;key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1-m51RBrvYughuyMxQ-i1QfUnH94QxWIa6N4U6MouMmBA"
        type="text/javascript"></script>
  
    
     <script type="text/javascript" language="javascript" >

         $(document).ready(function () {



             if (GBrowserIsCompatible()) {
                 var Id = $("#item_HotelId").val();

                 $.getJSON("/Hotel/AjaxRequest/HotelsForMap", { id: Id }, function (data) {
                  
                     initialize(data);
                 });

             }

             function initialize(mapData) {
                
                 var map = new GMap2(document.getElementById("map_canvas"));
               
                 //                map.addControl(new google.maps.smallMapControl());
                 map.addControl(new google.maps.MapTypeControl());
                 map.setCenter(new GLatLng(mapData.Data[0].Latitude, mapData.Data[0].Longitude), 16);
              
                 var zoom = mapData.zoom;

                 $.each(mapData, function (i, Hotel) {
                     setupLocationMarker(map, mapData);
                 });
                 map.setUIToDefault();     
                
             }
            
             function setupLocationMarker(map, Hotel) {

                 var latlng = new GLatLng(Hotel.Data[0].Latitude, Hotel.Data[0].Longitude);
                 var marker = new GMarker(latlng);
                 map.addOverlay(marker);
             }
         });
//              $(document).ready(function () {
//                  $('#map_canvas').width(100);
//                  $('#map_canvas').singleclick(function () {
//                      $(this).css("cursor", "pointer");
//                      $(this).animate({ width: "300px" }, 'slow');
//                  });

//                  $('#map_canvas').mouseout(function () {
//                      $(this).animate({ width: "100px" }, 'slow');
//                  });
//              });

    </script>
</asp:Content>
