<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
      {%>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentManagement" }, new { @class = "linkButton" })%></li>
            </ul>
        </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Agents</strong><span>&nbsp;</span><strong>Details
            </strong>
        </h3>
    </div>

    <div class="wiz-container">
        <%-- ----------------- End of Define Tab wizard Heading and steps contents -----------------------------%>
        <%-- ----------------- Begin of Tab wizard body contents ----------------------------------------------%>
        <div class="wiz-body">
            <%-- ----------------------------------Begin Tab wizard No.1 -----------------------------------------------%>
            <div id="wizard-1">
                <div class="wiz-content">
                    <%-- -------------End of Body for Tab wizard No.1 --------------%>
                    <%-- -----------Next and Back button------------------------%>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    1. Agent Basic Info</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.1 --------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.2 -----------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.2 --------------%>
                <div id="wizard-2">
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Name:")%></label>
                                            <% =Model.AgentName%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Address:")%></label>
                                            <%: Model.Address%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Phone Number:")%></label>
                                            <% =Model.Phone%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Email Address:")%></label>
                                            <% =Model.Email%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Fax Number:")%></label>
                                            <% =Model.FaxNo%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("PAN Number:")%></label>
                                            <% =Model.PanNo%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("URL:")%></label>
                                            <%:Model.Web != null ? Model.Web : " N/A "%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Country:")%></label>
                                            <% =Model.AgentCountryName%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Status:")%></label>
                                            <%--<%: Model.AgentStatusid %>--%>
                                            <%if (Model.AgentStatusid == 1)
                                              { %>
                                            Active
                                            <%} %>
                                            <% else
                                              { %>
                                            Deactive
                                            <%} %>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Zone:")%></label>
                                            <%: Model.ZoneName%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent District:")%></label>
                                            <%: Model.DistrictName%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Type:")%></label>
                                            <%: Model.AgentTypeName%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Code:")%></label>
                                            <%:Model.AgentCode != null ? Model.AgentCode : " N/A "%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Class:")%></label>
                                            <%:Model.AgentClassName%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--  button for next and back in wizard region --%>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    2. Agent Setting</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.2 --------------------------------------------%>
                <div>
                    <%-- ----------------------------------Begin Tab wizard No.3 -----------------------------------------------%>
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                    <%-- -------- Logic for displaying Total number or max user -------------%>
                                    <%if (Model.MaxNumberOfAgentUser == -1)
                                      { %>
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Unlimited User:")%></label>
                                            <%: true%>
                                        </div>
                                    </div>
                                    <%}
                                      else
                                      {%>
                                    <%-- --------else condition------------------%>
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Unlimited User:")%></label>
                                            <%: false%>
                                        </div>
                                    </div>
                                    <%} %>
                                    <%-- ----------End of Logic for displaying Total number or max user ----------------%>
                                    <div class="form-box1-row-content float-right">
                                        <div id="limiteduser">
                                            <label>
                                                <%: Html.Label("Max Number of User:")%></label>
                                            <%: Model.MaxNumberOfAgentUser%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Airline Group List:")%></label>
                                            <% =(Model.AirlineGroupName)%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Airline Deal:")%></label>
                                            <%:Model.AgentDealName%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Hotel Deal:")%></label>
                                            <%:Model.AgentDealName%>
                                        </div>
                                    </div>
                                    <%--   added newly for time zone--%>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Time Zone:")%></label>
                                            <%: Model.TimeZoneName%>
                                        </div>
                                    </div>
                                    <%--....................................--%>
                                </div>
                            </div>
                            <div id="check_Field" class="checkIfExsit">
                            </div>
                        </div>
                        <div class="form-box1-row" style="border: 1px solid #ccc; padding: 5px; width: 45%;">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <h5 class="border-btm">
                                        Setting</h5>
                                    <% foreach (var item in Model.AgentSettingDetailList)
                                       { %><div class="form-box1-row">
                                           <div class="form-box1-row-content float-left ">
                                               <div>
                                                   <label>
                                                       <strong>Setting List :</strong></label>
                                                   <%:item%>
                                               </div>
                                           </div>
                                       </div>
                                    <%}%>
                                    <% foreach (var item in Model.agentbankDetaillist)
                                       { %>
                                    <div class="form-box1-row">
                                        <div class="form-box1-row-content float-left ">
                                            <div>
                                                <label>
                                                    <strong>Bankinfo List :</strong></label>
                                                <%:item%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-box1-row">
                                        <div class="form-box1-row-content float-left ">
                                            <% foreach (var items in Model.agentIPList)
                                               { %>
                                            <div>
                                                <label>
                                                    <strong>Ip Address :</strong></label>
                                                <%:items%><%}%>
                                            </div>
                                        </div>
                                    </div>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    3. Agent Authorize User</h2>
                            </a></li>
                        </ul>
                    </div>
                    <div id="check_Field" style="display: block;">
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.3 ----------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.4 --------------------------------------------%>
                <div>
                    <div class="wiz-content">
                        <div class="form-box1 round-corner">
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Full Name:")%></label>
                                        <% =Model.AgentName%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("User Name:")%></label>
                                        <%: Model.UserName%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Email Address:")%></label>
                                        <% =Model.Email%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Address:")%></label>
                                        <% =Model.Address%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Mobile Number:")%></label>
                                        <% =Model.MobileNo%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Phone Number:")%></label>
                                        <%: Model.PhoneNo%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.4 --------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.5 --------------------------------------------%>
                <%-- ----------------------------------End of Tab wizard No.5 ---------------------------------------------%>
            </div>
        </div>
      
        <%-- -----------------End of Wizard Region start From here------------------------------------------------------%>
       
        </div>
         <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .form-box1-row-content div span.field-validation-error
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
