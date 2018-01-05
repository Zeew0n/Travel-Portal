<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Issue Card:Agent</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  

 <div class="box3">
        <div class="userinfo">
            <h3>
               Issue Card </h3>
        </div>
        <div class="buttons-panel">
            <ul>
             
     <%=Html.ActionLink("New", "Create", new { Controller = "IssueCard" }, new { @class = "new" })%>
            
            <li><input type="submit" value="Show All" class="search"/></li>
            
            </ul>
        </div>
    </div>
     <% Html.EnableClientValidation(); %>
              <%using (Ajax.BeginForm("Index", "", new AjaxOptions()
                      {
                          UpdateTargetId = "ListPartial",
                          InsertionMode = InsertionMode.Replace
                      ,
                          HttpMethod = "Post"
                      }, new { @class = "validate" }))
                { %>
    <div id="ajaxResult"></div>
    <div class="contentGrid" id="result">
    
   <%  using (Html.BeginForm("Index", "IssueCard", FormMethod.Post,
    new { @autocomplete = "off" }))
       {%>
<%--
               <%  var sno = 0; 
            foreach (var item in Model)
           {
               sno++;
      var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
       %>
     <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
  
           
           
            <td>
              <%: Html.DropDownListFor(item.AgentId ,item.GetAllAgentList,"--- Select ---")%>
            </td>
            </tr>--%>

                <div class="row-1">           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                     <label><%: Html.LabelFor(model => model.AgentId)%></label>
                                    <%: Html.DropDownListFor(model => model.AgentId, Model.AgentList, "--- Select ---")%>
                                     <%: Html.ValidationMessageFor(model => model.AgentId)%>
                                </div>
                         </div> 
                      </div>     
                   </div>          
                          
                
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">                      
                          <input type="submit" value="Search" id="Search" class="btn3" />
                           <%:Html.HiddenFor(model => model.AgentId)%>  
                           
                        </p>                        
                    </div>                                                         
                </div>
       <div id="ListPartial">
                    <%Html.RenderPartial("ListPartial", Model); %>                   
                 </div>
                 </div> 
   <%}
                }%>
<%--     <div id="dialog" title="Basic dialog">
  <!-- loaded from ajax call -->
  <form id="exampleForm">
 <input blah>
        <input type="button" onclick="Save()" />
  </form>
</div>--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    
  
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        /////////////////////// POP UP Function //////////////////////////////////////
        $(function () {

            $('a.edit').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');

            });
//            $('a.new').live("click", function (event) {
//                loadDialog(this, event, '#contentGrid');

//            });
            $('a.Details').live("click", function (event) {
                loadDetailsDialog(this, event, '#contentGrid');

            });

        });
        /////////////////End of new fucntion/////////////////


    });   /* end document.ready() */    


//function loadDetailsDialog(tag, event, target) {
//        event.preventDefault();
//        var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
//        var $url = $(tag).attr('href');
//        var $title = $(tag).attr('title');
//        var $dialog = $('<div></div>');
//        $dialog.empty();
//        $dialog
//            .append($loading)
//            .load($url)
//		    .dialog({
//		        autoOpen: false
//			    , title: $title
//			    , width: 500
//                , modal: true
//			    , minHeight: 500
//                , show: 'slide'
//                , hide: 'slide'
//		    });

//        //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

//        $dialog.dialog('open');
//        };


//    function loadDialog(tag, event, target) {
//        event.preventDefault();
//        var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
//        var $url = $(tag).attr('href');
//        var $title = $(tag).attr('title');
//        var $dialog = $('<div></div>');
//        $dialog.empty();
//        $dialog
//            .append($loading)
//            .load($url)
//		    .dialog({
//		        autoOpen: false
//			    , title: $title
//			    , width: 500
//                , modal: true
//			    , minHeight: 300
//                , show: 'slide'
//                , hide: 'scale'
//		    });

//        //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

//        $dialog.dialog('open');
//    };



  $(function() {
      $('.myPop').click(function() { 
          $.get("editController/loadContents", function(data){
             $("#dialog").html(data);
           });           
          $("#dialog").dialog('open');
      });
  });


function Save(){
 $.post("/editController/Edit", $("#exampleForm").serialize(),
  function(data){
     $("#dialog").dialog('close');
    //update grid with ajax call
  });
}


      </script>
</asp:Content>
