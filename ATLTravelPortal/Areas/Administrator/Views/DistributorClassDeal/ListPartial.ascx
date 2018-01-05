<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.AgentClassDealModel>" %>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;
        font-size: 13px;" class="GridView" width="100%" id="myTable">
        <thead>
            <th>
                Class
            </th>
            <th>
                Airline Deal
            </th>
            <th>
                Hotel Deal
            </th>
            <th>
                Bus Deal
            </th>
             <th>
                Mobile Deal
            </th>
            <th>
            </th>
        </thead>
        <%
            if (Model != null)
            {
                if (Model.AgentClassList != null)
                {
        %>
        <% var sno = 0;

           foreach (var item in Model.AgentClassList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
               item.CreatedBy = sno;
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <%Html.RenderPartial("VUC_AgentClassDealRow", item); %>
            </tr>
        </tbody>
        <%}
                }

            } %>
    </table>
</div>
