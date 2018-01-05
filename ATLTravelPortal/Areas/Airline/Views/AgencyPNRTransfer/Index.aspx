<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agency PNR Transfer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="lblloading">
                    </div>
                </li>
                <li>
                    </li>
                <li>
                    
                </li>
            </ul>
            <h3>
                <a href="#" class="icon_plane"></a>Ticket Management <span>&nbsp;</span><strong>Agency PNR Transfer</strong>
            </h3>
        </div>
    </div>
       <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Index", "AgencyPNRTransfer", new AjaxOptions()
                      {
                          UpdateTargetId = "resultcontainer",
                          OnBegin = "beginList",
                          OnSuccess = "successList",
                          InsertionMode = InsertionMode.Replace,
                          HttpMethod = "Post",
                      }, new { @class = "validate", @autocomplete = "off" }))
      { %>
    <%: Html.ValidationSummary(true) %>

            <div class="flightType">
        <%:Html.RadioButton("BookingStatus", "Booked", true, new { id = "Book", title = "Book" })%>
        <span>Book</span>
        <%:Html.RadioButton("BookingStatus", "Issued", new { id = "Issue", title = "Issue" })%>
        <span>Issue</span>     
    </div>
    <br /> 

             <div style="width: 100%; float: left;">
    <label>From &nbsp; &nbsp;&nbsp;</label>
   <%-- <%:Html.TextBox("From", "Arihant Holidays Pvt. Ltd.", new { @style = "width:196px; height:22px; padding:2px; font-size:12px;", @disabled = "disabled" })%><br /><br />
     <%:Html.Hidden("AgentId", 1)%>--%>
      <%:Html.TextBox("From", "", new { @class = "required", @style = "width:450px; height:22px; padding:2px; font-size:19px;" })%>  <br /><br />
      <%:Html.Hidden("AgentId", "", new { @class = "required" })%><br /><br />

    <label>PNR No &nbsp;&nbsp;</label><%:Html.TextBox("PnrNo", "", new {@class="required", @style = "width:150px; height:22px; padding:2px; font-size:19px;" })%><br /><br />

    <label>To Agent &nbsp;</label>
    <%:Html.TextBox("ToAgencyName", "", new { @class = "required", @style = "width:450px; height:22px; padding:2px; font-size:19px;" })%>  
      <%:Html.Hidden("ToAgentId","", new { @class = "required" })%><br /><br />
     <label>Remarks &nbsp;</label><%:Html.TextArea("Remark", "", new { rows = "3", cols = "24", @class = "{maxlength:58}, required", @style = "width: 177px; height: 58px;" })%><br /><br />
    
    <ul class="productgrid">
        <li>
        <input type="submit" id="transferbtn" name="transfer" value="Transfer now" style="font-weight: bold; font-size: 16px; "/>
        </li>
    </ul>
    </br>
    </br>
    <div style=" background-color:Yellow; float:left; ">
    <label style=" font-size:16px; color:Red;">This operation can not Undo. Please verify before you transfer the PNR.</label>
    </div>
   
    <% }
    %>
    </div>
        <div id="resultcontainer" style="font-size:18px; color:Green;">
     
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<style type="text/css">
    .error
        {
    background-color: #FFEEEE;
    border: 1px solid #FF0000;
        }
     </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $('.validate').validate();

            $(function () {
                $("#ToAgencyName").autocomplete({
                    minLength: 2,
                    selectFirst: true,
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AjaxRequest/GetAgentNameListAC", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 10 },
                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, error) {//302
                                alert('HTTP ' + textStatus + ' Error Encountered: ' + error);
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#ToAgentId").val(ui.item.id);
                        $("#ToAgencyName").val(ui.item.value);
                      
                    }

                });
            });
        });

        function beginList(args) {
            $("#resultcontainer").empty();
            var isValid = $('.validate').valid();
            if (isValid) {
                var PnrNo = $("#PnrNo").val();
                $("#transferbtn").attr("onclick", "return confirm('Do you want transfer PNR " + PnrNo + "');");
                $("#lblloading").html('<img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />');
            }
            else {
                $("#transferbtn").removeAttr("onclick");
                return false;
            }
        }
        function successList(content) {
            $("#lblloading").html('');
            $("#transferbtn").removeAttr("onclick");
            $("#PnrNo").val('');$("#ToAgencyName").val('');$("#ToAgentId").val('');$("#Remark").val('');
           // var json_data = content.get_response().get_object();
        }

        $(document).ready(function () {
            $('.validate').validate();

            $(function () {
                $("#From").autocomplete({
                    minLength: 2,
                    selectFirst: true,
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AjaxRequest/GetAgentNameListAC", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 10 },
                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, error) {//302
                                alert('HTTP ' + textStatus + ' Error Encountered: ' + error);
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#AgentId").val(ui.item.id);
                        $("#From").val(ui.item.value);

                    }

                });
            });
        });
        
              
    </script>
</asp:Content>
