﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CountryManagementModel>" %>

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

      <%if (TempData["ErrorMessage"] != null)
      { %>
    <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all"> 
		    <p><span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
           <strong><% = TempData["ErrorMessage"]%></strong></p>
    </div>
    <%} %>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "CountryManagement", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
            </li>
            <li>
                <input type="submit" value="Save" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/CountryManagement/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Country Management</a> <span>&nbsp;</span><strong> Create</strong>
            </h3>
        </div>
    </div>
     <div class="row-1">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                               <label> <%: Html.LabelFor(model=>model.CountryName) %></label>
                            <%: Html.TextBoxFor(model => model.CountryName)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.CountryName)%>
                           
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label> <%: Html.LabelFor(model=>model.CountryCode) %></label>
                            <%: Html.TextBoxFor(model => model.CountryCode)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.CountryCode)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><label> <%: Html.LabelFor(model=>model.Nationality) %></label>
                             <%: Html.TextBoxFor(model => model.Nationality)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.Nationality)%></div>
                        </div>
                    </div>
                </div>
    <% } %>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>