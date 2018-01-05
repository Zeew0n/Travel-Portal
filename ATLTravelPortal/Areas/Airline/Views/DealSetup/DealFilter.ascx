<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<table>
    <tbody>
        <tr>
            <td>
                Deal Name<br />
                <%: Html.DropDownListFor(model => model.DealMasterId, Model.DealMasterList, "--- Select---")%>
                <%: Html.ValidationMessageFor(model => model.DealMasterId, "*")%>
            </td>
            <td>
                Deal Identifier<br />
                <%: Html.DropDownListFor(model => model.DealIdentifierId, Model.DealIdentifierList, "--- Select ---", new { @id = "FilterDealIdentifierId" })%>
                <%:Html.ValidationMessageFor(model=>model.DealIdentifierId,"*") %>
            </td>
            <td>
                Airline Filter<br />
             <%--   <%: Html.DropDownListFor(model => model.AirlineId, Model.AirlineNameList, "--- Select---", new {id="FilterAirlineId" })%>
                <%: Html.ValidationMessageFor(model => model.AirlineId, "*")%>--%>



                       
        <%: Html.TextBoxFor(model => model.AirlineName, new { @class = "ui-autocomplete-input requiredField", @id = "FilterAirlineName" })%>
        <%: Html.ValidationMessageFor(model => model.AirlineName, "*")%>      
        <%:Html.HiddenFor(model => model.AirlineId, new { @id = "FilterAirlineId" })%>  

            </td>
            <td>
                Currency<br />
                <%: Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, "--- Select---", new  {@id="FilterCurrencyId" })%>
                <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
                <%:Html.Hidden("source1",Model.Source) %>
            </td>
            <td><br /><%:Html.ActionLink("New", "Create", null, new { @class = "create linkButton", @title = "New Item" })%></td>
        </tr>
    </tbody>
</table>
<br />

<%--<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $("#FilterAirlineName").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 10},
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {                    
                    $("#filterAirlineId").val(ui.item.id);
                }
            });
        });      
    });
</script>--%>