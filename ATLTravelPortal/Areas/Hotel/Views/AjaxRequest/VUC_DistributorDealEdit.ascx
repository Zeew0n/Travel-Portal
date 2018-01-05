<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "HotelDistributorDealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
    <thead>
        <th style="width: 75px;">
            <%:Html.LabelFor(model => model.HotelName)%>
        </th>
        <th style="width: 70px;">
            Amount
        </th>
        <th style="width: 15px;">
            Is%
        </th>
    </thead>
    <tbody>
        <tr class="optional">
            <td>
                <%:
    
        Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })
               
                %>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%:Html.TextBoxFor(model => model.HotelName, new { id="editHotelName_"+counterIndex,@style ="width:75px;", @class = "airAutoComplete",
                                                         @name = "editHotelName_" + counterIndex}) %>
                <%: Html.HiddenFor(model => model.HotelId, new { @id = "editHotelId_" + counterIndex }) %>
                <%:Html.ValidationMessageFor(model => model.HotelName)%>
            </td>
            <td>
                <%: Html.TextBoxFor(model=>model.Amount, new { id="editAmount_"+counterIndex,@style ="width:75px;", 
                                                         @name = "editAmount_" + counterIndex, @onkeypress = "return CheckFareNumericValue(event)"}) %>
            </td>
            <td>
                <label>
                    <%:Html.CheckBoxFor(model=>model.isPercentage) %></label>
            </td>
        </tr>
        <tr>
            <td colspan="13" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.DealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Update" id="UpdateUpdate_<%=counterIndex %>" onclick="UpdateDeal('DealDetail_<%=Model.DealId %>','myUpdateForm<%=Model.DealId %>')"
                    class="update" />
                <input type="button" value="Cancel" onclick="CancelDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')"
                    id="Cancel_<%=counterIndex %>" class="Canc" />
            </td>
        </tr>
    </tbody>
</table>
<%} %>
<script type="text/javascript">
    function CheckFareNumericValue(e) {

        var key = e.which ? e.which : e.keyCode;
        //enter key  //backspace //tabkey      //escape key  //dot  //minus             
        if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27 || key == 46 || key == 45) {
            return true;
        }
        else {

            return false;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    $(".airAutoComplete").live("change", function () {
        var text = $(this).val();
        var idCtrl = $(this).attr("id");
        var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

        if (text == '')
            $("#editHotelId_" + idCounter).val('');
    });   
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $(".airAutoComplete").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Hotel/AjaxRequest/FindHotels", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.HotelName + " (" + item.HotelCode + ")", value: item.HotelName + " (" + item.HotelCode + ")", id: item.HotelId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

                    $("#editHotelId_" + idCounter).val(ui.item.id);
                }
            });
        });
    });
</script>
