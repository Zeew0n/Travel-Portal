<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Hotel.Models.HotelInfos>>" %>

<%@ Import Namespace="ATLTravelPortal.Areas.Hotel.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Hotel Information List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="box3">
        <div class="userinfo">
            <h3>
                Hotel Information</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                <%:Html.ActionLink("Add New", "Create", new { controller = "HotelInfo" }, new { @class = "new" })%>
                </li>
                
            </ul>
        </div>
    </div>
    <% Html.RenderPartial("VUC_DeleteDialogue"); %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <%-- <th>
                S.No.
            </th>--%>
                    <th>
                        HotelName
                    </th>
                    <th>
                        HotelCode
                    </th>
                    <%--  <th>
                Country
            </th>--%>
                    <th>
                        Web
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                        Phone
                    </th>
                    <th>
                        Active
                    </th>
                    <th>
                        Action
                    </th>
                     </tr>
            </thead>
           
            <%  var sno = 0;
                foreach (var item in Model)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <%--<td>
               <%=sno %>
            </td>--%>
                <td>
                    <%:Html.ActionLink(item.HotelName, "Detail", new { id = item.HotelId, controller = "HotelInfo" }, new {@class="Details" })%>
                    <%--<%: item.HotelName %>--%>
                </td>
                <td>
                    <%: item.HotelCode %>
                </td>
                <%-- <td>
                <%: item.CountryId%>
            </td>--%>
                <td>
                    <%: item.Web %>
                </td>
                <td>
                    <%:item.Email %>
                </td>
                <td>
                    <%:item.Address %>
                </td>
                <td>
                    <%: item.Phone %>
                </td>
                <td>
                    <%= item.isActive %>
                </td>
                <td>
                    <%: Html.ActionLink(" ", "Edit", new { id = item.HotelId },new{@class="edit"})%>
                    <%--<%: Html.ActionLink("Details", "Detail", new { id = item.HotelId }, new {@class="details", onclick = "ShowThickBox('Detail',this.href+'?keepThis=true&TB_iframe=true&height=300&width=500');return false;" })%>--%>
                    <%: Html.ActionLink(" ", "Delete", new { id = item.HotelId }, new {@class="delete", onclick = "ShowDeleteDialogue('hddnDeleteDialogueContent',this," + sno + ");return false;" })%>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            /////////////////////// POP UP Function //////////////////////////////////////
            $(function () {


                $('a.Details').live("click", function (event) {
                    loadDetailsDialog(this, event, '#contentGrid');

                });

            });
            /////////////////End of new fucntion/////////////////


        });   /* end document.ready() */    

</script>

</asp:Content>

