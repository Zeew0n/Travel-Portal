<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MessagePanelsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
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
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
            </li>
            <li>
                <input type="submit" value="Save" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/MessagePanels/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Message Panel</a> <span>&nbsp;</span><strong> Create</strong>
            </h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div>
                    <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                        <%:Html.LabelFor(model => model.MessageText)%>
                        <%= Html.TextArea("MessageText", Model.MessageText, new { @class = "ckeditor" })%>
                        <%:Html.ValidationMessageFor(model => model.MessageText, "*")%>
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
                        <% List<SelectListItem> Panellist = new List<SelectListItem>{
                                     
                                        new SelectListItem {Selected = true, Text = "Advance Search Panel", Value = "1"},
                                        new SelectListItem {Selected = false, Text = "Basic Search Panel", Value = "2"},
                                        new SelectListItem {Selected = false, Text="Indian LCC Panel", Value = "3"},
                                         
                                    };%>
                        <%:Html.LabelFor(model => model.PanNoId)%>
                        <%: Html.DropDownListFor(model=>model.PanNoId, Panellist) %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <% } %>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../../../../Content/ckeditor/_samples/sample.js" type="text/javascript"></script>
    <link href="../../../../Content/ckeditor/_samples/sample.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var config = {
                toolbar:
                      [
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                        ['Link', 'Unlink', 'Anchor'],
                        ['Image', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak'],
                        '/',
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor'],
                        ['-']
                      ]
            };
            CKEDITOR.replace('MessageText', config);

        });


    </script>
</asp:Content>
