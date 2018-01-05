<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.AirPackageGroupModel>" %>


   <%-- <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

     <div class="pageTitle">
            <ul class="buttons-panel">
                <li><div id="loadingIndicator"></div></li>

                <li><input type="submit" value="Save" /> </li>
                <li>
                    <input type="button" onclick="document.location.href='/Airline/AirPackageGroup/Index'" value="Cancel" />
                </li>
           </ul>          
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create Group Package</strong>
        </h3>
    </div>--%>
            
          <div class="row-1">
           <div class="form-box1 round-corner">
            <div class="form-box1-row">  
             <div class="form-box1-row-content float-left" style="width: 90%;">
                    <div>
                        <%: Html.LabelFor(model => model.CountryId) %>
                        <%: Html.DropDownListFor(model => model.CountryId, Model.ddlCountryList, new { @onchange = "JqueryAjaxLoadSelectOption(this.value,'CityId','/AirLine/AjaxRequest/GetCoreCityOptions/')" })%>
                        <%: Html.ValidationMessageFor(model=>model.CountryId)%>
                    </div>
                     <div>
                        <%: Html.LabelFor(model => model.ZoneId)%>
                        <%: Html.DropDownListFor(model => model.ZoneId, Model.ddlZoneList,"--Select--")%>
                        <%: Html.ValidationMessageFor(model => model.ZoneId)%>
                    </div>
                    <div>
                        <%: Html.LabelFor(model => model.GroupName) %>
                        <%: Html.TextBoxFor(model => model.GroupName)%>
                        <%: Html.ValidationMessageFor(model => model.GroupName)%>
                    </div>
                               
                     <div>
                        <%: Html.LabelFor(model => model.URL)%>
                        <%: Html.TextBoxFor(model => model.URL, new { @style = "width :586px;" } )%>
                        <%: Html.ValidationMessageFor(model => model.URL)%>
                     </div>
            </div>
              
                 <div style="width: 90%;">  
                    <div>
                        <%: Html.LabelFor(model => model.Destination)%>
                        <%: Html.TextAreaFor(model => model.Destination, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.Destination)%>
                    </div>
                 </div>

             <%--   <div class="form-box1-row-content float-left" style="width: 90%;">
                     <div>
                        <%: Html.LabelFor(model => model.IsB2BPackage)%>
                        <%: Html.CheckBoxFor(model => model.IsB2BPackage)%>
                        <%: Html.ValidationMessageFor(model => model.IsB2BPackage)%>
                    </div>
                   
                    <div>
                        <%: Html.LabelFor(model => model.IsB2CPackage)%>
                        <%: Html.CheckBoxFor(model => model.IsB2CPackage)%>
                        <%: Html.ValidationMessageFor(model => model.IsB2CPackage)%>
                    </div>
                </div>--%>

           </div>
          </div>
         </div>
        
   
      

  

  
<link href="/Content/autocomplete.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/json.cycle.js" type="text/javascript"></script>
<script src="/Scripts/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>

<script type="text/javascript">

    $(document).ready(function () {
        $("input[id='GroupName']").keyup(function () {
            var valTitle = $(this).val();
            var valURL = valTitle.split(' ').join('-').toLowerCase();
            $("input[id='URL']").val(valURL);
        });
    });
     

        function JqueryAjaxLoadSelectOption(selValue, targetElm, url) {
            $.ajax({
                async: false,
                type: "POST",
                url: url + selValue,
                contentType: "text/json",
                data: ({ id: selValue }),
                beforeSend: function () {
                    $("#" + targetElm).attr('disabled', 'disabled');
                    $("#" + targetElm).addClass('ac_loading');
                },

                success: function (jsonResult) {

                    var evlResult = JSON.retrocycle(jsonResult);
                    var selOption = "";
                    selOption = ParseJsonResultForSelectOptions(evlResult);
                    tempTargetElm = targetElm.split(',');
                    for (var i = 0; i < tempTargetElm.length; i++) {
                        // alert(tempTargetElm.length + " : " + tempTargetElm[i]);
                        $("#" + tempTargetElm[i]).empty().append(selOption);
                        $("#" + tempTargetElm[i]).removeClass('ac_loading');
                        $("#" + tempTargetElm[i]).removeAttr('disabled');
                    }


                },
                error: function (jsonResult) {
                    // alert(jsonResult);
                }
            });

        }




        function ParseJsonResultForSelectOptions(evlResult) {
            var selOption = "";
            $.each(evlResult, function (key, item) {
                var isSelected = (item['Selected'] == "true") ? "Selected='Selected'" : "";
                //var otherAttrib = (item['Attribs']!=undefined)? item['Attribs']:"";
                var otherAttrib = "";
                $.each(item, function (name, value) {
                    if (name != 'Selected' && name != 'Value' && name != 'Text') {
                        otherAttrib += " " + name + '="' + value + '" ';
                    }
                });
                selOption += "<option value='" + item['Value'] + "' " + isSelected + " " + otherAttrib + " >"
                + evlResult[key].Text + "</option>";
            });
            return selOption;
        }

</script>
