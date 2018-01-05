<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Credit Limit Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (TempData["error"] != null)
 { %>
    <%: TempData["error"]%>
    <%}%>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%:Html.ActionLink("New", "Create", new { controller = "AgentCreditLimit" }, new { @class = "linkButton" })%></li>
            </ul>
        </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Credit Limit Management</strong>
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
                        <%:Html.AutoCompleteFor(model => Model.AgencyName, x => x.AgencyName, "ListAllAgency", "Administrator/AjaxRequest", 3)%>
                        <%--  <%:Html.TextBoxFor(model => model.AgencyName)%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.AgencyName)%>
                    <%:Html.HiddenFor(model => model.hdfAgentId)%>--%>
                    </div>
                </div>
            </div>
        </div>
        <%-- <div class="form-box1-row">
            <p class="mrg-lft-130 float-left">
                <input type="submit" value="Search" class="btn3" />
                  <%:Html.ActionLink("View Unapproved Credit Limit", "UnapprovedCreditLimit", new { controller = "AgentCreditLimit" }, new { @class = "linkButton float-right" })%>
            </p>
             <p class="float-right"><span class="activeHgh"></span>:Valid&nbsp;&nbsp;| <span class="inactiveHgh"></span>:Expired</p>
        </div>--%>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
                <%:Html.ActionLink("View Unapprove Credit Limit", "UnapprovedCreditLimit", new { controller = "AgentCreditLimit" }, new { @class = "linkButton float-right" })%>
            </p>
            <% if(Model.ShowHideAmountType == true){ %>
            <p class="float-left" style=" margin-top:5px; ">
                <label style="width:125px; float:left; margin-right:6px; text-align:right;">
                    <%: Html.Label("Amount Type")%></label>
                <% List<SelectListItem> StatusList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "0", Text = "Active Amount"},
                                        new SelectListItem {Selected = false, Value = "1", Text = "Expired Amount"},
                                         new SelectListItem {Selected = false, Value = "2", Text = "All"},
                                         
                                    };%>
                <%:Html.DropDownListFor(model => model.AmountType, StatusList)%>
            </p>
            <%} %>
            <p class="float-right">
                <span class="activeHgh"></span>:Valid Amount&nbsp;&nbsp;| <span class="inactiveHgh">
                </span>:Expired Amount</p>
        </div>
    </div>
    <% } %>
    <div class="contentGrid">
        <div id="Amount">
            <%Html.RenderPartial("VUC_Index", Model);%>
          
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/global.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        $("#AmountType").live("change", function () {

            var AmountType = $("#AmountType").val();

            if (AmountType == "") {
                return false;
            }
            else {
                $.ajax({
                    type: "GET",
                    url: "/Administrator/AgentCreditLimit/Index",
                    data: { AmountType: AmountType },
                    dataType: "html",
                    success: function (result) {

                        $("#Amount").empty().append(result);
                    }
                });
            }

        }).change();
    </script>
</asp:Content>
