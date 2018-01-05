<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.NewsModel>" %>

  <% Html.RenderPartial("~/Views/Shared/Utility/VUC_ActionResponse.ascx"); %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li><div id="loadingIndicator"></div></li>
            <li><input type="submit" value="<%: Model.formSubmitBttnName %>" class="save" /></li>
            <li><input type="button" value="Cancel" class="cancel" onclick="<%: Model.formCancelOnClick %>" /></li>
        </ul>
        <h3>
           <%-- <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Create News</strong>--%>
               <a href="#" class="icon_plane">News</a> <span>&nbsp;</span><strong>News</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left" style="width: 90%;">                    
                    <div>
                        <%: Html.LabelFor(model => model.Title)%>
                        <%: Html.TextBoxFor(model => model.Title)%>
                        <%: Html.ValidationMessageFor(model => model.Title)%>
                    </div>
                    <div>
                        <%: Html.LabelFor(model => model.URL)%>
                        <%: Html.TextBoxFor(model => model.URL, new { @style = "width :550px;" } )%>
                        <%: Html.ValidationMessageFor(model => model.URL)%>
                     </div>
                    <div>
                        <%: Html.LabelFor(model => model.Summary) %>
                        <%: Html.TextAreaFor(model => model.Summary, new { @cols = "110",@rows="5" })%>
                        <%: Html.ValidationMessageFor(model => model.Summary)%>
                    </div>                                       
                </div>                
                <div style="width: 90%;">                                                          
                    <div>
                        <%: Html.LabelFor(model => model.Description)%>
                        <%: Html.TextAreaFor(model => model.Description, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.Description)%>
                    </div>  
                      <div>
                        <%: Html.LabelFor(model => model.IsPublish)%>
                        <%: Html.CheckBoxFor(model => model.IsPublish)%>
                        <%: Html.ValidationMessageFor(model => model.IsPublish)%>
                    </div>               
                </div>
              
            </div>
        </div>
    </div>
   <%-- <div class="buttonBar">
        <input type="submit" value="<%: Model.formSubmitBttnName %>"/>
        <input type="button" value="Cancel" onclick="<%: Model.formCancelOnClick %>" />
    </div>--%>
<script type="text/javascript">
    $(document).ready(function () {
        $("input[id='Title']").keyup(function () {
            var valTitle = $(this).val();
            var valURL = valTitle.split(' ').join('-').toLowerCase();             
            $("input[id='URL']").val(valURL);
        });
    });
</script>

