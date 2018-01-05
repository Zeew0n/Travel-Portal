<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentNewsScrollModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["error"] != null)
        { %>
    <%: TempData["error"]%>
    <%
    
        }
    %>

   

    <% using (Html.BeginForm("Edit", "AgentNewsScroll", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
        <% Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true) %>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right"><li>
            <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
            </li>
            <li>
                <input type="submit" value="Update" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/AgentNewsScroll/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#">System Setup</a> <span>&nbsp;</span><strong>News Scroll</strong><span>&nbsp;</span><strong>Edit</strong>
            </h3>
        </div>
    </div>
   
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%:Html.LabelFor(model => model.NewsText)%>
                       <%:Html.TextAreaFor(model =>model.NewsText, new { @Style = " width:400px; margin-left:43px; padding:5px;" })%>   
                        <%:Html.ValidationMessageFor(model => model.NewsText, "*")%>
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
                       <%:Html.LabelFor(model => model.IsActive)%>
                        <%:Html.CheckBoxFor(model => model.IsActive)%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <% } %>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   
</asp:Content>
