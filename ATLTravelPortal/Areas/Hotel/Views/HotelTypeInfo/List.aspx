<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelTypeInfos>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hotel Type List</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Type</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                <%:Html.ActionLink("New", "Create", new { controller = "HotelTypeInfo" }, new { @class = "new" })%>
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
                HotelType
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
            <%: Html.ActionLink(item.HotelTypeName, "Detail", new { id = item.HotelTypeId }, new { @class= "Details" })%>
                
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.isActive %>
            </td>
            <td>
                <%: Html.ActionLink(" ", "Edit", new { id = item.HotelTypeId }, new {@class="edit" })%>
               <%: Html.ActionLink(" ", "Delete", new { id = item.HotelTypeId }, new { onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;",@class="delete" })%>
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