<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentMessageBoardModel>" %>

    <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Message Board:Arihant Holidays
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <%using (Html.BeginForm())
      {%>
 
    <div class="pageTitle">
        <div class="float-right">
            	<ul>
                <li>
                    <%:Html.ActionLink("New", "Create", new { controller = "AgentMessageBoard" }, new { @class = "linkButton" })%>
                    <%-- <input type="button" value="New" class="new" onclick="document.location.href='/AgentTicketSalesCommissions/Create'" />--%>
                </li>
                </ul>
            </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Message Board</strong>
        </h3>
    </div>


     <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="contentGrid">
                <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                    class="GridView" width="100%">
                    <thead>
                        <th>
                            SN
                        </th>
                        <th>
                            Type
                        </th>
                        <th>
                            Priority
                        </th>
                        <th>
                            Heading Content
                        </th>
                        <th>
                            Effective From
                        </th>
                        <th>
                            Expire On
                        </th>
                        <th>
                            Action
                        </th>
                    </thead>
                    <%
                        if (Model != null)
                        {
                    %>
                    <% var sno = 0;

                       foreach (var item in Model.AgentMessageBoardList)
                       {
                           sno++;
                           var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
                    <tbody>
                        <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                            onmouseout="this.className='<%= classTblRow %>'">
                            <td>
                                <%:sno%>
                            </td>
                            <td>
                                <%: item.MessageTypes %>
                            </td>
                            <td>
                                <%: item.Priority%>
                            </td>
                            <td>
                                <%:item.HeadContains%>
                            </td>
                            <td>
                                <%--<%: item.EffectiveFrom != null ? item.EffectiveFrom.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"].ToString()) : " - "%>--%>

                                <%: TimeFormat.DateFormat(item.EffectiveFrom.ToString()) %>

                            </td>
                            <td>
                               <%-- <%: item.ExpiredOn != null ? item.ExpiredOn.ToString(System.Web.Configuration.WebConfigurationManager.AppSettings["DateFormat"].ToString()):" - "%>--%>
                               <%: TimeFormat.DateFormat(item.ExpiredOn.ToString()) %>
                            </td>
                            <td>
                                <p>
                                    <%: Html.ActionLink(" ", "Details", new { id = item.MessageBoardId, controller = "AgentMessageBoard" }, new { @class = "details", @title = "Details" })%>
                                    <%:Html.ActionLink(" ", "Edit", new { id = item.MessageBoardId, controller = "AgentMessageBoard" }, new { @class = "edit", @title = "Edit" })%>
                                    <%:Html.ActionLink(" ","Delete",new{id=item.MessageBoardId,controller="AgentMessageBoard"},new{@class="delete",@title="Delete",onclick="return confirm('Are you sure want to delete?')"}) %>
                                </p>
                            </td>
                        </tr>
                    </tbody>
                    <%}
             } %>
                </table>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 
    <style type="text/css">
        .checklist
        {
            border: 1px solid #ccc;
            list-style: none;
            height: 20em;
            overflow: auto;
            width: 16em;
        }
        .checklist, .checklist li
        {
            margin: 0;
            padding: 0;
        }
        
        .checklist label
        {
            display: block;
            padding-left: 25px;
            text-indent: -25px;
        }
        
        .checklist label:hover
        {
            background: #777;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../Scripts/jquery.Datepicker-1.8.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.thickbox.js" type="text/javascript"></script>
    <script src="../../Scripts/ATL.jquery.functions.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            //Cheked/UnChecked all child check box if parent check box is Checked/Unchecked .
            $('.ChkBoxParent').click(function () {
                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            });

            $('.ChkBoxChild').click(function () {
                var childCheckBox = $('.ChkBoxChild');
                var checkedAllStatus = true;
                for (var i = 0; i < childCheckBox.length; i++) {
                    if (!$(childCheckBox[i]).is(':checked')) {
                        checkedAllStatus = false;
                    }
                }
                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            });

        });

        $(function () {
            var dates = $("#EffectiveFrom, #ExpiredOn").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                onSelect: function (selectedDate) {
                    var option = this.id == "EffectiveFrom" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });
        });


        function EnableDisableElementBySelectionAppliedDate(thisElm, targetElm) {
            if (thisElm == "checked") {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).val("")
            }
            else {
                $("#" + targetElm).removeAttr('disabled', 'disabled');
            }
        }


    </script>
</asp:Content>
