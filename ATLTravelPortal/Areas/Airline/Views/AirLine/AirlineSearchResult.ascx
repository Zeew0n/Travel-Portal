<%--<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AirLines.DataModel.Airlines>>" %>--%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Linq.EnumerableQuery<ATLTravelPortal.Areas.Airline.Models.AirLines>>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%------------------------  Data for paging ------------------------%>
<%--<% int numberOfPage = Int32.Parse(ViewData["TotalPages"].ToString());
   int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%>--%>
<%------------------------End  Data for paging ------------------------%>
<%--
                       <%using (Html.BeginForm("Index", "Airline", FormMethod.Post))
                  {%>
   
              <%:Html.CheckBox("IsActive",false, new { onchange = "this.form.submit();" })%>
           <%} %>--%>

<%-- <input type="button" onclick="Activate(this)" value="Activate" name="submit" id="Active" />
 <input type ="button" onclick="Activate(this)" value="Deactivate" name="submit" id="InActive" />--%>
  <%--<%=Ajax.ActionLink("InActive", "InActive", new { controller = "Airline", action = "InActive" }, new AjaxOptions() { HttpMethod = "Post" })%>--%>
  <div id="sortMsg" style="text-align:center;color:Red;"></div>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%" id="myTable">
        <thead>
        <tr>
            <th>
                &nbsp;<%:Html.CheckBox("All", new { @class = "ChkBoxParent" })%> &nbsp;All
            </th>
            
            <th>
                Airline Code
            </th>
            <th>
                Airline Name
            </th>
             <th>
                Country Name
            </th>
            <%--<th>
                Photo
            </th>--%>
            <th>
                Action
            </th>
            </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <%--<% var sno = ((currentPage - 1) * ((int)PageSize.JePageSize));--%>
         <tbody>
         <% var sno = 0;
                foreach (var item in Model)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
               //string location = "~/AirlineUploads/" + item.AirlineCode + "/" + item.AirlineName + "/" + item.Photo;
               string location = "~/AirlineUploads/" + item.AirLineCode + "/" + item.txtAirLineName + "/" + item.Photo;
        %>
       
            <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                   <%-- <input type="checkbox" name="chkAirLine" value="<%:item.AirlineId %>" class="ChkBoxChild" id="AirlineList" />--%>
                    <input type="checkbox" name="chkAirLine" value="<%:item.AirLineId %>" class="ChkBoxChild" id="AirlineList" />
                  
   
                </td>
                
                <td>
                    <%--<%: item.AirlineCode%>--%>
                    <%:item.AirLineCode %>
                </td>
                <td>
                    <%--<%: item.AirlineName%>--%>
                    <%:item.txtAirLineName %>
                </td>
                <td>
                    <%--<%: item.AirlineName%>--%>
                    <%:item.CountryName %>
                </td>
                <%--<td>
                    <img src="<%=Url.Content("~/AirlineUploads/" + item.AirlineCode + "/" + item.AirlineName + "/" + item.Photo) %>"
                        alt="Airline Logo" width="40px" height="40px" />
                </td>--%>
                <td>
                    <p>
                        <%--<a href="/AirLine/Edit/<%: item.AirlineId %>" class="edit" title="Edit"></a>--%>
                         <%:Html.ActionLink(" ", "Details", new { id = item.AirLineId }, new { @class = "details", @title = "Details" })%>
                        <%:Html.ActionLink(" ", "Edit", new { id = item.AirLineId }, new {@class="edit",@title="Edit" })%>
                        <%:Html.ActionLink(" ", "Delete", new { id = item.AirLineId }, new { @class = "delete", @title = "Delete", onclick = "return confirm('Are you sure you want to delete?')" })%>
                    </p>
                </td>
            </tr>
            <%} %>
        </tbody>
        <%}
              %>
    </table>
</div>

<div class="paging">
    <table class="grid_tbl" border="0" width="100%">
        <tr>
           <%-- <td>
                <div class="left">
                    <%=Ajax.ActionLink("<<First", "Index", new { controller = "Airline", action = "Index", pageNo = 1 },
        new AjaxOptions() { UpdateTargetId = "Airline",OnBegin = "beginList", OnSuccess = "successList" , InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    <%=Ajax.ActionLink("Previous", "Index", new { controller = "Airline", action = "Index", pageNo = currentPage, flag = 1 },
        new AjaxOptions() { UpdateTargetId = "Airline",OnBegin = "beginList", OnSuccess = "successList" ,InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                    <%=Ajax.ActionLink("Next", "Index", new { controller = "Airline", action = "Index", pageNo = currentPage, flag = 2 },
        new AjaxOptions() { UpdateTargetId = "Airline",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    <%=Ajax.ActionLink("Last>>", "Index", new { controller = "Airline", action = "Index", pageNo = numberOfPage },
        new AjaxOptions() { UpdateTargetId = "Airline",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                </div>
            </td>--%>
        </tr>
    </table>
</div>
<div  id="loadingIndicator">
</div>
 <script type="text/javascript">

     //Cheked/UnChecked all child check box if parent check box is Checked/Unchecked .
     $('.ChkBoxParent').live("click", function () {
         $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
         
     });

     $('.ChkBoxChild').live("click", function () {
         var childCheckBox = $('.ChkBoxChild');
         var checkedAllStatus = true;
         for (var i = 0; i < childCheckBox.length; i++) {
             if (!$(childCheckBox[i]).is(':checked')) {
                 checkedAllStatus = false;
             }
         }
         $('.ChkBoxParent').attr('checked', checkedAllStatus);
     });
//     $(document).ready(function () {
//         $("#myTable").tablesorter();
//     }
//); 
   
    </script>