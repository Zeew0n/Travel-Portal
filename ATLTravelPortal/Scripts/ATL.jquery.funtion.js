/**
* 
*/
//window.onhashchange = function() {
//    alert("hash changed!");
//};
$(function () {
    $(window).load(function () {
        $(".customTogglePanel h5").click();
    });
  
  
});

function ShowAjaxLoading(thisElmId) { 
    $("#"+thisElmId).empty().append('<div style="text-align: center;"><img alt="Loading..." src="/Content/Icons/indicator-big.gif"></div>');
}
function HideAjaxLoading(thisElmId) {
    $("#" + thisElmId).empty();
}
function ShowLoadingBox() {
    $("#myLoadingBox").show();
}
function HideLoadingBox() {
    $("#myLoadingBox").hide();
}
function ShowMessageBox(msg, imgIndex) {

    var imgArr = new Array();
    imgArr[0] = "/Content/Icons/success.png";
    imgArr[1] = "/Content/Icons/error.png";
    imgArr[2] = "/Content/Icons/exclamation.png";
    HideLoadingBox();
    $("#imgFooterMessage").attr({ src: imgArr[imgIndex], alt: "Test Image" });
    $("#lblFooterMessage").empty().append(msg);
    $("#myMessageBox").show();

}
function HideMessageBox() {
    $("#myMessageBox").hide();
}
var countCloseBulk = 0;
function ShowMessageBoxBulk(msg, imgIndex) {
    $("#myMessageBoxBulkResponse").append(msg);
    $("#myMessageBoxBulk").show();
}

function HideMessageBoxBulk() {
    $("#myMessageBoxBulk").hide();
}

function ShowSuccessImage() {
    ShowHideIcon(siteRelativePath + '/icons/success.png', 'eeel', 'true');
}
function ShowHideIcon(iconPath, targetElm, boolShowHide) {
    var img = "<img src='" + iconPath + "' alt='img' />";
    $("#targetElm").empty().hide();
    if (boolShowHide == 'true') {
        $("#" + targetElm).show();
        $("#" + targetElm).empty().append(img);
    } else {
        $("#" + targetElm).hide();
        $("#" + targetElm).empty().append(img);
    }

}
function ShowSiblingMessage(elmIdSibling, msg) {
    var objL = $("#" + elmIdSibling).siblings(".error");
    if (objL.length >= 1) {
        $("#" + elmIdSibling).siblings("span.error").html(msg);
    } else {
        $("#" + elmIdSibling).after('<span class="error">' + msg + '</span>');
    }

}
function SlideUpElementView(thisElmId, slideTime) {
    var slideTime = (slideTime == null || slideTime == '') ? 1000 : slideTime;
    $("#" + thisElmId).slideUp(slideTime);
    return false;
}
function SlideDownElementView(thisElmId, slideTime) {
    var slideTime = (slideTime == null || slideTime == '') ? 1000 : slideTime;
    $("#" + thisElmId).slideDown(slideTime);
   
}
function EnableDisableElement(thisElm, targetElms, boolCondition) {
    var selValue = $("#" + thisElm.id).val();
    var propValue = false;
    if (selValue == 0 || selValue == '') {
        propValue = (boolCondition) ? true : false;
        //$("#"+targetElm).attr('disabled','disabled');
    } else if (selValue > 0 || selValue != '') {
        propValue = (boolCondition) ? false : true;
        // $("#"+targetElm).removeAttr('disabled','disabled');
    }
    setEnableDisable(targetElms, propValue);

}
function EnableDisableElementForCheckBox(thisElm, targetElms, boolCondition) {
    var checkValue = thisElm.checked;
    var propValue = false;
    if (checkValue == false) {
        propValue = (boolCondition) ? true : false;
    } else if (checkValue == true) {
        propValue = (boolCondition) ? false : true;
    }
    setEnableDisable(targetElms, propValue);


}
function setEnableDisable(targetElms, propValue) {
    if (targetElms == "" || targetElms == undefined) return;
    var elms = targetElms.split(',');
    for (var i = 0; i < elms.length; i++) {
        if (elms[i] != "" && elms[i] != undefined) {
            if (propValue)
                $("#" + elms[i]).removeAttr('disabled', 'disabled');
            else
                $("#" + elms[i]).attr('disabled', 'disabled');
        }
    }
}
function setActivity(targetElm, url, interval) {
    this.targetElm = targetElm;
    this.url = url;
    this.interval = (interval == null) ? valInterval : interval;
    this.valTimer;
}
function getActivity() {
    return jqueryRecentActivity(this.targetElm, this.url, this.interval);
}
function jqueryRecentActivity(targetElm, url, interval) {
    this.valTimer = setInterval("JqueryAjaxHtml('" + targetElm + "','" + url + "','false')", interval);
}
function stopTimer() {
    this.valTimer = clearTimeOut();
}
function JqueryAjaxHtml(targetElm, urlAction, showLoading) {
    
    $.ajax({
        type: "POST",
        url: urlAction,
        contentType: "text/html",
        beforeSend : (showLoading == "false") ? "" : ShowAjaxLoading(targetElm),
        success: function (htmlResult) {
            $("#" + targetElm).empty().append(htmlResult);
            
        }
    });
}

function jqueryPostController(thisForm, urlAction) {
    var data = "";
    data = $(thisForm).serialize();
   
    //data = GetJsonFormat(thisForm);
    //data=JSON.stringify(data, "#");
    //data = $.toJSON(data);
    ShowLoadingBox(); // $("#ajaxLoader").show();
    $.ajax({
        async: false,
        type: "POST",
        url: urlAction,
        data: data,
        //data: ({ id: this.getAttribute('id') }),
        //completed: $unblock(),
        success: function (result) {
            //$(this).addClass("done");
            // var domElement = $(result); // create element from html
            // $("#DivFormContent").append(domElement); // append to end of list    
            HideLoadingBox();
            $("#contentFormUpdatePanel").empty().append(result);
            //$.unblockUI();
        }
    });
    HideLoadingBox();
}

function jqueryPostControllerWithDynamicUpdateId(thisForm,urlAction,updateId)
{
 var data = "";
    data = $(thisForm).serialize();
    ShowLoadingBox(); // $("#ajaxLoader").show();
    $.ajax({
        async: false,
        type: "POST",
        url: urlAction,
        data: data,
        //data: ({ id: this.getAttribute('id') }),
        //completed: $unblock(),
        success: function (result) {
            //$(this).addClass("done");
            // var domElement = $(result); // create element from html
            // $("#DivFormContent").append(domElement); // append to end of list    
            HideLoadingBox();
            $("#"+updateId).empty().append(result);
        }
    });
    HideLoadingBox();
}

function jqueryPostJsonResponse(thisForm, targetElm) {
    var data = "";
    data = $(thisForm).serialize();
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: thisForm.method, //"POST",
        url: thisForm.action,
        data: data,
        success: function (result) {
             var evlResult = JSON.retrocycle(result);
            HideLoadingBox();
            var responseStatus,responseStatus,responseMsg;
            $.each(evlResult, function (key, item) {
                //alert(key+" :: "+item["Key"] +" :: "+evlResult[key].Key+""+evlResult[key].Value);
                if(evlResult[key].Key == "responseStatus")
                {
                    responseStatus = evlResult[key].Value;
                }
                if(evlResult[key].Key == "responseType")
                {
                    responseType = evlResult[key].Value;
                }
                if(evlResult[key].Key == "responseMsg")
                {
                    responseMsg = evlResult[key].Value;
                }
                
            });
            
            if (responseStatus == "true") {
                    ShowMessageBox(responseMsg, 0);
                } else if (responseStatus == "false") {
                    SShowMessageBox(responseMsg, 1);

                }
        }

    });
    HideLoadingBox();
}


function jqueryPost(thisForm, targetElm) {

    var data = "";
    data = $(thisForm).serialize();
    ShowLoadingBox(); // $("#ajaxLoader").show();
    $.ajax({
        async: false,
        type: thisForm.method, //"POST",
        url: thisForm.action,
        data: data,
        success: function (result) {
            HideLoadingBox();
            $("#" + targetElm).empty().append(result);
        }
    });
    HideLoadingBox();
}

function JquerySearchPost(thisForm, targetElm) {
    var data = "";
    data = $(thisForm).serialize();   
    $.ajax({
        async: false,
        type: thisForm.method, //"POST",
        url: thisForm.action,
        data: data,
        beforeSend :ShowAjaxLoading(targetElm),
        success: function (result) {
            $("#" + targetElm).empty().append(result);
        }
    });
}

function jqueryShareDocument(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "get",
        url: "/DMS/DMSDocument/CreateShortCut/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);

            $("#" + "DMSFile").empty().append(result);
            //            HideLoadingBox();
            //            if (evlResult['CheckResponseStatus'] == true) {
            //                ShowMessageBox("Record Successfully Deleted!", 0);
            //            } else if (evlResult['CheckResponseStatus'] == false) {
            //                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            //            }
        }

    });
    HideLoadingBox();
}

function jqueryCheckoutDocument(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "post",
        url: "/DMS/AjaxRequest/CheckoutDocument/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            if (result.ResponseStatus) {
                var updateStr = "<img id=\"checkoutIcon\" src=\"/Content/Icons/CheckOut_Icon.png\">";
                var row = "file_" + documendId;
                var checkOoutIcon = "checkoutIcon" + "_" + documendId;
                var isCheckout = "ischeckout" + "_" + documendId;
                $("#" + checkOoutIcon).attr("src", "/Content/Icons/CheckOut_Icon.png");
                var node = "node_" + documendId + "#" + sno;
                $("#" + node).attr(isCheckout, "True");
                var evlResult = JSON.retrocycle(result);
            }
            else 
            {
            alert(result.ResponseMessage);
            }
        }

    });
    HideLoadingBox();
}


function jqueryLockUnlockDocFromClientCore(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "post",
        url: "/Ajax/LockUnlockDocument/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            alert(result.ResponseMessage);
            var updateStr = "<img id=\"checkoutIcon\" src=\"/Content/Icons/CheckOut_Icon.png\">";
            var row = "file_" + documendId;
            var checkOoutIcon = "checkoutIcon" + "_" + documendId;
            if (result.ResponseStatus) {
                var lock = "Locked";
                if (result.ResponseTranactionMode == lock) {
                    $("#" + checkOoutIcon).attr("src", "/Content/Icons/lock.png");
                }
                else
                    $("#" + checkOoutIcon).attr("src", "/Content/Icons/Blank_Icon.png");

            }
            var evlResult = JSON.retrocycle(result);
        }

    });
    HideLoadingBox();
}

function jqueryLockUnlockDocument(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "post",
        url: "/DMS/AjaxRequest/LockUnlockDocument/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            alert(result.ResponseMessage);
            var updateStr = "<img id=\"checkoutIcon\" src=\"/Content/Icons/CheckOut_Icon.png\">";
            var row = "file_" + documendId;
            var checkOoutIcon = "checkoutIcon" + "_" + documendId;
            if (result.ResponseStatus) {
            var lock = "Locked";
                      if(result.ResponseTranactionMode==lock)
                      {
                    $("#" + checkOoutIcon).attr("src", "/Content/Icons/lock.png");
                    }
                    else
                   $("#" + checkOoutIcon).attr("src", "/Content/Icons/Blank_Icon.png");
               
            }
            var evlResult = JSON.retrocycle(result);
        }

    });
    HideLoadingBox();
}

function jqueryRestoreDocument(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "POST",
        url: "/DMS/DMSDocument/Restore/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);
            HideLoadingBox();
            var row = "file_" + documendId;
            $("#" + row).remove();
            if (evlResult['CheckResponseStatus'] == true) {
                ShowMessageBox("Record Successfully Deleted!", 0);
            } else if (evlResult['CheckResponseStatus'] == false) {
                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            }
        }

    });
    HideLoadingBox();
}

function jqueryPermanentlyDeleteFile(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "POST",
        url: "/DMS/DMSDocument/PermanentlyDelete/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);
            HideLoadingBox();
            var row = "file_" + documendId;
            $("#" + row).remove();
            if (evlResult['CheckResponseStatus'] == true) {
                ShowMessageBox("Record Successfully Deleted!", 0);
            } else if (evlResult['CheckResponseStatus'] == false) {
                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            }
        }

    });
    HideLoadingBox();
}


function jqueryCheckOutDocumentClient(checkInUrl, documentId, message) {
    var myCheckPermissionUrl = "/Ajax/CanDocumentCheckOut/" + documentId;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {

            if (result.ResponseStatus == true) {
                SubmitConfirm(checkInUrl, message);
            }
            else {
                alert(result.ResponseMessage);
            }
        }
    });

}

function jqueryCheckinDocumentClient(checkInUrl, documentId, message) {

    var myCheckPermissionUrl = "/Ajax/CanNewVersionAdd/" + documentId;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {

            if (result.ResponseStatus == true) {
                SubmitConfirm(checkInUrl, message);
            }
            else {
                alert(result.ResponseMessage);
            }
        }
    });

}

function jqueryAddCommentFromClient(commenturl, documentId) {

      var myCheckPermissionUrl = "/Ajax/CanAddComment/" + documentId;

             $.ajax({
                          url:myCheckPermissionUrl,
                          contentType: "text/html",
                          async: false,
                          type:"POST",
                          success:function(result)
                          {
                                if(result.IsPermissionAvailable)
                                {
                                   ShowThickBox('Document Comments', commenturl +  '&keepThis=true&TB_iframe=true&modal=false');
                                }
                                else 
                                {
                                alert(result.ResponseMessage);
                                }
                          }
        });
}


function ActivateDeactivateMime(url, id, sno) {

    var myCheckPermissionUrl = "/DMS/AjaxRequest/ActivateDeactivateMime/" + id;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {

            if (result.ResponseStatus == true) {
                alert(result.ResponseMessage);
            }
            else {
                alert(result.ResponseMessage);
            }
        }
    });


}


function jqueryLockUnlockDocFromClient(documentId) {

    var myCheckPermissionUrl = "/Ajax/CanDocumentLockUnlock/" + documentId;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {

            if (result.ResponseStatus == true) {
                jqueryLockUnlockDocFromClientCore(documentId, 0);
            }
            else {
                alert(result.ResponseMessage);
            }
        }
    });


}

function jqueryDeleteDocumentCategory(delUrl, categoryId, sno) {

    var myCheckPermissionUrl = "/DMS/AjaxRequest/CanDocumentCategoryDelete/" + categoryId;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {
            if (result.ResponseStatus) {
                DeleteConfirm(delUrl, sno);
                this.remove(obj);
            }
            else {
                alert(result.ResponseMessage);
            }

        }
    });

}

function jqueryDeleteFileFromClient(delUrl, documentId) {

    var myCheckPermissionUrl = "/Ajax/CanDocumentDelete/" + documentId;
    $.ajax({
        url: myCheckPermissionUrl,
        contentType: "text/html",
        async: false,
        type: "POST",
        success: function (result) {
            if (result.ResponseStatus) {
                DeleteConfirm(delUrl, documentId);
                this.remove(obj);
            }
            else {
                alert(result.ResponseMessage);
            }

        }
    });

}

function jqueryDeleteFile(documendId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "POST",
        url: "/DMS/DMSDocument/Delete/" + documendId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);
            HideLoadingBox();
            var row = "file_" + documendId;
            $("#" + row).remove();
            if (evlResult['CheckResponseStatus'] == true) {
                ShowMessageBox("Record Successfully Deleted!", 0);
            } else if (evlResult['CheckResponseStatus'] == false) {
                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            }
        }

    });
    HideLoadingBox();
}

function jqueryDeleteFolder(folderId, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "POST",
        url: "/DMS/Folder/Delete/" + folderId,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);
            HideLoadingBox();
            var row = "folder_" + folderId;
            $("#" + row).remove();
            if (evlResult['CheckResponseStatus'] == true) {
                ShowMessageBox("Record Successfully Deleted!", 0);
                DeleteTableListRow(action, sno);
            } else if (evlResult['CheckResponseStatus'] == false) {
                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            }
        }

    });
    HideLoadingBox();
}

function jqueryDelete(action, sno) {
    var data = "";
    ShowLoadingBox();
    $.ajax({
        async: false,
        type: "POST",
        url: action,
        data: data,
        contentType: "text/json",
        success: function (result) {
            // {"ErrNumber":0,"ErrMessage":"","ErrSource":"","ErrType":null,"CheckResponseStatus":true}
            var evlResult = JSON.retrocycle(result);            
            HideLoadingBox();

            if (evlResult['CheckResponseStatus'] == true) {
                ShowMessageBox("Record Successfully Deleted!", 0);
                DeleteTableListRow(action, sno);
            } else if (evlResult['CheckResponseStatus'] == false) {
                ShowMessageBox("<p>Error Deleting Record!<br />" + evlResult['ErrMessage'] + "</p>", 1);

            }
        }
    });
    HideLoadingBox();
}

function jqueryResetForm(thisElm) {
    // for reseting the form and clear the fields
    ClearForm(thisElm.form);
    HideMaskBox("contentFormElement");
    //data = $(thisForm)[0].reset();

}
function LoadSelectOptions(thisElm, targetElm, url) {    
    var selValue = $("#" + thisElm.id).val();    
    var jsonResult = JqueryAjaxLoadSelectOption(selValue, targetElm, url);
   
}

function LoadSelectOptionMultiple(thisElm, targetElmName, url) {
    var selValue = $("#" + thisElm.id).val();
    var jsonResult = JqueryAjaxLoadSelectOptionMultiple(selValue, targetElmName, url);
}

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
            for (var i=0; i < tempTargetElm.length; i++) {
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

function JqueryAjaxLoadSelectOptionMultiple(selValue, targetElmName, url) {
    
    $.ajax({
        async: false,
        type: "POST",
        url: url + selValue,
        contentType: "text/json",
        data: ({ id: selValue }),
        beforeSend: function () {
            $("select[name*='" + targetElmName + "']").attr('disabled', 'disabled');
            $("select[name*='" + targetElmName + "']").addClass('ac_loading');
        },
        success: function (jsonResult) {
         if(jsonResult=="Error")
         {
         alert("Your request coulnot be processed.");
          $("select[name*='" + targetElmName + "']").removeClass('ac_loading');
            $("select[name*='" + targetElmName + "']").removeAttr('disabled');
         }else
         {
            var evlResult = JSON.retrocycle(jsonResult);
            var selOption = "";
            selOption = ParseJsonResultForSelectOptions(evlResult);

            $("select[name*='" + targetElmName + "']").empty().append(selOption);
            $("select[name*='" + targetElmName + "']").removeClass('ac_loading');
            $("select[name*='" + targetElmName + "']").removeAttr('disabled');
            }
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
                otherAttrib += " "+name + '="' + value + '" ';
            }
        });
        selOption += "<option value='" + item['Value'] + "' " + isSelected + " " + otherAttrib + " >"
                + evlResult[key].Text + "</option>";
    });
    return selOption;
}

function ParseJsonResultToCreateArray(evlResult) {
    var result = "";
    var itemsarray = new Array();
    var index = 0;
    var item = "";
    var i = 0;
    $.each(evlResult, function (key, item) {

        //        $.each(item, function (name, value) {
        //            if (name == "id") {
        //                index = value;
        //             }
        //            else
        //                item = value;
        //        });
        //        itemsarray[index] = item;
        itemsarray[index] = item;
        index++;
    });
        
        return itemsarray;  
//    var selOption = "";
//    var  i = 0;
//    $.each(evlResult, function (key, item) {
//        var isSelected = (item['Selected'] == "true") ? "Selected='Selected'" : "";
//        var otherAttrib = "";
//        $.each(item, function (name, value) {
//            if (name != 'Selected' && name != 'Value' && name != 'Text') {
//                otherAttrib += " " + name + '="' + value + '" ';
//            }
//        });
//        selOption += "<option value='" + i + "' " + isSelected + " " + otherAttrib + " >"
//                + evlResult[key].Text + "</option>";
//        i++;
//    });
//    
//    return selOption;
}
function getSelectOptionAttrib(thisElm, targetElm, attrib) {
    if (attrib == "") return false;
    var attr = $("#" + thisElm.id + " option:selected").attr(attrib);
    if (attr == undefined)
        attr = "";
    $("#" + thisElm.id).parent().parent().next().html('<span>' + attr + '</span>');
}


$(document).ready(function () {
    $("#chkParentSelected").click(function () {
        CheckUncheckAllCheckBoxes("chkChildSelected", this.checked);
    });

    $("input[type=checkbox][name*='chkChildSelected']").click(function () {
        ToggleSelectParentCheckBox("chkParentSelected", this.checked, "chkChildSelected");
    });

   
});

$(function () {
    $(window).load(function () {
        $(".customTogglePanel h5").click();
    });

    $(document).ajaxError(function (event, request, options) {
   
        //        if (request.status === 403) {//$("#access-denied-dialog").dialog({width: 500,height: 400,modal: true,buttons: {Ok: function () {$(this).dialog("close");}}});}else 
        if (request.status === 401) {
            ShowThickBox('Session Expired', '#TB_inline?height=300&width=400&modal=true&inlineId=divPageSessionExpiredInfo');            
        }    
    });
	
        
});

function JqueryAjaxGetText(selValue, targetElm, url) {
    selValue = $("#" + selValue).val();
    $.ajax({
        async: false,
        type: "POST",
        url: url + selValue,
        contentType: "text/json",
        data: ({ id: selValue }),
        
        beforeSend: function () {
            $("#" + targetElm).attr('disabled', 'disabled'); $("#" + targetElm).addClass('ac_loading');
        },
        success: function (jsonResult) {
         $("#" + targetElm).empty().val(jsonResult);
         $("#" + targetElm).attr('readonly', true);
         $("#" + targetElm).removeClass('ac_loading');
        }
    });

}

