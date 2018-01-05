<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ConfigureAccountModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <%using (Html.BeginForm("Index", "ConfigureAccount",FormMethod.Post, new { @class = "validate" }))
      { %>
  
      <div class="pageTitle">
        
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Configure Account</strong>
        </h3>
    </div>

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%:Html.Label("Product")%>
                        </label>
                        <%:Html.DropDownListFor(model => model.ProductId, (SelectList)ViewData["Products"], "---Select---")%><label class="redtxt" id="loadingIndicator"></label>

                    </div>
                </div>
            </div>
            
            <div id ="ListTable">
            <%Html.RenderPartial("ListPartial"); %>
           
            </div>
            <%:Html.HiddenFor(model => model.KeyValue)%>
            
           <%-- <input type="submit" value="Save" />--%>
           
        </div>
         <div class="buttonBar">         
                <%--<%:Html.ActionLink(" ","Index",new{keyValue=Model.KeyValue}) %>--%>
                    <input type="submit" value="Save" class="save" />
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        $('.validate').validate();
        $(".save").click(function () {
            var check = $("#ProductId").val();
            var dictionary = $("#KeyValue").val();

            if (check == null || check == "" || dictionary == null || dictionary == "") {
                return false;
            }
            
        }); //End of save click
    });
    $(function () {
        $("#ProductId").change(function () {
            var id = $("#ProductId").val();
            $("#MappedLedgerId").val(id);
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
            $.ajax({
                type: "GET",
                url: "ConfigureAccount/Index",
                data: "productId=" + id,
                dataType: "html",
                success: function (result) {
                    $("#loadingIndicator").html(' ');
                    $("#ListTable").empty().append(result);
                }
            });

        });

    });
    ////////////////////////End of ProductId Change /////////////////////////////////
    
</script>


             
</asp:Content>
