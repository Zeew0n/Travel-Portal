<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentTeleLogsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm("Create", "AgentTeleLogs", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
       { %>
    <div class="pageTitle">
        <div class="float-right">
            <input type="submit" value="Save" />
            <input type="button" onclick="document.location.href='/Administrator/AgentTeleLogs/Index'"
                value="Cancel" />
        </div>
        <h3>
            <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Tele
                Logs</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AgentName) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.AgentName, new { @style = "width:300px;" })%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.AgentName)%>
                    <%:Html.HiddenFor(model => model.hdfAgentId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Title) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.Title, new { @style = "width:300px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.ContactPerson) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.ContactPerson, new { @style = "width:300px;" })%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.ContactPerson)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.ContactNumber) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.ContactNumber, new { @style = "width:300px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Problem Category</label>
                    <% List<SelectListItem> ProblemCategoryList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "Fares", Text = "Fares"},
                                        new SelectListItem {Selected = false, Value = "Accounts", Text = "Accounts"},
                                        new SelectListItem {Selected = false, Value = "Online Training", Text = "Online Training"},
                                        new SelectListItem {Selected = false, Value = "Technical issues", Text = "Technical issues"},
                                        new SelectListItem {Selected = false, Value = "Tour packages", Text = "Tour packages"},
                                        new SelectListItem {Selected = false, Value = "Taxi/car", Text = "Taxi/car"},
                                        new SelectListItem {Selected = false, Value = "Railways", Text = "Railways"},
                                        new SelectListItem {Selected = false, Value = "Hotels", Text = "Hotels"},
                                        new SelectListItem {Selected = false, Value = "Insurance", Text = "Insurance"}
                                         
                                    };%>
                    <%:Html.DropDownListFor(model => model.ProblemCategoryId, ProblemCategoryList, "---Select---", new { @style = "width:125px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Remarks) %>
                    </label>
                    <%:Html.TextAreaFor(model => model.Remarks, new { @style = "width:300px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.CompetitorInformation) %>
                    </label>
                    <%:Html.TextAreaFor(model => model.CompetitorInformation, new { @style = "width:300px;" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.isNeededFollowUp) %>
                    </label>
                    <%: Html.CheckBoxFor(model=>model.isNeededFollowUp) %>
                </div>
            </div>
        </div>
    </div>
  <%--  <div class="buttonBar">
        <input type="submit" value="Save" />
         <input type="button" onclick="document.location.href='/Administrator/AgentTeleLogs/Index'"
            value="Cancel" />
    </div>--%>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $(function () {
                $("#AgentName").autocomplete({
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
