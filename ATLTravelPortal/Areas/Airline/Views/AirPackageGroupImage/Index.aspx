 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageGroupImageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("~/Views/Shared/Utility/VUC_ActionResponse.ascx"); %>
    
    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Group Package Management</a> <span>&nbsp;</span><strong>Package Image List</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null)
           { %>

             <% if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
              { %>  
           
           
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">

            <thead>
                <tr>
                    <th>SNo.</th>
                    <th>Caption</th>                  
                    <th>Name</th>  
                    <th>Default</th>                
                    <th>Action</th>                   
                </tr>
            </thead>

            <% var sno = 0;
               foreach (var item in Model.TablularRecordList)
               {

                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
            <tr>
            <td><%:sno%></td>
            <td><%: item.ImageCaption%></td>     
            <td><%: item.ImageName%></td>            
            <td><input type="radio" id="PackageDefaultGroupImageId<%:item.PackageGroupImageId %>" 
            name="PackageDefaultGroupImageId" value="<%: item.PackageGroupImageId %>" title="click to set the default image" /></td>            
            <td>
                <p>                    
                    <a href="/Airline/AirPackageGroupImage/Delete/<%: item.PackageGroupImageId %>?PID=<%: item.PackageGroupId %>" 
                    class="delete" title="Delete"
                    onclick="return DeleteConfirm('Are you sure you want to delete?')"></a>
                    </p>
               </td>
            </tr>
          
          <%} %>

        </table>       
            <%
                }
             }
           
            if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
           { %>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
      


    </div>
    <div style="clear:both;"></div>
     <div class="">
     <button onclick="AddTableRowMaster();">Add More</button>
     <button onclick="DeleteTableRows('dynamicFileUploader','1');">Delete</button>
     <div id="divAddDeleteTableRowMsg"></div>
      <% Html.EnableClientValidation(); %>
     <%using (Html.BeginForm("", "", FormMethod.Post, new { @enctype = "multipart/form-data", @id = "ATForm", @name = "ATForm" }))
      { %>
      <%=Html.ValidationSummary(true)%>      
      <%:Html.HiddenFor(m=>m.PackageGroupId) %>
      <table id="dynamicFileUploader">
      <tr>
      <td>
        <%:Html.Hidden("ImageUploader.Index", 0)%>         
        <%:Html.LabelFor(model => model.ImageUploader[0].UploadedImageCaption)%>
        <%:Html.TextBoxFor(model => model.ImageUploader[0].UploadedImageCaption)%>           
        <%:Html.ValidationMessageFor(model => model.ImageUploader[0].UploadedImageCaption)%> 
      </td>
      <td>
        <input type="file" name="ImageUploader[0].UploadedFile" id="ImageUploader_0__UploadedFile" />                  
       <%: Html.ValidationMessageFor(model => model.ImageUploader[0].UploadedFile)%>
      </td>
      <td></td>
      
      </tr>
      </table>       
      <input type="submit" name="Upload" value="Upload" />
       <a href="/Airline/AirPackageGroup/Index" class="new linkButton" title="New">Cancel</a>
  
      <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="/Scripts/jquery.validate.min.js" type="text/javascript"></script>
<script src="/Scripts/ATL.function.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript">

        var tblRowIncrease = 0;
        function AddTableRowMaster() {

            $("#divAddDeleteTableRowMsg").empty();
            $('#dynamicFileUploader tbody:first>tr:last').clone(true).insertAfter('#dynamicFileUploader tbody:first>tr:last');
            $('#dynamicFileUploader tbody:first>tr:last>td:last').empty().append("<input type=\"image\" id=\"imgDelete\" name=\"imgDelete\" alt='Delete' src='/Content/Icons/Delete.png' onclick='DeleteTableRow(this)' />");
            ResetTableRowsIdDynamicModel("dynamicFileUploader");

        }
        function DeleteTableRows(tableId, minCount) {
            var elmTable = document.getElementById(tableId);
            if (elmTable.rows.length > minCount) {
                if (confirm("Are you sure to delete the row?")) {
                    elmTable.deleteRow(elmTable.rows.length - 1);
                }
            } else {
                $("#divAddDeleteTableRowMsg").empty().append('No more rows to delete!');
            }
        }
        // reset the table id DynamicModel
        function ResetTableRowsIdDynamicModel(tableId) {
            tblRowIncrease++;
            var Form = $('#' + tableId + ' tbody:first>tr:last select,' + '#' + tableId + ' tbody:first>tr:last input,' + '#' + tableId + ' tbody:first>tr:last textarea');
            Form.each(function () {
                var suffix = "[" + tblRowIncrease + "].";

                var elmName = this.name;
                var elmId = "";
                var elmType = "";
                var elmNamePrePosition = elmName.lastIndexOf("[");
                var elmNameSufPosition = elmName.lastIndexOf("]");
                if (elmNamePrePosition > 1 && elmNameSufPosition > 1) {
                    var name = elmName.substring(0, elmNamePrePosition);
                    var nameSuf = elmName.substring(elmNameSufPosition + 2);
                }
                else {
                    var name = elmName;
                }
                elmName = name + suffix + nameSuf;
                elmId = name + "_" + tblRowIncrease + "__" + nameSuf;
                //alert(name + " : " + elmType + " : " + this.name);
                if (name.lastIndexOf(".Index") > 1) {
                    //alert(tblRowIncrease);
                    $(this).val(tblRowIncrease);
                } else {
                    $(this).removeAttr('name').attr('name', elmName);
                }

                $(this).removeAttr('id').attr('id', elmId);
                //for validation elm 
                var objL = $("#" + this.id).siblings(".field-validation-valid");
                if (objL.length >= 1) {
                    $("#" + this.id).siblings("span.field-validation-valid").attr("id", elmId + "_validationMessage");
                } else {
                    $("#" + this.id).after('<span id="' + elmId + "_validationMessage" + ' cals"></span>');
                }

                if (this.type == 'select-one' && $(this).attr('rel') == 'MultiOption') {
                    var tempTargetElm = $(this).attr('relTarget').split(',');
                    var tempTargetUrl = $(this).attr('relUrlTarget').split(',');
                    var onclick = "";
                    if ($(this).attr('relOption') == "name") {
                        onclick += "LoadSelectOptionMultiple(this,'" + name + "[" + tblRowIncrease + "]." + "','" + tempTargetUrl + "');";

                    } else {
                        for (var i = 0; i < tempTargetElm.length; i++) {
                            onclick += "LoadSelectOptions(this,'" + name + "_" + tblRowIncrease + "__" + tempTargetElm[i] + "','" + tempTargetUrl[i] + "');";
                        }
                    }
                    $(this).attr("onChange", onclick);
                }

            });

        }

        $(document).ready(function () {
            $("#ATForm").validate();
            $("input[type='radio'][name='PackageDefaultGroupImageId']").live("click", function () {
                var data = $(this).val();
                $.ajax({
                    async: false,
                    type: "POST",
                    url: "/Airline/AirPackageGroupImage/SetDefaultGroupImage/" + data,
                    data: data,
                    success: function (result) {
                        if (result == "true") {
                            alert('Default Image Set Successfully!!');
                        } else {

                            alert('Error occured while setting default image!!');
                        }
                    }
                });

            });


        });
    </script>
</asp:Content>