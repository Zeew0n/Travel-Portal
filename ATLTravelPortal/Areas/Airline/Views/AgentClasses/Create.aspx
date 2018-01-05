<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentClassesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
  
      <%using(Html.BeginForm())
        { %>
    

     <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li><input type="submit" value="Save"  /></li>
            <li><input type="button" onclick="document.location.href='/Airline/AgentClasses/Index'" value="Cancel"  />   

            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong>Agent Class</strong>
        </h3>
    </div>




    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                        <%:Html.Label("Agent Class") %>
                            </label>
                        <%:Html.TextBoxFor(model=>model.AgentTypeClasses) %>
                        <%:Html.ValidationMessageFor(model => model.AgentTypeClasses)%>
                    </div>
                </div>
              
                

            </div>
            <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                        <%:Html.Label("Description") %>
                            </label>
                        <%:Html.TextAreaFor(model=>model.Description) %>
                        <%:Html.ValidationMessageFor(model=>model.Description) %>
                    </div>
                </div>

            </div>
           
            
            <p style="color:Red"><%:TempData["AgentTypeName"]%></p>
        </div>
       <%-- <div class="buttonBar">
<input type="submit" value="Save"  />     
<input type="button" onclick="document.location.href='/Airline/AgentClasses/Index'" value="Cancel"  />  
                </div>--%>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
