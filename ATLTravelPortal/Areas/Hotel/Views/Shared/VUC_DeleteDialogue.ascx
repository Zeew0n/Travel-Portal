<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="hddnDeleteDialogueContent" class="selected" style="display:none">
<p>Are you sure to Delete the details?</p>
<p>
    <input type="hidden" id="hddnRecordValue" value="" />
    <input type="hidden" id="hddnTableRowNo" value="" />
    <input type="button" id="btnDelete" value="&nbsp;&nbsp;Ok&nbsp;&nbsp;" onclick="DeleteRecord(this)" />
    <input type="button" id="btnCancel" value="&nbsp;&nbsp;Cancel&nbsp;&nbsp;" onclick="CloseDialogue()" />
</p>
</div>