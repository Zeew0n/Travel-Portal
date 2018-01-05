<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>" %>
<% using (Html.BeginForm("Edit", "CardRegistration",FormMethod.Post))
   {%>
        <%: Html.ValidationSummary(true) %>
        

 <div class="box3">
        <div class="userinfo">
            <h3>
               Edit Registered Card
            </h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <input type="submit" value="Update" class="save"  />
                </li>
              
            </ul>
        </div>
    </div>

        
        <fieldset>

            <div class="row-1">
           		
            	<div class="form-box1 round-corner">

                  <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Number:</label> 
                                       <%: Html.TextBoxFor(model => model.CardNumber) %>
                                </div>                          
                        </div>
                        </div>
                        <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Type:</label>
                                     <%: Html.DropDownListFor(model => model.CardTypeId,Model.CardTypeList )%>
                                </div>                          
                        </div>
                    </div>
                     <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Value:</label>
                                   <%: Html.TextBoxFor(model => model.CardValue) %>
                                </div>                          
                        </div>
                        </div>
                          <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Valid Till:</label>
                                    <%: Html.TextBoxFor(model => model.ValidTill, String.Format("{0:g}", Model.ValidTill)) %>
                                </div>                          
                        </div>
                    </div>
                   
                        <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Is Active:</label>
                                 <%if (Model.CardStatusId == 2){%>
                                 
                                   <%: Html.CheckBoxFor(model => model.isActive, new { @disabled = "disabled" })%>
                                 <%  }else {%> 
                                      <%: Html.CheckBoxFor(model => model.isActive) %>
                                 <%  } %>
                                </div>                          
                        </div>
                        </div>
         
                     <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Status:</label>  
                                      <%: Html.DropDownListFor(model => model.CardStatusId, Model.CardStatusList , new { @disabled = "disabled" })%>
                                </div>                        
                        </div>
                        </div>
                 
                  <div   class="form-box1-row" >
                        <div id="Rules" class="form-box1-row-content float-left">                          
                                <div >
                                   <%: Model.CardRule %>
                                </div>                          
                        </div>
                       </div> 
                     </div> 
    </div>
    </fieldset>

          <% } %>  


           <script type="text/javascript">


//               $("#CardTypeId").change(function () {
//                   if (this.value == "") {
//                       return false;
//                   }
//                   //build the request url
//                   var url = "/CardRegistration/CardType";
//                   var id = $("#CardTypeId").val();
//                   //fire off the request, passing it the id which is the MakeID's selected item value

//                   $.getJSON(url, { id: id },
//             function (Data) {
//                 //Clear the Model list
//                 $("#CardRule").empty();
//                 var rule = Data;

//                 $("#CardRule").val(rule);
//                 var html = "";
//                 html += rule;

//                 $("#CardRule").replace(html);

//                 //Foreach Model in the list, add a model option from the data returned

//             }
//             );
               //               }).change();
 $(document).ready(function () {

     $("#ValidTill").datepicker({
         defaultDate: new Date($(this).val()),
         numberOfMonths: 1,
         disable: true,
         showOn: 'button',
         buttonImage: '../../Content/images/calendar.gif',
         minDate: new Date()
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
     }
             );
            </script>
