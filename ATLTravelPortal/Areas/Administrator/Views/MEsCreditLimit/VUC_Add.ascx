<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.MEsCreditLimitModel>" %>
   
          <fieldset class="style1">               
              <div class="form-box1-row">                   
                    <div class="form-box1-row-content float-left">
                       <div>
                         <%: Html.LabelFor(model => model.MEsID) %>   
                         <%: Html.DropDownListFor(model => model.MEsID,Model.MEsList) %>
                         <%: Html.ValidationMessageFor(model => model.MEsID) %>
                    
                              <%: Html.LabelFor(model => model.CurrencyID) %>      
                              <%: Html.DropDownListFor(model => model.CurrencyID, Model.CurrencyList)%>
                              <%: Html.ValidationMessageFor(model => model.CurrencyID)%>
                                                      
                              <%: Html.LabelFor(model => model.Amount) %>          
                              <%: Html.TextBoxFor(model => model.Amount) %>
                              <%: Html.ValidationMessageFor(model => model.Amount) %>
                       
                             <%: Html.LabelFor(model => model.EffictiveFrom) %> 
                             <%: Html.TextBoxFor(model => model.EffictiveFrom) %>
                             <%: Html.ValidationMessageFor(model => model.EffictiveFrom) %>
                               
                             <%: Html.LabelFor(model => model.ExpireOn) %>                 
                             <%: Html.TextBoxFor(model => model.ExpireOn) %>
                     
             </div>    </div></div>
           
        </fieldset>

