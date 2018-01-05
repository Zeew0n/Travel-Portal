<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelCityInfoAssociation>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hotel Google Map
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Google Map</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <%:Html.ActionLink("New", "Create", new { controller = "HotelGoogleMap" }, new { @class = "new" })%>
                </li>
            </ul>
        </div>
    </div>
    <%-- <h2>Hotels</h2>
<br />--%>
    <%--<div id="map_canvas" style="width: 100px; height: 100px;">
<%Html.RenderPartial("GoogleMap");%>--%>
    <%--</div>--%>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        S.No.
                    </th>
                    <th>
                        HotelName
                    </th>
                    <th>
                        City
                    </th>
                    <th>
                        Latitude
                    </th>
                    <th>
                        Longitude
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <% var sno = 0;
               foreach (var item in Model)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%=sno%>
                </td>
                <td>
                    <%:Html.ActionLink(item.HotelName, "Detail", new { id = item.HotelId }, new { id = item.HotelId, @class = "Details" })%>
                </td>
                <td>
                    <%:item.CityName %>
                </td>
                <td>
                    <%:item.Latitude%>
                </td>
                <td>
                    <%:item.Longitude%>
                </td>
                <td>
                    <%: Html.ActionLink(" ", "Edit", new { id = item.HotelId }, new {@class="edit" })%>
                    <%-- |
                    <%:Html.ActionLink("Delete", "HotelGoogleMapDelete", new { id = item.HotelId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;" })%>--%>
                </td>
            </tr>
            <%} %>
        </table>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript ">
        $(document).ready(function () {
          
              
           

            /////////////////////// POP UP Function //////////////////////////////////////
            $(function () {
              
                $('a.edit').live("click", function (event) {
                    loadEditDialog(this, event, '#contentGrid');

                });
                $('a.new').live("click", function (event) {
                    loadDialog(this, event, '#contentGrid');

                });
//                $('a.Details').live("click", function (event) {
//                    $("#item_HotelId").val(parseInt(this.id));
//                  
//                        loadDetailsDialog(this, event, '#contentGrid');
//                });
            });
            /////////////////End of new fucntion/////////////////
          
        });           /* end document.ready() */
        $('a.Details').live("click", function (event) {
            $("#item_HotelId").val(parseInt(this.id));

            loadDetailsDialog(this, event, '#contentGrid');

        });

    </script>
</asp:Content>
