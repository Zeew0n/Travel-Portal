<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TrainMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Book
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm(null, null, FormMethod.Post, new { @autocomplete = "off", @enctype = "multipart/form-data" }))
   { %>
<div class="row-1">
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <input type="button" onclick="document.location.href='/Train/BookingRequest/Process'" value="Back to List" />
            </li>
        </ul>
        <h3>
            <a class="icon_plane" href="#">Booking Request(In Process)</a> <span>&nbsp;</span><strong>Book</strong>
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
                <%:Html.HiddenFor(m=>m.AgentId) %>
                    <%:Html.LabelFor(m => m.AgentName)%><strong><%:Model.AgentName%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.AgentCode)%><strong><%:Model.AgentCode%></strong>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.AgentAddress)%><strong><%:Model.AgentAddress%></strong>
                </div>
                <div>
                    <%:Html.LabelFor(m => m.AgentEmial)%><strong><%:Model.AgentEmial%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.AgentPhone)%><strong><%:Model.AgentPhone%></strong>
                </div>
                
            </div>
        </div>
        <div class="form-box1-row" style="border: 1px solid #000000;color:#2B7617;height:25px;font-weight:bold;font-size: 11px;">
                    <div class="form-box1-row-content float-left">
                        <div style="width:250px;">
                            <label>
                                <strong>Credit Limit:</strong></label>
                            <%:Model.AvilableBalance.CreditLimitNPR == null ? "N/A" : Model.AvilableBalance.CreditLimitNPR.Value.ToString("N2")%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div style="width:250px;">
                        <label>
                                <strong>Avilable Balance:</strong></label>
                            <%:Model.AvilableBalance.CurrentBalanceNPR == null ? "N/A" : Model.AvilableBalance.CurrentBalanceNPR.Value.ToString("N2")%>
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
                <div>
                    <%:Html.LabelFor(m => m.FromStationId)%><strong><%:Model.FromStationName%></strong>
                    <%:Html.HiddenFor(m => m.FromStationId)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.ToStationId)%><strong><%:Model.ToStationName%></strong>
                    <%:Html.HiddenFor(m => m.ToStationId)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.DepartureDate)%><strong><%:Model.DepartureDate.ToShortDateString()%></strong>
                    <%:Html.HiddenFor(m => m.DepartureDate)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                     <%:Html.LabelFor(m => m.NoOfAdult)%><strong><%:Model.NoOfAdult%></strong>
                    <%:Html.HiddenFor(m => m.NoOfAdult)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                   <%:Html.LabelFor(m => m.NoOfSM)%><strong><%:Model.NoOfSM%></strong>
                    <%:Html.HiddenFor(m => m.NoOfSM)%> 
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.NoOfChild)%><strong><%:Model.NoOfChild%></strong>
                    <%:Html.HiddenFor(m => m.NoOfChild)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                   <%:Html.LabelFor(m => m.NoOfSF)%><strong><%:Model.NoOfSF%></strong>
                    <%:Html.HiddenFor(m => m.NoOfSF)%>
                </div>
            </div>
        </div>
        </div>
    </div>
    <div class="row-1 mrg-top-20">
        <h3>
            PNR Address
        </h3>
      <%--  <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.Prefix)%><strong>
                    <%:Model.Prefix%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.FullName)%><strong>
                    <%:Model.FullName%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.Gender)%><strong>
                    <%:Model.Gender%></strong>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.Nationality)%><strong>
                    <%:Model.Nationality%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.Age)%><strong>
                    <%:Model.Age%></strong>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.IDTypeId)%><strong>
                    <%:Model.IDTypeName%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.IDNumber)%><strong>
                    <%:Model.IDNumber%></strong>
                </div>
            </div>
        </div>--%>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.PhoneNumber)%><strong>
                    <%:Model.PhoneNumber%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.MobileNumber)%><strong>
                    <%:Model.MobileNumber%></strong>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.ContactAddress)%><strong>
                    <%:Model.ContactAddress%></strong>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.EmailAddress)%><strong>
                    <%:Model.EmailAddress%></strong>
                </div>
            </div>
        </div>
    </div>
    
        <% int i = 0; foreach (var item in Model.Passengers.Where(x => x.PassengerType == "Adult"))
           {
               i++; %>
        <div class="row-1 mrg-top-20">
            <h3 ">
                Adult Passenger (<%=i%>)</h3>
            <div class="form-box4">               
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].FullName)%><strong>
                            <%:item.Prefix%>.&nbsp;<%:item.FullName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Gender)%><strong>
                            <%:item.Gender%></strong>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Nationality)%><strong>
                            <%:item.Nationality%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Age)%><strong>
                            <%:item.Age%></strong>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%><strong>
                            <%:item.IDTypeName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%><strong>
                            <%:item.IDNumber%></strong>
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
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].FullName)%><strong>
                           <%:item.Prefix %>.&nbsp;<%:item.FullName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Nationality)%><strong>
                            <%:item.Nationality%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Age)%><strong>
                            <%:item.Age%></strong>
                        </div>
                    </div>
                </div>
                 <div class="form-box1-row">
                 <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%><strong>
                            <%:item.IDTypeName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%><strong>
                            <%:item.IDNumber%></strong>
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
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].FullName)%><strong>
                            <%:item.Prefix %>.&nbsp;<%:item.FullName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Nationality)%><strong>
                            <%:item.Nationality%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Age)%><strong>
                            <%:item.Age%></strong>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDTypeId)%><strong>
                            <%:item.IDTypeName%></strong>
                        </div>
                    </div>
                     <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].IDNumber)%><strong>
                            <%:item.IDNumber%></strong>
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
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].FullName)%><strong>
                            <%:item.Prefix %>.&nbsp;<%:item.FullName%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Gender)%><strong>
                            <%:item.Gender%></strong>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Nationality)%><strong>
                            <%:item.Nationality%></strong>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <%:Html.LabelFor(m => m.Passengers[0].Age)%><strong>
                            <%:item.Age%></strong>
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
        <%--<div class="form-box3 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.TrainName)%>
                    <%:Html.TextBoxFor(m => m.TrainName)%>
                    <%: Html.ValidationMessageFor(model => model.TrainName)%>
                   
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.TrainNo)%>
                    <%:Html.TextBoxFor(m => m.TrainNo)%>
                    <%: Html.ValidationMessageFor(model => model.TrainNo)%>
                </div>
            </div>
        </div>--%>
        <div class="form-box1-row">
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
      <div class="form-box1-row" style="border: 1px solid #000000;color:#2B7617;height:22px;font-weight:bold;font-size: 11px;">
            <div class="form-box1-row-content float-left">
                <div>
                <label><strong> PNR File: </strong></label>
                   <input type="file" name="PNRFile" id="PNRFile" style="font-size: .9em;
                        padding: 0 4px;float:right;" class="required" />
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div><strong>
                    <%:Html.LabelFor(m => m.RailWayPNR)%></strong>
                    <%:Html.TextBoxFor(m => m.RailWayPNR, new { @class="required"})%>
                    <%: Html.ValidationMessageFor(model => model.RailWayPNR)%>
                    <%:Html.HiddenFor(m => m.TrainPNRId)%>
                </div>
            </div>
            </div>
        </div>
        <%--<div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.GSASCharge)%>
                    <%:Html.TextBoxFor(m=>m.GSASCharge) %>
                     <%: Html.ValidationMessageFor(model => model.GSASCharge)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%:Html.LabelFor(m => m.AHCharge)%>
                    <%:Html.TextBoxFor(m=>m.AHCharge) %>
                     <%: Html.ValidationMessageFor(model => model.AHCharge)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.IRCTCSCharge)%>
                    <%:Html.TextBoxFor(m=>m.IRCTCSCharge) %>
                     <%: Html.ValidationMessageFor(model => model.IRCTCSCharge)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                   <%:Html.LabelFor(m => m.ExchangeRate)%>
                    <%:Html.TextBoxFor(m => m.ExchangeRate)%>
                     <%: Html.ValidationMessageFor(model => model.ExchangeRate)%> 
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%:Html.LabelFor(m => m.ChoiceSubjects)%>
                    <%:Html.TextAreaFor(m => m.ChoiceSubjects)%>
                     <%: Html.ValidationMessageFor(model => model.ChoiceSubjects)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                   
                </div>
            </div>
        </div>--%>
        </div>
        </div>
         <div class="buttonBar">
            <ul class="buttons-panel">
                <li>
                    <%Html.RenderPartial("Utility/VUC_Message", Model.Message); %></li>
                <li>
                    <input type="submit" value="Issue" />
                </li><li>
               <input type="button" onclick="Cancel(<%=Model.TrainPNRId %>)" value="Decline"  />
               </li>
            </ul>
        </div>
        </div>
<%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">
    function Cancel(id) {
        var con = confirm('Do you want to cancel?');
        if (con == true) {
            document.location.href = '/Train/BookingRequest/Cancel/' + id;
        }
    }
</script>
</asp:Content>
