<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SitePop.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelCityInfoAssociation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Hotel Google Map Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Hotel Google Map Edit</h2>
       
      <%if (ViewData["success"] != null)
          { %>
             <%: ViewData["success"] %>    
        <%} %>

            <% Html.EnableClientValidation();%>     
        
    
    <% using (Html.BeginForm("Edit", "HotelGoogleMap", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>
        <%: Html.ValidationSummary(true) %>

       <div class="buttons-panel">
            <ul>
            <li>
            <input type="submit" class="save" />
            </li>
                <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelGoogleMap" }, new { @class = "cancel" })%>
                </li>
                
            </ul>
        </div>
     <fieldset>
            
            
                 <div class="editor-label">
                        <%: Html.LabelFor(model => model.HotelId)%>
                 </div>

                 <div class="editor-field">
                      <%:Html.DropDownListFor(model => model.HotelId, new SelectList (Model.HotelNameList,"HotelId","HotelName"))%>
                    <%: Html.ValidationMessageFor(model => model.HotelId)%>
                </div>
             <div class="editor-label">
            <%: Html.LabelFor(model => model.CityId) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.CityId, new SelectList(Model.HotelCityInfoList,"CityId","CityName"))%>
            <%: Html.ValidationMessageFor(model => model.CityId)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Longitude) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Longitude)%>
            <%: Html.ValidationMessageFor(model => model.Longitude)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Latitude ) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Latitude)%>
            <%: Html.ValidationMessageFor(model => model.Latitude)%>
        </div>
          <%--  <div class="editor-field" id="Textboxarea">
                
            </div>--%>
                   
        </fieldset>

        <%} %>
       
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">

	<script type="text/javascript">
	    $(document).ready(function () {
	        //Hook onto the HotelName list's onchange event
	        $("#HotelId").change(function () {
	            //build the request url
	            var url = "/Hotel/AjaxRequest/GetHotelCityInfo";
	            //fire off the request, passing it the id which is the HotelName's selected item value
	            $.getJSON(url, { id: $("#HotelId").val() }, function (data) {
	                //Clear the Roomtype list
	                //	                $("#CityId").empty();
	                $("#Textboxarea").empty();
	                //Foreach Roomtype in the list, add a Roomtype option from the data returned
	                $.each(data, function (index, optionData) {
	                    //	                    $("#CityId").append("<option value='" + optionData.CityId + "'>" + optionData.HotelCityInfoName + "</option>");

	                    $("#Textboxarea").append("<label>" + optionData.HotelCityInfoName + " ==>Latitude ==>Longitude</label>");

	                    $("#Textboxarea").append("<input type='hidden' name='DetailsList.index' value='" + optionData.CityId + "'>" +
                        "<input type='text' name='DetailsList[" + optionData.CityId + "].Latitude' id='DetailsList[" + optionData.CityId + "].Latitude'>" +
                        "<input type='text' name='DetailsList[" + optionData.CityId + "].Longitude' id='DetailsList[" + optionData.CityId + "].Longitude'>");
	                    $("#Textboxarea").append("<input type='hidden' name='DetailsList[" + optionData.CityId + "].HiddenCityId' value='" + optionData.CityId + "'>");
	                    $("#Textboxarea").append("<input type='hidden' name='DetailsList[" + optionData.CityId + "].HiddenHotelId' value='" + optionData.HotelId + "'>");
	                });
	            });
	        }).change();
	    });
    </script>  
</asp:Content>
