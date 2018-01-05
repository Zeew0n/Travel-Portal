<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>
<%if(Model.CardNumber!=null){ %>
<tr id="cardrow-<%:Model.HFCardId%>">
             <td>
            <%: Html.ActionLink(Model.CardNumber, "Details", new { controller = "CardRegistration", id = Model.HFCardId }, new { @class="Details"})%>
              </td>
               <td>
               <%:Model.CardValue%>
             </td>
              <td>
               <%:Model.CardType%>
             </td>
              <td>
               <%: Model.ValidTill.ToShortDateString() %>
               </td>
                    <td>
                        <p>
                        <a href="#" class="delete" title="Delete" meta:id="<%:Model.HFCardId %>"> </a>
                        </p>
                    </td>
                    </tr>
      <%} %>
       <script type="text/javascript">
           $(".delete").live("click", function () {
               var id = $(this).attr("meta:id");
               if (confirm("Do you want to delete this record?")) {
                   $.post("/IssueCard/Delete",
		{ id: id },
		function (data) {
		    $("#cardrow-" + data).css("background-color", "lightgreen");
		    $("#cardrow-" + data).fadeOut("slow", function () { $(this).remove() });
		},
		"json"
        );
           }
               return false;
           });
      </script>
