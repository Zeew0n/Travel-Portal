var tblRowIncrease = 0;

/*function AddTableRows(tableId)
{
$("#divAddDeleteTableRowMsg").empty();
var elmTable = document.getElementById(tableId);
var row = elmTable.insertRow(elmTable.rows.length);
content1 = '<input type=\"text\" name=\"txt_input_name[]\" />';
content2 = '<select><option value=\"y\">Show</option><option value=\"N\">sdfsdf</option></select>';
	
var cell_0 = row.insertCell(0);
var cell_1 = row.insertCell(1);

cell_0.innerHTML=content2;
cell_1.innerHTML = content1;
}*/
// this is the function for the test of the clone of the element of the form.
function AddElementTest(elementId, tableId) {
    var elmTable = document.getElementById('addmore');
    var row = elmTable.insertRow(elmTable.rows.length);
    $("#divAddDeleteTableRowMsg").empty();
    var element = document.getElementById(elementId);
    //var cell_0 = row.insertCell(0);
    $("#" + elementId).clone(true).removeAttr('id').attr('id', elementId).insertAfter('#' + tableId + ' tbody>tr:last');

}
function AddTableRowMaster(tableId, allowClone) 
{
    allowClone = (allowClone == "" || allowClone == undefined || allowClone == true) ? true : false;
    $("#divAddDeleteTableRowMsg").empty();
    $('#' + tableId + ' tbody:first>tr:last').clone(allowClone).insertAfter('#' + tableId + ' tbody:first>tr:last');
    $('#' + tableId + ' tbody:first>tr:last>td:last').empty().append("<input type=\"image\" id=\"imgDelete\" name=\"imgDelete\" alt='Delete' src='" + siteRelativePath + "Content/Icons/Delete.png' onclick='DeleteTableRow(this)' />");
  
}

function AddTableRowsSimple(tableId, allowClone) {
    AddTableRowMaster(tableId, allowClone);
    ResetTableRowsIdSimple(tableId);
}
function AddTableRowsDynamicModel(tableId, allowClone) {
    AddTableRowMaster(tableId, allowClone);
    ResetTableRowsIdDynamicModel(tableId);
}

/*************** dynamic table row elmArray is *******************/
function AddTableRowsElm(tableId, elmArray) {
    $("#divAddDeleteTableRowMsg").empty();
    var elmTable = document.getElementById(tableId);
    var row = elmTable.insertRow(elmTable.rows.length);
    if (elmArray.length > 0) {
        for (var i = 0; i < elmArray.length; i++) {
            var cell = row.insertCell(i);
            cell.innerHTML = elmArray[i];
        }
    }
    $('#' + tableId + ' tbody:first>tr:last>td:last').empty().append("<input type=\"image\" id=\"imgDelete\" name=\"imgDelete\" alt='Delete' src='" + siteRelativePath + "Content/Icons/Delete.png' onclick='DeleteTableRow(this)' />");
    ResetTableRowsIdSimple(tableId);
}

function DeleteTableRow(thisElm) {
    if (confirm("Are you sure to delete the row?")) {
        $(thisElm).parent().parent().remove();
    }
    return false;
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

// reset the table id simple
function ResetTableRowsIdSimple(tableId) {
    tblRowIncrease++;
    //var count = $('#'+tableId+' tr').length-1;

    //var count =($('#'+tableId+' tbody>tr:last input:first').attr('id'));
    //count= String(parseFloat(count)); //count.replace(/[\, ]/g, '');//parseInt(count.replace(/^0+/g, ''));
    //alert(count);
    //change the id of the added element.
    var Form = $('#' + tableId + ' tbody:first>tr:last select,' + '#' + tableId + ' tbody:first>tr:last input,' + '#' + tableId + ' tbody:first>tr:last textarea');
    Form.each(function () {
        var suffix = "[" + tblRowIncrease + "]";
        var elmName = this.name;
        var elmNamePosition = elmName.lastIndexOf("[");
        if (elmNamePosition > 1) {
        var name = elmName.substring(0, elmNamePosition);
        }
        else {
            var name = elmName;
        }
        elmName = name + suffix;
        var id = name + tblRowIncrease;
        $(this).removeAttr('name').attr('name', elmName);
        $(this).removeAttr('id').attr('id', id);

    });
   /// resetMultiOption(tblRowIncrease);
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

        if (name.lastIndexOf(".Index") >1) {
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
        

    });
    /// resetMultiOption(tblRowIncrease);
}


/***
* 
* @param key contains the parentid 
* @param value contains the childid (if in array it should be comman seperated.) eg childid1,childid2,...
* @function createmultioption creates the format of the multioption of the given parent and child . 
*/

function MultiOption(key, value) {
    multiOption = multiOption + key + ":" + value + ";";

}

/**************	DYNAMIC MULTIOPTION	***************** 110033/

/***
* @parnam multioption variable is the global variable for the dynamic multioption.Which contains the array
* of the parent child combination in the given format.
* PARENT1:CHILD1,CHILD2;PARENT2:CHILD1;PARENT3:CHILD;
*/

/***
* 
* @param count contains the count of the rows in the table.
* @function resetMultiOption resets the id of the elements in the dynamicmultioption. 
*/


function resetMultiOption(count) {
    var countofmultioption = multiOption.split(';');
    $.each(countofmultioption, function () {
        if (this != "") {
            childid = "";
            var parent = this.split(':');
            parentid = parent[0];
            parentid += count;
            child = parent[1];
            child = parent[1].split(',');
            $.each(child, function () {
                if (this != "") {
                    childid += this + count + ",";
                }
            });
            createMultiOption(parentid, childid);
        }
    });
}

/***
* 
* @param parentId contains the parentid 
* @param childId contains the childid (if in array it should be comman seperated.) eg childid1,childid2,...
* @function testMultiOption creates the multioption for the the given parent and child . 
*/


function createMultiOption(parentId, childId) {
    $(document).ready(function () {
        var module = "";

        var functionname = "";
        var onclick = "";
        var childIds = childId.split(',');
        var ftnParent = parentId.split('Id');
        ftnParent = ftnParent[0];
        $.each(childIds, function () {
            if (this != "") {
                var modelname = this.split('Id');
                functionname = "get" + modelname[0] + "By" + ftnParent + "IdListOption";
                //var module = window.location.pathname;
                //module = module.split('/');
                //var modulenameprefix = module[2].substr(0, 1).toUpperCase()+ module[2].substr(1);
                dynmodelname = modulenameprefix + "_Model_" + modelname[0];
                url = siteRelativePath + "admin/ajaxrequest/multioption?model=" + dynmodelname + "&function=" + functionname + "&id=";
                onclick += "Javascript:LoadSelectOptionsTest('" + parentId + "','" + this + "','" + url + "');";
            }
        });
        //alert(parentId+":::"+childId);
        //MultiOption(parentId,childId); use this if resetMultioption is not used.
        //alert(parentId);
        //$("#"+parentId).removeAttr('onChange').attr('onChange',onclick);
        // This is the hack for IE


        var evt = $.browser.msie ? "ie" : "ms";
        $("select#" + parentId).attr("onChange", onclick);
        /*if(evt == "ie"){
			
        var select1 = document.getElementById(parentId);
			
        if(select1 != null){
        $("select#"+parentId).attr("onChange",onclick);
        //alert(parentId+"::"+select1);
        //select1.changed = false;
        //select1.onchange = onclick;
        }

        }else
        {
        //	$("#testsubin").attr(evt,onclick);
        $("select#"+parentId).attr("onChange",onclick);
		
        }*/

    });
}
function ResetTableRowsIdSimpleExceptParent(tableId) {
    tblRowIncrease++;
    var Form = $('#' + tableId + ' tbody:first>tr:last select,' + '#' + tableId + ' tbody:first>tr:last input,' + '#' + tableId + ' tbody:first>tr:last textarea');
    Form.each(function () {
        var suffix = "[" + tblRowIncrease + "]";
        var elmName = this.name;
        var elmNamePosition = elmName.lastIndexOf("[");
        if (elmNamePosition > 1) {
            var name = elmName.substring(0, elmNamePosition);
        }
        else {
            var name = elmName;
        }
        elmName = name + suffix;
        var id = name + tblRowIncrease;
        $(this).removeAttr('name').attr('name', elmName);
        $(this).removeAttr('id').attr('id', id);

    });
    resetMultiOptionExceptParent(tblRowIncrease);
}
function resetMultiOptionExceptParent(count) {
    var countofmultioption = multiOption.split(';');
    $.each(countofmultioption, function () {
        if (this != "") {
            childid = "";
            var parent = this.split(':');
            parentid = parent[0];
            child = parent[1];
            child = parent[1].split(',');
            $.each(child, function () {
                if (this != "") {
                    childid += this + count + ",";
                }
            });
            createMultiOption(parentid, childid);
        }
    });
}



/**************************** dynamic save the input field onchange **************************/
var arrChangeValue = new Array();
function setTextboxNameValue(txtName, txtValue) {
    this.txtName = txtName; this.txtValue = txtValue;
}
function CheckChange(thisElm) {
    $("#" + thisElm.id).siblings("em").empty();
    if (CheckValueChange(thisElm.id, thisElm.value, '') == true) {
        $("#" + thisElm.id).siblings("em").empty();
    } else {
        $("<img src=" + siteRelativePath + "'/Content/Icons/Success.png' alt='img' />").appendTo($("#" + thisElm.id).siblings("em").empty());

    }

}
function CheckValueChange(elmTextBoxId, elmTextBoxValue, boolAssignChange) {
    var addElm = true;
    var callFun = false;
    if (elmTextBoxId == null || elmTextBoxId == "" || elmTextBoxId == null || elmTextBoxId == "") return false;
    for (var i = 0; i < arrChangeValue.length; i++) {
        var obj = arrChangeValue[i];

        if (obj["txtName"] == elmTextBoxId) {
            if (obj["txtValue"] != elmTextBoxValue) {
                if (boolAssignChange == 'true') obj["txtValue"] = elmTextBoxValue;
                callFun = true;

            }
            addElm = false;
            break;
        }
    }
    if (addElm) {
        //arrChangeValue.push(new setTextboxNameValue(elmTextBoxId, elmTextBoxValue));
        callFun = true;

    }
    return callFun;
}
function CheckValueChangeAndPush(elmTextBoxId, elmTextBoxValue) {
    if (CheckValueChange(elmTextBoxId, elmTextBoxValue, 'true') == true) {
        arrChangeValue.push(new setTextboxNameValue(elmTextBoxId, elmTextBoxValue));
        return true;
    }
    return false;
}
/**************************** dynamic save the input field onchange **************************/