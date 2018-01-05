<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UploadPhoto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
        <%if (ViewData["success"] != null)
          { %>
             <%: ViewData["success"] %>    

        <%} %>
 
 
 <div style="font-size:small;"> <%:Html.ActionLink("Uplad Photos", "UploadPhoto")%>  ||  <%:Html.ActionLink("Edit Photos", "Edit")%>  ||  <%:Html.ActionLink("Delete All Photos", "Delete")%> || <%:Html.ActionLink("List Photos","List") %></div>  
     <% Html.EnableClientValidation();%>     

        
    <% using (Html.BeginForm("UploadPhoto", "HotelPhoto", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>


     <fieldset>
            <legend>Upload Photos</legend>
            
             <div class="editor-label">
                    <%: Html.LabelFor(model => model.HotelName)%>
             </div>

            <div class="editor-field">
                <%:Html.DropDownListFor(model => model.HotelName, new SelectList(Model.HotelNameList, "HotelId", "HotelName"))%>
                <%: Html.ValidationMessageFor(model => model.HotelName)%>
            </div>
               
           <div class="editor-label">
                    <%: Html.LabelFor(model => model.CategoryName)%>
             </div>

            <div class="editor-field">
              <%:Html.DropDownListFor(model => model.CategoryName, new SelectList(Model.PhotoCategoryList, "PhotoCategoryId", "CategoryName"))%>
                <%: Html.ValidationMessageFor(model => model.CategoryName)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Picture)%>
            </div>
       
            <div class="editor-field">
               <input type="file" id="Picture[0]" name="Picture[0]" />               
            </div>
            <div class="editor-label">
               
            </div>
            <div class="editor-field">
               <input type="file" id="Picture[1]" name="Picture[1]" />               
            </div>
            <div class="editor-label">
               
            </div>
            <div class="editor-field">
               <input type="file" id="Picture[2]" name="Picture[2]" />               
            </div>
            <div class="editor-label">
               
            </div>
            <div class="editor-field">
               <input type="file" id="Picture[3]" name="Picture[3]" />               
            </div>
            <div class="editor-label">
               
            </div>
            <div class="editor-field">
               <input type="file" id="Picture[4]" name="Picture[4]" />               
            </div>
            
            
             <div class="editor-label"> <label></label></div>
            <div class="editor-field">
               
                <input type="submit" value="Submit" />
                <input type="button" value="Cancel" />
            </div>
           
        </fieldset>

        <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>

	<script type="text/javascript">
	    $(document).ready(function () {
	        //Hook onto the HotelName list's onchange event
	        $("#HotelName").change(function () {
	            //build the request url
	            var url = "/Hotel/AjaxRequest/GetHotelPhotoCategory";
	            //fire off the request, passing it the id which is the HotelName's selected item value
	            $.getJSON(url, { id: $("#HotelName").val() }, function (data) {
	                //Clear the Roomtype list
	                $("#CategoryName").empty();
	                //Foreach Roomtype in the list, add a Roomtype option from the data returned
	                $.each(data, function (index, optionData) {
	                    $("#CategoryName").append("<option value='" + optionData.PhotoCategoryId + "'>" + optionData.CategoryName + "</option>");
	                });
	            });
	        }).change();
	    });
	</script>

</asp:Content>
