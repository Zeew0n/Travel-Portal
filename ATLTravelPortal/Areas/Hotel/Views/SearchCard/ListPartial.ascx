<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>" %>


       
   



<%if (Model != null && Model.CardNumber != null)
  { %>
<% Html.EnableClientValidation(); %>
      
               <%  using (Html.BeginForm("Search", "SearchCard", FormMethod.Post,
    new { @autocomplete = "off" }))
                   {%>
 
                <tbody>

                <tr id="cardrow-<%:Model.HFCardId%>">
                
               

                
             <td>
                <%: Html.ActionLink(Model.CardNumber, "Details", new { controller = "CardRegistration", id = Model.HFCardId }, new { @class = "Details" })%>
              </td>
               <td>
               <%:Model.CardType%>
             </td>
              <td>
               <%:Model.CardValue%>
             </td>
              <td>
               <%: Model.ValidTill.ToShortDateString()%>
               </td>
               <td>
               <%: Model.CardStatus%>
               </td>
                    <td>
                    <%if (Model.CardStatusId == 3)
                      {%>
                      <input id="Radio4" type="radio"   runat="server" name="SearchCardId"  value="3" checked=true  />  Active
                      <%} %>
                      <%else 
                      {%>
                       <input id="Radio1" type="radio"   runat="server" name="SearchCardId"  value="3" /> Active 
                      <%} %>
                       <%if (Model.CardStatusId == 4)
                      {%>
                      <input id="Radio2" type="radio"   runat="server" name="SearchCardId"  value="4" checked=true  />  Damage
                      <%} %>
                      <%else 
                      {%>
                       <input id="Radio3" type="radio"   runat="server" name="SearchCardId"  value="4" /> Damage
                      <%} %>
                       <%if (Model.CardStatusId == 5)
                      {%>
                      <input id="Radio5" type="radio"   runat="server" name="SearchCardId"  value="5" checked=true  />  Block
                      <%} %>
                      <%else 
                      {%>
                       <input id="Radio6" type="radio"   runat="server" name="SearchCardId"  value="5" /> Block 
                      <%} %>
                       <%if (Model.CardStatusId == 6)
                      {%>
                      <input id="Radio7" type="radio"   runat="server" name="SearchCardId"  value="6" checked="true"  />  Lost
                      <%} %>
                      <%else 
                      {%>
                       <input id="Radio8" type="radio"   runat="server" name="SearchCardId"  value="6" /> Lost 
                      <%} %>
                     
                     
                        <%--<input id="Radio8" type="radio"   runat="server" name="SearchCardId"  value="3" checked =true/>  Active
                      <input id="Radio1" type="radio"   runat="server" name="SearchCardId"  value="4" />  Damage 
                      <input id="Radio2" type="radio"   runat="server" name="SearchCardId" value="5" /> Block
                      <input id="Radio3" type="radio"   runat="server" name="SearchCardId"  value="6" />  Lost--%>
                      
         
                     <input type="submit" value="Save" class="save" />
   
                   <%:Html.HiddenFor(model => model.HFCardId )%>  
                    </td>
                    </tr>
                    
       <%}
  } %></tbody>
 
<script type="text/javascript">
    $(document).ready(function () {
        /////////////////////// POP UP Function //////////////////////////////////////
        $(function () {

            $('a.edit').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');

            });
            $('a.new').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');

            });
            $('a.Details').live("click", function (event) {
                loadDetailsDialog(this, event, '#contentGrid');

            });

        });
        /////////////////End of new fucntion/////////////////


    });   /* end document.ready() */  
//      $(".save").live("click", function () {
//          var id = $(this).attr("meta:id");
//          
//          if (confirm("Do you want to save this record?")) {
//              $.post(
//"/SearchCard/Searchs",
//		{ id: id },
//		function (data) {
//		    $("#cardrow-" + data).css("background-color", "lightgreen");
//		    $("#cardrow-" + data).fadeOut("slow", function () { $(this).remove() });
//		},
//		"json"
//	);
//		
//          }
//          return false;
//      });
             </script>