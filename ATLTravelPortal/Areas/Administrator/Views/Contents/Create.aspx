<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ContentsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%: Html.ValidationSummary(true)%>
    <% using (Html.BeginForm("Create", "Contents", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       { %>
    <div class="pageTitle">
  
            <div class="float-right">
        <input type="submit" value="Save" />
          <input type="button" onclick="document.location.href='/Administrator/Contents/Index'"
            value="Cancel" />
          
    </div>
        
        <h3>
            <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Page</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">


        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
               
                    <label>
                        <%: Html.LabelFor(model=>model.Title) %>
                    </label>
                     <div>
                   <%-- <%:Html.TextBoxFor(model => model.Title, new { @style = "width:300px;", onkeyup="OneTextToOther();" })%>--%>
                    <%:Html.TextBoxFor(model => model.Title, new { @style = "width:400px;"})%>
                    <span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.Title)%>
                </div>
            </div>
        </div>
        

        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
               
                    <label>
                        <%: Html.LabelFor(model=>model.URL) %>
                    </label>
                     <div>
                  
                    <%:Html.TextBoxFor(model => model.URL, new { @style = "width:159px;" })%><span class="redtxt">*</span>
                     <%: Html.ValidationMessageFor(model => model.URL)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                    <label>
                        <%: Html.LabelFor(model=>model.Body) %>
                    </label>
                    <div>
                    <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                        <%= Html.TextArea("Body", Model.Body, new { @class = "ckeditor" })%><span class="redtxt">*</span>
                         <%: Html.ValidationMessageFor(model => model.Body)%>
                    </div>

                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 400px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model=>model.isPublish) %>
                    </label>
                    <%: Html.CheckBoxFor(model=>model.isPublish) %>
                </div>
            </div>
        </div>
    </div>
    
    <%--<div class="buttonBar">
        <input type="submit" value="Save" />
          <input type="button" onclick="document.location.href='/Administrator/Contents/Index'"
            value="Cancel" />
          <%--  <input type="submit" value="Preview" />
    </div>--%>--%>

    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Title]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone.split(' ').join('-');
                //                var finaltext = txtClone.replace(' ', "-");
                //                $('input[id$=URL]').val(txtClone);
                $('input[id$=URL]').val(finaltext);
            });
        });

    </script>


</asp:Content>
