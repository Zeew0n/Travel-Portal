<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="font-size:small;"> <%:Html.ActionLink("Upload Photos", "UploadPhoto")%>  ||  <%:Html.ActionLink("Edit Photos", "Edit")%>  ||  <%:Html.ActionLink("Delete All Photos", "Delete")%> || <%:Html.ActionLink("List Photos","List") %></div>

      <%if (ViewData["success"] != null)
          { %>
             <%: ViewData["success"] %>    
        <%} %>
   
      <% Html.EnableClientValidation();%>    
    <% using (Html.BeginForm("Edit", "HotelPhoto", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>


        <div style="float:right;"><input type="submit" id="btnSave" value="Save Changes" /></div>
     <fieldset>
            <div class="divLeft">   
            
                 <div class="editor-label">
                        <%: Html.LabelFor(model => model.HotelName)%>
                 </div>

                 <div class="editor-field">
                    <%:Html.DropDownListFor(model => model.HotelName, new SelectList(Model.HotelNameList, "HotelId", "HotelName"))%>
                    <%: Html.ValidationMessageFor(model => model.HotelName)%>
                </div>
             </div>

             <div class="divRight">

                   <div class="editor-label">
                            <%: Html.LabelFor(model => model.CategoryName)%>
                     </div>

                   <div class="editor-field">
                        <%:Html.DropDownListFor(model => model.CategoryName, new SelectList(Model.PhotoCategoryList, "PhotoCategoryId", "CategoryName"))%>
                        <%: Html.ValidationMessageFor(model => model.CategoryName)%>
                        
                        <input type="button" value="List Photos" id="ListPhotos" />
                      
                    </div>               
             </div>         
        </fieldset>

       
        
      <% foreach (var item in Model.HotelPhotosList)
         {
             string PhotoPath = "~/HotelUploads/" + item.HotelId + "/" + item.PhotoCategoryId + "/" + item.Picture; 
             
             %>    
                     <div class="img">        
                        <img src='<%= ResolveUrl(PhotoPath.Replace("_sm","_th")) %>'  width="110" height="90" alt="Travel Portal" />   
                                               
                        <div class="desc">
                                <input type="hidden" name="DetailsList.index" value="<%=item.PhotoId %>" />
                                <%:Html.Encode("Title")%> <input type="text" name="DetailsList[<%=item.PhotoId %>].Title" id="DetailsList[<%=item.PhotoId %>].Title" value='<%=item.Title %>' />
                         </div>                        

                        <div class="desc">
                                <%:Html.Encode("Details")%>                                
                                <textarea id="DetailsList[<%=item.PhotoId %>].Details" name="DetailsList[<%=item.PhotoId %>].Details" rows="3" cols="10" ><%=item.Details%></textarea>                               
                                 <input type="hidden" name="DetailsList[<%=item.PhotoId %>].PhotoId" id="DetailsList[<%=item.PhotoId %>].PhotoId" value='<%=item.PhotoId %>' />
                                 <input type="hidden" name="DetailsList[<%=item.PhotoId %>].HiddenPictureName" id="DetailsList[<%=item.PhotoId %>].HiddenPictureName" value='<%=item.Picture %>' />
                                 <input type="hidden" name="DetailsList[<%=item.PhotoId %>].HiddenPicturePath" id="DetailsList[<%=item.PhotoId %>].HiddenPicturePath" value='<%=PhotoPath%>' />
                                 <input type="hidden" name="DetailsList[<%=item.PhotoId %>].CategoryName" id="DetailsList[<%=item.PhotoId %>].CategoryName" value='<%=item.PhotoCategoryId %>' />
                                 <input type="hidden" name="DetailsList[<%=item.PhotoId %>].HotelId" id="DetailsList[<%=item.PhotoId %>].HotelId" value='<%=item.HotelId %>' />
                        </div>            
                        <div class="desc">
                                <input type="checkbox" id="DeletedCheckedList" name="DeletedCheckedList"  value="<%=item.PhotoId %>" /> Delete This Photo
                        </div>
                     </div>     
    <% } %>

    <% } %>

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
	                    $("#CategoryName").append("<option value='" + optionData.PhotoCategoryId + "'>" + optionData.CategoryName + "</option>");
	                });
	            });
	        }).change();
	    });
    </script>    
      


     
    <style type="text/css">
            div.img
              {
              margin:5px;
              border:1px solid #0000ff;
              height:auto;
              width:220px;
              float:left;
              text-align:center;
              }
            div.img img
              {
              display:inline;
              margin:10px;
              border:1px solid #ffffff;
              }
            div.img a:hover img
              {
              border:0px solid #0000ff;
              }
            div.desc
              {
              text-align:center;
              font-weight:normal;
              width:210px;
              font:8pt "tahoma",Arial;
              margin:2px;
              }  
     </style>

</asp:Content>
