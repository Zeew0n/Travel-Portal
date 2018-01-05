<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentClassDealModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Branch Class
                    Deal</strong>
            </h3>
        </div>
    </div>
    <%using (Html.BeginForm("Index", "BranchClassDeal", FormMethod.Post, new { @class = "validate" }))
      { %>
    <div id="ListTable">
        <%Html.RenderPartial("ListPartial"); %>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">
        function SaveBranchClassDeal(id) {

            $("#loading_" + id).html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            branchClassId = $("#AgentClassId_" + id).val();
            masterDealId = $("#MasterDealId_" + id).val();
            hotelMasterDealId = $("#HotelMasterDealId_" + id).val();
            busMasterDealId = $("#BusMasterDealId_" + id).val();
            mobileMasterDealId = $("#MobileMasterDealId_" + id).val();

            $.ajax({
                type: "POST",
                url: '/Administrator/BranchClassDeal/Index',
                data: { branchClassId: branchClassId, masterDealId: masterDealId, hotelMasterDealId: hotelMasterDealId, busMasterDealId: busMasterDealId, mobileMasterDealId: mobileMasterDealId },
                dataType: "html",
                async: true,
                cache: false,
                success: function (serverResponse) {
                    if (serverResponse == 'true') {
                        $("#lblSuccess_" + id).toggle().empty().html('<font color="green"><strong>Saved Successfully.&nbsp;&nbsp;</strong></font>').fadeOut(10000, function () { $(this).hide() });
                    }
                    else if (serverResponse == 'false') {
                        alert('Sorry, Some error occurred');
                    }
                    $("#loading_" + id).html('');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('Sorry, Some error occurred');
                    $("#loading_" + id).html('');
                }
            });
        }    
    </script>
</asp:Content>

