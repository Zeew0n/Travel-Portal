<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<div class="ControllerGroup">
	
  
     <div class="form-box1">
                
     <% using (Html.BeginForm("RegisterNewController", "AjaxRequest", FormMethod.Post))
        {%>

           <div class="form-box1-row-content">   
                                <div>
                              <label>Product :</label>
                              <%:Html.DropDownListFor(model => model.ProductId, Model.ProductList, "-----Select-----", new{@id="Product1" })%>
                                <%: Html.ValidationMessageFor(model => model.ProductId,"*")%>
                               </div>
                                </div>
             <div class="form-box1-row-content">   
                                <div>
                              <label>Sub Product :</label>
                              <%:Html.DropDownListFor(model => model.SubProductId, Model.SubProductList, "-----Select-----", new { @id="SubProductId1"})%>
                                <%: Html.ValidationMessageFor(model => model.SubProductId, "*")%>
                               </div>
                                </div>                 

         
      <div class="form-box1-row-content">                           
                             <div><label>Controller Name:</label> 
                                 <%: Html.TextBoxFor(model => model.ControllerName)%>      
                                <%: Html.ValidationMessageFor(model => model.ControllerName)%>
                            </div>                           
                        </div>

                         <div class="form-box1-row-content">                           
                             <div><label>Controller Label:</label> 
                                 <%: Html.TextBoxFor(model => model.ControllerLabel)%>      
                                <%: Html.ValidationMessageFor(model => model.ControllerLabel)%>
                            </div>                           
                        </div>

                        <div class="form-box1-row-content">   
                                <div>
                              <label>Group :</label>
                              <%:Html.DropDownListFor(model => model.GroupId, Model.GroupNameList, "-----Select-----", new { @id = "GroupId1" })%>
                                <%: Html.ValidationMessageFor(model => model.GroupId, "*")%>
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
<div id="contentFormUpdatePanel2">
       <%: Html.Partial("~/Areas/Administrator/Views/PriviledgeSetup/VUC_PriviledgeList.ascx")%>
   </div>
<script type="text/javascript">

            $("#Product1").change(function () {
               var id = $("#Product1").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetSubGroupNameProductId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#SubProductId1").empty();
                        $("#SubProductId1").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {
                            $("#SubProductId1").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });

                }
            }).change();
            ////////////////////////////////////////////////////////
            $("#SubProductId1").change(function () {
                var id = $("#Product1").val();
                var SubProductId = $("#SubProductId1").val();
                var ProductId = id;
                if (SubProductId == "") {
                    $("#GroupId1").empty();
                    $("#GroupId1").append("<option value=''>" + "-- Select--" + "</option>");
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetGroupNameProductId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#GroupId1").empty();
                        $("#GroupId1").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#GroupId1").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                    $(function () {
                        $.ajax({
                            type: "POST",
                            url: "/Administrator/PriviledgeSetup/Index",
                            data: { ProductId: ProductId, SubProductId: SubProductId },
                            dataType: "html",
                            traditional: true,
                            success: function (result) {
                                $("#contentFormUpdatePanel2").empty().append(result);
                            }

                        });
                    });
                }
            }).change();
            ////////////////////////////////////////////////////////////////////////
 </script>
            