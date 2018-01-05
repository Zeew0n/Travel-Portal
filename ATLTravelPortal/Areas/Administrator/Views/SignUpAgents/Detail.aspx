<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgencyModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["ErrorMessage"] != null)
        { %>
    <%: TempData["ErrorMessage"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm("Detail", "SignUpAgents", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
            </li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/SignUpAgents/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Sign-Up Agents</a> <span>&nbsp;</span><strong>Detail</strong>
            </h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Agency Name:") %></label>
                    <%:Model.AgencyName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Email:") %></label>
                    <%: Model.Email %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Mobile:") %></label>
                    <%:Model.Mobile %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Phone:") %></label>
                    <%:Model.Phone %>
                </div>
            </div>
        </div>
    
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Zone:") %></label>
                    <%: Model.StateName%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("District:") %></label>
                    <%:Model.CityName%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Address:") %></label>
                    <%: Model.Address %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Contact Person:") %></label>
                    <%: Model.ContactPerson %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Pan Holder Name:") %></label>
                    <%: Model.PanHolderName %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Pan Card No:") %></label>
                    <%: Model.PanCardNo %>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <a href="/Administrator/SignUpAgents/Edit/<%:Model.AgentId  %>" class="linkButton"
        onclick="return confirm('Are you sure you want to approve?')">Approve</a>
    <% }
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
