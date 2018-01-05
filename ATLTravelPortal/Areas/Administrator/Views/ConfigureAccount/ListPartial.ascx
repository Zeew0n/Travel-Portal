<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.ConfigureAccountModel>" %>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%" id="myTable">
        <thead>
            <th>
                Account Name
            </th>
            <th>
                Ledger
            </th>
           
        </thead>
        <%
            if (Model != null)
            {
                if (Model.ConfigureAccountList != null)
                {
        %>
        <% var sno = 0;

           foreach (var item in Model.ConfigureAccountList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td class="<%=sno %>">
                    <%--<%Response.Write(item.AccountConfName); %>--%>
                    <%:Html.Label(item.AccountConfName) %>
                </td>
                <td>
                    <%Model.LedgerId = item.LedgerId; %>
                    <%--<%:Html.DropDownListFor(model=>model.LedgerId, (SelectList)ViewData["Ledger"], new {@class="ledger"+sno })%>--%>
                    <%=Html.DropDownList("LedgerId",(SelectList)ViewData["Ledger"],"---Select---" ,new {@class="required" }) %>
                </td>
               
                
            </tr>
        </tbody>
        <%}
                            }
                            //Html.HiddenFor(Model.KeyValue, new { @Readonly="true"});
                        } %>
    </table>
    <%--<%:Html.ActionLink(" ","Index",new{productId:productId} %>--%>
    <div id="hidden" class="hide">
    <%if (Model != null)
      {
          var counter = 0;
          foreach (var item in Model.ConfigureAccountList)
          {  %>
          <%:Html.Hidden("AccountValue[" + counter + "]", item.AccountConfId, new { @class = item.AccountConfName })%>
    <%
        counter++;
          }
              } %>
              </div>
              
</div>

<script type="text/javascript" language="javascript">
    $(".btn1").click(function () {
        var id = $(this).attr('id');
        id = id.substr(1);
        var rowid = $(this).closest('tr').attr('id');
        var LId = $('#' + rowid).find('#LedgerId').val();
        var PId = $("#ProductId").val();

        $.ajax({

            type: "POST",
            url: "Administrator/ConfigureAccount/Index",
            data: "Id=" + id + "&LedgerId=" + LId + "&productId=" + PId,

            dataType: "html",
            success: function (result) {

                $("#ListTable").empty().append(result);

            }
        });
    });

    /////////////////////////////End of BtnClick//////////////////////////////
    $(document).ready(function () {
        var ArrayMy = new Array();
        var rowCount = $('#myTable tr').length;

        for (var i = 0; i < rowCount; i++) {
            var j = i + 1;
            var LId = $("#tr_" + j).find('#LedgerId').val();
            ArrayMy[j] = LId;
        }
        $("#KeyValue").val(ArrayMy);



    });
    var myArray = new Array();


    $(".required").change(function () {

        var rowCount = $('#myTable tr').length;

        for (var i = 0; i < rowCount; i++) {
            var j = i + 1;
            var LId = $("#tr_" + j).find('#LedgerId').val();
            myArray[j] = LId;
        }
        $("#KeyValue").val(myArray);

    });
            
</script>

