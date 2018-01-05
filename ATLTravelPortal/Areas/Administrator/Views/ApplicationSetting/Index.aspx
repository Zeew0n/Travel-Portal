<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ApplicationSettingViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Application Setting:AT-BackOffice
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="pageTitle">
               <% using (Html.BeginForm("Index", "ApplicationSetting", FormMethod.Post))
   {%> 

      <div class="float-right">
        <input type="submit" value="Save" class="btn3" />
        <a href="/Administrator/ApplicationSetting/" class="linkButton" title="Cancel">Cancel</a>
        <%:Html.HiddenFor(model => model.HFProductId)%>
    </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>Application Setting</strong>
        </h3>
 
   </div>
         
     <div id="PartialDiv">
               <%Html.RenderPartial("SettingPartial", Model); %>                   
                 </div>
                 <% }%>
   

         <%using (Ajax.BeginForm("Index", "ApplicationSetting", new AjaxOptions()
                      {
                          UpdateTargetId = "PartialDiv",
                          InsertionMode = InsertionMode.Replace ,
                          OnBegin = "beginAgentList",
                          OnSuccess = "successAgentList",
                          OnFailure = "failureAgentList",
                          HttpMethod = "Post",
                      }, new { @id = "TheForm" }))
                { %>
<div class="row-1">
<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                     <label><%: Html.LabelFor(model => model.ProductId) %></label>
                                    <%: Html.DropDownListFor(model => model.ProductId, Model.ddlProductList, "--- Select ---")%>
                                     <%: Html.ValidationMessageFor(model => model.ProductId)%>
                                </div>
                         </div> 
                          <div class="form-box1-row-content float-left">                            
                                <div id="loadingIndicator">
                                 </div> 
                         </div> 
                      </div>  
                      </div>  
                      </div>

                    
                
                          
   <% } %>
   
 <%--   ==================================================--%>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

 <script type="text/javascript">
     $(function () {
         $("#ProductId").change(function () {
             $('#TheForm').submit();
         });
     });

</script>
<script type="text/javascript">
    function beginAgentList(args) {
        // Animate
        $("#PartialDiv").hide();
        $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');

    }

    function successAgentList() {
        // Animate loadingAnimation
        $("#PartialDiv").show();
        $("#loadingIndicator").html('');

    }

    function failureAgentList() {
        alert("Could not retrieve List.");
    }
</script>
</asp:Content>
