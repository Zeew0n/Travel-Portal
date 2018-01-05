<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<div style="width: 720px; margin: 20px auto 0px; font-family: Tahoma; font-size: 13px;
        padding: 10px; page-break-after: always">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <colgroup>
                <col width="30%">
                <col width="40%">
                <col width="30%">
            </colgroup>
            <tbody>
                <tr>
                    <td>                          
                    </td>
                    <td>
                        <div style="text-align: center;" >
                            <strong>Jay Ganga Tour & Travel Pvt Ltd</strong>
                            <br/>
                            Dharmapath,New Road<br/>
                            Kathmandu, Nepal<br/>
                            GSA<br/>
                            Indian Railway&nbsp; &nbsp;&nbsp;IRCTC Limited
                        </div>
                    </td>
                 </tr>
           
              
            </tbody>
        </table>
        </br>
        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="border: 1px solid #000;">
            <tbody>
                <tr>
                <td style="text-align:center; border:2px solid #000;"><strong>Indian Railway</strong><br />
E-RESERVATION / CANCELLATION REQUISITION FORM</td>
                </tr>
                <tr>
                <td>
                Please issue/Cancel the Indian Railway Reservation E- Tickets as per detailed below:</td></tr>
                </tbody>
                </table>
     
        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="border:1px solid #000; ">
        	
            	<tr>
                	<td>Train No. & Name:<strong><%:Model.TrainNo %>&nbsp;&nbsp;&&nbsp;&nbsp;<%:Model.TrainName %></strong></td>
                    <td>&nbsp;</td>
                    <td>Date of Journey:<strong><%:Model.DepartureDate.ToShortDateString() %></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                	<td>Class:<strong><%:Model.TrainClassName %></strong></td>
                    <td>&nbsp;</td>
                    <td>Nos.of Berth/Seat:<strong><%:Model.NoOfSeat %></strong></td>
                    <td>&nbsp;</td>
                </tr>
                
                <tr>
                	<td>Station from:<strong><%:Model.FromStationName %></strong></td>
                    <td>&nbsp;</td>
                    <td>To:<strong><%:Model.ToStationName %></strong></td>
                    <td>&nbsp;</td>
                </tr>
                
                <tr>
                	<td>Boarding at:<strong><%:Model.FromStationName %></strong></td>
                    <td>&nbsp;</td>
                    <td>Reservation upto:<strong><%:Model.ToStationName %></strong></td>
                    <td>&nbsp;</td>
                </tr>
            
        </table>


        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="border: 1px solid #000;">
            <tbody>
                <tr>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>SNo.</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #000;">
                        <strong>Name of Passenger in Block Letters</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #000;"><strong>Gender M/F</strong>
                        
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #000;"><strong>Age</strong>
                        
                    </td>
                    
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #000;"><strong>Choice if any subject to availability</strong>
                        
                    </td>
                    
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #000;"><strong>Nationality</strong>
                        
                    </td>
                    
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666;border-right: 1px solid #000;"><strong>Citizenship/Passport/ID No.</strong>
                        
                    </td>
                     <td style="padding: 2px 5px; border-bottom: 1px solid #666;"><strong>Type</strong>
                        
                    </td>
                </tr>
             


                <%var sn = 0;
                  var count = Model.NoOfAdult;

                  foreach (var item in Model.Passengers)
                  {
                      sn++;
                      count--;
                    %>
               
                <tr>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                       <strong><%:sn%></strong>
                    </td>
                    <td style="padding: 2px 5px; text-transform: uppercase; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong><%:item.FullName%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong><%:item.Gender%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                       <strong><%:item.Age%></strong>
                    </td>
                   
                   
                    <% if (count == 0)
                       {%>
                    <td rowspan="1" style="padding: 2px 5px; border-bottom: 0px solid #666; border-right: 1px solid #666;">
                       Lower Berth/ UpperBerth Veg/Non Veg <br />Meal for Rajdhani/Shatabdi Express only
                    </td>
                    <%--<%status = 1;%>--%>
                    <%} %>

                    <%else
                       { %>
                       <td style="padding: 2px 5px; border-right: 1px solid #666;"></td>
                    <%} %>

                  
                   
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                       <strong><%:item.Nationality%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                       <strong><%:item.IDNumber%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                       <strong><%:item.PassengerType%></strong>
                    </td>
                  <%} %>
                </tr>
                 
           
           
            </tbody>
        

        </table>
    
        <%--<p style="margin:0; padding:0;">TRAVELLING CHILDREN BELOW 5 YEARS (FOR WHOM TICKET IS NOT TO BE ISSUED)</p>--%>
       
       <%-- <table cellspacing="0" cellpadding="0" border="0" width="100%" style="border: 1px solid #000;">
            <thead>
                <tr>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>S.No.</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>Name in Block Letters</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>Gender M/F</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>Age</strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                        <strong>Remarks</strong>
                    </td>
                </tr>
            </thead>
       
       

               <% var snO = 0;
                  foreach (var item in Model.Passengers.Where(u=>u.PassengerType=="Child"))
                  {

                      snO++;
                     %> 
            <tbody>
                <tr>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                         <strong><%:snO%></strong>
                    </td>
                    <td style="padding: 2px 5px; text-transform: uppercase; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                       <strong><%:item.FullName%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                       <strong><%:item.Gender%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                      <strong><%:item.Age%></strong>
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                      <strong></strong>
                    </td>
                </tr>
                <%} %>
                
             <%--   <tr>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                       
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                       
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                        
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                        
                    </td>
                    <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;">&nbsp;
                        
                    </td>
                </tr>--%>
      
            <%--</tbody>
        
        </table>--%>
        <br>
        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="border: 1px solid #000;">
            
                
        
            
            <tbody>
               <%-- <tr>
                    <td colspan="7" style="border-bottom:1px solid #000;">ONWARD/RETURN JOURNEY DETAILS</td>
                </tr>
                
                <tr>
                	<td>Train No.& Name:<strong></strong></td>
                    <td>&nbsp;</td>
                    <td>Date:<strong></strong></td>
                    <td colspan="3">&nbsp;</td>
                </tr>
                
                   <tr>
                	<td>Class:<strong></strong></td>
                    <td>&nbsp;</td>
                    <td>Station from:<strong></strong></td>
                    <td>&nbsp;</td>
                    <td>To:<strong></strong></td>
                    <td>&nbsp;</td>
                    
                </tr>
                --%>
                <tr>
                    <td colspan="7" style="border-bottom:1px solid #000;">DETAILS OF ID TO BE USED AT THE TIME OF JOURNEY</td>
                </tr>
                
                <tr>
                	<td>Type:<strong><%:Model.Passengers.Where(x=>x.IsPrimary==true).Select(x=>x.IDTypeName).FirstOrDefault()%></strong></td>
                    <td>&nbsp;</td>
                    <td>ID NO.<strong><%:Model.Passengers.Where(x=>x.IsPrimary==true).Select(x=>x.IDNumber).FirstOrDefault()%></strong></td>
                    <td>&nbsp;</td>
                    <td>Issuing authority</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                
                   <tr>
                	<td>Applicant's Name:<strong><%:Model.Passengers.Where(x=>x.IsPrimary==true).Select(x=>x.FullName).FirstOrDefault() %></strong></td>
                    <td colspan="6">&nbsp;</td>
                </tr>
                
                <tr>
                	<td>Full Address:<strong><%:Model.ContactAddress%></strong></td>
                    <td>&nbsp;</td>
                     <td>Date:<%--<strong><%:Model.DepartureDate.ToShortDateString() %></strong>--%></td>
                    <td>&nbsp;</td>
                    <td>Time:<%--<strong><%:Model.DepartureTime %></strong>--%></td>
                    <td colspan="2">&nbsp;</td>
                   
                </tr>
                
                <tr>
                	<td>Telephone No, Mobile No, if any:<strong><%:Model.PhoneNumber %></strong>,&nbsp;&nbsp;<strong><%:Model.MobileNumber %></strong></td>
                    <td colspan="6">&nbsp;</td>
                </tr>
                
                <tr>
                	<td colspan="7">I undertake that the information / Particulars given here above are true & correct and I shall be held
            responsible or liable for any given false or misleading information.</td>
                </tr>
                
                <tr>
                	<td colspan="6" style="text-align:right;">&nbsp;</td>
                </tr>
                <tr>
                	<td colspan="6" style="text-align:right;">Signature of the Applicant/Representative</td>
                </tr>
            </tbody>
     </table>
     
     <table style="border:1px solid #000;">
     	<tr>
        	<td>Jay Ganga Tour & Travel Pvt Ltd. is not liable / responsible for any loss, damage occured due to false information particulars furnished by the applicant / representative.</td>
        </tr>
     </table>
     
  <%--   <table border="0" width="100%" style="border:1px solid #000;">
     	<tr>
        	<td><strong>FOR OFFICE USE ONLY</strong></td>
            <td>Requisition Slip No.</td>
            <td>&nbsp;</td>
            <td>PNR No.<strong></strong></td>
            <td colspan="2">&nbsp;</td>
        </tr>
        
        <tr>
        	<td>Berth/Seat No.</td>
            <td>&nbsp;</td>
            <td>Amount collected</td>
            <td>&nbsp;</td>
            <td>Date</td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
        	<td colspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="text-align:right;">Signature of Reservation official</td>
        </tr>
     </table>
        
            
        <br>
        <div class="note-list">
        	<p>Note:</p>
        	<ol>
            	<li>Maximum permissible passengers is 6 per requistion.</li>
                <li>One person can give one requisition form at a time.</li>
                <li>Please check your ticket and balance amount before leaving the window.</li>
                <li>Forms not properly filled or in illegible forms shall not be entertained.</li>
                <li>Choice is subject to availability.</li>
                <li>Please keep your E-Ticket and ID always with you during the Journey.</li>
                <li>Refunds of cancelled Tickets shall be allowed as per Indian Railway Rules and services charges of IRCTC and GSA shall not be refunded.</li>
                <li>Passenger travelling on False information/ID may be prosecuted with fine or jail or both by the Indian Govt./ Railway Authorities.</li>
            </ul>
        </div>--%>
    </div>