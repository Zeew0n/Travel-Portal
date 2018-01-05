<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<List<ATLTravelPortal.Areas.Administrator.Models.UserManagementModel.LockApprovedUserModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ManageUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <%using (Ajax.BeginForm("ManageUser", "", new AjaxOptions()
      {
          UpdateTargetId = "SearchResult",
          InsertionMode = InsertionMode.Replace  
      ,
          OnBegin = "beginAgentList",
          OnSuccess = "successAgentList",
          OnFailure="failureAgentList",
      HttpMethod="Post"
      }, new { @class = "validate" }))
      { %>
       <div class="pageTitle">
        
        <h3>
            <a href="#">User Management</a> <span>&nbsp;</span><strong>Manage Users</strong>
        </h3>
    </div>

          <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>

                                    <label>Select the Status Type</label>
                                     <%=Html.DropDownList("ddlOpt", (SelectList)ViewData["ddlmanageopt"], "---Select---", new { @class = "required" })%>
                                      	 
                                 </div> 
                            </div>   
                             <div class="form-box1-row-content float-left">
                             <input type="submit" value="Search" class="float-left" id="seachButton"/>   
                              <div id="loadingIndicator" >
                            </div>
                            
                             </div>                        
                        </div>
                       
                        </div> 
               <%} %>          
       <div id="SearchResult">
         <%if ((bool)TempData["Flag"] == true)
           { %>
            <%Html.RenderPartial("LockedUnapproveduser"); %>
            <%} %>
         </div>
            
 
 </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
     $(document).ready(function () {
            $('.validate').validate();
        });
        function beginAgentList(args) {
            // Animate
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
        }

        function successAgentList() {
            // Animate loadingAnimation
            $("#loadingIndicator").html('');

        }
        function failureAgentList() {
            $("#loadingIndicator").html('');
         alert("oops ! Error occured");
     }

     $(document).ready(function () {
         $("#seachButton").live("click", function () {
             ddlopt = $("#ddlOpt").val();
             if (ddlopt == '') {
                 alert('Please select the Status Type');
                 return false;
             }
             return ture;
         });
     });
</script>
</asp:Content>

