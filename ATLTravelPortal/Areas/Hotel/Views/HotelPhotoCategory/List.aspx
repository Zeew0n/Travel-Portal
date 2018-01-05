<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelPhotoCategories>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Hotel Photo Category</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Photo Category</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                <%:Html.ActionLink("New", "Create", new { controller = "HotelPhotoCategory" }, new { @class = "new" })%>
                </li>
                
            </ul>
        </div>
    </div>
    
    <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
    <thead>
        <tr>
            <th>
                S.No.
            </th>
            <th>
                Category Name
            </th>
            <th>
                Details
            </th>
            <th>
                Hotel Name
            </th>
            <th>
            Active
            </th>
            <th>
                Action
            </th>
            </thead>
        </tr>
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
            <%: Html.ActionLink(item.CategoryName, "Detail", new { id = item.PhotoCategoryId }, new { @class = "Details" })%>
                
            </td>
            <td>
                <%: item.Details%>
            </td>
            <td>
                <%: item.HotelName%>
            </td>

            <td>
                <%: item.isActive%>
            </td>

            <td>
                <%: Html.ActionLink(" ", "Edit", new { id = item.PhotoCategoryId }, new { @class = "edit" })%>
                
                
                
                <%: Html.ActionLink(" ", "Delete", new { id = item.PhotoCategoryId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;", @class = "delete" })%>
            </td>
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
