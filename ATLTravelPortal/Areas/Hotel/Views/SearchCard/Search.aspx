<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                    <%
     if (ViewData["success"] != null)
     { %>
       <%: ViewData["success"] %>
         <%    
      }
      %>
    
    <div class="box3">
        <div class="userinfo">
            <h3>
             Search Card
            </h3>
        </div>
             <% Html.EnableClientValidation(); %>
      
               <%  using (Html.BeginForm("Search", "SearchCard", FormMethod.Post, 
    new {  @autocomplete = "off" }))
    {%>
        <div class="buttons-panel">
            <ul>
            <li>
                    <input type="submit" value="Save" class="save"  />
                </li>
                
                <li>
                 
                    <%:Html.ActionLink("Cancel", "Search", new { controller = "SearchCard" }, new { @class = "cancel" })%>
                    <%-- <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/AdminAirlineSalesCommissions/Index'" />--%>
                </li>
            </ul>
        </div>
    </div>

    


    <div class="row-1">
        <div class="form-box1 round-corner">
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
                               
                                <input type="submit" value="Search" id="Search" class="btn3" />
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
            Card Type
            </th>
            <th>
             Card Value
            </th>
            <th>
            Valid Date
            </th>
            <th>CardStatus</th>
              <th><center>Actions</center></th>
            </tr>
        </thead>
      
       <%Html.RenderPartial("ListPartial",Model); %> 
       
       </table>
 </div>

    <%} %>
  
      <div  id="ListPartial">
                   
       </div>
      
 <div class="msgbox" style="border:0" id="loadingIndicator"></div>
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
   
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
           
                $("#ValidTill").val('');
                $("#CardValue").val(' ');
              
            });




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

                        url: "/Hotel/AjaxRequest/FindCards", type: "POST", dataType: "json", 
                        
                        data: { searchText: request.term,  maxResult: 5 },

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
            return false;
        });       
    </script>
</asp:Content>

