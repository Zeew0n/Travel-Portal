<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%
    int TotalPages = Int32.Parse(ViewData["TotalPages"].ToString());
    int CurrentPage = Int32.Parse(ViewData["CurrentPage"].ToString());
    
    
%>
<table class="grid_tbl paging" border="0" width="100%">
    <tr>
        <td>
                
            <%=Ajax.ActionLink("<<First", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = 1 },
            new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 

            <%=Ajax.ActionLink("Previous", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = CurrentPage, flag = 1 },
            new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                &nbsp;&nbsp;Page&nbsp;&nbsp;<%=CurrentPage%>&nbsp;of &nbsp;<%=TotalPages%>&nbsp;&nbsp;
            <%=Ajax.ActionLink("Next", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = CurrentPage, flag = 2 },
            new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                     
            <%=Ajax.ActionLink("Last>>", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = TotalPages },
            new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
  
        </td>
    </tr>
    </table>