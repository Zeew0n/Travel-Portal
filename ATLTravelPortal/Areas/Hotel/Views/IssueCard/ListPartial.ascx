<%@ Control Language="C#"Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>

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
            Valid Date
            </th>
           
            <th></th>
            </tr>
              </thead>
                <%
                    if (Model != null)
                    {
            %>
             <% using (Html.BeginForm("Create", "IssueCard", FormMethod.Get))
                {%>
            <% var sno = 0;

               foreach (var item in Model.agentcardmodel)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=item.HFCardId %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>

                       <%: Html.ActionLink(item.CardNumber, "Details", new { id = item.HFCardId }, new { @class = "Details" })%>
         <%-- <a href="Cardregistration/Details<%= item.HFCardId%>" class="Details" title="Details"> </a>--%>
                    </td>
                     <td>
                         <%: item.CardValue%> 
                    </td>
                    <td>
                        <%:  item.IssueDate.ToShortDateString()%>
                    </td>
                    <td>
                         <%: item.CardType%> 
                    </td>
                 
                    <td>
                        <p> 
                            
                               
                                  <a href="#" class="delete" title="Delete" meta:id="<%:item.HFCardId %>"> </a>
                                    
                        </p>
                    </td>
                </tr>
            </tbody>
            <%}
                }
                    } %>
        </table>
                    </div>

                   
      

 <script type="text/javascript">
    

     $(".delete").live("click", function () {
         var id = $(this).attr("meta:id");
         if (confirm("Do you want to delete this record?")) {
             $.post("/IssueCard/Delete",
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