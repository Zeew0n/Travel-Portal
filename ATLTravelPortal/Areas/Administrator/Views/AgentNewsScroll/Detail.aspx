<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentNewsScrollModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

        
     <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
                </li>
                  <%--<li>
                <a href="/Administrator/AgentNewsScroll/Edit/<%:Model.ScrollNewsId %>" class="new"
                    title="Edit">Edit</a></li>--%>
               <li>
                <input type="button" onclick="document.location.href='/Administrator/AgentNewsScroll/Index'"
                    value="Cancel" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>News Scroll</strong><span>&nbsp;</span><strong>Detail</strong>
        </h3>
    </div>


      
  
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            News Text:</label>
                        <%:  Model.NewsText%>
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
                            IsActive:</label>
                        <%:Model.IsActive%>
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
