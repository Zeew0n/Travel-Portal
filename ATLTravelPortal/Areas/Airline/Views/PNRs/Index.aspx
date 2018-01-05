<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PNRRetrieveResult>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Retrieve PNRs
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Index", "PNRs", new AjaxOptions()
                      {
                          UpdateTargetId = "rptSearchResult",
                          OnBegin = "beginList",
                          OnSuccess = "successList",
                          InsertionMode = InsertionMode.Replace,
                          HttpMethod = "Post",

                      }))
      { %>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <h3>
            <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Retrieve PNR Status</strong>
        </h3>
    </div>
    <div class="reportFilter">

    <div class="reportLeftDiv">
            <div class="divLeft">
                <label>
                   Agent
                </label>
                <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"])%>
                        <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
            </div>
        </div>

        <div class="reportLeftDiv">
            <div class="divLeft">
                <label>
                    GDS PNR
                </label>
                <%: Html.TextBoxFor(x=>x.RecordLocator) %>
                <%: Html.ValidationMessageFor(x=>x.RecordLocator) %>
                <label id="lblloading">
                </label>
            </div>
        </div>
        <div class="buttonBar  reportLeftDiv commonWidth">
            <%-- <%Html.RenderPartial("Utility/VUC_ExportData"); %>--%>
            <input class="float-right" type="submit" value="Search" name="Search" />
            <%--    <input class="delete float-right" id="btnCancelPNR"  type="submit" value="Cancel PNR" name="CancelPNR"
                style="display: none;"/>--%>
        </div>
    </div>
    <%} %>
    <div class="clearboth">
    </div>
    <br />
    <div id="rptSearchResult">
        <%Html.RenderPartial("VUC_PNRsResult"); %>
    </div>
    <br />
   <div id="PagingResultPlaceholder">
        <%Html.RenderPartial("VUC_VndLocatorToRetrieve"); %>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">

        /* ---------------------------------------------------- Loader Animation begin here ----------------------------------------*/

        function beginList(args) {
            // Animate
            $("#ResultPlaceHolder").empty();
            $("#lblloading").html('<img src="<%=Url.Content("~/Content/Icons/ui-anim_basic_16x16.gif") %>" alt="" width="16px" height="16px" />');

        }
        function successList() {
            $("#lblloading").html('');
            //            $("#btnCancelPNR").css('display', 'block');
            //            var RecordLocator = $("#RecordLocator").attr("value");
            //            $("#btnCancelPNR").attr("onclick","return confirm('Do you want to Delete PNR "+RecordLocator+"');") ;
        }        
    </script>
</asp:Content>
