<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
  <%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   Listing all Agent Payment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "DistributorAgentPayment" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a class="icon_plane" href="#">Account Management</a> <span>&nbsp;</span><strong>Deposit Update</strong>
            </h3>
        </div>
            <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="row-1">
    
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                         <%: Html.LabelFor(model => model.AgencyName)%></label>
                          <%:Html.TextBoxFor(model => model.AgencyName)%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
                  <input type="button" onclick="document.location.href='/Administrator/DistributorAgentPayment/Index'"
                    value="Show All" />
                   <%-- <%:Html.ActionLink("View Unapproved Payment", "Index", new { controller = "UnApproveMakePayment" }, new { @class = "linkButton float-right" })%>--%>
            </p>

        </div>
    </div>
    <% } %>
    </div>
     <div id="AgentPaymentContainer">
    <%Html.RenderPartial("VUC_Index"); %>
    </div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $(function () {
                $("#AgencyName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Administrator/AjaxRequest/FindAgentName", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfAgentId").val(ui.item.id);
                    }

                });
            });



        });
        //////////////End of document Ready function/////////////////////


       
    </script>
</asp:Content>