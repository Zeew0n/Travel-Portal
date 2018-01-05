<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<%
    if (Model.PriviledgeSetupList != null)
    {

        using (Html.BeginForm("Create"
               , ViewContext.RouteData.Values["Controller"].ToString()
               , FormMethod.Post,
        new { @id = "ATForm", @autocomplete = "off" }))
        {

%>

<div class="contentGrid ui-accordion">          
<%
            var preControllerId = 0;
            var preControllerGroupId = 0;
            foreach (var item in Model.PriviledgeSetupList)
            {

                var ControllerId = item.ControllerId;
                var ControllerGroupId = item.ControllerGroupId;
                var parentChkBoxName = "parent_" + ControllerGroupId +"_"+ item.ControllerId;
                var chkBoxName = ControllerGroupId + "_" + item.ControllerId + "_" + item.PrivilegeId;
                var chkBoxSufix = chkBoxName + "_" + item.ActionTypeName;

                if (ControllerId != preControllerId && preControllerId > 0)
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
           <%---- -----------Group Main heading -------------- -----%>
 
 <div class="acHeading" >
                         <%--<input type="checkbox" 
                              id="parent_<%: parentChkBoxName %>" 
                            name="parent_<%: parentChkBoxName %>"
                           value="<%: item.ControllerGroupId %>"
                             />--%>
             <span> <%: item.ControllerGroupName%></span>
 </div>

             <%---- -----------End Group Main heading -------------- -----%>
      
        <ul class="ac" >
<%
    }


                if (ControllerId != preControllerId)
                {



                    //isLast = preControllerId > 0 ? 1 : 0;

%>        <li>
                      <%---- -----------Controller Main heading -------------- -----%>
        <div>
        <span>
                <input type="checkbox" onclick="CheckUncheckAllCheckBoxes('checkbox_<%:item.ControllerGroupId +"_"+ item.ControllerId + "_"%>', this.checked);"
                            id="<%: parentChkBoxName %>" 
                            name="<%: parentChkBoxName %>" />
            <label for="<%: parentChkBoxName %>" class="LabelView"><%=item.ControllerLabel%></label></span>

                       
            </div>
             <%---- -----------End Controller Main heading -------------- -----%>

                <ul class=""><li>
<%
    }
       
%>
 <%---- -----------Begin Action name of  Controller -------------- -----%>
    <span style="width:100px">
     <% 
           
    var isChecked = "";
    if (item.PrivilageIdChecked)
    {
        isChecked = "checked='checked'";

    }
    %>
    <input type="checkbox" onclick="ToggleSelectParentCheckBox('<%: parentChkBoxName %>', this.checked, 'checkbox_<%:item.ControllerGroupId +"_"+item.ControllerId + "_"%>');"
            id="checkbox_<%: chkBoxSufix %>" 
            name="checkbox_<%:chkBoxSufix%>" <%: isChecked %>
             value="<%: item.PrivilegeId%>" />
        <label for="checkbox_<%: chkBoxSufix %>" class="LabelView"><%=item.ActionTypeName%></label>
    </span>
   
     <%---- -----------End Action name of  Controller -------------- -----%>
  
    
<%    
            preControllerId = ControllerId;
            preControllerGroupId = ControllerGroupId;
            }%>
          

</li></ul></li> </ul> 


</div>
<div class="buttonBar float-right" style="width:100%" >
        
            <ul>
                <li>  
                    <%=Html.Hidden("Roleid", Model.RoleTypeId )%>
                    <input type="submit" value="save" class="save" />
                </li>
            </ul> 
            </div>    
                   <% }
    }
%>
<script src="../../Scripts/ATL.core.function.js" type="text/javascript"></script>
