<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.RolePrivilageModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Priviledge Setup
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div class="pageTitle">
        <div class="float-right">
            	<ul>
               
                     <li><%:Html.ActionLink("New", "Create", new { controller = "PriviledgeSetup" }, new { @class = "linkButton"})%></li>
                   
                </ul>
            </div>
        <h3>
            <a href="#">User Management</a> <span>&nbsp;</span><strong>Privilege Setup</strong>
        </h3>
    </div>



   <%  using (Html.BeginForm(ViewContext.RouteData.Values["Action"].ToString()
           , ViewContext.RouteData.Values["Controller"].ToString()
           , FormMethod.Post,
    new { @id = "ATForm", @autocomplete = "off" }))
         {%>
         <div class="form-box1-row">
               <div class="form-box1-row-content float-left">
                    <div><label>Project/Module</label> <%: Html.DropDownListFor(m => m.ProductId, Model.ProductList, "------ Select -------")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><label>Sub-Project/Sub-Module</label><%: Html.DropDownListFor(m => m.SubProductId, Model.SubProductList, "------ Select -------")%>
                    </div>
                </div>
        </div>
    
    
  <% } %>
   
   <div id="contentFormUpdatePanel">
       <%: Html.Partial("VUC_PriviledgeList")%>
   </div>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
     <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>

<script type="text/javascript">

    ddaccordion.init({ //top level headers initialization
        headerclass: "ui-accordion-header", //Shared CSS class name of headers group that are expandable
        contentclass: "ui-accordion-content", //Shared CSS class name of contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [0], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        persiststate: true, //persist state of opened contents within browser session?
        toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["prefix", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    });


    ddaccordion.init({ //2nd level headers initialization
        headerclass: "ui-accordion-Main-header", //Shared CSS class name of sub headers group that are expandable
        contentclass: "ui-accordion-Main-content", //Shared CSS class name of sub contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click" or "mouseover
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
        defaultexpanded: [], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        persiststate: true, //persist state of opened contents within browser session?
        toggleclass: ["opensubheader", "closedsubheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["none", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    })
    $(function () {
        $("#SubProductId").change(function () {
            $('#ATForm').submit();
        });
    });
    $(document).ready(function () {
        $("#ProductId").change(function () {
            id = $("#ProductId").val();
            if (id == "") {
                $("#SubProductId").empty();
                $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                //build the request url
                var url = "/Administrator/AjaxRequest/GetSubGroupNameProductId";
                //fire off the request, passing it the id which is the MakeID's selected item value
                $.getJSON(url, { id: id }, function (data) {
                    //Clear the Model list
                    $("#SubProductId").empty();
                    $("#SubProductId").append("<option value=''>" + "-- Select--" + "</option>");
                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {

                        $("#SubProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
    });
</script>

</asp:Content>