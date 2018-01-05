<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<div class="contentGrid ui-accordion">
<%
if (Model.PriviledgeSetupList != null)
{
   var preControllerId = 0;
   var preControllerGroupId = 0;
   var isFirst = 1;
   var isLast = 0;
    foreach(var item in Model.PriviledgeSetupList){

        var ControlId = item.ControllerId;
        var ControllerGroupId = item.ControllerGroupId;

        if (ControlId != preControllerId && preControllerId > 0)
        {
        %> 
                </li></ul></li>
        <%
        } 

        if (ControllerGroupId != preControllerGroupId)
        {

       
            if (ControllerGroupId != preControllerGroupId && preControllerGroupId > 0)
            {
           %> 
                    </li></ul>
            <%
            } 
       
       

%>                    
         <div class="ui-accordion-Main-header acHeading" >
                <span style="cursor:pointer;" ><strong> <%: item.ControllerGroupName %> </strong><a href="/PriviledgeSetup/Delete?contollerGroupId=<%: ControllerGroupId %>"  
class="delete float-right" title="Delete" onclick = "return confirm('Are you sure you want to delete?')">&nbsp;</a></span>
                       
            </div>
      
        <ul class="ui-accordion-Main-content ac" >
<%
        }
        
        
        if (ControlId != preControllerId)
        {


        
            //isLast = preControllerId > 0 ? 1 : 0;

%>        <li>
<div class="ui-accordion-header">
                <span ><%: item.ControllerLabel %> <a href="/PriviledgeSetup/Delete?contollerId=<%: ControlId %>"  
class="delete float-right" title="Delete" onclick = "return confirm('Are you sure you want to delete?')">&nbsp;</a></span>
                       
           </div>
                <ul class="ui-accordion-content" ><li>
<%
        }
       
%>
    <span style="width:100px">
     <%:Html.ActionLink(" ", "Delete", new { ControllerId = ControlId, ActionTypeId =  item.ActionTypeId }
         , new { @class = "delete", @onclick = "return confirm('Are you sure you want to delete?')" })%> 
<%: item.ActionTypeName%>
    </span>
 
    
<%    
        preControllerId = ControlId;
        preControllerGroupId = ControllerGroupId; 
    }
}    
%>
</li></ul></li> </ul>
</div>

