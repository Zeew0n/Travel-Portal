<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusCityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bus Cities
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
         <div class="float-right">
        <ul class="buttons-panel">
            <li>
                <%:Html.ActionLink("New", "Create", new { controller = "BusCity", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
    </div>
        <h3>
            Setup <span>&nbsp;</span> City Manager
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
    <div class="rptSearchResult">
        <%if (Model != null)
          {
              if (Model.TabularList.Count() > 0)
              {
                  var sno = 0; %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    S.No.
                </th>
                <th>
                    City Code
                </th>
                <th>
                    City Name
                </th>
                <th>
                    Status
                </th>
                <th>
                    Action
                </th>
            </thead>
            <tbody>
                <%foreach (var item in Model.TabularList)
                  {
                      sno++;
                      var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNo%>
                    </td>
                    <td>
                        <%:item.BusCityCode%>
                    </td>
                    <td>
                        <%:item.BusCityName %>
                    </td>
                    <td>
                        <%:item.StatusName %>
                    </td>
                    <td>
                        <p>
                            <%:Html.ActionLink("Edit", "Edit", new { id = item.BusCityId, controller = "BusCity", area = "Bus" }, new { @class = "", @title = "Edit" })%>
                            |
                            <%:Html.ActionLink("Delete", "Delete", new { id = item.BusCityId, controller = "BusCity", area = "Bus" }, new { @class = "", @title = "Delete", @onclick = "return confirm('Do you want to Delete (" + item.BusCityName + ")');" })%>
                        </p>
                    </td>
                </tr>
                <%  }%>
            </tbody>
        </table>
               <%-- <%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize)
                    {%>--%>
        <div class="pager">

         <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Bus.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Bus/BusCity/Index")))%>
        </div>
        <%}
              
              else
              { %>
        <%Html.Partial("Utility/VUC_NoRecordsFound"); %>
        <%  }
          }
          else
          {%>
        <% Html.Partial("Utility/VUC_NoRecordsFound");%>
        <%} %>
    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function RedirectPath(url) {
            var rowPageValue = $('#recordDisplayCount').val();
            document.location.href = url + "&pageRow=" + rowPageValue;
        }
    </script>
</asp:Content>
