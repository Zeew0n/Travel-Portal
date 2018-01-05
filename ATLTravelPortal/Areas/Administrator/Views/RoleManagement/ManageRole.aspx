<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<List<ATLTravelPortal.Areas.Administrator.Models.RoleBasedRoleModel>>" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];%>
    <%using (Html.BeginForm("CreateRole", "RoleManagement", FormMethod.Post, new { @class = "validate" }))
      { %>
   

     <div class="pageTitle">
        
        <h3>
            <a href="#">User Management</a> <span>&nbsp;</span><strong>Manage Roles</strong>
        </h3>
    </div>

    <div class="row-1">
    
        <div class="form-box1">
            <div class="form-box1-row">
               <div class="form-box1-row-content float-left">
                    <div>
                         <label>
                            Product:</label>
                       <%=Html.DropDownList("ProductId", (SelectList)ViewData["ProductList"], "-----Select-----",new { @class = "required" })%>
                        
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Role Name:</label>
                        <% =Html.TextBox("id", "", new { @class="required"})%>
                        
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
               <div class="form-box1-row-content float-left">
                    <div>
                     <label>
                            Sub-Product:</label> <%=Html.DropDownList("SubProductId", (SelectList)ViewData["SubProductList"],  "-----Select-----", new { @class = "required" })%>
                    </div>
                </div>
            </div>
           
        </div>
        <div class="buttonBar">
            	<input type="submit" value="Save" class="save" />
            </div>
    </div>
    <%} %>
     <div class="msgbox" style="border:0px"> <%:TempData["message"] %></div>
    
   <div id="RoleDiv">
                    <%Html.RenderPartial("RolePartial",Model); %>                   
                 </div>

  

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssContent" runat="server">
   <style type="text/css">
        label.error
        {
            color: red;
            margin-right: 21px;
            text-align: center;
            width: 10px !important;
            float: right !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.validate').validate();
            /////// Get sub product on selecting Product////////////////////////////////////
            $("#ProductId").change(function () {
             var id = $("#ProductId").val();
             if (id == "") {
             $("#SubProductId").empty();
             $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
              return false;
              }
          else {
              $("#SubProductId").empty();
              $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
               var url = "/Administrator/AjaxRequest/GetSubGroupNameProductId";
                $.getJSON(url, { id: id }, function (data) {
                 $.each(data, function (index, optionData) {
                 $("#SubProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                  });
                   $("#loadingIndicator").html('');
                  });
                }
            }).change();
        });

    </script>
     <script type="text/javascript">
         function beginAgentList(args) {
             // Animate
             $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
         }
         function successAgentList() {
             // Animate loadingAnimation
             $("#loadingIndicator").html('');
         }
              </script>
</asp:Content>
