<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.FXRateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <div class="float-right">
            <p>
                <input type="submit" value="Save" />
                <input type="button" value="Cancel" id="cancelButton" />
            </p>
        </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>FX Rate Setting</strong>
        </h3>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.ExchangeRate) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.ExchangeRate) %>
        <%: Html.ValidationMessageFor(model => model.ExchangeRate, "*") %>
    </div>
    <% } %>
    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                <th>
                SNo
                </th>
                    <th>
                        Rate
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                        Approved
                    </th>
                </tr>
            </thead>
            <% 
                var sno = 0;
                foreach (var item in Model.FXRateList)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                <%:item.SNO %>
                </td>
                <td>
                    <%: String.Format("{0:F}", item.ExchangeRate) %>
                </td>
                <td>
                    <%: item.CreatedDate.ToShortDateString() %>
                </td>
                <td>
                    <%: item.isApproved %>
                </td>
            </tr>
            <% } %>
        </table>

         <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.FXRateList.PageSize, ViewData.Model.FXRateList.PageNumber, ViewData.Model.FXRateList.TotalItemCount )%>
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $("#cancelButton").live("click", function () {
                $("#ExchangeRate").val('');
            });

        });
    </script>
</asp:Content>
