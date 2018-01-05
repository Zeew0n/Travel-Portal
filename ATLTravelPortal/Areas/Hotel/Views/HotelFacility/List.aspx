<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelFacilities>>" %>
  

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hotel Facility List</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Facility</h3>
        </div>
        <div class="buttons-panel">
            <ul>

                <li>
                <%:Html.ActionLink("New", "Create", new { controller = "HotelFacility" }, new { @class = "new" })%>
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
                Facility Name
            </th>
            <th>
                Details
            </th>
            <th>
                Active
            </th>
            <th>
                 Action
            </th> </tr>
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
            <%: Html.ActionLink(item.FacilityName, "Detail", new { id = item.FacilityId }, new { @class = "Details" })%>
                
            </td>
            <td>
                <%: item.Details%>
            </td>
            <td>
                <%: item.isActive%>
            </td>
            <td>
                <%: Html.ActionLink(" ", "Edit", new { id = item.FacilityId }, new { @class = "edit" })%>
                
                
                
                <%: Html.ActionLink(" ", "Delete", new { id = item.FacilityId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;", @class = "delete" })%>
            </td>
        </tr>
        <% } %>
    </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/themes/jquery.ui.autocomplete.css" rel="stylesheet" type="text/css" />
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
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
