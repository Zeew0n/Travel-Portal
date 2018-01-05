<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<div class="ControllerGroup">
	
  
     <div class="form-box1">
                
     <% using (Html.BeginForm("CreateControllerGroup", "AjaxRequest", FormMethod.Post))
        {%>

           <div class="form-box1-row-content">   
                                <div>
                              <label>Product :</label>
                              <%:Html.DropDownListFor(model => model.ProductId, Model.ProductList, "-----Select-----", new { @id = "Product01" })%>
                                <%: Html.ValidationMessageFor(model => model.ProductId,"*")%>
                               </div>
                                </div>
                              
      <div class="form-box1-row-content">                           
                             <div><label>Group Name:</label> 
                                 <%: Html.TextBoxFor(model => model.GroupName)%>      
                                <%: Html.ValidationMessageFor(model => model.GroupName)%>
                                      
                            </div>                           
                        </div>
                        <div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Save" class="btn3" />                          
                        </p>                        
                </div> 
     <%} %>

</div>
</div>
  <div id="contentFormUpdatePanel1">
       <%: Html.Partial("~/Areas/Administrator/Views/PriviledgeSetup/VUC_PriviledgeList.ascx")%>
   </div>
<script type="text/javascript">
    $(document).ready(function () {
        $("#Product01").change(function () {
            var ProductId = $("#Product01").val();
             if (ProductId == "") {
             
                return false;
            }
            else {
        
                $(function () {
                    $.ajax({
                        type: "POST",
                        url: "/Administrator/PriviledgeSetup/Index",
                        data: { ProductId: ProductId },
                        dataType: "html",
                        traditional: true,
                        success: function (result) {
                            $("#contentFormUpdatePanel1").empty().append(result);
                        }

                    });
                });
                $("#loadingIndicator").html('');
            }
        }).change();
    });

     </script>