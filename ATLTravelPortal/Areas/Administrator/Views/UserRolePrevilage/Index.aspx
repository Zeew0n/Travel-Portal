<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Role Privilege:AT BackOffice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    

    <div class="pageTitle"> 
    
        <div class="float-right" >
        
            <ul>
              
            </ul> 
            </div>      
        <h3>
            <a href="#">User Management</a> <span>&nbsp;</span><strong>Role Based Privilege</strong>
        </h3>
    </div>

  <%  using(Html.BeginForm(ViewContext.RouteData.Values["Action"].ToString()
           , ViewContext.RouteData.Values["Controller"].ToString()
           , FormMethod.Post,
    new { @id = "ATForm", @autocomplete = "off" }))
         {%>

        <div class="row-1">
       
            	<div class="form-box1 round-corner">

                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                           
                                <div>
                                
                         
                              <label> Product</label>
                            
                              <%=Html.DropDownListFor(m => m.ProductId, Model.ProductList, "-----Select-----", new { @class = "required" })%>
                             
                </div> 
                                 
                            </div>                           
                        </div>
                        
                        <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                           
                            <div>
                                <label> Sub Module</label>
                              
                                <%=Html.DropDownListFor(m=>m.SubProductId, Model.SubProductList,  "-----Select-----", new { @class = "required" })%>
                                    
                            </div>      
                    </div> 
                    
                         <div class="form-box1-row-content float-left">                           
                                <div>
                                  <div id="loadingIndicator">
                                 </div> 
                                </div></div>      
                    </div>   
                     <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                           
                            <div>
                                <label> Role</label>
                              
                                <%=Html.DropDownListFor(m=>m.RoleTypeId, Model.RoleList,  "-----Select-----", new { @class = "required" })%>
                                    
                            </div>      
                    </div> 
                    
                         
                    </div>                                           
                </div>
            </div>
   
   <%} %>
    <div id="ListPartialDiv">
                    <%Html.RenderPartial("ListPartial"); %>                   
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
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>
 
<script type="text/javascript" language="javascript">
    ddaccordion.init({ //top level headers initialization
        headerclass: "ui-accordion-header", //Shared CSS class name of headers group that are expandable
        contentclass: "ui-accordion-content", //Shared CSS class name of contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [0], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        persiststate: true, //persist state of opened contents within browser session?
        toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["prefix", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    });


    ddaccordion.init({ //2nd level headers initialization
        headerclass: "ui-accordion-Main-header", //Shared CSS class name of sub headers group that are expandable
        contentclass: "ui-accordion-Main-content", //Shared CSS class name of sub contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click" or "mouseover
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        persiststate: true, //persist state of opened contents within browser session?
        toggleclass: ["opensubheader", "closedsubheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["none", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    })
    $(document).ready(function () {
        /////// Get sub product on selecting Product////////////////////////////////////
        $("#ProductId").change(function () {
            var id = $("#ProductId").val();
            if (id == "") {
                $("#SubProductId").empty();
                $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#RoleTypeId").empty();
                $("#RoleTypeId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#ListPartialDiv").empty();
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                var url = "/Administrator/AjaxRequest/GetSubGroupNameProductId";
                $.getJSON(url, { id: id }, function (data) {
                    $("#SubProductId").empty();
                    $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#RoleTypeId").empty();
                    $("#RoleTypeId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#ListPartialDiv").empty();
                    $.each(data, function (index, optionData) {
                        $("#SubProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
        /////// Get sub product on selecting Product////////////////////////////////////
        $("#SubProductId").change(function () {
            var id = $("#SubProductId").val();
            if (id == "") {
                $("#RoleTypeId").empty();
                $("#RoleTypeId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#ListPartialDiv").empty();
                return false;
            }
            else {
                $("#RoleTypeId").empty();
                $("#RoleTypeId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#ListPartialDiv").empty();
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                var url = "/Administrator/AjaxRequest/GetRolesBySubProductId";
                $.getJSON(url, { id: id }, function (data) {
                    $.each(data, function (index, optionData) {
                        $("#RoleTypeId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
        /*---------------------------------------------------------------------------------------------------*/
        $("#RoleTypeId").change(function () {

            var ProductId = $("#ProductId").val();
            var SubProductId = $("#SubProductId").val();
            var RoleName = $("#RoleTypeId").val();
            if (RoleName == "") {
                $("#ListPartialDiv").empty();
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                $(function () {
                    $.ajax({
                        type: "POST",
                        url: "/Administrator/UserRolePrevilage/Index",
                        data: { ProductId: ProductId, SubProductId: SubProductId, RoleName: RoleName },
                        dataType: "html",
                        traditional: true,
                        success: function (result) {

                            $("#ListPartialDiv").empty().append(result);
                            $("#loadingIndicator").html('');
                        }
                    });
                });
               
            }
        }).change();
        ////////////////////////////////////////////////////////////////////////////////////////////////
        $("input[type='checkbox'][name*='parent_parent_']").click(function () {
            var areAllChecked = true;
            if (!this.checked) {
                areAllChecked = false;
            }
            $(" input[type=checkbox][name*='_" + this.value + "_']").attr("checked", areAllChecked);
        });
    });
</script>
</asp:Content>
