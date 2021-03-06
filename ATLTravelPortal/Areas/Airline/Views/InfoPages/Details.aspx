﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.InfoPagesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/InfoPages/'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Detail  InfoPages</strong>
        </h3>
    </div>
        
           
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Name) %></label>
                        <%--<%: Html.TextBoxFor(model => model.Name)%>--%>
                        <%=Html.Encode(Model.Name) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Title)%></label>
                        <%--<%: Html.TextBoxFor(model => model.Title)%>--%>
                        <%=Html.Encode(Model.Title) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Description) %></label>
                        <%--<%: Html.TextAreaFor(model => model.Description)%>--%>
                        <%=Html.Encode(Model.Description) %>
                    </div>
                </div>
            </div>

        </div>
    </div>
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../Scripts/jquery.nicEdit.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        bkLib.onDomLoaded(function () { new nicEditor().panelInstance('Description'); });

    });
</script>
</asp:Content>
