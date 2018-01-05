<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OfflineIssueSourceModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
      { %>
    <%=Html.ValidationSummary(true)%>
    
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <input type="submit" value="Update" class="save" /></li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/OfflineIssueSource/'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Manage Offline Issue Source</a> <span>&nbsp;</span><strong>Edit Offline Issue Source</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ServiceProvider) %></label>
                        <%: Html.TextBoxFor(model => model.ServiceProvider)%>
                        <%: Html.ValidationMessageFor(model => model.ServiceProvider)%>
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
                            Is Active</label>
                        <%: Html.CheckBoxFor(model => model.IsActive)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- <div class="buttonBar">
        <input type="submit" value="Save" />
        <input type="button" onclick="document.location.href='/Airline/OfflineIssueSource/Index'" value="Cancel" />
    </div>--%>
    <div id="Error" style="color: Red">
        <%:TempData["Error"] %>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
