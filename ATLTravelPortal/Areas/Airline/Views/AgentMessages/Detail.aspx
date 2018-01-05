<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentMessagesModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <div class="float-right">
            <a href="/Airline/AgentMessages/Edit/<%:Model.AgentMessageId %>" class="linkButton"
                title="Edit">Edit</a>
            <%:Html.ActionLink("Cancel", "Index", new { controller = "AgentMessages" }, new { @class = "linkButton" })%>
        </div>
        <h3>
            <a class="icon_plane" href="#">Account</a> <span>&nbsp;</span><strong> Agent Message</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Agent:</label>
                        <%: Model.AgentName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Product:</label>
                        <%:Model.ProductName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Message:</label>
                        <%:Model.MessageText%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
