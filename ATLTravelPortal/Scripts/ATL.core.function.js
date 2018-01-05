var tableId = 'Sectors';
var tblRowIncrease = 1;
var multiOption = "";

function AddTableRowsClone(tableId) {
    $('#' + tableId + ' tbody:first>tr:last').clone(true).insertAfter('#' + tableId + ' tbody:first>tr:last');
    $('#' + tableId + ' tbody:first>tr:last>td:last').empty().append("<input type=\"image\" id=\"imgDelete\" name=\"delete\" alt='' class=\"delete\" onclick='DeleteTableRow(this)' />");
    $('#' + tableId + ' tbody:first>tr:last select,' + '#' + tableId + ' tbody:first>tr:last input,' + '#' + tableId + ' tbody:first>tr:last textarea').val("");
    resetId(tableId);
}
function DeleteTableRows(tableId, minCount) {
    var elmTable = document.getElementById(tableId);
    if (elmTable.rows.length > minCount)
        elmTable.deleteRow(elmTable.rows.length - 1);
    else
        $("#divAddDeleteTableRowMsg").empty().append('No more rows to delete!');
}
function DeleteTableRow(elmThis) {
    $(elmThis).parent().parent().remove();

}
function DeleteTableRows(tableId, minCount) {
    var elmTable = document.getElementById(tableId);
    if (elmTable.rows.length > minCount)
        elmTable.deleteRow(elmTable.rows.length - 1);
    else
        $("#divAddDeleteTableRowMsg").empty().append('No more rows to delete!');
}
function AddTableRows(tableId, elmArray) {
    $("#divAddDeleteTableRowMsg").empty();
    var elmTable = document.getElementById(tableId);
    var row = elmTable.insertRow(elmTable.rows.length);
    if (elmArray.length > 0) {
        for (var i = 0; i < elmArray.length; i++) {
            var cell = row.insertCell(i);
            cell.innerHTML = elmArray[i];
        }
    }
    $('#' + tableId + ' tbody:first>tr:last>td:last').empty().append("<input type=\"image\" id=\"imgDelete\" name=\"delete\" alt='Delete' class=\"delete\" onclick='DeleteTableRow(this)' />");

    resetId(tableId);
}
function CheckUncheckAllCheckBoxes(childCheckBoxName, checkedValue) {
    if (childCheckBoxName == null || childCheckBoxName == undefined) return;
    $(" input[type=checkbox][name*='" + childCheckBoxName + "']").each(function () {
        this.checked = checkedValue;
    });
}
function ToggleSelectParentCheckBox(parentCheckBoxID, checkedValue, childCheckBoxName) {
    if (parentCheckBoxID == null || parentCheckBoxID == undefined) return;
    if (!checkedValue || checkedValue == false) {
        $("#" + parentCheckBoxID).attr("checked", false);
    } else {
        var areAllChecked = true;
        $(" input[type=checkbox][name*='" + childCheckBoxName + "']").each(function () {
            if (!this.checked) {
                areAllChecked = false;
            }
        });
        $("#" + parentCheckBoxID).attr("checked", areAllChecked);
    }
}  


function resetId(tableId) {
    tblRowIncrease++;

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
    resetMultiOption(tblRowIncrease);
}
function resetAllId(tableId) {
    var row = $('#' + tableId + ' tbody:first>tr input');
    var i = 0;
    row.each(function () {
        var name = this.name;
        name += "[]";
        var id = this.id;
        id += i;
        $(this).removeAttr('name').attr('name', name);
        $(this).removeAttr('id').attr('id', id);
        i++;
    });


}
function resetMultiOption(count) {

    ///	alert(count+"::"+multiOption);
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
function MultiOption(key, value) {
    multiOption = multiOption + key + ":" + value + ";";
}
function createMultiOption(parentId, childId) {
    // alert(parentId);
    $(document).ready(function () {
        var module = "";
        var functionname = "";
        var onclick = "";
        var childIds = childId.split(',');
        var ftnParent = parentId.split('Id');
        ftnParent = ftnParent[1];

        $.each(childIds, function () {
            if (this != "") {
                $("#BankId" + ftnParent).change(function () {
                    //build the request url
                    var url = "/AgentManagement/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: $("#BankId" + ftnParent).val() }, function (data) {
                        //Clear the Model list
                        $('#BankBranchId' + ftnParent).removeAttr('disabled');
                        $("#BankBranchId" + ftnParent).empty();
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BankBranchId" + ftnParent).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }).change();
            }
        });

        var evt = $.browser.msie ? "ie" : "ms";
        if (evt == "ie") {
            var select1 = document.getElementById("'" + parentId + "'");
            //alert(parentId+select1)
            select1.changed = false;
            select1.onchange = onclick;

        } else {

            $("select#" + parentId).attr("onChange", onclick);

        }

    });
}