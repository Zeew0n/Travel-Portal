<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PNRManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit PNR</h2>

        <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Index", "PNRManagement", new AjaxOptions()
                      {
                          UpdateTargetId = "ResultPlaceHolder",
                          OnBegin = "beginList",
                          OnSuccess = "successList",
                          InsertionMode = InsertionMode.Replace,
                          HttpMethod = "Post",

                      }))
      { %>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <h3>
            <a href="#" class="icon_plane">Report</a> <span>&nbsp;</span><strong>Retrieve PNR Status</strong>
        </h3>
    </div>
    <div class="reportFilter">
        <div class="reportLeftDiv">
            <div class="divLeft">
                <label>
                    GDS PNR
                </label>
                <%: Html.TextBoxFor(x => x.GDSPNR)%>
                <%: Html.ValidationMessageFor(x => x.GDSPNR)%>
                <label id="lblloading">
                </label>
            </div>
        </div>
        <div class="buttonBar  reportLeftDiv ">
            <input class="float-right" type="submit" value="Search" name="Search" />
        </div>
    </div>
    <%} %>
    
    <div class="clearboth"></div>
    <br />
 
    <div id="ResultPlaceHolder">
        <%Html.RenderPartial("VUC_PNREditPartial",Model); %>
    </div>
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   <script type="text/javascript" language="javascript">
       /* ---------------------------------------------------- Loader Animation begin here ----------------------------------------*/

       

       function beginList(args) {
           // Animate
           $("#ResultPlaceHolder").empty();
           $("#lblloading").html('<img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />');

       }
       function successList() {
           $("#lblloading").html('');
       }


        $().ready(function () {

       $(function () {
           $('.ArriveCityName').live('keydown.autocomplete', function () {
               var sectorcount = this.id.match(/\d/);

               $(this).autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "/Airline/AjaxRequest/GetCityList", type: "POST", dataType: "json",
                           data: { searchText: request.term, maxResults: 10 },
                           success: function (data) {
                               response($.map(data, function (item) {
                                   return { label: item.CityName, value: item.CityName, id: item.CityID, cityCode: item.CityCode }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, error) {//302
                               location.reload();
                             
                           }
                       });
                   },
                   width: 150,
                   select: function (event, ui) {


                   }
               });
           });
       });


       $(function () {
           $('.DepartCityName').live('keydown.autocomplete', function () {
               var sectorcount = this.id.match(/\d/);

               $(this).autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           url: "/Airline/AjaxRequest/GetCityList", type: "POST", dataType: "json",
                           data: { searchText: request.term, maxResults: 10 },
                           success: function (data) {
                               response($.map(data, function (item) {
                                   return { label: item.CityName, value: item.CityName, id: item.CityID, cityCode: item.CityCode }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, error) {//302
                               location.reload();
                              
                           }
                       });
                   },
                   width: 150,
                   select: function (event, ui) {


                   }
               });
           });
       });

   });
    

       
       
       
       
          
    </script>
</asp:Content>
