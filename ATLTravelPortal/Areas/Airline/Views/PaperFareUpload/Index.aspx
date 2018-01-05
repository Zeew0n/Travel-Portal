<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Upload Paper Fare
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
             <a href="#" class="new linkButton" onclick="jQuery('#dialog').dialog('open'); return false">Upload New File</a>
            </li>
         
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Upload Paper Fare</strong>
        </h3>
    </div>
   
    <div id="dialog" title="Upload Files">
        <% using (Html.BeginForm("Upload", "PaperFareUpload", FormMethod.Post, new {@class = "validate", enctype = "multipart/form-data" }))
           {%>
           <p>File Name:<input type="text" name="AirlineName" id="AirlineName" class="required"/> </p>
            <p><input type="file" id="fileUpload" name="fileUpload" size="23"/> </p>
            <p><input type="submit" value="Upload File" /></p>
        <% } %>
    </div>
    
             <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
        <tr>
            <th>S.No.</th>
            <th>File Name</th>
            <th>View/Download</th>
            <th> Uploaded Date</th>
            <th>Size</th>  
            <th>Delete</th> 
            </tr>        
        </thead>

       
     <% var sno = 0;

        foreach (var item in Model)
        {
            string fileType = System.IO.Path.GetExtension(item.Name);
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

       <tbody >
         <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'"> 
         <td><%:sno%></td> 
         <%string[] words = item.Name.Split('.'); %>         
            <td><%:words[0]%></td>
            <td style="vertical-align:middle">
               <%string FileName = Html.Encode(item.WebPath);%>
                <% =Html.ActionLink(FileName, "DownloadFile", new { @id = item.WebPath })%>
            </td>
           <td style="vertical-align:middle">
               <%= Html.Encode(item.DateCreated.ToString()) %>
            </td>
            <td style="vertical-align:middle">
                <%= Html.Encode(item.Size) + " KB" %>
            </td>
             <td>
              <% =Html.ActionLink("Delete", "DeleteFile", new { @id = item.WebPath},new{@class="delete", title="Delete", @onclick = "return confirm('Do you really want to Delete this file  ?')" })%></td>
        </tr> 

        </tbody>
        <%}
             %>
    </table>

  </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
<script type="text/javascript">
  $(document).ready(function () {
            $('.validate').validate();
        });
    $(function () {
        $("#dialog").dialog({
            bgiframe: true,
            height: 140,
            modal: true,
            autoOpen: false,
            resizable: false
        })
    });
    
    </script>
</asp:Content>
