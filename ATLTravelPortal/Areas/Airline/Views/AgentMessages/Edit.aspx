<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentMessagesModel>" %>

 <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Agent Message
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Agent Message Setup
            </h3>
        </div>
    </div>

    

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">

             <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AgentId)%></label>
                    <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"])%>
                    <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
                    </div>
                </div>

                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Productid)%></label>
                    <%:Html.DropDownListFor(model => model.Productid, Model.ProductList)%>
                    <%: Html.ValidationMessageFor(model => model.Productid, "*")%>
                    </div>
                </div>

                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                             <%:Html.LabelFor(model => model.MessageText)%>
                    <%:Html.TextAreaFor(model => model.MessageText, new { @Style = " width:400px; margin-left:43px; padding:5px;" })%></label>
                    <%:Html.ValidationMessageFor(model => model.MessageText, "*")%>
                    </div>
                </div>
            </div>
        </div>
      
         <div class="buttonBar">
         <ul class="buttons-panel float-right">
            <li>
                <input type="submit" value="Submit" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Airline/AgentMessages/Index'"
                    value="Cancel" /></li>
        </ul>
        </div>
    </div>
    <% } %>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  
</asp:Content>
