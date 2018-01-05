<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentCallLogModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm("Create", "AgentCallLog", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
       { %>
    <div class="pageTitle">
        <div class="float-right">
        <input type="submit" value="Save" />
          <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentCallLog" }, new { @class = "linkButton float-right" })%>
    </div>
        <h3>
            <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Call
                Log</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.AgentName) %>
                    </label>
                    <%:Html.TextBoxFor(model => model.AgentName, new { @style = "width:300px;" })%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.AgentName)%>
                    <%:Html.HiddenFor(model => model.hdfAgentId)%>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div class="float-left">
                  <label style="width:35px;">For</label>
                    
                    <%:Html.DropDownListFor(model => model.For_ProductId, Model.For_ProductList, new { @style = "width:125px;" })%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.For_ProductId)%>
                </div>
                <div class="float-left">
                    
                   <label style="width:35px;">On</label>
                    
                    <%:Html.DropDownListFor(model => model.On_ServiceProviderId, Model.On_ServiceProviderList, "---Select---", new { @style = "width:125px;" })%>
                    <%: Html.ValidationMessageFor(model => model.On_ServiceProviderList)%>
                </div>
            </div>
        </div>

    

           <div class="form-box1-row">
           
            <div class="form-box1-row-content float-left" style="width:270px;">
                <div>
                  <label >Category</label>
                    <% List<SelectListItem> CategoryList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "Booking", Text = "Booking"},
                                        new SelectListItem {Selected = false, Value = "Modification", Text = "Modification"},
                                        new SelectListItem {Selected = false, Value = "Cancellation ", Text = "Cancellation "},
                                        new SelectListItem {Selected = false, Value = "Refund", Text = "Refund"},
                                        new SelectListItem {Selected = false, Value = "Fares", Text = "Fares"},
                                        new SelectListItem {Selected = false, Value = "Insurance", Text = "Insurance"},
                                        new SelectListItem {Selected = false, Value = "APIS", Text = "APIS"},
                                        new SelectListItem {Selected = false, Value = "Accounts", Text = "Accounts"},
                                        new SelectListItem {Selected = false, Value = "Email", Text = "Email"},
                                        new SelectListItem {Selected = false, Value = "Training", Text = "Training"},
                                        new SelectListItem {Selected = false, Value = "Technical issues", Text = "Technical issues"},
                                        new SelectListItem {Selected = false, Value = "Tour package", Text = "Tour package"},
                                        new SelectListItem {Selected = false, Value = "Revalid", Text = "Revalid"},
                                        new SelectListItem {Selected = false, Value = "Taxi", Text = "Taxi"},
                                        new SelectListItem {Selected = false, Value = "Railways", Text = "Railways"},
                                        new SelectListItem {Selected = false, Value = "Travel Insurance", Text = "Travel Insurance"},
                                         
                                    };%>
                    <%:Html.DropDownListFor(model => model.CategortId, CategoryList, new { @style = "width:125px;" })%>
                </div>

                
            </div>
            <div class="form-box1-row-content float-left">
            <div>
                   <label>Sub Category</label>

                     <% List<SelectListItem> SubCategoryList = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = false, Value = "New ", Text = "New "},
                                        new SelectListItem {Selected = false, Value = "Booking", Text = "Booking"},
                                        new SelectListItem {Selected = false, Value = "Status Check ", Text = "Status Check "},
                                        new SelectListItem {Selected = false, Value = "Sector Change", Text = "Sector Change"},
                                        new SelectListItem {Selected = false, Value = "Date Change", Text = "Date Change"},
                                        new SelectListItem {Selected = false, Value = "Void", Text = "Void"},
                                        new SelectListItem {Selected = false, Value = "Full cancel", Text = "Full cancel"},
                                        new SelectListItem {Selected = false, Value = "Partial Cancel", Text = "Partial Cancel"},
                                        new SelectListItem {Selected = false, Value = "Full Refund", Text = "Full Refund"},
                                        new SelectListItem {Selected = false, Value = "Partial Refund", Text = "Partial Refund"},
                                        new SelectListItem {Selected = false, Value = "Promotional Fare", Text = "Promotional Fare"},
                                        new SelectListItem {Selected = false, Value = "Sector fares", Text = "Sector fares"},
                                        new SelectListItem {Selected = false, Value = "Group Fare", Text = "Group Fare"},
                                        new SelectListItem {Selected = false, Value = "Tax info", Text = "Tax info"},
                                        new SelectListItem {Selected = false, Value = "Balance topup", Text = "Balance topup"},
                                        new SelectListItem {Selected = false, Value = "Collect Cheque", Text = "Collect Cheque"},
                                        new SelectListItem {Selected = false, Value = "Ticket", Text = "Ticket"},
                                        new SelectListItem {Selected = false, Value = "Error in portal", Text = "Error in portal"},
                                        new SelectListItem {Selected = false, Value = "User ID locked", Text = "User ID locked"},
                                        new SelectListItem {Selected = false, Value = "Visa", Text = "Visa"},
                                        new SelectListItem {Selected = false, Value = "Passport", Text = "Passport"},
                                         
                                    };%>
                    <%:Html.DropDownListFor(model => model.SubCategortId, SubCategoryList, new { @style = "width:125px;" })%>
                   
                </div>
            </div>
        </div>





        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:800px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Purpose) %>
                    </label>
                    <%:Html.TextAreaFor(model => model.Purpose, new { @style = "width:657px;" })%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.Purpose)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:800px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Note) %>
                    </label>
                    <%:Html.TextAreaFor(model => model.Note, new { @style = "width:657px;" })%>
                    <%: Html.ValidationMessageFor(model => model.Note)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:375px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Duration)%>
                    </label>
                   
                    <%:Html.TextBoxFor(model => model.Duration, new { @class = "callDuration" })%>
                     <i>(min:sec)</i>
                    
                    <%: Html.ValidationMessageFor(model => model.Duration)%>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.Followupthisagent) %>
                    </label>
                    <%:Html.CheckBoxFor(model => model.Followupthisagent)%>
                </div>
            </div>
        </div>

        <div class="form-box1-row">
           
            <div class="form-box1-row-content float-left" style="width:150px;">
                <div>
                   <label>Incoming</label>
                   <%: Html.RadioButtonFor(model => model.rdbCallType, "Incoming", new { @checked = "checked" })%> 
                        
                </div>
            </div>

             <div class="form-box1-row-content float-left">
                <div>
                   <label>Outgoing</label>
                   <%: Html.RadioButtonFor(model => model.rdbCallType, "Outgoing")%> 
                </div>
            </div>
        </div>



    </div>
   <%-- <div class="buttonBar">
        <input type="submit" value="Save" />
    </div>--%>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $(function () {
                $("#AgentName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Administrator/AjaxRequest/FindAgentName", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    // return { label: item.AirlineCode, value: item.AirlineCode, id: item.AirlineId }
                                    //return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineCode, id: item.AirlineId }
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }


                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfAgentId").val(ui.item.id);
                    }

                });
            });



        });
        //////////////End of document Ready function/////////////////////


        $(".callDuration").live('click', function () {
            $(".callDuration").mask("99:99", { placeholder: "0" });
            // $(".callDuration").mask("99:99:99", { defaultvalue: "00:00:00" });
        });

    </script>
</asp:Content>
