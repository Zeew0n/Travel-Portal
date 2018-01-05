<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<List<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>>" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Hotel.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Hotel Card
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="box3">
        <div class="userinfo">
            <h3>
               Registered Card </h3>
        </div>
        <div class="buttons-panel">
            <ul>
             
           <%=Html.ActionLink("New", "Create", new { Controller = "CardRegistration" }, new { @class = "new" })%>
         
            
            <li><input type="submit" value="Search" class="search"/></li>
            </ul>
        </div>
    </div>

     <div id="ajaxResult"></div>
    <div class="contentGrid" id="result">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%" id="myTable">
        <thead>
        <tr>
        <th>S.N</th>
            <th>
            Card Number
            </th>
            <th>
            Card Type
            </th>
            <th>
            Card Value
            </th>
            <th>
            Expiry Date
            </th>
            <th>Status</th>
            <th></th>
            </tr>
              </thead>
                <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=item.CardId %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                
          <%: Html.ActionLink(item.CardNumber, "Details", new { id = item.CardId }, new { @class = "Details" })%>
          
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.CardType)%>
                    </td>
                    <td>
                        <%: String.Format("{0:F}", item.CardValue) %>
                    </td>
                    <td>
                        <%:  item.ValidTill.ToShortDateString() %>
                    </td>
                    <td>
                         <%: item.CardStatus %> 
                    </td>
                 
                    <td>
                        <p>
                             
                                <a href="/Hotel/CardRegistration/Edit/<%: item.CardId %>" class="edit" title="Edit"></a>
                                 <a href="#" class="delete" title="Delete" meta:id="<%:item.CardId %>"> </a>
                            <%--  <%: Html.ActionLink("Delete", "Delete", new { meta:id = "<%:item.CardId %>" }, new { @class = "delete" })%>--%>
                                    
                        </p>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
                    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>



 <script type="text/javascript">
     $(document).ready(function () {
         /////////////////////// POP UP Function //////////////////////////////////////
         $(function () {

             $('a.edit').live("click", function (event) {
                 loadDialog(this, event, '#contentGrid');

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


  

     $(".delete").live("click", function () {
         var id = $(this).attr("meta:id");
         if (confirm("Do you want to delete this record?")) {
             $.post("/CardRegistration/Delete",
		{ id: id },
		function (data) {
		    $("#tr_" + data).css("background-color", "lightgreen");
		    $("#tr_" + data).fadeOut("slow", function () { $(this).remove() });
		},
		"json"
        );
         }
         return false;
     });
      </script>

         
</asp:Content>
     
        

    