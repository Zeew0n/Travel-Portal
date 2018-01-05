<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelRoomTypes>>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hotel RoomType List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Room Type</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                <%:Html.ActionLink("New", "Create", new { controller = "HotelRoomType" }, new { @class = "new" })%>
                </li>
                
            </ul>
        </div>
    </div>
    <% Html.RenderPartial("VUC_DeleteDialogue"); %>
     <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
    <thead>
        <tr>
            <th>
                S.No.
            </th>
            <th>
                Hotel Room Type
            </th>
         
            <th>
                Room Capacity
            </th>
            <th>
                Description
            </th>
            <th>
                Active
            </th>
            <th>
                Action
            </th>
        </tr>
        </thead>
        <%  var sno = 0;
            foreach (var item in Model)
            {
                sno++;
                var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
     <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
            <td>
                <%=sno %>
            </td>
            <td>
            <%: Html.ActionLink(item.TypeName, "Detail", new { id = item.HotelRoomTypeId }, new { @class = "Details" })%>
                
            </td>
            <%--<td>
            <%: Html.ActionLink(item.TypeName, "Detail", new { id = item.HotelRoomTypeId }, new { onclick = "ShowThickBox('Detail',this.href+'?keepThis=true&TB_iframe=true&height=300&width=500');return false;" })%>
                 
            </td>--%>
       
            <td>
            <%:item.RoomCapacity %>
            </td>
            <td>
                <%: item.Details %>
            </td>
            <td>
                <%: item.isActive%>
            </td>

            <td>
                <%: Html.ActionLink(" ", "Edit", new { id = item.HotelRoomTypeId }, new { @class = "edit" })%>
                
                
                
                <%: Html.ActionLink(" ", "Delete", new { id = item.HotelRoomTypeId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;", @class = "delete" })%>
            </td>
          <%--  <td>
                <%: Html.ActionLink(" ", "Edit", new { id = item.HotelRoomTypeId }, new {@class="edit"})%>
                <%: Html.ActionLink(" ", "Delete", new { id = item.HotelRoomTypeId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;", @class = "delete" })%>
            </td>--%>
        </tr>
        <% } %>
    </table>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /////////////////////// POP UP Function //////////////////////////////////////
            $(function () {

                $('a.edit').live("click", function (event) {
                    loadEditDialog(this, event, '#contentGrid');

                });
                $('a.new').live("click", function (event) {
                    loadDialog(this, event, '#contentGrid');

                });
                $('a.Details').live("click", function (event) {
                    loadDetailsDialog(this, event, '#contentGrid');

                });

            });
            /////////////////End of new fucntion/////////////////


        });   /* end document.ready() */    

</script>

</asp:Content>
