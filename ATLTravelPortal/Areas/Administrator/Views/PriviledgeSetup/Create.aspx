<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Priviledge Setup
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("Create", "PriviledgeSetup", FormMethod.Post))
      { %>
    <%: Html.ValidationSummary(true) %>
    
  <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
  <div class="pageTitle">
        <div class="float-right">
            	<ul>              
                     <li><input type="submit" value="Save" class="save" />
                      <input type="button" onclick="document.location.href='/Administrator/PriviledgeSetup/Index'"
                    value="Cancel" />   
                     </li>  
                    
                        
                </ul>
            </div>
        <h3>
            <a href="#">User Management</a> <span>&nbsp;</span><strong>Privilege Setup</strong>
        </h3>
    </div>


      <div class="box3">
        <div class="type-option" style=" margin-bottom:-10px; margin-top:15px;"><label>
<a href="/Administrator/AjaxRequest/CreateControllerGroup" class="create" title="New Controller Group:">New Group</a></label>
        <label><a href="/Administrator/AjaxRequest/RegisterNewController" class="create" title="New Controller:">New Controller</a></label>
 </div></div>
           
   
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Product :</label>
                        <%:Html.DropDownListFor(model => model.ProductId,Model.ProductList, "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.ProductId,"*")%>
                    </div>
                </div>
            </div>

               <div class="form-box1-row-content">   
                                <div>
                              <label>Sub Product :</label>
                              <%:Html.DropDownListFor(model => model.SubProductId, Model.SubProductList, "-----Select-----")%>
                                <%: Html.ValidationMessageFor(model => model.SubProductId, "*")%>
                               </div>
                                </div>        

             <div class="form-box1-row">

                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Controller Name:</label>
                            <%:Html.DropDownListFor(model => model.ControllerId, Model.ControllerNameList, "-----Select-----")%>
                            <%: Html.ValidationMessageFor(model => model.ControllerId, "*")%>
                            <%: Html.HiddenFor(model => model.hdfControllerName) %>
                        </div>
                    </div>
                </div>


                
          
           


            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Action Name:</label>
                        <%: Html.TextBoxFor(model => model.ActionTypeName)%>
                        <%: Html.ValidationMessageFor(model => model.ActionTypeName)%>
                    </div>
                </div>



                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                ActionType:</label>
                            <%:Html.DropDownListFor(model => model.ActionTypeId,Model.ActionTypeList, "-----Select-----")%>
                            <%: Html.ValidationMessageFor(model => model.ActionTypeId, "*")%>
                        </div>
                    </div>
                </div>
          
            </div>
        </div>
    </div>
    <%} %>

     <div id="contentFormUpdatePanel">
       <%: Html.Partial("VUC_PriviledgeList")%>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="/Content/themes/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/redmond/jquery.ui.base.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/AirlineSearchResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">


<script type="text/javascript">

    
        ///////////////////////////////// Pop Up /////////////////////////////////////////////////
        $(function () {
            $('a.create').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');
            });
        }); /* end document.ready() */
        function loadDialog(tag, event, target) {
            event.preventDefault();
            var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
            var $url = $(tag).attr('href');
            var $title = $(tag).attr('title');
            var $dialog = $('<div></div>');
            $dialog.empty();
            $(this).dialog('destroy').remove();
            $dialog
            .append($loading)
            .load($url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 500
                , modal: true
			    , minHeight: 300
                , show: 'slide'
                , hide: 'scale'
		    });

            $dialog.dialog('open');
        };
        ////////////////////////////////////////////////////////////////////////////
        /////// Get GroupName on selecting Product////////////////////////////////////
        $(document).ready(function () {
            /////// Get ControllerName on selecting Product////////////////////////////////////

            $("#ProductId").change(function () {
                id = $("#ProductId").val();
                if (id == "") {
                    $("#SubProductId").empty();
                    $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#ControllerId").empty();
                    $("#ControllerId").append("<option value=''>" + "-- Select--" + "</option>");
                    return false;
                }
                else {
                    //build the request url
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    var url = "/Administrator/AjaxRequest/GetSubGroupNameProductId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#SubProductId").empty();
                        $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#SubProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        $("#loadingIndicator").html('');
                    });
                }
            }).change();

        $("#SubProductId").change(function () {
            var ProductId = $("#ProductId").val();
             var SubProductId = $("#SubProductId").val();
             if (SubProductId == "") {
             $("#ControllerId").empty();
              $("#ControllerId").append("<option value=''>" + "-- Select--" + "</option>");
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                //build the request url
                var url = "/Administrator/AjaxRequest/GetControllerNamebyProductIdandSubProductId";
                //fire off the request, passing it the id which is the MakeID's selected item value
                $.getJSON(url, { ProductId: ProductId,SubProductId:SubProductId }, function (data) {
                    //Clear the Model list
                    $("#ControllerId").empty();
                    $("#ControllerId").append("<option value=''>" + "-- Select--" + "</option>");
                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {
                        $("#ControllerId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                   
                });
                $(function () {
                    $.ajax({
                        type: "POST",
                        url: "/Administrator/PriviledgeSetup/Index",
                        data: { ProductId: ProductId, SubProductId: SubProductId },
                        dataType: "html",
                        traditional: true,
                        success: function (result) {
                            $("#contentFormUpdatePanel").empty().append(result);
                        }

                    });
                });
                $("#loadingIndicator").html('');
            }
        }).change();
    });

        ////////////////////////////////////////////////////////////////////////

    </script>
</asp:Content>
