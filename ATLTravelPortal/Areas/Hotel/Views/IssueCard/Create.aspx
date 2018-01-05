 <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.AgentCardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="box3">
        <div class="userinfo">
            <h3>
             Issue New Card To Agents
            </h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <input type="submit" value="Save" class="save"  />
                </li>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "IssueCard" }, new { @class="cancel"})%>
                    <%-- <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/AdminAirlineSalesCommissions/Index'" />--%>
                </li>
            </ul>
        </div>
    </div>


         <% Html.EnableClientValidation(); %>
         <%using (Ajax.BeginForm("Create", "IssueCard", new AjaxOptions()
                      {
                          UpdateTargetId = "Div_AgentCard",
                          OnBegin = "beginList", OnSuccess = "successList",
                          InsertionMode = InsertionMode.InsertBefore  
                      ,HttpMethod="Post"
                      }, new { @class = "validate" }))
              { %>


    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                       
                          <label><%: Html.LabelFor(model => model.AgentId) %></label>
                                 <%: Html.DropDownListFor(model => model.AgentId,Model.AgentList ,"--- Select ---")%>
                                 <%: Html.ValidationMessageFor(model => model.AgentId)%>
                    </div>
                </div>
            </div>
           <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                       
                          <label><%: Html.LabelFor(model => model.CardNumber) %></label>
                                 <%: Html.TextBoxFor(model => model.CardNumber)%>
                                 <%: Html.ValidationMessageFor(model => model.CardNumber)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                                <p class="mrg-lft-130"> 
                                <input type="submit" value="Add"  class="btn3" />
                                <%:Html.HiddenFor(model => model.HFCardId )%>  
                                </p>                        
           </div>     
      </div>
   </div>
 
   
                    
                  <%--  ---------------Region updating table---------------- --%>
 <div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"class="GridView" width="100%" id="myTable">
        <thead>
        <tr>
            <th>
            Card Number
            </th>
            <th>
            Card Value
            </th>
            <th>
             Card Type
            </th>
            <th>
            Valid Date
            </th>
            <th></th>
            </tr>
        </thead>

        <tbody  id="Div_AgentCard">
               <%Html.RenderPartial("CreatePartial",Model); %>      
       </tbody>
       </table>
 </div>

    <%} %>
 <div class="msgbox" style="border:0" id="loadingIndicator"></div>
     
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

//            $('a.edit').live("click", function (event) {
//                loadDialog(this, event, '#contentGrid');

//            });
//            $('a.new').live("click", function (event) {
//                loadDialog(this, event, '#contentGrid');

//            });
            $('a.Details').live("click", function (event) {
                loadDetailsDialog(this, event, '#contentGrid');

            });

        });
        /////////////////End of new fucntion/////////////////


    });   /* end document.ready() */    
    
    </script>

    <script type="text/javascript">
        function beginList(args) {
            // Animate
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/loadingAnimation.gif") %>" alt="" width="140px" height="100px" />   </center>');
        }

        function successList() {
            // Animate loadingAnimation
            $("#loadingIndicator").html('');
            $("#CardNumber").val('');

        }
                $(function () {
               $("#CardNumber").autocomplete({
                   source: function (request, response) {
                      $.ajax({
                          url: "/Hotel/AjaxRequest/FindCard", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                           success: function (data) {
                                response($.map(data, function (item) {
                                   return { label: item.CardNumber, value: item.CardNumber, id: item.CardId }
                              }))
                           }
                       })
                   },
                  width: 150,
                  select: function (event, ui) {
                      $("#HFCardId").val(ui.item.id);

                   }

            });
        });       
    </script>
</asp:Content>
