<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TrainMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%:Html.Partial("Utility/VUC_Message", Model.Message)%>
    <div class="row-1">
        <div class="pageTitle">
        <div class="float-right">
         
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/'" value="Back To List" />
                   
            </div>
           <%-- <ul class="buttons-panel">
                <%if (Model.TicketStatusId == 1)
                  { %>
              
                    <ul class="buttons-panel">
                        <li>
                            <input type="button" onclick="document.location.href='/Train/BookingRequest/Edit/<%=Model.TrainPNRId %>'"
                                value="Update" />
                            <input type="button" onclick="Process(<%=Model.TrainPNRId %>)" value="InProcess" />
                       
                        </li>
                    </ul>
                
                <%} %>
                <%if (Model.TicketStatusId == 7)
                  {%>
               
                    <ul class="buttons-panel">
                        <li>
                            <input type="button" onclick="document.location.href='/Train/BookingRequest/Book/<%=Model.TrainPNRId %>'"
                                value="Book" />
                            <input type="button" onclick="Cancel(<%=Model.TrainPNRId %>)" value="Decline" />
                        </li>
                    </ul>
                
                <%} %>
               
                <%if (Model.TicketStatusId == 1)
                  { %>   
                <li>
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/'" value="Back To List" />
                    </li>
                 
                <%} %>

                <%if (Model.TicketStatusId == 2)
                  { %>                    
                <li>
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/Canceled'" value="Back To List" /> </li>
                <%} %>

                <%if (Model.TicketStatusId == 3)
                  { %>     
                <li>
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/Issued'" value="Back To List" />                </li>
               
                <%} %>
                <%if (Model.TicketStatusId == 7)
                  { %>                  
                <li>
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/Process'" value="Back To List" />
                </li>                
                <%} %>
            </ul>  --%>
            <%if (Model.TicketStatusId == 1)
                  { %> 
                 <h3><a class="icon_plane" href="#">Booking Request</a> <span>&nbsp;</span><strong>Details</strong></h3>              
                <%} %>

                <%if (Model.TicketStatusId == 2)
                  { %>
                 <h3><a class="icon_plane" href="#">Cancel Request</a> <span>&nbsp;</span><strong>Details</strong></h3>              
                <%} %>


                <%if (Model.TicketStatusId == 3)
                  { %>  
                 <h3><a class="icon_plane" href="#">Issued Request</a> <span>&nbsp;</span><strong>Details</strong></h3>              

                <%} %>
                <%if (Model.TicketStatusId == 7)
                  { %> 
                 <h3><a class="icon_plane" href="#">In Process Request</a> <span>&nbsp;</span><strong>Details</strong></h3>                
                <%} %>          
        </div>
        <div class="row-1 mrg-top-20">
            <h3>
                Agent Detail
            </h3>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.AgentName)%></strong><%:Model.AgentName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.AgentCode)%></strong><%:Model.AgentCode%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.AgentAddress)%></strong><%:Model.AgentAddress%>
                        </div>
                        <div><strong>
                             <%:Html.LabelFor(m => m.AgentEmial)%></strong><%:Model.AgentEmial%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.AgentPhone)%></strong><%:Model.AgentPhone%>
                        </div>
                    </div>
                </div>
                

            </div>
        </div>
        <div class="row-1 mrg-top-20">
            <h3>
                Traveller Information
            </h3>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.FromStationId)%></strong><%:Model.FromStationName%>
                             <%:Html.HiddenFor(m => m.FromStationId)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.ToStationId)%></strong><%:Model.ToStationName%>                        
                             <%:Html.HiddenFor(m => m.ToStationId)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m=>m.TrainClassId) %></strong><%:Model.TrainClassName %>
                             <%:Html.HiddenFor(m=>m.TrainClassId) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                            <%:Html.LabelFor(m => m.DepartureDate)%></strong><%:Model.DepartureDate.ToShortDateString()%>
                             <%:Html.HiddenFor(m => m.DepartureDate)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                            <%:Html.LabelFor(m=>m.ArrivalDate) %></strong><%:Model.ArrivalDate.Value.ToShortDateString() %>
                            <%:Html.HiddenFor(m=>m.ArrivalDate) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                        <%:Html.LabelFor(m=>m.DepartureTime) %></strong><%:Model.DepartureTime %>
                        <%:Html.HiddenFor(m=>m.DepartureTime) %>                           
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                           <%:Html.LabelFor(m=>m.ArrivalTime) %></strong><%:Model.ArrivalTime %>
                           <%:Html.HiddenFor(m=>m.ArrivalTime) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                               <%:Html.LabelFor(m => m.NoOfAdult)%></strong><%:Model.NoOfAdult%>
                             <%:Html.HiddenFor(m => m.NoOfAdult)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                                <%:Html.LabelFor(m => m.NoOfSM)%></strong><%:Model.NoOfSM%>
                             <%:Html.HiddenFor(m => m.NoOfSM)%>
                        </div>
                    </div>
                     <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.NoOfSF)%></strong><%:Model.NoOfSF%>
                             <%:Html.HiddenFor(m => m.NoOfSF)%>  
                        </div>
                    </div>
                </div>
                 <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                               <%:Html.LabelFor(m => m.NoOfChild)%></strong><%:Model.NoOfChild%>
                             <%:Html.HiddenFor(m => m.NoOfChild)%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

         <div style="margin-bottom: 1%;">
            <h3 class="headingTlt2">
                Fare Detail</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                <%double fare = 0; %>
                    <%foreach (var item in Model.Passengers)
                      {
                          fare += item.Fare;
                          %>
                             
                            <div><%=(item.PassengerType) %>:<strong> <%:item.Fare %></strong></div>
                    <%} %>
                   
                    <div>
                   <label> <strong>Total:<%=fare %></strong></label></div>
                      <div><label>IRCTCS Charge:</label><strong><%:Model.IRCTCSCharge %></strong></div>
                      <div><label>Agent Charge:</label><strong><%:Model.AgentCharge %></strong></div>
                      <div><u><label>AH Charge:</label><strong><%:Model.AHMarkUp %></strong></u></div>
                      <div><label>Grand Total:</label><strong><%=fare+Model.IRCTCSCharge+Model.AgentCharge+Model.AHMarkUp %></strong> </div>
                </div>
                </div>
            </div>


        <div class="row-1 mrg-top-20">
            <h3>
                PNR Address
            </h3>
            <%--div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Prefix)%></strong>
                         <%:Model.Prefix%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.FullName)%></strong>
                         <%:Model.FullName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Gender)%></strong>
                         <%:Model.Gender%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Nationality)%></strong>
                         <%:Model.Nationality%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Age)%></strong>
                         <%:Model.Age%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.IDTypeId)%></strong>
                         <%:Model.IDTypeName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.IDNumber)%></strong>
                         <%:Model.IDNumber%>
                    </div>
                </div>
            </div>--%>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.PhoneNumber)%></strong>
                         <%:Model.PhoneNumber%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.MobileNumber)%></strong>
                         <%:Model.MobileNumber%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.ContactAddress)%></strong>
                         <%:Model.ContactAddress%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.EmailAddress)%></strong>
                         <%:Model.EmailAddress%>
                    </div>
                </div>
            </div>
        </div>
        <% int i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Adult"))
           {
               i++; %>
        <div class="row-1 mrg-top-20">
            <h3>
                Adult Passenger (<%=i%>)</h3>
            <div class="form-box4">               
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].FullName)%></strong>
                             <%:item.Prefix %>.&nbsp;<%:item.FullName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Gender)%></strong>
                             <%:item.Gender%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Nationality)%></strong>
                             <%:item.Nationality%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Age)%></strong>
                             <%:item.Age%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%></strong>
                             <%:item.IDTypeName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%></strong>
                             <%:item.IDNumber%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>

       
         <%  i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Senior Men"))
             {
                 i++; %>
               
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Senior Men Passenger (<%=i%>)</h3>
            <div class="form-box4">              
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].FullName)%></strong>
                             <%:item.Prefix %>.&nbsp; <%:item.FullName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Nationality)%></strong>
                             <%:item.Nationality%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Age)%></strong>
                             <%:item.Age%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%></strong>
                             <%:item.IDTypeName%>
                        </div>
                    </div>
                      <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%></strong>
                             <%:item.IDNumber%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>

         <%  i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Senior Women"))
             {
                 i++; %>
               
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Senior Women Passenger (<%=i%>)</h3>
            <div class="form-box4">                
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].FullName)%></strong>
                             <%:item.Prefix %>.&nbsp;<%:item.FullName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Nationality)%></strong>
                             <%:item.Nationality%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Age)%></strong>
                             <%:item.Age%>
                        </div>
                    </div>
                </div>
                 <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%></strong>
                             <%:item.IDTypeName%>
                        </div>
                    </div>
                      <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%></strong>
                             <%:item.IDNumber%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
         <%  i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Child"))
            {
                i++; %>
               
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Child Passenger (<%=i%>)</h3>
            <div class="form-box4">
               
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].FullName)%></strong>
                             <%:item.Prefix %>.&nbsp;<%:item.FullName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Gender)%></strong>
                             <%:item.Gender%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Nationality)%></strong>
                             <%:item.Nationality%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[0].Age)%></strong>
                             <%:item.Age%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>


        <div class="row-1 mrg-top-20">
            <h3>
                Booking Information
            </h3>
            <div class="form-box3 round-corner">
                 <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.TrainPNRId)%></strong>TRN0000<%:Model.TrainPNRId%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.CreateDate)%></strong><%:Model.CreateDate.ToShortDateString()%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.TrainName)%></strong><%:Model.TrainName%>
                             </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.TrainNo)%></strong><%:Model.TrainNo%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Fair)%></strong>Rs.<%:Model.Fair%>
                        </div>
                    </div>
                    <%if (Model.TicketStatusId == 3)
                      {%>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.RailWayPNR)%></strong><%:Model.RailWayPNR%>
                        </div>
                    </div>
                    <%} %>
                </div>
                <%--<div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <strong>
                                <%:Html.LabelFor(m => m.GSASCharge)%></strong>
                            <%:Model.GSASCharge%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <strong>
                                <%:Html.LabelFor(m => m.AHCharge)%></strong>
                            <%:Model.AHCharge%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <strong>
                                <%:Html.LabelFor(m => m.ExchangeRate)%></strong>
                            <%:Model.ExchangeRate%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <strong>
                                <%:Html.LabelFor(m => m.ChoiceSubjects)%></strong>
                            <%:Model.ChoiceSubjects%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

     <%if (Model.TicketStatusId == 1)
       { %>  
           <div class="buttonBar">
            <ul class="buttons-panel">        
                <li>
                     <input type="button" onclick="document.location.href='/Train/BookingRequest/Edit/<%=Model.TrainPNRId %>'" value="Edit" />
                     <input type="button" onclick="Process(<%=Model.TrainPNRId %>)" value="InProcess" />
                     <input type="button" onclick="Cancel(<%=Model.TrainPNRId %>)" value="Decline" />
                </li>
             </ul>
           </div>
       <%} %>
       <%if (Model.TicketStatusId == 7)
         {%>
         <div class="buttonBar">
            <ul class="buttons-panel">    
            <li>     
                <input type="button" onclick="document.location.href='/Train/BookingRequest/Book/<%=Model.TrainPNRId %>'" value="Book" />                
                    <input type="button" onclick="CancelInProcess(<%=Model.TrainPNRId %>)" value="Decline" />
                </li>
             </ul>
           </div>

       <%} %>
               

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">
    function Process(id) {
        document.location.href = '/Train/BookingRequest/InProcess/' + id;
    }

    function Cancel(id) {
        var con = confirm('Do you want to cancel?');
        if (con == true) {
            document.location.href = '/Train/BookingRequest/Cancel/' + id;
        }
    }

    function CancelInProcess(id) {
        var con = confirm('Do you want to cancel?');
        if (con == true) {
            document.location.href = '/Train/BookingRequest/CancelInProcess/' + id;
        }
    }
    </script>
</asp:Content>
