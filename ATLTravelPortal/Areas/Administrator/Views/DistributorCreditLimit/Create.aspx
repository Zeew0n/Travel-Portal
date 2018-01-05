<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Create", "DistributorCreditLimit", new AjaxOptions()
                      {
                          UpdateTargetId = "PartialDiv",
                          InsertionMode = InsertionMode.Replace,
                          OnBegin = "beginAgentList",
                          OnSuccess = "successAgentList",
                          OnFailure = "failureAgentList",
                          HttpMethod = "Post",

                      }, new { @id = "myForm" }))
      { %>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Create</h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Agent:</label>
                        <%:Html.DropDownListFor(model => model.ddlAgentId, Model.AgentList, "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.ddlAgentId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Type:</label>
                        <%:Html.DropDownListFor(model => model.ddlTypeId, Model.TypeList, "-----Select-----")%><label
                            class="redtxt" id="loadingIndicator"></label>
                        <%: Html.ValidationMessageFor(model => model.ddlTypeId, "*")%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <div id="PartialDiv">
        <%Html.RenderPartial("CreditLimitSettingPartial", Model.CreditLimit); %>
    </div>
    <div id="AgentCreditLimitDetailsContainer">
        <%Html.RenderPartial("VUC_AgentCreditLimitDetails"); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ddlTypeId").change(function () {
                // $('#TheForm').submit();
                serializeFormData = $("form[id$=myForm]").serialize();
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
                $.ajax({
                    url: "/Administrator/DistributorCreditLimit/Create",
                    type: "POST",
                    dataType: "html",
                    data: serializeFormData,
                    success: function (data) {

                        $('#PartialDiv').empty().append(data);
                        var AgentId = $("#ddlAgentId").val();
                        var CreditLimitType = $("#ddlTypeId").val();
                        
                       

                        $("#hdfagentid").val(AgentId);
                        $("#hdfTypeid").val(CreditLimitType);

                        $("#loadingIndicator").html('');
                    },
                    error: function (XMLHttpRequest, textStatus, error) {//302
                        alert('HTTP ' + textStatus + ' Error Encountered: ' + error);
                        $("#loadingIndicator").html('');
                    }
                });


            });
        });

    </script>
    <script type="text/javascript">
        function beginAgentList(args) {
            // Animate
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');

        }
        function successAgentList() {
            // Animate loadingAnimation
            $("#loadingIndicator").html('');
            var AgentId = $("#ddlAgentId").val();
            var CreditLimitType = $("#ddlTypeId").val();
            $("#hdfagentid").val(AgentId);
            $("#hdfTypeid").val(CreditLimitType);
        }
        function failureAgentList() {
            alert("Could not retrieve List.");
        }
        $("#ddlAgentId").live("change", function () {
           
            var AgentId = $("#ddlAgentId").val();
            if (AgentId == "") {
                $("#AgentCreditLimitDetailsContainer").empty();
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                $(function () {
                    $.ajax({
                        type: "POST",
                        url: "/Administrator/DistributorCreditLimit/Index",
                        data: { AgentId: AgentId },
                        dataType: "html",
                        traditional: true,
                        success: function (result) {
                            $("#AgentCreditLimitDetailsContainer").empty().append(result);
                            $("#loadingIndicator").html('');
                        }
                    });
                });

            }
        }).change();
    </script>
</asp:Content>
