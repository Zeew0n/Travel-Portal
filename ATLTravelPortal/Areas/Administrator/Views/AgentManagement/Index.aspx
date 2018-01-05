<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<List<TravelPortalEntity.Agents>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Arihant Holidays:Agent List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <%
        if (TempData["error"] != null)
        { %>
    <%: TempData["error"]%>
    <%
    
        }
    %>
   
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
                </li>
                <li>
                    <input type="button" onclick="document.location.href='/Administrator/AgentManagement/Create'" value="New"
                        class="new" />

                </li>
            </ul>
        </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Agents</strong>
        </h3>
    </div>
    <% using (Html.BeginForm("AgentSearch", "AgentManagement", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <%ATLTravelPortal.Areas.Administrator.Models.AgentModel model = new ATLTravelPortal.Areas.Administrator.Models.AgentModel(); %>
    <div>
        <label>
            <%: Html.Label("Agency Name/Code") %>
            <%: Html.TextBoxFor(x=>model.AgentSearch)%>
            <input type="submit" value="Search" class="btn1" />
        </label>
    </div>
    <%} %>
    <% using (Html.BeginForm("Index", "AgentManagement", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <div>
        <%ATLTravelPortal.Areas.Administrator.Models.AgentModel model1 = new ATLTravelPortal.Areas.Administrator.Models.AgentModel(); %>
        <label>
            <%: Html.Label("Status")%></label>
        <% List<SelectListItem> StatusList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "0", Text = "All"},
                                        new SelectListItem {Selected = false, Value = "1", Text = "Active"},
                                         new SelectListItem {Selected = false, Value = "2", Text = "Deactive"},
                                         
                                    };%>
        <%:Html.DropDownListFor(x => model1.ddlStatus, StatusList)%>
    </div>
    <div id="AgentPartialDiv">
        <%Html.RenderPartial("AgentListPartial", Model);%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>

    <script type="text/javascript">
       $(document).ready(function () {
           var alphabet;

       });

        function beginAgentList(args) {
            // Animate
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
        }

        function successAgentList() {
            // Animate loadingAnimation
            $("#loadingIndicator").html('');

        }
        function failureAgentList() {
            $("#loadingIndicator").html('');
            alert("Could not retrieve List.");
        }


        ////////////////////////////Start of searching Agent By Status //////////////////////////////
        $("#model1_ddlStatus").live("change", function () {

            var alphabet;

            var IsActive = $("#model1_ddlStatus").val();

            if (IsActive == "") {
                return false;
            }
            else {
                $.ajax({
                    type: "GET",
                    url: "/Administrator/AgentManagement/Index",
                    data: { IsActive: IsActive, id: alphabet },
                    dataType: "html",
                    success: function (result) {

                        $("#AgentPartialDiv").empty().append(result);
                    }
                });
            }

        }).change();


        $(function () {
            $('.Adminpager a').click(function () {
                alphabet = $(this).text();
            });
        });



    </script>
</asp:Content>
