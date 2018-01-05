<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.FAQContentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
       <%-- <div class="userinfo">
            <h3>
                FAQ Content</h3>
        </div>--%>
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
                <input type="submit" value="Save" class="save" /></li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/FaqContent/Index'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create Content</strong>
        </h3>
    </div>
    
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HeadingId) %></label>
                        <%: Html.DropDownListFor(model => model.HeadingId,Model.ddlHeadingList)%>
                        <%: Html.ValidationMessageFor(model => model.HeadingId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Question) %></label>
                        <%: Html.TextAreaFor(model => model.Question)%>
                        <%: Html.ValidationMessageFor(model => model.Question)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Answer) %></label>
                        <%: Html.TextAreaFor(model => model.Answer)%>
                        <%: Html.ValidationMessageFor(model => model.Answer)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
