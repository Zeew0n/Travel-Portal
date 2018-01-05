<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentTeleLogsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm("Edit", "AgentTeleLogs", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
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

   <%-- <div class="buttonBar">
        <input type="submit" value="Save" />
        <input type="button" onclick="document.location.href='/Administrator/AgentTeleLogs/Index'"
            value="Cancel" />
    </div>--%>
    <%} %>




       <% using (Html.BeginForm("Comment", "AgentTeleLogs", new { id = Model.AgentTeleLogId }, FormMethod.Post))
       { %>
    <div class="reportFilter">
    <h3 class="borderBtm headingTlt">
        <strong>Comment Section</strong>
    </h3>
    <div style="overflow: hidden;">
        <%if (Model.CommentList != null)
          {
          
        %>
        <%foreach (var item in Model.CommentList)
          {
              var telelogid = item.AgentTeleLogId;
              var commentid = item.commentid;
              var createdby = item.CreatedBy;
        %>
        <div style="width: 400px;">
            <%  ATLTravelPortal.Helpers.TravelSession ts = (ATLTravelPortal.Helpers.TravelSession)Session["TravelPortalSessionInfo"];%>
            <% if (ts.AppUserId == item.CreatedBy)
               { %>
            <p>
                <span class="float-right">
                    <%:Html.ActionLink(" ", "DeleteAgentTeleLogComment", "AjaxRequest", new { telelogid = telelogid, commentid = commentid }
         , new { @class = "delete", @onclick = "return confirm('Are you sure you want to delete the comment?')" })%>
                </span>
                <%} %>
                <span class="float-left" style="margin-right: 11px; margin-top: 4px;">
                    <img src="../../../../Content/images/icons/comment.png" /></span> <span style="color: #FF7902">
                        <%: item.CreatedName%>
                        On
                        <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.CreatedDate.ToString())%>:</span>
            </p>
            <p style="border: 1px solid #eaeaea; padding: 5px; width: 400px; margin-bottom: 10px;
                margin-left: 43px;">
                <%:item.Comment%>
            </p>
        </div>
        <%} %>
        <%} %>
        <div class="divLeft">
            <label>
            </label>
            <%: Html.TextAreaFor(model => model.Comment, new { @Style = " width:400px; margin-left:43px; padding:5px;" })%><span class="redtxt">*</span>
            <%: Html.ValidationMessageFor(model=>model.Comment) %>
        </div>
    </div>
</div>
<div class="buttonBar" style="width: 455px; border-top: none; margin-top: 0px;">
    <input type="submit" value="Post Comment" class="btn3" />
    
</div>
    <%} %>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
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