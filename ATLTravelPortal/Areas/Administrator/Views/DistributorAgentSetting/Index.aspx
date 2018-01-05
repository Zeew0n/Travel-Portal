<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentSettingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Agents Setting
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div class="pageTitle">
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Agents</strong><span>&nbsp;</span><strong>Agents
                Setting</strong>
        </h3>
    </div>
    <%using (Html.BeginForm("Index", "DistributorAgentSetting", FormMethod.Post, new { @class = "validate" }))
      { %>
    <div class="row-1">
        <h3 class="pageTitle" style="color: Green;">
            <b>
                <%: Model.AgentName %></b>
        </h3>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Agent Class") %></label>
                        <%: Html.DropDownListFor(model => model.AgentClassId, (SelectList)ViewData["agentClass"], "---Select Type---", new { @class = "required" })%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Airline Deal") %></label>
                        <%: Html.DropDownListFor(model => model.MasterDealIdOfAirlines, Model.MasterDealNameListOfAirlines, "--- Select ------")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Hotel Deal") %></label>
                        <%: Html.DropDownListFor(model => model.MasterDealIdOfHotel, Model.MasterDealNameListOfHotels,"--- Select ------")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Bus Deal") %></label>
                        <%: Html.DropDownListFor(model => model.MasterDealIdOfBus, Model.MasterDealNameListOfBus, "--- Select ------")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Mobile Deal") %></label>
                        <%: Html.DropDownListFor(model => model.MasterDealIdOfMobile, Model.MasterDealNameListOfMobile,"--- Select ------")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-box1-row" style="border: 1px solid #ccc; padding: 5px; width: 45%;">
        <div class="form-box1-row-content">
            <div>
                <h5 class="border-btm">
                    Add Setting</h5>
                <p>
                    <label style="width: 125px;">
                        <strong>Select All</strong>
                    </label>
                    <input type="checkbox" name="ChkIdAll" class="ChkBoxParent" />
                    <br />
                </p>
                <% foreach (var agentsetting in Model.agentsettinglist)
                   { %>
                <p>
                    <%if ((ATLTravelPortal.Areas.Administrator.Models.ModelSettingExtension.IsActiveSetting(agentsetting.SettingId, Model.Activeagentsettinglist)) == true)
                      { %>
                    <input type="checkbox" name="ChkSettingId" value="<%=agentsetting.SettingId%>" checked="checked"
                        class="ChkBoxChild" />
                    <%}
                      else
                      { %>
                    <input type="checkbox" name="ChkSettingId" value="<%=agentsetting.SettingId%>" class="ChkBoxChild" />
                    <%} %>
                    <label>
                        <% =agentsetting.SettingName%></label>
                </p>
                <%}%>
            </div>
        </div>
    </div>
    <br />
    <div class="form-box1-row">
        <div id="ListTable">
            <% 
                   int i = 0;
                   foreach (var item in Model.ServiceProviders)
                   {%>
            <% Html.RenderPartial("IndividualServiceProvider", item, new ViewDataDictionary { new KeyValuePair<string, object>("Count", i) }); %>
            <%i++;
                   } %>
            <input type="button" value="Cancel" class="float-right" onclick="window.location='/Administrator/AgentManagement/'" />
            <input type="submit" value="Save" class="float-right" />
            <%} %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ChkBoxParent').click(function () {
                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            });

            $('.ChkBoxChild').click(function () {
                var childCheckBox = $('.ChkBoxChild');
                var checkedAllStatus = true;
                for (var i = 0; i < childCheckBox.length; i++) {
                    if (!$(childCheckBox[i]).is(':checked')) {
                        checkedAllStatus = false;
                    }
                }
                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            });
            var childCheckBox = $('.ServiceProvidercheckbox');
            for (var i = 0; i < childCheckBox.length; i++) {
                if (!$(childCheckBox[i]).is(':checked')) {
                    var id = $(childCheckBox[i]).attr('id');
                    $('.' + id + "childbalancecheckon").attr('disabled', 'disabled');
                }
            }

            $('.ServiceProvidercheckbox').live("change", function () {
                var id = $(this).attr('id');
                if (!$(this).is(':checked')) {
                    $('.' + id + "childbalancecheckon").attr('disabled', 'disabled');
                }
                else {
                    $('.' + id + "childbalancecheckon").removeAttr("disabled", "disabled");
                }

            });
        });
   
    </script>
</asp:Content>
