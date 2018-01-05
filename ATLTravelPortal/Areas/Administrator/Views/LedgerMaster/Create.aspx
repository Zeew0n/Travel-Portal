<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerMasterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
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
    <%using (Html.BeginForm("Create", "LedgerMaster", FormMethod.Post))
      { %>
    <%: Html.ValidationSummary(true) %>
   

    <div class="pageTitle">
       <div class="float-right">
            	 <input type="submit" value="Save" class="save" />
                 <%:Html.ActionLink("Cancel", "Index", new { controller = "LedgerMaster" }, new { @class = "linkButton float-right" })%>
            </div>

        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Ledger Master</strong><span>&nbsp;</span><strong>Create</strong>
        </h3>
         
    </div>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Product:</label>
                        <%:Html.DropDownListFor(model => model.ProductId, Model.ProductNameList, "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.ProductId,"*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Account Group:</label>
                        <%:Html.DropDownListFor(model => model.AccGroupId, Model.AccGroupNameList, "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.AccGroupId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Account Sub Group:</label>
                        <%:Html.DropDownListFor(model => model.AccSubGroupId, Model.AccSubGroupNameList, "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.AccSubGroupId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Account Type:</label>
                        <%:Html.DropDownListFor(model => model.AccTypeId, Model.AccTypeNameList, "-----Select-----")%><%--<label class="redtxt" id="loadingIndicator"></label>--%>
                        <%: Html.ValidationMessageFor(model => model.AccTypeId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline:</label>
                        <%:Html.DropDownListFor(model => model.ddlAirLines, Model.ddlAirLinesList, "-----Select-----")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Ledger:</label>
                        <%: Html.TextBoxFor(model => model.LedgerName)%>
                        <%: Html.ValidationMessageFor(model => model.LedgerName)%>
                    </div>
                </div>
            </div>
        </div>
        <%--  <div class="buttonBar">
            	 <input type="submit" value="Save" class="save" />
                 <%:Html.ActionLink("Cancel", "Index", new { controller = "LedgerMaster" }, new { @class = "linkButton float-right" })%>
            </div>--%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
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



        /////// Get AirlineName or AgentName on selecting AccountTypeName////////////////////////////////////
        $(document).ready(function () {
            $("#AccTypeId").change(function () {
               var id = $("#AccTypeId").val();
                if (id == "" || id == 3 || id == 4) {
                    $("#ddlAirLines").empty();
                    $("#ddlAirLines").append("<option value=''>" + "-- Select--" + "</option>");
                    $("#ddlAirLines").val();
                    return false;
                }
                else {
                    //build the request url
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
                    var url = "/Administrator/AjaxRequest/GetMapTableList";
                    //var url = "/Administrator/AjaxRequest/GetMapTableList";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#ddlAirLines").empty();
                        $("#ddlAirLines").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {
                            $("#loadingIndicator").html(' ');
                            $("#ddlAirLines").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////// GetAccTypeName on selecting ProductName///////////////
                $(document).ready(function () {

                    $("#ProductId").change(function () {
                        id = $("#ProductId").val();
                        if (id == "") {

                            $("#AccTypeId").empty();
                            $("#AccTypeId").append("<option value=''>" + "-- Select--" + "</option>");
                            $("#AccTypeId").val();

                            return false;
                        }
                        else {
                            //build the request url
                            $("#loadingProductIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
                            var url = "/Administrator/AjaxRequest/GetAccTypeNameBasedOnProductName";
                            //fire off the request, passing it the id which is the MakeID's selected item value
                            $.getJSON(url, { id: id }, function (data) {
                                //Clear the Model list
                                $("#AccTypeId").empty();
                                $("#AccTypeId").append("<option value=''>" + "-- Select--" + "</option>");

                                $("#ddlAirLines").empty();
                                $("#ddlAirLines").append("<option value=''>" + "-- Select--" + "</option>");


                                //Foreach Model in the list, add a model option from the data returned
                                $.each(data, function (index, optionData) {
                                    $("#loadingProductIndicator").html(' ');
                                    $("#AccTypeId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                                });
                            });
                        }
                    }).change();

                });
                //////////////////////////////////////////////////////////////////////////////////////////////////////


                ////////////// GetAccSubGroup on selecting ProductName and AccountGroupName///////////////
                $(document).ready(function () {

                    $("#ProductId, #AccGroupId").change(function () {
                        id = $("#ProductId").val();
                       
                        accgroupid = $("#AccGroupId").val();
                       
                        if (id == "" || accgroupid == "") {
                            return false;
                        }
                        else {
                            //build the request url
                            $("#loadingProductIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
                            var url = "/Administrator/AjaxRequest/GetAccSubGroupBasedOnProductNameandAccountGroupName";
                            //fire off the request, passing it the id which is the MakeID's selected item value

                            $.getJSON(url, { id: id, accgroupid: accgroupid }, function (data) {

                                //Clear the Model list
                                $("#AccSubGroupId").empty();
                                $("#AccSubGroupId").append("<option value=''>" + "-- Select--" + "</option>");


                                //Foreach Model in the list, add a model option from the data returned
                                $.each(data, function (index, optionData) {
                                    $("#loadingProductIndicator").html(' ');
                                    $("#AccSubGroupId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                                });
                            });
                        }
                    }).change();

                });
                //////////////////////////////////////////////////////////////////////////////////////////////////////




    </script>
</asp:Content>
