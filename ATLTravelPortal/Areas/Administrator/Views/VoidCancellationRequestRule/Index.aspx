<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.VoidCancellationRequestRuleModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
     <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "VoidCancellationRequestRule" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Void Cancellation Request Rule</strong>
            </h3>
        </div>
    </div>

    <div class="contentGrid">
        
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView tablesorter" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                       Products 
                    </th>
                    <th>
                        Sunday
                    </th>
                    <th>
                        Monday
                    </th>
                    <th>
                        Tuesday
                    </th>
                    <th>
                        WednesDay
                    </th>
                    <th>
                        ThrusDay
                    </th>
                    <th>
                        FriDay
                    </th>
                    <th>
                        SaturDay
                    </th>
                    <th>
                        From Time
                    </th>
                    <th>
                        To Time
                    </th>
                    <th>
                        Within Hours
                    </th>
                    <th>
                        RuleOn
                    </th>
                </tr>
            </thead>
            <tbody>
            <% if (Model != null)
               { %>
        <%if (Model.VoidCancellationRequestList != null && Model.VoidCancellationRequestList.Count() > 0)
          { %>
                <%  var sno = 0;


                    foreach (var item in Model.VoidCancellationRequestList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%: item.Product%>
                    </td>
                    <% if (item.SunDay)
                       { %>
                    <td>
                       <%: Html.CheckBox("SunDay", true, new { disabled = "disabled" })%>SunDay
                    </td>
                    <%}
                       else
                       {%>
                     <td>
                       <%: Html.CheckBox("SunDay", false, new { disabled = "disabled" })%>SunDay
                    </td>
                    <%} %>
                        <% if (item.MonDay)
                           { %>
                    <td>
                       <%: Html.CheckBox("MonDay", true, new { disabled = "disabled" })%>MonDay
                    </td>
                    <%}
                           else
                           {%>
                     <td>
                       <%: Html.CheckBox("MonDay", false, new { disabled = "disabled" })%>MonDay
                    </td>
                    <%} %>
                  <% if (item.TuesDay)
                     { %>
                    <td>
                       <%: Html.CheckBox("TuesDay", true, new { disabled = "disabled" })%>TuesDay
                    </td>
                    <%}
                     else
                     {%>
                     <td>
                       <%: Html.CheckBox("TuesDay", false, new { disabled = "disabled" })%>TuesDay
                    </td>
                    <%} %>
                    <% if (item.WednesDay)
                       { %>
                    <td>
                       <%: Html.CheckBox("WednesDay", true, new { disabled = "disabled" })%>WednesDay
                    </td>
                    <%}
                       else
                       {%>
                     <td>
                       <%: Html.CheckBox("WednesDay", false, new { disabled = "disabled" })%>WednesDay
                    </td>
                    <%} %>
                   <% if (item.ThrusDay)
                      { %>
                    <td>
                       <%: Html.CheckBox("ThrusDay", true, new { disabled = "disabled" })%>ThrusDay
                    </td>
                    <%}
                      else
                      {%>
                     <td>
                       <%: Html.CheckBox("ThrusDay", false, new { disabled = "disabled" })%>ThrusDay
                    </td>
                    <%} %>
                    <% if (item.FriDay)
                       { %>
                    <td>
                       <%: Html.CheckBox("FriDay", true, new { disabled = "disabled" })%>FriDay
                    </td>
                    <%}
                       else
                       {%>
                     <td>
                       <%: Html.CheckBox("FriDay", false, new { disabled = "disabled" })%>FriDay
                    </td>
                    <%} %>
                    <% if (item.SaturDay)
                       { %>
                    <td>
                       <%: Html.CheckBox("SaturDay", true, new { disabled = "disabled" })%>SaturDay
                    </td>
                    <%}
                       else
                       {%>
                     <td>
                       <%: Html.CheckBox("SaturDay", false, new { disabled = "disabled" })%>SaturDay
                    </td>
                    <%} %>
                    <td>
                        <%: item.FromTime%>
                    </td>
                    <td>
                        <%: item.ToTime%> 
                    </td>
                    <td>
                        <%: item.WithinHour%>
                    </td>
                    <td>
                        <%: item.RuleOn%>
                    </td>
                    <td>
                         <%-- <a href="/Administrator/CountryManagement/Detail/<%:item.CountryId %>" class="details" title="Details"> </a>--%>
                       
                        <a href="/Administrator/VoidCancellationRequestRule/Edit/<%:item.VoidCancellationRuleId %>" class="edit" title="Edit"></a>
                        <a href="/Administrator/VoidCancellationRequestRule/Delete/<%:item.VoidCancellationRuleId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </td>
                    
                </tr>
                <% } %>
                <%}%>
               
              <% else
            {
                Html.RenderPartial("NoRecordsFound");
            }
                    %>
                
            </tbody>
            
            
        </table>
       
      

        <%} %>
     
      </div> 
  
</asp:Content>
