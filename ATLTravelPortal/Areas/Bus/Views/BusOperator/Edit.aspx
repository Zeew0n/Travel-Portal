<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusMasterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Bus Operator
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <%using (Html.BeginForm(null, null, FormMethod.Post, new { @class = "Validate", @autocomplete = "off", @enctype = "multipart/form-data" }))
      {%>
    <div class="pageTitle">
     <ul class="buttons-panel">
        <li>
            <input type="submit" value="Update" />
        </li>
        <li>
            <%:Html.ActionLink("Cancel", "Index", new { controller = "BusOperator", area = "Bus" }, new { @class = "linkButton" })%>
        </li></ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Edit Bus Operator</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                    <%: Html.HiddenFor(model => model.BusMasterId)%>
                        <%: Html.LabelFor(model => model.BusMasterId)%>
                        <%: Html.TextBoxFor(model => model.BusMasterName)%>
                        <%: Html.ValidationMessageFor(model => model.BusMasterName, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <%: Html.LabelFor(model => model.ContactPerson)%>
                        <%: Html.TextBoxFor(model => model.ContactPerson)%>
                        <%: Html.ValidationMessageFor(model => model.ContactPerson)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%: Html.LabelFor(model => model.ContactAddress)%>
                        <%: Html.TextAreaFor(model => model.ContactAddress)%>
                         <%: Html.ValidationMessageFor(model => model.ContactAddress)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                         <%: Html.LabelFor(model => model.Phone)%>
                        <%: Html.TextBoxFor(model => model.Phone)%>
                         <%: Html.ValidationMessageFor(model => model.Phone)%>
                    </div>
                    <div>
                         <%: Html.LabelFor(model => model.Mobile)%>
                        <%: Html.TextBoxFor(model => model.Mobile)%>
                         <%: Html.ValidationMessageFor(model => model.Mobile)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                <input type="file" name="LogoImage" id="LogoImage" style="font-size: .9em;
                    padding: 0 4px;float:right;" onchange="readURL(this);" />
                </div>
                <div class="form-box1-row-content float-right"><div style="width:98%;text-align:center;">Orerator Logo</div>
                <div id="img" style="overflow: auto; max-height: 175px; min-height: 80px;text-align:center;">
                    <img id="peoImg" src="<%=Model.LogoUrl %>" width="70" height="70" alt="<%=Model.BusMasterName%>" />
                    </div></div></div>
        </div>
        <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <%Html.RenderPartial("Utility/VUC_Message",Model.Message); %></li>
               
            </ul>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#peoImg').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }
</script>
</asp:Content>

