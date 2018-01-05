<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.TicketAirlineSearchOrderModel>" %>
 <%if (Model != null)
      { %>
    <div id="contentLeft">
        <ul>
            <%foreach (var item in Model.GetTicketAirlineSearchList)
              { %>
            <%--<li id="r<%:item.AirlineId%>">--%>
            <li id="r<%:item.AirlineSearchOrderId%>" >
                <%:item.SerialNo %>.
                <%:item.AirlineName %>
                       <a href="/AirlineOrder/Delete/<%:item.AirlineSearchOrderId %>" class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')"></a>
                </li>
                
            <%} %>
        </ul>
        <%:Html.HiddenFor(model=>model.SerialOrder) %>
    </div>
    
    <%} %>
    <script type="text/javascript">
        $(document).ready(function () {
            var arr = [];

            
            $("#contentLeft ul").sortable({
                update: function (event, ui) {
                    $("#AirlineName").val('');
                    arr = [];
                    $("#contentLeft li").each(function () {
                        arr.push($(this).attr('id'));

                    });
                    $("#SerialOrder").val(arr);

                    //                    var arr1 = $("#SerialOrder").val();
                    //                    $.ajax({
                    //                        type: "POST",
                    //                        url: "/AirlineOrder/Index",
                    //                        //data: $(this).serialize(),
                    //                        data: { SerialOrders: arr1 },
                    //                        //data: status,
                    //                        dataType: "html",
                    //                        success: function (result) {

                    //                            $("#Partial").empty().append(result);


                    //                        }
                    //                    });
                }

            });
        });
    </script>
    
