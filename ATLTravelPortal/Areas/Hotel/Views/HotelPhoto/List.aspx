<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelPhotos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Hotel Photos List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  
    
    <div style="font-size:small;"> <%:Html.ActionLink("Upload Photos", "UploadPhoto")%>  ||  <%:Html.ActionLink("Edit Photos", "Edit")%>  ||  <%:Html.ActionLink("Delete All Photos", "Delete")%> || <%:Html.ActionLink("List Photos","List") %></div>


           <% Html.EnableClientValidation();%>    

     <% using (Html.BeginForm("List", "HotelPhoto", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
         {%>

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
                        
                        <input type="submit"  value="List Photos" />
                    </div>               
             </div>         
        </fieldset>

        <%} %>

    <% foreach (var item in Model.HotelPhotosList)               
       { 
           string PhotoPath ="~/HotelUploads/"+item.HotelId+"/"+item.PhotoCategoryId +"/" + item.Picture; 
           
           %>    
            <div id="links">
                    <a href="#">
                     <div class="img">   
                          <img src='<%= ResolveUrl(PhotoPath.Replace("_sm","_th")) %>'  width="110" height="90" alt="Travel Portal" />        
                        <div class="desc"><%=item.Title %></div>
                     </div>
                    
                    
                    <%#Eval("CountryId") %> 
                            <span>                                    
                                    <img src='<%= ResolveUrl(PhotoPath) %>'  width="500" height="500" alt="Travel Portal" />  
                                    <%=item.Details %>
                            </span>
                     </a>
                    
                </div>   
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
  width:auto;
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
  width:120px;
  margin:2px;
  }
  
  
   div#links { left: 0;   font: 14px Verdana, sans-serif; z-index: 100;}
   div#links a { text-align: center; font-size:10px; }
   div#links a:hover {color: #411; background: #AAA; border-right: 0px double white;}
   div#links a span {display: none;}
   div#links a:hover span 
                {display: block;
                position: absolute; top: 100px; left: 500px; width: 500px;
                padding: 10px; margin: 10px; z-index: 100;
                color: #000; background: #F2F8F9;
                border:2px solid #069;
                font: 10px Verdana, sans-serif; text-align: center;
                border: 2px solid #069;
                -moz-border-radius: 10px;
                -webkit-border-radius: 10px;
                border-radius: 10px;
                -moz-box-shadow: 6px 6px 6px #069;
                -webkit-box-shadow: 6px 6px 6px #069;
                box-shadow: 6px 6px 6px #069;
                }

    
    
    
  </style>
</asp:Content>
