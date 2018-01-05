<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineFlighClassViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Airline Flight Class Definition
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div 


        <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                </li>
            <li>
                 <a href="/Airline/DomesticFlightClass/Create" class="new linkButton" title="New">Create</a>            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong>Domestic Flight Class Definition</strong>
        </h3>
    </div>






 <%var q = (from p in Model.AirlineFlighClass select new { p.AirlineId,p.AirlineName }).Distinct().ToList(); %> 

<% for (int i = 0; i < q.Count(); i++)
   {%>
 <%var item = (from l in Model.AirlineFlighClass where l.AirlineId == q.ToList()[i].AirlineId select l).OrderByDescending(qq => qq.AirlineName).ToList(); %>

 <div class="type-option" style=" margin-bottom:-10px; margin-top:15px;"><label></label> 
 <h5> Class Code  - <strong><%:item.ElementAtOrDefault(0).AirlineName%></strong></a></h5>
</div>

      <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
           
          
            <th>ClassType</th>
            <th>Flight Code</th>
            
            <th>Action</th>           
        </thead>

       


        <% for (int m = 0; m < item.Count(); m++)
           { %>


     <% var sno = 0;

        sno++;
        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

       <tbody >
         <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">           
    
                
            
            <td>
               <%: item[m].ClassType%>
            </td>
                <td>
             <%: item[m].FlightClassCode%>
                
            </td>
             <td>
              
                    <p><a href="/Airline/DomesticFlightClass/Edit?id=<%: item[m].FlightClassId %>" class="edit" title="Edit"></a>
                    <%--<a href="/DomesticFlightClass/Delet/<%:item.FlightClassId %>" class="delete" title="Delete"  onclick = "return confirm('Are you sure you want to delete?')"></a>--%>
                    <%:Html.ActionLink(" ", "Delete", new { id = item[m].FlightClassId }, new { @class = "delete", @title = "Delete", onclick = "return confirm('Are you sure you want to delete?')" })%></p>

             </td>
        </tr> 

        </tbody>
        <%} %>
    </table>
     
   
  </div>
  <%} %>
  <p style="color:Red">
   <%:TempData["Message"] %>
   </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<style type="text/css">
        label.error
        {
            color: red;
            margin-right: 21px;
            text-align: center;
            width: 10px !important;
            float: right !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">


 <script type="text/javascript">

     $(function () {

         $('a.edit').live("click", function (event) {
             loadDialog(this, event, '#contentGrid');
         
          });
         $('a.new').live("click", function (event) {
             loadDialog(this, event, '#contentGrid');
       
          });

     }); /* end document.ready() */

     function loadDialog(tag, event, target) {
         event.preventDefault();
         var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
         var $url = $(tag).attr('href');
         var $title = $(tag).attr('title');
         var $dialog = $('<div></div>');
         $dialog.empty();
         $dialog
            .append($loading)
            .load($url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 500
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'slide'
		    });

        
         $dialog.dialog('open');
     };

     function displayError(message, status) {
         var $dialog = $(message);
         $dialog
                .dialog({
                    modal: true,
                    title: status + ' Error',
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                        }
                    }
                });
         return false;
     };

     function confirmDelete(message, callback) {
         var $deleteDialog = $('<div>Are you sure you want to delete ' + message + '?</div>');

         $deleteDialog
            .dialog({
                resizable: false,
                height: 140,
                title: "Delete Record?",
                modal: true,
                buttons: {
                    "Delete": function () {
                        $(this).dialog("close");
                        callback.apply();
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
     };

     function deleteRow($btn) {
         $.ajax({
             url: $btn.attr('href'),
             //type: 'POST',
             success: function (response) {
                 $("#ajaxResult").hide().html(response).fadeIn(300, function () {
                     var e = this;
                     setTimeout(function () { $(e).fadeOut(400); }, 2500);
                 });
             },
             error: function (xhr) {
                 displayError(xhr.responseText, xhr.status); /* display errors in separate dialog */
             }
         });
         return false;
     };

    </script>
  
 

</asp:Content>




