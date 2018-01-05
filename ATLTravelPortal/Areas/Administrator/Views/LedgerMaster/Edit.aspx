<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerMasterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>

    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm("Edit", "LedgerMaster", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
  
     <div class="pageTitle">
      <div class="float-right">
                <input type="submit" value="Update" />
                 <%:Html.ActionLink("Cancel", "Index", new { controller = "LedgerMaster" }, new { @class = "linkButton float-right" })%>
            	  
            </div>
        
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Ledger Master</strong><span>&nbsp;</span><strong>Edit</strong>
        </h3>
    </div>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label(" Product:")%></label>
                        <%:Html.DropDownListFor(model => model.ProductId, (SelectList)ViewData["Product Name"], "-----Select-----")%>
                        <%--<%:Html.DropDownListFor(model => model.ProductId, Model.ProductNameList, "-----Select-----")%>--%>
                        <%: Html.ValidationMessageFor(model => model.ProductId,"*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Account Group:")%></label>
                        <%:Html.DropDownListFor(model => model.AccGroupId, (SelectList)ViewData["Account Group Name"], "-----Select-----")%>
                       <%--<%:Html.DropDownListFor(model => model.AccGroupId, Model.AccGroupNameList, "-----Select-----")%>--%>
                        <%: Html.ValidationMessageFor(model => model.AccGroupId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Account Sub Group:")%></label>
                        <%:Html.DropDownListFor(model => model.AccSubGroupId, (SelectList)ViewData["Account Sub Group Name"], "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.AccSubGroupId, "*")%>
                    </div>
                </div>
            </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Account Type:")%></label>
                        <%:Html.DropDownListFor(model => model.AccTypeId, (SelectList)ViewData["Account Type Name"], "-----Select-----")%>
                        <%: Html.ValidationMessageFor(model => model.AccTypeId, "*")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <%:Html.DropDownListFor(model => model.ddlAirLines, (SelectList)ViewData["Type Name"], "-----Select-----")%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Ledger Name:</label>
                        <%: Html.TextBoxFor(model => model.LedgerName)%>
                        <%: Html.ValidationMessageFor(model => model.LedgerName)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-right">
                    <div style="color: Red">
                        <%:TempData["Error"]%>
                    </div>
                </div>
            </div>
        </div>
       <%-- <div class="buttonBar">
                <input type="submit" value="Save" />
                 <%:Html.ActionLink("Cancel", "Index", new { controller = "LedgerMaster" }, new { @class = "linkButton float-right" })%>
            	  
            </div>--%>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   

   

</asp:Content>
