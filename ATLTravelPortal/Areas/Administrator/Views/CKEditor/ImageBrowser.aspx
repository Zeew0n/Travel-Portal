<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CKEditorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ImageBrowser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <h2>Image Browser</h2>    

       <form id="ATFormImgBroswer" action="" name="ATFormImgBroswer" onsubmit="return false;" enctype="multipart/form-data">
          <div class="contentGrid">
          <table width="720px" class="GridView" cellpadding="10" cellspacing="0" border="1" >
          <tr>
            <th style="width: 324px;" valign="top">Folders</th>
              <th>Image Preview</th>
        </tr>
        <tr>
        <td style="width: 324px;" valign="top">
        	Folders:<br />

            <%:Html.DropDownListFor(x => x.DirectoryList, Model.ddlDirectoryList, new { @onchange = "SelectFolder(this,'ImageList','/CKEditor/GetSelectListImage/');" })%>
          <%--  <%:MvcHtmlString.Create(Html.Button("DeleteDirectoryButton", "Delete", "return DeleteFolder(this.form,'DirectoryList');"))%>--%>
           <button id="DeleteDirectoryButton" name="DeleteDirectoryButton" onclick="return DeleteFolder(this.form,'DirectoryList');">Delete</button>
            <%:Html.HiddenFor(x => x.NewDirectoryName)%>
             <button id="NewDirectoryButton" name="NewDirectoryButton" onclick="return CreateFolder(this.form);">New</button>
          
           <br /><br />

           <div>
           <%:Html.TextBoxFor(x => x.SearchTerms)%>
            <button id="SearchButton" name="SearchButton" onclick="return SearchImage(this.form)">Search</button>
           </div>
           <%:Html.DropDownListFor(x => x.ImageList, Model.ddlImageList, new { @size = "4", @onchange = "SelectImage(this,'DirectoryList','ImagePreview')", @style = "width: 280px; height: 180px;" })%>

           <%: @Html.HiddenFor(x => x.NewImageName)%>
           <%: @Html.HiddenFor(x => x.ImageHttpPath)%>
           
            <button id="RenameImageButton" name="RenameImageButton" onclick="return RenameImage(this.form,'ImageList');">Rename</button>
            <button id="DeleteImageButton" name="DeleteImageButton" onclick="return DeleteImage(this.form,'ImageList');">Delete</button>
           <br />
					<br />
					Resize:<br />
                    <%:Html.TextBoxFor(x => x.ResizeWidth, new { @style = "width:50px;" })%>
                    x
                    <%:Html.TextBoxFor(x => x.ResizeHeight, new { @style = "width:50px;" })%>
                    <%:Html.HiddenFor(x => x.ImageAspectRatio)%>
                     <button id="ResizeImageButton" name="ResizeImageButton" onclick="return ResizeImage(this.form)">Resize Image</button><br />
                    <%:Html.Label("ResizeMessage")%>
                    <br /><br />
					Upload Image: (10 MB max)
                    <br />
                     <input type="file" id="UploadedImageFile" name="UploadedImageFile" />
                     <input type="button" onclick="UploadImage(this.form);" value="Upload" id="UploadButton" name="UploadButton">
                     <br />
        </td>
         <td style="width: 396px;" valign="middle" align="center">
                <div style="width: 396px;  height:400px; overflow:scroll;" id="ImagePreview"></div>
				</td>
        </tr>
          </table>
          <center>
           <button id="OkButton" name="OkButton" onclick="return SubmitSelectedImage();">Ok</button>
          <button id="CancelButton" name="CancelButton" onclick="return window.top.close(); window.top.opener.focus();">Cancel</button>
          </center>
          </div>

     </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script>
    var ImageFolderRoot = "<%:Model.ImageFolderRoot%>";
</script>
<script src="/Scripts/json.cycle.js" type="text/javascript"></script>    
<script src="/Scripts/CKEditorHelper.js" type="text/javascript"></script>

</asp:Content>
