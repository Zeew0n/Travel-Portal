<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.CustomerIsssueCard>" %>
<%@ Import Namespace ="ATLTravelPortal.Areas.Hotel.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
    if ( ViewData["success"] != null )
    { %>
     <%: ViewData["success"] %>
   
     <%
    
    }
 %>

   <div class="box3">
        <div class="userinfo">
            <h3>
              <b>Issue Customer Card For    <%: TempData["AgentName"]%></b></h3>
        </div>
        <div class="buttons-panel">
            <ul>
             
    
            
            <li><input type="submit" value="Show All" class="search"/></li>
            
            </ul>
        </div>
    </div>
 <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend></legend>

     <div class="row-1">
      <div class="form-box1 round-corner">
      <ul class="listStyle5"><%:Html.Hidden("AgentId",Model.AgentId )%>
     <% foreach (var item in Model.CustomerCard)
        {
            
                      %>
           
            <li><%:item%></li>

           
         
     <%} %>
     <%foreach (var result in Model.CustomerCardId)
       {%>
         <input type="hidden" name="CardsId" value="<%:result%>" />
      <% } %>
             </ul>
              <div class="form-box1-row">
               <%-- <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.CardNumber)%></label>
                        <%: Html.TextBoxFor(model => model.CardNumber)%>
                <%: Html.ValidationMessageFor(model => model.CardNumber)%>
                      </div>
                    </div>--%>
             
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.CustomerCode)%></label>
                         <%: Html.TextBoxFor(model => model.CustomerCode)%>
                <%: Html.ValidationMessageFor(model => model.CustomerCode)%>
                    </div>
                </div>
                 </div>

             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.FirstName)%></label>
                        <%: Html.TextBoxFor(model => model.FirstName)%>
                <%: Html.ValidationMessageFor(model => model.FirstName)%>
                      </div>
                    </div>
               
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.MiddleName)%></label>
                         <%: Html.TextBoxFor(model => model.MiddleName)%>
                <%: Html.ValidationMessageFor(model => model.MiddleName)%>
                    </div>
                </div> 
                 </div>
                
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.LastName)%></label>
                        <%: Html.TextBoxFor(model => model.LastName, new { maxlength="50" ,size="50"})%>
                <%: Html.ValidationMessageFor(model => model.LastName)%>
                      </div>
                    </div>
              
               <%-- <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.Gender)%></label>
                         <%: Html.TextBoxFor(model => model.Gender)%>
                <%: Html.ValidationMessageFor(model => model.Gender)%>
                    </div>
                </div>--%>
                 </div>
                
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.DateOfBirth)%></label>
                        <%: Html.TextBoxFor(model => model.DateOfBirth)%>
                <%: Html.ValidationMessageFor(model => model.DateOfBirth)%>
                      </div>
                    </div>
               
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.Address1)%></label>
                         <%: Html.TextBoxFor(model => model.Address1)%>
                <%: Html.ValidationMessageFor(model => model.Address1)%>
                    </div>
                </div> 
                 </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.Address2)%></label>
                        <%: Html.TextBoxFor(model => model.Address2)%>
                <%: Html.ValidationMessageFor(model => model.Address2)%>
                      </div>
                    </div>
              
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.HouseNo)%></label>
                         <%: Html.TextBoxFor(model => model.HouseNo)%>
                <%: Html.ValidationMessageFor(model => model.HouseNo)%>
                    </div>
                </div> 
                 </div>
              <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.City)%></label>
                        <%: Html.TextBoxFor(model => model.City)%>
                <%: Html.ValidationMessageFor(model => model.City)%>
                      </div>
                    </div>
             
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.ZipCode)%></label>
                         <%: Html.TextBoxFor(model => model.ZipCode)%>
                <%: Html.ValidationMessageFor(model => model.ZipCode)%>
                    </div>
                </div> 
                 </div>
             <div class="form-box1-row">
                <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                      <%: Html.Label("Country")%></label>
                         <%: Html.DropDownListFor(model => model.CountryID , Model.CountryList,"--- Select ---")%>
                        <%= Html.ValidationMessageFor(m => m.CountryID)%>   
                      </div>
                    </div>
              
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.HomePhone)%></label>
                         <%: Html.TextBoxFor(model => model.HomePhone)%>
                <%: Html.ValidationMessageFor(model => model.HomePhone)%>
                    </div>
                </div> 
                 </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.WorkPhone)%></label>
                        <%: Html.TextBoxFor(model => model.WorkPhone)%>
                <%: Html.ValidationMessageFor(model => model.WorkPhone)%>
                      </div>
                    </div>
             
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.MobileNo)%></label>
                         <%: Html.TextBoxFor(model => model.MobileNo)%>
                <%: Html.ValidationMessageFor(model => model.MobileNo)%>
                    </div>
                </div> 
                 </div>
                
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.FaxNo)%></label>
                        <%: Html.TextBoxFor(model => model.FaxNo)%>
                <%: Html.ValidationMessageFor(model => model.FaxNo)%>
                      </div>
                    </div>
            
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.Email)%></label>
                         <%: Html.TextBoxFor(model => model.Email)%>
                <%: Html.ValidationMessageFor(model => model.Email)%>
                    </div>
                </div> 
                 </div>
              <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <%: Html.LabelFor(model => model.Profession)%></label>
                        <%: Html.TextBoxFor(model => model.Profession)%>
                <%: Html.ValidationMessageFor(model => model.Profession)%>
                      </div>
                    </div>
              
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.CustomerTypeId)%></label>
                        <%: Html.DropDownListFor(model => model.CustomerTypeId, Model.CustomerTypeList ,"---Select---" )%>
                <%: Html.ValidationMessageFor(model => model.CustomerTypeId)%>
                    </div>
                </div> 
                 </div>
              <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CustomerStatus)%></label>
                            <%: Html.DropDownListFor(model => model.CustomerStatus, Model.CustomerStatusList )%>
                            <%: Html.ValidationMessageFor(model => model.CustomerStatus)%>
                      </div>
                    </div>
              
                <%--<div class="form-box1-row-content float-right">
                    <div>
                        <label>
                                <%: Html.LabelFor(model => model.Created)%></label>
                                <%: Html.TextBoxFor(model => model.Created)%>
                                <%: Html.ValidationMessageFor(model => model.Created)%>
                        </div>
                     </div> --%>
                <div>
                  <%:Html.HiddenFor(model => model.HFCustomerID)%>  

                </div>
                 </div>
          
                </div>
                  </div> 
          
          </div>


            
        
            
            <p>
                <input type="submit" value="Create" class="btn3"/>
         <input name="reset" type="reset" value="Clear Form" class="btn3" />

            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssContent" runat="server">
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
              $(function () {
                          Agentid = $("#AgentId").val();
                         $("#CardNumber").autocomplete({
                      
                   source: function (request, response) {
                      $.ajax({
                           url: "/CustomerCard/FindCardByAgent", type: "POST", dataType: "json",
                           data: { searchText: request.term, Agentid: Agentid, maxResult: 5 },

                           success: function (data) {
                                response($.map(data, function (item) {
                                   return { label: item.CardNumber, value: item.CardNumber, id: item.CardId }
                              }))
                           }
                       })
                   },
                  width: 150,
                  select: function (event, ui) {
                      $("#HFCardId").val(ui.item.id);

                   }

            });
          });
          /////////////////////////////////////////////////////////////////////////////////////////////////
            </script>     --%>
              <script type="text/javascript">
          ////////////////////////////////////////////////////////////////////
                  $(function () {
                      $("#CustomerCode").autocomplete({
                          source: function (request, response) {
                              $.ajax({
                                  url: "/Hotel/AjaxRequest/FindCustomerInfo", type: "POST", dataType: "json",
                                  data: { searchText: request.term, maxResult: 5 },

                                  success: function (data) {
                                      response($.map(data, function (item) {
                                          return {


                                              label: item.CustomerCode, value: item.CustomerCode, id: item.CustomerID,
                                              LastName: item.LastName, FirstName: item.FirstName, DateOfBirth: item.DateOfBirth, CountryID: item.CountryID,
                                              Address1: item.Address1, HouseNo: item.HouseNo, City: item.City, ZipCode: item.ZipCode, HomePhone: item.HomePhone, WorkPhone: item.WorkPhone,
                                              MobileNo: item.MobileNo, Email: item.Email, Profession: item.Profession, CustomerStatus: item.CustomerStatus
                                          }

                                      }))
                                  }
                              })
                          },
                          width: 150,
                          select: function (event, ui) {

                              $("#LastName").val(ui.item.LastName);
                              $("#CustomerCode").val(ui.item.CustomerCode);

                              //Added Date conversion by MADDY 
                              var taskDate = new Date(+ui.item.DateOfBirth.replace(/\/Date\((-?\d+)\)\//gi, "$1"));

                              var month = taskDate.getMonth();
                              var year = taskDate.getFullYear();
                              var date = taskDate.getDate();

                              month = GetMonths(month);

                              ;
                              //Maddy Closes
                              $("#DateOfBirth").val(date + ' ' + month + ' ' + year);
                              $("#Address1").val(ui.item.Address1);
                              $("#CountryID").val(ui.item.CountryID);
                              $("#City").val(ui.item.City);
                              $("#HouseNo").val(ui.item.HouseNo);
                              $("#ZipCode").val(ui.item.ZipCode);
                              $("#HomePhone").val(ui.item.HomePhone);
                              $("#WorkPhone").val(ui.item.WorkPhone);
                              $("#MobileNo").val(ui.item.MobileNo);
                              $("#Email").val(ui.item.Email);
                              $("#Profession").val(ui.item.Profession);
                              $("#CustomerStatus").val(ui.item.CustomerStatus);




                          }
                      });

                  });

                 

                 /////////////////////////////////////////////////////////////////////////////////////////////////
          </script>  

         
  

             

</asp:Content>

