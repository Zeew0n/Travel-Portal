<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="font-size:small;"> <%:Html.ActionLink("Upload Photos", "UploadPhoto")%>  ||  <%:Html.ActionLink("Edit Photos", "Edit")%>  ||  <%:Html.ActionLink("Delete All Photos", "Delete")%> || <%:Html.ActionLink("List Photos","List") %></div>

    
      <%if (ViewData["success"] != null)
          { %>
             <%: ViewData["success"] %>    
        <%} %>
   

           <% Html.EnableClientValidation();%>    

     <% using (Html.BeginForm("Delete", "HotelPhoto", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>


     <fieldset> 
            
                 <div class="editor-label">
                        <%: Html.LabelFor(model => model.HotelName)%>
                 </div>

                 <div class="editor-field">
                    <%:Html.DropDownListFor(model => model.HotelName, new SelectList(Model.HotelNameList, "HotelId", "HotelName"))%>
                    <%: Html.ValidationMessageFor(model => model.HotelName)%>
                </div>
            
                   <div class="editor-label">                                                      
                            <label for="CategoryName">Choose Category to Delete</label>
                    </div>       

                    <div class="editor-field" id="CategoryName">

                    </div>
                <div style="float:right;">
                        <input type="submit" value="Delete" />
               </div>                 
            
        </fieldset>

        <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">



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

	                    $("#CategoryName").append("<input type='checkbox'  id='DeletedCheckedList' name='DeletedCheckedList'  value='" + optionData.PhotoCategoryId + "'>" + optionData.CategoryName);
	                });
	            });
	        }).change();
	    });
    </script>      

</asp:Content>
