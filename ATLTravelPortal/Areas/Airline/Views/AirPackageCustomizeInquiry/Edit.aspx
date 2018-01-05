<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageInquiryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("~/Views/Shared/Utility/VUC_ActionResponse.ascx"); %>
    <%using (Html.BeginForm("", "", FormMethod.Post, new { @class = "autoCompleteForm" }))
      { %>
        <%=Html.ValidationSummary(true)%>
        <% Html.RenderPartial("VUC_Add"); %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="/Content/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //var oCKeditor = new $('#OverView').ckeditor();            

            $("input[id$='Name']").keyup(function () {
                var valTitle = $(this).val();
                var valURL = valTitle.split(' ').join('-');
                $("input[id$='URL']").val(valURL);
            });


        });
    
    </script>
</asp:Content>
