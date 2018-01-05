<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.B2CVisitorInfoModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Visitor Info 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Visitor Info</strong>
            </h3>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.ListB2CVisitorInfo != null && Model.ListB2CVisitorInfo.Count() > 0)
          { %>
        <div class="contentGrid">
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Address
                        </th>
                        <th>
                            Email
                        </th>
                        <th>
                            Contact No
                        </th>
                        <th>
                            Source
                        </th>
                        <th>
                            Type
                        </th>
                        <th>
                            Profession
                        </th>
                        <th>
                            Created Date
                        </th>
                    </tr>
                </thead>
                <%  var sno = 0;
                    foreach (var item in Model.ListB2CVisitorInfo)
                    {

                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr id="tr_<%= sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SN0%>
                    </td>
                    <td>
                        <%: item.Name %>
                    </td>
                    <td>
                        <%: item.Address %>
                    </td>
                    <td>
                        <%: item.Email %>
                    </td>
                    <td>
                        <%: item.ContactNo %>
                    </td>
                    <td>
                        <%: item.SRC %>
                    </td>
                    <td>
                        <%: item.Type %>
                    </td>
                    <td>
                        <%: item.Profession %>
                    </td>
                    <td>
                        <%: TimeFormat.DateFormat( item.CreatedDate.ToString()) %>
                    </td>
                </tr>
                <% } %>
            </table>
             <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.ListB2CVisitorInfo.PageSize, ViewData.Model.ListB2CVisitorInfo.PageNumber, ViewData.Model.ListB2CVisitorInfo.TotalItemCount)%>
       </div>
        </div>
        <%}  %>
        <%} %>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
</asp:Content>
