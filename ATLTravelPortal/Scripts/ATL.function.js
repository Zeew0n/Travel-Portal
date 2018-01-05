var formName = "ATForm";
var imgLoading = siteRelativePath + "icons/loading.gif";
var isValid = false;
var delRecordValue = "";

function DeleteConfirm(msg) {
    var alertMsg = "";
    if (msg != "") alertMsg = msg;
    else alertMsg = "'Are you sure to Delete the details?'";
    if (confirm(alertMsg)) return true;
    return false

}
function SaveConfirm(thisForm,mode) {
    
    var alertMsg = "";
    if (mode == "C") {
        alertMsg = "'Are you sure to save the details?'";
    }
    else if (mode == "U") {
        alertMsg = "'Are you sure to update the details?'";
    }
    var isValid = $("#" + thisForm.id).valid();
    if (isValid && alertMsg != "") {
        if (confirm(alertMsg)) {
            return true;
        }
    }
    return false;
}
function SubmitForm(thisForm) 
{
    var isValid = $("#" + thisForm.id).valid();
    if (isValid) {
        return true;
    }
    return false;
}

function slideUpElementView() {
    $("#myErrorBox").slideUp(1000);
}



//function DeleteRecord(thisElm) {
//    CloseTB();
//    //alert($(thisElm).parent().child.html()) 
//    var delUrl = $(thisElm).parent().children("#hddnRecordValue").val();
//    jqueryDelete(delUrl);

//}

//function ShowTBDeleteDialogue(pageUrl, thisHref) {
//    //ShowTBMessage("hello");
//    delRecordValue = "";
//    delRecordValue = thisHref;
//    document.getElementById("hddnRecordValue").value = thisHref;
//    ShowThickBox("Delete", pageUrl);
//  
//}

function CloseDialogue() {
    $.unblockUI();
}
function CloseDialogueAnimate() {
    $.unblockUI({
        onUnblock: function () { alert('onUnblock'); }
    });

}
function ShowDeleteDialogue(elmId, thisElm,tableRowNo) {
    delRecordValue = "";
    delRecordValue = thisElm.href;
    $("#hddnRecordValue").empty().val(delRecordValue);
    $("#hddnTableRowNo").empty().val(tableRowNo);
    //$("#tr_" + tableRowNo).css({ "background-color": "#BB0000" });
    $.blockUI({ message: $('#'+elmId),  theme: true,  title : 'Delete?', css: { width: '275px'} }); 

}
function ShowSaveDialogue(thisForm, mode) {

    var alertMsg = "";
    if (mode == "C") {
        alertMsg = "'Are you sure to save the details?'";
    }
    else if (mode == "U") {
        alertMsg = "'Are you sure to update the details?'";
    }
    else if (mode == "D") {
        alertMsg = "'Are you sure to Delete the details?'";
    }
    var isValid = $("#" + thisForm.id).valid();
    if (isValid && alertMsg != "") {
        $.blockUI({ message: $('#hddnDeleteDialogueContent'), theme: true, title: 'Delete?', css: { width: '275px'} }); 
   
    }
   
    return false;
}

function SaveRecord() {
    return true;

}
function DeleteRecord(thisElm) {

    CloseDialogue();
    //alert($(thisElm).parent().child.html()) 
    var delUrl = $(thisElm).parent().children("#hddnRecordValue").val();
    var delSNo = $(thisElm).parent().children("#hddnTableRowNo").val();
    jqueryDelete(delUrl, delSNo);
}
function DeleteTableRow(val, sno) {
    CloseDialogue();
    $.unblockUI({
        onUnblock: function () {
            $("#tr_" + sno).css({ "background-color": "red" }).fadeOut(1000, function () {
                $("#tr_" + sno).remove();
            });

        }
    });
 
}
function ShowTBMessage(msg) {
    $("#myErrorBox").empty().append("<p>" + msg + "</p>");
    $("#myErrorBox").css({ 'display': 'block' });
    // var pageUrl = "TB_inline?height=120&width=250&inlineId=hddnMsgBox";
   // ShowThickBox("Message", pageUrl);
  
}
function ShowThickBox(pageTitle, pageUrl) {
    tb_show(pageTitle, pageUrl, null);
}
function CloseTB() {
    tb_remove();
}


// for parent checkbox--- 
//call function as CheckUncheckAllCheckBoxes(childCheckBoxName, this.checked) {
function CheckUncheckAllCheckBoxes(childCheckBoxName, checkedValue) {
    if (childCheckBoxName == null || childCheckBoxName == undefined) return;
    $(" input[type=checkbox][name*='" + childCheckBoxName + "']").each(function () {
        this.checked = checkedValue;
    });
}
// for child checkbox--- 
//call function as (parentCheckBoxID, checkedValue, childCheckBoxName) {  
function ToggleSelectParentCheckBox(parentCheckBoxID, checkedValue, childCheckBoxName) {
    if (parentCheckBoxID == null || parentCheckBoxID == undefined) return;
    if (!checkedValue || checkedValue == false) {
        $(parentCheckBoxID).attr("checked", false);
    } else {
        var areAllChecked = true;
        $(" input[type=checkbox][name*='" + childCheckBoxName + "']").each(function () {

            if (!this.checked) {
               areAllChecked = false;
            }
        });
        $(parentCheckBoxID).attr("checked", areAllChecked);
    }
}  



/******************************* event capture ***********************************************/
//var cNumber = ['From-to'];
var cNumber = ['48-57', '96-105'];
//var cNumPad = ['96-105'];
var cAlphabet = ['65-90'];
var cDecimal = ['110', '190'];
var cControler = ['8', '9', '13', '35', '36', '37', '38', '39', '40', '46'];
//keyToCheck = new Array();
//getKeyDown.prototype.chkNum = chkNumber;
function checkKeyDown(e){
    kCode = e.keyCode
   // alert(kCode)
    return checkUserKeyDown(kCode);
}
Array.prototype.inArray = function(value)
{
    var i;
    for (i = 0; i < this.length; i++) {
       // Matches identical (===), not just similar (==).
        if (parseInt(this[i]) === value) {
            return true;
        }
    }
    return false;
};

//alert('dd')event.returnValue=false;
function checkUserKeyDown(kCode) {
    var i;
    for (i = 0; i < cNumber.length; i++) {
        var rngResult = chkRange("-", cNumber[i]);
        //alert(keyToCheck[i])
        if (rngResult == 1) {
            return true;
        }
    }
    arrResult = cControler.inArray(kCode);
    if (arrResult == false) {
        arrResult = cDecimal.inArray(kCode);
    }
    return arrResult

}
function chkRange(strSeparator, chkVal )
{
    var strIndexPos = chkVal.indexOf(strSeparator);
    if (strIndexPos >= 0) {
        frmVal = parseFloat(chkVal.substr(0, strIndexPos));
        toVal = parseFloat(chkVal.substr(strIndexPos + 1, chkVal.length));
        if (frmVal > toVal) {
            frmVal = frmVal + toVal;
            toVal = frmVal - toVal;
            frmVal = frmVal - toVal;
        }
        return chkInRange(frmVal, toVal, kCode)
    }else if (chkVal == kCode)
    {
        return 1;
    }
    return -1;

}
function chkInRange(minVal ,maxVal ,chkVal) {
    if (chkVal >= minVal && chkVal <= maxVal) return 1;
    return 0;
}


function ToogleThemeView(elmId) {
    $("#" + elmId).toggle("slow");
}
function slideUpElementView() {
    $("#myErrorBox").slideUp(1000);
}
function ToogleElementView(elmId) {
    var elm = document.getElementById(elmId).style;
    if (elm.visibility == "visible") {
        elm.visibility = "hidden";
        elm.display = "none";
    }
    else if (elm.visibility == "hidden") {
        elm.visibility = "visible";
        elm.display = "block";
    }
}
function ToogleElementClass(elmId, class1, class2) {
    var elmClass = document.getElementById(elmId);
    if (elmClass.className == class1) {
        elmClass.className = class2;
    }
    else if (elmClass.className == class2) {
        elmClass.className = class1;
    }
    return true;
}







//Accepts only Numeric Value in a textbox
function NumericValidation(id) {
    $("#"+id).keydown(function (event) {
        // Allow only backspace and delete
        if (event.keyCode == 46 || event.keyCode == 8) {
            // let it happen, don't do anything
        }
        else {
            // Ensure that it is a number and stop the keypress
            if (event.keyCode < 48 || event.keyCode > 57) {
                event.preventDefault();
            }
        }
    });
}


