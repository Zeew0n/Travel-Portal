<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>" %>

 <% Html.EnableClientValidation(); %>
   <% using (Html.BeginForm("Create", "CardRegistration", FormMethod.Post))
  
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
               Register New Card
            </h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <input type="submit" value="Save" class="save"  />
                </li>
            </ul>
        </div>
    </div>
    
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model=>model.CardNumber) %></label>
                        <%: Html.TextBoxFor(model => model.CardNumber) %>
                        <%: Html.ValidationMessageFor(model => model.CardNumber) %>
                    </div>
                </div>
            </div>
            
             <div class="form-box1-row">
         <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CardTypeId) %></label>
                        <%: Html.DropDownListFor(model => model.CardTypeId,Model.CardTypeList ,"--- Select ---")%>
                        <%: Html.ValidationMessageFor(model => model.CardTypeId,"*")%></div>
                </div>
                </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CardValue) %></label>
                        <%: Html.TextBoxFor(model => model.CardValue)%>
                        <%: Html.ValidationMessageFor(model => model.CardValue)%></div>
                </div>
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ValidTill) %></label>
                        <%: Html.TextBoxFor(model => model.ValidTill)%>
                        <%: Html.ValidationMessageFor(model => model.ValidTill)%></div>
                </div>
            </div>
         <label><%: Html.LabelFor(model => model.CardRule) %></label>
          <div id="Rules">
                <p style="width:500px; height:400px; overflow:auto;"> 
               
                     <%:Html.HiddenFor(model=>model.CardRule) %>
                     
                </p>
                </div>
                </div>
            </div>
            
          
          
     
     
    <%} %>

    <script language ="text/javascript" type ="text/javascript">

    $(document).ready(function(){
    $("#ValidTill").val('');
    
    } );
        $("#ValidTill").datepicker({
                
                numberOfMonths: 1,
                disable: true,
                showOn: 'both',
                minDate:new Date(),
                buttonImage: '../../Content/images/calendar.gif',
               
            });
        $(function () {
            var availableTags = [
			"499",
			"999",
			"1499",
			"1999",
			"2499",
			"2999",
			"3499",

		];
            $("#CardValue").autocomplete({
                source: availableTags
            });
        });


             $("#CardTypeId").change(function () {
             if (this.value == "") {
                
                 return false;
             }
            
             //build the request url
             var url = "/Hotel/AjaxRequest/CardType";
             var id = $("#CardTypeId").val();
             //fire off the request, passing it the id which is the MakeID's selected item value

             $.getJSON(url, { id: id },
             function (data) {
                 //Clear the Model list
                 $("#Rules").empty();
                 var rule = data;

                 $("#CardRule").val(rule);
                 var html = "";
                 html += rule;


                 $("#Rules").append(html);

                 //Foreach Model in the list, add a model option from the data returned

             }
             );
         }).change();
   
            
           //End of document ready function


//               
//             $("#CardTypeId").change(function () {
//                 if (this.value == "") {
//                     return false;
//                 }
//                 //build the request url
//                 var url = "/CardRegistration/CardType";
//                 var id = $("#CardTypeId").val();
//                 //fire off the request, passing it the id which is the MakeID's selected item value
//    
//                 $.getJSON(url, { id: id },
//             function (Data) {
//                 //Clear the Model list
//                 $("#CardRule").empty();
//                 var rule = Data;

//                 $("#CardRule").val(rule);
//                 var html = "";
//                 html += rule;

//                 $("#CardRule").after(html);

//                 Foreach Model in the list, add a model option from the data returned

//             }
//             );
//             }).change();
    </script>
         <%--  <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
       --%>