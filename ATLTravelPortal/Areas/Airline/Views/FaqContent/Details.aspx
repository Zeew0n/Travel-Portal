<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.FAQContentModel>" %>
    <%@ Import Namespace="ATLTravelPortal.Helpers" %>
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
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/FaqContent/Index'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>FAQ Content</strong>
        </h3>
    </div>
    
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HeadingId) %></label>
                        <%=Html.Encode(Model.HeadingTitle) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Question) %></label>
                    <%=Html.Encode(Model.Question) %>
                </div>
            </div>
            <div class="form-box1-row">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Answer) %></label>
                   <%=Html.Encode(Model.Answer) %>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%:Html.LabelFor(model=>model.CreatedBy) %>
                        </label>
                        <%=Html.Encode(Model.CreatorName) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.LabelFor(model=>model.CreatedDate) %>
                        </label>
                       
                        <%=Html.Encode(String.Format("{0:g}",Model.CreatedDate)) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%:Html.LabelFor(model=>model.UpdatedBy) %>
                        </label>
                      
                        <%=Html.Encode(Model.UpdatorName) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.LabelFor(model=>model.UpdatedDate) %>
                        </label>
                        <%=Html.Encode(String.Format("{0:g}",Model.UpdatedDate))%>
                            
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
