<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentCallLogModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li> <input type="button" onclick="document.location.href='/Administrator/AgentCallLog/Index'"
            value="Cancel" /></li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Call
                Log</strong>
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
            <div class="form-box1-row-content float-left">
                <div class="float-left">
                  <label style="width:35px;">For:</label>
                    
                   <%: Model.For_ProductName %>
                </div>
                <div class="float-left">
                    
                   <label style="width:35px;">On:</label>
                    
                   <%: Model.On_ServiceProviderName %>
                </div>
            </div>
           
        </div>

       


        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:800px;">
                <div>
                    <label>
                        Purpose:
                    </label>
                   <%: Model.Purpose %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:800px;">
                <div>
                    <label>
                      Note:
                    </label>
                  <%: Model.Note %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width:375px;">
                <div>
                    <label>
                      Duration:
                    </label>
                   <%: Model.Duration %><i>(min:sec)</i>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Follow up this agent:
                    </label>
                    <%: Model.Followupthisagent %>
                </div>
            </div>
        </div>
    </div>
  
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   
</asp:Content>
