<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentClassesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%ATLTravelPortal.Areas.Airline.Repository.GeneralProvider ent = new ATLTravelPortal.Areas.Airline.Repository.GeneralProvider(); %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
               </li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AgentClasses/'" />
            </li>
        </ul>
        <h3>
            Setup<span>&nbsp;</span><strong>Agent Class</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Name:</label>
                        <%--<%: Model.TranDate %>--%>
                        <%:Model.AgentTypeClasses %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Description:</label>
                        <%: Model.Description %>
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
