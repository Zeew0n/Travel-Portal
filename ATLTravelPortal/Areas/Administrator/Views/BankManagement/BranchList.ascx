<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
             <th>
                SN
            </th>
            <th>
                BranchName
            </th>
            <th>
                PhoneNo
            </th>
            <th>
                ContactPerson
            </th>
            
            <th>Action</th>
        </thead>


         <%
             if (Model != null)
             {
         %>
     <% var sno = 0;

        foreach (var item in Model.GetAllBranch)
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
                <%:item.BranchName %>
                
            </td>
            <td>
                <%: item.BranchPhoneNumber %>
            <td>
                <%:item.BranchContactPerson %>
            </td>
            
            <td>
           
                  <p>        
                  <%:Ajax.ActionLink(" ", "Detail", "BankManagement", new { id = item.BankBranchId }, new AjaxOptions { UpdateTargetId = "Detail", HttpMethod = "GET", OnComplete="Unhide"}, new { @class = "details", title = "Details" })%>
                   <%--<%:Html.ActionLink(" " ,"Detail",new{id = item.BankBranchId},new{@class="details",title="Details",@onclick="Details()"}) %>--%>
                     <%--<input type="button" id="detail" class="details" onclick="Details(); value=<%:item.BankBranchId %>"  />--%>
                      <%:Ajax.ActionLink(" ", "Edit", "BankManagement", new { id = item.BankBranchId }, new AjaxOptions { UpdateTargetId = "Detail", HttpMethod = "GET", OnComplete = "EditUnhide" }, new { @class = "edit", title = "Edit" })%>
                      <%:Ajax.ActionLink(" ", "Delete", "BankManagement", new { id = item.BankBranchId }, new AjaxOptions {Confirm="Are You Sure",HttpMethod="POST" }, new { @class = "delete", title = "Delete" })%>
                     
                      
                          
                       </p>
             </td>
        </tr> 
          
        </tbody>
        <%}
             } %>
             
    </table>
  </div>
  <script language="javascript" type="text/javascript">

      function Unhide() {
          $("#Detail").css('visibility', 'visible');
          $("#Detail").insertBefore("#Sectors");
      }
      function EditUnhide() {
          $("#Detail").css('visibility', 'visible');
          $("#Detail").insertBefore("#Sectors");
      }
  </script>