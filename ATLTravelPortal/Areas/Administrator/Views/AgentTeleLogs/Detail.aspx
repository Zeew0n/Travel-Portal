<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentTeleLogsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <div class="float-right">
        <input type="button" onclick="document.location.href='/Administrator/AgentTeleLogs/Index'"
            value="Cancel" />
    </div>
        <h3>
            <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Tele
                Logs</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        Agent Name:
                    </label>
                   <%: Model.AgentName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                        Title:
                    </label>
                 <%: Model.Title %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                       Contact Person:
                    </label>
                   <%: Model.ContactPerson %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                      Contact Number:
                    </label>
                  <%: Model.ContactNumber %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Problem Category:
                        </label>
                 <%: Model.ProblemCategoryId %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                       Remarks:
                    </label>
                  <%: Model.Remarks %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:450px;">
                <div>
                    <label>
                      Competitor Information:
                    </label>
                   <%: Model.CompetitorInformation %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                       Follow up:
                    </label>
                   <%: Model.isNeededFollowUp %>
                </div>
            </div>
        </div>
    </div>
   <%-- <div class="buttonBar">
        <input type="button" onclick="document.location.href='/Administrator/AgentTeleLogs/Index'"
            value="Cancel" />
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
