<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TrainMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-1">
 <% using (Html.BeginForm())
           { %>
        <div class="pageTitle">
            <ul class="buttons-panel">
             <li>
                    <input type="submit" value="Update" />
                </li>
                <li>
                    <input type="button" onclick="document.location.href='/Train/BookingRequest/'" value="Cancel" />
                </li>
               
            </ul>
            <h3>
                <a class="icon_plane" href="#">Booking Request</a> <span>&nbsp;</span><strong>Edit</strong>
            </h3>
        </div>
       
        <div class="row-1 mrg-top-20">
            <h3>
                Agent Detail
            </h3>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.HiddenFor(m => m.TrainPNRId)%><strong>
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
        
        <br />
         <div style="margin-bottom: 2%;">
            <h3 class="headingTlt2">
                Fare Detail</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                <%double fare = 0; %>
                    <%foreach (var item in Model.Passengers)
                      {
                          fare += item.Fare;
                          %>
                             
                            <div style="padding-left:35px"><%=(item.PassengerType) %>:<strong> <%:item.Fare %></strong></div>
                    <%} %>
                   
                    <div style="padding-left:35px">
                   <label> <strong>Total:<%=fare %></strong></label></div>
                      <div style="padding-left:35px"><label>IRCTCS Charge:</label><strong><%:Model.IRCTCSCharge %></strong></div>
                      <div style="padding-left:35px"><label>Agent Charge:</label><strong><%:Model.AgentCharge %></strong></div>
                      <div style="padding-left:35px"><u><label>AH Charge:</label><strong><%:Model.AHMarkUp %></strong></u></div>
                      <div style="padding-left:35px"><label>Grand Total:</label><strong><%=fare+Model.IRCTCSCharge+Model.AgentCharge+Model.AHMarkUp %></strong> </div>
                </div>
                </div>
            </div>
        <div class="row-1 mrg-top-20">
            <h3>
                PNR Address
            </h3>
          <%--  <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Prefix)%></strong>
                         <%:Html.DropDownListFor(m => m.Prefix,Model.ddlPrefixList)%>
                         <%:Html.ValidationMessageFor(m => m.Prefix)%>
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
                         <%:Html.TextBoxFor(m => m.FullName)%>
                         <%:Html.ValidationMessageFor(m => m.FullName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Gender)%></strong>
                         <%:Html.DropDownListFor(m => m.Gender,Model.ddlGenderList)%>
                         <%:Html.ValidationMessageFor(m => m.Gender)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Nationality)%></strong>
                         <%:Html.TextBoxFor(m => m.Nationality)%>
                         <%:Html.ValidationMessageFor(m => m.Nationality)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.Age)%></strong>
                         <%:Html.DropDownListFor(m => m.Age,Model.ddlAdultAgeList)%>
                         <%:Html.ValidationMessageFor(m => m.Age)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.IDTypeId)%></strong>
                         <%:Html.DropDownListFor(m => m.IDTypeId,Model.ddlIDTypeList)%>
                         <%:Html.ValidationMessageFor(m => m.IDTypeId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.IDNumber)%></strong>
                         <%:Html.TextBoxFor(m => m.IDNumber)%>
                         <%:Html.ValidationMessageFor(m => m.IDNumber)%>
                    </div>
                </div>
            </div>--%>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.PhoneNumber)%></strong>
                         <%:Html.TextBoxFor(m => m.PhoneNumber)%>
                         <%:Html.ValidationMessageFor(m => m.PhoneNumber)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.MobileNumber)%></strong>
                         <%:Html.TextBoxFor(m => m.MobileNumber)%>
                         <%:Html.ValidationMessageFor(m => m.MobileNumber)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><strong>
                         <%:Html.LabelFor(m => m.ContactAddress)%></strong>
                         <%:Html.TextBoxFor(m => m.ContactAddress)%>
                         <%:Html.ValidationMessageFor(m => m.ContactAddress)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div><strong>
                         <%:Html.LabelFor(m => m.EmailAddress)%></strong>
                         <%:Html.TextBoxFor(m => m.EmailAddress)%>
                         <%:Html.ValidationMessageFor(m => m.EmailAddress)%>
                    </div>
                </div>
            </div>
        </div>
        <%int id = -1; %>
        <% int i = 0;  foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Adult"))
           {
               i++; id++;%>
        <div class="row-1 mrg-top-20">
            <h3>
                Adult Passenger (<%=i%>)</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.HiddenFor(m => m.Passengers[id].TrainPassengerId)%><strong>
                            <%:Html.LabelFor(m => m.Passengers[id].Prefix)%></strong>
                            <%:Html.DropDownListFor(m => m.Passengers[id].Prefix, Model.Passengers[id].ddlPrefixList)%>
                            <%:Html.ValidationMessageFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.HiddenFor(m => m.Passengers[id].TrainPassengerId)%></strong>
                             <%:Html.HiddenFor(m => m.Passengers[id].PassengerType)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].FullName)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].FullName)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].FullName)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Gender)%></strong>
                             <%:Html.DropDownListFor(m => m.Passengers[id].Gender, Model.Passengers[id].ddlGenderList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Gender)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Nationality)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Nationality)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Nationality)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Age)%></strong>
                             <%:Html.DropDownListFor(m => m.Passengers[id].Age, Model.Passengers[id].ddlAdultAgeList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Age)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDTypeId)%></strong>
                             <%:Html.DropDownListFor(m => m.Passengers[id].IDTypeId, Model.Passengers[id].ddlIDTypeList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDTypeId)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDNumber)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].IDNumber)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDNumber)%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
       
        <% i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Senior Men"))
             {
                 i++; id++; %>
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Senior Men Passenger (<%=i%>)</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                   <%-- <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Prefix)%></strong>
                             <%:Html.DropDownListFor(m => m.Passengers[id].Prefix, Model.ddlPrefixList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>--%>
                    
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.HiddenFor(m => m.Passengers[id].TrainPassengerId)%>
                            <%:Html.HiddenFor(m => m.Passengers[id].PassengerType)%>
                              <%:Html.HiddenFor(m => m.Passengers[id].Gender)%>
                               <%:Html.HiddenFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].FullName)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].FullName)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].FullName)%>
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
                             <%:Html.LabelFor(m => m.Passengers[id].Nationality)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Nationality)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Nationality)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Age)%></strong>
                            <%-- <%:Html.DropDownListFor(m => m.Passengers[id].Age,Model.ddlSMAgeList)%>--%>
                           <%:Html.DropDownListFor(m => m.Passengers[id].Age, Model.Passengers[id].ddlSMAgeList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Age)%>
                        </div>
                    </div>
                </div>
                  <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDTypeId)%></strong>
                              <%:Html.DropDownListFor(m => m.Passengers[id].IDTypeId, Model.Passengers[id].ddlIDTypeList)%>
                  
                            <%-- <%:Html.DropDownListFor(m => m.Passengers[id].IDTypeId,Model.ddlIDTypeList)%>--%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDTypeId)%>
                        </div>
                    </div>
                     <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDNumber)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].IDNumber)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDNumber)%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>

        <% i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Senior Women"))
             {
                 i++; id++; %>
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Senior Women Passenger (<%=i%>)</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                    <%--<div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Prefix)%></strong>
                             <%:Html.DropDownListFor(m => m.Passengers[id].Prefix, Model.ddlPrefixList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>--%>
                    <div class="form-box1-row-content float-right">
                        <div>
                             <%:Html.HiddenFor(m => m.Passengers[id].TrainPassengerId)%>
                             <%:Html.HiddenFor(m => m.Passengers[id].PassengerType)%>
                             <%:Html.HiddenFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].FullName)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].FullName)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].FullName)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                            <%-- <%:Html.LabelFor(m => m.Passengers[id].Gender)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Gender)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Gender)%>--%>
                              <%:Html.HiddenFor(m => m.Passengers[id].Gender)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Nationality)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Nationality)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Nationality)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Age)%></strong>
                               <%:Html.DropDownListFor(m => m.Passengers[id].Age, Model.Passengers[id].ddlSFAgeList)%>
                       <%--      <%:Html.DropDownListFor(m => m.Passengers[id].Age,Model.ddlSFAgeList)%>--%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Age)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDTypeId)%></strong>
                                 <%:Html.DropDownListFor(m => m.Passengers[id].IDTypeId, Model.Passengers[id].ddlIDTypeList)%>
                           <%--  <%:Html.DropDownListFor(m => m.Passengers[id].IDTypeId,Model.ddlIDTypeList)%>--%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDTypeId)%>
                        </div>
                    </div>
                     <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].IDNumber)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].IDNumber)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].IDNumber)%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>

         <% i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Child"))
             {
                 i++; id++;%>
        <div class="row-1 mrg-top-20">
            <h3 class="headingTlt2">
                Child Passenger (<%=i%>)</h3>
            <div class="form-box4">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Prefix)%></strong>
                              <%:Html.DropDownListFor(m => m.Passengers[id].Prefix, Model.Passengers[id].ddlPrefixList)%>
                            <%-- <%:Html.DropDownListFor(m => m.Passengers[id].Prefix, Model.ddlPrefixList)%>--%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Prefix)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.HiddenFor(m => m.Passengers[id].TrainPassengerId)%>
                            <%:Html.HiddenFor(m => m.Passengers[id].PassengerType)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].FullName)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].FullName)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].FullName)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Gender)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Gender)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Gender)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Nationality)%></strong>
                             <%:Html.TextBoxFor(m => m.Passengers[id].Nationality)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Nationality)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div><strong>
                             <%:Html.LabelFor(m => m.Passengers[id].Age)%></strong>
                           <%--  <%:Html.DropDownListFor(m => m.Passengers[id].Age,Model.ddlChaildAgeList)%>--%>
                               <%:Html.DropDownListFor(m => m.Passengers[id].Age, Model.Passengers[id].ddlChaildAgeList)%>
                             <%:Html.ValidationMessageFor(m => m.Passengers[id].Age)%>
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
                </div>
            </div>
        </div>

        <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <%Html.RenderPartial("Utility/VUC_Message", Model.Message); %></li>
                <%--<li>
                    <input type="submit" value="Save" />
                </li>--%>
              <%--  <li>
                    <%:Html.ActionLink("Back To List", "Index", new { controller = "BookingRequest", area = "Train" }, new { @class = "linkButton" })%>
                </li>--%>
            </ul>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
