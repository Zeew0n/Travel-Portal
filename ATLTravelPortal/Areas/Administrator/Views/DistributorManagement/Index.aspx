<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
                </li>
                <li>
                    <input type="button" onclick="document.location.href='/Administrator/DistributorManagement/Create/'"
                        value="New" class="new" />
                </li>
            </ul>
        </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>Distributor Management</strong>
        </h3>
    </div>
    <% using (Html.BeginForm("DistributorSearch", "DistributorManagement", FormMethod.Post))
       {%>
    <div>
        <label>
            <%: Html.Label("Distributor Name/Code") %>
            <%: Html.TextBoxFor(model=>model.DistributorName)%>
            <%:Html.ValidationMessageFor(model=>model.DistributorName) %>
            <input type="submit" value="Search" class="btn1" />
        </label>
    </div>
    <%} %>
    <% using (Html.BeginForm("Index", "DistributorManagement", FormMethod.Post, new { @id = "ATForm" }))
       {%>
    <div>
        <%ATLTravelPortal.Areas.Administrator.Models.AgentModel model1 = new ATLTravelPortal.Areas.Administrator.Models.AgentModel(); %>
        <label>
            <%: Html.LabelFor(model=>model.Status)%></label>
        <% List<SelectListItem> StatusList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "0", Text = "All"},
                                        new SelectListItem {Selected = false, Value = "1", Text = "Active"},
                                         new SelectListItem {Selected = false, Value = "2", Text = "Deactive"},
                                         
                                    };%>
        <%:Html.DropDownListFor(model => model.Status, StatusList)%>
    </div>
    <hr />
    <div id="AgentPartialDiv">
        <%Html.RenderPartial("VUC_DistributorList", Model.Distributors);%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        function beginAgentList(args) {
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
        }

        function successAgentList() {
            $("#loadingIndicator").html('');
        }

        function failureAgentList() {
            $("#loadingIndicator").html('');
            alert("Could not retrieve List.");
        }




        ////////////////////////////Start of searching Agent By Status //////////////////////////////
        $("#Status").live("change", function () {
            var alphabet;
            var IsActive = $("#Status").val();

            if (IsActive == "") {
                return false;
            }
            else {
                $.ajax({
                    type: "GET",
                    url: "/Administrator/DistributorManagement/Index",
                    data: { IsActive: IsActive, id: alphabet },
                    dataType: "html",
                    success: function (result) {
                        $("#AgentPartialDiv").empty().append(result);
                    }
                });
            }
        }).change();



        $(function () {
            $('a.agentList').live("click", function (event) {
                loadCreateDialog(this, event);
            });
        });

        function loadCreateDialog(tag, event) {
            event.preventDefault();
            $(this).dialog('destroy');
            var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
            var url = $(tag).attr('href');
            var id = $(tag).attr('rel');
         
            if (id == "") {               
                return false;
            }

            var $title = $(tag).attr('title');
            var $dialog = $('<div></div>');
            $dialog.empty();
            $dialog
            .append($loading)
            .load(url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 885
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale'
                , closeOnEscape: false
		        , open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); }
                , buttons: [
                           {
                               text: "Close",
                               click: function () { $(this).remove(); }
                           }
                         ]
		    });
            $dialog.dialog('open');
        };


    </script>
</asp:Content>
