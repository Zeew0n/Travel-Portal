<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusCategoryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bus Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="float-right">
            <li>
                <%:Html.ActionLink("New", "Create", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span> Category Manager
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
                    Category Name
                </th>
                <th>
                    Action
                </th>
            </thead>
            <tbody>
                <%foreach (var item in Model.TabularList)
                  {
                      //sno++;
                      var classTblRow = (sno % 2 == 0) ? "GridItem" : "GridAlter"; %>
                <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNo %>
                    </td>
                    <td>
                        <%:item.BusCategoryName%>
                    </td>
                    <td>
                        <p>
                            <%:Html.ActionLink("Detail", "Details", new { id = item.BusCategoryId, controller = "BusCategory", area = "Bus" }, new { @class = "", @title = "Details" })%>
                            |
                            <%:Html.ActionLink("Edit", "Edit", new { id = item.BusCategoryId, controller = "BusCategory", area = "Bus" }, new { @class = "", @title = "Edit" })%>
                            |
                            <%:Html.ActionLink("Delete", "Delete", new { id = item.BusCategoryId, controller = "BusCategory", area = "Bus" }, new { @class = "", @title = "Delete", @onclick = "return confirm('Do you want to Delete (" + item.BusCategoryName + ")');" })%>
                        </p>
                    </td>
                </tr>
                <%  }%>
            </tbody>
        </table>
        <%--<%  if (Model.TabularList.TotalItemCount > ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize)
            {%>--%>
        <div class="pager">
      <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Bus.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Bus/BusCategory/Index")))%>
            
        </div>
        <%}
              //}
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
    <%-- <div class="buttonBar">
        <ul class="buttons-panel">
            <li>
                <%:Html.ActionLink("Create", "Create", new { controller = "BusCategory", area = "Bus" }, new { @class = "linkButton" })%>
            </li>
        </ul>
    </div>--%>
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
