<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.VoidCancellationRequestRuleModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Void Cancellation Request Rule</strong>
            </h3>
        </div>
    </div>
       
         <div>
            <label>
                    Products</label>
            <%:Html.DropDownListFor(model=>model.ProductId,Model.ProductOption,"--Select--") %>
        </div>
        <br />
       
        <div>
            <label>
                    SunDay</label>
            <%:Html.CheckBoxFor(model=>model.SunDay) %>
        </div> <br />
       <div>
        <label>
                MonDay</label>
            <%:Html.CheckBoxFor(model=>model.MonDay) %>
        </div> <br />
       <div>
        <label>
                TuesDay</label>
            <%:Html.CheckBoxFor(model=>model.TuesDay) %>
        </div> <br />

       <div>
        <label>
                WednesDay</label>
            <%:Html.CheckBoxFor(model => model.WednesDay)%>
        </div> <br />
        
        <div>
        <label>
                ThrusDay</label>
            <%:Html.CheckBoxFor(model => model.ThrusDay)%>
        </div><br />

        <div>
        <label>
                FriDay</label>
            <%:Html.CheckBoxFor(model => model.FriDay)%>
        </div> <br />
        <div>
        <label>
                SaturDay</label>
            <%:Html.CheckBoxFor(model => model.SaturDay)%>
        </div> <br />
       <div>
            <label>
                   From Time</label>
                   <%: Html.TextBoxFor(model=>model.FromTime) %>
                   <%: Html.ValidationMessageFor(model=>model.FromTime) %>
            <label> 
                    To Time</label>
                    <%: Html.TextBoxFor(model=>model.ToTime) %>
                    <%: Html.ValidationMessageFor(model=>model.ToTime) %>
       </div> <br />
       <div>
            <label>
                    Within Hour</label>
                <%: Html.TextBoxFor(model=>model.WithinHour) %>  hr
       </div> <br />
       <div>
            <label>
                    Rule On</label>
            <%: Html.DropDownListFor(model=>model.RuleOn,Model.RuleOnOption) %>
       </div> <br />
       <div> 
        <%: Html.HiddenFor(model=>model.VoidCancellationRuleId) %></div>
        <div>
        <%: Html.HiddenFor(model=>model.temp) %></div>

       <input type = "submit" value = "Update" />
   
    <%} %>
</asp:Content>
