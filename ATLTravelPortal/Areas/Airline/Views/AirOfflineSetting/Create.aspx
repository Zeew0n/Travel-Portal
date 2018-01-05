<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel.AirOfflineSettingModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
            <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "AirOfflineSetting", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
   
    <div class="pageTitle">
            <ul class="buttons-panel">
                <li><div id="loadingIndicator"></div></li>
                <li><input type="submit" value="Save" /></li><li><input type="button" value="Cancel"  onclick="document.location.href='/Airline/AirOfflineSetting/'" /></li>
            </ul>
            <h3><a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create AirLine</strong></h3>
        </div>
    <div class="row-1">
    <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                <table cellspacing="0" cellpadding="0" border="0" width="100%" id="SourceDynamicField" class="GridView" style="border-collapse: collapse;">
                    <tr>
                    <td>
                        <%: Html.HiddenFor(model => model.AirlineId)%>
                        <%: Html.LabelFor(model => model.AirlineName)%>
                        <%: Html.TextBoxFor(model => model.AirlineName)%>                        
                     </td>
                     <td>&nbsp;</td>
                   <td><input type="button" value="Add" onclick="AddDynamicFormField('DynamicFieldContainer')" /></td>
                   </tr></table>
                </div>
            </div>
         
          
        </div>
      
    </div>

    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <table cellspacing="0" cellpadding="0" border="0" width="100%" id="DynamicFieldContainer" class="GridView" style="border-collapse: collapse;">                   
                <tr>
                <th>AirLine</th>
                <th>Set Offline</th>
                <th>&nbsp;</th>
                </tr>
            </table>

    </div></div></div>
    <p style="color: Red">
        <%:TempData["Error"] %>
    </p>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
<script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
<script type="text/javascript">
var dynamicElmCount=0;
        $(document).ready(function () {

        });
        $('.validate').validate();
        $(function () {
            $("#AirlineName").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                            url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },
                            success: function(data) {
                                response($.map(data, function(item) {
                                    return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                                }));
                            }
                        });
                },
                width: 150,
                select: function (event, ui) {
                    $("#AirlineId").val(ui.item.id);

                }

            });

        });
        function AddDynamicFormField(targetTableId) {
            var elmTable = document.getElementById(targetTableId);
            var IsAlreadyExist = 0;
            $AirlineId = $("#AirlineId").val();
            $AirlineName = $("#AirlineName").val();
            $("#ATForm input[type='hidden'][name$='.AirlineId']").each(function () {               
                var elmId = this.id;
                if ($("#"+elmId).val() == $AirlineId) {
                    IsAlreadyExist = 1;
                    return false;
                }
            });
            if (IsAlreadyExist == 1) {
                alert('AirLine already exist!!');
                return false;
            }
            if ($AirlineId != "" && $AirlineName != "" ) {
                var htmlElementHidden = "<input type=\"hidden\" id=\"AirlineList_Index\" name=\"AirlineList.Index\" value=\"" + dynamicElmCount + "\">";
                var htmlElementAirlineId = "<input type=\"hidden\" id=\"AirlineList_" + dynamicElmCount + "__AirlineId\" name=\"AirlineList[" + dynamicElmCount + "].AirlineId\" class=\"className\" value=\"" + $AirlineId + "\" />";
                var htmlElementAirlineName = "<input type=\"text\" id=\"AirlineList_" + dynamicElmCount + "__AirlineName\" name=\"AirlineList[" + dynamicElmCount + "].AirlineName\" class=\"className\"  value=\"" + $AirlineName + "\" />";
                var htmlElementIsOffline = "<input type=\"checkbox\" id=\"AirlineList_" + dynamicElmCount + "__IsOffline\" name=\"AirlineList[" + dynamicElmCount + "].IsOffline\" class=\"className\"  value=\"true\" checked=\"checked\" />";
                htmlElementIsOffline += "<input type=\"hidden\" name=\"AirlineList[" + dynamicElmCount + "].IsOffline\" class=\"className\" value=\"false\">"; ;

                var row = elmTable.insertRow(elmTable.rows.length);
                var cell0 = row.insertCell(0);
                cell0.innerHTML = htmlElementHidden + htmlElementAirlineId + htmlElementAirlineName;
                var cell1 = row.insertCell(1);
                cell1.innerHTML = htmlElementIsOffline;
                var cell2 = row.insertCell(2);
                $('#' + targetTableId + ' tbody:first>tr:last>td:last').empty().append("<label onclick='DeleteTableRow(this)' class='delete' />&nbsp;</label>");
                dynamicElmCount++;
            }
            else {
                alert('There is an error while adding airline. Please search again!!');

            }
            $("#AirlineId").val("");
            $("#AirlineName").val("");
        }

        function DeleteTableRow(thisElm) {
            if (confirm("Are you sure to delete the row?")) {
                $(thisElm).parent().parent().remove();
            }

            return false;
        }

      

</script>
</asp:Content>
