<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.SegmentCountReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Segment Count
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
    <% using (Html.BeginForm("Index", "SegmentCountReport", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true) %>

     <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Segment Count</strong>
            </h3>
        </div>
    </div>

    <div class="contentGrid">
      <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
        <div class="row-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.LabelFor(model => model.YearId)%></label>
                            <% List<SelectListItem> YearList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = true, Value = "2011", Text = "2011"},
                                        new SelectListItem {Selected = false, Value = "2012", Text = "2012"},
                                         new SelectListItem {Selected = false, Value = "2013", Text = "2013"},
                                          new SelectListItem {Selected = false, Value = "2014", Text = "2014"},
                                           new SelectListItem {Selected = false, Value = "2015", Text = "2015"},
                                         
                                    };%>
                            <%:Html.DropDownListFor(model => model.YearId, YearList)%>
                            <span class="redtxt">*</span>
                            <%:Html.ValidationMessageFor(model => model.YearId)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <%: Html.LabelFor(model => model.ServiceProviderId)%></label>
                            <% List<SelectListItem> ServiceProviderList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = true, Value = "1", Text = "Galileo"},
                                        new SelectListItem {Selected = false, Value = "3", Text = "Abacus"},
                                       
                                    };%>
                            <%:Html.DropDownListFor(model => model.ServiceProviderId, ServiceProviderList)%>
                            <span class="redtxt">*</span>
                            <%:Html.ValidationMessageFor(model => model.ServiceProviderId)%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Agent
                            </label>
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
        <% if (Model != null)
           { %>
        <%if (Model.SegmentCountReportList != null && Model.SegmentCountReportList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                        Info
                    </th>
                    <th>
                        Jan
                    </th>
                    <th>
                        Feb
                    </th>
                    <th>
                        March
                    </th>
                    <th>
                        April
                    </th>
                    <th>
                        May
                    </th>
                    <th>
                        June
                    </th>
                    <th>
                        July
                    </th>
                    <th>
                        Aug
                    </th>
                    <th>
                        Sep
                    </th>
                    <th>
                        Oct
                    </th>
                    <th>
                        Nov
                    </th>
                    <th>
                        Dec
                    </th>
                    <th>
                        Net
                    </th>
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    int count = Model.SegmentCountReportList.Count();
                    if (count > 0)
                    {
                        Model.SumJan = Model.SegmentCountReportList.ElementAt(count - 1).SumJan;
                        Model.SumFeb = Model.SegmentCountReportList.ElementAt(count - 1).SumFeb;
                        Model.SumMarch = Model.SegmentCountReportList.ElementAt(count - 1).SumMarch;
                        Model.SumApril = Model.SegmentCountReportList.ElementAt(count - 1).SumApril;
                        Model.SumMay = Model.SegmentCountReportList.ElementAt(count - 1).SumMay;
                        Model.SumJune = Model.SegmentCountReportList.ElementAt(count - 1).SumJune;
                        Model.SumJuly = Model.SegmentCountReportList.ElementAt(count - 1).SumJuly;
                        Model.SumAug = Model.SegmentCountReportList.ElementAt(count - 1).SumAug;
                        Model.SumSep = Model.SegmentCountReportList.ElementAt(count - 1).SumSep;
                        Model.SumOct = Model.SegmentCountReportList.ElementAt(count - 1).SumOct;
                        Model.SumNov = Model.SegmentCountReportList.ElementAt(count - 1).SumNov;
                        Model.SumDec = Model.SegmentCountReportList.ElementAt(count - 1).SumDec;

                        Model.SumBooked = Model.SegmentCountReportList.ElementAt(count - 1).SumBooked;
                        Model.SumCancelled = Model.SegmentCountReportList.ElementAt(count - 1).SumCancelled;
                        Model.SumAllMonths = Model.SegmentCountReportList.ElementAt(count - 1).SumAllMonths;


                    }


                    foreach (var item in Model.SegmentCountReportList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%: sno%>.
                    </td>
                    <td>
                        <%: item.Info%>
                    </td>
                    <td>
                        <%: item.Jan%>
                    </td>
                    <td>
                        <%: item.Feb%>
                    </td>
                    <td>
                        <%: item.Mar%>
                    </td>
                    <td>
                        <%:  item.April%>
                    </td>
                    <td>
                        <%: item.May%>
                    </td>
                    <td>
                        <%: item.Jun%>
                    </td>
                    <td>
                        <%: item.July%>
                    </td>
                    <td>
                        <%: item.Aug%>
                    </td>
                    <td>
                        <%: item.Sep%>
                    </td>
                    <td>
                        <%: item.Oct%>
                    </td>
                    <td>
                        <%: item.Nov%>
                    </td>
                    <td>
                        <%: item.Dec%>
                    </td>
                    <% if (item.Info == "Booked")
                       { %>
                    <td>
                        <b>
                            <%: item.SumBooked%>
                        </b>
                    </td>
                    <%} %>
                    <% else if (item.Info == "Cancelled")
                       { %>
                    <td>
                        <b>
                            <%:item.SumCancelled%>
                        </b>
                    </td>
                    <td>
                    </td>
                </tr>
                <% } %>
                <%}
                %>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <b>Net</b>
                    </td>
                    <td>
                        <b><b>
                            <%:Model.SumJan == null ? "" : (Model.SumJan).ToString()%>
                        </b></b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumFeb == null ? "" : (Model.SumFeb).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumMarch == null ? "" : (Model.SumMarch).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumApril == null ? "" : (Model.SumApril).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumMay == null ? "" : (Model.SumMay).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumJune == null ? "" : (Model.SumJune).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumJuly == null ? "" : (Model.SumJuly).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumAug == null ? "" : (Model.SumAug).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumSep == null ? "" : (Model.SumSep).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumOct == null ? "" : (Model.SumOct).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumNov == null ? "" : (Model.SumNov).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumDec == null ? "" : (Model.SumDec).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>
                            <%:Model.SumAllMonths == null ? "" : (Model.SumAllMonths).ToString()%>
                        </b>
                    </td>
                </tr>
            </tbody>
        </table>
        <%} %>
    </div>
    <%} %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

  <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>

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


        $("#AgentName").live("change", function () {
            $("#hdfAgentId").val('');            
        });
    </script>
</asp:Content>
