<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>

   <div class="contentGrid" id="result">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%" id="myTable">
        <thead>

        <tr>
        <th>Select</th>
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
                    if (Model.agentcardmodel  != null)
                    {
            %>
          
                
    <% using (Html.BeginForm("Create", "CustomerCard", FormMethod.Get))
       {%>
    

            <% var sno = 0;

               foreach (var item in Model.agentcardmodel  )
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

   

          <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                      <%--  <%:Html.CheckBox("Selectedcardnumber", new { @value = item.CardNumber })%>--%>
                        <input type="checkbox" value="<%=item.CardNumber%>" name="Selectedcardnumber" />
                    </td>
                    <td>
                       <%: Html.ActionLink(item.CardNumber, "Details", new { controller = "CardRegistration", id=item.HFCardId }, new { @class = "Details" })%>
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
               
            <%} %>

    
                    <input type="submit" value="Issue" class="btn3"/>
                    <%: Html.HiddenFor(model => model.AgentId)%>
               <%}
                    }%>
        </table>

                    </div>
                    

<script type="text/javascript">
    $(".delete").live("click", function () {
        var id = $(this).attr("meta:id");
        if (confirm("Do you want to delete this record?")) {
            $.post("/IssueCard/Delete",
		{ id: id },
		function (data) {
		    $("#cardrow-" + data).css("background-color", "lightgreen");
		    $("#cardrow-" + data).fadeOut("slow", function () { $(this).remove() });
		},
		"json"
	);
        }
        return false;
    });
             </script>