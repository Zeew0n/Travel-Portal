<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PromotionalFareModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
                <label id="lblSuccess" style="display: none; color: Green; font-weight: bold;">
                </label>
            </li>
           
            <li>
                <input type="button" onclick="document.location.href='/Airline/PromotionalFareSetup/'"
                    value="Cancel" />
            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong>Promotional Fare</strong>
        </h3>
        </div>
<fieldset class="style1" style="padding-left: 5px; padding-right: 5px;">
        <legend>Segment Info</legend>
    
     <% if (Model.PromotionalFareSector.PromotionalFareSegment != null)
           {
               for (int i = 0; i < Model.PromotionalFareSector.PromotionalFareSegment.Count; i++)
               {%>
        <div id="Sector_<%=i %>" class="SectorList">
            
            <table class="tableCityPair" id="Table1" style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <label>
                                From</label><br>
                            <%:Model.PromotionalFareSector.PromotionalFareSegment[i].FromCity%>
                        </td>
                        <td>
                            <label>
                                To</label><br>
                            <%:Model.PromotionalFareSector.PromotionalFareSegment[i].ToCity%>
                        </td>
                        <td>
                            <label>
                                Dept. Date/Time</label><br>
                            <%:Model.PromotionalFareSector.PromotionalFareSegment[i].DepartureDate%>
                          
                        </td>
                        <td>
                            <label>
                                Arr. Date/Time</label><br>
                            <%: Model.PromotionalFareSector.PromotionalFareSegment[i].ArrivalDate%>
                           
                        </td>
                        <td>
                            <label>
                                Flight No.</label><br>
                            <%: Model.PromotionalFareSector.PromotionalFareSegment[i].FlightNo%>
                         
                        </td>
                       
                    </tr>
                </tbody>
            </table>
        </div>
        <%}
           }%>
        <%--        <div class="buttonBar" id="addSegment">
            <a id="AddSector" href="javascript: void(0);">+ Add another flight</a>
        </div>--%>
    </fieldset>
    <br />
    <fieldset class="style1" style="padding-bottom: 0px;">
        <legend>Sector Info</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Airline
                    </label>
                    <%: Model.PromotionalFareSector.AirlineId%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Tour Code</label>
                    <%: Model.PromotionalFareSector.TourCode%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Currency</label>
                    <%: Model.PromotionalFareSector.CurrencyId%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Class
                    </label>
                    <%: Model.PromotionalFareSector.BICClass%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Fare Basis
                    </label>
                    <%: Model.PromotionalFareSector.FareBasis%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Effective From</label>
                    <%: Model.PromotionalFareSector.EffectiveFrom%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Expire On
                    </label>
                    <%:( Model.PromotionalFareSector.ExpireOn)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        No Of Pax
                    </label>
                    <%:(Model.PromotionalFareSector.NoOfPax)%>
                 
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Base Fare
                    </label>
                    <%:(Model.PromotionalFareSector.BaseFare)%>
                   
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Other Charges
                    </label>
                    <%: Model.PromotionalFareSector.OtherCharges%>
                   
                </div>
            </div>
        </div>
        <div class="form-box1-row" style="border-left: 1px solid #CCCCCC; background: #F8F8F8;
            border-top: 1px solid #CCCCCC; float: right; margin-top: 10px; padding: 5px 10px;
            width: 62%;">
            <h4>
                <strong>Tax</strong></h4>
            <% if (Model.PromotionalFareSector.Taxes != null)
               {
                   for (int i = 0; i < Model.PromotionalFareSector.Taxes.Count; i++)
                   {%>
            <div class="float-left TaxesList" style="width: 100%; margin-bottom: 5px;" id="Tax_<%=i %>">
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    
                    <div>
                        <label style="width: 60px;">
                            Tax Name</label>
                        <%: Model.PromotionalFareSector.Taxes[i].TaxName%>
                       
                    </div>
                </div>
                <div class="form-box1-row-content float-left" style="width: 42%;">
                    <div>
                        <label style="width: 60px;">
                            Tax Amount</label>
                        <%: Model.PromotionalFareSector.Taxes[i].TaxAmount%>
                      
                    </div>
                </div>
              
            </div>
            <%}
               } %>
           
        </div>
    </fieldset>










   <%-- <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline:</label>
                        <%: Model.PromotionalFareSector.AirlinesList %>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            From Date:</label>
                        <%:Model.PromotionalFareSector%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Country:</label>
                            <%if (Model.Countries!= null)
                              { %>
                        <%:Model.Countries.CountryName%>
                        <%}%>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

</asp:Content>
