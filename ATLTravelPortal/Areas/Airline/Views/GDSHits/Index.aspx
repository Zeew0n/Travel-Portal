<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.GDSHitsModel>" %>

     <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GDS Hits
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <label id="lblDealMasterSuccess" style="display: none;" class="pageTitle">
                </label>
            </li>
            
        </ul>
        <h3>
            Reports<span>&nbsp;</span><strong>Transaction Hits</strong>
        </h3>
    </div>

    <% Html.EnableClientValidation(); %>
   <% using (Html.BeginForm("Index", "GDSHits", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
                GDS Hits
            </h3>
        </div>
    </div>

      <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>Agent</label>
                            <%:Html.TextBoxFor(model => model.AgentName)%>
                            <%:Html.HiddenFor(model => model.hdfAgentId)%>
                    </div>
                </div>
            </div>
           
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <% } %>






       
     <% var q = (from p in Model.GDSHitLists select new { p.AgentName,p.Agentid }).Distinct().ToList();

        for (int i = 0; i < q.Count(); i++)
        {
            var k = (from l in Model.GDSHitLists where l.AgentName == q.ToList()[i].AgentName select l).ToList();
            %>

        <label><%:Html.ActionLink("Details", "Details", new { @id = q.ToList()[i].Agentid })%></label>

          <%var s = (from t in k select new { t.ServiceProvider }).Distinct().ToList();
            for (int j = 0; j < s.Count(); j++)
            {
                var l = (from m in k where m.ServiceProvider == s.ToList()[j].ServiceProvider select m).ToList();
          %>
           
                  <div class="contentGrid">
             <h3 style="text-align:left; background:#8ab7df; color:#fff; border-right:1px solid #59676a; border-left:1px solid #59676a; font-size:14px; padding:3px 5px;"><%:s.ToList()[j].ServiceProvider%></h3>
           <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="5%" />
                <col width="65%" />
                <col width="30%" />
            </colgroup>
           
           
            <tbody>
             <% var sno = 0;

                var total = 0;
               foreach (var item in l)
               {
                  
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                  <td><% =sno%></td>
                    <td>
                        <%: item.TransactionName%>
                    </td>
                    <td>
                        <%: item.GDSHitCount%>
                    </td>
                   
                </tr>
                <%
                   total += item.GDSHitCount;
                    } %>
                <tr>
                <td colspan="3" style="text-align: center;">
                Total: <%:total%>
                </td>
                </tr>
            </tbody>

        </table>
         </div>
            <%
            }
       
        
        
     %>
  <%} %>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $(function () {
            var dates = $("#FromDate, #ToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "FromDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });
        });
///////////////////////////End of DatePicker/////////////////////////////////////////////////////////////

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
/////////////////////////////////End of Autocomplete//////////////////////////////////////////////////

    });



</script>

<script type="text/javascript" language="javascript">
    $("#AgentName").live("change", function () {
        $("#hdfAgentId").val('');
    });
 

</script>

</asp:Content>
