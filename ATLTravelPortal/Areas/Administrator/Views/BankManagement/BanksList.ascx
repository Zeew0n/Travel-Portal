<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
             <th>
                SN
            </th>
            <th>
                Bank 
            </th>
            <th>
                PhoneNo
            </th>
            <th>
                Contact Person
            </th>
            
            <th>Action</th>
        </thead>


         <%
             if (Model != null)
             {
         %>
     <% var sno = 0;

        foreach (var item in Model.BankList)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

       <tbody >
    <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
           
          <td>
                <%:sno%>
            </td>
            <td>
                <%:item.BankName %>
                
            </td>
            <td>
                <%: item.PhoneNo %>
            <td>
                <%:item.ContactPerson %>
            </td>
            
            <td>
           
                  <p>        
                    
                    <%:Html.ActionLink(" ", "Detail", new { controller = "BankManagement",id= item.BankId }, new {@class="details",title="Details" })%>
                     <%:Html.ActionLink(" ","Edit",new{controller="BankManagement",id = item.BankId},new{@class="edit",title="Edit"})%> 
                      <%:Html.ActionLink(" ", "Delete", new { id = item.BankId, controller = "BankManagement" }, new { @class = "delete", @title = "Delete", onclick = "return confirm('Are you sure want to delete?')" })%>
                      
                          
                       </p>
             </td>
        </tr> 
          
        </tbody>
        <%}
             } %>
             
    </table>
  </div>