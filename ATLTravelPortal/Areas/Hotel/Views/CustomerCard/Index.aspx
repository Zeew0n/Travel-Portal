<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box3">
        <div class="userinfo">
            <h3>
               Customer Card </h3>
        </div>
        <div class="buttons-panel">
            <ul>
            
                <li>
                    <input type="submit" value="Save" class="save"  />
                </li>
              
            
    
            
            <li><input type="submit" value="Show All" class="search"/></li>
            
            </ul>
        </div>
    </div>
    
               <%  using (Html.BeginForm("Index", "CustomerCard", FormMethod.Post,
    new { @autocomplete = "off" }))
                   {%>

                <div class="row-1">           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                     <label><%: Html.LabelFor(model => model.AgentId) %></label>
                                    <%: Html.DropDownListFor(model => model.AgentId,Model.AgentList , "--- Select ---")%>
                                     <%: Html.ValidationMessageFor(model => model.AgentId)%>
                                </div>
                         </div> 
                      </div>     
                   </div>          
                          
                
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">                      
                          <input type="submit" value="Search" id="Search" class="btn3" />

                        </p>                        
                    </div>                                                         
                </div>
     
   <%} %>
     <div>
                    <%Html.RenderPartial("ListPartial",Model ); %>                   
                 </div>
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
  <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        /////////////////////// POP UP Function //////////////////////////////////////
        $(function () {

            $('a.edit').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');

            });
            $('a.new').live("click", function (event) {
                loadDialog(this, event, '#contentGrid');

            });
            $('a.Details').live("click", function (event) {
                loadDetailsDialog(this, event, '#contentGrid');

            });

        });
        /////////////////End of new fucntion/////////////////


    });   /* end document.ready() */    

    $(function () {
        $('.myPop').click(function () {
            $.get("editController/loadContents", function (data) {
                $("#dialog").html(data);
            });
            $("#dialog").dialog('open');
        });
    });


    function Save() {
        $.post("/editController/Edit", $("#exampleForm").serialize(),
  function (data) {
      $("#dialog").dialog('close');
      //update grid with ajax call
  });
    }


      </script>
</asp:Content>
