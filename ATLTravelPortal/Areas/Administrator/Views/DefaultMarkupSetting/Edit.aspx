<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlinePortalMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATBackOffice.DataModel.GetAdminAirlineMarkupValueList_Result>>" %>
<%@ Import Namespace="ATBackOffice.Helpers"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin Airline MarkUp Setting
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
              <div class="box3">
        <div class="userinfo">
            <h3>
                Admin Airline MarkUp Setting</h3>
        </div>
        
          <div class="buttons-panel">
            <ul>
            
            </ul>
        </div>
    </div>
     <%using (Ajax.BeginForm("Edit", new { controller = "DefaultMarkUpSetting", action = "Edit", }
               , new AjaxOptions()
                      {
                          UpdateTargetId = "AirlineMarkUp",
                          InsertionMode = InsertionMode.Replace  
                      ,HttpMethod="Post"
                      }, new { @class = "validate" }))
              { %>

                <div class="row-1">           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label><%: Html.Label("Airline")%></label>
                                          <%=Html.TextBox("SearchAirline","", new { @class = "required" })%>
                                 </div> 
                            </div>                           
                        </div>                        
             
                
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">                      
                          <input type="submit" value="Search" class="btn3" />
                        </p>                        
                    </div>                                                       
                </div>
            </div>

               <div id="AirlineMarkUp">
                    <%Html.RenderPartial("EditPartial"); %>                   
                 </div>

                    <%} %>
 

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../Content/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/jquery.ui.autocomplete.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.ac_loading {
	background: transparent url('../../../Content/Images/indicator.gif') right center no-repeat;
	
}
</style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

<script src="../../Scripts/MicrosoftMvcJQueryValidation.js" type="text/javascript"></script>    
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>   
    <link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>  
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
<script src="../../Scripts/jSONcycle.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var arrChangeValue = new Array();
    function myTest(txtName, txtValue) {
        this.txtName = txtName; this.txtValue = txtValue;
    }
    function checkValueChange(txtBoxId, txtBoxVal) {
        var addElm = true;
        var callFun = false;
        if (txtBoxId == null || txtBoxId == "" || txtBoxId == null || txtBoxId == "") return false;
        for (var i = 0; i < arrChangeValue.length; i++) {
            var obj = arrChangeValue[i];

            if (obj["txtName"] == txtBoxId) {
                if (obj["txtValue"] != txtBoxVal) {
                    obj["txtValue"] = txtBoxVal;
                    callFun = true;

                }
                addElm = false;
                break;
            }
        }
        if (addElm) {
            arrChangeValue.push(new myTest(txtBoxId, txtBoxVal));
            callFun = true;

        }
        return callFun;
    }


    function jqueryPostOnBlur(elmAirID, defaultMakrupValue, thisElm, url, targetElm) {
        var markUpValue = thisElm.value;
        if (markUpValue != defaultMakrupValue) {
            if (checkValueChange(elmAirID, markUpValue) == true) {
                $.ajax({
                    async: false,
                    type: "POST",
                    url: url,
                    data: ({ id: elmAirID, value: markUpValue }),
                    beforeSend: function () { $("#" + thisElm.id).attr('disabled', 'disabled'); $("#" + thisElm.id).addClass('ac_loading'); },
                    success: function (result) {
                        var evlResult = JSON.retrocycle(result)
                        if (evlResult['responseStatus'] == "false") {
                            alert(evlResult['responseMsg'])
                        }
                    }
                });
                $("#" + thisElm.id).removeClass('ac_loading');
                $("#" + thisElm.id).removeAttr('disabled');
                HideLoadingBox();
            }
        }
    }
//   
//             function beginList(args) {
//                 // Animate
//                 $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/loadingAnimation.gif") %>" alt="" width="140px" height="100px" />   </center>');
//             }

//             function successList() {
//                 // Animate loadingAnimation
//                 $("#loadingIndicator").html('');

//             }
    

</script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('.validate').validate();
             $(function () {
                 $("#SearchAirline").autocomplete({
                     minlength: 2,
                     source: function (request, response) {
                         $.ajax({
                             url: "/Airline/FindAirline", type: "POST", dataType: "json",
                             data: { searchText: request.term, maxResult: 5 },

                             success: function (data) {
                                 response($.map(data, function (item) {
                                     return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                                 }))
                             }
                         })
                     },
                     width: 150,
                     select: function (event, ui) {
                         $("#AirlineId").val(ui.item.id);

                     }
                 });
             });
         });
    </script>
</asp:Content>

